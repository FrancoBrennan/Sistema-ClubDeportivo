using CapaDeDatos;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeNegocios
{
    [Serializable]
    public class Club
    {
        private List<Actividad> actividades;
        private List<Socio> socios;
        private List<Clase> clases;
        private List<Profesor> profesores;
        private List<Pago> pagos;
        private ProfesorDatos profDatos;
        private ActividadDatos actividadDatos;
        private ClaseDatos claseDatos;
        private PagoDatos pagoDatos;
        private SocioActividadDatos socioActividadDatos;
        private SocioClubDatos socioClubDatos;
        private ActividadClaseDatos actividadClaseDatos;
        private ProfesorClaseDatos profesorClaseDatos;
        private SocioClaseDatos socioClaseDatos;
        private SocioPagoDatos socioPagoDatos;

        public Club()
        {
            this.profDatos = new ProfesorDatos();
            this.actividadClaseDatos = new ActividadClaseDatos();
            this.actividadDatos = new ActividadDatos();
            this.profesorClaseDatos = new ProfesorClaseDatos();
            this.socioClubDatos = new SocioClubDatos();
            this.socioClaseDatos = new SocioClaseDatos();
            this.socioActividadDatos = new SocioActividadDatos();
            this.socioPagoDatos = new SocioPagoDatos();
            this.pagoDatos = new PagoDatos();
            this.claseDatos = new ClaseDatos();

            InicializarListas();
            cargarDatos();
            vincularRelacionClases();
        }

        // Método para inicializar las listas
        public void InicializarListas()
        {
            actividades = new List<Actividad>();
            socios = new List<Socio>();
            clases = new List<Clase>();
            profesores = new List<Profesor>();
            pagos = new List<Pago>();
        }

        public List<Actividad> Actividades
        {
            get { return actividades; }
            set { actividades = value; }
        }

        public List<Socio> Socios
        {
            get { return socios; }
            set { socios = value; }
        }

        public List<Clase> Clases
        {
            get { return clases; }
            set { clases = value; }
        }

        public List<Profesor> Profesores
        {
            get { return profesores; }
            set { profesores = value; }
        }

        public List<Pago> Pagos
        {
            get { return pagos; }
            set { pagos = value; }
        }

        public static Club Cargar()
        {
            Club club = (Club)Datos.Recuperar();
            if (club == null)
            {
                club = new Club();
            }
            return club;
        }

        public void guardar()
        {
            Datos.Guardar(this);
        }

        public void agregarActividad(Actividad newAct)
        {
            actividades.Add(newAct);
            actividadDatos.agregar(newAct.Id, newAct.Nombre, newAct.Precio);
        }

        public void agregarSocio(Socio newSoc)
        {
            socios.Add(newSoc);
            
            if(newSoc.usaCuota())
            {
                socioClubDatos.agregar(newSoc.Dni, newSoc.Nombre, newSoc.FechaNac, ((SocioClub)newSoc).CuotaSocial, newSoc.Email, newSoc.Direccion);
            }
            else
            {
                socioActividadDatos.agregar(newSoc.Dni, newSoc.Nombre, newSoc.FechaNac, newSoc.Email, newSoc.Direccion);
            }
        }

        public void agregarClase(Clase c)
        {
            clases.Add(c);
            claseDatos.agregar(c.Id,c.Dia,c.Hora,c.CupoMax);

            //BD: Se crea la relación entre Actividad y Clase
            c.Act.agregarClaseBD(c);

            //BD: Se crea la relación entre Profesor y Clase
            c.Prof.agregarClaseBD(c);
        }

        public void agregarProfesor(Profesor newProf)
        {
            profesores.Add(newProf);
            profDatos.agregar(newProf.Dni, newProf.Nombre, newProf.FechaNac, newProf.Legajo);
        }

        public void removerActividad(Actividad act)
        {
            //Remueve todas las clases que tengan esa actividad.

            foreach (var c in act.Clase)
            {
                c.removerDeProfesorYSocios();

                // Eliminar clase de la base de datos
                claseDatos.eliminar(c.Id);

                clases.Remove(c);
            }

            act.borrarClases();
            actividades.Remove(act);

            actividadDatos.eliminar(act.Id);
        }

        public void removerSocio(Socio soc)
        {
            soc.removerDeTodaLaBD();

            socios.Remove(soc);
            
        }

        public void removerProfesor(Profesor prof)
        {

            profesorClaseDatos.removerRelacionDniProf(prof.Dni);

            profDatos.eliminar(prof.Dni);

            profesores.Remove(prof);
        }

        public void removerClase(Clase c)
        {            
            actividadClaseDatos.removerRelacion(c.Id,c.Act.Id);

            profesorClaseDatos.removerRelacion(c.Id,c.Prof.Dni);

            claseDatos.eliminar(c.Id);

            c.removerRelacionesSocios();

            clases.Remove(c);
        }

        public void removerPago(Pago p)
        {
            pagoDatos.eliminar(p.Id);
            socioPagoDatos.removerRelacionPorPago(p.Id);
            pagos.Remove(p);
        }

        public bool verificarActividad(Actividad nuevaActividad)
        {
            return actividades.Any(actividad => actividad.Id == nuevaActividad.Id);
        }

        public bool verificarSocio(Socio nuevoSocio)
        {
            return socios.Any(socio => socio.Dni == nuevoSocio.Dni);
        }

        public bool verificarProfesor(Profesor nuevoProf)
        {
            return profesores.Any(profesor => profesor.Legajo == nuevoProf.Legajo || profesor.Dni == nuevoProf.Dni);
        }

        public bool verificarClase(Clase nuevaClase)
        {
            return clases.Any(clase => clase.Id == nuevaClase.Id);
        }

        public void generarPago(Socio socio)
        {
            float total = socio.calcularMontoTotal();
            Pago pago = new Pago(this.pagos.Count, DateTime.Now, socio, total);
            this.pagos.Add(pago);
            pagoDatos.agregar(pago.Id, pago.FechaPaga, pago.MontoTotal);
            socioPagoDatos.agregarRelacion(socio.Dni, pago.Id);
        }

        private void cargarDatos()
        {
            cargarProfesores();
            cargarActividades();
            cargarClases();
            cargarPagos();
            cargarSociosActividad();
            cargarSociosClub();
        }

        private void cargarProfesores()
        {
            OleDbDataReader readers = profDatos.listarProfesores();

            while (readers.Read())
            {
                Profesor nuevoProf = new Profesor((int)readers["DNI"], (string)readers["Nombre"], DateTime.Parse((string)readers["FechaNacimiento"]), (int)readers["Legajo"]);
                profesores.Add(nuevoProf);
            }

            readers.Close();
        }

        private void cargarActividades()
        {
            OleDbDataReader readers = actividadDatos.listar();

            while (readers.Read())
            {
                Actividad nuevaAct = new Actividad((int)readers["ID"], (string)readers["Nombre"], float.Parse((string)readers["Precio"]), null);
                actividades.Add(nuevaAct);
            }

            readers.Close();
        }

        private void cargarClases()
        {
            OleDbDataReader readers = claseDatos.listar();

            while (readers.Read())
            {
                Clase nuevaClase = new Clase((int)readers["ID"], null, (string)readers["Dia"], (int)readers["Hora"], null, (int)readers["CupoMaximo"]);
                clases.Add(nuevaClase);
            }

            readers.Close();
        }

        private void cargarPagos()
        {
            OleDbDataReader readers = pagoDatos.listar();

            while (readers.Read())
            {
                Pago nuevoPago = new Pago((int)readers["ID"], DateTime.Parse((string)readers["FechaPaga"]), null, float.Parse((string)readers["MontoTotal"]));
                pagos.Add(nuevoPago);
            }

            readers.Close();
        }

        private void cargarSociosActividad()
        {
            OleDbDataReader readers = socioActividadDatos.listar();

            while (readers.Read())
            {
                SocioActividad nuevoSocAct = new SocioActividad((int)readers["DNI"], (string)readers["Nombre"], DateTime.Parse((string)readers["FechaNacimiento"]), (string)readers["Email"], (string)readers["Direccion"]);
                socios.Add(nuevoSocAct);
            }

            readers.Close();
        }

        private void cargarSociosClub()
        {
            OleDbDataReader readers = socioClubDatos.listar();

            while (readers.Read())
            {
                SocioClub nuevoSocClub = new SocioClub((int)readers["DNI"], (string)readers["Nombre"], DateTime.Parse((string)readers["FechaNacimiento"]), (string)readers["Email"], (string)readers["Direccion"], float.Parse((string)readers["CuotaSocial"]));
                socios.Add(nuevoSocClub);
            }

            readers.Close();
        }


        private void vincularRelacionClases()
        {

            // Vincular Profesor con Clase
            OleDbDataReader reader = profesorClaseDatos.listarRelaciones();

            while (reader.Read())
            {
                int profesorId = reader.GetInt32(0);
                int claseId = reader.GetInt32(1);

                Profesor profesor = profesores.FirstOrDefault(p => p.Dni == profesorId);
                Clase clase = clases.FirstOrDefault(c => c.Id == claseId);

                if (profesor != null && clase != null)
                {
                    profesor.agregarClase(clase);
                    clase.Prof = profesor;
                }
            }
            

            // Vincular Socio con Clase
            reader = socioClaseDatos.listarRelaciones();
            while (reader.Read())
            {
                int socioId = reader.GetInt32(0);
                int claseId = reader.GetInt32(1);

                Socio socio = socios.FirstOrDefault(s => s.Dni == socioId);
                Clase clase = clases.FirstOrDefault(c => c.Id == claseId);

                if (socio != null && clase != null)
                {
                    socio.agregarClase(clase);
                    clase.agregarSocio(socio);
                }
            }

            // Vincular pago con Socio 
            reader = socioPagoDatos.listarRelaciones();
            while (reader.Read())
            {
                int socioId = reader.GetInt32(0);
                int pagoId = reader.GetInt32(1);

                Socio socio = socios.FirstOrDefault(s => s.Dni == socioId);
                Pago pago = pagos.FirstOrDefault(p => p.Id == pagoId);

                if (socio != null && pago != null)
                {
                    pago.Socio = socio;
                }
            }


            // Vincular Actividad con Clase
            reader = actividadClaseDatos.listarRelaciones();
            while (reader.Read())
            {
                int claseId = reader.GetInt32(0);
                int actividadId = reader.GetInt32(1);

                Actividad actividad = actividades.FirstOrDefault(a => a.Id == actividadId);
                Clase clase = clases.FirstOrDefault(c => c.Id == claseId);

                if (actividad != null && clase != null)
                {
                    actividad.agregarClase(clase);
                    clase.Act = actividad;
                }
            }
            reader.Close();
        }


    }
}
