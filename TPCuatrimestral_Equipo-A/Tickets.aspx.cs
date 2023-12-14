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
