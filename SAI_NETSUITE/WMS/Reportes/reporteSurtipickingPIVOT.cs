using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.ViewInfo;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.Reportes
{
    public partial class reporteSurtipickingPIVOT : UserControl
    {

        int format = 0;
        string sqlString;
        public reporteSurtipickingPIVOT(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }

        private void reporteSurtipickingPIVOT_Load(object sender, EventArgs e)
        {
  
            spNivelPickingTableAdapter.Fill(wMS_NivelPicking.spNivelPicking);
            pivotGridControl1.DataSource = wMS_NivelPicking.spNivelPicking;
            //cargainfo();

        }

        public void cargainfo()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query= "exec INDGDLSQL01.INDAR_INACTIONWMS.dbo.spnivelpicking";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            da.SelectCommand.CommandTimeout = 0;
            DataSet ds = new DataSet();
            da.Fill(ds);
            pivotGridControl1.DataSource = ds.Tables[0];
         
        
        }

        private void pivotGridControl1_CustomDrawCell(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs e)
        {
            if (e.DataField == fieldporsurtir1 && format == 1)
            {
                PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

                int surtido = (int)ds.GetValue(1, "fieldsurtido1");
                int porSurtir = (int)ds.GetValue(1, "porsurtir");
                if (porSurtir == 0 && (surtido > porSurtir))
                    e.Appearance.BackColor = Color.Green;
                //if (hiddenValue < 0)
                //    e.Appearance.BackColor = Color.Red;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
  
        
        }

        private void pivotGridControl1_CellDoubleClick(object sender, PivotCellEventArgs e)
        {
             PivotGridHitInfo hi = pivotGridControl1.CalcHitInfo(pivotGridControl1.PointToClient(MousePosition));
            if (hi.HitTest == PivotGridHitTest.Cell)
            {
                var fieldValue = hi.CellInfo.GetFieldValue(fieldNUMPEDIDO1);
                var cliente = hi.CellInfo.GetFieldValue(fieldCLIENTE1);
                pickingDetalle pd = new pickingDetalle(sqlString, fieldValue.ToString(), cliente.ToString());
                pd.ShowDialog();
               
            }

        }

        
    }
}
