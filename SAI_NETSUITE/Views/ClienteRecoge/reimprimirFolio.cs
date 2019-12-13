using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using System.Diagnostics;

namespace SAI_NETSUITE.Views.ClienteRecoge 
{
    public partial class reimprimirFolio : Form
    {
        string sqlString;
        public reimprimirFolio(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }

        private void reimprimirFolio_Load(object sender, EventArgs e)
        {
            cargaFolios();
        }





        public void generaRecibo()
        { 
       
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

          
            DataSet ds = new DataSet();
       
            
          //  ds.WriteXmlSchema(@"S:\XML\cteRecoge\recibo3.xml");

           
                //   dtInfoCte.Rows.Add(txtFolio.Text, txtRazonSocial.Text, txtNumCte.Text, radioGroup1.EditValue.ToString()+" " + radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description, txtRFCbANCO.Text, txtBanco.Text, txtCuenta.Text, txtClabe.Text, txtTarjeta.Text, txtCheque.Text);
                Console.WriteLine(gridView1.RowCount);
                SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("",myConnection);
                    if (gridView1.GetFocusedRowCellValue(colsucursal).ToString().Equals("GDL"))
                    {
                        cmd.CommandText = @"select 'G'+CONVERT(varchar(10), folioGDL07) as folio,nombre_cliente,cliente,tipo_pago,rfcBanco,nombreBanco,numcuenta,clabe,tarjetaBanco,cheque_banco,mov+' '+num_fac,importeDocumento, isnull(porciento,0) as despp,importe_cobra,observaciones,agente,fecha,isnull(total,0) as total from  indarneg.dbo.reciboCobro_CteRecoge
                                        where foliogdl07=" + gridView1.GetFocusedRowCellValue(colfolio).ToString().Remove(0, 1);
                        Debug.WriteLine(cmd.CommandText);
                    }
                    else
                        cmd.CommandText = @" select 'C'+CONVERT(varchar(10),folio) as folio,nombre_cliente,cliente,tipo_pago,rfcBanco,nombreBanco,numcuenta,clabe,tarjetaBanco,cheque_banco,mov+' '+num_fac,importeDocumento, isnull(porciento,0) as despp,importe_cobra,observaciones,agente,fecha,isnull(total,0) as total from  indarneg.dbo.reciboCobro_CteRecoge
                                        where folio=" + gridView1.GetFocusedRowCellValue(colfolio).ToString().Remove(0, 1);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read() && sdr.HasRows)
                    {
                        dtInfoCte.Rows.Add(sdr.GetValue(0).ToString(), sdr.GetValue(1).ToString(), sdr.GetValue(2).ToString(), sdr.GetValue(3).ToString(), sdr.GetValue(4).ToString(), sdr.GetValue(5).ToString(), sdr.GetValue(6).ToString(), sdr.GetValue(7).ToString(), sdr.GetValue(8).ToString(), sdr.GetValue(9).ToString(), sdr.GetValue(10).ToString(), Convert.ToDouble(sdr.GetValue(11).ToString()), Convert.ToDouble(sdr.GetValue(12).ToString()), Convert.ToDouble(sdr.GetValue(13).ToString()), sdr.GetValue(14).ToString(), regresaAgenteNombre(sdr.GetValue(15).ToString()),Convert.ToDateTime(sdr.GetValue(16).ToString()).ToShortDateString(),Convert.ToDouble(sdr.GetValue(17).ToString()));
                        //    dtFactura.Rows.Add(gridView1.GetRowCellValue(i, colMov).ToString()+" " + gridView1.GetRowCellValue(i, colMovid).ToString(), gridView1.GetRowCellValue(i, colImporte).ToString(), gridView1.GetRowCellValue(i, colDesPP).ToString(), gridView1.GetRowCellValue(i, colImporteFinal).ToString(), gridView1.GetRowCellValue(i, colComentario).ToString());
                    }
                ds.Tables.Add(dtInfoCte);
                //ds.WriteXmlSchema(@"S:\XML\cteRecoge\recibo3.xml");
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
            

        
        
        
        
        
        
        }


        public string regresaAgenteNombre(string agente)
        {/*
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select nombre from agente  where agente='" + agente + "'";
            var resultado = cmd.ExecuteScalar().ToString();
            return resultado.ToString();
            */
            return agente;
        }

        public void cargaFolios()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"select id,cliente,nombre_cliente,mov,num_fac,
                            CASE WHEN folio IS NULL then 'G'+CONVERT(varchar(10), folioGDL07) else 'C'+CONVERT(varchar(10),folio) END  AS folio,
                            CASE WHEN folio is null then 'GDL' else 'CCI' END AS sucursal
                            ,fecha from  indarneg.dbo.reciboCobro_CteRecoge  ORDER BY ID";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        
        
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount!=1)
            {
                MessageBox.Show("SOLO TIENES QUE SELECCIONAR UN FOLIO UNICAMENTE");
            }
            else
            {

                generaRecibo();
            }
        }
    }
}
