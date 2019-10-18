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
using SAI_NETSUITE.Models.Catalogos;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class embarqueMasivo : UserControl
    {
        string sqlString10 = SAI_NETSUITE.Properties.Settings.Default.SERVER10;
        DataTable dt = new DataTable();
        string usuario;
        public embarqueMasivo(string usuario)
        {
            this.usuario = usuario;
            InicializaTabla();
            InitializeComponent();
        }

        public void InicializaTabla()
        {
            dt.Columns.Add("TRANSACTION_NUMBER", typeof(string));
            dt.Columns.Add("companyid", typeof(string));
            dt.Columns.Add("CREATE_DATE", typeof(string));
            dt.Columns.Add("FORMAENVIO", typeof(string));
            dt.Columns.Add("PAQUETERIA", typeof(string));
            dt.Columns.Add("TRANID", typeof(string));
            

        }


        public List<Models.Catalogos.Empleado> llenaEmpleados()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var emp = from x in ctx.Entity.Where(s => s.ENTITY_TYPE.Equals("Employee")) select new Models.Catalogos.Empleado() { id = x.ENTITY_ID, nombre = x.NAME };
                return emp.ToList();

            }

        }

        private void btnConsultaFactura_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy&& NoseRepite())
            { 
            pictureEdit1.Visible = true;
            string factura = txtFactura.Text;
            backgroundWorker1.RunWorkerAsync(argument: factura);
            }

            /*
            using (SqlConnection myConnection = new SqlConnection(sqlString10))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "exec sp_consultaFacturaNetSuite '" + txtFactura.Text + "'";
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read() && sdr.HasRows)
                {
                    dt.Rows.Add(sdr.GetValue(1).ToString(), sdr.GetValue(2).ToString(), sdr.GetValue(3).ToString(), sdr.GetValue(4).ToString(), sdr.GetValue(5).ToString());

                }
                sdr.Close();
                cmd.Dispose();
                myConnection.Close();
            }

            gridControl1.DataSource = dt;*/
            
        }

        private bool NoseRepite()
        {

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"if exists(select ed.factura from Indarneg.dbo.EmbarquesD  ED
                                        LEFT JOIN Indarneg.DBO.Embarques E ON ED.idEmbarque = E.idEmbarque
                                        WHERE ed.estado not like 'DESEMBARQUE%' and ED.factura = '" + txtFactura.Text+ @"')
                                        select  TOP 1 ed.idEmbarque from Indarneg.dbo.EmbarquesD  ED
                                        LEFT JOIN Indarneg.DBO.Embarques E ON ED.idEmbarque = E.idEmbarque
                                        WHERE ED.factura = '" + txtFactura.Text + @"' ORDER BY E.idEmbarque DESC
                                        ELSE select 'SI'";
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                var resultado = cmd.ExecuteScalar().ToString();
                if (!resultado.ToString().Equals("SI"))
                {
                    txtFactura.ErrorText = "Ya esta en un embarque "+resultado.ToString();
                    return false;
                }

            }

                for (int i = 0; i < GridView1.RowCount; i++)
                {
                    if (GridView1.GetRowCellValue(i, colTRANSACTION_NUMBER).ToString().Equals(txtFactura.Text))
                    {
                        txtFactura.ErrorText = "Repetido";
                        return false;
                    }

                }
            txtFactura.ErrorText = String.Empty;
            return true;

        }

        private void embarqueMasivo_Load(object sender, EventArgs e)
        {
            List<Models.Catalogos.Empleado> lista = llenaEmpleados();
            searchEmpleado.Properties.DataSource = lista;
            List<RutaListCombo> listaRuta = Llenaruta();
            searchPaqueteria.Properties.DataSource = listaRuta;
            pictureEdit1.Visible = false;

        }


        public List<Models.Catalogos.RutaListCombo>  Llenaruta()
        {
           
            using (IWSEntities ctx = new IWSEntities())
            {

                var rl = from x in ctx.Paqueteria.Where(s => s.isInactive == false) select new Models.Catalogos.RutaListCombo() { LIST_ID = x.LIST_ID, LIST_ITEM_NAME = x.LIST_ITEM_NAME };
                return rl.ToList();
            }
            
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool existe = false;
            DataRow dataRow = dt.NewRow();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "exec indarneg.dbo.sp_consultaFacturaNetSuite '" + txtFactura.Text + "'";
                SqlDataReader sdr = cmd.ExecuteReader();
            
                while (sdr.Read() && sdr.HasRows)
                {
                    existe = true;
                   // dt.Rows.Add(sdr.GetValue(1).ToString(), sdr.GetValue(2).ToString(), sdr.GetValue(3).ToString(), sdr.GetValue(4).ToString(), sdr.GetValue(5).ToString());
                    dataRow[0] = sdr.GetValue(1).ToString();
                    dataRow[1] = sdr.GetValue(2).ToString();
                    dataRow[2] = sdr.GetValue(3).ToString();
                    dataRow[3] = sdr.GetValue(4).ToString();
                    dataRow[4] = sdr.GetValue(5).ToString();
                    dataRow[5] = sdr.GetValue(0).ToString();
                }
                sdr.Close();
                cmd.Dispose();
                myConnection.Close();
            }

            BeginInvoke((MethodInvoker)delegate
            {
                if (!dataRow.IsNull(0))
                {
                    dt.Rows.Add(dataRow);
                    }
                else { txtFactura.ErrorText = "No existe Documento"; }
                gridControl1.DataSource = dt;
            });

            // 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureEdit1.Visible = false;
            txtFactura.Text = "";
            txtFactura.Focus();
           
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnConsultaFactura_Click(null, null);
            }
        }

        private void btnEmbarcar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate() && GridView1.RowCount > 0)
            {
                if (guardarEmbarque())
                    MessageBox.Show("Embarque Completado");
                else MessageBox.Show("ERROR DE EMBARQUE");
            }
        }

        public bool guardarEmbarque()
        {
            try
            {
                using (IndarnegEntities ctx = new IndarnegEntities())
                {
                   Embarques emb = regresaEmbarque();
                    ctx.Embarques.Add(emb);
                    ctx.SaveChanges();
                    List<EmbarquesD> embd = regresaEmbarqueD(emb.idEmbarque);
                    foreach (var detalle in embd)
                    {
                        ctx.EmbarquesD.Add(detalle);
                    }

                    ctx.SaveChanges();
                    generaReporte(emb.idEmbarque);
                    return true;
                };
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        public void generaReporte(int idEmbarque)
        {
            DataTable dt = new DataTable();
           /* dt.Columns.Add("embarque", typeof(int));
            dt.Columns.Add("agente", typeof(string));
            dt.Columns.Add("comentarios", typeof(string));
            dt.Columns.Add("fechaemision", typeof(string));
            dt.Columns.Add("fletera", typeof(string));
            dt.Columns.Add("estatus", typeof(string));
            */
            DataTable dtFac = new DataTable();
          /*  dtFac.Columns.Add("factura", typeof(string));
            dtFac.Columns.Add("fechaFactura", typeof(string));
            dtFac.Columns.Add("paqueteria", typeof(string));
            dtFac.Columns.Add("nombreCTE", typeof(string));
            dtFac.Columns.Add("direccion", typeof(string));
            dtFac.Columns.Add("importe", typeof(decimal));
            dtFac.Columns.Add("estatus", typeof(string));*/

            DataSet ds = new DataSet();
           // dt = regresaCabeceraReporte(idEmbarque).Copy();
            dtFac= regresaDetalleReporte(idEmbarque).Copy();
            Console.WriteLine(dtFac.Rows.Count);
          //  ds.Tables.Add(dt);
            ds.Tables.Add(dtFac);
            ds.WriteXmlSchema(@"S:\XML\Almacen\Distribucion\embarqueNetsuite.xml");
            Embarque emb = new Embarque();
            emb.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(emb))
            {
                // Invoke the Ribbon Print Preview form modally, 
                // and load the report document into it.
                printTool.ShowRibbonPreviewDialog();

                // Invoke the Ribbon Print Preview form
                // with the specified look and feel setting.
                printTool.ShowRibbonPreview(UserLookAndFeel.Default);
            }






        }

        public DataTable regresaDetalleReporte(int idEmbarque)
        {/*
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select  TranId as TRANSACTION_NUMBER,p.list_item_name AS PAQUETERIA ,c.name,SHIPADDRESS,i.AmountDue,'ESTATUS' AS STATUS,i.DescuentoTotalPP,i.DescuentoEvento,i.DescuentoTotalImporte,i.Total from  iws.dbo.Invoices I
								LEFT JOIN INDGDLSQL01.IWS.dbo.customers C on I.Entity=c.internalid
								left join INDGDLSQL01.IWS.dbo.Paqueteria P on i.Paqueteria=p.list_id
								 LEFT JOIN INDGDLSQL01.INDARNEG.DBO.embarquesD  embd on i.TranId=REPLACE( embd.factura,'invoice','')
								  left join INDGDLSQL01.INDARNEG.DBO.embarques emb on embd.idEmbarque=emb.idembarque
								where   emb.idembarque=" + idEmbarque.ToString();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                ds.Tables[0].TableName = "detalle";
                return ds.Tables[0];
            }*/
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"SELECT E.idEmbarque,EN.NAME,e.comentarios,e.fecha,p.LIST_ITEM_NAME,e.estatus,f.*
								 FROM Indarneg.DBO.Embarques  E
                                left join IWS.dbo.Entity EN on e.entity_id=EN.ENTITY_ID
                                left join IWS.DBO.Paqueteria P ON e.idPaqueteria=p.LIST_ID								
								LEFT JOIN (
								select  emb.idembarque,TranId as TRANSACTION_NUMBER,p.list_item_name AS PAQUETERIA ,c.name,SHIPADDRESS,i.AmountDue,'ESTATUS' AS STATUS,i.DescuentoTotalPP,i.DescuentoEvento,i.DescuentoTotalImporte,i.Total from  iws.dbo.Invoices I
								LEFT JOIN INDGDLSQL01.IWS.dbo.customers C on I.Entity=c.internalid
								left join INDGDLSQL01.IWS.dbo.Paqueteria P on i.Paqueteria=p.list_id
								 LEFT JOIN INDGDLSQL01.INDARNEG.DBO.embarquesD  embd on i.TranId=REPLACE( embd.factura,'invoice','')
								  left join INDGDLSQL01.INDARNEG.DBO.embarques emb on embd.idEmbarque=emb.idembarque
								where   emb.idembarque="+idEmbarque.ToString()+@") F on e.idEmbarque=f.idEmbarque
                                WHERE E.idEmbarque="+idEmbarque.ToString();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                ds.Tables[0].TableName = "detalle";
                return ds.Tables[0];
            }


        }

        public DataTable regresaCabeceraReporte(int idEmbarque)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"SELECT idEmbarque,EN.NAME,e.comentarios,e.fecha,p.LIST_ITEM_NAME,e.estatus FROM Indarneg.DBO.Embarques  E
                                left join IWS.dbo.Entity EN on e.entity_id=EN.ENTITY_ID
                                left join IWS.DBO.Paqueteria P ON e.idPaqueteria=p.LIST_ID
                                WHERE idEmbarque=" + idEmbarque.ToString();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

        public List<EmbarquesD> regresaEmbarqueD(int id)
        {

            List<EmbarquesD> emb = new List<EmbarquesD>();

            for (int i = 0; i < GridView1.RowCount; i++)
            {
                EmbarquesD embd = new EmbarquesD
                {
                    idEmbarque = id,
                    entity_id = GridView1.GetRowCellValue(i, colcompanyid).ToString(),
                    estado = "TRANSITO",
                    factura = GridView1.GetRowCellValue(i, colTRANSACTION_NUMBER).ToString(),
                    //fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    formaEnvio=GridView1.GetRowCellValue(i,colFORMAENVIO).ToString(),
                    paqueteria = searchPaqueteria.EditValue.ToString(),
                    facturaid=Convert.ToInt32( GridView1.GetRowCellValue(i,colTRANID).ToString())
                    

                };
                emb.Add(embd);
            }

            return emb;
            
        }
        public Embarques regresaEmbarque()
        {
            Embarques emb = new Embarques()
            {
                fecha = DateTime.Now,
                entity_id = Convert.ToInt32(searchEmpleado.EditValue.ToString()),
                comentarios = txtComentarios.Text,
                estatus = "TRANSITO",
                idPaqueteria = Convert.ToInt32(searchPaqueteria.EditValue.ToString()),
                usuario = usuario
                


            };
            return emb;
            
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                generaReporte(Convert.ToInt32(txtNumEmbarque.Text));
            }
            catch (Exception ex)
            {
                txtNumEmbarque.ErrorText = ex.Message.ToString();
            }
        }
    }
}
