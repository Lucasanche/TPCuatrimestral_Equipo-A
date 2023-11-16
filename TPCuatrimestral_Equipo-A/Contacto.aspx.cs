using Business;
using Domain;
using System;

namespace TPCuatrimestral_Equipo_A
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            if (Request.QueryString["ID"] != null)
            {
                int clienteID = Convert.ToInt32(Request.QueryString["ID"]);

                cliente = ClientesBusiness.ClientePorID(clienteID);

                // Asignar el valor de clienteID al Text del Label
                txtIDCliente.Text = cliente.Nombre;

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
    }
}