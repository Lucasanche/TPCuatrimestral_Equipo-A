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
        private Ticket ticket;
        private List<Usuario> usuarios;
        private List<Prioridad> prioridades;
        private List<TipoTicket> tipos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["dni"] != null)
            {
                string dni = Request.QueryString["dni"];
                tbBuscarPorDNI.Text = dni;
            }
            if (Session["usuario"] == null)
            {
                Response.Redirect("Error404.aspx");
            }
            if (!IsPostBack)
            {
                usuarios = new List<Usuario>();
                prioridades = PrioridadBusiness.List();
                tipos = TipoTicketBusiness.List();

                ddlPrioridad.DataSource = prioridades;
                ddlPrioridad.DataTextField = "Nombre";
                ddlPrioridad.DataValueField = "ID";
                ddlPrioridad.DataBind();


                if (((Usuario)Session["usuario"]).Rol.ID == 3)
                {
                    usuarios.Add((Usuario)Session["usuario"]);
                    ddlUsuario.DataSource = usuarios;
                }
                else
                {
                    usuarios = UsuarioBusiness.List();
                    ddlUsuario.DataSource = usuarios;
                }
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
                ticket = new Ticket();
                ticket.ClienteAfectado = ClientesBusiness.ClientePorDNI(ID);
                Session.Add("ticket", ticket);
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
                ticket = new Ticket();
                ticket.ClienteAfectado = ClientesBusiness.ClientePorDNI(DNI);
                Session.Add("ticket", ticket);
                if (ticket.ClienteAfectado.ID != 0)
                {
                    string textCliente = $"ID: {ticket.ClienteAfectado.ID.ToString()}   DNI: {ticket.ClienteAfectado.DNI}   Nombre: {ticket.ClienteAfectado.Nombre} {ticket.ClienteAfectado.Apellido}";
                    textResultadoCliente.Text = textCliente;
                }
                else
                {
                    textResultadoCliente.ForeColor = System.Drawing.Color.Red;
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
            labelValidarCliente.ForeColor = System.Drawing.Color.Red;
            labelValidarDescripcion.ForeColor = System.Drawing.Color.Red;
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
                labelValidarCliente.Visible = true;
                labelValidarCliente.Text = ddlPrioridad.SelectedValue;
                ticket = (Ticket)Session["ticket"];
                ticket.DescripcionInicial = textDescripcion.Text;
                ticket.FechaCreacion = DateTime.Now;
                ticket.IdEstadoReclamo = 1;
                ticket.Estado = new EstadoReclamo();
                ticket.Prioridad = PrioridadBusiness.PrioridadPorID(Byte.Parse(ddlPrioridad.SelectedValue));
                ticket.Tipo = TipoTicketBusiness.TipoTicketPorID(Byte.Parse(ddlTipoTicket.SelectedValue));
                ticket.LegajoUsuario = ddlUsuario.SelectedValue;
                try
                {
                    if (TicketBusiness.Agregar(ticket) == 1)
                    {
                        btnGuardar.Visible = false;
                        btnVolver.Visible = true;
                        txtAgregaCliente.Visible = true;
                        txtAgregaCliente.ForeColor = System.Drawing.Color.Green;
                        txtAgregaCliente.Text = "Ticket añadido correctamente";
                    }
                    else
                    {
                        txtAgregaCliente.Visible = true;
                        txtAgregaCliente.ForeColor = System.Drawing.Color.Red;
                        txtAgregaCliente.Text = "Hubo un error al cargar el ticket, por favor contacte con un administrador";
                    }

                }
                catch(Exception ex)
                {
                    
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tickets.aspx");
        }
    }
}