using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public class Clase
    {
        private int id;
        private Actividad act;
        private string dia;
        private int hora;
        private List<Socio> socios;
        private Profesor prof;
        private int cupoMax;
        private ActividadClaseDatos actClasDat;
        private ProfesorClaseDatos profClasDat;
        private SocioClaseDatos socClasDat;
        private ClaseDatos claseDatos;

        public Clase(int id, Actividad act, string dia, int hora, Profesor prof, int cupoMax)  //Se quitó la lista de clases
        {
            this.id = id;
            this.act = act;
            this.dia = dia;
            this.hora = hora;
            this.prof = prof;
            this.cupoMax = cupoMax;

            actClasDat = new ActividadClaseDatos();
            profClasDat = new ProfesorClaseDatos();
            socClasDat = new SocioClaseDatos();
            claseDatos = new ClaseDatos();
            socios = new List<Socio>();

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Actividad Act
        {
            get { return act; }
            set { act = value; }
        }

        public string Dia
        {
            get { return dia; }
            set { dia = value; }
        }

        public int Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        public List<Socio> Socios
        {
            get { return socios; }
            set { socios = value; }
        }

        public Profesor Prof
        {
            get { return prof; }
            set { prof = value; }
        }

        public int CupoMax
        {
            get { return cupoMax; }
            set { cupoMax = value; }
        }

        public void agregarSocio(Socio newSocio)
        {
            if (!verificarSocio(newSocio) && verificarCupo())
            {
                socios.Add(newSocio);
            }
            
        }

        public bool verificarCupo()
        {
            return socios.Count() < this.cupoMax;
        }

        public bool verificarSocio(Socio s)
        {
            return socios.Any(c => c.Dni == s.Dni);
        }

        public void quitarSocio(Socio s)
        {
            socios.Remove(s);
        }

        public void removerDeProfesorYSocios()
        {
            if (this.prof != null)
            {
                this.prof.quitarClase(this);

                foreach (Socio s in socios)
                {
                    s.quitarClase(this);
                }
            }
        }

        public void removerProfesor()
        {
            this.prof = null;
        }

        public void removerRelacionesSocios()
        {
            foreach(Socio soc in socios)
            {
                soc.quitarClase(this);
            }
        }

        public void removerRelacionProfesor()
        {
            profClasDat.removerRelacionIdClase(this.Id);
        }

        
        public override string ToString()
        {
            return this.id + "-" + this.act.Nombre + "-" + this.dia + "-" + this.hora + " hs."; //Arreglar esto
        }

        public  void modificarClaseBD()
        {
            this.claseDatos.modificar(this.Id, this.dia, this.hora, this.cupoMax);
        }
        
        public void agregarRelacionConSocio(Socio soc)
        {
            socClasDat.agregarRelacion(soc.Dni, this.id);
        }

        public void removerRelacionConSocio(Socio soc)
        {
            socClasDat.removerRelacion(soc.Dni,this.id);
        }
        
    }
}
