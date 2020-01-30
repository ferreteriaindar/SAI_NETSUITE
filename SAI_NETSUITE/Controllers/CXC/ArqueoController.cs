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

        public string regresaOrdenCobroIntelisis(string v)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"Select E.Mov+''+E.MovId, EstatusOC = E.Estatus, E.FechaRegistro,   Docto = Em.Mov+' '+Em.MovId, EstadoDocto = Ed.Estado, 
                             Rank() Over (Partition By Em.MovId Order By E.FechaRegistro Desc) As 'UltEmbF'    From indar.dbo.Embarque E WITH (NOLOCK) 
                              Left Outer Join indar.dbo.EmbarqueD Ed WITH (NOLOCK) ON E.ID = Ed.ID   Left Outer Join indar.dbo.EmbarqueMov Em WITH (NOLOCK) ON Ed.EmbarqueMov = Em.Id   LEFT JOIN  indar.dbo.Cte  ct on EM.Cliente=ct.Cliente   Where E.Empresa = 'FIN' 
                             And Em.Modulo = 'CXC'     And Em.Mov = 'Factura Indar'          And E.Mov = 'Orden Cobro'   							 
							 and  em.movid='" + v.Replace("SI- ","") + "'";
                string resultado = (cmd.ExecuteScalar() ?? "").ToString();
                return resultado;

            };
        }

        public List<Models.Catalogos.ZonaModel> regresaZonas()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var z = (from i in ctx.ZonasIndar where(i.Isnactive==0)
                         select new Models.Catalogos.ZonaModel() { id = i.NSO___ZONAS_CLIENTES_ID, zona = i.NSO___ZONAS_CLIENTES_NAME }).ToList();
                return z;
            }
        }
    }
}
