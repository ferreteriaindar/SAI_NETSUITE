using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.CXC
{
    class ArqueoController
    {



        public ArqueoModel regresaPrimerosDatos(string idZona )
        {
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/Customer/GetArqueo?idZona=" + idZona,  SAI_NETSUITE.Properties.Resources.token);
            ArqueoModel am = JsonConvert.DeserializeObject<ArqueoModel>(json);
            return am;
        }


        public string regresaOrdenCobroId(string factura)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"select top 1 oc.idOrdenCobro from Indarneg.dbo.OrdenCobro OC
                                    INNER JOIN Indarneg.DBO.OrdenCobroD OCF ON oc.idOrdenCobro = OCF.idOrdenCobro
                                    where OCF.factura = '" + factura + "' order by oc.fecha desc ";
                string resultado= (cmd.ExecuteScalar() ?? "").ToString();
                return resultado;
                    
            };



        }

        public List<Models.Catalogos.ZonaModel> regresaZonas()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var z = (from i in ctx.ZonasIndar
                         select new Models.Catalogos.ZonaModel() { id = i.NSO___ZONAS_CLIENTES_ID, zona = i.NSO___ZONAS_CLIENTES_NAME }).ToList();
                return z;
            }
        }
    }
}
