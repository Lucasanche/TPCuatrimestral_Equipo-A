using Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Domain;
using System.Numerics;

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

        protected void btnBusquedaClientesDNI_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusquedaClientesDNI.Text))
            {
                txtValidarBusquedaClienteDNI.ForeColor = System.Drawing.Color.Red;
                txtValidarBusquedaClienteDNI.Text = "Complete con numeros, no puede quedar vacio";
            }
            if(ExtraerNumeros(txtBusquedaClientesDNI.Text) != "")
            {
                string dniBuscado;
                dniBuscado = ExtraerNumeros(txtBusquedaClientesDNI.Text);
                ClientesGV.BorderColor = System.Drawing.Color.Blue;
                ClientesGV.DataSource = ClientesBusiness.ClientePorDNI(dniBuscado);
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
          
        }
    }
}