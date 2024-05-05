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

        public Clase(int id, Actividad act, string dia, int hora, List<Socio> socios, Profesor prof, int cupoMax)
        {
            this.id = id;
            this.act = act;
            this.dia = dia;
            this.hora = hora;
            this.socios = socios;
            this.prof = prof;
            this.cupoMax = cupoMax;
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

        public override string ToString()
        {
            return this.id + "-" + this.act.Nombre + "-" + this.dia + "-" + this.hora + " hs.";
        }
    }
}
