using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
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

        public void agregarActividad(Actividad newAct)
        {
            actividades.Add(newAct);
        }

        public void agregarSocio(Socio newSoc)
        {
            socios.Add(newSoc);
        }

        public void agregarComision(Clase newCom)
        {
            clases.Add(newCom);
        }

        public void agregarProfesor(Profesor newProf)
        {
            profesores.Add(newProf);
        }

        public void agregarPago(Pago newPago)
        {
            this.pagos.Add(newPago);
        }

        /*
        public void removerActividad(Actividad act)
        {
            foreach (var c in act.Comisiones)
            {
                comisiones.Remove(c);
            }

            act.limpiarComisiones();
            actividades.Remove(act);
        }
        */

        public void quitarSocio(Socio soc)
        {
            socios.Remove(soc);
        }

        public void quitarProfesor(Profesor prof)
        {
            profesores.Remove(prof);
        }

        public void quitarComision(Clase com)
        {
            clases.Remove(com);
        }

    }
}
