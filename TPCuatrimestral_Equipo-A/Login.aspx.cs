using Business;
using Domain;
using System;

namespace TPCuatrimestral_Equipo_A
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = "lucas@sanchez.com";
            string password = "password";
            Usuario usuario = UsuarioBusiness.UsuarioPorEmail(email, password);
            Session.Add("usuario", usuario);
            Session.Add("rol", usuario.Rol.ID);
            Response.Redirect("Tickets.aspx", false);
            textError.Visible = true;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = TextEmailUsuario.Text;
            string password = TextPassword.Text;
            Usuario usuario = UsuarioBusiness.UsuarioPorEmail(email, password);
            textError.Visible = true;
            try
            {
                if (usuario != null)
                {
                    Session.Add("usuario", usuario);
                    Session.Add("rol", usuario.Rol.ID);
                    Response.Redirect("Tickets.aspx", false);
                    textError.Text = "Usuario existente";
                }
                else
                {
                    textError.Text = "El usuario o la contraseña son incorrectas";
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}