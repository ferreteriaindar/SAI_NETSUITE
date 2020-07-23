using SAI_NETSUITE.Views.Ventas.Apoyos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Ventas
{
    class saleOrderEditorController
    {


        public bool actualizaDetalle(List<saleordereditorART> lista,string pedido)
        {

            int tranid = Convert.ToInt32(pedido);
            try
            {
                using (IWSEntities ctx = new IWSEntities())
                {
                    foreach (var articulo in lista)
                    {
                        var result = (from so in ctx.SaleOrders
                                      join sod in ctx.SaleOrdersDetails on so.internalId equals sod.saleOrderId
                                      where so.tranId==tranid && sod.itemId.Equals(articulo.itemid)
                                      select sod).FirstOrDefault();
                        if (articulo.cantidad != 0)
                        {
                            result.quantity = articulo.cantidad;
                            result.backOrdered = 0;
                        }
                        else
                        {
                            ctx.SaleOrdersDetails.Attach(result);
                            ctx.SaleOrdersDetails.Remove(result);
                        }

                        ctx.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool InsertaAWMS(string tranid)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var pedido = (from so in ctx.SaleOrders
                              join CU in ctx.Customers on so.idCustomer equals CU.internalid
                              join FO in ctx.FormaEnvio on so.shippingWay equals FO.LIST_ID
                              join DIR in ctx.Address on so.shippingAddress equals DIR.addressID
                              join PAQ in ctx.Paqueteria on so.package equals PAQ.LIST_ID
                              where so.tranId == Convert.ToInt32(tranid)
                              select so);
                if (pedido != null)
                { new PedidoEstatusBOController().insertaPedidoWMS(tranid);
                    return true;
                }
                else return false;
            }
        }
    }
}
