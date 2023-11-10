using Business;
using Domain;
using System;

namespace TPCuatrimestral_Equipo_A
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = TextEmailUsuario.Text;
            string password = TextPassword.Text;
            Usuario usuario = UsuarioBusiness.UsuarioPorEmail(email, password);
            Error.Visible = true;
            if (usuario != null)
            {
                Error.Text = "Usuario existente";
            }
            else
            {
                Error.Text = "El usuario o la contraseña son incorrectas";
            }
        }
    }
}