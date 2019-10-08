using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Logistica.Distribucion
{
    class desembarqueController
    {

        public DataTable regresaEmbarque(int idEmbarque)
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select  idembarque,factura,entity_id,estado,formaenvio,comentario='',revisado=0 from Indarneg.dbo.EmbarquesD where idembarque=" + idEmbarque.ToString();
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                return ds.Tables[0];
            }

        }

        public bool desembarcarEmbarque(int idembarque,string destino,DataTable data)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("",myConnection);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    cmd.CommandText = "update  indarneg.dbo.embarquesD set estado='DESEMBARQUE " + destino + "', comentarios='" + data.Rows[i][1].ToString() + "' WHERE IDEMBARQUE=" + idembarque.ToString() + " and factura='" + data.Rows[i][0].ToString()+"'";
                    cmd.ExecuteNonQuery();
                }
            
                cmd.CommandText="UPDATE indarneg.dbo.embarques set estatus='DESEMBARQUE "+destino+ "' WHERE IDEMBARQUE=" + idembarque.ToString();
                int resultado=cmd.ExecuteNonQuery();
                if (resultado > 0)
                    return true;
                else return false;
            }

        }

    }
}
