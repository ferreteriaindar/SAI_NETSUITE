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

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class ValidarSAD : UserControl
    {
        string usuario;
        public ValidarSAD(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }



        public void cargaDatos()
        {

            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select sad.sadID,SO.tranId AS Pedido, so.total as ImportePedido,c.companyId as Cliente,c.company as Nombre,I.TranDate AS FechaFactura,I.TranId as Factura,i.Total AS ImporteFactura,i.DescuentoTotalPP,i.Total*(100-i.DescuentoTotalPP)/100 as ImportePP,SAD.excepcion,SAD.comentario,SAD.cxcComentario,SAD.cxcMonto from Indarneg.dbo.SAD 
                                inner join IWS.DBO.SaleOrders SO ON SAD.pedidoID=SO.internalId
                                inner join iws.dbo.Customers C on SO.idCustomer=C.internalid
                                left join iws.dbo.Invoices I on so.internalId=i.createdfrom
                                WHERE SAD.validadFecha IS NULL AND SAD.cxcFecha IS NOT NULL";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            }

        }

        private void ValidarSAD_Load(object sender, EventArgs e)
        {

        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }

        private void btnAutorizar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
                //AUTORIZAR
                using (IndarnegEntities ctx = new IndarnegEntities())
                {
                    int sadID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colsadID).ToString());
                    SAD sAD = (from i in ctx.SAD
                               where i.sadID.Equals(sadID)
                               select i).FirstOrDefault();
                    sAD.validaAgente = usuario;
                    sAD.validadFecha = DateTime.Now;
                    ctx.SaveChanges();
                MessageBox.Show("Terminado");
                }
                
            cargaDatos();
           
        }
    }

   
}
