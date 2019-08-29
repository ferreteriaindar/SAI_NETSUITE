using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.Ventas;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using SAI_NETSUITE.Models.Transaccion;
using Newtonsoft.Json;
using SAI_NETSUITE.IWS;

namespace SAI_NETSUITE.Views.Ventas
{

    /// <summary>
    /// prueba
    /// </summary>
    public partial class SaleOrderSentVista : DevExpress.XtraEditors.XtraUserControl
    {

        Token token;
        DataTable dtGrid = new DataTable();
        DataTable dtItem = new DataTable();
        string priceLevel;
        List<ItemInfobyCode> ListaItem;
        public SaleOrderSentVista(Token token)
        {
            this.token = token;
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            InitializeComponent();
        }

        private void SaleOrderSentVista_Load(object sender, EventArgs e)
        {
            
            cargaClientes();
            ListaItem = new List<ItemInfobyCode>();
            InicializarGrid();
            base.OnLoad(e);
            SplashScreenManager.CloseForm();
       
        }

        public void cargaClientes()
        {
            SaleOrderSentController sosc = new SaleOrderSentController();
            sosc.getCustomersList();
          //  List<Models.Catalogos.CustomerListCombo> lista = sosc.getCustomersList();
          //  Console.WriteLine(lista.Count);
            
            searchListaCliente.Properties.ValueMember = "companyid";
            searchListaCliente.Properties.DisplayMember = "companyid";
            searchListaCliente.Properties.DataSource = sosc.listaCTE; // lista;

            searchAlmacen.Properties.ValueMember = "LOCATION_ID";
            searchAlmacen.Properties.DisplayMember = "LOCATION_ID";
            searchAlmacen.Properties.DataSource = sosc.listaLoc;

            searchFormaEnvio.Properties.DataSource = sosc.listaFormaEnvio;
            searchFormaEnvio.Properties.ValueMember = "LIST_ID";
            searchFormaEnvio.Properties.DisplayMember = "LIST_ITEM_NAME";


            searchFletera.Properties.DataSource = sosc.listaRuta;
            searchFletera.Properties.ValueMember = "LIST_ID";
            searchFletera.Properties.DisplayMember = "LIST_ITEM_NAME";

            searchEvento.Properties.DataSource = sosc.listaEvento;
            searchEvento.Properties.ValueMember = "LIST_ID";
            searchEvento.Properties.DisplayMember = "LIST_ITEM_NAME";

           
        }

      

        public void cargaAddress()
        {
            SaleOrderSentController sosc = new SaleOrderSentController();
            List<Models.Catalogos.AdressListCombo> lista = sosc.getAddressLis(Convert.ToInt32(searchListaCliente.Properties.View.GetFocusedRowCellValue("id").ToString()));
            searchFacturaDIR.Properties.ValueMember = "id";
            searchFacturaDIR.Properties.DisplayMember = "direccion";
            searchFacturaDIR.Properties.DataSource = lista.Where(li => li.defaultbill == true).ToList();

            searchEnvioDir.Properties.ValueMember = "id";
            searchEnvioDir.Properties.DisplayMember = "direccion";
            searchEnvioDir.Properties.DataSource = lista.Where(li => li.defaultship == true).ToList();


            searchFacturaDIR.EditValue = lista.Where(li => li.defaultbill == true).Select(x => x.id).ToList().FirstOrDefault();
            searchEnvioDir.EditValue = lista.Where(li => li.defaultship == true).Select(x => x.id).ToList().FirstOrDefault();



        }


    



        private void searchListaCliente_EditValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("entra");
            Console.WriteLine(searchListaCliente.EditValue.ToString());
            labelNombreCliente.Text = "Cliente: " + searchListaCliente.Properties.View.GetFocusedRowCellValue("name");
            cargaAddress();
            using (IWSEntities ctx = new IWSEntities())
            {
                var formaenvio = from x in ctx.Customers   .Where(s=> s.companyId==searchListaCliente.EditValue.ToString()) select x.shippingWayId;
                var ruta = from x in ctx.Customers.Where(s => s.companyId == searchListaCliente.EditValue.ToString()) select x.Route;
                searchFletera.EditValue = ruta.FirstOrDefault().ToString();
                searchFormaEnvio.EditValue = formaenvio.FirstOrDefault().ToString();
                Console.WriteLine("Formaenvio" + formaenvio.FirstOrDefault().ToString());
                labelPrecio.Text = (from x in ctx.Customers join x2 in ctx.ListaPrecios on x.PriceList equals x2.price_type_id where (x.companyId == searchListaCliente.EditValue.ToString()) select x2.name).First().ToString();
               
                priceLevel = (from x in ctx.Customers join x2 in ctx.ListaPrecios on x.PriceList equals x2.price_type_id where (x.companyId == searchListaCliente.EditValue.ToString()) select x2.price_type_id).First().ToString();
            }
            searchAlmacen.EditValue = 1;

            
        }


