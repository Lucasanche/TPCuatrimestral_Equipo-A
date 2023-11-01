using System;
using Business;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Equipo_A
{
    public partial class Clientes : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientesGV.DataSource = ClientesBusiness.List();
            ClientesGV.DataBind();
        }
    }
}