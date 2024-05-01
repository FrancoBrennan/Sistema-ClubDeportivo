using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public class SocioActividad : Socio
    {
        public SocioActividad(int dni, string nombre, DateTime fechaNac, string email, string direccion) : base(dni, nombre, fechaNac, email, direccion)
        {
            
        }

        public override float calcularMontoTotal()
        {
            float total=0;

            for(int i = 0; i < this.clases.Count; i++)
            {
                total += this.clases[i].Act.Precio;
            }

            return total;
        }
    }
}
