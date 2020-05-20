using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.CXC
{
    class TimbrarPagoController
    {


        public NonCertifiedPaymentSearchModel cargaInfo()
        {
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/Timbrado/GetNonCertifiedPayments", SAI_NETSUITE.Properties.Resources.token);
            NonCertifiedPaymentSearchModel ncps = JsonConvert.DeserializeObject<NonCertifiedPaymentSearchModel>(json);
            return ncps;

        }


        

        public string tieneErrorPago(int internalId)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1) )
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"if  exists(select * from iws.dbo.errorTimbradoPago where internalId="+internalId.ToString()+@")
				                     select top 1 error  from iws.dbo.errorTimbradoPago where internalId="+internalId.ToString()+@"  order by idErrorTimbradoPago desc
				                     else select 'NADA'";
                return cmd.ExecuteScalar().ToString();
            }
        }
    }
}
