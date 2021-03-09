using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class desembarque : UserControl
    {
        string usuario, perfil;
        public desembarque(string perfil,string usuario)
        {
            this.usuario = usuario;
            this.perfil = perfil;        
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            cargaEmbarque();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {


        }

        public void cargaEmbarque()
        {
            Controllers.Logistica.Distribucion.desembarqueController dc = new Controllers.Logistica.Distribucion.desembarqueController();
            gridControl1.DataSource = dc.regresaEmbarque(Convert.ToInt32(txtEmbarque.Text),perfil);
            if(gridView1.RowCount<1)
                MessageBox.Show("EL EMBARQUE TIENE QUE ESTAR EN TRANSITO");
        }
        

        public void catalogaAcceso(string perfil)
        {
            switch (perfil)
            {
                case "admin": case "almacen": case "Jefe Almacen":
                    labelUbicacion.Text = "CCI";
                    break;
                case "postventa":  case "POSTVENTA": labelUbicacion.Text = "POSTVENTA";
                    break;
                case "apoyoventas": labelUbicacion.Text = regresaUbicacion(usuario);
                    break;
                default: labelUbicacion.Text = regresaUbicacion(usuario);
                    break;
            }

        }

        private void desembarque_Load(object sender, EventArgs e)
        {
            catalogaAcceso(perfil);
            if (perfil.Equals("POSTVENTA"))
            {
                /*
                ComboBoxItemCollection coll = new ComboBoxItemCollection();
                coll.AddRange();
                comboEstado.
      */

                RepositoryItemComboBox combo = new RepositoryItemComboBox();
                combo.Items.AddRange(new object[] { "Flete X Confirmar", "DESEMBARQUE POSTVENTA" });
                gridControl1.RepositoryItems.Add(combo);
                //gridView1.Columns["coltransito"].ColumnEdit = combo;
                coltransito.ColumnEdit = combo;


            }
            else
            {
                coltransito.Visible = false;
            }
           
        }

        private void txtEmbarque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                cargaEmbarque();
        }

        private void txtEscaneaFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buscarFactura();
                txtEscaneaFac.Text = "";
                txtEscaneaFac.Select();
            }
        }

        private void buscarFactura()
        {
            bool encontrado = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (txtEscaneaFac.Text.Equals(gridView1.GetRowCellValue(i, colfactura).ToString()))
                {
                    gridView1.SetRowCellValue(i, colrevisado, 1);
                    gridView1.SelectRow(i);
                    encontrado = true;
                }
            }
             
            if(!encontrado)
                MessageBox.Show("Factura NO PERTECNECE AL EMBARQUE");
        }

        private void btnDesembarcar_Click(object sender, EventArgs e)
        {
            bool todo = false;
            if (gridView1.RowCount == gridView1.SelectedRowsCount)
                todo = true;
                DataTable data = new DataTable();
                data.Columns.Add("factura", typeof(string));
                data.Columns.Add("comentario", typeof(string));
                data.Columns.Add("estado", typeof(string));
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    data.Rows.Add(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colfactura).ToString(), gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colcomentario).ToString(),gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], coltransito).ToString());
                }
                if (new Controllers.Logistica.Distribucion.desembarqueController().desembarcarEmbarque(Convert.ToInt32(txtEmbarque.Text), labelUbicacion.Text, data,perfil,todo,usuario))
                {
                    gridControl1.DataSource = null;
                    MessageBox.Show("Desembarcado Exitoso");
                }
           

        }

        public bool estaCompletoelEmbarque()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colrevisado).ToString().Equals("0"))
                    return false;

            }
            return true;
        }

        private void btnEscanea_Click(object sender, EventArgs e)
        {
            buscarFactura();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                embarqueMasivo em = new embarqueMasivo("");

                em.generaReporte(Convert.ToInt32(txtNumEmbarque.Text));
            }
            catch (Exception ex)
            {
                txtNumEmbarque.ErrorText = ex.Message.ToString();
            }
        }

        public string regresaUbicacion(string usuario)
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                var usuarioSai = (from x in ctx.sai_usuario
                                  where x.usuario.Equals(usuario)
                                  select x.sucursal).FirstOrDefault();
                return usuarioSai.ToString();
            }
        }
    }
}
