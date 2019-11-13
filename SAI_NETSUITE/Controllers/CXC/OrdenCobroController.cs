using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.CXC
{
    class OrdenCobroController
    {



        public List<Models.Catalogos.Empleado> llenaEmpleados()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var emp = from x in ctx.Entity.Where(s => s.ENTITY_TYPE.Equals("Employee")) select new Models.Catalogos.Empleado() { id = x.ENTITY_ID, nombre = x.NAME };
                return emp.ToList();

            }

        }

        public bool existeFacturaEnEmbarque(int numFac)
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                if (ctx.EmbarquesD.Any(o => o.factura.Equals(numFac.ToString())))
                    return true;
                else return false;

            }
        }

        public int regresaInternalID(int numFac)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var internalID = (from i in ctx.Invoices
                                   where i.TranId.Equals(numFac)
                                   select i.internalId).SingleOrDefault();
                return Convert.ToInt32(internalID.ToString());
                                 

            }
        }
    }
}
