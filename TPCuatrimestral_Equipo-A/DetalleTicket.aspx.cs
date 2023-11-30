using Business;
using Domain;
using System;
using System.Collections.Generic;

namespace TPCuatrimestral_Equipo_A
{
    public partial class DetalleTicket : System.Web.UI.Page
    {
        private List<Usuario> usuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Error404.aspx");
            }
            Ticket ticket = new Ticket();
            if (Request.QueryString["ID"] != null && !IsPostBack)
            {
                int ticketID = Convert.ToInt32(Request.QueryString["ID"]);

                ticket = TicketBusiness.BuscarTicketPorID(ticketID);
                Session.Add("ticket", ticket);

                //Labels
                List<EstadoReclamo> estadosReclamo = EstadoReclamoBusiness.List();
                ddlEstado.DataSource = estadosReclamo;
                ddlEstado.DataTextField = "Nombre";
                ddlEstado.DataValueField = "ID";
                ddlEstado.SelectedValue = ticket.Estado.ID.ToString();
                ddlEstado.DataBind();
                lblID.Text = ticket.ID.ToString();

                lblFechaCreacion.Text = ticket.FechaCreacion.ToString();
                if (((Usuario)Session["usuario"]).Rol.ID == 1)
                {
                    usuarios.Add((Usuario)Session["usuario"]);
                    ddlUsuario.DataSource = usuarios;
                    ddlTipoTicket.DataSource = ticket.Tipo;
                    ddlPrioridad.DataSource = ticket.Prioridad;

                }
                else
                {
                    List<Prioridad> prioridades = PrioridadBusiness.List();
                    List<TipoTicket> tipos = TipoTicketBusiness.List();
                    usuarios = UsuarioBusiness.List();
                    ddlTipoTicket.DataSource = tipos;
                    ddlPrioridad.DataSource = prioridades;
                    ddlUsuario.DataSource = usuarios;

                }
                ddlTipoTicket.DataTextField = "Nombre";
                ddlTipoTicket.DataValueField = "ID";
                ddlTipoTicket.SelectedValue = ticket.Tipo.ID.ToString();
                ddlTipoTicket.DataBind();
                ddlPrioridad.DataTextField = "Nombre";
                ddlPrioridad.DataValueField = "ID";
                ddlPrioridad.SelectedValue = ticket.Prioridad.ID.ToString();
                ddlPrioridad.DataBind();
                ddlUsuario.DataTextField = "NombreCompleto";
                ddlUsuario.DataValueField = "Legajo";
                ddlUsuario.SelectedValue = ticket.LegajoUsuario.ToString();
                ddlUsuario.DataBind();

                lblClienteAfectado.Text = ticket.ClienteAfectado.DNI;
                lblDescripcionInicial.Text = ticket.DescripcionInicial;

                //Textos
                TextDescripcionInicial.Text = ticket.DescripcionInicial;
                TextClienteAfectado.Text = ticket.ClienteAfectado.DNI;
            }

        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedItem.Text.Contains("Cerrado")) {
                int a = 0;
            }
        }
    }
}
