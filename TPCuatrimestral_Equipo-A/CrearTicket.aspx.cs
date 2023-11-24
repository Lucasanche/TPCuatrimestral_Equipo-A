using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Domain;
using Business;

namespace TPCuatrimestral_Equipo_A
{
    public partial class CrearTicket : System.Web.UI.Page
    {
        private Ticket ticket = new Ticket();
        private List<Usuario> usuarios;
        private List<Prioridad> prioridades;
        private List<TipoTicket> tipos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ticket = new Ticket();
                usuarios = UsuarioBusiness.List();
                prioridades = PrioridadBusiness.List();
                tipos = TipoTicketBusiness.List();

                ddlPrioridad.DataSource = prioridades;
                ddlPrioridad.DataTextField = "Nombre";
                ddlPrioridad.DataValueField = "ID";
                ddlPrioridad.DataBind();

                ddlUsuario.DataSource = usuarios;
                ddlUsuario.DataTextField = "NombreCompleto";
                ddlUsuario.DataValueField = "Legajo";
                ddlUsuario.DataBind();

                ddlTipoTicket.DataSource = tipos;
                ddlTipoTicket.DataTextField = "Nombre";
                ddlTipoTicket.DataValueField= "ID";
                ddlTipoTicket.DataBind();

            }
        }

        protected void buttonBuscarPorID_Click(object sender, EventArgs e)
        {
            string IDformateado = ExtraerNumeros(tbBuscarPorDNI.Text);
            int ID;
            try
            {
                ID = int.Parse(IDformateado);
            }
            catch { ID = 0; }
            if (ID != 0)
            {
                ticket.ClienteAfectado = ClientesBusiness.ClientePorDNI(ID);
                if (ticket.ClienteAfectado.ID != 0)
                {
                    string textCliente = $"ID: {ticket.ClienteAfectado.ID.ToString()}   DNI: {ticket.ClienteAfectado.DNI}   Nombre: {ticket.ClienteAfectado.Nombre} {ticket.ClienteAfectado.Apellido}";
                    textResultadoCliente.Text = textCliente;
                }
                else
                {
                    textResultadoCliente.Text = "Cliente inexistente";
                }
            }
        }

        protected void buttonBuscarPorDNI_Click(object sender, EventArgs e)
        {
            string DNIformateado = ExtraerNumeros(tbBuscarPorDNI.Text);
            int DNI;
            try
            {
                DNI = int.Parse(DNIformateado);
            }
            catch { DNI = 0; }
            if (DNI != 0)
            {
                ticket.ClienteAfectado = ClientesBusiness.ClientePorDNI(DNI);
                if (ticket.ClienteAfectado.ID != 0)
                {
                    string textCliente = $"ID: {ticket.ClienteAfectado.ID.ToString()}   DNI: {ticket.ClienteAfectado.DNI}   Nombre: {ticket.ClienteAfectado.Nombre} {ticket.ClienteAfectado.Apellido}";
                    textResultadoCliente.Text = textCliente;
                }
                else
                {
                    textResultadoCliente.Text = "Cliente inexistente";
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
            bool clienteValido = false;
            bool descripcionValida = false;
            if (textResultadoCliente.Text == "")
            {
                labelValidarCliente.Visible = true;
            }
            else
            {
                labelValidarCliente.Visible = false;
                clienteValido = true;
            }
            if (textDescripcion.Text == "")
            {
                labelValidarDescripcion.Visible = true;
            }
            else
            {
                labelValidarDescripcion.Visible = false;
                descripcionValida = true;
            }
            if (descripcionValida && clienteValido) {
                ticket.DescripcionInicial = textDescripcion.Text;
                ticket.FechaCreacion = DateTime.Now;
                ticket.IdEstadoReclamo = 1;
                ticket.Estado = new EstadoReclamo();
                //ticket.Prioridad = prioridades.FirstOrDefault(p => )
            }
        }
    }
}