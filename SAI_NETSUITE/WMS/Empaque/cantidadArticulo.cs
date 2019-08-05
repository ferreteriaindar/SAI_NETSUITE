using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAI_NETSUITE.WMS.Empaque
{
    public partial class cantidadArticulo : DevExpress.XtraEditors.XtraForm
    {

        public decimal cantidad=-1;
        string articulo = "", cantart = "0";
        public cantidadArticulo(string art,string cant)
        {
            articulo = art;
            cantart = cant.ToString();
            InitializeComponent();
        }


        public void cierra()
        {
            if (Convert.ToDecimal(txtCantidad.Text) > Convert.ToDecimal(cantart))
            {
                MessageBox.Show("Excede la cantidad requerida");
            }
            else
            {
                cantidad = Convert.ToDecimal(txtCantidad.Text);
                this.Close();
            }
        
        
        }
        public void salir()
        {
            cantidad = -1;
            this.Close();
        
        }
        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cierra();
            
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cierra();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void cantidadArticulo_Load(object sender, EventArgs e)
        {
            txtCantidad.Select();
            txtCantidad.Text = cantart;
            labelArticulo.Text = articulo;
            Console.WriteLine(cantart);
        }

        private void cantidadArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
           // cantidad = -1;
        }
    }
}
