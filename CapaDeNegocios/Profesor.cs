using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public class Profesor : Persona
    {
        private int legajo;
        private ProfesorClaseDatos profClasDat;

        public Profesor(int dni, string nombre, DateTime fechaNac, int legajo) : base(dni,nombre,fechaNac){
            this.legajo = legajo;
            profClasDat = new ProfesorClaseDatos();
        }

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public override void agregarClase(Clase c)
        {
            profClasDat.agregarRelacion(this.Dni, c.Id);
            clases.Add(c);
        }

        public override void quitarClase(Clase c)
        {
            profClasDat.removerRelacion(c.Id, this.Dni);
            clases.Remove(c);
        }

        public void removerDeClases()
        {
            foreach(Clase clase in this.clases) {
                clase.removerProfesor();
            }
        }

    }
}
