using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Equipo_A
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Error404.aspx");
            }
            Cliente cliente = new Cliente();
            if (Request.QueryString["ID"] != null)
            {
                int clienteID = Convert.ToInt32(Request.QueryString["ID"]);

                cliente = ClientesBusiness.ClientePorID(clienteID);

                //Cargar los label de descripcion
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
            }

        }

        protected void ConfirmaEdicion_Click(object sender, EventArgs e)
        {
            //cargar variables 
            int clienteID = Convert.ToInt32(Request.QueryString["ID"]);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDNI.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            // instancia de Cliente y asigna
            Cliente cliente = new Cliente
            {
                ID = clienteID,
                Nombre = nombre,
                Apellido = apellido,
                DNI = dni,
                Email = email,
                Telefono1 = telefono
            };

            // Llamar a la función para modificar el cliente
            if (ClientesBusiness.ModificarCliente(cliente))
            {
                // Cliente editado correctamente
                string mensaje = "Cliente editado exitosamente.";
                txtEditado.Text = mensaje;
            }
            else
            {
                // Error al editar el cliente
                string mensaje = "Error al editar el cliente. Por favor, inténtalo nuevamente.";
                txtEditado.Text = mensaje;
            }
        }

        protected void EliminarCliente_Click(object sender, EventArgs e)
        {
            int clienteID = Convert.ToInt32(Request.QueryString["ID"]);

            if (ClientesBusiness.BajaLogicaCliente(clienteID))
            {
                // Cliente eliminado correctamente
                string mensaje = "Cliente eliminado exitosamente.";
                txtEliminado.Text = mensaje;
            }
            else
            {
                // Error al eliminar
                string mensaje = "Error al eliminar el cliente. Por favor, inténtalo nuevamente.";
                txtEliminado.Text = mensaje;
            }

        }

        protected void CrearTicket_Command(object sender, CommandEventArgs e)
        {
            // Obtener el valor del DNI del Label
            string dni = lblDNI.Text;

            // Imprimir para depuración
            Debug.WriteLine($"Valor de dni: {dni}");

            // Redirigir a la página CrearTicket.aspx con el parámetro DNI
            Response.Redirect($"CrearTicket.aspx?dni={dni}");
        }
    }
}