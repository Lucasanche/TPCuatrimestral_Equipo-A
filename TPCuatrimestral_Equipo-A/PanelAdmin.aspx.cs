using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace TPCuatrimestral_Equipo_A
{
    public partial class PanelAdmin : System.Web.UI.Page
    {
        private List<Usuario> usuarios;
        private List<TipoTicket> tipos;
        protected void Page_Load(object sender, EventArgs e)
        {
            tipos = TipoTicketBusiness.List();

            ddlEditarTipoTicket.DataSource = tipos;
            ddlEditarTipoTicket.DataTextField = "Nombre";
            ddlEditarTipoTicket.DataBind();


            ddlEliminarTipoTicket.DataSource = tipos;
            ddlEliminarTipoTicket.DataTextField = "Nombre";
            ddlEliminarTipoTicket.DataBind();
        }
        protected void GuardarUsuario_Click(object sender, EventArgs e)
        { 

        }
        protected void GuardarTipoTicket_Click(object sender, EventArgs e)
        {

        }
        protected void EditarUsuario_Click(object sender, EventArgs e)
        {

        }
        protected void EditarTipoTicket_Click(object sender, EventArgs e)
        {

        }
        protected void EliminarUsuario_Click(object sender, EventArgs e)
        {

        }
        protected void EliminarTipoTicket_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarUsuarioEditar_Click(object sender, EventArgs e)
        {

        }
        protected void BuscarUsuarioEliminar_Click(object sender, EventArgs e)
        {

        }

    }
    
}