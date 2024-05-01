using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public abstract class Socio : Persona
    {
        private string email;
        private string direccion;

        public Socio(int dni, string nombre, DateTime fechaNac, string email, string direccion) :base(dni,nombre,fechaNac)
        {
            this.email = email;
            this.direccion = direccion;
        }

        public abstract float calcularMontoTotal();

        public void remover()
        {
            foreach (var c in this.clases)
            {
                c.quitarSocio(this);
            }

        }

        public virtual bool usaCuota()
        {
            return false;
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
