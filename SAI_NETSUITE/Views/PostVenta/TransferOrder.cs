using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace SAI_NETSUITE.Views.PostVenta
{
    public partial class TransferOrder : UserControl
    {
        public TransferOrder()
        {
            InitializeComponent();
        }

        private void TransferOrder_Load(object sender, EventArgs e)
        {
            cargaDatos();
            //generaReporte("24");
        }

        public void cargaDatos()
        {
            string query = @"select baserecordtype,tranid,fechaIngreso from IWS.DBO.TOR WHERE synWMS is null";
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            }
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }

        private void btnWMS_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount== 1)
            {            //if(gridView1.GetRowCellValue(gridView3.GetSelectedRows()[], colTablaCheck).ToString())
                string query= @"insert into INDGDLSQL01.INDAR_INACTIONWMS.int.entradacompra (mov,movid,Articulo,Cantidad,Proveedor)
                        SELECT 'TOR'as mov,TOR.tranid,Tord.itemText as Articulo,sum(tord.quantity) as cantidad,'POSTVENTA' from IWS.dbo.TOR 
                        INNER JOIN IWS.DBO.TORD ON TOR.IdTOR=TORD.IdTOR
                        where TOR.Tranid="+ gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], coltranid).ToString() + @" group by tranid,itemtext";
                using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    int resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                    {
                        cmd.CommandText = "update iws.dbo.tor SET synwms=1 where tranid=" + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], coltranid).ToString();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("ENVIADO A WMS");
                    }
                    else MessageBox.Show("Error al insertar TOR");
                };
            }
            else MessageBox.Show("Solo Selecciona Uno");
        }


        public void generaReporte(string tranid)
        {
            string query = @"select * from IWS.dbo.TOR 
                            INNER JOIN  IWS.DBO.TORD  ON TOR.IdTOR=TOR.IdTOR
                            WHERE TOR.tranid=" + tranid;
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                // ds.WriteXmlSchema(@"S:\XML\PostVenta\tor.xml");
                HojaTOR hoja = new HojaTOR();
                hoja.DataSource = ds;
                ReportPrintTool printTool = new ReportPrintTool(hoja);
                printTool.ShowRibbonPreview();
            }


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            generaReporte(txtImprimir.Text);
        }
    }
}
