using Data;
using Domain;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
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
                data.SetQuery(@"SELECT ID, NOMBRE, ESTADO FROM TIPOS_INCIDENCIA WHERE ESTADO = 1;");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    TipoTicket tipoTicketAux = new TipoTicket();
                    tipoTicketAux.ID = (sbyte)data.Reader["ID"];
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
                                FROM TIPOS_INCIDENCIA WHERE ID = " + ID.ToString()+ ";");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    tipoTicket.ID = (sbyte)data.Reader["ID"];
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
        public static int AgregarTipoTicket(string nombre)
        {
            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            try
            {
                // Actualiza
                data.SetQuery("INSERT INTO TIPOS_INCIDENCIA (NOMBRE) VALUES ('@Nombre');");
                data.AddParameter("@Nombre", nombre);

                return data.ExecuteNonQuery();
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
        public static int EliminarTipoTicket(string desc)
        {
            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            try
            {
                // Actualiza
                data.SetQuery("DELETE FROM TIPOS_INCIDENCIA WHERE DESCRIPCION = @Descripcion;");
                data.AddParameter("@Descripcion", desc);

                return data.ExecuteNonQuery();
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
        public static int ModificarTipoTicket(string ticket, string nuevaDesc)
        {
            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            try
            {
                // Actualiza
                data.SetQuery("UPDATE TIPOS_INCIDENCIA SET NOMBRE = @NuevaDescripcion WHERE NOMBRE = @Ticket;");
                data.AddParameter("@Ticket", ticket);
                data.AddParameter("@NuevaDescripcion", nuevaDesc);

                return data.ExecuteNonQuery();
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
