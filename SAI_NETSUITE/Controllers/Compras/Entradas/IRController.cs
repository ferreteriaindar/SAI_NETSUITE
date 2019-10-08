using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SAI_NETSUITE.Controllers.Compras.Entradas
{
    class IRController
    {


        public DataSet regresaInfo()
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                
                string query = @"select WMS.id, wms.type,wms.idReceipt,l.NAME as Location, p.NAME as Vendor,I.itemid,wms.itemquantity from  IWS.dbo.ItemReceiptWMS WMS
                                    inner JOIN IWS.DBO.Entity  P ON  WMS.entity=P.ENTITY_ID
                                    inner join iws.dbo.Locations L on wms.location=l.LOCATION_ID
                                    inner join iws.dbo.Items I on wms.item=I.id
                                    where wms.location=16 and p.NAME is not null AND WMS.syncWMS IS NULL";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                return ds;

            }



        }

        public void actualizaSyncWMS(int[] ids)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                for (int i = 0; i < ids.Length; i++)
                {
                    cmd.CommandText = "update iws.dbo.ItemReceiptWMS set  syncwms = 1 where id = " + ids[i].ToString();

                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