        public void InicializarGrid()
        {/*
            SaleOrderSentController sosc = new SaleOrderSentController();
            DataTable dt = new DataTable();
            dt.Columns.Add("itemid", typeof(string));
            dt.Columns.Add("displayname",typeof(string));
            List<Models.Catalogos.ItemsListCombo> lista = sosc.getItemsList();
            foreach (var item in lista)
            {
                dt.Rows.Add(item.itemid,item.displayname);
            }
            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.ValueMember = "itemid";
            repositoryItemSearchLookUpEdit1.DisplayMember = "itemid";
            */
            
            dtGrid.Columns.Add("articulo", typeof(string));
            dtGrid.Columns.Add("disponible", typeof(int));
            dtGrid.Columns.Add("cantidad", typeof(int));
            gridControl1.DataSource = dtGrid;
           // gridViewMain.AddNewRow();


            dtItem.Columns.Add("internalid", typeof(Int32));
            dtItem.Columns.Add("code", typeof(string));
            dtItem.Columns.Add("disponible", typeof(Int32));
            dtItem.Columns.Add("cantidad", typeof(Int32));
            dtItem.Columns.Add("multiplo", typeof(Int32));
            dtItem.Columns.Add("price", typeof(double));
            dtItem.Columns.Add("promo", typeof(double));
            dtItem.Columns.Add("iva", typeof(double));



        
        }

