using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Logistica.MesaControl
{
   public class PlaneadorController
    {

        public List<PlaneadorModel> GetPlaneadors()
        {
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            string query = @" exec INDAR_INACTIONWMS.dbo.spPlaneadorMesaControl";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<PlaneadorModel> lista = new List<PlaneadorModel>();

            foreach (DataRow  dr in ds.Tables[0].Rows)
            {
                PlaneadorModel pm = new PlaneadorModel();
                pm.AREA = dr["AREA"].ToString();
                pm.Clave = dr["Clave"].ToString();
                pm.Cliente = dr["Cliente"].ToString();
                pm.FormaEnvio = dr["FormaEnvio"].ToString();
                pm.IdEstilo = Convert.ToInt32(dr["IdEstilo"].ToString());
                pm.Mov = dr["Mov"].ToString();
                pm.Nombre = dr["Nombre"].ToString();
                pm.NumPedido = Convert.ToInt32(dr["NumPedido"].ToString());
                pm.porsurtir = Convert.ToInt32(dr["porsurtir"].ToString());
                pm.Prioridad = Convert.ToInt32(dr["Prioridad"].ToString());
                pm.surtido = Convert.ToInt32(dr["surtido"].ToString());

                lista.Add(pm);

            }
            return lista;

        }

    }
}
