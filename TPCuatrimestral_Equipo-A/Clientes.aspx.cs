using Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Guardar datos en variables
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDNI.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;


            //Validar los datos (puedes agregar más validaciones según sea necesario)


            //Generar instancia
            ClientesBusiness negocioClientes = new ClientesBusiness();


            //Pasar los datos a la funcion de bussines
            if (ClientesBusiness.GuardarUsuario(nombre, apellido, dni, email, telefono))
            {
                // guardo correctamente
                string mensaje = "Usuario guardado exitosamente.";
                txtConfirma.Text= mensaje;
            }
            else
            {
                //error al guardar el usuario
                string mensaje = "Error al guardar el usuario. Por favor, inténtalo nuevamente.";
                txtConfirma.Text = mensaje;
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