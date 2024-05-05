using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Club()
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
        }

        public void agregarSocio(Socio newSoc)
        {
            socios.Add(newSoc);
        }

        public void agregarClase(Clase c)
        {
            clases.Add(c);
        }

        public void agregarProfesor(Profesor newProf)
        {
            profesores.Add(newProf);
        }

        public void agregarPago(Pago newPago)
        {
            this.pagos.Add(newPago);
        }

        
        public void removerActividad(Actividad act)
        {
            foreach (var c in act.Clase)
            {
                clases.Remove(c);
            }

            act.borrarClases();
            actividades.Remove(act);
        }

        public void removerSocio(Socio soc)
        {
            socios.Remove(soc);
        }

        public void removerProfesor(Profesor prof)
        {
            profesores.Remove(prof);
        }

        public void removerClase(Clase c)
        {
            clases.Remove(c);
        }

        public void removerPago(Pago p)
        {
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
        }

    }
}
