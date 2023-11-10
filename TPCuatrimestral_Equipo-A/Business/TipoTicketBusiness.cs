using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TipoTicketBusiness
    {
        public static List<TipoTicket> List()
        {
            List<TipoTicket> tipoTicketLista = new List<TipoTicket>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID, NOMBRE, ESTADO FROM TIPOS_INCIDENCIA WHERE ESTADO = 1");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    TipoTicket tipoTicketAux = new TipoTicket();
                    tipoTicketAux.ID = (byte)data.Reader["ID"];
                    tipoTicketAux.Nombre = data.Reader["NOMBRE"].ToString();
                    tipoTicketLista.Add(tipoTicketAux);
                }
                return tipoTicketLista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
    }
}
