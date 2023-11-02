using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Reflection;

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
                                       ISNULL(TELEFONO_2, 'Sin asignar') as TELEFONO2,
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
                    clienteAux.Estado = (bool)data.Reader["ESTADO"];
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
        public static int Remove(Cliente cliente)
        {
            AccessData data = new AccessData();
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                string query = "DELETE FROM CLIENTES WHERE ID = @Id";
                parameters.Add(new SqlParameter("@Id", cliente.ID));
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
        //public static int GetMaxID()
        //{
        //    AccessData data = new AccessData();
        //    try
        //    {
        //        data.SetQuery(@"SELECT MAX(Id) FROM CLIENTES");
        //        data.ExecuteQuery();
        //        data.Reader.Read();
        //        return (int)data.Reader.GetInt32(0);
        //    }
        //    catch (Exception)
        //    {
        //        return -1;
        //    }
        //    finally
        //    {
        //        data.Close();
        //    }
        //}
    }
}
