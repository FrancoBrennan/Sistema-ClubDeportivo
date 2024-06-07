using CapaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private Club club;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.club = new Club();
            Session["Club"] = this.club;

            listBoxActividades.DataSource = club.Actividades;
            listBoxActividades.DataBind();


        }
    }
}