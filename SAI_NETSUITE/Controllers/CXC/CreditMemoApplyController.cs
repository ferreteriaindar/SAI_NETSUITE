using Newtonsoft.Json;
using SAI_NETSUITE.Models.Catalogos;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.CXC
{
    class CreditMemoApplyController
    {

        public List< CustomerListCombo> regresaClientes()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var z = (from i in ctx.Customers
                         
                         select new Models.Catalogos.CustomerListCombo() { name=i.company, companyid=i.companyId }).ToList();
                return z;
            }

        }

        public CreditMemoApplySearchModel regresaDatos(string cliente)
        {
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/Customer/GetCreditMemo_Apply_search?cliente=" + cliente, SAI_NETSUITE.Properties.Resources.token);
            CreditMemoApplySearchModel piam = Newtonsoft.Json.JsonConvert.DeserializeObject<CreditMemoApplySearchModel>(json);
            return piam;
        }

        public bool AplicarNotaCredito(ApplyCreditMemoSendModel acmsm)
        {
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = JsonConvert.SerializeObject(acmsm);
            string response = con.POST("api/Invoice/ApplyCreditMemo", json, SAI_NETSUITE.Properties.Resources.token);
            respuestaIWScs res = JsonConvert.DeserializeObject<respuestaIWScs>(response);
            if (res.result.responseStructure.codeStatus.Equals("OK"))
                return true;
            else return false;
        }

        public List<TIPO_DE_RELACION_V3_3> regresaTipoRelacion()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var regresa = from i in ctx.TIPO_DE_RELACION_V3_3 select i;
                return regresa.ToList();
            }
        }

        public List<FORMA_DE_PAGO_V3_3> regresaFormaPago()
        {
            using (IWSEntities ctx  = new IWSEntities())
            {
                var regresa = from i in ctx.FORMA_DE_PAGO_V3_3 select i;
                return regresa.ToList();
            }
        }
    }
}
