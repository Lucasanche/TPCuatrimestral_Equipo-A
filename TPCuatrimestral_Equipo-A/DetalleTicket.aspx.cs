using Business;
using Domain;
using System;
using System.Collections.Generic;

namespace TPCuatrimestral_Equipo_A
{
    public partial class DetalleTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Error404.aspx");
            }
            Ticket ticket = new Ticket();
            if (Request.QueryString["ID"] != null)
            {
                int ticketID = Convert.ToInt32(Request.QueryString["ID"]);

                ticket = TicketBusiness.BuscarTicketPorID(ticketID);

                //Labels
                lblID.Text = ticket.ID.ToString();
                lblPrioridad.Text = ticket.Prioridad.Nombre;
                lblTipo.Text = ticket.Tipo.Nombre;
                lblEstado.Text = ticket.Estado.Nombre;
                lblFechaCreacion.Text = ticket.FechaCreacion.ToString();
                lblLegajoUsuario.Text = ticket.LegajoUsuario.ToString();
                lblClienteAfectado.Text = ticket.ClienteAfectado.DNI;
                lblDescripcionCierre.Text = ticket.DescripcionCierre;
                lblDescripcionInicial.Text = ticket.DescripcionInicial;

                //Textos
                TextDescripcionInicial.Text = ticket.DescripcionInicial;
                TextClienteAfectado.Text = ticket.ClienteAfectado.DNI;

                //Cargo los tipos de ticket y prioridades para el modal EDITAR
                List<TipoTicket> tiposTicket = TipoTicketBusiness.List();
                List<string> tiposTicketNombre = new List<string>();
                foreach (TipoTicket tipo in tiposTicket)
                {
                    tiposTicketNombre.Add(tipo.Nombre);
                }
                TipoDDL.DataSource = tiposTicketNombre;
                TipoDDL.DataBind();

                List<Prioridad> prioridades = PrioridadBusiness.List();
                List<string> prioridadesNombre = new List<string>();
                foreach (Prioridad prioridad in prioridades)
                {
                    prioridadesNombre.Add(prioridad.Nombre);
                }
                PrioridadDDL.DataSource = prioridadesNombre;
                PrioridadDDL.DataBind();

            }
            
        }
    }
}