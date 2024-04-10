using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDeNegocios;

namespace CapaDeUsuario
{
    public partial class Principal : Form
    {
        private Club club;
        public Principal()
        {
            InitializeComponent();
            this.club = new Club();
        }


        private void clasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clase clase = new Clase();
            clase.ShowDialog();
        }


        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actividad act = new Actividad();
            act.ShowDialog();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profesor pro = new Profesor();
            pro.ShowDialog();
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Socio socio = new Socio();
            socio.ShowDialog();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pago pago = new Pago();
            pago.ShowDialog();
        }

    }
}
