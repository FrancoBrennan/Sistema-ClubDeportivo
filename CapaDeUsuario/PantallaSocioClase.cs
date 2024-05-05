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
    public partial class PantallaSocioClase : Form
    {
        private Socio socio;
        private List<Socio> socios;

        public PantallaSocioClase(List<Socio> socios)
        {
            InitializeComponent();
            this.socios = socios;

            llenarSocios();
        }

        public Socio Socio
        {
            get { return this.socio; }
            set { this.socio = value; }
        }

        private void llenarSocios()
        {
            foreach (Socio socio in socios)
            {
                this.comboBox1.Items.Add(socio);
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.Text.Length == 0)
                {
                    throw new Exception("Pro favor, seleccione un socio!");
                }

                this.socio = (Socio) this.comboBox1.SelectedItem;

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
