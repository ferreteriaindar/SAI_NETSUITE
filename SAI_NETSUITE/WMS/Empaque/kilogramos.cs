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
    public partial class kilogramos : Form
    {

        public string kilos;
        public kilogramos()
        {
            kilos = "NO";
            InitializeComponent();
        }

        private void kilogramos_Load(object sender, EventArgs e)
        {
       
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            kilos = "NO";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            kilos = txtCantidad.Text;
            this.Close();
        }
    }
}
