using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public class Actividad
    {
        private int id;
        private string nombre;
        private float precio;
        private List<Clase> clases;
        private ActividadClaseDatos actClaseDatos;
        private ActividadDatos actDatos;

        public Actividad(int id, string nombre, float precio, List<Clase> clases)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.clases = clases;
            this.clases = new List<Clase>();
            actClaseDatos = new ActividadClaseDatos();
            actDatos = new ActividadDatos();
        }

        public Actividad()
        {

        }

        public void agregarClase(Clase c)
        {
            clases.Add(c);
        }

        public void quitarClaseBD(Clase c)
        {
            actClaseDatos.removerRelacion(c.Id,this.id);
        }

        public void modificarBD()
        {
            actDatos.modificar(this.id,this.nombre,this.precio);
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

        public void agregarClaseBD(Clase c)
        {
            actClaseDatos.agregarRelacion(this.id, c.Id);
        }
    }
}
