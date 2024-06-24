using CapaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        private Club club;
        private Socio usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.club = new Club();
                Session["Club"] = club;

                this.usuario = (Socio) Session["Usuario"];

                cargarActividades();
                cargarClases(this.club, this.usuario);
                cargarProfesores();
                cargarSocios();
                cargarPagos();
            }
        }

        protected void cargarActividades()
        {
            if (usuario != null)
            {
                ListBoxActividades.DataSource =usuario.Clases.Select(c => c.Act).ToList();

            } else
            {
                ListBoxActividades.DataSource = club.Actividades;
            }

            ListBoxActividades.DataBind();
        }

        protected void cargarClases(Club c, Socio s)
        {
            if (s != null)
            {
                ListBoxClases.DataSource = c.Clases.Where(cla => !s.Clases.Contains(cla)).ToList();

                ListBoxClasesIncriptas.DataSource = s.Clases;
                ListBoxClasesIncriptas.DataBind();
            } else
            {
                ListBoxClases.DataSource = c.Clases;
                ListBoxClasesIncriptas.Visible = false;
            }
            
            ListBoxClases.DataBind();
        }

        protected void cargarProfesores()
        {
            if (usuario != null)
            {
                ListBoxProfesores.Visible = false;
                LabelProfesores.Visible = false;

            } else
            {
                ListBoxProfesores.DataSource = club.Profesores;
                ListBoxProfesores.DataBind();
            }
        }

        protected void cargarSocios()
        {
            if (usuario != null)
            {
                ListBoxSocios.Visible = false;
                LabelSocios.Visible = false;
            } else
            {
                ListBoxSocios.DataSource = club.Socios;
                ListBoxSocios.DataBind();
            }
        }

        protected void cargarPagos()
        {
            if (usuario != null)
            {
                ListBoxPagos.Visible = false;
                LabelPagos.Visible = false;

            } else
            {
                ListBoxPagos.DataSource = club.Pagos;
                ListBoxPagos.DataBind();
            }
        }

        //Actividades
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxClases.ClearSelection();
            ListBoxProfesores.ClearSelection();
            ListBoxSocios.ClearSelection();
            ListBoxPagos.ClearSelection();
            ListBoxClasesIncriptas.ClearSelection();
        }

        //Clases
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxProfesores.ClearSelection();
            ListBoxSocios.ClearSelection();
            ListBoxPagos.ClearSelection();
            ListBoxClasesIncriptas.ClearSelection();
        }

        //Clases inscriptas
        protected void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxProfesores.ClearSelection();
            ListBoxSocios.ClearSelection();
            ListBoxPagos.ClearSelection();
            ListBoxClases.ClearSelection();
        }

        //Profesores
        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxClases.ClearSelection();
            ListBoxSocios.ClearSelection();
            ListBoxPagos.ClearSelection();
            ListBoxClasesIncriptas.ClearSelection();
        }

        //Socios
        protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxClases.ClearSelection();
            ListBoxProfesores.ClearSelection();
            ListBoxPagos.ClearSelection();
            ListBoxClasesIncriptas.ClearSelection();
        }

        //Pagos
        protected void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxClases.ClearSelection();
            ListBoxSocios.ClearSelection();
            ListBoxProfesores.ClearSelection();
            ListBoxClasesIncriptas.ClearSelection();
        }

        // Inscribirse a clase
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ListBoxClases.SelectedIndex != -1)
            {
                Socio s = (Socio)Session["Usuario"];
                Clase clase = ((Club)Session["Club"]).Clases.Where(c => !s.Clases.Contains(c)).ToList()[ListBoxClases.SelectedIndex];

                clase.agregarSocio(s);
                s.agregarClase(clase);

                Session["Usuario"] = s;

                cargarClases((Club)Session["Club"], s);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ListBoxActividades.SelectedIndex != -1)
            {
                Actividad act = ((Club)Session["Club"]).Actividades[ListBoxActividades.SelectedIndex];
                Session["Actividad"] = act;
                Session["Type"] = "actividad";
            }
            else if (ListBoxClases.SelectedIndex != -1)
            {
                Clase clase = ((Club)Session["Club"]).Clases[ListBoxClases.SelectedIndex];
                Session["Clase"] = clase;
                Session["Type"] = "clase";
            }
            else if (ListBoxProfesores.SelectedIndex != -1)
            {
                Profesor prof = ((Club)Session["Club"]).Profesores[ListBoxProfesores.SelectedIndex];
                Session["Profesor"] = prof;
                Session["Type"] = "profesor";
            }
            else if (ListBoxSocios.SelectedIndex != -1)
            {
                Socio soc = ((Club)Session["Club"]).Socios[ListBoxSocios.SelectedIndex];
                Session["Socio"] = soc;
                Session["Type"] = "socio";
            }
            else if (ListBoxPagos.SelectedIndex != -1)
            {
                Pago pago = ((Club)Session["Club"]).Pagos[ListBoxPagos.SelectedIndex];
                Session["Pago"] = pago;
                Session["Type"] = "pago";
            }
            else if (ListBoxClasesIncriptas.SelectedIndex != -1)
            {
                Clase clase = ((Club)Session["Club"]).Clases[ListBoxClasesIncriptas.SelectedIndex];
                Session["Clase"] = clase;
                Session["Type"] = "clase";
            }


            string url = "https://localhost:44366/Mostrar";
            string script = string.Format("window.open('{0}');", url);

            Page.ClientScript.RegisterStartupScript(this.GetType(),
                "newPage" + UniqueID, script, true);
        }
    }

}