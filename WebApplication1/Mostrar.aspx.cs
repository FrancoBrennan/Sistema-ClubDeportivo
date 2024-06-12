using CapaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = ((string)Session["Type"]);
            if (type == null)
            {
                cargarEmpty();
            }
            else
            {
                switch (type)
                {
                    case "actividad":
                        cargarActividad();
                        break;
                    case "clase":
                        cargarClase();
                        break;
                    case "profesor":
                        cargarProfesor();
                        break;
                    case "socio":
                        cargarSocio();
                        break;
                    case "pago":
                        cargarPagos();
                        break;
                }
            }
        }

        private void cargarActividad()
        {
            Page.Title = "Actividad";
            Actividad act = ((Actividad)Session["Actividad"]);
            LabelDescripcion.Text = act.Nombre;
            LabelID.Text = "Actividad ID: " + act.Id.ToString();
            Label1.Text = "Precio: " + act.Precio.ToString();
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            if (act.Clase.Count() > 0)
            {
                Label6.Text = "Clases";
                ListBox1.DataSource = act.Clase;
                ListBox1.DataBind();
            }
            else
            {
                Label6.Visible = false;
                ListBox1.Visible = false;
            }
        }

        private void cargarClase()
        {
            Title = "Clase";
            Clase clase = ((Clase)Session["Clase"]);
            LabelDescripcion.Text = "Actividad: " + clase.Act.Nombre;
            LabelID.Text = "Clase ID: " + clase.Id.ToString();
            Label1.Text = "Dia: " + clase.Dia;
            Label2.Text = "Horario: " + clase.Hora.ToString();
            Label3.Text = "Cupo maximo de socios " + clase.CupoMax.ToString();
            Label4.Visible = false;
            Label5.Visible = false;

            if (clase.Socios.Count() > 0)
            {
                Label6.Text = "Socios";
                ListBox1.DataSource = clase.Socios;
                ListBox1.DataBind();
            }
            else
            {
                Label6.Visible = false;
                ListBox1.Visible = false;
            }
        }

        private void cargarProfesor()
        {
            Title = "Profesor";
            Profesor prof = ((Profesor)Session["Profesor"]);
            LabelID.Text = "Profesor DNI: " + prof.Dni.ToString();
            LabelDescripcion.Text = prof.Nombre;
            Label1.Text = "Fecha de nacimiento: " + prof.FechaNac.ToString("dd/MM/yyyy");
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            ListBox1.Visible = false;
        }

        private void cargarPagos()
        {
            Title = "Pago";
            Pago pago = ((Pago)Session["Pago"]);
            LabelID.Text = "Pago ID: " + pago.Id.ToString();
            LabelDescripcion.Text = "Socio: " + pago.Socio.Nombre;
            Label1.Text = "Fecha Paga: " + pago.FechaPaga.ToString("dd/MM/yyyy");
            Label2.Text = "Monto: U$D" + pago.MontoTotal;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            ListBox1.Visible = false;
        }

        private void cargarSocio()
        {
            Title = "Socio";

            Socio soc = ((Socio)Session["Socio"]);

            LabelID.Text = "Socio DNI: " + soc.Dni.ToString();
            LabelDescripcion.Text = soc.Nombre;
            Label1.Text = "Fecha de nacimiento: " + soc.FechaNac.ToString("dd/MM/yyyy");
            Label2.Text = "Email: " + soc.Email;
            Label3.Text = "Direccion: " + soc.Direccion;

            if (soc.GetType().Name == "SocioClub")
            {
                SocioClub socClub = (SocioClub)soc;
                Label5.Text = "Cuota social: " + socClub.CuotaSocial;
            }
            else
            {
                Label5.Visible = false;
            }

            if (soc.Clases.Count() > 0)
            {
                Label6.Text = "Clases";
                ListBox1.DataSource = soc.Clases;
                ListBox1.DataBind();
            }
            else
            {
                Label6.Visible = false;
                ListBox1.Visible = false;
            }

        }

        private void cargarEmpty()
        {
            LabelID.Text = "No hubo seleccion.";
            LabelDescripcion.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            ListBox1.Visible = false;
        }
    }
}