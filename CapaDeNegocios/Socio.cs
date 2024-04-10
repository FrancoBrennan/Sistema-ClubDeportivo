using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public abstract class Socio : Persona
    {
        private int id;
        private string email;
        private string direccion;

        public Socio(int dni, string nombre, DateTime fechaNac, DateTime fechaIng, int id, string email, string direccion) :base(dni,nombre,fechaNac,fechaIng)
        {
            this.id = id;
            this.email = email;
            this.direccion = direccion;
        }

        public abstract float calcularMontoTotal();
    }
}
