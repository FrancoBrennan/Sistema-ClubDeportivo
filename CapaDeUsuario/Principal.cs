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

            //this.club = Club.Cargar(); // <- Codigo para archivos
            this.club = new Club();

            //Carga todos los listbox con los datos cargados

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

        private void Principal_Load(object sender, EventArgs e)
        {
            string actividades = Microsoft.VisualBasic.Interaction.InputBox("Cantidad máxima de actividades incluidas del socio","Actividades incluidas del Socio Club", SocioClub.GetActividadesMax().ToString());

            SocioClub.SetActividadesMax(int.Parse(actividades));

            string descuento = Microsoft.VisualBasic.Interaction.InputBox("Ingrese procentaje de descuento", "Descuento del Socio Club por actividades extras", SocioClub.GetPorcDescuento().ToString());

            SocioClub.SetPorcDescuento(int.Parse(descuento));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AgregarAct_Click(object sender, EventArgs e)
        {
            //Al clickear en el botón "Agregar" se crea un objeto form

            PantallaActividad agregarActividad = new PantallaActividad();

            //Se muestra el formulario

            agregarActividad.ShowDialog();
            
            Actividad actividad = agregarActividad.Act;

            if(actividad != null)
            {
                if (!this.club.verificarActividad(actividad))
                {
                    this.club.agregarActividad(actividad);

                    //Con estas dos líneas recarga el listbox de actividades
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

                //Refresca la listbox de actividades por si hubo algún cambio
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

        private void AgregarSoc_Click(object sender, EventArgs e)
        {
            PantallaSocio pantallaSocio = new PantallaSocio();

            pantallaSocio.ShowDialog();

            Socio soc = pantallaSocio.Soc;

            if(soc != null)
            {
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

            if(prof != null)
            {
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
                    prof.removerDeClases();

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

        private void AgregarClase_Click(object sender, EventArgs e)
        {
            PantallaClase pantallaClase = new PantallaClase(this.club.Actividades, this.club.Profesores);

            pantallaClase.ShowDialog();

            Clase clase = pantallaClase.Clase;

            if(clase != null)
            {
                if (!club.verificarClase(clase))
                {
                    //BD: Lo agrega a la Base de Datos
                    club.agregarClase(clase);

                    listBoxClases.DataSource = null;
                    listBoxClases.DataSource = club.Clases;

                    listBoxClases.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Ya existe una Clase con ese Id ;)");
                }
            }

        }

        private void ModificarClase_Click(object sender, EventArgs e)
        {
            Clase clase = (Clase)this.listBoxClases.SelectedItem;

            if (clase != null)
            {
                PantallaClase pantallaClase = new PantallaClase(clase, this.club.Actividades, this.club.Profesores);

                pantallaClase.ShowDialog();

                this.listBoxClases.DataSource = null;
                this.listBoxClases.DataSource = club.Clases;

                listBoxClases.ClearSelected();
            }
            else
            {
                MessageBox.Show("No hay clase seleccionada :(");
            }
        }

        private void BorrarClase_Click(object sender, EventArgs e)
        {
            Clase clase = (Clase)this.listBoxClases.SelectedItem;

            if (clase != null)
            {
                DialogResult dr = MessageBox.Show("¿Estas seguro que desea eliminar la clase?", "Eliminar", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    clase.removerDeProfesorYSocios();

                    club.removerClase(clase);

                    this.listBoxClases.DataSource = null;
                    this.listBoxClases.DataSource = club.Clases;

                    listBoxClases.ClearSelected();
                }
            }
            else
            {
                MessageBox.Show("No hay clase seleccionada :(");
            }
        }

        // Agregar socio a clase
        private void button1_Click(object sender, EventArgs e)
        {
            Clase clase = (Clase)this.listBoxClases.SelectedItem;

            if (clase != null)
            {
                if (clase.verificarCupo())
                {
                    PantallaSocioClase pantallaClase = new PantallaSocioClase(this.club.Socios,clase);

                    //Ejecuta el formulario
                    pantallaClase.ShowDialog();

                    //Una vez que termina asigna el socio creado en el formulario a una variable local.
                    Socio socio = pantallaClase.Socio;

                    if (socio != null)
                    {
                        //Acá ocurre un error ya que se puede agregar el mismo socio multiples veces a una misma clase. Se corrigió en
                        //PantallaSocioClase para que no muestre en el combobox a aquellos socios que ya estén en dicha clase.

                        clase.agregarSocio(socio);
                        socio.agregarClase(clase);

                        listBoxClases.DataSource = null;
                        listBoxClases.DataSource = club.Clases;

                        listBoxClases.ClearSelected();
                    }
                }
                else
                {
                    MessageBox.Show("La clase llegó al cupo máximo ;)");
                }
            }
            else
            {
                MessageBox.Show("No hay clase seleccionada :(");
            }
        }

        // Sacar socio de clase
        private void button2_Click(object sender, EventArgs e)
        {
            Clase clase = (Clase)this.listBoxClases.SelectedItem;

            if (clase != null)
            {
                PantallaSocioClase pantallaClase = new PantallaSocioClase(clase);

                pantallaClase.ShowDialog();

                Socio socio = pantallaClase.Socio;

                if (socio != null)
                {
                    clase.quitarSocio(socio);
                    socio.quitarClase(clase);

                    listBoxClases.DataSource = null;
                    listBoxClases.DataSource = club.Clases;

                    listBoxClases.ClearSelected();
                }

            }
            else
            {
                MessageBox.Show("No hay clase seleccionada :(");
            }
        }

        private void AgregarPago_Click(object sender, EventArgs e)
        {
            PantallaPago pantallaPago = new PantallaPago(this.club.Socios);

            pantallaPago.ShowDialog();

            Socio socio = pantallaPago.Socio;

            if (socio != null)
            {
                club.generarPago(socio);

                listBoxPagos.DataSource = null;
                listBoxPagos.DataSource = club.Pagos;

                listBoxPagos.ClearSelected();
            }
        }

        private void BorrarPago_Click(object sender, EventArgs e)
        {
            Pago pago = (Pago)this.listBoxPagos.SelectedItem;

            if (pago != null)
            {

                DialogResult dr = MessageBox.Show("¿Estas seguro que desea eliminar al Socio?", "Eliminar", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    club.removerPago(pago);

                    listBoxPagos.DataSource = null;
                    listBoxPagos.DataSource = club.Pagos;

                    listBoxPagos.ClearSelected();
                }
                    
            }
            else
            {
                MessageBox.Show("No hay pago seleccionado :(");
            }

        }

        
        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
            DialogResult dr = MessageBox.Show("¿Quiere realizar un guardado?", "Guardar datos", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                this.club.guardar();
            }
            */
        }
        
    }
}
