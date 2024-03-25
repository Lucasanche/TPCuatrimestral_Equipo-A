using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EstadoReclamoBusiness
    {
        public static List<EstadoReclamo> List()
        {
            List<EstadoReclamo> estadoReclamoesLista = new List<EstadoReclamo>();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID, NOMBRE FROM ESTADOS_TICKET WHERE ESTADO = 1;");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    EstadoReclamo estadoReclamoAux = new EstadoReclamo();
                    estadoReclamoAux.ID = (sbyte)data.Reader["ID"];
                    estadoReclamoAux.Nombre = data.Reader["NOMBRE"].ToString();
                    estadoReclamoesLista.Add(estadoReclamoAux);
                }
                return estadoReclamoesLista;
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
        public static EstadoReclamo EstadoReclamoPorID(byte ID)
        {
            EstadoReclamo estadoReclamo = new EstadoReclamo();
            AccessData data = new AccessData();
            try
            {
                data.SetQuery(@"SELECT ID
                                , NOMBRE
                                FROM ESTADOS_TICKET WHERE ID = " + ID.ToString() +";");
                data.ExecuteQuery();

                while (data.Reader.Read())
                {
                    estadoReclamo.ID = (sbyte)data.Reader["ID"];
                    estadoReclamo.Nombre = data.Reader["NOMBRE"].ToString();
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
            return estadoReclamo;
        }
    }
}
