using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Business
{
    internal class TicketBusiness
    {
        public static List<Ticket> List()
        {
            List<Ticket> ticketLista = new List<Ticket>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID, 
                                ID_TIPO,
                                ID_PRIORIDAD,
                                ISNULL(ID_PRIORIDAD, 0),
                                DESCRIPCION_INICIAL,
                                DESCRIPCION_CIERRE, 
                                ISNULL(DESCRIPCION_CIERRE, 'Cerrado sin descripcion'),
                                USUARIO_ASIGNADO, 
                                CLIENTE_AFECTADO,
                                FECHA_INICIO,
                                FECHA_FIN,
                                ID_ESTADO,
                                ESTADO
                                FROM TICKE");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    //Ticket ticketAux = new Ticket();
                    ////{
                    //ticketAux.ID = (int)data.Reader["Id"];
                    //ticketAux.tipo_id = (byte)data.Reader["ID_TIPO"];
                    //ticketAux.IDPrioridad = (byte)data.Reader["ID_PRIORIDAD"];
                    //ticketAux.DescripcionIncial = data.Reader["DESCRIPCION_INICIAL"].ToString();
                    //ticketAux.DescripcionCierre = data.Reader["DESCRIPCION_CIERRE"].ToString();
                    //ticketAux.UsuarioAsignado = (int)data.Reader["USUARIO_ASIGNADO"];
                    //ticketAux.ClienteAfectado = (int)data.Reader["CLIENTE_AFECTADO"];
                    //ticketAux.FechaInicio = (DateTime)data.Reader["FECHA_INICIO"];
                    //ticketAux.FechaFin = (DateTime)data.Reader["FECHA_FIN"];
                    //ticketAux.IDEstado = (byte)data.Reader["ID_ESTADO"];
                    //ticketAux.Estado = (bool)data.Reader["ESTADO"];
                    //};
                    ticketLista.Add(ticketAux);
                }
                return ticketLista;
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
        public static int Remove(Ticket ticket)
        {
            AccessData data = new AccessData();
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                string query = "DELETE FROM TICKETS WHERE ID = @Id";
                parameters.Add(new SqlParameter("@Id", ticket.ID));
                data.SetQuery(query, parameters);
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
        public static int GetIdTicketMasViejo()
        {
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT MIN(FECHA_INICIO) FROM TICKETS");
                data.ExecuteQuery();
                data.Reader.Read();
                return (int)data.Reader.GetInt32(0);
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                data.Close();
            }

        }
    }
}
