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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.club = new Club();
                Session["Club"] = club;

                ListBoxActividades.DataSource = club.Actividades;
                ListBoxActividades.DataBind();
                ListBoxClases.DataSource = club.Clases;
                ListBoxClases.DataBind();
                ListBoxProfesores.DataSource = club.Profesores;
                ListBoxProfesores.DataBind();
                ListBoxSocios.DataSource = club.Socios;
                ListBoxSocios.DataBind();
            }
        }

        //Actividades
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxClases.ClearSelection();
            ListBoxProfesores.ClearSelection();
            ListBoxSocios.ClearSelection();
        }

        //Clases
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxProfesores.ClearSelection();
            ListBoxSocios.ClearSelection();
        }

        //Profesores
        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxClases.ClearSelection();
            ListBoxSocios.ClearSelection();
        }

        //Socios
        protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxActividades.ClearSelection();
            ListBoxClases.ClearSelection();
            ListBoxProfesores.ClearSelection();
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

            string url = "https://localhost:44322/Mostrar";
            string script = string.Format("window.open('{0}');", url);

            Page.ClientScript.RegisterStartupScript(this.GetType(),
                "newPage" + UniqueID, script, true);
        }
    }

}