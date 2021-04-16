using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using Microsoft.Win32;
using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using SAI_NETSUITE.IWS;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class entregaPedido : UserControl
    {

        SqlConnection myConnection = new SqlConnection("Data Source=192.168.87.100;" + "Initial Catalog=indarneg;" + "User id=sa;" + "Password=7Ind4r7;");
        SqlConnection myConnection2 = new SqlConnection("Data Source=192.168.87.100;" + "Initial Catalog=indarneg;" + "User id=sa;" + "Password=7Ind4r7;");

        string nombre, perfil, usuario,sqlString;
        string idClienteFila;
        Token token;

        public entregaPedido(string nom, string profile,string sql, Token token)
        {
        //    myConnection = conn;
            nombre = nom;
            perfil = profile;
            sqlString = sql;
            this.token = token;

            InitializeComponent();
        }
        public entregaPedido( string sql)
        {
            //    myConnection = conn;
          
            sqlString = sql;
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           




        }

        private void entregaPedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cteRecogeFila.cteRecogeClientes' table. You can move, or remove it, as needed.
          //  this.cteRecogeClientesTableAdapter.Fill(this.cteRecogeFila.cteRecogeClientes);

            //  string    query = "declare @horra datetime  "+
            //" set @horra= cast(convert(varchar(10), getdate(), 110) as datetime)"+
            //    " select * from cterecogeclientes where hora<= @horra and hora> DATEADD (day , -1 , GETDATE() )  ";
            string query;
            if(checkGDL.Checked)
            query= " set dateformat dmy select * from cterecogeclientes where hora>='"+DateTime.Now.ToShortDateString()+"' and horasalida is null and sucursal='7'";
            else
                query = " set dateformat dmy select * from cterecogeclientes where hora>='" + DateTime.Now.ToShortDateString() + "' and horasalida is null and sucursal is null";

            SqlDataAdapter da3 = new SqlDataAdapter(query, myConnection2);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "id");
          gridclientes.DataSource = ds3.Tables["id"];
          gridView4.RowHeight = 1;

          myConnection2.Close();
       
            
          
        }

        

        private void regresaDatos()
        {
            myConnection2.Close();
            myConnection2.Open();
            myConnection.Close();
            myConnection.Open();
            string query = "select upper(usuario) from sai_usuario where nombre='" + nombre + "'";
            SqlCommand cmd = new SqlCommand(query, myConnection2);
            usuario = cmd.ExecuteScalar().ToString();
            Debug.WriteLine(usuario);
            
        }


        private void cargaDatos(object sender, EventArgs e)
        {
            

             


        }

        private void cargaClienteCelda(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }


        public void pedidosCliente()
        {

            idClienteFila = gridView4.GetFocusedRowCellValue(colClienteid).ToString();

            string query;
            if(checkGDL.Checked)
               query= "select * from indarneg.dbo.almacencterecoge where cliente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus='ALMACEN CTE REC' AND CHECK1 IS NULL and sucursal in ('7','GDL07') ";
            else
                query = "select * from indarneg.dbo.almacencterecoge where cliente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus='ALMACEN CTE REC' AND CHECK1 IS NULL  and (sucursal='1' OR sucursal IS NULL)";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection2);
            da.SelectCommand.CommandTimeout = 0;
            DataSet ds = new DataSet();
            da.Fill(ds, "id");
            // grid_folios.DataSource = ds.Tables["id"];
            gridFacturas.DataSource = ds.Tables["id"];


            //////PARTE DE LA PREFACTURAS

            /* query = "select top 100 movid,(importe+impuestos)as importe,fechaemision, ultimocambio,situacion, formaenvio from venta where   cliente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus not in ('CONCLUIDO','CANCELADO') and mov='Pre Factura' and formaenvio in " +
                 " ('Cte Esta en CDI','Cte Esta en Suc1', 'Cte Mostrador','Cte Recoge CDI','Cte Recoge Suc 1','Cte Recoge Surtefacil','Vendedor Entrega')";*/
            //query = "select top 100 v.movid,(v.importe+v.impuestos)as importe,v.fechaemision, v.ultimocambio,v.situacion, v.formaenvio " +
            //      " from venta v "+
            //      "   where   cliente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus not in ('CONCLUIDO','CANCELADO') and mov='Pre Factura' and formaenvio in  " +
            //      "   ('Cte Recoge en GDL 07','Cte Recoge en CCI','Cte Esta en CCI','Cte Esta en CDI','Cte Esta en Suc1', 'Cte Mostrador','Cte Recoge CDI','Cte Recoge Suc 1','Cte Recoge Surtefacil','Vendedor Entrega','Vendedor Entrega CCI') " +
            //      "   group by v.movid,v.importe,v.impuestos,v.fechaemision,v.ultimoCambio,v.situacion,v.formaenvio";

            //SqlDataAdapter da2 = new SqlDataAdapter(query, myConnection);
            //da2.SelectCommand.CommandTimeout = 0;
            //DataSet ds2 = new DataSet();
            //da2.Fill(ds2, "id");
            //gridPreFactura.DataSource = ds2.Tables["id"];



            ////PEDIDOS
            query = @"
                        select SO.internalId as id,so.tranid as movid,SO.total as importe,so.trandate AS fechaemision,SO.status as situacion,f.LIST_ITEM_NAME as formaenvio from iws.dbo.SaleOrders SO
                        inner join iws.dbo.FormaEnvio f on so.shippingWay=f.LIST_ID
                        inner join IWS.dbo.Customers C on so.idCustomer=c.internalid
                        LEFT join IWS.DBO.Invoices  I on i.createdfrom=so.internalid
                       where  i.createdfrom is null and so.status NOT IN ('Closed','Cerrado') and c.companyId='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "'";
            Console.WriteLine(query);
            SqlDataAdapter da3 = new SqlDataAdapter(query, myConnection);
            da3.SelectCommand.CommandTimeout = 0;
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "id");
            gridpedido.DataSource = ds3.Tables["id"];


            ///FACTURA TERMINADAS POR LLEGAR A CTERECOGER
            ///
            query = @" select  tranid from IWS.dbo.Invoices where TranId not in (select factura from Indarneg.dbo.almacenCteRecoge where cliente='"+ gridView4.GetFocusedRowCellValue(colcliente).ToString() + @"')
                        and status in ('Pendiente', 'Open')";
            //Debug.WriteLine("select v.movid from venta v where not movid  in (select a.factura from indarneg.dbo.almacencterecoge a where a.cliente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "') and v.cliente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and v.ultimocambio>='" + DateTime.Now.ToShortDateString() + "' and v.mov='Factura Indar' and v.estatus='Concluido'");
            SqlDataAdapter da4 = new SqlDataAdapter(query, myConnection);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4, "venta");
            gridFacturaXllegar.DataSource = ds4.Tables["venta"];


            myConnection.Close();
            myConnection.Open();
            query = @"SELECT companyId,c.company,pt.name FROM  iws.dbo.Customers  C
                        INNER JOIN IWS.DBO.PaymentTerms pt on c.PaymentTerms = pt.PAYMENT_TERMS_ID
                         where companyId = '" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            
            txtCliente.Text = sdr.GetValue(0).ToString();
            txtNombreCliente.Text = sdr.GetValue(1).ToString();
            txtCredito.Text = sdr.GetValue(2).ToString();
            myConnection.Close();
        }

        public void pedidosVendedor()
        {
            idClienteFila = gridView4.GetFocusedRowCellValue(colClienteid).ToString();

            //Busca facturas en el aLmacen de cte recoge con el vendedor
            SqlConnection myConnectionInt = new SqlConnection(sqlString);
            string query;
            if (checkGDL.Checked)
                query = @"SELECT V2.id,v.MovID as factura ,v.FormaEnvio,v.Importe+v.Impuestos as importe FROM VENTA v 
                            left join Venta V2 on V.Origen=V2.mov and v.OrigenID=V2.MovID  
                            WHERE v.Mov='Factura Indar' and v.formaenvio='CCI Vendedor Entrega' and v.MovID in( select factura as movid from indarneg.dbo.almacencterecoge  where agente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + @"' and estatus='ALMACEN CTE REC' AND CHECK1 IS NULL)   and V2.MOV LIKE 'PEDIDO%' and v2.autorizacionsad=1 and sucursal='7'"; //"   SELECT movid as factura ,FORMAENVIO,importe+impuestos as importe FROM VENTA WHERE MOV='Factura Indar' and formaenvio='Vendedor Entrega' and movid in( select factura as movid from indarneg.dbo.almacencterecoge where agente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus='ALMACEN CTE REC' AND CHECK1 IS NULL and sucursal='7')";
            else
                query = @"SELECT V2.id,v.MovID as factura ,v.FormaEnvio,v.Importe+v.Impuestos as importe FROM VENTA v 
                            left join Venta V2 on V.Origen=V2.mov and v.OrigenID=V2.MovID  
                            WHERE v.Mov='Factura Indar' and v.formaenvio='CCI Vendedor Entrega' and v.MovID in( select factura as movid from indarneg.dbo.almacencterecoge  where agente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString()+ @"' and estatus='ALMACEN CTE REC' AND CHECK1 IS NULL)   and V2.MOV LIKE 'PEDIDO%' and v2.autorizacionsad=1";
                    
                    //"   SELECT movid as factura ,FORMAENVIO,importe+impuestos as importe FROM VENTA WHERE MOV='Factura Indar' and formaenvio='Vendedor Entrega' and movid in( select factura as movid from indarneg.dbo.almacencterecoge where agente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus='ALMACEN CTE REC' AND CHECK1 IS NULL)";

            Console.WriteLine(query);
            SqlDataAdapter da = new SqlDataAdapter(query, myConnectionInt);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridFacturas.DataSource = ds.Tables[0];

            //FACTURAS RECIEN FACTURADAS
            SqlConnection myConnectionInt2 = new SqlConnection(sqlString);
            query = "select movid from venta where formaenvio='Vendedor Entrega' and fechaemision='" + DateTime.Now.ToShortDateString() + "'  and  MOVID not in (select factura from indarneg.dbo.almacencterecoge where agente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "') AND AGENTE='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and mov='Factura Indar' and estatus='Concluido'";
            SqlDataAdapter da2 = new SqlDataAdapter(query, myConnectionInt2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            gridFacturaXllegar.DataSource = ds2.Tables[0];
            //´PREFACTURAS
         /*   SqlConnection myConnectionInt3 = new SqlConnection(sqlString);
            query="select  v.movid,(v.importe+v.impuestos)as importe,v.fechaemision, v.ultimocambio,v.situacion, v.formaenvio,ISNULL(CONVERT(float, SUM(pkd.staged_quantity) / SUM(pkd.planned_quantity)), 0) AS Avance  "+
                   " from venta v left join  SERVERDB.AAD.dbo.t_order AS hj with (nolock) ON  v.MovID = SUBSTRING(hj.order_number, 3, 10) COLLATE MODERN_SPANISH_CI_AS  "+
                    " LEFT  JOIN   SERVERDB.AAD.dbo.t_pick_detail AS pkd with (nolock) ON pkd.order_number = hj.order_number " +
                    " where   agente='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus not in ('CONCLUIDO','CANCELADO') and mov='Pre Factura' and formaenvio in ('Vendedor Entrega','Vendedor Entrega CCI') " +
                    " group by v.movid,v.importe,v.impuestos,v.fechaemision,v.ultimoCambio,v.situacion,v.formaenvio";
            SqlDataAdapter da3 = new SqlDataAdapter(query, myConnectionInt3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);*/
            //gridPreFactura.DataSource = ds3.Tables[0];
            //PEDIDOS

            query = "select top 100 movid,(importe+impuestos)as importe,fechaemision,ultimocambio ,situacion,formaenvio from venta with(nolock) where   AGENTE='" + gridView4.GetFocusedRowCellValue(colcliente).ToString() + "' and estatus not in ('CONCLUIDO','CANCELADO') and mov in ('Pedido','Pedido BO','Pedido SAD','Pedido WEB','Pedido APP') and formaenvio in " +
" ('Vendedor Entrega','Vendedor Entrega CCI')";
            SqlDataAdapter da4 = new SqlDataAdapter(query, myConnection);
         //   da3.SelectCommand.CommandTimeout = 0;
            DataSet ds4 = new DataSet();
            da4.Fill(ds4, "id");
            gridpedido.DataSource = ds4.Tables["id"];




        }


        private void gridView4_DoubleClick(object sender, EventArgs e)
        {

            //Credencial.cteRecogeCredencial ctrc = new Credencial.cteRecogeCredencial(sqlString, gridView4.GetFocusedRowCellValue(colcliente).ToString().ToUpper());
            //ctrc.ShowDialog();
            if (gridView4.RowCount >= 1)
            {
              CteCredencial.cteRecogeCredencial cc = new CteCredencial.cteRecogeCredencial(sqlString, gridView4.GetFocusedRowCellValue(colcliente).ToString().ToUpper());
                cc.ShowDialog();

                if (gridView4.GetFocusedRowCellValue(colcliente).ToString().ToUpper().Contains("VEN"))
                {
                    pedidosVendedor();
                    checkBox1.Checked = true;
                    txtAgente.Text = gridView4.GetFocusedRowCellValue(colcliente).ToString().ToUpper();
                }
                else
                {
                    checkBox1.Checked = false;
                    pedidosCliente();
                    
                }
            }


        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Views.ClienteRecoge.reimprimirFolio rf = new Views.ClienteRecoge.reimprimirFolio(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            rf.Show();
            
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            entregaPedido_Load(null, null);
           // gridView4_DoubleClick(null, null);
        }

        private void btnEmbarca_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("factura", typeof(string));
            data.Columns.Add("estado", typeof(string));
            data.Columns.Add("fechaHora", typeof(string));
            data.Columns.Add("persona", typeof(string));
            data.Columns.Add("comentarios", typeof(string));
            data.Columns.Add("facturaid", typeof(int));


            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {

                int? internalIdFactura;
                int factura = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString());
                using (IWSEntities ctx = new IWSEntities())
                {
                    internalIdFactura = (from iv in ctx.Invoices
                                         where iv.TranId.Equals(factura)
                                         select iv.internalId).FirstOrDefault();
                }
                data.Rows.Add(
                               gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString(),
                               "ENTREGADO",
                               DateTime.Now.ToString(),
                               "CTE RECOGE",
                               "",
                               internalIdFactura);


            }


            bool resultado = new Controllers.PostVenta.ConfirmacionController().registraEmbarqueConcluido(nombre, data);
            if (resultado)
            {
                List<UpdateInvoiceModel> factura = new List<UpdateInvoiceModel>();
                for (int i = 0; i < data.Rows.Count; i++)
                {

                    int internalid = Convert.ToInt32(data.Rows[i][5].ToString());
                    UpdateInvoiceModel uim = new UpdateInvoiceModel()
                    {
                        internalId = Convert.ToInt32(data.Rows[i][5].ToString()),
                        custbody_nso_indr_receipt_date = DateTime.Now.ToString()
                    };
                    factura.Add(uim);
                }
    
                labelAvance.Text = "0/" + gridView1.RowCount.ToString();
                gridclientes.Visible = false;
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync(argument: factura);

                }
            }
            else
                MessageBox.Show("Error en la transaccion");




            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            SqlCommand cmd2 = new SqlCommand("", myConnection);
            myConnection.Open();
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                string factura2 = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString();
                cmd2.CommandText = "update indarneg.dbo.almacencterecoge set check1=1 where factura='" + factura2 + "'";
                cmd2.ExecuteNonQuery();
            }
            cmd2.CommandText = "update indarneg.dbo.cterecogeclientes set horasalida=getdate() where id=" + idClienteFila;
            cmd2.ExecuteNonQuery();
         
                List<string> facturas = new List<string>();
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    facturas.Add(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString());
                }
            string sucursal="";
            if (checkGDL.Checked)
                sucursal = "GDL";
            else sucursal = "0";
                recibo3 r3 = new recibo3( usuario, txtCliente.Text, facturas,sucursal);
                r3.Show();
         //   }
              gridFacturas.DataSource = null;
              gridFacturaXllegar.DataSource = null;
              //gridPreFactura.DataSource = null;
              gridpedido.DataSource = null;
              MessageBox.Show("Embarque Realizado");
              entregaPedido_Load(null, null);
            
            if (checkBox1.Checked == true)
            {
              //  imprimeReciboVendedor(idEmbarque);
            }
            checkBox1.Checked = false;
         
        }

        public void imprimeReciboVendedor(string numEmbarque)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = "select Embarque=E.Mov+' '+E.MovID,E.Estatus,E.FechaEmision,Agente=A.Nombre+' ('+E.Agente+')',E.Vehiculo,E.Ruta,E.Peso,E.Volumen,E.Referencia,E.Observaciones,E.Paquetes,D.Orden,PaquetesD = D.Paquetes,EmbEstado = D.Estado,Em.Accion,Movimiento = Em.Mov+' '+Em.MovID,RutaD = Em.Ruta,Em.Zona,ImporteTotal = Em.Importe+Em.Impuestos, " +
                          "  Em.Moneda,Em.Condicion,Cliente=Em.Nombre+' - '+Em.Cliente,Em.NombreEnvio,Em.Direccion,Em.MovReferencia,Em.Colonia,Em.CodigoPostal,Em.Poblacion,Em.Estado,Em.Pais,Em.Telefonos,e.movid as numeroEMB,Em.MovID as codigoFactura   from Embarque E   left join Agente A on E.Agente = A.Agente   join EmbarqueD D on E.ID = D.ID " +
                           "     join EmbarqueMov Em on D.ID = Em.AsignadoID AND D.EmbarqueMov = Em.ID    where E.ID = " + numEmbarque + "     order by D.Orden,Em.Cliente";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
          //  ds.WriteXmlSchema(@"S:\XML\CteRecoge\vendedorEntrega.xml");
            cteRecogeVendedorEntrega ctRVE = new cteRecogeVendedorEntrega();
            ctRVE.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(ctRVE))
            {
                // Invoke the Ribbon Print Preview form modally, 
                // and load the report document into it.
                printTool.ShowRibbonPreviewDialog();

                // Invoke the Ribbon Print Preview form
                // with the specified look and feel setting.
                printTool.ShowRibbonPreview(UserLookAndFeel.Default);
            }
            //ctRVE.ExportToPdf(@"S:\XML\CteRecoge\prueba.pdf");
        
        }


       
        public void imprimeReciboVendedor(string numEmbarque,string claveFletera)
        {
            Console.WriteLine("sientro");
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = "select Embarque=E.Mov+' '+E.MovID,E.Estatus,E.FechaEmision,Agente=A.Nombre+' ('+E.Agente+')',E.Vehiculo,E.Ruta,E.Peso,E.Volumen,E.Referencia,E.Observaciones,E.Paquetes,D.Orden,PaquetesD = D.Paquetes,EmbEstado = D.Estado,Em.Accion,Movimiento = Em.Mov+' '+Em.MovID,RutaD = Em.Ruta,Em.Zona,ImporteTotal = Em.Importe+Em.Impuestos, " +
                          "  Em.Moneda,Em.Condicion,Cliente=Em.Nombre+' - '+Em.Cliente,Em.NombreEnvio,Em.Direccion,Em.MovReferencia,Em.Colonia,Em.CodigoPostal,Em.Poblacion,Em.Estado,Em.Pais,Em.Telefonos,e.movid as numeroEMB,'" + claveFletera + "' as claveFletera ,Em.MovID as codigoFactura   from Embarque E   left join Agente A on E.Agente = A.Agente   join EmbarqueD D on E.ID = D.ID " +
                           "     join EmbarqueMov Em on D.ID = Em.AsignadoID AND D.EmbarqueMov = Em.ID    where E.ID = " + numEmbarque + "     order by D.Orden,Em.Cliente";
            Console.WriteLine(query);
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Console.WriteLine("clave fletera"+claveFletera);
            //ds.WriteXmlSchema(@"S:\XML\CteRecoge\vendedorEntrega.xml");
            cteRecogeVendedorEntrega ctRVE = new cteRecogeVendedorEntrega();
            ctRVE.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(ctRVE))
            {
                // Invoke the Ribbon Print Preview form modally, 
                // and load the report document into it.
                printTool.ShowRibbonPreviewDialog();

                // Invoke the Ribbon Print Preview form
                // with the specified look and feel setting.
                printTool.ShowRibbonPreview(UserLookAndFeel.Default);
            }
            //ctRVE.ExportToPdf(@"S:\XML\CteRecoge\prueba.pdf");

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

 


        private void CargaDatosFactura(object sender, EventArgs e)
        {
            infoFactura info = new infoFactura( gridView1.GetFocusedRowCellValue(colFactura).ToString(),"I","*");
            info.ShowDialog();
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            infoFactura info = new infoFactura(gridView5.GetFocusedRowCellValue(colFacturaXllegar).ToString(),"F","*");
            info.ShowDialog();
        }

        //private void cargaPreFactura(object sender, EventArgs e)
        //{
        //    Procesos.PostVenta.infoFactura info = new PostVenta.infoFactura(myConnection, nombre, perfil, gridView2.GetFocusedRowCellValue(colPreMovid).ToString(), "PF");
        //    info.ShowDialog();
        //}

        private void cargaPedido(object sender, DevExpress.XtraGrid.Views.Base.DragObjectStartEventArgs e)
        {
            infoFactura info = new infoFactura( gridView3.GetFocusedRowCellValue(colPedPedido).ToString(), "PE",gridView3.GetFocusedRowCellValue(colPedId).ToString());
            info.ShowDialog();
        }

        private void gridView4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
            {
                Debug.WriteLine("sI ENTRO");
                myConnection2.Close();
                myConnection2.Open();
                string row = gridView4.GetFocusedRowCellValue(colClienteid).ToString();
                SqlCommand cmd = new SqlCommand("", myConnection2);
                cmd.CommandText = "delete from cterecogeclientes where id=" + row;
                cmd.ExecuteNonQuery();
                myConnection2.Close();
                entregaPedido_Load(null, null);
                
            
            }
        }

        private void gridView4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                Debug.WriteLine("sI ENTRO");
                myConnection2.Close();
                myConnection2.Open();
                borrarClienteFila borra = new borrarClienteFila();
                borra.ShowDialog();
                string motivo =  ClienteRecoge.borrarClienteFila.C.Text;
                string row = gridView4.GetFocusedRowCellValue(colClienteid).ToString();
                SqlCommand cmd = new SqlCommand("", myConnection2);
                cmd.CommandText = "update  cterecogeclientes set horasalida=getdate(),motivo='" + motivo + "' where id=" + row;
                cmd.ExecuteNonQuery();
                myConnection2.Close();
                entregaPedido_Load(null, null);
                
            
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = "[check1]= true";
            gridView1.ActiveFilter.Clear();
        }

        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            //gridView1.ActiveFilterString = "[check1]= true";
            //*********************VERSION  ANTIGUA**************************************************
            
            //DataTable dt = new DataTable();
            //dt.Columns.Add("factura", typeof(string));
            //for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            //{
            //    Debug.WriteLine(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString());
            //    dt.Rows.Add(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString());
            //}
            //Procesos.CteRecoge.recibo reci = new recibo(myConnection, nombre, perfil, dt, txtCliente.Text,txtNombreCliente.Text,txtAgente.Text,sqlString);
            //reci.Show();
            //*********************VERSION  ANTIGUA**************************************************

            List<string> facturas = new List<string>();
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                Console.WriteLine("agregafactura");
                facturas.Add(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString());
            }
            Console.WriteLine(facturas.Count);
            string sucursal = "";
            if (checkGDL.Checked)
                sucursal = "GDL";
            else sucursal = "0";
            recibo3 r3 = new recibo3(nombre, txtCliente.Text, facturas,sucursal);
            r3.Show();


        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {

                DialogResult result = MessageBox.Show("Borrar Factura:"+gridView1.GetFocusedRowCellValue(colFactura).ToString(), "Mensaje", MessageBoxButtons.OKCancel);

                switch (result)
                {
                    case DialogResult.OK:
                        {
                            SqlConnection myConnection2int = new SqlConnection("Data Source=192.168.87.100;" + "Initial Catalog=indarneg;" + "User id=sa;" + "Password=7Ind4r7;");
                                    myConnection2int.Close();
                                    myConnection2int.Open();
                                    SqlCommand cmd = new SqlCommand("", myConnection2int);
                                    cmd.CommandText = "delete from  almacencterecoge   where factura='" + gridView1.GetFocusedRowCellValue(colFactura).ToString() + "'";
                                    cmd.ExecuteNonQuery();
                                    myConnection2int.Close();
                                    
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            
                            break;
                        }
                }
            }
        }

        public string regresaEstacion()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                string InstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Intelisis", "Estacion Trabajo", null);
                if (InstallPath != null)
                {
                    return InstallPath;
                }
                else
                {
                    InstallPath = (string)Registry.GetValue(@"HKEY_CLASSES_ROOT\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\Intelisis", "Estacion Trabajo", null);
                    if (InstallPath != null)
                    {
                        return InstallPath;
                    }
                }
            }
            else
            {
                string InstallPath2 = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Intelisis", "Estacion Trabajo", null);
                if (InstallPath2 != null)
                {
                    return InstallPath2;
                }
            }
        
        return "635";
        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<UpdateInvoiceModel> lista = (List<UpdateInvoiceModel>)e.Argument;
            int avance = 0;
            foreach (var Invoice in lista)
            {

                Controllers.PostVenta.ConfirmacionController cc = new Controllers.PostVenta.ConfirmacionController();
                string resultado = cc.insertaFechaVencimientoNetsuite(Invoice, token);
                if (resultado.Contains("true"))
                {

                    backgroundWorker1.ReportProgress(avance);
                    avance++;
                    Console.WriteLine(Invoice.internalId);
                }
                else MessageBox.Show("ERROR " + JsonConvert.SerializeObject(Invoice));


            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso Terminado");
         
            labelAvance.Text = "0/1";
         pictureEdit1.Visible = false;
            gridclientes.Visible = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelAvance.Text = e.ProgressPercentage.ToString() + "/" + gridView1.RowCount.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //imprimeReciboVendedor("119980");
             imprimeReciboVendedor("103295","ENVIA");
        }

        private void btnAdminsitraralmacen_Click(object sender, EventArgs e)
        {
            /* administraAlmacen aa = new administraAlmacen(sqlString);
             aa.Show();*/
            Views.ClienteRecoge.administraAlmacen AA = new administraAlmacen(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            AA.Show();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            /*    Procesos.PostVenta.infoFactura info = new PostVenta.infoFactura(myConnection, nombre, perfil, gridView3.GetFocusedRowCellValue(colPedPedido).ToString(), "PE",gridView3.GetFocusedRowCellValue(colPedId).ToString());
                info.ShowDialog();*/

            infoFactura info = new infoFactura(gridView3.GetFocusedRowCellValue(colPedPedido).ToString(), "PE", gridView3.GetFocusedRowCellValue(colPedId).ToString());
            info.ShowDialog();
        }

        
    }
}





