using CapaDeNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuario
{
    public partial class PantallaActividad : Form
    {
        private Actividad act;
        public PantallaActividad(Actividad act)
        {
            InitializeComponent();
            this.act = act;
            this.textBox1.Text = act.Id.ToString();
            this.textBox2.Text = act.Nombre.ToString();
            this.textBox3.Text = act.Precio.ToString();

            this.textBox1.ReadOnly = true;
        }

        public PantallaActividad()
        {
            InitializeComponent();
        }

        public Actividad Act{
            get { return this.act; }
            set { this.act = value; }
        }


        private void Aceptar_Click(object sender, EventArgs e)
        {

            try
            {

                if (textBox3.Text.Length == 0 || textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                {
                    throw new Exception("Hay campos vacíos !");
                }

                int id = int.Parse(textBox1.Text);
                string nombre = textBox2.Text;

                float precio;

                if (!float.TryParse(textBox3.Text,out precio)) {
                    throw new Exception("Formato incorrecto !");
                }

                
                if (act == null)
                {
                    act = new Actividad(id, nombre, precio, new List<Clase>());
                }
                else
                {
                    act.Id = id;
                    act.Nombre = nombre;
                    act.Precio = precio;
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
