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
        private Clase clase;

        public PantallaSocioClase(List<Socio> socios, Clase clase)
        {
            InitializeComponent();
            this.socios = socios;

            this.clase = clase;

            
            llenarSocios();
            
        }

        
        public PantallaSocioClase(Clase clase)
        {
            InitializeComponent();
            this.clase = clase;

            llenarSocios();
        }
        
        

        public Socio Socio
        {
            get { return this.socio; }
            set { this.socio = value; }
        }

        
        private void llenarSocios()
        {
            if (socios != null) //En el caso de querer agregar un socio a una clase
            {
                foreach (Socio soc in socios)
                {

                    // Verificar si el socio ya está asociado a la clase
                    bool socioEnClase = clase.verificarSocio(soc);

                    // Si el socio no está asociado a la clase, agregarlo al ComboBox
                    if (!socioEnClase)
                    {
                        this.comboBox1.Items.Add(soc);
                    }

                }
            }
            else //En el caso de querer eliminar un socio de una clase
            {
                foreach (Socio soc in clase.Socios)
                {
                    this.comboBox1.Items.Add(soc);
                }
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
