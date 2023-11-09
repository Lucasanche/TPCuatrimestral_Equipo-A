﻿using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioBusiness
    {
        public static List<Cliente> List()
        {
            List<Cliente> clienteLista = new List<Cliente>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT LEGAJO
                                       , NOMBRE
                                       , APELLIDO
                                       , EMAIL
                                       , PASSWORD
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
                                , ISNULL(TELEFONO_2, 'Sin asignar') as TELEFONO2
                                , FECHA_NACIMIENTO
                                , FECHA_ALTA
                                , FECHA_BAJA
                                , ESTADO 
                                FROM CLIENTES WHERE ID = " + ID.ToString());
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
                    cliente.Estado = (bool)data.Reader["ESTADO"];
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
    }
