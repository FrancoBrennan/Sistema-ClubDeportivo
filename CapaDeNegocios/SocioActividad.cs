using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public class SocioActividad : Socio
    {

        private SocioActividadDatos actDat;
        
        public SocioActividad(int dni, string nombre, DateTime fechaNac, string email, string direccion) : base(dni, nombre, fechaNac, email, direccion)
        {
            this.actDat = new SocioActividadDatos();
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

        public override void modificarBD()
        {
            actDat.modificar(this.Dni, this.Nombre, this.FechaNac, this.Email, this.Direccion);
        }

        public override void removerDeTodaLaBD()
        {
            //Elimino todas las relaciones en la Tabla SocioClase

            this.ClaseDatos.removerRelacionPorDni(this.Dni);

            //Elimino al Socio de la BD

            this.actDat.eliminar(this.Dni);
            
            this.borrarPagosDB();

            foreach (Clase c in this.Clases)
            {
                c.quitarSocio(this);
            }
        }


    }
}
