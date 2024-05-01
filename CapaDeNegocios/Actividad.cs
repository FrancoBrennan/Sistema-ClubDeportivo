using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public class Actividad
    {
        private int id;
        private string nombre;
        private float precio;
        private List<Clase> clases;

        public Actividad(int id, string nombre, float precio, List<Clase> clases)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.clases = clases;
            this.clases = new List<Clase>();
        }

        public Actividad()
        {

        }

        public void agregarClase(Clase c)
        {
            clases.Add(c);
        }

        public void quitarClase(Clase c)
        {
            clases.Remove(c);
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Clase> Clase
        {
            get { return clases; }
            set { clases = value; }
        }

        public void borrarClases()
        {
            this.clases.Clear();
        }

        public void eliminar()
        {
            foreach(var c  in clases)
            {
                c.removerDeProfesorYSocios();
            }
        }


        public override string ToString()
        {
            return this.id+" "+this.nombre + " U$D" + this.precio.ToString();
        }
    }
}
