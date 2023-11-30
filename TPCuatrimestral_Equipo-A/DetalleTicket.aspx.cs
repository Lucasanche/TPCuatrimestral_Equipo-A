using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
                bool cerrado = false;
                Session.Add("cerrado", cerrado);
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
            }
            else
            {
                if (ddlEstado.SelectedItem.Text.Contains("Cerrado"))
                {
                    bool cerrado = true;
                    Session.Add("cerrado", cerrado);
                    textCierre.Visible = true;
                    labelDescripcionCierre.Visible = true;
                }
                else
                {
                    bool cerrado = false;
                    Session.Add("cerrado", cerrado);
                    textCierre.Visible = false;
                    labelDescripcionCierre.Visible= false;
                }
            }

        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedItem.Text.Contains("Cerrado")) {
                bool cerrado = true;
                Session.Add("cerrado", cerrado); 
            }
            else
            {
                bool cerrado = false;
                Session.Add("cerrado", cerrado);
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            Ticket ticket = (Ticket)Session["ticket"];
            bool modificado = false;
            if(ddlTipoTicket.SelectedItem.Text != ticket.Tipo.Nombre)
            {
                TipoTicket tipo = TipoTicketBusiness.TipoTicketPorID(Byte.Parse(ddlTipoTicket.SelectedValue));
                ticket.Tipo = tipo;
                modificado = true;
            }
            if(ddlUsuario.SelectedValue.ToString() != ticket.LegajoUsuario)
            {
                ticket.LegajoUsuario = ddlUsuario.SelectedValue.ToString();
                modificado = true;
            }
            if(ddlPrioridad.SelectedItem.Text != ticket.Prioridad.Nombre) {
                Prioridad prioridad = PrioridadBusiness.PrioridadPorID(Byte.Parse(ddlPrioridad.SelectedValue));
                ticket.Prioridad = prioridad;
                modificado = true;
            }
            if ((bool)Session["cerrado"])
            {
                if(textCierre.Text == "")
                {
                    labelVerificacionCierre.Visible = true;
                    modificado = false;
                }
                else
                {
                    labelVerificacionCierre.Visible = false;
                    modificado = true;
                    ticket.FechaCierre = DateTime.Now;
                }
            }
            if(ticket.Estado.Nombre != ddlEstado.SelectedItem.Text)
            {
                EstadoReclamo estado = EstadoReclamoBusiness.EstadoReclamoPorID(ticket.Estado.ID);
                ticket.Estado = estado;
            }
            try
            {
                if(modificado)
                {
                    if (TicketBusiness.ModificarTicket(ticket) == 1) {
                        labelVerificacionCierre.Text = "Cambios guardados correctamente";
                        labelVerificacionCierre.Visible = true;
                    }
                    else
                    {
                        labelVerificacionCierre.Text = "Error al guardar los cambios";
                        labelVerificacionCierre.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
            
        }
    }
}
