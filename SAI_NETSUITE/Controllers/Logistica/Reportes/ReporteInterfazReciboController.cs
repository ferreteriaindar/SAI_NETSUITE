using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Logistica.Reportes
{
    class ReporteInterfazReciboController
    {


        public List<ReporteInterfazReciboMix> cargaDatos(string FechaIni)
        {

            ReporteInterfazReciboModel netsuite = cargaDatosNetsuite(FechaIni);
            List<EntradaCompraEstatus_Out> wms = cargaDatosWMS(FechaIni);
            List<ReporteInterfazReciboMix> lista = new List<ReporteInterfazReciboMix>();

         //   lista.AddRange(revisaIR(netsuite, wms));
            lista.AddRange(revisaXMov(netsuite, wms, "IR", "LOGISTICA : 31-CCI Recibo"));
            lista.AddRange(revisaXMov(netsuite, wms, "TOR", "LOGISTICA : 32-CCI Recibo devoluciones"));
            lista.AddRange(revisaXMov(netsuite, wms, "IRE", "MERCADOTECNIA : 150-Mercancía en eventos"));
            lista.AddRange(revisaXMov(netsuite, wms, "IRP", "MERCADOTECNIA : 151-Promos y regalos mercadotec"));

            
            return lista;
        }



        public List<ReporteInterfazReciboMix> revisaIR(ReporteInterfazReciboModel netsuite, List<EntradaCompraEstatus_Out> wms)
        {
            List<ReporteInterfazReciboMix> lista = new List<ReporteInterfazReciboMix>();

            foreach (var item in wms.Where(x=>x.Mov.Equals("IR")))
            {
                DateTime fecha = Convert.ToDateTime(item.FechaModificacion);
                ReporteInterfazReciboMix aux = new ReporteInterfazReciboMix();
                if (netsuite.result.Any(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadRecibida && x.from_location.Equals("LOGISTICA : 31-CCI Recibo") && x.trandate.Equals(fecha.ToString("dd/M/yyyy"))) && !item.Estatus.Equals("REVISADO"))
                {
                    ReporteInterfazReciboModelDocumentos nAux = netsuite.result.Where(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadRecibida && x.from_location.Equals("LOGISTICA : 31-CCI Recibo") && x.trandate.Equals(fecha.ToString("dd/M/yyyy"))).FirstOrDefault();
                    aux.trandate = nAux.trandate;
                    aux.tranid = nAux.tranid;
                    aux.to_location = nAux.to_location;
                    aux.quantity = nAux.quantity;
                    aux.item = nAux.item;
                    aux.from_location = nAux.from_location;
                    aux.Articulo = item.Articulo;
                    aux.CantidadRecibida = (int)item.CantidadRecibida;
                    aux.EstatusSincronizacion = item.EstatusSincronizacion == 0?false:item.EstatusSincronizacion==null?false:true;
                    aux.FechaModificacion = fecha;
                    aux.MovId = item.MovId;
                    lista.Add(aux);
                    item.Estatus = "REVISADO";
                }
                else if (netsuite.result.Any(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadNoRecibida && x.from_location.Equals("LOGISTICA : 31-CCI Recibo") && x.trandate.Equals(fecha.ToString("dd/M/yyyy"))) && !item.Estatus.Equals("REVISADO"))
                {
                    ReporteInterfazReciboModelDocumentos nAux = netsuite.result.Where(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadNoRecibida && x.from_location.Equals("LOGISTICA : 31-CCI Recibo") && x.trandate.Equals(fecha.ToString("dd/M/yyyy"))).FirstOrDefault();
                    aux.trandate = nAux.trandate;
                    aux.tranid = nAux.tranid;
                    aux.to_location = nAux.to_location;
                    aux.quantity = nAux.quantity;
                    aux.item = nAux.item;
                    aux.from_location = nAux.from_location;
                    aux.Articulo = item.Articulo;
                    aux.CantidadNoRecibida = (int)item.CantidadNoRecibida;
                    aux.EstatusSincronizacion = item.EstatusSincronizacion != 0;
                    aux.FechaModificacion = fecha;
                    aux.MovId = item.MovId;
                    lista.Add(aux);
                    item.Estatus = "REVISADO";
                }
                else
                {
                    aux.Articulo = item.Articulo;
                    aux.CantidadNoRecibida = item.CantidadNoRecibida == null ? 0 : (int)item.CantidadNoRecibida;
                    aux.CantidadRecibida = item.CantidadRecibida == null ? 0 : (int)item.CantidadRecibida;
                    aux.EstatusSincronizacion = item.EstatusSincronizacion != 0;
                    aux.FechaModificacion = fecha;
                    aux.MovId = item.MovId;
                    lista.Add(aux);
                    item.Estatus = "REVISADO";
                }
            }
            return lista;

        }



        public List<ReporteInterfazReciboMix> revisaXMov(ReporteInterfazReciboModel netsuite, List<EntradaCompraEstatus_Out> wms,string MOV,string Location)
        {
            List<ReporteInterfazReciboMix> lista = new List<ReporteInterfazReciboMix>();

            foreach (var item in wms.Where(x => x.Mov.Equals(MOV)))
            {
                DateTime fecha = Convert.ToDateTime(item.FechaModificacion);
                ReporteInterfazReciboMix aux = new ReporteInterfazReciboMix();
                if (netsuite.result.Any(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadRecibida && x.from_location.Equals(Location) && x.trandate.Equals(fecha.ToString("d/M/yyyy"))) && !item.Estatus.Equals("REVISADO"))
                {
                    ReporteInterfazReciboModelDocumentos nAux = netsuite.result.Where(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadRecibida && x.from_location.Equals(Location) && x.trandate.Equals(fecha.ToString("d/M/yyyy"))).FirstOrDefault();
                    aux.trandate = nAux.trandate;
                    aux.tranid = nAux.tranid;
                    aux.to_location = nAux.to_location;
                    aux.quantity = nAux.quantity;
                    aux.item = nAux.item;
                    aux.from_location = nAux.from_location;
                    aux.Articulo = item.Articulo;
                    aux.CantidadRecibida = (int)item.CantidadRecibida;
                    aux.EstatusSincronizacion = item.EstatusSincronizacion == 0 ? false : item.EstatusSincronizacion == null ? false : true;
                    aux.FechaModificacion = fecha;
                    aux.MovId = item.MovId;
                    aux.mov = item.Mov;
                    lista.Add(aux);
                    item.Estatus = "REVISADO";
                }
                else if (netsuite.result.Any(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadNoRecibida && x.from_location.Equals(Location) && x.trandate.Equals(fecha.ToString("d/M/yyyy"))) && !item.Estatus.Equals("REVISADO"))
                {
                    ReporteInterfazReciboModelDocumentos nAux = netsuite.result.Where(x => x.item.Equals(item.Articulo) && x.quantity == item.CantidadNoRecibida && x.from_location.Equals(Location) && x.trandate.Equals(fecha.ToString("d/M/yyyy"))).FirstOrDefault();
                    aux.trandate = nAux.trandate;
                    aux.tranid = nAux.tranid;
                    aux.to_location = nAux.to_location;
                    aux.quantity = nAux.quantity;
                    aux.item = nAux.item;
                    aux.from_location = nAux.from_location;
                    aux.Articulo = item.Articulo;
                    aux.CantidadNoRecibida = (int)item.CantidadNoRecibida;
                    aux.EstatusSincronizacion = item.EstatusSincronizacion != 0;
                    aux.FechaModificacion = fecha;
                    aux.MovId = item.MovId;
                    aux.mov = item.Mov;
                    lista.Add(aux);
                    item.Estatus = "REVISADO";
                }
                else
                {
                    aux.Articulo = item.Articulo;
                    aux.CantidadNoRecibida = item.CantidadNoRecibida == null ? 0 : (int)item.CantidadNoRecibida;
                    aux.CantidadRecibida = item.CantidadRecibida == null ? 0 : (int)item.CantidadRecibida;
                    aux.EstatusSincronizacion = item.EstatusSincronizacion != 0;
                    aux.FechaModificacion = fecha;
                    aux.MovId = item.MovId;
                    aux.mov = item.Mov;
                    lista.Add(aux);
                    item.Estatus = "REVISADO";
                }
            }
            return lista;

        }

        public ReporteInterfazReciboModel cargaDatosNetsuite(string FechaIni)
        {
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/Inventory/GetInventoryTransferHistory?FechaIni=" + FechaIni, SAI_NETSUITE.Properties.Resources.token);
            ReporteInterfazReciboModel rirm = JsonConvert.DeserializeObject<ReporteInterfazReciboModel>(json);
            return rirm;
        }


        public List<EntradaCompraEstatus_Out> cargaDatosWMS(string FechaIni)
        {


            DateTime fechaIni = Convert.ToDateTime(FechaIni);
            DateTime fechaFin = fechaIni.AddDays(1);
            INDAR_INACTIONWMSEntities ctx = new INDAR_INACTIONWMSEntities();

            var resultado = (from i in ctx.EntradaCompraEstatus_Out where (i.FechaModificacion >= fechaIni && i.FechaModificacion < fechaFin) select i).ToList();
            return resultado.ToList();


        }



    }
}
