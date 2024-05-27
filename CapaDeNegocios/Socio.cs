using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public abstract class Socio : Persona
    {
        private string email;
        private string direccion;
        private SocioClaseDatos claseDatos;
        private SocioPagoDatos socioPagoDatos;

        public Socio(int dni, string nombre, DateTime fechaNac, string email, string direccion) : base(dni, nombre, fechaNac)
        {
            this.email = email;
            this.direccion = direccion;
            this.claseDatos = new SocioClaseDatos();
            this.socioPagoDatos = new SocioPagoDatos();
        }

        public abstract float calcularMontoTotal();

        public override void quitarClase(Clase c)
        {
            this.ClaseDatos.removerRelacion(this.Dni, c.Id);
            this.Clases.Remove(c);
        }

        public override void agregarClase(Clase c)
        {
            this.Clases.Add(c);
        }

        public abstract void removerDeTodaLaBD();

        public void borrarPagosDB()
        {
            socioPagoDatos.removerRelacionPorDni(this.Dni);
        }

        public SocioClaseDatos ClaseDatos
        {
            get { return claseDatos; }
            set { claseDatos = value; }
        }

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
