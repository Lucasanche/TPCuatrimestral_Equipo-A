using Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TPCuatrimestral_Equipo_A
{
    public partial class Tickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        }
    }
}

//BoundField: Represents a simple text column that displays data from a data  source.

//ButtonField: Represents a column with a button control.

//CheckBoxField: Represents a column with a checkbox control.

//CommandField: Represents a column with command buttons (such as Edit, Delete,     etc.).

//HyperLinkField: Represents a column with hyperlinks.

//ImageField: Represents a column with image controls.

//TemplateField: Represents a column with custom templates, allowing you to define the column's appearance and behavior in a custom way.