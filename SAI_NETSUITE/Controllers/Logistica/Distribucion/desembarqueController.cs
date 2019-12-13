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

        public DataTable regresaEmbarque(int idEmbarque,string perfil)
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {               

                string query = @"select  ed.idembarque,factura,ed.entity_id,'' as estado,formaenvio,comentario='',revisado=0 from Indarneg.dbo.EmbarquesD   ED
                                INNER JOIN Indarneg.dbo.Embarques E on ed.idEmbarque=e.idEmbarque 
                                where  e.estatus='TRANSITO' and ed.estado='TRANSITO' AND ed.idembarque=" + idEmbarque.ToString();
                if (perfil.Equals("POSTVENTA"))
                    query = @"select  ed.idembarque,factura,ed.entity_id,'Flete X Confirmar' as estado,formaenvio,comentario='',revisado=0 from Indarneg.dbo.EmbarquesD   ED
                            INNER JOIN Indarneg.dbo.Embarques E on ed.idEmbarque=e.idEmbarque 
                            where  e.estatus='TRANSITO'  and ed.estado='TRANSITO' AND  ed.idembarque=" + idEmbarque.ToString();
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                return ds.Tables[0];
            }

        }

        public bool desembarcarEmbarque(int idembarque,string destino,DataTable data,string perfil,bool todoElEmbarque)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("",myConnection);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if(!perfil.Equals("POSTVENTA"))
                    cmd.CommandText = "update  indarneg.dbo.embarquesD set estado='DESEMBARQUE " + destino + "', comentarios='" + data.Rows[i][1].ToString() + "' WHERE IDEMBARQUE=" + idembarque.ToString() + " and factura='" + data.Rows[i][0].ToString()+"'";
                    else cmd.CommandText = "update  indarneg.dbo.embarquesD set estado='"+data.Rows[i][2].ToString()+ "', comentarios='" + data.Rows[i][1].ToString() + "' WHERE IDEMBARQUE=" + idembarque.ToString() + " and factura='" + data.Rows[i][0].ToString() + "'";
                    cmd.ExecuteNonQuery();
                }
                if (todoElEmbarque)
                {
                    cmd.CommandText = "UPDATE indarneg.dbo.embarques set estatus='DESEMBARQUE " + destino + "' WHERE IDEMBARQUE=" + idembarque.ToString();
                     cmd.ExecuteNonQuery();
                }
               
                    return true;
              
            }

        }

    }
}
