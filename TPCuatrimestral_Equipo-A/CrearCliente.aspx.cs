using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Equipo_A
{
    public partial class CrearCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            string mensaje = "";
            //Validar los datos (puedes agregar más validaciones según sea necesario)

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtValidarNombre.Text = "Campo obligatorio";
                mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                txtValidarApellido.Text = "Campo obligatorio";
                mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
            }
            if (string.IsNullOrEmpty(ExtraerNumeros(txtDNI.Text)))
            {
                txtValidarDNI.Text = "Campo obligatorio";
                mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtValidarEmail.Text = "Campo obligatorio";
                mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtValidarTelefono.Text = "Campo obligatorio";
                mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
            }
            if (CalendarioFechaNacimiento.SelectedDate >= DateTime.Now)
            {
                txtValidarFechaNacimiento.Text = "La fecha ingresada debe ser menor a la del dia actual";
                mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
            }
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = ExtraerNumeros(txtDNI.Text);
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            DateTime fechaNacimiento = CalendarioFechaNacimiento.SelectedDate;

            //Generar instancia
            ClientesBusiness negocioClientes = new ClientesBusiness();


            //Pasar los datos a la funcion de bussines
            if (ClientesBusiness.GuardarCliente(nombre, apellido, dni, email, telefono, fechaNacimiento) == 1)
            {
                // guardo correctamente
                mensaje = "Cliente guardado exitosamente.";

            }
            else
            {
                //error al guardar el usuario
                mensaje = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";

            }
            txtAgregaCliente.Text = mensaje;
            
        }
        static string ExtraerNumeros(string input)
        {
            Regex regex = new Regex(@"\D");
            string result = regex.Replace(input, "");
            return result;
        }
    }
}