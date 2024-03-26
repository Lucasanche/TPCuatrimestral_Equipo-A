using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
                    if (ticket.LegajoUsuario == usuario.Legajo)
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
                int ticketID = Convert.ToInt32(e.CommandArgument);
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

           
        }
    }
}
// TODO:
//-Ver usuarios responsables de tickets
//- Modificar columna "Tipo" por "Tipo de incidente"
//- Flechita de ordenamiento de filas
//- Usuario responsable -> Agente responsable
//- Cambiar columna "Opciones" a "Detalles" y sacarle el "Ver" al botón
//- Añadir "marca" a la derecha de la barra de navegación.
//- Añadir filtros al buscador de clientes
//- Añadir buscador a Tickets
//- Sacar botón "login"
//- Añadir "Cliente encontrado" en "Agregar Cliente"
//- Colores según el estado del ticket
//- Tickets tarda mucho ????????????????????????????????????????????????????????
//- Que no desaparezca el botón de "Agregar ticket".

//AGREGAR TICKET
//- botón de guardar dice "guardar cliente"
//- Agente responsable en vez de "usuario"
//- Tipo de incidente en vez de "tipo"

//AGREGAR CLIENTES:
//-Cambiar calendario fecha nacimiento

//CLIENTES:
//-Añadir servicios contratados
//- Cambiar "VER" Por EDITAR (lapicito)

//DETALLE DE CLIENTE
//- Botón "eliminar cliente" abre un aviso que dice "Headline"
//- No funca eliminar cliente
//- Avisos no se borran
//- Cambiar botón "Editar cliente" por "confirmar cambios"