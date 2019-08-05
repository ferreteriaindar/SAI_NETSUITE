using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAI_NETSUITE.WMS.Reportes
{
    public partial class detalleReporte : Form
    {
        string query, sqlString;
        public detalleReporte(string qry,string sql)
        {
            query = qry;
            sqlString = sql;
            InitializeComponent();

        }


        public void cargaInfo()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];


                myConnection.Close();
                myConnection.Dispose();
                da.Dispose();
        
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void detalleReporte_Load(object sender, EventArgs e)
        {
            cargaInfo();
        }
    }
}
