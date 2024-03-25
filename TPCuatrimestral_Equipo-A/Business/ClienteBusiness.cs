using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Sockets;

namespace Business
{
    public class ClientesBusiness
    {
        public static List<Cliente> List()
        {
            List<Cliente> clienteLista = new List<Cliente>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID, 
                                       DNI, 
                                       NOMBRE, 
                                       APELLIDO,
                                       EMAIL, 
                                       TELEFONO_1, 
                                       IFNULL(TELEFONO_2, 'Sin asignar') as TELEFONO2,
                                       FECHA_NACIMIENTO,
                                       FECHA_ALTA,
                                       FECHA_BAJA,
                                       ESTADO 
                                FROM CLIENTES");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Cliente clienteAux = new Cliente();
                    //{
                    clienteAux.ID = (int)data.Reader["Id"];
                    clienteAux.DNI = data.Reader["DNI"].ToString();
                    clienteAux.Nombre = data.Reader["NOMBRE"].ToString();
                    clienteAux.Apellido = data.Reader["APELLIDO"].ToString();
                    clienteAux.Email = data.Reader["EMAIL"].ToString();
                    clienteAux.Telefono1 = data.Reader["TELEFONO_1"].ToString();
                    clienteAux.Telefono2 = data.Reader["TELEFONO2"].ToString();
                    clienteAux.FechaNacimiento = (DateTime)data.Reader["FECHA_NACIMIENTO"];
                    clienteAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    clienteAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    clienteAux.Estado = (sbyte)data.Reader["ESTADO"];
                    //};
                    clienteLista.Add(clienteAux);
                }
                return clienteLista;
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

        public static Cliente ClientePorID(int ID)
        {
            Cliente cliente = new Cliente();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , DNI
                                ,  NOMBRE 
                                , APELLIDO
                                , EMAIL
                                , TELEFONO_1
                                , IFNULL(TELEFONO_2, 'Sin asignar') as TELEFONO2
                                , FECHA_NACIMIENTO
                                , FECHA_ALTA
                                , FECHA_BAJA
                                , ESTADO 
                                FROM CLIENTES WHERE ID = " + ID.ToString() +";");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    cliente.ID = (int)data.Reader["Id"];
                    cliente.DNI = data.Reader["DNI"].ToString();
                    cliente.Nombre = data.Reader["NOMBRE"].ToString();
                    cliente.Apellido = data.Reader["APELLIDO"].ToString();
                    cliente.Email = data.Reader["EMAIL"].ToString();
                    cliente.Telefono1 = data.Reader["TELEFONO_1"].ToString();
                    cliente.Telefono2 = data.Reader["TELEFONO2"].ToString();
                    cliente.FechaNacimiento = (DateTime)data.Reader["FECHA_NACIMIENTO"];
                    cliente.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    cliente.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    cliente.Estado = (sbyte)data.Reader["ESTADO"];
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
            return cliente;
        }
        public static Cliente ClientePorDNI(int DNI)
        {
            Cliente cliente = new Cliente();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , DNI
                                ,  NOMBRE 
                                , APELLIDO
                                , EMAIL
                                , TELEFONO_1
                                , ISNULL(TELEFONO_2, 'Sin asignar') as TELEFONO2
                                , FECHA_NACIMIENTO
                                , FECHA_ALTA
                                , FECHA_BAJA
                                , ESTADO 
                                FROM CLIENTES WHERE DNI = '" + DNI.ToString()+"'");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    cliente.ID = (int)data.Reader["Id"];
                    cliente.DNI = data.Reader["DNI"].ToString();
                    cliente.Nombre = data.Reader["NOMBRE"].ToString();
                    cliente.Apellido = data.Reader["APELLIDO"].ToString();
                    cliente.Email = data.Reader["EMAIL"].ToString();
                    cliente.Telefono1 = data.Reader["TELEFONO_1"].ToString();
                    cliente.Telefono2 = data.Reader["TELEFONO2"].ToString();
                    cliente.FechaNacimiento = (DateTime)data.Reader["FECHA_NACIMIENTO"];
                    cliente.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    cliente.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    cliente.Estado = (sbyte)data.Reader["ESTADO"];
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
            return cliente;
        }

