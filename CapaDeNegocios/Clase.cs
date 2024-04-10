using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
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

        public Actividad Act
        {
            get { return act; }
        }

        public void agregarSocio(Socio newSocio)
        {
            if (!verificarSocio(newSocio) && verificarCupo())
            {
                socios.Add(newSocio);
            }
            else
            {

            }
            
        }

        public bool verificarCupo()
        {
            return socios.Count() <this.cupoMax;
        }

        public bool verificarSocio(Socio s)
        {
            return socios.Any(c => c.Dni == s.Dni);
        }

        public void quitarSocio(Socio s)
        {
            socios.Remove(s);
        }
    }
}
