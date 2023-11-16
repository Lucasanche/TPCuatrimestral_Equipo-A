using Business;
using System;


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
            /*
            ClientesGV.DataSource = ClientesBusiness.List();
            ClientesGV.DataBind();
            */
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
                // El usuario se guardó correctamente, puedes realizar alguna acción adicional si es necesario.
                Response.Write("Usuario guardado exitosamente.");
            }
            else
            {
                // Ocurrió un error al guardar el usuario, muestra un mensaje de error.
                Response.Write("Error al guardar el usuario. Por favor, inténtalo nuevamente.");
            }
        }
    }
}