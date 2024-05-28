using CapaDeNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuario
{
    public partial class PantallaProfesor : Form
    {
        private Profesor prof;

        //Este contructor se usa para modificar
        public PantallaProfesor(Profesor prof)
        {
            InitializeComponent();
            this.prof = prof;
            this.textBox1.Text = prof.Dni.ToString();
            this.textBox2.Text = prof.Nombre.ToString();
            this.maskedTextBox1.Text = prof.Legajo.ToString();
            this.dateTimePicker1.Text = prof.FechaNac.ToString();


            this.textBox1.ReadOnly = true;
            this.maskedTextBox1.ReadOnly = true;
        }

        //Este para crear
        public PantallaProfesor()
        {
            InitializeComponent();
        }

        public Profesor Profesor{
            get { return this.prof; }
            set { this.prof = value; }
        }


        private void Aceptar_Click(object sender, EventArgs e)
        {

            try
            {

                if (maskedTextBox1.Text.Length == 0 || textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                {
                    throw new Exception("Hay campos vacíos !");
                }


                int dni = int.Parse(textBox1.Text);
                string nombre = textBox2.Text;
                DateTime fechaNac = DateTime.Parse(dateTimePicker1.Text);
                int legajo = int.Parse(maskedTextBox1.Text);
                

                if(prof == null)
                {
                    this.prof = new Profesor(dni, nombre, fechaNac, legajo);
                }
                else
                {
                    prof.Dni = dni;
                    prof.Nombre = nombre;
                    prof.FechaNac = fechaNac;
                    prof.Legajo = legajo;

                    prof.modificarBD();
                }
                this.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
