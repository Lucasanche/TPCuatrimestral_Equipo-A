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

            if (!IsPostBack)
            {
                Cliente cliente = new Cliente();
                if (Request.QueryString["ID"] != null)
                {
                    int clienteID = Convert.ToInt32(Request.QueryString["ID"]);

                    cliente = ClientesBusiness.ClientePorID(clienteID);

                    if (!cliente.Estado)
                    {
                        btnCrearTicketSobreCliente.Visible = false;
                        btnEditarCliente.Visible = false;
                        btnEliminarCliente.Visible = false;
                    }

                    //Cargar los label de descripcion
                    lblDNI.Text = cliente.DNI;
                    txtNombre.Text = cliente.Nombre;

                    // Cargar en caso de Edicion los textbox
                    txtApellido.Text = cliente.Apellido;
                    //txtDNI.Text = cliente.DNI;
                    txtEmail.Text = cliente.Email;
                    txtTelefono.Text = cliente.Telefono1;
                }
            }

        }

        protected void btnEditarCliente_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            //Validar los datos (puedes agregar más validaciones según sea necesario)


            //Generar instancia
            ClientesBusiness negocioClientes = new ClientesBusiness();


            //Pasar los datos a la funcion de bussines
            if (ClientesBusiness.ModificarCliente(nombre, apellido, email, telefono, id) == 1)
            {
                // guardo correctamente
                txtEditado.ForeColor = System.Drawing.Color.Green;
                txtEditado.Text = "Cliente guardado exitosamente.";

            }
            else
            {
                //error al guardar el usuario
                txtEditado.ForeColor = System.Drawing.Color.Red;
                txtEditado.Text = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";

            }
        }


        protected void EliminarCliente_Click(object sender, EventArgs e)
        {
            int clienteID = Convert.ToInt32(Request.QueryString["ID"]);

            if (ClientesBusiness.BajaLogicaCliente(clienteID) == 1)
            {
                // Cliente eliminado correctamente
                txtEliminado.ForeColor = System.Drawing.Color.Green;
                txtEliminado.Text = "Cliente eliminado exitosamente.";
            }
            else
            {
                // Error al eliminar
                txtEliminado.ForeColor = System.Drawing.Color.Red;
                txtEliminado.Text = "Error al eliminar el cliente. Por favor, inténtalo nuevamente.";
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