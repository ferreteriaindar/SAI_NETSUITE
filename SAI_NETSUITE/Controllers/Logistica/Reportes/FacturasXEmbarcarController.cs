using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Logistica.Reportes
{
    class FacturasXEmbarcarController
    {

        public List<FacturasXEmbarcarModel> regresaEmbarques(string fechaIni, string fechaFin)
        {
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            string query = "exec  IndarWms.dbo.spFacturaEmbarqueResponsableDias '" + fechaIni + "','" + fechaFin + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            da.SelectCommand.CommandTimeout = 120;
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<FacturasXEmbarcarModel> lista = new List<FacturasXEmbarcarModel>();
            /*  lista = (from DataRow dr in ds.Tables[0].Rows
                       select new FacturasXEmbarcarModel()
                       {
                           Chofer=dr["Chofer"].ToString(),
                           Cliente=dr["Cliente"].ToString(),
                           ComentarioEmbarque=dr["ComentarioEmbarque"].ToString(),
                           ComentarioFactura=dr["ComentarioFactura"].ToString(),
                           CondicionPago=dr["CondicionPago"].ToString(),
                           Consolidado=dr["Consolidado"].ToString(),
                           Cotizacion=dr["Consolidado"].ToString(),
                           Embarque=dr["Embarque"]==null,
                           EstadoEmbarque=dr["EstadoEmbarque"].ToString()


                       }

                      ).ToList();*/
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                FacturasXEmbarcarModel fxem = new FacturasXEmbarcarModel();
                fxem.Chofer = dr["Chofer"].ToString();
                fxem.Cliente = dr["Cliente"].ToString();
                fxem.ComentarioEmbarque = dr["ComentarioEmbarque"].ToString();
                fxem.ComentarioFactura = dr["ComentarioFactura"].ToString();
                fxem.CondicionPago = dr["CondicionPago"].ToString();
                fxem.Consolidado = dr["Consolidado"].ToString();
                fxem.Cotizacion = dr["Consolidado"].ToString();
                fxem.Embarque = dr.Field<int?>("Embarque");
                fxem.EstadoEmbarque = dr["EstadoEmbarque"].ToString();
                fxem.EstadoFactura = dr["EstadoFactura"].ToString();
                fxem.Factura = dr.Field<int>("Factura");
                fxem.FechaEmbarque = dr.Field<DateTime?>("FechaEmbarque");
                fxem.FechaEntrega = dr["FechaEntrega"].ToString().Replace("a.m.", "a. m.").Replace("a.m", "a. m.");
                fxem.FechaFactura = dr.Field<DateTime?>("FechaFactura");
                fxem.FechaFleteXConfirmar = dr.Field<DateTime?>("FechaFleteXConfirmar");
                fxem.Fletera = dr["Fletera"].ToString();
                fxem.FormaEnvio = dr["FormaEnvio"].ToString();
                fxem.Importe = dr.Field<decimal?>("Importe");
                fxem.Movimiento = dr["Movimiento"].ToString();
                fxem.Nota = dr["Nota"].ToString();
                fxem.Pedido = dr.Field<int?>("Pedido");
                fxem.usuario = dr["usuario"].ToString();
                fxem.Ubicacion = dr["Ubicacion"].ToString();
                fxem.totalEmbarques = dr["totalEmbarques"].ToString();

                DateTime? fechaEntrega, FechaEmbarque, FechaFactura, FechaFleteXConfirmar;
               
               fechaEntrega = fxem.FechaEntrega.Equals("") || fxem.FechaEntrega.Equals(" ") ? null :(DateTime?) Convert.ToDateTime(fxem.FechaEntrega.Replace("p.m.", "p. m.").Replace("a.m", "a. m."));  ///dr.Field<DateTime?>("FechaEntrega")             
                FechaFleteXConfirmar= dr.Field<DateTime?>("FechaFleteXConfirmar");
                FechaEmbarque = dr.Field<DateTime?>("FechaEmbarque");
                FechaFactura = dr.Field<DateTime?>("FechaFactura");


                /* fxem.Dias = dr["FechaEntrega"].ToString().Equals("") || dr["FechaEntrega"] == null ? (Convert.ToDateTime(dr["FechaFleteXConfirmar"].ToString()) - DateTime.Now).Days :
                             dr["FechaFleteXConfirmar"].ToString().Equals("") || dr["FechaFleteXConfirmar"] == null ? (Convert.ToDateTime(dr["FechaEmbarque"].ToString()) - DateTime.Now).Days :
                             dr["FechaEmbarque"].ToString().Equals("") || dr["FechaEmbarque"] == null ? (Convert.ToDateTime(dr["FechaFactura"].ToString()) - DateTime.Now).Days : (Convert.ToDateTime(dr["FechaEntrega"].ToString()) - DateTime.Now).Days;
                 */

                fxem.Dias = fechaEntrega == null ? (DateTime.Now- (FechaFleteXConfirmar == null ? (FechaEmbarque == null ? FechaFactura : FechaEmbarque) : FechaFleteXConfirmar) ).Value.Days : ( DateTime.Now- fechaEntrega ).Value.Days;
                
                
                lista.Add(fxem);
                                               
            };


            List<TraduccionFormaEnvioXEmbarcar> listaFormaEnvio = inicializaTablaFormaEnvio();
            List<UsuarioReporteXEmbarcar> usuario = inicializaTablaUsuario();
            List<TraduccionEstatusEmbarque> estatusEmbarque = InicializatraduccionEstatusEmbarques();
            var listaDiasPermitidos = new IndarnegEntities().DiasReporteXEmbarcar.Select(x => x).ToList();
            //BUSCAR  EL RESPONSABLE  --DIAS PERMITIDOS --- ESTATUS FINAL
            foreach (var row in lista)
            {
                string factura = row.Factura.ToString();
                ////////BUSCAR  EL RESPONSABLE/////////////////  INICIO
                if (row.Ubicacion.Contains("161-Refacturaciones") || row.Ubicacion.Contains("CREDI"))
                    row.Responsable = "CREDITO Y COBRANZA";
                if (row.Embarque.Equals("")|| row.Embarque.Equals(" ")||row.Embarque==null) // NO TIENE EMBARQUE
                {
                    row.Responsable = listaFormaEnvio.
                                    Where(x => x.formaEnvio.Equals(row.FormaEnvio)).
                                    Select(x => x .responsable).FirstOrDefault();

                }
                else
                {
                    if (row.EstadoFactura.Equals("TRANSITO"))
                        row.Responsable = usuario.
                                        Where(x => x.usuario.Equals(row.usuario)).
                                        Select(x => x.area).FirstOrDefault();
                    if (!row.EstadoFactura.Equals("TRANSITO"))
                        row.Responsable = estatusEmbarque.
                                        Where(x => x.EstadoEmbarque.Equals(row.EstadoFactura))
                                        .Select(x => x.responsable).FirstOrDefault();
                }
                ////////BUSCAR  EL RESPONSABLE/////////////////  FIN

                //////// DIAS PERMITIDOS /////////////////////  INICIO
               
                if (row.Embarque == null)
                    row.DiasPermitidos = listaDiasPermitidos.ToList().Where(x => x.Estado.Equals("SINEMBARQUE") && x.Responsable.Equals(row.Responsable)).Select(x => x.Dias).FirstOrDefault();
                 else
                       row.DiasPermitidos = listaDiasPermitidos.ToList().Where(x => x.Estado.Equals(row.EstadoFactura) && x.Responsable.Equals(row.Responsable)).Select(x => x.Dias).FirstOrDefault();

                //////// DIAS PERMITIDOS /////////////////////  FIN



            }



            return lista;

        }







        public List<UsuarioReporteXEmbarcar> inicializaTablaUsuario()
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                var lista = ctx.UsuarioReporteXEmbarcar.Select(i => i).ToList();
                return lista.ToList();
            }


        }
        public List<TraduccionFormaEnvioXEmbarcar> inicializaTablaFormaEnvio()
        {
            List<TraduccionFormaEnvioXEmbarcar> lista = new List<TraduccionFormaEnvioXEmbarcar>();

            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CCI FORANEO", responsable = "DISTRIBUCION" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CCI LOCAL", responsable = "DISTRIBUCION" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CCI VENDEDOR ENTREGA", responsable = "CLIENTE RECOGE" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "TAUBER", responsable = "DISTRIBUCION" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CCI FLETERA", responsable = "EMBARQUES" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "GDL07 CLIENTE RECOGE", responsable = "DISTRIBUCION" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "AGS01 OFICINA AGUASCALIENTES", responsable = "EMBARQUES" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CCI CLIENTE RECOGE", responsable = "CLIENTE RECOGE" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "GDL 07 VENDEDOR ENTREGA", responsable = "DISTRIBUCION" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CCI CLIENTE ESTA AQUI", responsable = "CLIENTE RECOGE" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "QRO03 OFICINA QRO", responsable = "EMBARQUES" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CCI PEDIDO DE EMPLEADO", responsable = "CLIENTE RECOGE" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "MLM05 OFICINA MORELIA", responsable = "EMBARQUES" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "TRC06 OFICINA TORREON", responsable = "EMBARQUES" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "CUL04 OFICINA CULIACAN", responsable = "EMBARQUES" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "BJX02 OFICINA LEON", responsable = "EMBARQUES" });
            lista.Add(new TraduccionFormaEnvioXEmbarcar() { formaEnvio = "MTY08 OFICINA MONTERREY", responsable = "EMBARQUES" });
            return lista;

        }


        public List<TraduccionEstatusEmbarque> InicializatraduccionEstatusEmbarques()
        {
            List<TraduccionEstatusEmbarque> lista = new List<TraduccionEstatusEmbarque>();
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "Flete X Confirmar", responsable = "POSTVENTA" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE Of León", responsable = "OF LEON" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CC León", responsable = "OF LEON" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE Of Querétaro", responsable = "OF QRO" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CC Querétaro", responsable = "OF QRO" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE Of Culiacán", responsable = "OF CULIACAN" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CC Culiacán", responsable = "OF CULIACAN" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE Of Morelia", responsable = "OF MORELIA" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CC Morelia", responsable = "OF MORELIA" });
            
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE Of Aguascalientes", responsable = "OF AGS" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CC Aguascalientes", responsable = "OF AGS" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE Of Monterrey", responsable = "OF MTY" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CC Monterrey", responsable = "OF MTY" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE Of Torreón", responsable = "OF TORR" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CC Torreón", responsable = "OF TORR" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "TRANSITO", responsable = "1" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "CANCELADO", responsable = "POSTVENTA" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE CCI", responsable = "DISTRIBUCION" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE", responsable = "1" });
            lista.Add(new TraduccionEstatusEmbarque() { EstadoEmbarque = "DESEMBARQUE GDL07", responsable = "GDL07" });
            return lista;

        }

    }


    public class TraduccionFormaEnvioXEmbarcar

    {

        public string formaEnvio { get; set; }
        public  string  responsable { get; set; }
    }

    public class TraduccionEstatusEmbarque
    {
        public string EstadoEmbarque { get; set; }
        public string responsable { get; set; }
    }

}
