using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            gridControl1.DataSource = dc.regresaEmbarque(Convert.ToInt32(txtEmbarque.Text));
        }
        

        public void catalogaAcceso(string perfil)
        {
            switch (perfil)
            {
                case "admin": case "almacen": case "Jefe Almacen":
                    labelUbicacion.Text = "CCI";
                    break;
                case "postventa": labelUbicacion.Text = "POSTVENTA";
                    break;
                case "apoyoventas": labelUbicacion.Text = regresaUbicacion(usuario);
                    break;
                
            }

        }

        private void desembarque_Load(object sender, EventArgs e)
        {
            catalogaAcceso(perfil);
        }

        private void txtEmbarque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                cargaEmbarque();
        }

        private void txtEscaneaFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                buscarFactura();
        }

        private void buscarFactura()
        {
            bool encontrado = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (txtEscaneaFac.Text.Equals(gridView1.GetRowCellValue(i, colfactura).ToString()))
                {
                    gridView1.SetRowCellValue(i, colrevisado, 1);
                    encontrado = true;
                }
            }
             
            if(!encontrado)
                MessageBox.Show("Factura NO PERTECNECE AL EMBARQUE");
        }

        private void btnDesembarcar_Click(object sender, EventArgs e)
        {
            if (estaCompletoelEmbarque())
            {
                DataTable data = new DataTable();
                data.Columns.Add("factura", typeof(string));
                data.Columns.Add("comentario", typeof(string));
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    data.Rows.Add(gridView1.GetRowCellValue(i, colfactura).ToString(), gridView1.GetRowCellValue(i, colcomentario).ToString());
                }
                if (new Controllers.Logistica.Distribucion.desembarqueController().desembarcarEmbarque(Convert.ToInt32(txtEmbarque.Text), labelUbicacion.Text, data))
                {
                    gridControl1.DataSource = null;
                    MessageBox.Show("Desembarcado Exitoso");
                }
            }
            else MessageBox.Show("Falta escanear Facturas");

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
