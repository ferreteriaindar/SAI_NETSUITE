using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.administracion
{
    public partial class bloquearPedido : UserControl
    {
        string sqlString;
        public bloquearPedido(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }

        private void bloquearPedido_Load(object sender, EventArgs e)
        {
            cargaPedidos();
        }

        public void cargaPedidos()
        {

            string query = @"select IdOrdenEmbarque,cte.Clave,oe.Mov,oe.NumPedido,oe.FormaEnvio,oe.Prioridad,ee.Nombre,(select top 1 isnull(EnBuro,0)  from INDGDLSQL01.INDAR_INACTIONWMS.dbo.PedidoRenglon where PedidoRenglon.IdOrdenEmbarque=oe.IdOrdenEmbarque) as  buro from INDGDLSQL01.INDAR_INACTIONWMS.dbo.OrdenEmbarque oe
                                left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Cliente cte on oe.IdCliente=cte.IdCliente
                                left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.EstatusOrdenEmbarque  ee on oe.IdEstatusOrdenEmbarque=ee.IdEstatusOrdenEmbarque";
            SqlConnection myConnection = new SqlConnection(sqlString);
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAccion.EditValue.ToString().Equals("LIBERAR"))
            {
                btnAccion.Text = "LIBERAR";
            }
            else btnAccion.Text = "BLOQUEAR";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gridView1.ClearSelection();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate() && !btnAccion.Text.Equals("") && gridView1.SelectedRowsCount >= 1)
            {
                DialogResult result2 = MessageBox.Show("Seguro que vas a " + comboAccion.Text + "?",
                "AVISO",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        int @buro = 0;
                        if (comboAccion.Text.Equals("BLOQUEAR"))
                            @buro = 1;
                        else @buro = 0;
                        SqlConnection myConnection = new SqlConnection(sqlString);
                        myConnection.Open();
                        SqlCommand cmd = new SqlCommand("", myConnection);
                        string query = @"	UPDATE INDGDLSQL01.INDAR_INACTIONWMS.dbo.PedidoRenglon SET
                                        EnBuro = " + @buro.ToString() + @"
                                        WHERE IdOrdenEmbarque IN(
                                        SELECT IdOrdenEmbarque FROM INDGDLSQL01.INDAR_INACTIONWMS.dbo.OrdenEmbarque WHERE NumPedido='" + gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colNumPedido).ToString() + "')";
                        cmd.CommandText = query;
                        Console.WriteLine(query);
                         cmd.ExecuteNonQuery();
                         myConnection.Close();
                         cmd.Dispose();
                         myConnection.Dispose();

                    }
                    MessageBox.Show("Terminado");
                    cargaPedidos();
                }
            }
            else MessageBox.Show("Revisa debes seleccionar una accion y pedidos");
        }
    }
}
