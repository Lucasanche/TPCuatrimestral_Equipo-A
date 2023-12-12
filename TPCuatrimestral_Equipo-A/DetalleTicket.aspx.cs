using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Net;
using System.Net.Mail;

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
                        btnCambioEstado2.Visible = false;
                        Session.Add("estadoTicket", 1);
                        break;
                    case 3:
                        btnCambioEstado1.Text = "Cerrar - Resuelto";
                        btnCambioEstado2.Text = "Cerrar - No Resuelto";
                        btnCambioEstado2.Visible = true;
                        textEnvioMail.Visible = true;
                        labelMensajeParaCliente.Visible = true;
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
                labelComentarios.Text = ticket.DescripcionInicial;
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
            if (ticket.Estado.ID != (Byte)Session["estadoTicket"] && Session["estadoTicket"] != null)
            {
                EstadoReclamo estado = EstadoReclamoBusiness.EstadoReclamoPorID((Byte)Session["estadoTicket"]);
                ticketNuevo.Estado = estado;
                modificado = true;
            }
            if (!String.IsNullOrEmpty(textComentario.Text))
            {
                modificado = true;
                string fechaHoraActual = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                ticketNuevo.DescripcionInicial += $"<br>- {fechaHoraActual}: {textComentario.Text}";
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
                    if (String.IsNullOrEmpty(textEnvioMail.Text))
                    {
                        labelVerificacionEmail.Visible = true;
                        break;
                    }
                    if (EnviarEmail(textEnvioMail.Text,((Ticket)Session["ticket"]).ClienteAfectado.Email)) {
                        labelVerificacionEmail.Text = "Email enviado correctamente";
                        labelVerificacionEmail.Visible = true;
                    }
                    else {
                        labelVerificacionEmail.Text = "Email enviado correctamente";
                        labelVerificacionEmail.Visible= true;
                    }
                    
                    estado = 4;
                    Session["estadoTicket"] = estado;
                    break;
            }
            btnGuardarCambios_Click(sender, e);
            Page_Load(sender, e);
        }

        protected void btnCambioEstado2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textEnvioMail.Text))
            {
                labelVerificacionEmail.Visible = true;
                return;
            }
            if (EnviarEmail(textEnvioMail.Text, ((Ticket)Session["ticket"]).ClienteAfectado.Email))
            {
                labelVerificacionEmail.Text = "Email enviado correctamente";
                labelVerificacionEmail.Visible = true;
            }
            else
            {
                labelVerificacionEmail.Text = "Email enviado correctamente";
                labelVerificacionEmail.Visible = true;
            }
            Byte estado = 5;
            Session["estadoTicket"] = estado;
            btnGuardarCambios_Click(sender, e);
            Page_Load(sender, e);
        }

        protected void textComentario_TextChanged(object sender, EventArgs e)
        {
            if (textComentario.Text != "")
            {
                btnCambioEstado1.Enabled = true;
                btnCambioEstado2.Enabled = true;
            }
            else
            {
                btnCambioEstado1.Enabled = false;
                btnCambioEstado2.Enabled = false;
            }
        }
        protected bool EnviarEmail(string emailBody, string destinatario)
        {
            if (string.IsNullOrEmpty(emailBody))
            {
                return false;
            }
            var fromAddress = new MailAddress("tpprog3grupoa@gmail.com", "GrupoA");
            string toAddress = destinatario;
            string fromPassword = "qyjwaqzikjnaqxqf";
            string subject = "Test";
            string body = emailBody;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            try
            
            {
                using (var message = new MailMessage(toAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
