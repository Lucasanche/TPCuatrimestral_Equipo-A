using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PrioridadBusiness
    {
        public static List<Prioridad> List()
        {
            List<Prioridad> prioridadesLista = new List<Prioridad>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID, NOMBRE FROM PRIORIDADES WHERE ESTADO = 1");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    Prioridad prioridadAux = new Prioridad();
                    prioridadAux.ID = (byte)data.Reader["ID"];
                    prioridadAux.Nombre = data.Reader["NOMBRE"].ToString();
                    prioridadesLista.Add(prioridadAux);
                }
                return prioridadesLista;
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
        public static Prioridad PrioridadPorID(byte ID)
        {
            Prioridad prioridad = new Prioridad();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , NOMBRE
                                FROM PRIORIDADES WHERE ID = " + ID.ToString());
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    prioridad.ID = (byte)data.Reader["ID"];
                    prioridad.Nombre = data.Reader["NOMBRE"].ToString();
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
            return prioridad;
        }
    }
}
