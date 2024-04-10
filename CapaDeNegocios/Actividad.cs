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
        }
    }
}
