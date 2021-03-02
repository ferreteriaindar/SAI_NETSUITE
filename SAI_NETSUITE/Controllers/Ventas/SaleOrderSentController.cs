using Newtonsoft.Json;
using SAI_NETSUITE.IWS;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Ventas
{
    class SaleOrderSentController
    {
       public List<Models.Catalogos.CustomerListCombo> listaCTE;
       public List<Models.Catalogos.LocationListCombo> listaLoc;
       public List<Models.Catalogos.FormaEnvioListCombo> listaFormaEnvio;
       public List<Models.Catalogos.RutaListCombo> listaRuta;
       public List<Models.Catalogos.EventosListCombo> listaEvento;
        public List<Models.Catalogos.ListaPaqueteria> listaPaqueterias;
       public string listaPrecio;
        public SaleOrderSentController()
        { 
        
        }



        public void getCustomersList()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
              // var cte =   from  x in ctx.Customers.Select(x => new { x.companyId, x.name }).ToList();
                var cte = from x in ctx.Customers  select new Models.Catalogos.CustomerListCombo() { name=x.name, companyid = x.companyId, id=x.internalid};
                listaCTE= cte.ToList();
                var lo = from x in ctx.Locations select new Models.Catalogos.LocationListCombo() { NAME = x.NAME, LOCATION_ID = x.LOCATION_ID };
                listaLoc=  lo.ToList();
                var fe = from x in ctx.FormaEnvio.Where(s => s.isInactive == false) select new Models.Catalogos.FormaEnvioListCombo() { LIST_ID = x.LIST_ID, LIST_ITEM_NAME = x.LIST_ITEM_NAME };
                listaFormaEnvio= fe.ToList();
                var rl = from x in ctx.Ruta.Where(s => s.isInactive == false) select new Models.Catalogos.RutaListCombo() { LIST_ID = x.LIST_ID, LIST_ITEM_NAME = x.LIST_ITEM_NAME };
                listaRuta= rl.ToList();
                var evento = from x in ctx.Eventos select new Models.Catalogos.EventosListCombo() { LIST_ID = x.LIST_ID, LIST_ITEM_NAME = x.LIST_ITEM_NAME };
                listaEvento = evento.ToList();

                var pa = from x in ctx.Paqueteria.Where(s => s.isInactive == false) select new Models.Catalogos.ListaPaqueteria() { LIST_ID = x.LIST_ID, LIST_ITEM_NAME = x.LIST_ITEM_NAME };
                listaPaqueterias = pa.ToList();

            }
        }

    


        public List<Models.Catalogos.AdressListCombo> getAddressLis(int id)
        {
            using (IWSEntities ctx = new IWSEntities())
            {

                var ad = from x in ctx.Address.Where(s=> s.entity_id==id)  select new Models.Catalogos.AdressListCombo() { id = x.addressID, direccion = x.addr1 + " " + x.addr2 + " Cp:" + x.postalCode + " " + x.city + " " + x.state, defaultbill = x.defaultbilling.Value, defaultship = x.defaultshipping.Value };
                return ad.ToList();
            }
        }


      

     


        public List<Models.Catalogos.ItemsListCombo> getItemsList()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var i = from x in ctx.Items select new Models.Catalogos.ItemsListCombo() { itemid = x.itemid, displayname = x.displayname };
                return i.ToList();
            
            }
        
        }


        public int regresaDisponible(string articulo)
        {
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = @"select  sum(Cantidad) as disponible from INDAR_INACTIONWMS.dbo.Unitario U
                            LEFT JOIN  INDAR_INACTIONWMS.dbo.UnitarioLocalidad UL on U.IdUnitario=UL.IdUnitario
                            LEFT JOIN  INDAR_INACTIONWMS.dbo.Localidad L on UL.IdLocalidad=L.IdLocalidad
                            left join INDAR_INACTIONWMS.dbo.Area A on L.IdArea=A.IdArea
                            left join INDAR_INACTIONWMS.dbo.Producto P on U.IdProducto=P.IdProducto
                            left join INDAR_INACTIONWMS.dbo.Estilo E on P.IdEstilo=E.IdEstilo
                            WHERE E.Clave='"+articulo+@"' and A.IdArea in (32,33,34,35,36,37,38,39,40,41,50,52)
                            group by E.Clave";
            Console.WriteLine(cmd.CommandText);
                        object userNameObj = cmd.ExecuteScalar();
            var disponible="" ;
            if (userNameObj != null)
                disponible = userNameObj.ToString();
            else disponible = "0";
         //   var disponible = cmd.ExecuteScalar().ToString();
            
            return Convert.ToInt16(disponible.ToString());

        
        }

        public string regresaIDItem(string art)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var i = (from x in ctx.Items 
                         where x.itemid.Equals(art) 
                         select x.id).FirstOrDefault();
                return i.FirstOrDefault().ToString();

            }
        
        }

      

        public DataTable regresaPedidoSeparadoParte1(DataTable rows)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Articulo", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Zona", typeof(string));
            dt.Columns.Add("CategoriaArt", typeof(string));
            dt.Columns.Add("CategoriaCte", typeof(string));
            dt.Columns.Add("Almacen", typeof(string));
            dt.Columns.Add("Proveedor", typeof(string));
            dt.Columns.Add("Familia", typeof(string));
            dt.Columns.Add("DescNormal", typeof(decimal));
            dt.Columns.Add("DescPlazo", typeof(string));
            dt.Columns.Add("DescAplicado", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Promo", typeof(decimal));
            dt.Columns.Add("Unitario", typeof(decimal));
            dt.Columns.Add("Importe", typeof(decimal));

            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
           
            for (int i = 0; i < rows.Rows.Count; i++)
            {
                 cmd.CommandText = @"exec INDGDLSQL01.Indar.dbo.sp_DescCatCte2 '" + rows.Rows[i][0].ToString() + "','" + rows.Rows[i][1].ToString() + "'";
                 Console.WriteLine(cmd.CommandText);
                 SqlDataReader sdr = cmd.ExecuteReader();
                 sdr.Read();
                 if (sdr.HasRows)
                 {
                     Console.WriteLine(sdr.GetValue(9).ToString());
                     string categoriaArt = "0", Proveedor = "0", Familia = "0";
                      if (!sdr.IsDBNull(2))
                          categoriaArt = sdr.GetValue(2).ToString();
                      if (!sdr.IsDBNull(5))
                          Proveedor = sdr.GetValue(5).ToString();
                      if (!sdr.IsDBNull(6))
                          Familia = sdr.GetValue(6).ToString();
                  
                     dt.Rows.Add(sdr.GetValue(0).ToString(), sdr.GetValue(1).ToString(), categoriaArt, sdr.GetValue(3).ToString(), sdr.GetValue(4).ToString(), Proveedor, Familia, sdr.GetValue(7).ToString(), sdr.GetValue(8).ToString(), sdr.GetValue(9).ToString(),sdr.GetValue(10).ToString());
                 }

                 sdr.Close();
                 sdr.Dispose();
            }

            return dt;

        }


        public DataSet regresaPrimerSplit(UnsplitSaleOrderModel un,Token token)
        {
            Connection conn = new Connection();
            string json = JsonConvert.SerializeObject(un);
            var resultado = conn.POST("api/SaleOrder/SplitSaleOrder", json, token.token);
            Console.WriteLine(resultado.ToString());
            ResultSplitSaleOrderModel rsom = JsonConvert.DeserializeObject<ResultSplitSaleOrderModel>(resultado);
            List<SplitSaleOrderModel> som = rsom.Result;
           /* DataTable dt = new DataTable();

            dt.Columns.Add("CustomerId", typeof(int));
            dt.Columns.Add("Discount", typeof(int));
            dt.Columns.Add("PaymentTerm", typeof(int));
            dt.Columns.Add("GroupName", typeof(string));
            dt.Columns.Add("Item", typeof(int));
            dt.Columns.Add("quantity", typeof(int));
            dt.Columns.Add("inventoryQty", typeof(int));               
            //Columnas del gridAnterior para traerme los datos
            dt.Columns.Add("Articulo", typeof(string));
           // dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("descuentoArt", typeof(double));
            dt.Columns.Add("precio", typeof(double));

            foreach (var pedidos in som)
            {
                int customerId = pedidos.CustomerId;
                int Discount = pedidos.Discount;
                string PaymentTerm = pedidos.PaymentTerm;
                string GroupName = pedidos.GroupName;
                foreach (var art in pedidos.items)
                {
                    dt.Rows.Add(customerId, Discount, PaymentTerm, GroupName, art.itemId, art.quantity);
                }

            }
            return dt;*/

            DataTable dtCa = new DataTable();
            dtCa.TableName="head";
            dtCa.Columns.Add("id", typeof(int));
            dtCa.Columns.Add("CustomerId", typeof(int));
            dtCa.Columns.Add("Discount", typeof(int));
            dtCa.Columns.Add("PaymentTerm", typeof(int));
            dtCa.Columns.Add("GroupName", typeof(string));

            DataTable dtBo = new DataTable();
            dtBo.TableName = "body";

            dtBo.Columns.Add("id", typeof(int));
            dtBo.Columns.Add("Item", typeof(int));
            dtBo.Columns.Add("quantity", typeof(int));
            dtBo.Columns.Add("inventoryQty", typeof(int));
            dtBo.Columns.Add("Articulo", typeof(string));
            dtBo.Columns.Add("descuentoArt", typeof(double));
            dtBo.Columns.Add("precio", typeof(double));
            dtBo.Columns.Add("iva", typeof(double));
            dtBo.Columns.Add("pp", typeof(double));

            DataColumn keyColumn = dtCa.Columns["id"];
            DataColumn foreignKeyColumn = dtBo.Columns["id"];
            DataSet ds = new DataSet();
            ds.Tables.Add(dtCa);
            ds.Tables.Add(dtBo);

            ds.Relations.Add("DETALLE", keyColumn, foreignKeyColumn);

            int id=0;
            foreach (var pedidos in som)
            {
                id++;
                dtCa.Rows.Add(id, pedidos.CustomerId, pedidos.Discount, pedidos.PaymentTerm, pedidos.GroupName);
                foreach (var item in pedidos.items)
                {
                    dtBo.Rows.Add(id,item.itemId, item.quantity, item.inventoryQty,"",0,0,0,pedidos.Discount);
                }

            }

            return ds;

        }

    }
}