/*
 private void btnEmbarca_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Debug.WriteLine(gridView1.RowCount);
                Debug.WriteLine("+"+gridView1.GetRowCellValue(i, colcheck)+"+");

                   if ((bool)gridView1.GetRowCellValue(i, colcheck) == true)
                    {
                        string factura = gridView1.GetRowCellValue(i, colFactura).ToString();
                        myConnection.Close();
                        myConnection.Open();

                        SqlCommand cmd = new SqlCommand("", myConnection);
                        /// INSERTA EL NUERO EMBARQUE
                        cmd.CommandTimeout=0;
                        cmd.CommandText="INSERT INTO Embarque "+
                         " (Empresa, Mov, MovID, FechaEmision, UltimoCambio, Proyecto, Usuario, Autorizacion, Concepto, Referencia, DocFuente, Observaciones, Estatus, Situacion, SituacionFecha, SituacionUsuario, SituacionNota, Vehiculo, Ruta, Agente, Peso, Volumen, Paquetes, Ejercicio, Periodo, FechaSalida, FechaRetorno, CtaDinero, Proveedor, Importe, Impuestos, Gastos, Sucursal, SucursalOrigen, UEN, PersonalCobrador, KmsSalida, KmsRetorno, TermoInicio, TermoFin)"+
                             " VALUES "+
                         " ('FIN', 'Embarque', NULL, '"+DateTime.Now.ToShortDateString()+"', getdate(), NULL, '"+usuario+"', NULL, NULL, NULL, NULL, NULL, 'SINAFECTAR', NULL, NULL, NULL, NULL, NULL, NULL, '"+txtAgente.Text+"', NULL, NULL, NULL, 2015, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL)";
                        cmd.ExecuteNonQuery();
                        ///RECUPERO EL ID DEL NUEVO EMBARQUE
                        cmd.CommandText = "select max(id) from embarque where usuario='"+usuario+"'";
                        string idEmbarque = cmd.ExecuteScalar().ToString();
                        ////LIMPIO LISTAID (INTELESIS LA USA COMO VARIABLE)
                        cmd.CommandText = "delete listaid where estacion=635";
                        cmd.ExecuteNonQuery();
                        ///BUSCO EL ID DEL LA FACTURA QUE ESTA EN EMBARQUEMOV
                        cmd.CommandText="select id from embarquemov where movid='"+factura+"' and mov='Factura Indar' and modulo='VTAS'";
                        string id = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = "INSERT INTO ListaID (Estacion, ID) VALUES (635," + id + " ) ";
                        cmd.ExecuteNonQuery();
                        /// SP EMBARQUE  PARA ASIGNAR LAS FACTURAS  AL EMBARQUE ACTUAL
                        cmd.CommandText = " exec spEmbarqueAsignar 0, 635, " + idEmbarque;
                        cmd.ExecuteNonQuery();
                        ///primer  Afectar
                        cmd.CommandText = " exec spAfectar 'EMB', " + idEmbarque + ", 'AFECTAR', 'Todo', NULL, '"+usuario+"', @Estacion=635";
                        cmd.ExecuteNonQuery();
                        //Segundo Afectar cuando  se le pone entre entregado
                        cmd.CommandText="UPDATE EmbarqueD"+
                          "  SET  Estado = 'Entregado',  FechaHora = getdate(),  Persona = '" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "' WHERE  ID = " + idEmbarque + " AND Orden = 1";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = " exec spAfectar 'EMB', " + idEmbarque + ", 'AFECTAR', 'Todo', NULL, '"+usuario+"', @Estacion=635";
                        cmd.ExecuteNonQuery();
                        myConnection.Close();
                        Debug.WriteLine("EMBARQUE TERMINADO");
                       ////Ahora  quitar la factura de la lista de del almacen y quitar el usaurio
                       myConnection2.Close();
                        myConnection2.Open();
                        SqlCommand cmd2 = new SqlCommand("", myConnection2);
                        cmd2.CommandText = "update almacencterecoge set check1=1 where factura='" + factura + "'";
                        cmd2.ExecuteNonQuery();
                        cmd2.CommandText = "update cterecogeclientes set horasalida=getdate() where id=" + idClienteFila;
                        cmd2.ExecuteNonQuery();
                        if (txtCredito.Text.Contains("ANTICIPO") || txtCredito.Text.Contains("CONTADO") || txtCredito.Text.Contains("EFECTIVO") || txtCredito.Text.Contains("PAGO ANTICIPADO"))
                        {
                            Procesos.Pagos.recibo_cobro recibo = new Pagos.recibo_cobro(myConnection, nombre, perfil);
                            recibo.Show();
                        }
                        else
                        {
                            gridFacturas.DataSource = null;
                            gridFacturaXllegar.DataSource = null;
                            gridPreFactura.DataSource = null;
                            gridpedido.DataSource = null;
                            MessageBox.Show("Embarque Realizado");
                            entregaPedido_Load(null, null);
                            
                        }



                    }
                
            }
        }
 
 */
