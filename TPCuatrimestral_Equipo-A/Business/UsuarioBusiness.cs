using Data;
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
        public static List<Usuario> List()
        {
            List<Usuario> usuarioLista = new List<Usuario>();
            AccessData data = new AccessData();
            try
            {
                Usuario usuarioAux = new Usuario();
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
                                     FROM USUARIOS");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    //{
                    usuarioAux.Legajo = data.Reader["LEGAJO"].ToString();
                    usuarioAux.Nombre = data.Reader["NOMBRE"].ToString();
                    usuarioAux.Apellido = data.Reader["APELLIDO"].ToString();
                    usuarioAux.Email = data.Reader["EMAIL"].ToString();
                    usuarioAux.Password = data.Reader["PASSWORD"].ToString();
                    usuarioAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    usuarioAux.Rol = RolBusiness.RolPorID((byte)data.Reader["ROL"]);
                    usuarioAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    usuarioAux.Estado = (bool)data.Reader["ESTADO"];
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
                                     , ESTADO 
                                     FROM USUARIOS");

                while (data.Reader.Read())
                {
                    usuarioAux.Legajo = data.Reader["LEGAJO"].ToString();
                    usuarioAux.Nombre = data.Reader["NOMBRE"].ToString();
                    usuarioAux.Apellido = data.Reader["APELLIDO"].ToString();
                    usuarioAux.Email = data.Reader["EMAIL"].ToString();
                    usuarioAux.Password = data.Reader["PASSWORD"].ToString();
                    usuarioAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                    usuarioAux.Rol = RolBusiness.RolPorID((byte)data.Reader["ROL"]);
                    usuarioAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                    usuarioAux.Estado = (bool)data.Reader["ESTADO"];
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
            string query = $"SELECT * FROM USUARIOS WHERE EMAIL = '{email}' AND PASSWORD = '{password}'";
            try
            {
                data.SetQuery(query);
                data.ExecuteQuery();
                if(data.Reader !=  null) {
                    while (data.Reader.Read())
                    {
                        Rol rolAux = RolBusiness.RolPorID((byte)data.Reader["ROL"]);
                        usuarioAux.Legajo = data.Reader["LEGAJO"].ToString();
                        usuarioAux.Nombre = data.Reader["NOMBRE"].ToString();
                        usuarioAux.Apellido = data.Reader["APELLIDO"].ToString();
                        usuarioAux.Email = data.Reader["EMAIL"].ToString();
                        usuarioAux.Password = data.Reader["PASSWORD"].ToString();
                        usuarioAux.FechaAlta = (DateTime)data.Reader["FECHA_ALTA"];
                        usuarioAux.Rol = RolBusiness.RolPorID((byte)data.Reader["ROL"]);
                        usuarioAux.FechaBaja = data.Reader["FECHA_BAJA"] != DBNull.Value ? (DateTime)data.Reader["FECHA_BAJA"] : (DateTime?)null;
                        usuarioAux.Estado = (bool)data.Reader["ESTADO"];
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
        public static int Remove(Usuario usuario)
        {
            AccessData data = new AccessData();
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                string query = "DELETE FROM USUARIOS WHERE LEGAJO = @Legajo";
                parameters.Add(new SqlParameter("@Legajo", usuario.Legajo));
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