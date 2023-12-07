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
        protected void btn_GuardarClick(object sender, EventArgs e)
        {
            
            string message = "Buenos dias estrellitas";
            txtAgregaCliente.Text = message;
            txtValidarNombre.Text = "funciona";
            
           
        }
        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {

            string message = "Buenos dias estrellitas";
            txtAgregaCliente.Text = message;
            txtValidarNombre.Text = "funciona";


        }
    }
    
}