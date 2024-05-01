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

            listBoxAct.DataSource = club.Actividades;
            listBoxAct.ClearSelected();

            listBoxSoc.DataSource = club.Socios;
            listBoxSoc.ClearSelected();

            listBoxProf.DataSource = club.Profesores;
            listBoxProf.ClearSelected();

            listBoxClases.DataSource = club.Clases;
            listBoxClases.ClearSelected();

            listBoxPagos.DataSource = club.Pagos;
            listBoxPagos.ClearSelected();
        }



        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            string actividades = Microsoft.VisualBasic.Interaction.InputBox("Cantidad máxima de actividades del socio","Actividades del Socio");

            SocioClub.SetActividadesMax(int.Parse(actividades));

            string descuento = Microsoft.VisualBasic.Interaction.InputBox("Ingrese procentaje de descuento", "Descuento del Socio Club por actividades extras");

            SocioClub.SetPorcDescuento(int.Parse(descuento));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AgregarAct_Click(object sender, EventArgs e)
        {
            PantallaActividad agregarActividad = new PantallaActividad();

            agregarActividad.ShowDialog();
            
            Actividad actividad = agregarActividad.Act;

            if(actividad != null)
            {
                if (!this.club.verificarActividad(actividad))
                {
                    this.club.agregarActividad(actividad);
                    this.listBoxAct.DataSource = null;
                    this.listBoxAct.DataSource = club.Actividades;

                    listBoxAct.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Esa actividad ya fue ingresada :)");
                }
            }
            
        }

        private void ModificarAct_Click(object sender, EventArgs e)
        {
            Actividad act2 = (Actividad)this.listBoxAct.SelectedItem;

            if(act2 != null)
            {
                PantallaActividad agregarActividad = new PantallaActividad(act2);

                agregarActividad.ShowDialog();

                this.listBoxAct.DataSource = null;
                this.listBoxAct.DataSource = club.Actividades;

                listBoxAct.ClearSelected();
            }
            else
            {
                MessageBox.Show("No hay actividad seleccionada :(");
            }


        }

        private void BorrarAct_Click(object sender, EventArgs e)
        {
            Actividad act2 = (Actividad)this.listBoxAct.SelectedItem;

            if(act2 != null)
            {
                DialogResult dr = MessageBox.Show("¿Estas seguro que desea eliminar la actividad?", "Eliminar", MessageBoxButtons.YesNo);

                if(dr == DialogResult.Yes)
                {
                    act2.eliminar();

                    club.removerActividad(act2);

                    this.listBoxAct.DataSource = null;
                    this.listBoxAct.DataSource = club.Actividades;

                    listBoxAct.ClearSelected();
                }
            }
            else
            {
                MessageBox.Show("No hay actividad seleccionada :(");
            }


        }

        /*
        private void AgregarPago_Click(object sender, EventArgs e)
        {
            AgregarPago agregarPago = new AgregarPago();
            agregarPago.ShowDialog();
        }
        */

        private void ModificarPago_Click(object sender, EventArgs e)
        {

        }

        private void BorrarPago_Click(object sender, EventArgs e)
        {

        }

        private void AgregarSoc_Click(object sender, EventArgs e)
        {
            PantallaSocio pantallaSocio = new PantallaSocio();

            pantallaSocio.ShowDialog();

            Socio soc = pantallaSocio.Soc;

            if (!club.verificarSocio(soc))
            {
                club.agregarSocio(soc);

                listBoxSoc.DataSource = null;
                listBoxSoc.DataSource = club.Socios;

                listBoxSoc.ClearSelected();
            }
            else
            {
                MessageBox.Show("Ya existe un Socio con ese DNI ;)");
            }
        }

        private void ModificarSoc_Click(object sender, EventArgs e)
        {
            Socio soc2 = (Socio)this.listBoxSoc.SelectedItem;

            if (soc2 != null)
            {
                PantallaSocio modificarSocio = new PantallaSocio(soc2);

                modificarSocio.ShowDialog();

                this.listBoxSoc.DataSource = null;
                this.listBoxSoc.DataSource = club.Socios;

                listBoxSoc.ClearSelected();
            }
            else
            {
                MessageBox.Show("No hay socio seleccionado :(");
            }
        }

        private void BorrarSoc_Click(object sender, EventArgs e)
        {
            Socio soc3 = (Socio)this.listBoxSoc.SelectedItem;

            if (soc3 != null)
            {
                DialogResult dr = MessageBox.Show("¿Estas seguro que desea eliminar al Socio?", "Eliminar", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    soc3.remover();

                    club.removerSocio(soc3);

                    this.listBoxSoc.DataSource = null;
                    this.listBoxSoc.DataSource = club.Socios;

                    listBoxSoc.ClearSelected();
                }
            }
            else
            {
                MessageBox.Show("No hay Socio seleccionado :(");
            }
        }

        private void AgregarProf_Click(object sender, EventArgs e)
        {
            PantallaProfesor pantallaProf = new PantallaProfesor();

            pantallaProf.ShowDialog();

            Profesor prof = pantallaProf.Profesor;

            if (!club.verificarProfesor(prof))
            {
                club.agregarProfesor(prof);

                listBoxProf.DataSource = null;
                listBoxProf.DataSource = club.Profesores;

                listBoxProf.ClearSelected();
            }
            else
            {
                MessageBox.Show("Ya existe un Profesor con ese DNI o Legajo ;)");
            }
        }


        private void ModificarProf_Click_1(object sender, EventArgs e)
        {
            Profesor prof = (Profesor)this.listBoxProf.SelectedItem;

            if (prof != null)
            {
                PantallaProfesor modificarProf = new PantallaProfesor(prof);

                modificarProf.ShowDialog();

                this.listBoxProf.DataSource = null;
                this.listBoxProf.DataSource = club.Profesores;

                listBoxProf.ClearSelected();
            }
            else
            {
                MessageBox.Show("No hay profesor seleccionado :(");
            }
        }

        private void BorrarProf_Click(object sender, EventArgs e)
        {
            Profesor prof = (Profesor)this.listBoxProf.SelectedItem;

            if (prof != null)
            {
                DialogResult dr = MessageBox.Show("¿Estas seguro que desea eliminar al Profesor?", "Eliminar", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    prof.remover();

                    club.removerProfesor(prof);

                    this.listBoxProf.DataSource = null;
                    this.listBoxProf.DataSource = club.Profesores;

                    listBoxProf.ClearSelected();
                }
            }
            else
            {
                MessageBox.Show("No hay Profesor seleccionado :(");
            }
        }
    }
}
