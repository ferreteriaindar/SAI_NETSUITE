using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Logistica.Empaque
{
    class FacturaIndarController
    {

        public DataSet regresaDatosCabecera(int numFactura)
        {
            DataSet ds = new DataSet();
            using (IWSEntities ctx = new IWSEntities())
            {
                var FacturaEncabezado = from i in ctx.Invoices
                                        join c in ctx.Customers on i.Entity equals c.internalid
                                        join fe in ctx.FormaEnvio on i.ShippingWay equals fe.LIST_ID
                                        join tp in ctx.TerminosDePago on i.TerminosPago equals tp.nso___TRMINOS_DE_PAGO_ID
                                        join zi in ctx.ZonasIndar on c.customerZone equals zi.NSO___ZONAS_CLIENTES_ID
                                        join Evend in ctx.Entity on zi.REPRESENTANTE_VENTAS_ID equals Evend.ENTITY_ID
                                        join Ecob in ctx.Entity on zi.AGENTE_COBRADOR_ID equals Ecob.ENTITY_ID
                                        join DirFac in ctx.Address on c.internalid equals DirFac.entity_id
                                        join Dep in ctx.Departments on c.Department equals Dep.DEPARTMENT_ID
                                        join DepPa in ctx.Departments on Dep.PARENT_ID equals DepPa.DEPARTMENT_ID
                                        join Sale in ctx.SaleOrders on i.createdfrom equals Sale.internalId
                                        join fletera in ctx.Paqueteria on i.Paqueteria equals fletera.LIST_ID



                                        where i.TranId == numFactura
                                        select new
                                        {
                                            i.TranId,
                                            TranDate=DateTime.Now, // i.TranDate,
                                            vendedor = Evend.NAME,
                                            cobrador = Ecob.NAME,
                                            terminosPago = i.ClienteContado == 1 ? "Contado" : "Crédito",
                                            i.FechaVencimiento,
                                            formaenvio = fe.LIST_ITEM_NAME,
                                            gerencia = DepPa.NAME,
                                            i.CFDIFormaDePago,
                                            i.CfdiMetPagoSat,
                                            i.UsoCFDI,
                                            i.CurrencySymbol,
                                            i.ExchangeRate,
                                            CondicionesPago = tp.NSO___TRMINOS_DE_PAGO_NAME,
                                            cliente = c.companyId + " " + c.company,
                                            enviarA = i.ShipAddress+" TEL: "+c.phone,
                                            direccion = i.BillAddress+" TEL: "+c.phone +" RFC: "+c.RFC, // DirFac.addr1 + " " + DirFac.addr2 + " " + DirFac.city + " " + DirFac.state + " " + DirFac.country + " " + DirFac.postalCode,
                                            Pedido = "Sales Order #" + Sale.tranId,
                                            Observaciones = i.Memo,
                                            paqueteria = fletera.LIST_ITEM_NAME,
                                            ordenCompra = i.OrdenCompra,
                                            referencia = c.bankReference


                                        };

                var FacturaDetalle = from Id in ctx.InvoicesDetail
                                     join I in ctx.Items on Id.item.ToString() equals I.id
                                     where Id.InvoicesId == numFactura
                                     select new { Id.quantity, I.unitstypeText, I.CASAT, I.itemid, I.purchasedescription, Id.DiscountTotal, Id.rate,Id.tax1amt };



                DataTable dtDetalle = new DataTable();
                dtDetalle.Columns.Add("cant", typeof(int));
                dtDetalle.Columns.Add("unidad", typeof(string));
                dtDetalle.Columns.Add("caSAT", typeof(string));
                dtDetalle.Columns.Add("itemid", typeof(string));
                dtDetalle.Columns.Add("descripcion", typeof(string));
                dtDetalle.Columns.Add("plista", typeof(decimal));
                dtDetalle.Columns.Add("desc", typeof(decimal));
                dtDetalle.Columns.Add("pUnitario", typeof(decimal));
                dtDetalle.Columns.Add("importe", typeof(decimal));
                dtDetalle.Columns.Add("iva", typeof(decimal));


                foreach (var item in FacturaDetalle)
                {


                    dtDetalle.Rows.Add(item.quantity,
                                 item.unitstypeText,
                                 item.CASAT,
                                 item.itemid,
                                 item.purchasedescription,
                                decimal.Round( (decimal) item.rate * 100 / Math.Abs((decimal)item.DiscountTotal - 100),2),
                                 item.DiscountTotal,
                                 item.rate,
                                 item.rate * item.quantity,
                                 item.tax1amt
                                 );
                }

                DataTable dtSumatoria = new DataTable();
                dtSumatoria.Columns.Add("letra", typeof(string));
                dtSumatoria.Columns.Add("subTotal", typeof(decimal));
                dtSumatoria.Columns.Add("IVA", typeof(decimal));
                dtSumatoria.Columns.Add("total", typeof(decimal));

                decimal subtotal = dtDetalle.AsEnumerable().Sum(r => r.Field<decimal>("importe"));
                decimal iva = dtDetalle.AsEnumerable().Sum(r => r.Field<decimal>("iva")); //subtotal * (decimal)0.16;
                Moneda m = new Moneda();

                dtSumatoria.Rows.Add(m.Convertir(Math.Round(subtotal + iva,2).ToString(), false, "PESOS"), subtotal, iva, subtotal + iva);


                DataTable dt = new DataTable();
                dt.Columns.Add("TranId", typeof(int));
                dt.Columns.Add("TranDate", typeof(string));
                dt.Columns.Add("vendedor", typeof(string));
                dt.Columns.Add("cobrador", typeof(string));
                dt.Columns.Add("terminosPago", typeof(string));
                dt.Columns.Add("FechaVencimiento", typeof(string));
                dt.Columns.Add("formaenvio", typeof(string));
                dt.Columns.Add("gerencia", typeof(string));
                dt.Columns.Add("CFDIFormaDePago", typeof(string));
                dt.Columns.Add("CfdiMetPagoSat", typeof(string));
                dt.Columns.Add("UsoCFDI", typeof(string));
                dt.Columns.Add("CurrencySymbol", typeof(string));
                dt.Columns.Add("ExchangeRate", typeof(int));
                dt.Columns.Add("CondicionesPago", typeof(string));
                dt.Columns.Add("cliente", typeof(string));
                dt.Columns.Add("enviarA", typeof(string));
                dt.Columns.Add("direccion", typeof(string));
                dt.Columns.Add("Pedido", typeof(string));
                dt.Columns.Add("Observaciones", typeof(string));
                dt.Columns.Add("paqueteria", typeof(string));
                dt.Columns.Add("ordenCompra", typeof(string));
                dt.Columns.Add("referencia", typeof(string));
                dt.Columns.Add("cant", typeof(int));
                dt.Columns.Add("unidad", typeof(string));
                dt.Columns.Add("caSAT", typeof(string));
                dt.Columns.Add("itemid", typeof(string));
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("plista", typeof(decimal));
                dt.Columns.Add("desc", typeof(decimal));
                dt.Columns.Add("pUnitario", typeof(decimal));
                dt.Columns.Add("importe", typeof(decimal));
               


                foreach (var item in FacturaDetalle)
                {

                                 dt.Rows.Add(
                     FacturaEncabezado.First().TranId,
                     FacturaEncabezado.First().TranDate,
                     FacturaEncabezado.First().vendedor,
                      FacturaEncabezado.First().cobrador,
                      FacturaEncabezado.First().terminosPago,
                     Convert.ToDateTime(FacturaEncabezado.First().FechaVencimiento).ToShortDateString(),
                      FacturaEncabezado.First().formaenvio,
                      FacturaEncabezado.First().gerencia,
                      FacturaEncabezado.First().CFDIFormaDePago,
                      FacturaEncabezado.First().CfdiMetPagoSat,
                      FacturaEncabezado.First().UsoCFDI,
                      FacturaEncabezado.First().CurrencySymbol,
                      FacturaEncabezado.First().ExchangeRate,
                     FacturaEncabezado.First().CondicionesPago,
                     FacturaEncabezado.First().cliente,
                      FacturaEncabezado.First().enviarA,
                     FacturaEncabezado.First().direccion,
                     FacturaEncabezado.First().Pedido,
                      FacturaEncabezado.First().Observaciones,
                      FacturaEncabezado.First().paqueteria,
                       FacturaEncabezado.First().ordenCompra,
                       FacturaEncabezado.First().referencia,
                       item.quantity,
                                 item.unitstypeText,
                                 item.CASAT,
                                 item.itemid,
                                 item.purchasedescription,
                                 decimal.Round((decimal)item.rate * 100 / Math.Abs((decimal)item.DiscountTotal - 100), 2),
                                 item.DiscountTotal,
                                 item.rate,
                                 item.rate * item.quantity
                       );
            }
                ds.Tables.Add(dt);
               // ds.Tables.Add(dtDetalle);
                ds.Tables.Add(dtSumatoria);
            }



            return ds;

        }
    }
}
