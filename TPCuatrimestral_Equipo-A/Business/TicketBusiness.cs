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
        public static int Agregar(Ticket ticket)
        {
            AccessData data = new AccessData();
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                string columns, values;
                columns = values = "";
                if (ticket.Tipo != null)
                {
                    columns += "ID_TIPO,";
                    values += $"@Id_tipo,";
                    parameters.Add(new SqlParameter("@Id_tipo", ticket.Tipo.ID));
                }
                else
                {
                    return -1;
                }
                if (ticket.Prioridad != null)
                {
                    columns += "ID_PRIORIDAD,";
                    values += $"@Id_prioridad,";
                    parameters.Add(new SqlParameter("@Id_prioridad", ticket.Prioridad.ID));
                }
                else
                {
                    return -1;
                }
                if (ticket.DescripcionInicial != null && ticket.DescripcionInicial != "")
                {
                    columns += "DESCRIPCION_INICIAL,";
                    values += $"@Descripcion_inicial,";
                    parameters.Add(new SqlParameter("@Descripcion_inicial", ticket.DescripcionInicial));
                }
                else { return -1; }
                if (ticket.DescripcionCierre != null && ticket.DescripcionCierre != "")
                {
                    columns += "DESCRIPCION_CIERRE,";
                    values += $"@Descripcion_cierre,";
                    parameters.Add(new SqlParameter("@Descripcion_cierre", ticket.DescripcionCierre));
                }
                if (ticket.LegajoUsuario != null && ticket.LegajoUsuario != "")
                {
                    columns += "LEGAJO_USUARIO,";
                    values += $"@Legajo_usuario,";
                    parameters.Add(new SqlParameter("@Legajo_usuario", ticket.LegajoUsuario));
                }
                else { return -1; }
                if (ticket.ClienteAfectado != null)
                {
                    columns += "CLIENTE_AFECTADO,";
                    values += $"@Cliente_afectado,";
                    parameters.Add(new SqlParameter("@Cliente_afectado", ticket.ClienteAfectado.ID));
                }
                else { return -1; }
                // Se crea por default - Lucas
                //if (ticket.FechaCreacion != null)
                //{
                //    columns += "FECHA_CREACION,";
                //    values += $"@Descripcion_cierre,";
                //    parameters.Add(new SqlParameter("@Descripcion_cierre", ticket.DescripcionCierre));
                //}
                if (ticket.Estado != null)
                {
                    columns += "ID_ESTADO,";
                    values += $"@Id_estado,";
                    parameters.Add(new SqlParameter("@Id_estado", ticket.Estado.ID));
                }
                else { return -1; }


                string query = $@"
                    INSERT INTO TICKETS 
                        ({columns})
                    VALUES
                        ({values})";

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
        public static bool ModificarTicket(Ticket ticket)
        {
            AccessData data = new AccessData();
            try
            {
                // Actualizar Ticket en la base de datos.
                data.SetQuery("UPDATE Tickets SET Tipo = @Tipo, " +
                    "Prioridad = @Prioridad, " +
                    "DescripcionInicial = @DescripcionInicial, " +
                    "DescripcionCierre = @DescripcionCierre, " +
                    "LegajoUsuario = @LegajoUsuario, " +
                    "NombreUsuario = @NombreUsuario, " +
                    "ClienteAfectado = @ClienteAfectado, " +
                    "FechaCreacion = @FechaCreacion, " +
                    "FechaCierre = @FechaCierre, " +
                    "Estado = @Estado WHERE ID = @Id");
                data.AddParameter("@Id", ticket.ID);
                data.AddParameter("@Tipo", ticket.Tipo);
                data.AddParameter("@Prioridad", ticket.Prioridad);
                data.AddParameter("@DescripcionInicial", ticket.DescripcionInicial);
                data.AddParameter("@DescripcionCierre", ticket.DescripcionCierre);
                data.AddParameter("@LegajoUsuario", ticket.LegajoUsuario);
                data.AddParameter("@NombreUsuario", ticket.NombreUsuario);
                data.AddParameter("@ClienteAfectado", ticket.ClienteAfectado.ID); 
                data.AddParameter("@FechaCreacion", ticket.FechaCreacion);
                data.AddParameter("@FechaCierre", ticket.FechaCierre);
                data.AddParameter("@Estado", ticket.Estado);

                data.ExecuteQuery();
                return true;
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

        public static bool BajaLogicaTicket(int ticketID)
        {
            AccessData data = new AccessData();
            try
            {
                // Baja logica
                data.SetQuery("UPDATE Tickets SET ESTADO = 0 WHERE ID = @Id");
                data.AddParameter("@Id", ticketID);

                data.ExecuteQuery();
                return true;
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
