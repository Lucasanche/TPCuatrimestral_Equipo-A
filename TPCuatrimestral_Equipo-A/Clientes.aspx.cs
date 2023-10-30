using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Equipo_A
{
    public class Coso
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public List<Coso> listar()
        {
            List<Coso> lista = new List<Coso>();
            lista.Add(new Coso());
            lista.Add(new Coso());
            lista[0].ID = 1;
            lista[0].Nombre = "Coso 1";
            lista[0].Color = "Azul";

            lista[1].ID = 2;
            lista[1].Nombre = "Coso 2";
            lista[0].Color = "Verde";
            return lista;
        }
    }

    public partial class Clientes : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Coso coso = new Coso();
            ClientesGV.DataSource = coso.listar();
            ClientesGV.DataBind();
        }
    }
}