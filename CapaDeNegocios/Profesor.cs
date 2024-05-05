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

        public Profesor(int dni, string nombre, DateTime fechaNac, int legajo) : base(dni,nombre,fechaNac){
            this.legajo = legajo;
        }

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public void removerDeClases()
        {
            foreach(Clase clase in this.clases) {
                clase.removerProfesor();
            }
        }

    }
}
