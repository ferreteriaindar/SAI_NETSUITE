using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SAI_NETSUITE.Controllers.PostVenta.ConfirmacionController;
using SAI_NETSUITE.Models.Transaccion;
using SAI_NETSUITE.IWS;
using Newtonsoft.Json;
using SAI_NETSUITE.Controllers.PostVenta;
using SAI_NETSUITE.Models.Catalogos;

namespace SAI_NETSUITE.Views.PostVenta
{
    public partial class Confirmacion : UserControl
    {

        DataTable dt = new DataTable();
        int tipoPrincipal;
        string usuario, perfil;
        Token token;
        public Confirmacion(string perfil,string usuario,Token token)
        {
            this.perfil = perfil;
            this.usuario = usuario;
            this.token = token;
            InitializeComponent();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Confirmacion_Load(object sender, EventArgs e)
        {
            inicializaDt();
          
        }

       

        private void inicializaDt()
        {
            dt.Columns.Add("factura", typeof(string));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("fechaHora", typeof(string));
            dt.Columns.Add("persona", typeof(string));
            dt.Columns.Add("comentarios", typeof(string));
            dt.Columns.Add("facturaid", typeof(int));
            dt.Columns.Add("cliente", typeof(string));
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnBuscarFactura_Click(null, null);
                txtFactura.Text = "";
                txtFactura.Select();
            }

        }

        private void buscaFactura(string v)
        {
            
        }

        private void btnBuscarEmbarque_Click(object sender, EventArgs e)
        {
            Ocultar(0);
            Controllers.PostVenta.ConfirmacionController cc = new Controllers.PostVenta.ConfirmacionController();
            DataSet ds = cc.regresaembarque(txtEmbarque.Text);
            if (ds.Tables[0].Rows.Count < 1)
                MessageBox.Show("No existe y/o no est en TRANSITO");
            else
                gridControl1.DataSource = ds.Tables[0];
        }

        public void Ocultar(int tipo)
        {
            //tipo=0 es embarque  tipo=1  es  por factura
            switch(tipo)
            {
                case 0: 
                        labelFactura.Visible = false;
                        txtFactura.Visible = false;
                        btnBuscarFactura.Visible = false;
                    tipoPrincipal = tipo;
                    break;
                case 1:  labelEmbarque.Visible = false;
                         txtEmbarque.Visible = false;
                        btnBuscarEmbarque.Visible = false;
                    tipoPrincipal = tipo;
                    break;

            }
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            Ocultar(1);
            DataRow dr = new Controllers.PostVenta.ConfirmacionController().regresaFactura(txtFactura.Text, dt.NewRow());
            if (dr["factura"].ToString().Equals("ENTREGADA") || dr["factura"].ToString().Equals("NO EXISTE"))
                MessageBox.Show("FACTURA " + dr["FACTURA"].ToString());
            else dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
        }

