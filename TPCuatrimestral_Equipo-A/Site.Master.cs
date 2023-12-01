using Domain;
using System;

namespace TPCuatrimestral_Equipo_A
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    linkUsuario.Text = "Usuario: " + ((Usuario)Session["usuario"]).Nombre;
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}