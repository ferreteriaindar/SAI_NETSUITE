using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Logistica.Distribucion
{
    class GastoFleterasController
    {

        public List<Models.Catalogos.Vendor> regresaVendors()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var z = (from i in ctx.Entity
                         where (i.ENTITY_TYPE.Equals("Vendor") && i.PAQUETERIA_DISTRIBUCION_ID != null)
                         select new Models.Catalogos.Vendor { ENTITY_ID = i.ENTITY_ID, NAME = i.NAME, PAQUETERIA_DISTRIBUCION_ID = i.PAQUETERIA_DISTRIBUCION_ID }).ToList();
                return z;
            }
            
        }

        public List<NumeroGuiaNetsuite> regresaGuias(string v)
        {
            int idpaqueteria = Convert.ToInt32(v);

            IndarnegEntities ctx = new IndarnegEntities();
            
                var guias = (from i in ctx.NumeroGuiaNetsuite
                             where (i.idPaqueteria== idpaqueteria)
                             select i).ToList();
                return guias.ToList();
           

        }
    }
}
