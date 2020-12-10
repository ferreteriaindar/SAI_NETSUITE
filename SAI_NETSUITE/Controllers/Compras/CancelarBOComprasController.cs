using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Compras
{
    class CancelarBOComprasController
    {


        public int regresaIdItem(string item)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var id = from i in ctx.Items where i.itemid.Equals(item) select i;
                return Convert.ToInt32(id.First().id);

            }

        }

    }
}
