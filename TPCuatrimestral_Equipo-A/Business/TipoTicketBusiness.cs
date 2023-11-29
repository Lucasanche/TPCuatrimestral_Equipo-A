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
        public static TipoTicket TipoTicketPorID(byte ID)
        {
            TipoTicket tipoTicket = new TipoTicket();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , NOMBRE
                                FROM TIPOS_INCIDENCIA WHERE ID = " + ID.ToString());
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    tipoTicket.ID = (byte)data.Reader["ID"];
                    tipoTicket.Nombre = data.Reader["NOMBRE"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
            return tipoTicket;
        }
    }
}
