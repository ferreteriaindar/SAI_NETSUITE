using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;


namespace SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class recibo3 : Form
    {
        string agente,cte,agenteNombre,sucursal,folioEmail;
        int intento = 0;
        DataTable dt;
        List<string> facturas;
        public recibo3(string agt,string cliente,List<string> facs,string suc)
        {
          
            agente = agt;
            cte = cliente;
            facturas = facs;
            sucursal = suc;
            InitializeComponent();
        }

        private void recibo3_Load(object sender, EventArgs e)
        {
          //  cargaDocumentosLibres();
            txtFolio.Select();
            cargaDatosGenerales();
            inicializaDT();
        
        }



        public void inicializaDT()
        {
            dt = new DataTable();
            dt.Columns.Add("mov", typeof(string));
            dt.Columns.Add("movid", typeof(string));
            dt.Columns.Add("importe", typeof(double));
            dt.Columns.Add("despp", typeof(double));
            dt.Columns.Add("importepagar", typeof(double));
            dt.Columns.Add("comentario", typeof(string));
            SqlConnection myConnection =new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            SqlCommand cmd = new SqlCommand("",myConnection);
            myConnection.Open();
            cmd.CommandText = @"  		  select TranType as mov,TranId as movid,(SubTotal+TaxTotal) as importe,case when isnull( DescuentoTotalPP,0)=0 then 4 else isnull( DescuentoTotalPP,0) end  as despp,(SubTotal+TaxTotal) as importepagar,'' as comentario from iws.dbo.Invoices
                                    where tranid in (" + string.Join(",", facturas)+") and status='Open'"  ; 
          Console.WriteLine(cmd.CommandText);
          if (facturas.Count > 0)
          {
              SqlDataReader sdr = cmd.ExecuteReader();
              while (sdr.HasRows && sdr.Read())
              {
                  dt.Rows.Add(sdr.GetValue(0).ToString(), sdr.GetValue(1).ToString(), Convert.ToDouble(sdr.GetValue(2).ToString()), Convert.ToDouble(sdr.GetValue(3).ToString()), sdr.GetValue(4).ToString());


              }
          }
          gridControl1.DataSource = dt;
          actualizaTotal();

 
        }
        public void cargaDatosGenerales()
        {
            
                txtNumCte.Text = cte;
                txtfecha.Text = DateTime.Now.ToShortDateString();
                SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
                SqlCommand cmd = new SqlCommand("", myConnection);
                myConnection.Open();
                cmd.CommandText = "select isnull(company,'No existe') from iws.dbo.customers where companyid='" + cte + "'";
                var resultado = cmd.ExecuteScalar().ToString();
                txtRazonSocial.Text = resultado.ToString();
        
        
        }

        public void cargaDocumentosLibres()
        {
            try
            {
                /*   SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);

                   string query = "select * ,isnull((select  case when(isnull(indardescnormal,0)+isnull(indardescnegociado,0))=0 then 4 ELSE (isnull(indardescnormal,0)+isnull(indardescnegociado,0)) END from venta where venta.movid=q.movid and venta.mov=q.mov),0) as despp  from (" +
                                   "SELECT MOV,MOVID,SALDO,mov+' '+movid+'   $'+STR(saldo, 8, 2) as completo  FROM dbo.fnCxcInfo('FIN', '" + cte + "', '" + cte + "') " +
                                   "  WHERE Mov NOT IN ('Cobro Posfechado') AND Moneda = 'Pesos' " +
                                   "  AND Mov not in('Redondeo'))as q " +
                                   "  ORDER BY  Mov, MovID ";


                   Console.WriteLine(query);
                   SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                   da.SelectCommand.CommandTimeout = 0;
                   DataSet ds = new DataSet();
                   da.Fill(ds);

                   searchLookUpEdit1.Properties.DataSource = ds.Tables[0];
                   searchLookUpEdit1.Properties.DisplayMember = "completo";
                   searchLookUpEdit1.Properties.ValueMember = "MOVID";
                   myConnection.Dispose();
                   da.Dispose();*/
                IWS.Connection con = new IWS.Connection();
                string json = con.GET("api/Customer/GetBalanceDocuments?idcliente="+ regresaIdCliente(cte), SAI_NETSUITE.Properties.Resources.token);
                BalanceDocumentsModel balanceDocumentsModel = JsonConvert.DeserializeObject<BalanceDocumentsModel>(json);
                string documentos = JsonConvert.SerializeObject(balanceDocumentsModel.result.Resultados);
                //DataTable dsTopics = JsonConvert.DeserializeObject<DataTable>(documentos);
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(documentos);

                DataTable dataTable = dataSet.Tables["Documentos"];
                foreach (var columns in dataTable.Columns)
                {
                    Console.WriteLine(columns.ToString());
                }
                searchLookUpEdit1.Properties.DataSource = dataTable;
                searchLookUpEdit1.Properties.DisplayMember = "completo";
                searchLookUpEdit1.Properties.ValueMember = "No_documento";
            }
            catch (SqlException ex)
            {
             
                MessageBox.Show("Intenta de nuevo");
            }
            
     


        }


     

        private void btnAgregarDoc_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
            {
                MessageBox.Show("Escoge Al menos un documento");

            }
            else
            {
                if (esRepetido().Equals("LIBRE"))
                {
                    GridView view = searchLookUpEdit1.Properties.View;
                    int rowHandle = view.FocusedRowHandle;
                    string fieldName = "Saldo_documento"; // or other field name
                    object value = view.GetRowCellValue(rowHandle, fieldName);
                    object mov = view.GetRowCellValue(rowHandle, "Doc");
                    object despp = view.GetRowCellValue(rowHandle, "Descuento_pronto_pago");
                    string pp = despp.ToString().Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                    if (mov.Equals("creditmemo"))
                    {
                        mov = "Nota Credito";
                        value = "-" + value;
                        pp = "0";
                    }
                    if(mov.Equals("invoice"))
                    {
                        mov = "Factura";

                    }
                    dt.Rows.Add(mov.ToString(), searchLookUpEdit1.EditValue.ToString(), value.ToString(), pp, value.ToString(), "");
                    gridControl1.DataSource = dt;
                    actualizaTotal();
                }
                else MessageBox.Show("ESTE DOCUMENTO YA SE  USÓ EN EL FOLIO " + esRepetido());
            
            }
        }


        public string esRepetido()
        {/*
            GridView view = searchLookUpEdit1.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            object mov = view.GetRowCellValue(rowHandle, "MOV");
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select isnull(cteRecogeFolio,'LIBRE') AS resultado from cxc where MovID='" + searchLookUpEdit1.EditValue.ToString() + "' and mov='"+mov+"'";
            var resultado = cmd.ExecuteScalar().ToString();
            myConnection.Close();
            if(resultado.ToString().Equals("LIBRE"))
                return "LIBRE";
            else return resultado.ToString();*/
            return "LIBRE";
           
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void lookUpEdit1_DoubleClick(object sender, EventArgs e)
        {
        
        }

        private void btnGuardarEImprimir_Click(object sender, EventArgs e)
        {
            if (validadordatoscte.Validate()&& intento==0)
            {
              //  registraFolio();
              string folio = regresaUltimoFolio(sucursal);
              folioEmail = folio;
                Debug.WriteLine("SUCURSAL" + sucursal);
                if (sucursal.Equals("GDL"))
                    registraFOlIO3_gdl();
                else
                registraFOlIO3();
                generaRecibo(folio);
                registrardocumentosAplicados(folio);
                
                DialogResult result = MessageBox.Show("¿Quieres re-imprimir el recibo?", "Atención", MessageBoxButtons.YesNo);

                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            generaRecibo(folio);
                            break;

                        }
                    case DialogResult.No:
                        this.Close();
                        break;
                }

            }
            else MessageBox.Show("No se puede  duplicar el folio");

            LoginUserControl myControl = new LoginUserControl();
            if (DevExpress.XtraEditors.XtraDialog.Show(myControl, "Email Alternativo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // do something 
                string email = myControl.teLogin.Text;
                RegexUtilities util = new RegexUtilities();
                if (util.IsValidEmail(email))
                {
                    enviaEmails(cte, email, folioEmail);
                }
                else MessageBox.Show("No es valido");
            }
            else
            {
                enviaEmails(cte, enviarEmail(""), folioEmail);
            }




        }



        public string enviarEmail(string emailAdicional)
        {
            if (!cte.Contains("VEN"))
            {
                try
                {
                    SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    cmd.CommandText = "select top 1 isnull(eMail,'sistemas@indar.com.mx') as email from ctecto  where cliente='" + cte + "' AND CFD_Enviar is not null order by id asc";
                    var email = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                    myConnection.Close();
                    myConnection.Dispose();

                    return email.ToString();
                }
                catch (SqlException )
                {
                    return "sistemas@indar.com.mx";
                }
            }
            else return "efonseca@indar.com.mx";
        
        }
        public void registrardocumentosAplicados(string folio)
        {
            //BUSCAR LA MANERA DE  MARCAR ESOS DOCUMENTOS EN NETSUITE
            /*
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            for (int i = 0; i <gridView1.RowCount; i++)
            {
                cmd.CommandText = "update cxc  set cteRecogeFolio='" + folio + "' where movid='" + gridView1.GetRowCellValue(i, colMov).ToString() + "' and mov='" + gridView1.GetRowCellValue(i, colMovid).ToString() + "'";
                cmd.ExecuteNonQuery();
            }
            cmd.Dispose();
            myConnection.Close();
            myConnection.Dispose();
            */
        }

        public int regresaIdBlock(string folio)
        {
            int id_block=0;
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            string query = "select id,nombre from  indarneg.dbo.recibo_folios where " + folio + ">=folio_inicio and " + folio + "<=folio_fin and serie='A'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            myConnection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                id_block = Convert.ToInt32(sdr.GetValue(0));
                agenteNombre = sdr.GetValue(1).ToString();
             
            }
            myConnection.Close();
            return  id_block;
            
        
        }

        public string regresaUltimoFolio(string sucursal)
        {
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            if (sucursal.Equals("GDL"))
            {
                Debug.WriteLine("si busca el ultimo  folio  de gdl");
                cmd.CommandText = "select MAX( isnull(foliogdl07,0))+1 as folio from indarneg.dbo.reciboCobro_CteRecoge where  foliogdl07 is not null";
            }
            else
            cmd.CommandText = "select MAX( isnull(folio,0))+1 as folio from indarneg.dbo.reciboCobro_CteRecoge";
            var resultado = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            myConnection.Close();
            myConnection.Dispose();
            return resultado.ToString();

          
          
          
        }



        public void registraFOlIO3_gdl()
        {
            try
            {
                string ultimofolio = regresaUltimoFolio(sucursal);
                SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);

                myConnection.Open();

                for (int i = 0; i < gridView1.RowCount; i++)
                {

                    string query = " SET DATEFORMAT dmy insert into INDARNEG.dbo.reciboCobro_CteRecoge(fecha,cliente,nombre_cliente,agente,tipo_pago,mov,num_fac,importeDocumento,importe_cobra,observaciones,fecha_captura,rfcBanco,nombreBanco,numCuenta,tarjetaBanco,cheque_banco,fecha_banco,foliogdl07,clabe,porciento,total)" +
                                                                                              "values(@fecha,@cliente,@nombre_cliente,@agente,@tipo_pago,@mov,@num_fac,@importeDocumento,@importe_cobra,@observaciones,@fecha_captura,@rfcBanco,@nombreBanco,@numCuenta,@tarjetaBanco,@cheque_banco,@fecha_banco,@foliogdl07,@clabe,@porciento,@total)";
                    SqlCommand cmd2 = new SqlCommand(query, myConnection);



                    cmd2.Parameters.AddWithValue("@cliente", txtNumCte.Text);
                    cmd2.Parameters.AddWithValue("@nombre_cliente", txtRazonSocial.Text);
                    cmd2.Parameters.AddWithValue("@agente", agente);
                    cmd2.Parameters.AddWithValue("@tipo_pago", radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description.ToString());
                    cmd2.Parameters.AddWithValue("@mov", gridView1.GetRowCellValue(i, colMov).ToString());
                    cmd2.Parameters.AddWithValue("@num_fac", gridView1.GetRowCellValue(i, colMovid).ToString());
                    cmd2.Parameters.AddWithValue("@importeDocumento", Convert.ToDecimal(gridView1.GetRowCellValue(i, colImporte).ToString()));
                    cmd2.Parameters.AddWithValue("@porciento", Convert.ToDecimal(gridView1.GetRowCellValue(i, colDesPP).ToString()));
                    if (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description.ToString().Equals("Vale Empleado"))
                        cmd2.Parameters.AddWithValue("@importe_cobra", 0.0);
                    else
                        cmd2.Parameters.AddWithValue("@importe_cobra", Convert.ToDecimal(gridView1.GetRowCellValue(i, colImporteFinal).ToString()));
                  
                    cmd2.Parameters.AddWithValue("@observaciones", gridView1.GetRowCellValue(i, colComentario).ToString());
                    cmd2.Parameters.AddWithValue("@fecha_captura", DateTime.Now.ToShortDateString());
                    cmd2.Parameters.AddWithValue("@rfcBanco", txtRFCbANCO.Text);
                    cmd2.Parameters.AddWithValue("@nombreBanco", txtBanco.Text);
                    cmd2.Parameters.AddWithValue("@numCuenta", txtCuenta.Text);
                    cmd2.Parameters.AddWithValue("@tarjetaBanco", txtTarjeta.Text);
                    cmd2.Parameters.AddWithValue("@cheque_banco", txtCheque.Text);
                    Console.WriteLine(masked_fecha.Text);
                    if (masked_fecha.Text.Equals("  /  /    "))
                        cmd2.Parameters.AddWithValue("@fecha_banco", "01/01/1900");
                    else cmd2.Parameters.AddWithValue("@fecha_banco", masked_fecha.Text);
                    cmd2.Parameters.AddWithValue("@foliogdl07", ultimofolio);
                    cmd2.Parameters.AddWithValue("@fecha", DateTime.Now.ToShortDateString());
                    cmd2.Parameters.AddWithValue("@clabe", txtClabe.Text);
                    cmd2.Parameters.AddWithValue("@total", txtTotal.Text);
                    Console.WriteLine(cmd2.CommandText);
                    cmd2.ExecuteNonQuery();
                    intento++;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }



        public void registraFOlIO3()
    {
        try
        {
            string ultimofolio = regresaUltimoFolio(sucursal);
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);

            myConnection.Open();

            for (int i = 0; i < gridView1.RowCount; i++)
            {

                string query = " SET DATEFORMAT dmy insert into INDARNEG.dbo.reciboCobro_CteRecoge(fecha,cliente,nombre_cliente,agente,tipo_pago,mov,num_fac,importeDocumento,importe_cobra,observaciones,fecha_captura,rfcBanco,nombreBanco,numCuenta,tarjetaBanco,cheque_banco,fecha_banco,folio,clabe,porciento,total)" +
                                                                                          "values(@fecha,@cliente,@nombre_cliente,@agente,@tipo_pago,@mov,@num_fac,@importeDocumento,@importe_cobra,@observaciones,@fecha_captura,@rfcBanco,@nombreBanco,@numCuenta,@tarjetaBanco,@cheque_banco,@fecha_banco,@folio,@clabe,@porciento,@total)";
                SqlCommand cmd2 = new SqlCommand(query, myConnection);
             
                
                
                cmd2.Parameters.AddWithValue("@cliente", txtNumCte.Text);
                cmd2.Parameters.AddWithValue("@nombre_cliente", txtRazonSocial.Text);
                cmd2.Parameters.AddWithValue("@agente", agente);
                cmd2.Parameters.AddWithValue("@tipo_pago", radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description.ToString());
                cmd2.Parameters.AddWithValue("@mov", gridView1.GetRowCellValue(i, colMov).ToString());
                cmd2.Parameters.AddWithValue("@num_fac", gridView1.GetRowCellValue(i, colMovid).ToString());
                cmd2.Parameters.AddWithValue("@importeDocumento", Convert.ToDecimal(gridView1.GetRowCellValue(i, colImporte).ToString()));
                cmd2.Parameters.AddWithValue("@porciento",Convert.ToDecimal(gridView1.GetRowCellValue(i,colDesPP).ToString()));
                if (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description.ToString().Equals("Vale Empleado"))
                    cmd2.Parameters.AddWithValue("@importe_cobra", 0.0);
                else
                cmd2.Parameters.AddWithValue("@importe_cobra", Convert.ToDecimal(gridView1.GetRowCellValue(i, colImporteFinal).ToString()));
                cmd2.Parameters.AddWithValue("@observaciones", gridView1.GetRowCellValue(i, colComentario).ToString());
                cmd2.Parameters.AddWithValue("@fecha_captura", DateTime.Now.ToShortDateString());
                cmd2.Parameters.AddWithValue("@rfcBanco",txtRFCbANCO.Text);
                cmd2.Parameters.AddWithValue("@nombreBanco",txtBanco.Text);
                cmd2.Parameters.AddWithValue("@numCuenta",txtCuenta.Text);
                cmd2.Parameters.AddWithValue("@tarjetaBanco",txtTarjeta.Text);
                cmd2.Parameters.AddWithValue("@cheque_banco",txtCheque.Text);
                Console.WriteLine(masked_fecha.Text);
                if(masked_fecha.Text.Equals("  /  /    "))
                    cmd2.Parameters.AddWithValue("@fecha_banco","01/01/1900");
                else cmd2.Parameters.AddWithValue("@fecha_banco",masked_fecha.Text);
                cmd2.Parameters.AddWithValue("@folio", ultimofolio);
                cmd2.Parameters.AddWithValue("@fecha", DateTime.Now.ToShortDateString());
                cmd2.Parameters.AddWithValue("@clabe", txtClabe.Text);
                cmd2.Parameters.AddWithValue("@total", txtTotal.Text);
               Console.WriteLine(cmd2.CommandText);             
                cmd2.ExecuteNonQuery();
                intento++;
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
        
    
    }


        public void registraFolio()
        {
/*
            try
            {
                SqlConnection myConnection = new SqlConnection(sqlString);

                myConnection.Open();

                    for (int i = 0; i < gridView1.RowCount;i++ )
                    {

                        string query = "SET DATEFORMAT dmy insert into indarneg.dbo.recibo_folios_consecutivo(id_block,folio,fecha,cliente,nombre_cliente,agente,tipo_pago,num_fac,porciento,importe_desc,importe_cobra,observaciones,fecha_captura,importe_real,fecha_banco,cheque_banco,mov)" +
                                                                   "values(@id_block,@folio,@fecha,@cliente,@nombre_cliente,@agente,@tipo_pago,@num_fac,@porciento,@importe_desc,@importe_cobra,@observaciones,@fecha_captura,@importe_real,@fecha_banco,@cheque_banco,@mov)";
                        SqlCommand cmd2 = new SqlCommand(query, myConnection);
                        cmd2.Parameters.AddWithValue("@id_block",regresaIdBlock(txtFolio.Text));
                        cmd2.Parameters.AddWithValue("@folio", Convert.ToInt32(txtFolio.Text));
                        cmd2.Parameters.AddWithValue("@fecha",DateTime.Now.ToShortDateString());
                        cmd2.Parameters.AddWithValue("@cliente", txtNumCte.Text);
                        cmd2.Parameters.AddWithValue("@nombre_cliente", txtRazonSocial.Text);
                        cmd2.Parameters.AddWithValue("@agente", agenteNombre);
                        cmd2.Parameters.AddWithValue("@tipo_pago", radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description.ToString());
                        cmd2.Parameters.AddWithValue("@num_fac", gridView1.GetRowCellValue(i,colMovid).ToString());
                        cmd2.Parameters.AddWithValue("@porciento", Convert.ToDecimal(gridView1.GetRowCellValue(i,colDesPP).ToString()));
                        cmd2.Parameters.AddWithValue("@importe_desc", 0.0);
                        cmd2.Parameters.AddWithValue("@importe_cobra", Convert.ToDecimal(gridView1.GetRowCellValue(i,colimportePagar).ToString()));
                        cmd2.Parameters.AddWithValue("@observaciones", gridView1.GetRowCellValue(i,colComentario).ToString());
                      //  cmd.Parameters.AddWithValue("@cobranza_nombre", txt_firma_cobranza.Text);
                        cmd2.Parameters.AddWithValue("@fecha_captura", DateTime.Now.ToShortDateString());
                        cmd2.Parameters.AddWithValue("@importe_real", Convert.ToDecimal(gridView1.GetRowCellValue(i, colimportePagar).ToString()));
                        //cmd.Parameters.AddWithValue("@monto", txt_monto.Text);
                        //   cmd.Parameters.AddWithValue("@cantidad_letra", txt_letra_importe.Text);

                        cmd2.Parameters.AddWithValue("@importe_fac", Convert.ToDecimal(gridView1.GetRowCellValue(i,colImporte).ToString()));


                        cmd2.Parameters.AddWithValue("@cheque_banco",txtCheque.Text);
                        cmd2.Parameters.AddWithValue("@fecha_banco", masked_fecha.Text);
                        cmd2.Parameters.AddWithValue("@mov", gridView1.GetRowCellValue(i, colMov).ToString());




                    //    cmd.Parameters.AddWithValue("@firma_cliente", txt_firma_cliente.Text);
                        //
                        // cmd.Parameters.AddWithValue("tipo_pago", combo_tipo.Text);
                        cmd2.ExecuteNonQuery();
                    }
            }
                catch(SqlException ex)
                {
                 MessageBox.Show(ex.ToString());
                }

           */
        
        
        }


        public string regresaAgenteNombre(string agente)
        {
            /*
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select nombre from agente  where agente='" + agente + "'";
            var resultado = cmd.ExecuteScalar().ToString();
            return resultado.ToString();
            */
            return agente;
        }
        
        public void generaRecibo(string ultimofolio)
        {

            string folio = ultimofolio;
            if (sucursal.Equals("GDL"))
                folio = "G" + ultimofolio;
            else folio = "C" + ultimofolio;
            DataTable dtInfoCte = new DataTable();
            dtInfoCte.Columns.Add("folio", typeof(string));
            dtInfoCte.Columns.Add("nombre", typeof(string));
            dtInfoCte.Columns.Add("cliente", typeof(string));
            dtInfoCte.Columns.Add("formaPago", typeof(string));
            dtInfoCte.Columns.Add("rfc", typeof(string));
            dtInfoCte.Columns.Add("banco", typeof(string));
            dtInfoCte.Columns.Add("cuenta", typeof(string));
            dtInfoCte.Columns.Add("clabe", typeof(string));
            dtInfoCte.Columns.Add("tarjeta", typeof(string));
            dtInfoCte.Columns.Add("cheque", typeof(string));
            dtInfoCte.Columns.Add("documento", typeof(string));
            dtInfoCte.Columns.Add("importeDoc", typeof(double));
            dtInfoCte.Columns.Add("despp", typeof(double));
            dtInfoCte.Columns.Add("importePagar", typeof(double));
            dtInfoCte.Columns.Add("comentarios", typeof(string));
            dtInfoCte.Columns.Add("agente", typeof(string));
            dtInfoCte.Columns.Add("fecha", typeof(DateTime));
            dtInfoCte.Columns.Add("total", typeof(double));
            //DataTable dtFactura = new DataTable();
            //dtFactura.Columns.Add("documento", typeof(string));
            //dtFactura.Columns.Add("importeDoc", typeof(double));
            //dtFactura.Columns.Add("despp", typeof(double));
            //dtFactura.Columns.Add("importePagar", typeof(double));
            //dtFactura.Columns.Add("comentarios", typeof(string));

            DataSet ds = new DataSet();
            //ds.Tables.Add(dtInfoCte);
            //ds.Tables.Add(dtFactura);
       //     ds.WriteXmlSchema(@"S:\XML\cteRecoge\recibo3.xml");

            if (!validadordatoscte.Validate())
            {
                MessageBox.Show("Ingresa todos los datos");

            }
            else
            {
                //   dtInfoCte.Rows.Add(txtFolio.Text, txtRazonSocial.Text, txtNumCte.Text, radioGroup1.EditValue.ToString()+" " + radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description, txtRFCbANCO.Text, txtBanco.Text, txtCuenta.Text, txtClabe.Text, txtTarjeta.Text, txtCheque.Text);
                Console.WriteLine(gridView1.RowCount);
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    dtInfoCte.Rows.Add(folio, txtRazonSocial.Text, txtNumCte.Text, radioGroup1.EditValue.ToString() + " " + radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description, txtRFCbANCO.Text, txtBanco.Text, txtCuenta.Text, txtClabe.Text, txtTarjeta.Text, txtCheque.Text, gridView1.GetRowCellValue(i, colMov).ToString() + " " + gridView1.GetRowCellValue(i, colMovid).ToString(), gridView1.GetRowCellValue(i, colImporte).ToString(), gridView1.GetRowCellValue(i, colDesPP).ToString(), gridView1.GetRowCellValue(i, colImporteFinal).ToString(), gridView1.GetRowCellValue(i, colComentario).ToString(),regresaAgenteNombre(agente),DateTime.Now.ToShortDateString(),Convert.ToDouble( txtTotal.Text));
                    //    dtFactura.Rows.Add(gridView1.GetRowCellValue(i, colMov).ToString()+" " + gridView1.GetRowCellValue(i, colMovid).ToString(), gridView1.GetRowCellValue(i, colImporte).ToString(), gridView1.GetRowCellValue(i, colDesPP).ToString(), gridView1.GetRowCellValue(i, colImporteFinal).ToString(), gridView1.GetRowCellValue(i, colComentario).ToString());
                    Console.WriteLine(gridView1.GetRowCellValue(i, colMov).ToString() + " " + gridView1.GetRowCellValue(i, colMovid).ToString());
                }
                ds.Tables.Add(dtInfoCte);
             //  ds.WriteXmlSchema(@"S:\XML\cteRecoge\recibo3.xml");
                //ds.Tables.Add(dtFactura);
                miniCFDI3 mini = new miniCFDI3();
                mini.DataSource = ds;
              //  reciboCDFI rcfdi = new reciboCDFI();
               // rcfdi.DataSource = ds;
                using (ReportPrintTool printTool = new ReportPrintTool(mini))
                {
                    // Invoke the Ribbon Print Preview form modally, 
                    // and load the report document into it.
                    printTool.ShowRibbonPreviewDialog();

                    // Invoke the Ribbon Print Preview form
                    // with the specified look and feel setting.
                    printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                }
                 string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();
            mini.ExportToPdf(carpeta + "\\reciboCobro.pdf");
            }

        
        
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                labelFechaCheque.Visible = true;
                masked_fecha.Visible = true;
            }
            else
            {
                labelFechaCheque.Visible = false;
                masked_fecha.Visible = false;
            }
            actualizaTotal();
        }

        private void txtFolio_Leave(object sender, EventArgs e)
        {
            var resultado="SI";
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            SqlCommand cmd = new SqlCommand("", myConnection);
            myConnection.Open();
            cmd.CommandText=  @"         if exists(select id from indarneg.dbo.recibo_folios where "+txtFolio.Text+">=folio_inicio and "+txtFolio.Text+@"<=folio_fin )
	                                    begin
			                                    select 'SI' AS resultado
	                                    end
	                                    ELSE SELECT 'NO' AS resultado";
            try
            {
                resultado = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException )
            { 
             resultado="NO";
            }
            Console.WriteLine(resultado.ToString());
            if (!resultado.ToString().Equals("SI"))
                MessageBox.Show("Es numero de folio no existe");

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargaDocumentosLibres();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridView1.UpdateSummary();
            actualizaTotal();
        }



        public void actualizaTotal()
        {
            /*
            double suma = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {

                if (gridView1.GetRowCellValue(i, colMov).ToString().Equals("Factura Indar"))
                {
                    suma = suma + (Convert.ToDouble(gridView1.GetRowCellValue(i, colImporte).ToString()) * (1 - Convert.ToDouble(gridView1.GetRowCellValue(i, colDesPP).ToString()) / 100));
                }
                if(gridView1.GetRowCellValue(i, colMov).ToString().Contains("N. Credito"))
               suma= suma + Convert.ToDouble(gridView1.GetRowCellValue(i,colImporte).ToString())*.96;
                if (gridView1.GetRowCellValue(i, colMov).ToString().Contains("Cobro"))
                    suma = suma + Convert.ToDouble(gridView1.GetRowCellValue(i, colImporte).ToString());
                if (suma < 0)
                    txtTotal.Text = "0.00";
                else txtTotal.Text = suma.ToString();
            }  */
            try
            {
                var summaryValue = gridView1.Columns["colImporteFinal"].SummaryItem.SummaryValue;
                txtTotal.Text = summaryValue.ToString();
                if (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description.ToString().Equals("Vale Empleado"))
                    txtTotal.Text = "0.00";
            }
            catch (Exception )
            {
                txtTotal.Text = "0.00"; 
            }
        }

        private void btnTestBorrar_Click(object sender, EventArgs e)
        {
            LoginUserControl myControl = new LoginUserControl();
            if (DevExpress.XtraEditors.XtraDialog.Show(myControl, "Email Alternativo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // do something 
                string email = myControl.teLogin.Text;
                RegexUtilities util = new RegexUtilities();
                if (util.IsValidEmail(email))
                    MessageBox.Show("Si es valido");
                else MessageBox.Show("No es valido");
            }

            /*
            var summaryValue = gridView1.Columns["colImporteFinal"].SummaryItem.SummaryValue;
            MessageBox.Show(summaryValue.ToString());   */
        }


        public static Attachment regresaAttachment()
        {

            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();
           
            Attachment attachment;

            attachment = new System.Net.Mail.Attachment(carpeta + "\\reciboCobro.pdf");



            return attachment;
        }


        public string regresaIdCliente(string cliente)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var idcliente = (from i in ctx.Customers
                                 where i.companyId.Equals(cliente)
                                 select i.internalid).FirstOrDefault();
                return idcliente.ToString();
                               

            }
           
        }

        public static void enviaEmails( string cliente, string email, string folio)
        {

            
            using (SmtpClient smtpClient = new SmtpClient("sndr2.vinetworks.net"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("mailing@sndr.indar.com.mx", "q0xfA&08");
                //     smtpClient.Credentials = new System.Net.NetworkCredential("expo@indar.com.mx", "Fin870710$");
                smtpClient.EnableSsl = true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                delegate(object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                 System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                { return true; };

                using (MailMessage message = new MailMessage())
                {
                    try
                    {
                        MailAddress AddressFrom = new MailAddress("no_reply@indar.com.mx");
                        message.From = AddressFrom;
                        MailAddress AddressTo = new MailAddress(email);
                        message.Subject = "Envio de comprobante Recibo de Cobro, " + folio + " ";
                        message.To.Add(AddressTo);
                        message.CC.Add("sistemas@indar.com.mx");
                        message.Body = @"Usted esta recibiendo un comprobante de Recibo de Cobro";
 

                        LinkedResource LinkedImage = new LinkedResource(@"C:\Borrar\Logo_Indar.jpg");
                        LinkedImage.ContentId = "MyPic";
                        //Added the patch for Thunderbird as suggested by Jorge
                        //    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);

                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                          " <img src=cid:MyPic>  <p> Usted esta recibiendo un comprobante de Recibo de Cobro</br> </p>",
                          null, "text/html");
                        htmlView.LinkedResources.Add(LinkedImage);
                        message.AlternateViews.Add(htmlView);
                        message.Attachments.Add(regresaAttachment());
                   
                        smtpClient.Send(message);
                    }
                    catch (Exception e)
                    {
                       
                    }
                }


            }
          

        }


    }



    public class LoginUserControl : XtraUserControl
    {
        public TextEdit teLogin;
        public LoginUserControl()
        {
            
            LayoutControl lc = new LayoutControl();
            lc.Dock = DockStyle.Fill;
           teLogin = new TextEdit();
           LabelControl label = new LabelControl();
           label.Text = "Ingresa correo electronico  alterno";
           lc.AddItem(String.Empty,label);
            lc.AddItem(String.Empty, teLogin).TextVisible = false;           
            this.Controls.Add(lc);
            this.Dock = DockStyle.Top;
        }
    }
}
