using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public class Profesor : Persona
    {
        private int legajo;

        public Profesor(int dni, string nombre, DateTime fechaNac, DateTime fechaIng, int legajo) : base(dni,nombre,fechaNac,fechaIng){
            this.legajo = legajo;
        }


    }
}
