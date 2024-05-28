using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public class Profesor : Persona
    {
        private int legajo;
        private ProfesorClaseDatos profClasDat;
        private ProfesorDatos profDatos;

        public Profesor(int dni, string nombre, DateTime fechaNac, int legajo) : base(dni,nombre,fechaNac){
            this.legajo = legajo;
            profClasDat = new ProfesorClaseDatos();
            profDatos = new ProfesorDatos();
        }

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public override void agregarClase(Clase c)
        {
            clases.Add(c);
        }

        public override void quitarClase(Clase c)
        {
            this.quitarClaseBD(c);
            clases.Remove(c);
        }

        public void quitarClaseBD(Clase c)
        {
            profClasDat.removerRelacion(c.Id, this.Dni);
        }

        public void removerDeClases()
        {
            foreach(Clase clase in this.clases) {
                clase.removerProfesor();
            }
        }

        public void agregarClaseBD(Clase c)
        {
            profClasDat.agregarRelacion(this.Dni,c.Id);
        }

        public void modificarBD()
        {
            profDatos.modificar(this.Dni, this.Nombre, this.FechaNac, this.legajo);
        }

    }
}
