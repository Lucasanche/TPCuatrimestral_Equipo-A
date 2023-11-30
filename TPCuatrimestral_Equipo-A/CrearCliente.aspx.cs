﻿using Business;
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
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = ExtraerNumeros(txtDNI.Text);
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            string mensaje = "";
            DateTime fechaNacimiento = CalendarioFechaNacimiento.SelectedDate;

            //Validar los datos (puedes agregar más validaciones según sea necesario)


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