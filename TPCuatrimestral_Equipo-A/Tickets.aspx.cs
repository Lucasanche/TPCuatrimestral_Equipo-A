using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TPCuatrimestral_Equipo_A
{
    public partial class Tickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Error404.aspx");
            }
            if (!IsPostBack)
            {
                Session.Add("OrderID", true);
                Session.Add("OrderPrioridad", true);
                Session.Add("OrderTipo", true);
                Session.Add("OrderUsuario", true);
                Session.Add("OrderCliente", true);
                Session.Add("OrderFechaCreacion", true);
                Session.Add("OrderEstado", true);
                List<Ticket> list = TicketBusiness.List();
                Session.Add("ticketList", list);
                list = list.OrderByDescending(ticket => ticket.ID).ToList();
                LoadGridView(list);
            }
        }

        protected void LoadGridView(List<Ticket> list)
        {
            TicketsGV.DataSource = null;
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario.Rol.ID == 1)
            {
                TicketsGV.Columns.Cast<DataControlField>().First(column => column.HeaderText == "Usuario Responsable").Visible = false;
                List<Ticket> listAux = new List<Ticket>();
                foreach (Ticket ticket in list)
                {
                    if (ticket.LegajoUsuario == usuario.Legajo && !ticket.Estado.Nombre.Contains("Cerrado"))
                    {
                        listAux.Add(ticket);
                    }
                }

                TicketsGV.DataSource = listAux;
                int fechaCierreIndex = TicketsGV.Columns.IndexOf(TicketsGV.Columns.Cast<DataControlField>().FirstOrDefault(c => c.HeaderText == "Fecha de cierre"));
                TicketsGV.Columns[fechaCierreIndex].Visible = false;
            }
            else
            {
                TicketsGV.DataSource = list;
            }
            TicketsGV.DataBind();
            // Registrar para validación de eventos
            foreach (GridViewRow row in TicketsGV.Rows)
            {
                System.Web.UI.WebControls.Button btnVerDetalleTicket = (System.Web.UI.WebControls.Button)row.FindControl("VerDetalleTicket");
                if (btnVerDetalleTicket != null)
                {
                    ClientScript.RegisterForEventValidation(btnVerDetalleTicket.UniqueID, "VerDetalleTicket");
                }
            }
        }
        protected void TicketsGV_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalles")
            {
                // Aquí obtienes el ID del cliente desde el CommandArgument
                int ticketID = Convert.ToInt32(e.CommandArgument);

                // Redirige a la página de detalles pasando el ID como parámetro
                Response.Redirect($"DetalleTicket.aspx?ID={ticketID}");
            }
        }

        protected void buttonAgregar_Click(object sender, EventArgs e)
        {
            
        }

        protected void TicketsGV_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<Ticket> list = (List<Ticket>)Session["ticketList"];
            bool order;
            switch (e.SortExpression)
            {
                case "ID":
                    order = (bool)Session["OrderID"];
                    if (order)
                    {
                        list = list.OrderBy(ticket => ticket.ID).ToList();
                        Session["OrderID"] = false;
                    }
                    else
                    {
                        list = list.OrderByDescending(ticket => ticket.ID).ToList();
                        Session["OrderID"] = true;
                    }
                    break;
                case "TIPO":
                    order = (bool)Session["OrderTipo"];
                    if (order)
                    {
                        list = list.OrderBy(ticket => ticket.Tipo.Nombre).ToList();
                        Session["OrderTipo"] = false;
                    }
                    else
                    {
                        list = list.OrderByDescending(ticket => ticket.Tipo.Nombre).ToList();
                        Session["OrderTipo"] = true;
                    }
                    break;
                case "PRIORIDAD":
                    order = (bool)Session["OrderPrioridad"];
                    if (order)
                    {
                        list = list.OrderBy(ticket => ticket.Prioridad.Nombre).ToList();
                        Session["OrderPrioridad"] = false;
                    }
                    else
                    {
                        list = list.OrderByDescending(ticket => ticket.Prioridad.Nombre).ToList();
                        Session["OrderPrioridad"] = true;
                    }
                    break;
                case "USUARIO":
                    order = (bool)Session["OrderUsuario"];
                    if (order)
                    {
                        list = list.OrderBy(ticket => ticket.NombreUsuario).ToList();
                        Session["OrderUsuario"] = false;
                    }
                    else
                    {
                        list = list.OrderByDescending(ticket => ticket.NombreUsuario).ToList();
                        Session["OrderUsuario"] = true;
                    }
                    break;
                case "CLIENTE":
                    order = (bool)Session["OrderCliente"];
                    if (order)
                    {
                        list = list.OrderBy(ticket => ticket.ClienteAfectado.NombreCompleto).ToList();
                        Session["OrderCliente"] = false;
                    }
                    else
                    {
                        list = list.OrderByDescending(ticket => ticket.ClienteAfectado.NombreCompleto).ToList();
                        Session["OrderCliente"] = true;
                    }
                    break;
                case "FECHA_CREACION":
                    order = (bool)Session["OrderFechaCreacion"];
                    if (order)
                    {
                        list = list.OrderBy(ticket => ticket.FechaCreacion).ToList();
                        Session["OrderFechaCreacion"] = false;
                    }
                    else
                    {
                        list = list.OrderByDescending(ticket => ticket.FechaCreacion).ToList();
                        Session["OrderFechaCreacion"] = true;
                    }
                    break;
                case "ESTADO":
                    order = (bool)Session["OrderEstado"];
                    if (order)
                    {
                        list = list.OrderBy(ticket => ticket.Estado.Nombre).ToList();
                        Session["OrderEstado"] = false;
                    }
                    else
                    {
                        list = list.OrderByDescending(ticket => ticket.Estado.Nombre).ToList();
                        Session["OrderEstado"] = true;
                    }
                    break;
                default:
                    break;
            }
            LoadGridView(list);

            //< asp:BoundField DataField = "Tipo.Nombre" HeaderText = "Tipo" SortExpression = "TIPO" />
            //< asp:BoundField DataField = "Prioridad.Nombre" HeaderText = "Prioridad" SortExpression = "PRIORIDAD" />
            //< asp:BoundField DataField = "NombreUsuario" HeaderText = "Usuario Responsable" SortExpression = "USUARIO" />
            //< asp:BoundField DataField = "ClienteAfectado.DNI" HeaderText = "DNI Cliente Afectado" SortExpression = "CLIENTE" />
            //< asp:BoundField DataField = "FechaCreacion" HeaderText = "Fecha De Creacion" SortExpression = "FECHA_CREACION" />
            //< asp:BoundField DataField = "Estado.Nombre" HeaderText = "Estado" SortExpression = "ESTADO" />
            //< asp:BoundField DataField = "FechaCierre" HeaderText = "Fecha de cierre" />
        }
        /*
protected void CargarTabla()
{
_ticketList = TicketBusiness.List();
TicketsGV.AutoGenerateColumns = true;
BindingSource bs = new BindingSource();
bs.DataSource = TicketBusiness.List();
TicketsGV.AutoGenerateColumns = false;
TicketsGV.DataSource = bs;
BoundField colID = new BoundField();
colID.DataField = "ID";
colID.HeaderText = "ID";
TicketsGV.Columns.Add(colID);
BoundField colTipoTicket = new BoundField();
colTipoTicket.DataField = "Tipo.Nombre";
colTipoTicket.HeaderText = "Tipo";
BoundField colPrioridad = new BoundField();
colPrioridad.DataField = "Prioridad.Nombre";
colPrioridad.HeaderText = "Prioridad";
TicketsGV.Columns.Add(colPrioridad);
BoundField colDescripcionInicial = new BoundField();
colDescripcionInicial.DataField = "DescripcionInicial";
colDescripcionInicial.HeaderText = "Descripción inicial";
TicketsGV.Columns.Add(colDescripcionInicial);
BoundField colDescripcionCierre = new BoundField();
colDescripcionCierre.DataField = "DescripcionCierre";
colDescripcionCierre.HeaderText = "Descripción al cierre";
TicketsGV.Columns.Add(colDescripcionCierre);
BoundField colLegajoUsuario = new BoundField();
colLegajoUsuario.DataField = "LegajoUsuario";
colLegajoUsuario.HeaderText = "Legajo usuario asignado";
TicketsGV.Columns.Add(colLegajoUsuario);
BoundField colNombreUsuario = new BoundField();
colNombreUsuario.DataField = "NombreUsuario";
colNombreUsuario.HeaderText = "Usuario asignado";
TicketsGV.Columns.Add(colNombreUsuario);
BoundField colClienteAfectado = new BoundField();
colClienteAfectado.DataField = "ClienteAfectado.ID";
colClienteAfectado.HeaderText = "ID del cliente afectado";
TicketsGV.Columns.Add(colClienteAfectado);
BoundField colFechaCreacion = new BoundField();
colFechaCreacion.DataField = "FechaCreacion";
colFechaCreacion.HeaderText = "Fecha de creación";
TicketsGV.Columns.Add(colFechaCreacion);
BoundField colFechaCierre = new BoundField();
colFechaCierre.DataField = "FechaCierre";
colFechaCierre.HeaderText = "Fecha de cierre";
TicketsGV.Columns.Add(colFechaCierre);
BoundField colEstado = new BoundField();
colEstado.DataField = "Estado.Nombre";
colEstado.HeaderText = "Estado";
TicketsGV.Columns.Add(colEstado);
TicketsGV.DataBind();

List<TipoTicket> tiposTicket = TipoTicketBusiness.List();
List<string> tiposTicketNombre = new List<string>();
foreach (TipoTicket tipo in tiposTicket)
{
tiposTicketNombre.Add(tipo.Nombre);
}
TipoDDL.DataSource = tiposTicketNombre;
TipoDDL.DataBind();

List<Prioridad> prioridades = PrioridadBusiness.List();
List<string> prioridadesNombre = new List<string>();
foreach (Prioridad prioridad in prioridades)
{
prioridadesNombre.Add(prioridad.Nombre);
}
PrioridadDDL.DataSource = prioridadesNombre;
PrioridadDDL.DataBind();

List<string> parametrosClientes = new List<string>
{
"DNI",
"EMAIL"
};
ClienteAfectadoDDL.DataSource = parametrosClientes;
ClienteAfectadoDDL.DataBind();
}
protected void RecargarTabla()
{
TicketsGV.DataSource = null;
CargarTabla();
}
*/
    }
}



//if (!IsPostBack)
//{
//    if (TextClienteAfectado.Text != "" && TextClienteAfectado.Text != null)
//    {

//    }
//    else
//    {
//        Response.Write("buscate una vida");
//    }
//}

//BoundField: Represents a simple text column that displays data from a data  source.

//ButtonField: Represents a column with a button control.

//CheckBoxField: Represents a column with a checkbox control.

//CommandField: Represents a column with command buttons (such as Edit, Delete,     etc.).

//HyperLinkField: Represents a column with hyperlinks.

//ImageField: Represents a column with image controls.

//TemplateField: Represents a column with custom templates, allowing you to define the column's appearance and behavior in a custom way.