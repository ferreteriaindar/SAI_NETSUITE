using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.Compras.Entradas
{
    public partial class IR : UserControl
    {
        public IR()
        {
            InitializeComponent();
        }

        private void IR_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        public void cargaDatos()
        {
            Controllers.Compras.Entradas.IRController ir = new Controllers.Compras.Entradas.IRController();
            gridControl1.DataSource = ir.regresaInfo().Tables[0];

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargaDatos();
        }


      
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = gridView1.GetSelectedRows();
            
            List<string> listaProv = new List<string>();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                if(selectedRowHandles[i]>=0)
                listaProv.Add(gridView1.GetRowCellValue(selectedRowHandles[i], colVendor).ToString());
            }
            IEnumerable<string> proveedores =listaProv.Distinct();
            if (proveedores.Count() > 1 && proveedores.Count()>0)
                MessageBox.Show("Solo debes de escoger un solo PROVEEDOR");
            else
            {
                using (IndarnegEntities ctxNeg = new IndarnegEntities())
                
                using (IWSEntities ctx = new IWSEntities())
                {
                    SAI_NETSUITE.IR ir = new SAI_NETSUITE.IR()
                    {
                        date = DateTime.Now,
                        mov = "IR",
                        vendor = proveedores.FirstOrDefault()
                    };
                    ctx.IR.Add(ir);
                    ctx.SaveChanges();
                    List<IRD> iRDs = new List<IRD>();
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        if (gridView1.GetSelectedRows()[i] > 0)
                        {
                            IRD iRD = new IRD()
                            {
                                idIR = ir.id,
                                itemid = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colitemid).ToString(),
                                quantity = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colCantidad).ToString()),
                                sourceTran=gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],colType).ToString(),
                                sourceNumber=Convert.ToInt32( gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i],colidReceipt).ToString())
                            };
                            iRDs.Add(iRD);
                           // ctx.IRD.Add(iRD);
                        }
                    }
                    ctx.IRD.AddRange(iRDs);
                    ctx.SaveChanges();
                    try
                    {
                        spWMS_InsertaIR_Result result = ctxNeg.spWMS_InsertaIR(ir.id).FirstOrDefault();
                        if (result.rows != null && result.rows < 1)
                        {

                            MessageBox.Show("Error al insertar al WMS");
                        }
                        else
                        {
                            ir.synWMS = true;
                            ctx.SaveChanges();
                            MessageBox.Show("DOCUMENTO CREADO: " + ir.id.ToString());
                            Reporte(ir.id.ToString());
                            Controllers.Compras.Entradas.IRController iRController = new Controllers.Compras.Entradas.IRController();
                            int[] idItemrcpt = new int[selectedRowHandles.Length];
                            for (int i = 0; i < selectedRowHandles.Length; i++)
                            {
                                if (selectedRowHandles[i] >= 0)
                                    idItemrcpt[i] = Convert.ToInt32(gridView1.GetRowCellValue(selectedRowHandles[i], colIR).ToString());
                            }
                            iRController.actualizaSyncWMS(idItemrcpt);
                            gridView1.ActiveFilterString = null;


                        }
                    }
                    catch (Exception)
                    {
                        List<IRD> LIRDs = ctx.IRD.Where(x => x.IR.id == ir.id).ToList();
                        ctx.IRD.RemoveRange(LIRDs);
                        SAI_NETSUITE.IR iR = ctx.IR.Where(X => X.id == ir.id).FirstOrDefault();
                        ctx.IR.Remove(iR);
                        ctx.SaveChanges();
                        MessageBox.Show("Error al insertar IR");
                    }
                    cargaDatos();
                }
                    
                
            }
        }

        private void BTNImprimir_Click(object sender, EventArgs e)
        {/*

           // Views.Compras.Entradas.hojaIR hoja = new hojaIR();
            Parameter param1 = new Parameter();
          //  Parameter param2 = new Parameter();
            param1.Name = "idParameter";
          //  param2.Name = "idParameterDetail";
            param1.Value = 10;
          //  param2.Value = 10;
            hoja.Parameters.Add(param1);
          //  hoja.Parameters.Add(param2);
            hoja.RequestParameters = false;
            ReportPrintTool printTool = new ReportPrintTool(hoja);
            printTool.ShowRibbonPreview();
            */
            Reporte(txtReimprimir.Text);


        }


        public void Reporte(string id)
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                /*string query = @"select ir.id,ir.mov,ir.vendor,ir.date,IRD.itemid,ird.sourceTran,ird.sourceNumber from  iws.dbo.ir IR
                                left join iws.dbo.IRD IRD ON ir.id=IRD.idIR
                                where ir.id="+id;*/
                 string query= @"select ir.id,ir.mov,ir.vendor,ir.date,IRD.itemid,ird.sourceTran,
                                    sourceNumber = (select ',' + CONVERT(varchar(10), ird2.sourceNumber) from iws.dbo.IRD ird2 where ird2.idIR = IR.id and ird2.itemid = IRD.itemid for xml path('') )
                                from iws.dbo.ir IR
                                left join iws.dbo.IRD IRD ON ir.id = IRD.idIR
                                            where ir.id = "+id.ToString()+@"
                                group by IR.id,ir.mov,ir.vendor,ir.date,IRD.itemid,ird.sourceTran";
                SqlDataAdapter da =  new SqlDataAdapter(query, myConnection);
              
                da.Fill(ds);
                //ds.WriteXmlSchema(@"S:\XML\Compras\IR.xml");

            }
            hojaIR ir = new hojaIR();
            ir.DataSource = ds;
            ReportPrintTool printTool = new ReportPrintTool(ir);
            printTool.ShowRibbonPreview();

        }
    }
}
