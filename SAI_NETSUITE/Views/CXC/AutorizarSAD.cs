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

namespace SAI_NETSUITE.Views.CXC
{
    public partial class AutorizarSAD : UserControl
    {
        string usuario;
        public AutorizarSAD(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }


        public void cargaInfo()
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select sad.sadID,so.tranId AS Pedido, so.total as ImportePedido,c.companyId as Cliente,c.company as Nombre,I.TranDate AS FechaFactura,I.TranId as Factura,i.Total AS ImporteFactura,i.DescuentoTotalPP,i.Total*(100-i.DescuentoTotalPP)/100 as ImportePP,SAD.excepcion,SAD.comentario,'' as cxcComentario,0.0  as monto from Indarneg.dbo.SAD 
                                inner join IWS.DBO.SaleOrders SO ON SAD.pedidoID=SO.internalId
                                inner join iws.dbo.Customers C on SO.idCustomer=C.internalid
                                left join iws.dbo.Invoices I on so.internalId=i.createdfrom
                                WHERE SAD.cxcFecha IS NULL";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            }

        }
        private void btActualizar_Click(object sender, EventArgs e)
        {
            cargaInfo();
        }

        private void btnAutorizar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //MessageBox.Show(gridView1.GetFocusedRowCellValue(colNombre).ToString());
            if (!gridView1.GetFocusedRowCellValue(colcxcComentario).ToString().Equals("") && !gridView1.GetFocusedRowCellValue(colmonto).ToString().Equals("0"))
            {
                //AUTORIZAR
                using (IndarnegEntities ctx = new IndarnegEntities())
                {
                    int sadID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colsadID).ToString());
                    SAD sAD = (from i in ctx.SAD
                               where i.sadID.Equals(sadID)
                               select i).FirstOrDefault();
                    sAD.cxcAgente = usuario;
                    sAD.cxcComentario = gridView1.GetFocusedRowCellValue(colcxcComentario).ToString();
                    sAD.cxcFecha = DateTime.Now;
                    sAD.cxcMonto = Convert.ToDecimal(gridView1.GetFocusedRowCellValue(colmonto).ToString());
                    ctx.SaveChanges();
                }
                cargaInfo();
            }
            else MessageBox.Show("Ingresa Comentario y/o Monto");
        }
    }
}