        private void repositoryItemSearchLookUpEdit1View_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void repositoryItemSearchLookUpEdit1View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
        }

        private void repositoryItemSearchLookUpEdit1View_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            MessageBox.Show("BUSCO aRTICULOS");
        }

        private void gridViewMain_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name.Equals("colCantidad"))
            {
              var articulo= gridViewMain.GetFocusedRowCellValue(colarticulo).ToString();
              var cantidad = gridViewMain.GetFocusedRowCellValue(colCantidad).ToString();
              for (int i = 0; i < dtItem.Rows.Count; i++)
              {
                  if (dtItem.Rows[i][1].Equals(articulo))
                  {
                      dtItem.Rows[i][6] = Convert.ToDouble(regresaPromoPorCiento(articulo, Convert.ToDouble(cantidad)));
                      dtItem.Rows[i][3]=Convert.ToDouble(cantidad);
                  }
              }
             // dtItem.Rows[i][6] = Convert.ToDouble(regresaPromoPorCiento(gv.GetRowCellValue(i, "Articulo").ToString(), Convert.ToDouble(dtItem.Rows[i][4].ToString())));

              Console.WriteLine(articulo.ToString());
            }
            gridViewMain.RefreshData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK && dxValidationProvider1.Validate()) // Test result.
            {
                
                try
                {
                    DevExpress.DataAccess.Excel.ExcelDataSource myExcelSource = new DevExpress.DataAccess.Excel.ExcelDataSource();
                    myExcelSource.FileName = openFileDialog1.FileName;
                    ExcelWorksheetSettings worksheetSettings = new ExcelWorksheetSettings("Hoja1", "A:B");
                    myExcelSource.SourceOptions = new ExcelSourceOptions(worksheetSettings);
                    myExcelSource.SourceOptions.SkipEmptyRows = true;
                    myExcelSource.SourceOptions.UseFirstRowAsHeader = true;
                    myExcelSource.Fill();
                    
                    DevExpress.XtraGrid.GridControl gd = new DevExpress.XtraGrid.GridControl();
                    gd.BindingContext = new System.Windows.Forms.BindingContext();
                    gd.DataSource = myExcelSource;
                    GridView gv = new GridView(gd);
                    gd.MainView = gv;
                    gd.RefreshDataSource();
                    gv.PopulateColumns();
                

                     DataTable rows = new DataTable();
            rows.Columns.Add("Articulo", typeof(string));
            rows.Columns.Add("Cliente", typeof(string));
         /*   for (int i = 0; i < gv.RowCount; i++)
            {

                rows.Rows.Add(gv.GetRowCellValue(i, "PRODUCTO").ToString(), searchListaCliente.Properties.GetDisplayText(searchListaCliente.EditValue));
            }

            gridControl2.DataSource = new SaleOrderSentController().regresaPedidoSeparadoParte1(rows);
                    */
                        for (int i = 0; i < gv.RowCount; i++)
                        {
                            ListaItem.Add(regresaItem(gv.GetRowCellValue(i, "Articulo").ToString(), searchListaCliente.Properties.View.GetFocusedRowCellValue("id").ToString()));

                        }

                    foreach(var item in  ListaItem)
                    {
                        int iva=0;
                        if (item.taxId == 1)
                            iva = 16;
                        dtItem.Rows.Add(item.internalid, item.code, item.availableQty, 0, item.saleAmount, item.price, 0,iva);
                    }
                    //for para agregar la cantidad
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        dtItem.Rows[i][3] = gv.GetRowCellValue(i, "Cantidad").ToString();
                        dtItem.Rows[i][6] = Convert.ToDouble(regresaPromoPorCiento(gv.GetRowCellValue(i, "Articulo").ToString(), Convert.ToDouble(dtItem.Rows[i]["cantidad"].ToString())));
                    }
                    Console.WriteLine(dtItem.Rows[0][4].ToString());
                    Console.WriteLine("ARTICULO"+dtItem.Rows[0][1].ToString()+"PROMO"+dtItem.Rows[0][5].ToString());
                    gridControl1.DataSource = dtItem;
                   

                    
                                       
                
                }
                catch (IOException)
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                   
                    args.Caption = "ERROR ARCHIVO";
                    args.Text = "Error al abrir el archivo de excel, verifica que sea el correcto \n o que no este abierto";
                    args.Buttons = new DialogResult[] { DialogResult.OK};
                    XtraMessageBox.Show(args).ToString();
                }
            }
        }



        public double regresaPromoPorCiento(string articulo, double cantidad)
        {
            List<PromoIndar> lista = new List<PromoIndar>();
            foreach (var item in ListaItem.Where(s=> s.code.ToLower().Equals(articulo)))
            {
                if (item.PromoIndar != null)
                {
                    foreach (var promo in item.PromoIndar)
                    {
                        PromoIndar Pi = promo;
                        lista.Add(Pi);
                    }
                }
                else
                {
                    PromoIndar pitemp = new PromoIndar();
                            pitemp.Discount=0;
                            lista.Add(pitemp);
                }
            }

            double descuento = lista.Where(s => s.Min <= cantidad && s.Max >= cantidad).Select(s => s.Discount).FirstOrDefault();
            Console.WriteLine("Descuento",descuento+"*");
         return descuento;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate() && gridViewMain.RowCount > 0)
            {
                Models.Transaccion.SaleOrder so = new Models.Transaccion.SaleOrder();
                so.idCustomer = searchListaCliente.Properties.View.GetFocusedRowCellValue("id").ToString();
                so.date = DateTime.Now.ToShortDateString();
                so.location = searchAlmacen.EditValue.ToString();
                BillingAddress ba = new BillingAddress();
                ba.id = searchFacturaDIR.EditValue.ToString();
                so.billingAddress = ba;
                ShippingAddress sa = new ShippingAddress();
                sa.id = searchEnvioDir.EditValue.ToString();
                so.shippingAddress = sa;
                //searchFacturaDIR.Properties.View.GetFocusedRowCellValue("id").ToString();
             //   so.billingAddress.id = searchFacturaDIR.Properties.View.GetFocusedRowCellValue("id").ToString();
               // string idbill = searchFacturaDIR.EditValue.ToString();
             //   so.billingAddress.id = idbill;
            //    so.shippingAddress.id = searchEnvioDir.EditValue.ToString();
               // so.typeOrder.id = "5";
                TypeOrder to = new TypeOrder();
                to.txt = "normal";
                to.id = "2";
                so.typeOrder = to;
                so.idWeb = "";
                Department d = new Department();
                d.id = "58";
                d.txt = "10000-ADMINISTRACIÓN : 10100-PROYECTOS ESPECIALES";
             //   so.department.id = "58";
               // so.department.txt = "10000-ADMINISTRACIÓN : 10100-PROYECTOS ESPECIALES";
                so.department = d;
                ShippingWay sw = new ShippingWay();
                sw.id = searchFormaEnvio.EditValue.ToString();
                sw.txt = searchFormaEnvio.Properties.GetDisplayText(searchFormaEnvio.EditValue);
                so.shippingWay = sw;
                Package p = new Package();
                p.id = searchFletera.EditValue.ToString();
                p.txt = searchFletera.Properties.GetDisplayText(searchFletera.EditValue);
                so.package = p;

                List<LineItem> listaArt = new List<LineItem>();
                for (int i = 0; i < gridViewMain.RowCount; i++)
                {
                    LineItem li = new LineItem()
                    {
                        itemId=new SaleOrderSentController().regresaIDItem(gridViewMain.GetRowCellValue(i,colarticulo).ToString()),
                        listPrice=priceLevel,
                        quantity=gridViewMain.GetRowCellValue(i,colCantidad).ToString()
                       
                    };
                    listaArt.Add(li);
                }
                so.lineItems = listaArt;

                string json = JsonConvert.SerializeObject(so);
                Console.WriteLine(json);

            }
        }

        private void btnSepara_Click(object sender, EventArgs e)
        {
            UnsplitSaleOrderModel un = new UnsplitSaleOrderModel();
            un.CustomerId= Convert.ToInt32( searchListaCliente.Properties.View.GetFocusedRowCellValue("id").ToString());
            List<LineItem> listaItem=new List<LineItem>();
            for (int i = 0; i < gridViewMain.RowCount; i++)
			{
			 LineItem l = new LineItem();
                 l.itemId=gridViewMain.GetRowCellValue(i,colInternalId).ToString();
                 l.listPrice=priceLevel;
                 int cantidad = Convert.ToInt32(gridViewMain.GetRowCellValue(i, colCantidad).ToString());
                    int multiplo=Convert.ToInt32(gridViewMain.GetRowCellValue(i,colMultiplo).ToString());
                    Console.WriteLine(cantidad.ToString() + "++++" + multiplo.ToString());
                if(cantidad%multiplo!=0)
                {
                    Console.WriteLine("si entra multiplo");
                    cantidad = cantidad + (multiplo - cantidad % multiplo);
                }
                Console.WriteLine(cantidad.ToString());
                l.quantity = cantidad.ToString(); //gridViewMain.GetRowCellValue(i,colCantidad).ToString();

                listaItem.Add(l);

			}
            un.items=listaItem;

           SaleOrderSentController ssc = new SaleOrderSentController();
          /*  DataTable dt = ssc.regresaPrimerSplit(un, token);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dtItem.Rows.Count; j++)
                {
                    Console.WriteLine(dt.Rows[i][4].ToString() + "==" + dtItem.Rows[j][0].ToString());
                    if (dt.Rows[i][4].ToString().Equals(dtItem.Rows[j][0].ToString()))
                    {
                        Console.WriteLine("Igual");
                        dt.Rows[i]["Articulo"] = dtItem.Rows[j]["code"];
                        dt.Rows[i]["precio"] = dtItem.Rows[j]["price"];
                        dt.Rows[i]["descuentoArt"] = dtItem.Rows[j]["promo"];
                    }
                }
            }*/

           DataSet ds = ssc.regresaPrimerSplit(un, token);
           for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
           {
               for (int J = 0; J < dtItem.Rows.Count; J++)
               {
                   if (ds.Tables[1].Rows[i]["Item"].ToString().Equals(dtItem.Rows[J]["internalid"].ToString()))
                   {
                       ds.Tables[1].Rows[i]["Articulo"] = dtItem.Rows[J]["code"];
                       ds.Tables[1].Rows[i]["descuentoArt"] = dtItem.Rows[J]["promo"];
                       ds.Tables[1].Rows[i]["precio"] = dtItem.Rows[J]["price"];
                       ds.Tables[1].Rows[i]["iva"] = dtItem.Rows[J]["iva"];
                       //ds.Tables[1].Rows[i]["pp"]=ds.Tables[0].Select("")


                   }
               }
           }
            //gridControl2.DataSource = dt;
           gridControl3.DataSource = ds.Tables[0];

           gridView9.ActiveFilterString = "[GroupName] not like ('Original')";



           
          

            /*
            DataTable rows = new DataTable();
            rows.Columns.Add("Articulo", typeof(string));
            rows.Columns.Add("Cliente", typeof(string));
            for (int i = 0; i < gridViewMain.RowCount; i++)
            {

                rows.Rows.Add(gridViewMain.GetRowCellValue(i,colarticulo).ToString(),searchListaCliente.Properties.GetDisplayText(searchListaCliente.EditValue));
            }

            gridControl2.DataSource = new SaleOrderSentController().regresaPedidoSeparadoParte1(rows);
            */
           

        }




        

        public ItemInfobyCode regresaItem(string articulo, string cliente)
        {
            //
            Connection conn = new Connection();
            var json = conn.GET("api/Item/GetByCode?code="+articulo+"&customerId="+cliente, token.token);
            Console.WriteLine(json);
            ResultItembyCode result = JsonConvert.DeserializeObject<ResultItembyCode>(json);
            ItemInfobyCode item = result.Result;
            return item;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
           
            Views.Ventas.SaleOrderSentVista sosv = new Views.Ventas.SaleOrderSentVista(token);
            sosv.Parent = this.Parent;
            sosv.Dock = DockStyle.Fill;
            Parent.Controls.Add(sosv);
            sosv.BringToFront();
           
        }
    }
}
