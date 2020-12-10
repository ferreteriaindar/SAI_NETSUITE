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

namespace SAI_NETSUITE.Views.Compras
{
    public partial class ActualizaBasesCompras : UserControl
    {
        public ActualizaBasesCompras()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string tipo =(string) e.Argument;
            string SQLsp="";

            switch (tipo)
            {
                case "btnArticuloWeb":  SQLsp = "sp_NS_Actulizaarticulos";
                    break;
                case "btnPromoCompras":  SQLsp = "sp_NS_ActulizaPromosCompras";
                    break;
                default:  SQLsp = "error";
                    break;

            }

            if (SQLsp.Equals("error"))
                e.Result = "error";
            else
            {
                try
                {
                    using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.SERVERWEB))
                    {
                        string query = "EXEC "+ SQLsp;
                        myConnection.Open();
                        SqlCommand cmd = new SqlCommand(query, myConnection);
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                        myConnection.Close();
                        e.Result = "OK";
                    };
                }
                catch (SqlException ex)
                {
                    e.Result = ex.Message;
                }
            }

        }

        private void btnArticuloWeb_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                btnArticuloWeb.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                backgroundWorker1.RunWorkerAsync(argument: "btnArticuloWeb");
            }
            else MessageBox.Show("Espera a que termine el proceso  -_-!");
        }

        private void btnPromoCompras_Click(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
            {
                btnPromoCompras.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                backgroundWorker1.RunWorkerAsync(argument: "btnPromoCompras");
            }
            else MessageBox.Show("Espera a que termine el proceso  -_-!");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnPromoCompras.ImageOptions.Image = null;
            btnArticuloWeb.ImageOptions.Image = null;
            string resultado = (string)e.Result;
            if(resultado.Equals("OK"))
                MessageBox.Show("PROCESO TERMINADO CON EXITO!");
            else
            {
                MessageBox.Show(resultado);
            }
        }
    }
}
