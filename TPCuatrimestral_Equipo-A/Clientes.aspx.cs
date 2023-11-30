using Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Domain;

namespace TPCuatrimestral_Equipo_A
{
    public partial class Clientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Error404.aspx");
            }
  

            ClientesGV.DataSource = ClientesBusiness.List();
            ClientesGV.DataBind();
            // Registrar para validación de eventos
            foreach (GridViewRow row in ClientesGV.Rows)
            {
                Button btnVerDetalles = (Button)row.FindControl("VerDetalles");
                if (btnVerDetalles != null)
                {
                    ClientScript.RegisterForEventValidation(btnVerDetalles.UniqueID, "VerDetalles");
                }
            }
        }

        static string ExtraerNumeros(string input)
        {
            Regex regex = new Regex(@"\D");
            string result = regex.Replace(input, "");
            return result;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Guardar datos en variables
            string nombre = txtNombre1.Text;
            string apellido = txtApellido1.Text;
            string dni = ExtraerNumeros(txtDNI1.Text);
            string email = txtEmail1.Text;
            string telefono = txtTelefono1.Text;


            //Validar los datos (puedes agregar más validaciones según sea necesario)


            //Generar instancia
            ClientesBusiness negocioClientes = new ClientesBusiness();


            //Pasar los datos a la funcion de bussines
            if (ClientesBusiness.GuardarCliente(nombre, apellido, dni, email, telefono))
            {
                // guardo correctamente
                string mensaje = "Cliente guardado exitosamente.";
                txtAgregaCliente.Text= mensaje;
            }
            else
            {
                //error al guardar el usuario
                string mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
                txtAgregaCliente.Text = mensaje;
            }
        }
        protected void ClientesGV_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalles")
            {
                // Aquí obtienes el ID del cliente desde el CommandArgument
                int clienteID = Convert.ToInt32(e.CommandArgument);

                // Redirige a la página de detalles pasando el ID como parámetro
                Response.Redirect($"Contacto.aspx?ID={clienteID}");
            }
        }


    }
}