using Business;
using Domain;
using System;

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

                lblID.Text = ticket.ID.ToString();
                //Cargar los label de descripcion
                /*
                lblDNI.Text = cliente.DNI;
                lblNombre.Text = cliente.Nombre;    
                lblApellido.Text = cliente.Apellido;
                lblEmail.Text = cliente.Email;
                lblTelefono.Text = cliente.Telefono1;

                // Cargar en caso de Edicion los textbox
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDNI.Text = cliente.DNI;
                txtEmail.Text = cliente.Email;
                txtTelefono.Text = cliente.Telefono1;
                */

            }
        }
    }
}