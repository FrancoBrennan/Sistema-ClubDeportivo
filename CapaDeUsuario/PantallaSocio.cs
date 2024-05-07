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
    public partial class PantallaSocio : Form
    {
        private Socio soc;

        //Este contructor se usa para modificar
        public PantallaSocio(Socio soc)
        {
            InitializeComponent();
            this.soc = soc;
            this.textBox1.Text = soc.Dni.ToString();
            this.textBox2.Text = soc.Nombre.ToString();
            this.textBox3.Text = soc.Email.ToString();
            this.textBox5.Text = soc.Direccion.ToString();
            this.dateTimePicker1.Text = soc.FechaNac.ToString();

            if (soc.usaCuota())
            {
                this.textBox4.Text = ((SocioClub)soc).CuotaSocial.ToString();
            }

            label4.Visible = soc.usaCuota();
            textBox4.Visible = soc.usaCuota();
            checkBox1.Visible = false;
        }

        //Este para crear
        public PantallaSocio()
        {
            InitializeComponent();
            textBox4.Visible = false;
            label4.Visible = false;
        }

        public Socio Soc{
            get { return this.soc; }
            set { this.soc = value; }
        }


        private void Aceptar_Click(object sender, EventArgs e)
        {

            try
            {

                if (textBox3.Text.Length == 0 || textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                {
                    throw new Exception("Hay campos vacíos !");
                }


                float cuotaSocial;


                if (!float.TryParse(textBox4.Text, out cuotaSocial) && checkBox1.Checked) {
                    throw new Exception("Formato incorrecto !");
                }


                /*
                if (soc == null)
                {
                    
                }
                else
                {
                    soc.Id = id;
                    soc.Nombre = nombre;
                    soc.Precio = precio;
                }
                */

                int dni = int.Parse(textBox1.Text);
                string nombre = textBox2.Text;
                DateTime fechaNac = DateTime.Parse(dateTimePicker1.Text);
                string email = textBox3.Text;
                string direccion = textBox5.Text;

                if(soc == null)
                {
                    if (checkBox1.Checked)
                    {
                        this.soc = new SocioClub(dni, nombre, fechaNac, email, direccion, cuotaSocial);
                    }
                    else
                    {
                        this.soc = new SocioActividad(dni, nombre, fechaNac, email, direccion);
                    }
                }
                else
                {
                    

                    soc.Dni = dni;
                    soc.Nombre = nombre;
                    soc.FechaNac = fechaNac;
                    soc.Direccion = direccion;
                    soc.Email = email;

                    if(soc.usaCuota())
                    {
                        ((SocioClub)soc).CuotaSocial = cuotaSocial;
                    }
                 
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

        /*
        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
           label4.Visible = checkBox1.Checked;
           textBox4.Visible = checkBox1.Checked;
        }
        */
    }
}
