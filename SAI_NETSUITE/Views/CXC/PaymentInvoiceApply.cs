using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Models.Transaccion;
using SAI_NETSUITE.Views.CXC.Combinacion;
using SAI_NETSUITE.Controllers.CXC;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace SAI_NETSUITE.Views.CXC
{
    public partial class PaymentInvoiceApply : UserControl
    {
        List<string> listaTimbrar = new List<string>();
        DataTable dt;
        string usuario;
        public PaymentInvoiceApply(string usr)
        {
            usuario = usr;
            InitializeComponent();
        }

        private void PaymentInvoiceApply_Load(object sender, EventArgs e)
        {
            cargaZonas();
           
           dt= InicializaTabla();
            cargaFormaPagoSAT();
        }


        public void cargaFormaPagoSAT()
        {
            Controllers.CXC.PaymentInvoiceApplyController piac = new PaymentInvoiceApplyController();
            comboSAT.Properties.Items.AddRange(piac.regresaListaFormaPago().Select(i=> i.FORMA_DE_PAGO_V3_3_NUMBER+" "+i.FORMA_DE_PAGO_V3_3_NAME).ToArray());

        }

        public void cargaZonas()
        {
            Controllers.CXC.ArqueoController ac = new Controllers.CXC.ArqueoController();
            searchLookUpEdit1.Properties.DisplayMember = "zona";
            searchLookUpEdit1.Properties.ValueMember = "id";
            searchLookUpEdit1.Properties.DataSource = ac.regresaZonas();
        }

        private void btnCargarInfo_Click(object sender, EventArgs e)
        {
          //  btnEnviarNetsuite.Enabled = false;
            gridView1.ActiveFilterString = "";
            layoutSuma.Control.BackColor = Color.White;
            if (dxValidationProvider1.Validate())
            {
                btnCargarInfo.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                if (!backgroundWorkerCarga.IsBusy)
                    backgroundWorkerCarga.RunWorkerAsync(argument: searchLookUpEdit1.EditValue.ToString());
            }
            else MessageBox.Show("Selecciona una Zona");

        }

        private void backgroundWorkerCarga_DoWork(object sender, DoWorkEventArgs e)
        {
            Controllers.CXC.PaymentInvoiceApplyController piac = new Controllers.CXC.PaymentInvoiceApplyController();
            PaymentInvoiceApplyModel piam = piac.regresaPortafolio((string)e.Argument);
            ///LLENA EL CAMPO DE FECHA
            foreach (var documentos in piam.result.Documentos)
            {
                DateTime dateTime2;

                if (DateTime.TryParse(documentos.FechaVencimiento, out dateTime2))
                {
                    documentos.FechaVencimientov2 = Convert.ToDateTime(documentos.FechaVencimiento);
                }
                else documentos.FechaVencimientov2 = Convert.ToDateTime("01/01/1900");
                //documentos.FechaVencimientov2 =Convert.ToDateTime(  DateTime.TryParse(documentos.FechaVencimiento, out dateTime2)?"01/01/1900": documentos.FechaVencimiento); // Convert.ToDateTime(documentos.FechaVencimiento.Equals("")?"01/01/1900":documentos.FechaVencimiento);
                documentos.DescuentoFactura = Convert.ToDecimal(documentos.DescuentoCliente.Equals("")?"0":documentos.DescuentoCliente.Remove(documentos.DescuentoCliente.Length - 1, 1));
                documentos.DescuentoTotal = Convert.ToDouble(documentos.DescuentoTotal == null ? Convert.ToDouble("0") : documentos.DescuentoTotal);
            }


            e.Result = piam;
        }

        private void backgroundWorkerCarga_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PaymentInvoiceApplyModel piam= (PaymentInvoiceApplyModel) e.Result;
            foreach (var item in piam.result.Documentos)
            {
                if (item.LimiteCredito.GetValueOrDefault() == 0)
                {
                    item.LimiteCredito = 0;
                }

            }
            gridControl1.DataSource = piam.result.Documentos.Where(x => !x.Documento.Contains("CustPymt"));

            // piam.result.Documentos.Where(x=>!x.Documento.Contains("CustPymt"));
            gridControl2.DataSource = piam.result.Documentos.Where(x => x.Documento.Contains("CustPymt"));
            btnCargarInfo.ImageOptions.Image = null;
           
        }

        private void gridPago_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {/*
            gridView1.ActiveFilterString = "";
            string cliente = gridPago.GetFocusedRowCellValue(colPaymentCliente).ToString();
            gridView1.ActiveFilterString = "([Cliente]='" + cliente + "')";*/
        }

        private void gridPago_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gridView1.ClearSelection();
            if (!backgroundWorkerCarga.IsBusy)
            {
                gridView1.ActiveFilterString = "";
                if (gridView1.RowCount > 0)
                {
                    gridView1.ActiveFilterString = "";
                    //// quita la fecha del pago a todo
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, colfechaPagoexternal, "");
                    }
                    string cliente = gridPago.GetFocusedRowCellValue(colPaymentCliente).ToString();
                    gridView1.ActiveFilterString = "([Cliente]='" + cliente + "')";
                    ///Se pone la fecha de pago a lo que aparecen
                    for (int i = 0; i < gridView1.RowCount; i++) 
                    {
                        gridView1.SetRowCellValue(i, colfechaPagoexternal, gridPago.GetFocusedRowCellValue(colPaymentFecha).ToString());
                    }
                    if (gridView1.RowCount < 10)
                        btnMagic.Enabled = true;
                    else btnMagic.Enabled = false;

                    if (gridView1.RowCount > 0)
                    {
                        layoutNombreCliente.Control.Text = gridView1.GetRowCellValue(0, "Cliente").ToString();
                        layoutCob.Control.Text = gridView1.GetRowCellValue(0, "Cobrador").ToString();
                        layoutVen.Control.Text = gridView1.GetRowCellValue(0, "Vendedor").ToString();
                        layoutZona.Control.Text = gridView1.GetRowCellValue(0, "Zona").ToString();
                        layoutLimite.Control.Text = gridView1.GetRowCellValue(0, "LimiteCredito").ToString();
                        layoutPago.Control.Text = gridPago.GetFocusedRowCellValue(colPaymentSaldoPendiente).ToString();
                        comboSAT.Text = regresaFormadePagoIMR(gridPago.GetFocusedRowCellValue(colPaymentmetodoPago).ToString());
                        layoutSuma.Control.Text = "0";
                        memoNota.Text= gridPago.GetFocusedRowCellValue(colNota).ToString();

                        dt.Rows.Clear();


                    }
                    else MessageBox.Show("No hay documentos de este cliente por aplicar");
                }
            }
            else MessageBox.Show("Espera a que cargue la info (-_-)!");

        }


        public string regresaFormadePagoIMR(string idFormapago)
        {
            using (IWSEntities ctx = new IWSEntities())
            { if (!idFormapago.Equals(""))
                {
                    var regresa = ctx.FORMA_DE_PAGO_V3_3.Where(x => x.FORMA_DE_PAGO_V3_3_NUMBER.Equals(idFormapago)).Select(x => x.FORMA_DE_PAGO_V3_3_NUMBER + " " + x.FORMA_DE_PAGO_V3_3_NAME).FirstOrDefault().ToString();
                    return regresa.ToString();
                }
                else return "99 Por definir";
            }
              

        }

        public DataTable InicializaTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("tranid", typeof(string));
            dt.Columns.Add("FacturaID", typeof(string));
            dt.Columns.Add("FacturaMonto", typeof(decimal));
            dt.Columns.Add("FacturaMontoFix", typeof(decimal));
            dt.Columns.Add("descuento16", typeof(decimal));
            dt.Columns.Add("descuento10", typeof(decimal));
            dt.Columns.Add("ImporterBruto", typeof(decimal));
            dt.Columns.Add("DiffDay", typeof(int));

            return dt;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            layoutSuma.Control.BackColor = Color.White;
            if (gridView1.SelectedRowsCount > 0)
            {
                //decimal suma=0;
                // for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                // {
                //     decimal parcial = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],colA_pagar).ToString());
                //     suma = suma + parcial;
                // }
                // layoutSuma.Control.Text = suma.ToString();
                // if (!layoutPago.Control.Text.Equals(""))
                // {
                //       decimal pago=Convert.ToDecimal(layoutPago.Control.Text);
                //       if ((pago - suma) >= -3 && (pago - suma) <= 3)
                //       /*    btnEnviarNetsuite.Enabled = true;
                //       else btnEnviarNetsuite.Enabled = false; */
                //     layoutSuma.Control.BackColor = Color.LawnGreen;
                // }
                actualizaGridFacturas();
            }
            if (gridView1.SelectedRowsCount == 0)
            {
                dt.Rows.Clear();
                layoutSuma.Control.BackColor = Color.White;
                layoutSuma.Control.Text = "0";

            }
        }

        private void actualizaGridFacturas()
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    //PRIMERO BUSCA SI ES NUEVO
                    string facturaSelect = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colinternalId).ToString();
                    bool existe = dt.AsEnumerable().Any(row => facturaSelect == row.Field<string>("FacturaID"));
                    if (!existe)
                        dt.Rows.Add(
                            gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colNumDoc).ToString(),
                            facturaSelect,
                             gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colA_pagar).ToString(),
                             gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colA_pagar).ToString(),
                             gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],colDescuento16).ToString(),
                             gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],coldiscount10).ToString(),
                             gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],colImporteBruto).ToString(),
                             gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],colrestafecha).ToString()
                            );                 
                }
                gridControl3.DataSource = dt;
                if (gridView1.SelectedRowsCount != gridViewFinalFactura.RowCount)
                {
                    
                   
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int bandera = 0;
                        for (int j = 0; j < gridView1.SelectedRowsCount; j++)
                        {
                            if (dt.Rows[i]["FacturaID"].ToString().Equals(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[j], colinternalId).ToString()))
                                bandera = 1;
                         
                        }
                        if (bandera == 0)
                            dt.Rows.RemoveAt(i);

                    }
                }
                sumarFacturas();

               

            }
           
        }


        public void sumarFacturas()
        {
            decimal suma = 0;
            for (int i = 0; i < gridViewFinalFactura.RowCount; i++)
            {
                decimal parcial = Convert.ToDecimal(gridViewFinalFactura.GetRowCellValue(i, colFinalFacturaMontoFix).ToString());
                suma = suma + parcial;
            }
            layoutSuma.Control.Text = suma.ToString();
            if (!layoutPago.Control.Text.Equals(""))
            {
                decimal pago = Convert.ToDecimal(layoutPago.Control.Text);
             ///   if ((pago - suma) >= -3 && (pago - suma) <= 3)
                   if(pago==suma)
                    layoutSuma.Control.BackColor = Color.LawnGreen;
                else layoutSuma.Control.BackColor = Color.White;
            }

        }
        private void btnEnviarNetsuite_Click(object sender, EventArgs e)
        {  ///agregar validacion del importe
            
              //  MessageBox.Show("No olvides cambiar la forma de Pago!!");
            
            if (!layoutPago.Control.Text.Equals(layoutSuma.Control.Text))
            {
                DialogResult res = MessageBox.Show("La suma no cuadra con el pago ¿continuar?  \n ", "ATENCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

                if (gridView1.SelectedRowsCount > 0 && !comboSAT.Text.Contains("99"))
            {
                string nombreNetSuite =new PaymentInvoiceApplyController().regresaNombreNetsuite(usuario);
                StringBuilder sb = new StringBuilder(); //////
                sb.Append("ExternalId,Pago,PagoMonto,Facturaid,ImporteFactura,sat,sai");
                sb.Append("\r\n");
                string ExternalId = DateTime.Now.ToFileTime().ToString();
                List<listaFacturasPorEnviarPago> lista = new List<listaFacturasPorEnviarPago>();
                for (int i = 0; i < gridViewFinalFactura.RowCount; i++)
                {
                    /* string pagoID = gridPago.GetFocusedRowCellValue(colPaymentinternalId).ToString();
                     string pagoMonyo = layoutPago.Control.Text;
                     string FacturaID = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colinternalId).ToString();
                     string FacturaMonto = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colA_pagar).ToString();

                     sb.Append(ExternalId + "," + pagoID + "," + pagoMonyo + "," + FacturaID + "," + FacturaMonto);
                     sb.Append("\r\n");*/

                    listaFacturasPorEnviarPago aux = new listaFacturasPorEnviarPago()
                    {
                        pagoID = gridPago.GetFocusedRowCellValue(colPaymentinternalId).ToString(),
                        pagoMonyo = Convert.ToDecimal(layoutPago.Control.Text.ToString()),
                        FacturaID = gridViewFinalFactura.GetRowCellValue(i, colFinalFacturaID).ToString(), //gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colinternalId).ToString(),
                        FacturaMonto = Convert.ToDecimal(gridViewFinalFactura.GetRowCellValue(i, colFinalFacturaMontoFix).ToString()),
                        sat = comboSAT.Text,
                        sai = nombreNetSuite
                       
                    };
                    lista.Add(aux);
                }
                //REVISO SI   SUMA DE FACTURAS ES MAYOR +-3 para corregir
                decimal suma =(decimal) lista.Sum(x => x.FacturaMonto);
                if ((lista[0].pagoMonyo - lista.Sum(x => x.FacturaMonto) > -3 && (lista[0].pagoMonyo - lista.Sum(x => x.FacturaMonto))<0))
                    {
                    lista[0].FacturaMonto = (lista[0].pagoMonyo - lista.Sum(x => x.FacturaMonto))+lista[0].FacturaMonto ;
                    }

                foreach (var item in lista)
                {
                    sb.Append(ExternalId + "," + item.pagoID + "," + item.pagoMonyo.ToString() + "," + item.FacturaID + "," + item.FacturaMonto.ToString()+","+item.sat+","+item.sai);
                    sb.Append("\r\n");
                }

             
                Console.WriteLine(sb);
                PaymentInvoiceApplyController piac = new PaymentInvoiceApplyController();
                ApplyPaymentCSVModel apcm = new ApplyPaymentCSVModel()
                {
                    name = "Pago" + gridPago.GetFocusedRowCellValue(colPayment).ToString(),
                    content = sb.ToString()
                };
                if (piac.ApplyPaymentMethod(apcm))
                {
                  
                        listaTimbrar.Add(gridPago.GetFocusedRowCellValue(colPayment).ToString());
                    gridTimbrar.DataSource = listaTimbrar.ToArray();
                    MessageBox.Show("PAGO ENVIADO CON EXITO!! \n No olvides borrar el archivo el viernes");
                }
                else
                {
                    MessageBox.Show("ERROR \n Por favor presiona CTRL+V en un correo y mandalo a rvelasco@indar.com.mx");
                    Clipboard.Clear();
                    Clipboard.SetText(sb.ToString());
                }
                layoutSuma.Control.BackColor = Color.White;

            
            }
            else MessageBox.Show("Cambia la Forma de Pago y/o selecciona al menos una factura");



        }

        

        private void btnMagic_Click(object sender, EventArgs e)
        {
            layoutSuma.Control.BackColor = Color.White;
            List<decimal> myList = new List<decimal>();
            decimal objetivo = Convert.ToDecimal(layoutPago.Control.Text);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                
                    decimal numero = Convert.ToDecimal(gridView1.GetRowCellValue(i, colA_pagar).ToString());
                    myList.Add(numero);
                

            }
            /*
            var allMatchingCombos = new List<IList<decimal>>();
            for (int lowerIndex = 1; lowerIndex < myList.Count; lowerIndex++)
            {
                IEnumerable<IList<decimal>> matchingCombos = new Combinations<decimal>(myList, lowerIndex, GenerateOption.WithoutRepetition)
                    .Where(c => c.Sum() >= (objetivo-3) && c.Sum()<=(objetivo+3));
                allMatchingCombos.AddRange(matchingCombos);
            }
            foreach (var matchingCombo in allMatchingCombos)
                Console.WriteLine(string.Join(",", matchingCombo));
            if (allMatchingCombos.Count > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    decimal actual = Convert.ToDecimal(gridView1.GetRowCellValue(i, colA_pagar).ToString());
                    foreach (var matchingCombo in allMatchingCombos[0])
                    {
                        if (matchingCombo == actual)
                        {
                            gridView1.SelectRow(i);
                        }


                    }

                }
            }*/
            
            
            Loop l = new Loop();
          List<decimal> listaEncontrado = l.FindCombination(myList, Convert.ToDecimal(layoutPago.Control.Text));
            if (listaEncontrado.Count > 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    decimal actual = Convert.ToDecimal(gridView1.GetRowCellValue(i, colA_pagar).ToString());
                    foreach (var item in listaEncontrado)
                    {
                        if(item==actual)
                            gridView1.SelectRow(i);

                    }
                }
            }



        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\Payments.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\Payments.xlsx";
            pdfexport.Start();

            gridTimbrar.ExportToXlsx(carpeta + "\\Timbrar.xlsx");
            Process pdfexport2 = new Process();
            pdfexport2.StartInfo.FileName = "EXCEL.exe";
            pdfexport2.StartInfo.Arguments = carpeta + "\\Timbrar.xlsx";
            pdfexport2.Start();
        }

        private void gridViewFinalFactura_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BandedGridView view = sender as BandedGridView;
           // if (view == null) return;
            if (e.Column.Caption.Equals("FINAL"))
            sumarFacturas();
            else return;
        }
    }


    public class listaFacturasPorEnviarPago
    {
      public  string pagoID { get; set; }
        public decimal? pagoMonyo { get; set; }
        public string FacturaID { get; set; }
        public decimal? FacturaMonto { get; set; }
        public string sat { get; set; }
        public string sai { get; set; }

    }
}