        public static Cliente ClientePorDNI(string DNI)
        {
            Cliente cliente = new Cliente();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , DNI
                                ,  NOMBRE 
                                , APELLIDO
                                , EMAIL
                                , TELEFONO_1
                                , ISNULL(TELEFONO_2, 'Sin asignar') as TELEFONO2
                                , FECHA_NACIMIENTO
                                , FECHA_ALTA
                                , FECHA_BAJA
                                , ESTADO 
                                FROM CLIENTES WHERE DNI = '" + DNI.ToString() + "'");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    cliente.ID = (int)data.Reader["Id"];
                    cliente.DNI = data.Reader["DNI"].ToString();
                    cliente.Nombre = data.Reader["NOMBRE"].ToString();
                    cliente.Apellido = data.Reader["APELLIDO"].ToString();
                    cliente.Email = data.Reader["EMAIL"].ToString();
                    cliente.Telefono1 = data.Reader["TELEFONO_1"].ToString();
                    cliente.Telefono2 = data.Reader["TELEFONO2"].ToString();
                    cliente.FechaNacimiento = (DateTime)data.Reader["FECHA_NACIMIENTO"];
                    cliente.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    cliente.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    cliente.Estado = (sbyte)data.Reader["ESTADO"];
                }
                return cliente;
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
        public static List<Cliente> ClientePorDNIParaDGV(string DNI)
        {
            List<Cliente> clienteLista = new List<Cliente>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , DNI
                                ,  NOMBRE 
                                , APELLIDO
                                , EMAIL
                                , TELEFONO_1
                                , ISNULL(TELEFONO_2, 'Sin asignar') as TELEFONO2
                                , FECHA_NACIMIENTO
                                , FECHA_ALTA
                                , FECHA_BAJA
                                , ESTADO 
                                FROM CLIENTES WHERE DNI = '" + DNI.ToString() + "'");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Cliente clienteAux = new Cliente();
                    //{
                    clienteAux.ID = (int)data.Reader["Id"];
                    clienteAux.DNI = data.Reader["DNI"].ToString();
                    clienteAux.Nombre = data.Reader["NOMBRE"].ToString();
                    clienteAux.Apellido = data.Reader["APELLIDO"].ToString();
                    clienteAux.Email = data.Reader["EMAIL"].ToString();
                    clienteAux.Telefono1 = data.Reader["TELEFONO_1"].ToString();
                    clienteAux.Telefono2 = data.Reader["TELEFONO2"].ToString();
                    clienteAux.FechaNacimiento = (DateTime)data.Reader["FECHA_NACIMIENTO"];
                    clienteAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    clienteAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    clienteAux.Estado = (sbyte)data.Reader["ESTADO"];
                    //};
                    clienteLista.Add(clienteAux);
                }
                return clienteLista;
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

        public static int GuardarCliente(string nombre, string apellido, string dni, string email, string telefono, DateTime fechaNacimiento)
        {

            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            try
            {
                
                // guardar cliente en la base de datos.
                data.SetQuery("INSERT INTO Clientes (Nombre, Apellido, DNI, Email, TELEFONO_1, FECHA_NACIMIENTO) VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono , @FechaNacimiento);");
                data.AddParameter("@Nombre", nombre);
                data.AddParameter("@Apellido", apellido);
                data.AddParameter("@Dni", dni);
                data.AddParameter("@Email", email);
                data.AddParameter("@Telefono", telefono);
                data.AddParameter("@FechaNacimiento", fechaNacimiento);
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

        public static string BuscarPor(string parametro, string valor)
        {
            string DNIcliente = "";
            AccessData data = new AccessData();
            string query = $"SELECT DNI FROM CLIENTES WHERE {parametro} = {valor};";

            try
            {
                data.SetQuery(query);
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    DNIcliente = data.Reader["DNI"].ToString();
                }
                return DNIcliente;
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
        public static int ModificarCliente(string nombre, string apellido, string email, string telefono, int id)
        {
            AccessData data = new AccessData();
            try
            {
                // Actualiza
                data.SetQuery("UPDATE CLIENTES SET NOMBRE = @Nombre, APELLIDO = @Apellido, EMAIL = @Email, TELEFONO_1 = @Telefono WHERE ID = @Id;");
                data.AddParameter("@Id", id);
                data.AddParameter("@Nombre", nombre);
                data.AddParameter("@Apellido", apellido);
                data.AddParameter("@Email", email);
                data.AddParameter("@Telefono", telefono);

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

        public static int BajaLogicaCliente(int id)
        {
            AccessData data = new AccessData();
            try
            {
                DateTime fechaBaja = DateTime.Now;

                data.SetQuery("UPDATE Clientes SET ESTADO = 0, FECHA_BAJA = @FechaBaja WHERE ID = @Id;");
                data.AddParameter("@Id", id);
                data.AddParameter("@FechaBaja", fechaBaja);

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
        public static int Remove(Cliente cliente)
        {
            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            try
            {
                string query = "DELETE FROM CLIENTES WHERE ID = @Id;";
                parameters.Add(new MySqlParameter("@Id", cliente.ID));
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
    }
}
