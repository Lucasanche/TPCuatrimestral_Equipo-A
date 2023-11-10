using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Business
{
    public class TicketBusiness
    {
        public static List<Ticket> List()
        {
            List<Ticket> ticketLista = new List<Ticket>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT 
                                ticket.ID
                                , tipo.ID AS ID_TIPO
                                , tipo.NOMBRE AS TIPO
                                , priori.ID AS ID_PRIORIDAD
                                , priori.NOMBRE AS PRIORIDAD
                                , ticket.DESCRIPCION_INICIAL
                                , ISNULL(ticket.DESCRIPCION_CIERRE, 'Sin asignar') AS DESCRIPCION_CIERRE
                                , usuario.LEGAJO AS LEGAJO_USUARIO
                                , CONCAT(usuario.NOMBRE,' ', usuario.APELLIDO) AS USUARIO
                                , CLIENTE_AFECTADO
                                , ticket.FECHA_INICIO
                                , FECHA_FIN
                                , estado.ID AS ID_ESTADO
                                , estado.NOMBRE AS ESTADO
                                FROM TICKETS ticket
                                LEFT JOIN TIPOS_INCIDENCIA AS tipo ON ticket.ID_TIPO = tipo.ID
                                LEFT JOIN PRIORIDADES AS priori ON ticket.ID_PRIORIDAD = priori.ID
                                LEFT JOIN ESTADOS_TICKET AS estado ON ticket.ID_ESTADO = estado.ID
                                LEFT JOIN USUARIOS AS usuario ON ticket.USUARIO_ASIGNADO = usuario.LEGAJO");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Ticket ticketAux = new Ticket();
                    ticketAux.ID = (int)data.Reader["Id"];
                    ticketAux.Tipo = new TipoTicket
                    {
                        ID = (byte)data.Reader["ID_TIPO"],
                        Nombre = data.Reader["TIPO"].ToString()
                    };
                    ticketAux.Prioridad = new Prioridad
                    {
                        ID = (byte)data.Reader["ID_PRIORIDAD"],
                        Nombre = data.Reader["PRIORIDAD"].ToString()
                    };
                    ticketAux.DescripcionInicial = data.Reader["DESCRIPCION_INICIAL"].ToString();
                    ticketAux.DescripcionCierre = data.Reader["DESCRIPCION_CIERRE"].ToString();
                    ticketAux.LegajoUsuario = data.Reader["LEGAJO_USUARIO"].ToString();
                    ticketAux.NombreUsuario = data.Reader["USUARIO"].ToString();
                    ticketAux.ClienteAfectado = ClientesBusiness.ClientePorID((int)data.Reader["CLIENTE_AFECTADO"]);
                    ticketAux.FechaCreacion = (DateTime)data.Reader["FECHA_INICIO"];
                    if (!data.Reader.IsDBNull(data.Reader.GetOrdinal("FECHA_FIN")))
                    {
                        ticketAux.FechaCierre = (DateTime)data.Reader["FECHA_FIN"];
                    }
                    else
                    {
                        ticketAux.FechaCierre = null;
                    }
                    ticketAux.Estado = new EstadoReclamo()
                    {
                        ID = (byte)data.Reader["ID_ESTADO"],
                        Nombre = data.Reader["ESTADO"].ToString()
                    };
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
