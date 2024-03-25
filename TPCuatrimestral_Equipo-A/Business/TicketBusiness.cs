using Data;
using Domain;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

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
                data.SetQuery(@"use effort_callCenter;
                                SELECT
                                    ticket.ID,
                                    tipo.ID AS ID_TIPO,
                                    tipo.NOMBRE AS TIPO,
                                    priori.ID AS ID_PRIORIDAD,
                                    priori.NOMBRE AS PRIORIDAD,
                                    ticket.DESCRIPCION_INICIAL,
                                    IFNULL(ticket.DESCRIPCION_CIERRE, 'Sin asignar') AS DESCRIPCION_CIERRE,
                                    usuario.LEGAJO AS LEGAJO_USUARIO,
                                    CONCAT(usuario.NOMBRE, ' ', usuario.APELLIDO) AS USUARIO,
                                    CLIENTE_AFECTADO,
                                    ticket.FECHA_INICIO,
                                    ticket.FECHA_FIN,
                                    estado.ID AS ID_ESTADO,
                                    estado.NOMBRE AS ESTADO
                                FROM TICKETS ticket
                                LEFT JOIN TIPOS AS tipo ON ticket.ID_TIPO = tipo.ID
                                LEFT JOIN PRIORIDADES AS priori ON ticket.ID_PRIORIDAD = priori.ID
                                LEFT JOIN ESTADOS_TICKET AS estado ON ticket.ID_ESTADO = estado.ID
                                LEFT JOIN USUARIOS AS usuario ON ticket.USUARIO_ASIGNADO = usuario.LEGAJO;");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Ticket ticketAux = new Ticket();
                    ticketAux.ID = (int)data.Reader["Id"];
                    ticketAux.Tipo = new TipoTicket
                    {
                        ID = (sbyte)data.Reader["ID_TIPO"],
                        Nombre = data.Reader["TIPO"].ToString()
                    };
                    ticketAux.Prioridad = new Prioridad
                    {
                        ID = (sbyte)data.Reader["ID_PRIORIDAD"],
                        Nombre = data.Reader["PRIORIDAD"].ToString()
                    };
                    ticketAux.DescripcionInicial = data.Reader["DESCRIPCION_INICIAL"].ToString();
                    ticketAux.DescripcionCierre = data.Reader["DESCRIPCION_CIERRE"].ToString();
                    ticketAux.LegajoUsuario = data.Reader["LEGAJO_USUARIO"].ToString();
                    ticketAux.NombreUsuario = data.Reader["USUARIO"].ToString();
                    int clienteAfectado = (int)data.Reader["CLIENTE_AFECTADO"];
                    ticketAux.ClienteAfectado = ClientesBusiness.ClientePorID(clienteAfectado);
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
                        ID = (sbyte)data.Reader["ID_ESTADO"],
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
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            try
            {
                string query = "DELETE FROM TICKETS WHERE ID = @Id;";
                parameters.Add(new MySqlParameter("@Id", ticket.ID));
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
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            try
            {
                string columns, values;
                columns = values = "";
                if (ticket.Tipo != null)
                {
                    columns += "ID_TIPO,";
                    values += $"@Id_tipo,";
                    parameters.Add(new MySqlParameter("@Id_tipo", ticket.Tipo.ID));
                }
                else
                {
                    return -1;
                }
                if (ticket.Prioridad != null)
                {
                    columns += "ID_PRIORIDAD,";
                    values += $"@Id_prioridad,";
                    parameters.Add(new MySqlParameter("@Id_prioridad", ticket.Prioridad.ID));
                }
                else
                {
                    return -1;
                }
                if (ticket.DescripcionInicial != null && ticket.DescripcionInicial != "")
                {
                    columns += "DESCRIPCION_INICIAL,";
                    values += $"@Descripcion_inicial,";
                    parameters.Add(new MySqlParameter("@Descripcion_inicial", ticket.DescripcionInicial));
                }
                else { return -1; }
                if (ticket.DescripcionCierre != null && ticket.DescripcionCierre != "")
                {
                    columns += "DESCRIPCION_CIERRE,";
                    values += $"@Descripcion_cierre,";
                    parameters.Add(new MySqlParameter("@Descripcion_cierre", ticket.DescripcionCierre));
                }
                if (ticket.LegajoUsuario != null && ticket.LegajoUsuario != "")
                {
                    columns += "USUARIO_ASIGNADO,";
                    values += $"@Legajo_usuario,";
                    parameters.Add(new MySqlParameter("@Legajo_usuario", ticket.LegajoUsuario));
                }
                else { return -1; }
                if (ticket.ClienteAfectado != null)
                {
                    columns += "CLIENTE_AFECTADO,";
                    values += $"@Cliente_afectado,";
                    parameters.Add(new MySqlParameter("@Cliente_afectado", ticket.ClienteAfectado.ID));
                }
                else { return -1; }
                // Se crea por default - Lucas
                //if (ticket.FechaCreacion != null)
                //{
                //    columns += "FECHA_CREACION,";
                //    values += $"@Descripcion_cierre,";
                //    parameters.Add(new MySqlParameter("@Descripcion_cierre", ticket.DescripcionCierre));
                //}
                if (ticket.Estado != null)
                {
                    columns += "ID_ESTADO";
                    values += $"@Id_estado";
                    parameters.Add(new MySqlParameter("@Id_estado", ticket.Estado.ID));
                }
                else { return -1; }


                string query = $@"
                    INSERT INTO TICKETS 
                        ({columns})
                    VALUES
                        ({values});";

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
        public static int ModificarTicket(Ticket ticket, Ticket ticketNuevo)
        {
            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            try
            {
                string values = "";
                parameters.Add(new MySqlParameter("Id", ticketNuevo.ID));
                if (ticket.Tipo.ID != ticketNuevo.Tipo.ID)
                {
                    values += "ID_TIPO = @Id_tipo,";
                    parameters.Add(new MySqlParameter("@Id_tipo", ticketNuevo.Tipo.ID));
                }
                if (ticket.Prioridad.ID != ticketNuevo.Prioridad.ID)
                {
                    values += "ID_PRIORIDAD = @Id_prioridad,";
                    parameters.Add(new MySqlParameter("@Id_prioridad", ticketNuevo.Prioridad.ID));
                }

                //TODO: Enviar email acá
                if (!string.IsNullOrEmpty(ticketNuevo.DescripcionCierre) && !ticketNuevo.DescripcionCierre.Contains("Sin asignar"))
                {
                    values += "DESCRIPCION_CIERRE = @Descripcion_cierre,";
                    parameters.Add(new MySqlParameter("@Descripcion_cierre", ticketNuevo.DescripcionCierre));
                }
                if (!string.IsNullOrEmpty(ticketNuevo.DescripcionInicial) && !ticketNuevo.DescripcionInicial.Contains("Sin asignar"))
                {
                    values += "DESCRIPCION_INICIAL = @Descripcion_inicial,";
                    parameters.Add(new MySqlParameter("@Descripcion_inicial", ticketNuevo.DescripcionInicial));
                }
                if (ticket.LegajoUsuario != ticketNuevo.LegajoUsuario)
                {
                    values += "USUARIO_ASIGNADO = @Legajo_usuario,";
                    parameters.Add(new MySqlParameter("@Legajo_usuario", ticketNuevo.LegajoUsuario));
                }
                if (ticket.Estado.ID != ticketNuevo.Estado.ID)
                {
                    values += " ID_ESTADO = @Id_estado,";
                    parameters.Add(new MySqlParameter("@Id_estado", ticketNuevo.Estado.ID));
                }
                if (values.EndsWith(","))
                {
                    values = values.Substring(0, values.Length - 1);
                }
                string query = $@"UPDATE TICKETS SET {values} WHERE ID = @Id;";

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

        public static bool BajaLogicaTicket(int ticketID)
        {
            AccessData data = new AccessData();
            try
            {
                // Baja logica
                data.SetQuery("UPDATE Tickets SET ESTADO = 0 WHERE ID = @Id;");
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
        public static Ticket BuscarTicketPorID(int ticketID)
        {
            Ticket ticket = null; // Inicializa la variable en null

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
                            LEFT JOIN USUARIOS AS usuario ON ticket.USUARIO_ASIGNADO = usuario.LEGAJO
                            WHERE ticket.ID = @TicketID;"); // Utiliza un parámetro para evitar SQL injection
                data.AddParameter("@TicketID", ticketID); // Agrega el parámetro al comando
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    ticket = new Ticket(); // Inicializa el objeto solo si hay datos
                    ticket.ID = (int)data.Reader["Id"];
                    ticket.Tipo = new TipoTicket
                    {
                        ID = (sbyte)data.Reader["ID_TIPO"],
                        Nombre = data.Reader["TIPO"].ToString()
                    };
                    ticket.Prioridad = new Prioridad
                    {
                        ID = (sbyte)data.Reader["ID_PRIORIDAD"],
                        Nombre = data.Reader["PRIORIDAD"].ToString()
                    };
                    ticket.DescripcionInicial = data.Reader["DESCRIPCION_INICIAL"].ToString();
                    ticket.DescripcionCierre = data.Reader["DESCRIPCION_CIERRE"].ToString();
                    ticket.LegajoUsuario = data.Reader["LEGAJO_USUARIO"].ToString();
                    ticket.NombreUsuario = data.Reader["USUARIO"].ToString();
                    ticket.ClienteAfectado = ClientesBusiness.ClientePorID((int)data.Reader["CLIENTE_AFECTADO"]);
                    ticket.FechaCreacion = (DateTime)data.Reader["FECHA_INICIO"];
                    if (!data.Reader.IsDBNull(data.Reader.GetOrdinal("FECHA_FIN")))
                    {
                        ticket.FechaCierre = (DateTime?)data.Reader["FECHA_FIN"];
                    }
                    else
                    {
                        ticket.FechaCierre = null;
                    }
                    ticket.Estado = new EstadoReclamo()
                    {
                        ID = (sbyte)data.Reader["ID_ESTADO"],
                        Nombre = data.Reader["ESTADO"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el ticket por ID: {ex.Message}");
                throw;
            }
            finally
            {
                data.Close();
            }

            return ticket;
        }
        public static int GetIdTicketMasViejo()
        {
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT MIN(FECHA_INICIO) FROM TICKETS;");
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
