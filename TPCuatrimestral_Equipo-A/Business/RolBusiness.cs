using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RolBusiness
    {
        
       
        public static List<Rol> List()
        {
            List<Rol> ListaRol = new List<Rol>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery("SELECT * FROM ROLES");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Rol Rol = new Rol();
                    Rol.ID = (byte)data.Reader["ID"];
                    Rol.Descripcion = data.Reader["DESCRIPCION"].ToString();
                    ListaRol.Add(Rol);
                }
                return ListaRol;
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
        public static Rol RolPorID(byte ID)
        {
            Rol rol = new Rol();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , DESCRIPCION
                                FROM ROLES WHERE ID = " + ID.ToString());
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    rol.ID = (byte)data.Reader["ID"];
                    rol.Descripcion = data.Reader["DESCRIPCION"].ToString();
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
            return rol;
        }
    }
}
