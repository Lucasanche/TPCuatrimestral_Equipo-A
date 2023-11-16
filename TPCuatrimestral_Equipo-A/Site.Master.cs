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
    }
}