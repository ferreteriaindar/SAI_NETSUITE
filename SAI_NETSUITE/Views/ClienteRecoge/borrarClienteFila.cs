using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class borrarClienteFila : Form
    {
        public static ComboBox C = new ComboBox();
        public borrarClienteFila()
        {
            InitializeComponent();
            C = comboBox1;
        }

        private void borrarClienteFila_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