        private void btnAplicarFecha_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0 && dxValidationProvider1.Validate())
            {
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    // if(gridView1.GetRowCellValue(gridView3.GetSelectedRows()[i], colTablaCheck).ToString().Equals("True"))
                    gridView1.SetRowCellValue(gridView1.GetSelectedRows()[i], colfechaHora, dateEdit1.EditValue.ToString());
                    gridView1.SetRowCellValue(gridView1.GetSelectedRows()[i], colEstado, "ENTREGADO");
                }
            }
            else MessageBox.Show("Selecciona al menos un movimiento");
        }

        private void txtEmbarque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            btnBuscarEmbarque_Click(null, null);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<UpdateInvoiceModel> lista = (List<UpdateInvoiceModel>)e.Argument;
            int avance = 0;
            foreach (var Invoice in lista)
            {

                Controllers.PostVenta.ConfirmacionController cc = new Controllers.PostVenta.ConfirmacionController();
               string resultado= cc.insertaFechaVencimientoNetsuite(Invoice,token);
                if (resultado.Contains("true"))
                {
                   
                    backgroundWorker1.ReportProgress(avance);
                    avance++;
                    Console.WriteLine(Invoice.internalId);
                }
                else MessageBox.Show("ERROR "+ JsonConvert.SerializeObject(Invoice));


            }


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelAvance.Text = e.ProgressPercentage.ToString() + "/" + gridView1.RowCount.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso Terminado");
            gridControl1.DataSource = null;
            labelAvance.Text = "0/1";
            pictureBox1.Visible = false;
        }

        private void btnNopresionar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("factura,fecha");
            sb.Append("\r\n");
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
               sb.Append(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],colfacturaid).ToString()+","+Convert.ToDateTime( gridView1.GetRowCellValue( gridView1.GetSelectedRows()[i], colfechaHora).ToString()).ToString("dd/MM/yyyy")+",");
                sb.Append("\r\n");
            }
            Console.WriteLine(sb);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           // pictureBox1.Visible = true;
            DataTable data = new DataTable();
            data.Columns.Add("factura", typeof(string));
            data.Columns.Add("estado", typeof(string));
            data.Columns.Add("fechaHora", typeof(string));
            data.Columns.Add("persona", typeof(string));
            data.Columns.Add("comentarios", typeof(string));
            data.Columns.Add("facturaid", typeof(int));

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                data.Rows.Add(
                                gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colFactura).ToString(),
                                gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colEstado).ToString(),
                                gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfechaHora).ToString(),
                                gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colPersona).ToString(),
                                gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colcomentarios).ToString(),
                               Convert.ToInt32( gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfacturaid).ToString()==""?"0": gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfacturaid).ToString())
                                );
            }
            bool resultado;
            if (tipoPrincipal == 0)
                resultado = new Controllers.PostVenta.ConfirmacionController().confirmaEmbarque(usuario, data, txtEmbarque.Text);
            else resultado = new Controllers.PostVenta.ConfirmacionController().registraEmbarqueConcluido(usuario, data);
            if (resultado)
            {
                //METODO ANTIGUO PARA ENVIA LA FECHA RECEPCION   POR SCRIPT FACTURA PORA FACTURA
                // List<UpdateInvoiceModel> factura = new List<UpdateInvoiceModel>();
                // for (int i = 0; i < gridView1.RowCount; i++)
                // {
                //     UpdateInvoiceModel uim = new UpdateInvoiceModel()
                //     {
                //         internalId = Convert.ToInt32(gridView1.GetRowCellValue(i, colfacturaid).ToString()),
                //         custbody_nso_indr_receipt_date = gridView1.GetRowCellValue(i, colfechaHora).ToString()
                //     };
                //     factura.Add(uim);
                // }
                ///* List<UpdateInvoiceModel> lista = new Controllers.PostVenta.ConfirmacionController().regresaInternalId(factura);*/
                // labelAvance.Text = "0/" + gridView1.RowCount.ToString();
                // if (!backgroundWorker1.IsBusy)
                // {
                //     backgroundWorker1.RunWorkerAsync(argument: factura);

                // }

                //Metodo nuevo se carga el csv a una importacion guardad y se manda la info

                StringBuilder sb = new StringBuilder();
                sb.Append("factura,fecha");
                sb.Append("\r\n");
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    string fecha = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfechaHora).ToString();
                    // fecha = Convert.ToDateTime(fecha).ToShortDateString();
                    DateTime result;
   //                 var matchingCulture = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures).FirstOrDefault(ci => DateTime.TryParse(fecha, ci, System.Globalization.DateTimeStyles.None, out result));
                    DateTime fechaD = Convert.ToDateTime(fecha);
                    //sb.Append(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfacturaid).ToString() + "," + Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfechaHora).ToString()).ToString("dd/MM/yyyy") + ",");
                    sb.Append(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfacturaid).ToString() + "," + fechaD.ToShortDateString());
                    sb.Append("\r\n");
                }
                Console.WriteLine(sb);
                ConfirmacionController cc = new ConfirmacionController();
                string respuesta = cc.EmbarqueCSV(sb, tipoPrincipal == 0 ? "Embarque" + txtEmbarque.Text : "Embarque" + DateTime.Now.ToShortDateString(),token);
                respuestaIWScs res = JsonConvert.DeserializeObject<respuestaIWScs>(respuesta);
                if(res.result.responseStructure.codeStatus.Equals("OK"))
                    MessageBox.Show("Proceso terminado \r\n Borra el archivo en NETSUITE los viernes");
                else MessageBox.Show("ERROR:"+res.result.responseStructure.descriptionStatus);
            }
            else
                MessageBox.Show("Error en la transaccion");
        }
    }
}
