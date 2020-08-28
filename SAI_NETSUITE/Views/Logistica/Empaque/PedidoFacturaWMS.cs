using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using SAI_NETSUITE.Models.Transaccion;
using Newtonsoft.Json;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class PedidoFacturaWMS : DevExpress.XtraEditors.XtraForm
    {
        public PedidoFacturaWMS()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

          //  simpleButton1.Appearance.Image = 
            simpleButton1.ImageOptions.Image= SAI_NETSUITE.Properties.Resources.gear;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {

                MessageBox.Show("Esperate -_-!");
                simpleButton1.Appearance.Image = null;
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            string query = "exec  IndarWms.[dbo].[spPedidosEmpacados]";
            
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sendGetSalesInvoiceWMSModel lista = new sendGetSalesInvoiceWMSModel();
            lista.ids = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lista.ids.Add(dt.Rows[i][0].ToString());
            }

            
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.POST("api/Timbrado/GetSalesInvoiceWMS",JsonConvert.SerializeObject(lista), SAI_NETSUITE.Properties.Resources.token);
            GetSalesInvoiceWMSModel list = JsonConvert.DeserializeObject<GetSalesInvoiceWMSModel>(json);
            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("tranPedido", typeof(string));
            dtFinal.Columns.Add("statusPedido", typeof(string));
            dtFinal.Columns.Add("mov", typeof(string));
            dtFinal.Columns.Add("tranFactura", typeof(string));
            dtFinal.Columns.Add("statusFactura", typeof(string));
            dtFinal.Columns.Add("FechaFactura", typeof(string));
            dtFinal.Columns.Add("mensaje", typeof(string));

            foreach (var item in list.result.Resultados.Documentos.Where(x=>x.type.Equals("SalesOrd")).ToList())
            {
                DocumentoGetSalesInvoiceWMSModel factura = (from x in list.result.Resultados.Documentos where x.createdfrom.Equals(item.internalid.ToString()) select x).FirstOrDefault();
                if (factura != null)
                {
                    var row = dt.AsEnumerable().Where(x => x.Field<string>("NumPedido").Equals(item.tranid)).Select(y => new { mov = y.Field<string>("Mov"), cons = y.Field<string>("Consolidado") }).First();
                    dtFinal.Rows.Add(item.tranid, item.statusref,row.cons.Equals("")?"":row.cons,factura.tranid, factura.statusref, factura.trandate, factura.custbody_fe_sf_mensaje_respuesta);
                }
                else
                    dtFinal.Rows.Add(item.tranid, item.statusref);
            }
            
            e.Result = dtFinal;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // GetSalesInvoiceWMSModel list = (GetSalesInvoiceWMSModel)e.Result;

            // gridControl1.DataSource = list.result.Resultados.Documentos.ToList();

            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("tranPedido", typeof(string));
            dtFinal.Columns.Add("statusPedido", typeof(string));
            dtFinal.Columns.Add("tranFactura", typeof(string));
            dtFinal.Columns.Add("statusFactura", typeof(string));
            dtFinal.Columns.Add("FechaFactura", typeof(string));
            dtFinal.Columns.Add("mensaje", typeof(string));


            dtFinal = (DataTable)e.Result;
            gridControl1.DataSource = dtFinal;
            simpleButton1.ImageOptions.Image =  null;
        }

        private void PedidoFacturaWMS_Load(object sender, EventArgs e)
        {

        }

        private void tileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (tileView1.GetRowCellValue(e.RowHandle, coltranFactura).ToString().Equals(""))
                e.Item.Elements[6].Appearance.Normal.BackColor = Color.Red;
            else e.Item.Elements[6].Appearance.Normal.BackColor = Color.Green;
        }
    }
}