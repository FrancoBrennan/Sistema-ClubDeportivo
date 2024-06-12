using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using CapaDeNegocios;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication1.Models;

namespace WebApplication1.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializar visibilidad del campo CuotaSocial
                divCuotaSocial.Visible = EsSocio.Checked;
            }
        }

        protected void EsSocio_CheckedChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar el campo CuotaSocial basado en el estado del checkbox
            divCuotaSocial.Visible = EsSocio.Checked;
        }


        protected void CreateUser_Click(object sender, EventArgs e)
        {
            Club club = (Club)Session["Club"];

            try
            {
                int dni = int.Parse(Password.Text);
                int dniConfirm = int.Parse(ConfirmPassword.Text);
                DateTime fecha = DateTime.Parse(FechaNacimiento.Text);
                
                

                if(dni != dniConfirm)
                {
                    throw new Exception();
                }

                if(EsSocio.Checked)
                {
                    float monto = float.Parse(CuotaSocial.Text);

                    SocioClub socClub = new SocioClub(dni,Nombre.Text, fecha, Email.Text, Direccion.Text, monto);

                    club.agregarSocio(socClub);
                }
                else
                {
                    SocioActividad socAct = new SocioActividad(dni, Nombre.Text, fecha, Email.Text, Direccion.Text);

                    club.agregarSocio(socAct);
                }

                ErrorMessage.Text = "";


                string url = "https://localhost:44366";
                string script = string.Format("window.open('{0}');", url);

                Page.ClientScript.RegisterStartupScript(this.GetType(),
                "newPage" + UniqueID, script, true);
            }
            catch {
                ErrorMessage.Text = "Parámetros invalidos";
            }

            


            /*
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }

            */
        }
    }
}