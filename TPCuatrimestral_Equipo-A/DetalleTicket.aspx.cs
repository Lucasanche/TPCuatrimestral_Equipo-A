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
            if (Request.QueryString["ID"] != null)
            {
                bool cerrado = false;
                bool supervisor = ((Usuario)Session["usuario"]).Rol.ID == 2 || ((Usuario)Session["usuario"]).Rol.ID == 3;
                Session.Add("cerrado", cerrado);
                int ticketID = Convert.ToInt32(Request.QueryString["ID"]);
                ticket = TicketBusiness.BuscarTicketPorID(ticketID);
                Session.Add("ticket", ticket);
                Session.Add("estadoTicket", ticket.Estado.ID);

                //Labels
                switch (ticket.Estado.ID)
                {
                    case 1:
                        btnCambioEstado1.Text = "Aprobar";
                        if (!supervisor)
                        {
                            btnCambioEstado1.Enabled = false;
                        }
                        Session.Add("estadoTicket", 1);
                        btnCambioEstado2.Visible = false;
                        break;
                    case 2:
                        btnCambioEstado1.Text = "Procesar";
                        Session.Add("estadoTicket", 1);
                        break;
                    case 3:
                        btnCambioEstado1.Text = "Cerrar - Resuelto";
                        btnCambioEstado2.Text = "Cerrar - No Resuelto";
                        btnCambioEstado2.Visible = true;
                        Session.Add("estadoTicket", 2);
                        break;
                    case 4:
                        btnCambioEstado1.Visible = false;
                        btnCambioEstado2.Visible = false;
                        break;
                    case 5:
                        btnCambioEstado1.Visible = false;
                        btnCambioEstado2.Visible = false;
                        break;
                }
                lblID.Text = ticket.ID.ToString();
                lblFechaCreacion.Text = ticket.FechaCreacion.ToString();
                lblEstadoTicket.Text = ticket.Estado.Nombre;
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
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket((Ticket)Session["ticket"]);
            Ticket ticketNuevo = new Ticket((Ticket)Session["ticket"]);
            bool modificado = false;
            if (ddlTipoTicket.SelectedItem.Text != ticket.Tipo.Nombre)
            {
                TipoTicket tipo = TipoTicketBusiness.TipoTicketPorID(Byte.Parse(ddlTipoTicket.SelectedValue));
                ticketNuevo.Tipo = tipo;
                modificado = true;
            }
            if (ddlUsuario.SelectedValue.ToString() != ticket.LegajoUsuario)
            {
                ticketNuevo.LegajoUsuario = ddlUsuario.SelectedValue.ToString();
                modificado = true;
            }
            if (ddlPrioridad.SelectedItem.Text != ticket.Prioridad.Nombre)
            {
                Prioridad prioridad = PrioridadBusiness.PrioridadPorID(Byte.Parse(ddlPrioridad.SelectedValue));
                ticketNuevo.Prioridad = prioridad;
                modificado = true;
            }
            if ((bool)Session["cerrado"])
            {
                if (textCierre.Text == "")
                {
                    labelVerificacionCierre.Visible = true;
                    modificado = false;
                }
                else
                {
                    labelVerificacionCierre.Visible = false;
                    modificado = true;
                    ticketNuevo.FechaCierre = DateTime.Now;
                }
            }
            if (ticket.Estado.ID != (Byte)Session["estadoTicket"] && Session["estadoTicket"] != null)
            {
                EstadoReclamo estado = EstadoReclamoBusiness.EstadoReclamoPorID((Byte)Session["estadoTicket"]);
                ticketNuevo.Estado = estado;
                modificado = true;
            }
            try
            {
                if (modificado)
                {
                    if (TicketBusiness.ModificarTicket(ticket, ticketNuevo) == 1)
                    {
                        Session["ticket"] = ticketNuevo;
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
        protected void btnCambioEstado1_Click(object sender, EventArgs e)
        {
            Byte estado = 0;
            switch (((Ticket)Session["ticket"]).Estado.ID)
            {
                case 1:
                    estado = 2;
                    Session["estadoTicket"] = estado;
                    break;
                case 2:
                    estado = 3;
                    Session["estadoTicket"] = estado;
                    break;
                case 3:
                    estado = 4;
                    Session["estadoTicket"] = estado;
                    break;
            }
            btnGuardarCambios_Click(sender, e);
            Page_Load(sender, e);
        }

        protected void btnCambioEstado2_Click(object sender, EventArgs e)
        {
            Byte estado = 5;
            Session["estadoTicket"] = estado;
            btnGuardarCambios_Click(sender, e);
            Page_Load(sender, e);
        }
    }
}
