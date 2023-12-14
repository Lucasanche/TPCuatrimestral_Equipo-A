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
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtValidarNombre.ForeColor = System.Drawing.Color.Red;
                txtValidarNombre.Text = "Campo obligatorio";
            }
            else
            {
                txtValidarNombre.Visible = false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                txtValidarApellido.ForeColor = System.Drawing.Color.Red;
                txtValidarApellido.Text = "Campo obligatorio";
            }
            else
            {
                txtValidarApellido.Visible = false;
            }
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                txtValidarDNI.Text = "Campo obligatorio";
                txtValidarDNI.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (string.IsNullOrEmpty(ExtraerNumeros(txtDNI.Text))){
                    txtValidarDNI.Text = "Sólo se permiten números";
                    txtValidarDNI.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtValidarDNI.Visible = false;
                }
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtValidarEmail.ForeColor = System.Drawing.Color.Red;
                txtValidarEmail.Text = "Campo obligatorio";
            }
            else
            {
                txtValidarEmail.Visible = false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                txtValidarTelefono.ForeColor = System.Drawing.Color.Red;
                txtValidarTelefono.Text = "Campo obligatorio";
            }
            else
            {
                txtValidarTelefono.Visible = false;
            }
            if (CalendarioFechaNacimiento.SelectedDate >= DateTime.Now)
            {
                txtValidarFechaNacimiento.ForeColor = System.Drawing.Color.Red;
                txtValidarFechaNacimiento.Text = "La fecha ingresada debe ser menor a la del dia actual";
            }
            else
            {
                txtValidarFechaNacimiento.Visible = false;
            }

            if ( txtNombre.Text != "" && txtApellido.Text != "" && txtDNI.Text != "" && txtEmail.Text != "" && txtTelefono.Text != "" && CalendarioFechaNacimiento.SelectedDate <= DateTime.Now)
            {

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string dni = ExtraerNumeros(txtDNI.Text);
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                DateTime fechaNacimiento = CalendarioFechaNacimiento.SelectedDate;
                btnGuardar.Visible = false;
                btnRecargar.Visible = true;

                //Generar instancia
                ClientesBusiness negocioClientes = new ClientesBusiness();


                //Pasar los datos a la funcion de bussines
                if (ClientesBusiness.GuardarCliente(nombre, apellido, dni, email, telefono, fechaNacimiento) == 1)
                {
                    // guardo correctamente
                    txtAgregaCliente.ForeColor = System.Drawing.Color.Green;
                    txtAgregaCliente.Text = "Cliente guardado exitosamente.";
                    btnGuardar.Visible = false;
                    btnRecargar.Visible = true;
                }
                else
                {
                    //error al guardar el usuario
                    txtAgregaCliente.ForeColor = System.Drawing.Color.Red;
                    txtAgregaCliente.Text = "Error al guardar el cliente. Por favor, inténtalo nuevamente.";
                }
            }
        }
        static string ExtraerNumeros(string input)
        {
            Regex regex = new Regex(@"\D");
            string result = regex.Replace(input, "");
            return result;
        }

        protected void btnRecargar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCliente.aspx");
        }
    }
}