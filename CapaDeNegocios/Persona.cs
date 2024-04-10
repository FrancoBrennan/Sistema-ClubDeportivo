using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public abstract class Persona
    {
        private int dni;
        private string nombre;
        private DateTime fechaNac;
        private DateTime fechaIng;
        protected List<Clase> clases;

        public Persona(int dni, string nombre, DateTime fechaNac, DateTime fechaIng)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.fechaNac = fechaNac;
            this.fechaIng = fechaIng;
        }

        public override string ToString()
        {
            return "DNI: "+dni + " Edad: " + calcularEdad() + " Nombre: " + nombre + " Fecha Ingreso: " + fechaIng.Date.ToString();
        }

        public int calcularEdad()

        {

            DateTime hoy = DateTime.Today;

            int edad = hoy.Year - fechaNac.Year;

            if (hoy.Month < fechaNac.Month)

                edad--;

            else

              if (hoy.Month == fechaNac.Month && hoy.Day < fechaNac.Day)

                edad--;

            return edad;

        }

        public int Dni
        {
            get { return dni; } set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; } set { nombre = value; }
        }

        public DateTime FechaNac
        {
            get { return fechaNac; } set { fechaNac = value; }
        }

        public void agregarClase(Clase c)
        {
            clases.Add(c);
        }

        public void quitarClase(Clase c)
        {
            clases.Remove(c);
        }

    }
}
