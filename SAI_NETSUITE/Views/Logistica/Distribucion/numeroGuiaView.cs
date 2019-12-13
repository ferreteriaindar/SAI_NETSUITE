using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Controllers.Ventas;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Customization;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class numeroGuiaView : UserControl
    {
        DataTable dtFacturas = new DataTable();
        public numeroGuiaView()
        {

            InitializeComponent();
        }





        public void InicializaDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("tipo", typeof(string));
            dt.Columns.Add("cantidad", typeof(int));
            dt.Columns.Add("importe", typeof(decimal));

            List<ListaConceptoNumeroGuia> lista = new List<ListaConceptoNumeroGuia>();
            lista.Add(new ListaConceptoNumeroGuia() { tipo = "BULTO" });
            lista.Add(new ListaConceptoNumeroGuia() { tipo = "CAJA" });
            lista.Add(new ListaConceptoNumeroGuia() { tipo = "TARIMA" });
            lista.Add(new ListaConceptoNumeroGuia() { tipo = "ATADO" });
            lista.Add(new ListaConceptoNumeroGuia() { tipo = "PESO" });
            lista.Add(new ListaConceptoNumeroGuia() { tipo = "VOLUMEN" });

            repositoryCombo.DataSource = lista;
            gridControl1.DataSource = dt;

            SaleOrderSentController sosc = new SaleOrderSentController();
            sosc.getCustomersList();
            searchFletera.Properties.DataSource = sosc.listaRuta;
            searchFletera.Properties.ValueMember = "LIST_ID";
            searchFletera.Properties.DisplayMember = "LIST_ITEM_NAME";

            DataTable dtEmbarques = new DataTable();
            dtEmbarques.Columns.Add("embarque", typeof(string));
            gridEmbarques.DataSource = dtEmbarques;


            
            dtFacturas.Columns.Add("factura", typeof(string));
            dtFacturas.Columns.Add("autoriza", typeof(string));
            dtFacturas.Columns.Add("embarque", typeof(string));
        }

        private void numeroGuiaView_Load(object sender, EventArgs e)
        {
            InicializaDt();
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           
                

        }

        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string embarque = gridView2.GetRowCellValue(e.RowHandle, colEmbarque).ToString();
            if (new Controllers.Logistica.Distribucion.NumeroGuiaController().existeEmbarque(embarque) == false)
            {
                MessageBox.Show("Embarque No existe o Concluida");
                gridView2.CancelUpdateCurrentRow();
            }
        }

        private void groupControl3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {

            if (e.Button == groupControl3.CustomHeaderButtons[0])
            {
                colEmbarque.OptionsColumn.ReadOnly = true;
                gridEmbarques.UseEmbeddedNavigator = false;
                gridFacturas1.Visible = true;
                gridfinal.Visible = true;
                List<string> lista = new List<string>();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    lista.Add(gridView2.GetRowCellValue(i, colEmbarque).ToString());
                }
                gridFacturas1.DataSource=new Controllers.Logistica.Distribucion.NumeroGuiaController().regresaFacturas1(lista);
            }
        }



        
        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            buscaFactura();
        }


        public void buscaFactura()
        {
            int bandera = 0;
            string factura = txtFactura.Text;
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                if(factura.ToUpper().Equals(gridView3.GetRowCellValue(i,colFactura1).ToString()))
                {
                    bandera = 1;
                    if(!new Controllers.Logistica.Distribucion.NumeroGuiaController().tieneNumerodeGuia(factura.ToUpper()))
                    dtFacturas.Rows.Add(factura, "", gridView3.GetRowCellValue(i, colEmbarque1).ToString()) ;
                    else dtFacturas.Rows.Add(factura, "Ya tiene numero de guia", gridView3.GetRowCellValue(i, colEmbarque1).ToString());
                }

            }

            if (bandera == 0)
            {
                FlyoutAction action = new FlyoutAction();
                action.Commands.Add(FlyoutCommand.OK);
                action.Image = SAI_NETSUITE.Properties.Resources.Error_icon;
                if (new Controllers.Logistica.Distribucion.NumeroGuiaController().existaFacturaEnAlgunEmbarque(factura))
                {
                    action.Caption = "Esta Factura no Pertence a los embarques señalados";
                    dtFacturas.Rows.Add(factura, "No Pertece a los Embarques");
                }
                else
                {
                    action.Caption = "Esta factura nunca a sido embarcada";
                    dtFacturas.Rows.Add(factura, "No esta Embarcada Aún");
                }
                FlyoutDialog.Show(this.FindForm(), action);
               

            }
            gridfinal.DataSource = dtFacturas;
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buscaFactura();
                txtFactura.Text = "";
                txtFactura.Select();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate() && gridView1.RowCount > 0 && gridView2.RowCount > 0 && gridView4.RowCount > 0)
            {
                if(guardaNumeroGuia())
                    MessageBox.Show("Proceso Existoso");
                else MessageBox.Show("Error al guardar el  numero de guía");

            }
            else MessageBox.Show("Falta Informacion");
        }

        public bool guardaNumeroGuia()
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                NumeroGuiaNetsuite ngn = new NumeroGuiaNetsuite()
                {
                    Fecha = DateTime.Now,
                    idPaqueteria = Convert.ToInt32(searchFletera.EditValue.ToString()),
                    ImporteTotal = Convert.ToDecimal(txtImporteTotal.Text),
                    NumeroGuia = txtNumGuia.Text,
                    Usuario = "",

                };
                ctx.NumeroGuiaNetsuite.Add(ngn);
                
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    NumeroGuiaNetsuiteC ngnc = new NumeroGuiaNetsuiteC()
                    {
                        Cantidad = Convert.ToDecimal(gridView1.GetRowCellValue(i, colCantidad).ToString()),
                        idNumeroGuia = ngn.idNumeroGuia,
                        Importe = Convert.ToDecimal(gridView1.GetRowCellValue(i, colImporte).ToString()),
                        Tipo = gridView1.GetRowCellValue(i, colTipo).ToString()
                    };
                    ctx.NumeroGuiaNetsuiteC.Add(ngnc);
                }
                for (int i = 0; i < gridView4.RowCount; i++)
                {
                    NumeroGuiaNetsuiteD ngnd = new NumeroGuiaNetsuiteD()
                    {
                        idNumeroGuia = ngn.idNumeroGuia,
                        Factura = gridView4.GetRowCellValue(i, colFacturaEND).ToString(),
                        embarque=gridView4.GetRowCellValue(i,colembarqueFinal).ToString()



                    };
                        ctx.NumeroGuiaNetsuiteD.Add(ngnd);
                }
                

                ctx.SaveChanges();
                return true;
            }
            
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Views.Logistica.Distribucion.numeroGuiaView ng2 = new Views.Logistica.Distribucion.numeroGuiaView();
            ng2.Parent = this.Parent;
            ng2.Dock = DockStyle.Fill;
            Parent.Controls.Add(ng2);
            ng2.BringToFront();
        }
    }

      
        
    }

    public class ListaConceptoNumeroGuia
    {
        public string  tipo { get; set; }
        
    }


  

