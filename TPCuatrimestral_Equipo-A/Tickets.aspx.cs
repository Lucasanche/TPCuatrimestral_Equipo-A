using Business;
using Domain;
using System;
using System.Collections.Generic;
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
                TicketsGV.DataSource = null;

                List<Ticket> list = TicketBusiness.List();
                Usuario usuario = (Usuario)Session["usuario"];
               
                if (usuario.Rol.ID == 1)
                {

                    List<Ticket> listAux = new List<Ticket>();
                    foreach (Ticket ticket in list)
                    {
                        if(ticket.LegajoUsuario == usuario.Legajo && !ticket.Estado.Nombre.Contains("Cerrado"))
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