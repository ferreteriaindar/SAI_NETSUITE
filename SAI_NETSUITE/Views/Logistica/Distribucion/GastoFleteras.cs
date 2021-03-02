using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using SAI_NETSUITE.Models.Transaccion;
using SAI_NETSUITE.Controllers.Logistica.Distribucion;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class GastoFleteras : UserControl
    {
        string xmlString, usuario,importeEmbarque;

        public GastoFleteras(string usr)
        {
            usuario = usr;
            InitializeComponent();
        }

        private void GastoFleteras_Load(object sender, EventArgs e)
        {
            importeEmbarque = "0";
            cargaVendors();
        }


        public void cargaVendors()
        {
            Controllers.Logistica.Distribucion.GastoFleterasController gfc = new Controllers.Logistica.Distribucion.GastoFleterasController();
            searchVendor.Properties.DataSource = gfc.regresaVendors();
            searchVendor.Properties.ValueMember = "ENTITY_ID";
            searchVendor.Properties.DisplayMember = "NAME";

        }

        private void searchVendor_EditValueChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            gridFinal.DataSource = null;
            importeEmbarque = "0";
            Controllers.Logistica.Distribucion.GastoFleterasController gfc = new Controllers.Logistica.Distribucion.GastoFleterasController();
         
            gridControl1.DataSource = gfc.regresaGuias(searchVendor.Properties.View.GetFocusedRowCellValue("PAQUETERIA_DISTRIBUCION_ID").ToString()).Tables[0];
            if (searchVendor.Properties.View.GetFocusedRowCellValue("NAME").ToString().Contains("OF "))
            {
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                TextEdit txt = new TextEdit();
                 txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                args.Prompt = "Ingresa Importe Factura";
                args.Prompt = "Importe";
                args.Caption = "Definir Importe de factura oficina";
                args.Editor = txt;
                var result = XtraInputBox.Show(args);
                if (result == null)
                {
                    gridControl1.DataSource = null;
                   // searchVendor.Refresh();
                    MessageBox.Show("Ingresa un importe real");
                }
                
                else { importeEmbarque = result.ToString();
                    txtImporteGuia.Text = importeEmbarque;
                        }

            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            /* decimal importe = 0;
             txtImporteGuia.Text = "";
             for (int i = 0; i < gridView1.SelectedRowsCount; i++)
             {


                 importe += Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colImporteTotal).ToString());

             }  */
            //  txtImporteGuia.Text = importe.ToString();   

            gridFinal.DataSource = null;
            List<GastoFleteraModel> listaGuias = new List<GastoFleteraModel>();
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                GastoFleteraModel gfm = new GastoFleteraModel()
                {
                    idNumeroGuia = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colidNumeroGuia).ToString()),
                    NumeroGuia = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colNumeroGuia).ToString(),
                    importe = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colImporteTotal).ToString())
                };
                listaGuias.Add(gfm);
            }

            if (listaGuias.Count > 0)
            {
                if (listaGuias[0].NumeroGuia.Contains("EMBARQUE"))
                    gridFinal.DataSource = new GastoFleterasController().RegresaGridFinalXEmbarque(listaGuias, importeEmbarque);
                else
                    gridFinal.DataSource = new GastoFleterasController().RegresaGridFinal(listaGuias);
            }
            
                decimal importe = 0;
                txtImporteGuia.Text = "";
                for (int i = 0; i < gridView2.RowCount; i++)
                {


                    importe += Convert.ToDecimal(gridView2.GetRowCellValue(i, colFinalimporte).ToString());

                }
                txtImporteGuia.Text =Math.Round( importe,2).ToString();
                validadImportes();
            
        }


        public void validadImportes()
        {
            decimal guia,factura;
            if (Decimal.TryParse(txtImporteGuia.Text, out guia) && Decimal.TryParse(txtSubtotal.Text, out factura))
            {
                if (guia == factura)
                {
                    btnRegistra.Visible = true;
                    //btnRegistra.Enabled = true;
                 
                }
                else
                  //  btnRegistra.Enabled = false;
                    btnRegistra.Visible = false;
            }
            else
            {
                btnRegistra.Visible = false;
             //   btnRegistra.Enabled = false;
               
            }

        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {

            using (IndarnegEntities ctx = new IndarnegEntities())
            {

                GastoFletera gf = new GastoFletera()
                {
                    checkRetencion = checkEdit1.Checked ? true : false,
                    fecha = DateTime.Now,
                    idVendor = Convert.ToInt32(searchVendor.EditValue.ToString()),
                    importeFactura = Convert.ToDecimal(txtFacturaImporte.Text),
                    numFactura = txtNumFactura.Text,
                    uuid = txtUUID.Text,
                    Vendor = searchVendor.Properties.View.GetFocusedRowCellValue("NAME").ToString(),
                    usuario = usuario,
                    autorizado=checkAutorizado.Checked?true:false,
                    
                    
                    
               
            };
                ctx.GastoFletera.Add(gf);
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    GastoFleteraD gfd = new GastoFleteraD();

                    gfd.idGastoFletera = gf.idGastoFletera;
                        gfd.idNumGuia = Convert.ToInt32(gridView2.GetRowCellValue(i, colFinalidNumeroGuia).ToString());
                    gfd.NumGuia = gridView2.GetRowCellValue(i, colFinalNumeroGuia).ToString();
                    gfd.importeGuia = Convert.ToDecimal(gridView2.GetRowCellValue(i, colFinalimporte).ToString());
                    gfd.atados =importeEmbarque.Equals("0")? Convert.ToInt32(gridView2.GetRowCellValue(i, colFinalATADO).ToString()):0;
                    gfd.bultos = importeEmbarque.Equals("0") ? Convert.ToInt32(gridView2.GetRowCellValue(i, colFinalBULTOS).ToString()):0;
                    gfd.cajas = Convert.ToInt32(gridView2.GetRowCellValue(i, colFinalCAJAS).ToString());
                    gfd.tarimas = importeEmbarque.Equals("0") ? Convert.ToInt32(gridView2.GetRowCellValue(i, colFinalTARIMA).ToString()):0;
                    gfd.facturas = gridView2.GetRowCellValue(i, colFinalFacturas).ToString();
                    gfd.metodo = gridView2.GetRowCellValue(i, colFinalMETODO).ToString();
                    gfd.comentario = gridView2.GetRowCellValue(i, colFinalcomentario).ToString();


                    ctx.GastoFleteraD.Add(gfd);
                }
                
                ctx.SaveChanges();



                StringBuilder sb = new StringBuilder(); //////
                sb.Append("ExternalId,xml,DepartmentHead,Vendor,Location,Date,Reference,Item,Rate,Quantity,Tax,Department,Relacion");
                sb.Append("\r\n");
                string ExternalId = DateTime.Now.ToFileTime().ToString();

                List<GastoFleteraModel> listaGridFinal = (List<GastoFleteraModel>)gridView2.DataSource;
                List<GastoFleteraCSVModel> lista = new List<GastoFleteraCSVModel>();

                foreach (var item in listaGridFinal)
                {
                    List<GastoFleteraCSVModel> listaAux;
                      
                        listaAux=   new GastoFleterasController().regresaLineaBill(item, checkEdit1.Checked);                 
                   
                    listaAux[0].Reference = "FLETERA "+gf.idGastoFletera.ToString();
                    listaAux[0].xml = txtUUID.Text + ".xml"; //"test.xml";//xmlString.Replace("\"", "\\\""),   //es el UUID DEL xml
                    //Para el vendor, si detect que dice "OF LEON" ETC ETC,   Pone la columna  OficinaNameFletara,   si no  pone  el verdadero que es NAME
                    listaAux[0].Vendor = searchVendor.Properties.View.GetFocusedRowCellValue("NAME").ToString().Contains("OF ")? searchVendor.Properties.View.GetFocusedRowCellValue("OficinaNameFletara").ToString(): searchVendor.Properties.View.GetFocusedRowCellValue("NAME").ToString();
                    lista.AddRange(listaAux);
                }
                /*
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    GastoFleteraCSVModel aux = new GastoFleteraCSVModel()
                    {
                        Date = DateTime.Now.ToShortDateString(),
                        DepartmentHead ="180", // "20000-DIRECCIÓN COMERCIAL : 25100-GERENCIA VTAS TELEFONICAS : 25100-ZONA 100",
                        Location = "LOGISTICA",
                        Quantity = "1",
                        Reference = "FLETERA 1",
                        xml = "test.xml",//xmlString.Replace("\"", "\\\""),
                        Vendor = searchVendor.Properties.View.GetFocusedRowCellValue("NAME").ToString(),
                        Department = new GastoFleterasController().regresaDepartmentGuia(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colidNumeroGuia).ToString()),
                        Item = checkEdit1.Checked ? "FLETES CON RETENCION" : "FLETES SIN RETENCION",
                        Rate = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colImporteTotal).ToString())* 100/ (checkEdit1.Checked?112:116),
                        Tax = checkEdit1.Checked ? "RET IVA FLETES:GPO RET FLETE" : "IVA 16%:IVA 16%"

                    };
                    lista.Add(aux);
                }*/

                foreach (var item in lista)
                {
                    sb.Append(ExternalId + "," + item.xml + "," + item.DepartmentHead + "," + item.Vendor + "," + item.Location + "," + item.Date + "," + item.Reference + "," + item.Item + "," + item.Rate.ToString() + "," + item.Quantity + "," + item.Tax + "," + item.Department+","+item.Relacion);
                    sb.Append("\r\n");
                }

                try
                {
                    GastoFleterasController gfc = new GastoFleterasController();
                    if (gfc.enviarBill(sb, xmlString, txtUUID.Text,gf.idGastoFletera))
                    {
                        MessageBox.Show("Enviado Exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Un problema");
                    }
                }
                catch (Exception ex)
                {
                    List<GastoFleteraD> borrarGFD = ctx.GastoFleteraD.Where(x => x.idGastoFletera == gf.idGastoFletera).ToList();
                    ctx.GastoFleteraD.RemoveRange(borrarGFD);
                    ctx.GastoFletera.Remove(gf);
                    ctx.SaveChanges();
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void btnCargaXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "Busca Archivos XML",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "XML",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 xmlString = System.IO.File.ReadAllText(openFileDialog1.FileName);
               // Byte[] bytes = File.ReadAllBytes(openFileDialog1.FileName);
               // xmlString = Convert.ToBase64String(bytes);
               
                labelPath.Text = openFileDialog1.FileName;
                //string  xmlstringUnscapped=xmlString.Replace("\"", "\\\"");

                cargaInfoXml(xmlString);
            }

           
        }

        private void cargaInfoXml(string  xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var emisor = doc.GetElementsByTagName("cfdi:Emisor");
                var raiz = doc.GetElementsByTagName("cfdi:Comprobante");
                var complemento = doc.GetElementsByTagName("cfdi:Complemento");
                var TimbreFiscalDigital = complemento[0].LastChild;
                var total = raiz[0].Attributes["Total"];
                var SubTotal = raiz[0].Attributes["SubTotal"];
                var folio = raiz[0].Attributes["Folio"];
                var href = emisor[0].Attributes["Nombre"];
                var uuid = TimbreFiscalDigital.Attributes["UUID"];

                string name = href.Value;
                string vendor = searchVendor.Properties.View.GetFocusedRowCellValue("NAME").ToString();
                if (vendor.Contains(name.ToUpper()))
                    MessageBox.Show("XML VALIDO");
                txtFacturaImporte.Text = total.Value;
                txtNumFactura.Text = folio.Value;
                txtUUID.Text = uuid.Value;
                txtSubtotal.Text = SubTotal.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  en el xml\n"+ex.Message);
            }
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            /*
            LoginUserControl myControl = new LoginUserControl();
            if (DevExpress.XtraEditors.XtraDialog.Show(myControl, "Sign in", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                var controls = myControl.Controls.OfType<TextEdit>();
                foreach (TextEdit c in controls)
                {
                    
                        Console.WriteLine((c as TextEdit).Text);
                       
                    
                }
            }*/
           
            XtraInputBoxArgs args = new XtraInputBoxArgs();
            TextEdit txt = new TextEdit();
            TextEdit txtuser = new TextEdit();
            txt.Properties.UseSystemPasswordChar = true;            
            args.Prompt = "Ingresa Contraseña";
            args.Prompt = "Contraseña";
            args.Caption= "Autorizar Cambio de Importe";
            args.Editor = txt;
           
            var result = XtraInputBox.Show(args);
            //Console.WriteLine(result.ToString());
            if (validarContrasena(result.ToString()))
            {
               
                colFinalimporte.OptionsColumn.ReadOnly = false;
                colFinalcomentario.OptionsColumn.ReadOnly = false;
                checkAutorizado.Checked = true;
            }
            else MessageBox.Show("No Autorizado");
        }

        public bool validarContrasena(string pass)
        {
            GastoFleterasController gfc = new GastoFleterasController();
            bool resultado = gfc.validarContrasena(pass);
            return resultado;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            txtFacturaImporte.Text = (Math.Round( Convert.ToDecimal(txtSubtotal.Text) * (checkEdit1.Checked ? 1.12M : 1.16M),2)).ToString();
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Console.WriteLine("edit");
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption.Equals("Importe")&&  gridView2.RowCount>0)
            {

                 decimal importe = 0;
                 txtImporteGuia.Text = "";
                 for (int i = 0; i < gridView2.RowCount; i++)
                 {


                     importe += Convert.ToDecimal(gridView2.GetRowCellValue(i, colFinalimporte).ToString());

                 }  
                  txtImporteGuia.Text = importe.ToString();
                validadImportes();
            }

        }



    }


    public class LoginUserControl : XtraUserControl
    {
        public LoginUserControl()
        {


            LayoutControl lc = new LayoutControl();
            lc.Dock = DockStyle.Fill;
              TextEdit teLogin = new TextEdit();
            TextEdit tePassword = new TextEdit();
            CheckEdit ceKeep = new CheckEdit() { Text = "Keep me signed in" };
            SeparatorControl separatorControl = new SeparatorControl();
            lc.AddItem(String.Empty, teLogin).TextVisible = false;
            lc.AddItem(String.Empty, tePassword).TextVisible = false;
            lc.AddItem(String.Empty, ceKeep);
            this.Controls.Add(lc);
            this.Height = 100;
            this.Dock = DockStyle.Top;

        }
    }
}
