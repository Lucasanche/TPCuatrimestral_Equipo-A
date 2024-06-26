﻿using Data;
using Domain;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioBusiness
    {
        public static List<Usuario> List()
        {
            List<Usuario> usuarioLista = new List<Usuario>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT LEGAJO
                                     , NOMBRE
                                     , APELLIDO
                                     , EMAIL
                                     , PASSWORD
                                     , NOMBRE
                                     , APELLIDO
                                     , EMAIL
                                     , FECHA_BAJA
                                     , FECHA_ALTA
                                     , ROL
                                     , ESTADO 
                                     FROM USUARIOS;");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Usuario usuarioAux = new Usuario();
                    //{
                    usuarioAux.Legajo = data.Reader["LEGAJO"].ToString();
                    usuarioAux.Nombre = data.Reader["NOMBRE"].ToString();
                    usuarioAux.Apellido = data.Reader["APELLIDO"].ToString();
                    usuarioAux.Email = data.Reader["EMAIL"].ToString();
                    usuarioAux.Password = data.Reader["PASSWORD"].ToString();
                    usuarioAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    usuarioAux.Rol = RolBusiness.RolPorID((sbyte)data.Reader["ROL"]);
                    usuarioAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;

                    usuarioAux.Estado = (sbyte)data.Reader["ESTADO"];
                    usuarioLista.Add(usuarioAux);
                }
                return usuarioLista;
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
        public static Usuario UsuarioPorLegajo(string legajo)
        {
            Usuario usuarioAux = new Usuario();
            AccessData data = new AccessData();
            try
            {
                string query = "SELECT * FROM USUARIOS WHERE LEGAJO = @Legajo";
                data.AddParameter("@Legajo", legajo);
                data.SetQuery(query);
                data.ExecuteQuery();
                while (data.Reader.Read())
                {
                    usuarioAux.Legajo = data.Reader["LEGAJO"].ToString();
                    usuarioAux.Nombre = data.Reader["NOMBRE"].ToString();
                    usuarioAux.Apellido = data.Reader["APELLIDO"].ToString();
                    usuarioAux.Email = data.Reader["EMAIL"].ToString();
                    usuarioAux.Password = data.Reader["PASSWORD"].ToString();
                    usuarioAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    usuarioAux.Rol = RolBusiness.RolPorID((sbyte)data.Reader["ROL"]);
                    usuarioAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    usuarioAux.Estado = (sbyte)data.Reader["ESTADO"];
                }

                return usuarioAux;
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
        public static Usuario UsuarioPorEmail(string email, string password)
        {
            Usuario usuarioAux = new Usuario();
            AccessData data = new AccessData();
            string query = $"SELECT * FROM USUARIOS WHERE EMAIL = '{email}' AND PASSWORD = '{password}';";
            try
            {
                data.SetQuery(query);
                data.ExecuteQuery();
                if(data.Reader !=  null) {
                    while (data.Reader.Read())
                    {
                        sbyte rol = (sbyte)data.Reader["ROL"];
                        Rol rolAux = RolBusiness.RolPorID(rol);
                        usuarioAux.Rol = rolAux;
                        usuarioAux.Legajo = data.Reader["LEGAJO"].ToString();
                        usuarioAux.Nombre = data.Reader["NOMBRE"].ToString();
                        usuarioAux.Apellido = data.Reader["APELLIDO"].ToString();
                        usuarioAux.Email = data.Reader["EMAIL"].ToString();
                        usuarioAux.Password = data.Reader["PASSWORD"].ToString();
                        usuarioAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                        usuarioAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                        usuarioAux.Estado = (sbyte)data.Reader["ESTADO"];
                    }
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                data.Close();
            }
            if(usuarioAux.Legajo == null)
            {
                return null;
            }
            else
            {
                return usuarioAux;
            }
        }

        public static int ModificarUsuario(string legajo, string nombre, string apellido, string email, int rol)
        {
            AccessData data = new AccessData();
            try
            {
                // Actualiza
                data.SetQuery("UPDATE USUARIOS SET NOMBRE = @Nombre, APELLIDO = @Apellido, EMAIL = @Email, ROL = @Rol WHERE LEGAJO = @Legajo;");
                data.AddParameter("@Legajo", legajo);
                data.AddParameter("@Nombre", nombre);
                data.AddParameter("@Apellido", apellido);
                data.AddParameter("@Email", email);
                data.AddParameter("@Rol", rol);

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

        public static int AgregarUsuario(string legajo, string nombre, string apellido, string email, int rol)
        {
            AccessData data = new AccessData();
            string password = "password";
            DateTime fechaAlta = DateTime.Now;
            try
            {
                // Actualiza
                data.SetQuery("INSERT INTO USUARIOS (LEGAJO, NOMBRE, APELLIDO, EMAIL, PASSWORD, ROL) VALUES (@Legajo, @Nombre, @Apellido, @Email, @Password , @Rol);");
                data.AddParameter("@Legajo", legajo);
                data.AddParameter("@Nombre", nombre);
                data.AddParameter("@Email", email);
                data.AddParameter("@Apellido", apellido);
                data.AddParameter("@Password", password);
                data.AddParameter("@FechaAlta", fechaAlta);
                data.AddParameter("@Rol", rol); 

                return data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return -1;
                
            }
            finally
            {
                data.Close();
            }
        }

        public static int Remove(Usuario usuario)
        {
            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            try
            {
                string query = "DELETE FROM USUARIOS WHERE LEGAJO = @Legajo;";
                parameters.Add(new MySqlParameter("@Legajo", usuario.Legajo));
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

        public static int EliminarUsuario(string legajo)
        {
            AccessData data = new AccessData();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            try
            {
                string query = "DELETE FROM USUARIOS WHERE LEGAJO = @Legajo;";
                parameters.Add(new MySqlParameter("@Legajo", legajo));
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