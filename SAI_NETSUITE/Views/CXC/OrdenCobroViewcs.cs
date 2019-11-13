using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.CXC;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace SAI_NETSUITE.Views.CXC
{
    public partial class OrdenCobroViewcs : UserControl
    {
        string usuario;
        DataTable dt = new DataTable();
        public OrdenCobroViewcs(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void OrdenCobroViewcs_Load(object sender, EventArgs e)
        {
            inicializaDT();
            List<Models.Catalogos.Empleado> lista = new Controllers.CXC.OrdenCobroController().llenaEmpleados();
            searchEmpleado.Properties.DataSource = lista;
            labelAgente.Text = usuario;


        }

        public void inicializaDT()
        {
            dt.Columns.Add("factura", typeof(int));
            dt.Columns.Add("comentarios", typeof(string));
            dt.Columns.Add("facturaid", typeof(int));

        }

        private void btnConsultaFactura_Click(object sender, EventArgs e)
        {
            if(!SeRepite())
                agregarFactura(Convert.ToInt32(txtFactura.Text));
            else MessageBox.Show("Factura Repetida");
        }


        public bool SeRepite()
        {
            string actual = txtFactura.Text;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (actual.Equals(gridView1.GetRowCellValue(i, colFactura).ToString()))
                    return true;
                        
            }
            return false;
        }

        public void agregarFactura(int numFac)
        {
            OrdenCobroController occ = new OrdenCobroController();
            if (occ.existeFacturaEnEmbarque(numFac))
            {
                dt.Rows.Add(numFac, "", occ.regresaInternalID(numFac));
                gridControl1.DataSource = dt;
            }
            else MessageBox.Show("Esta Factura NO ESTA EMBARCADA");
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if(!SeRepite())
                agregarFactura(Convert.ToInt32(txtFactura.Text));
                else MessageBox.Show("Factura Repetida");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                using (IndarnegEntities ctx = new IndarnegEntities())
                {
                    OrdenCobro oc = regresaOrdenCobro();
                    ctx.OrdenCobro.Add(oc);
                    ctx.SaveChanges();
                    List<OrdenCobroD> lista = regresaOrdenCobroD(oc.idOrdenCobro);
                    foreach (var detalle in lista)
                    {
                        ctx.OrdenCobroD.Add(detalle);
                    }
                    ctx.SaveChanges();
                    //APARECE EL REPORTE
                    generaReporte(oc.idOrdenCobro);
                    MessageBox.Show("TERMINADO");

                }
            }
            else MessageBox.Show("Ingresa el Vendedor");
        }

        public void generaReporte(int idOrdenCobro)
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {

                string query = @"exec  Indarneg.dbo.spReporteOrdenCobro " + idOrdenCobro.ToString();
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                // ds.WriteXmlSchema(@"S:\XML\CyC\ordenCobro.xml");
                HojaOrdenCobro hoc = new HojaOrdenCobro();
                hoc.DataSource = ds;
                using (ReportPrintTool printTool = new ReportPrintTool(hoc))
                {
                    // Invoke the Ribbon Print Preview form modally, 
                    // and load the report document into it.
                    printTool.ShowRibbonPreviewDialog();

                    // Invoke the Ribbon Print Preview form
                    // with the specified look and feel setting.
                    printTool.ShowRibbonPreview(UserLookAndFeel.Default);
                }
            }

        }

        private List<OrdenCobroD> regresaOrdenCobroD(int OrdeCobroID)
        {
            List<OrdenCobroD> lista = new List<OrdenCobroD>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                OrdenCobroD ocd = new OrdenCobroD()
                {
                    comentarios = gridView1.GetRowCellValue(i, colComentarios).ToString(),
                    factura = gridView1.GetRowCellValue(i, colFactura).ToString(),
                    facturaid = Convert.ToInt32(gridView1.GetRowCellValue(i, colFacturaid).ToString()),
                    idOrdenCobro = OrdeCobroID

                };
                lista.Add(ocd);
            }
            return lista;
        }

        public OrdenCobro regresaOrdenCobro()
        {
            OrdenCobro oc = new OrdenCobro()
            {
                comentarios = txtComentarios.Text,
                entity_id = Convert.ToInt32(searchEmpleado.EditValue.ToString()),
                estatus = "ENTREGADO",
                fecha = DateTime.Now,
                usuario = usuario


            };
        return oc;
        }
    }
}
