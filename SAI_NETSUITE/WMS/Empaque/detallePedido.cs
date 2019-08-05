using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAI_NETSUITE.WMS.Empaque
{
    public partial class detallePedido : Form
    {
        string idOrdenEmbarque,sqlString;
        int detalle;
        public detallePedido(string sql,string  idorden,int det)
        {
            sqlString = sql;
            idOrdenEmbarque = idorden;
            detalle = det;
            InitializeComponent();
        }

        private void detallePedido_Load(object sender, EventArgs e)
        {
            carginfo();
        }

        public void carginfo()
        {
            try
            {
                SqlConnection myConnnection = new SqlConnection(sqlString);
                string query;
                if (detalle == 0)
                    query = "exec INDAR_INACTIONWMS.dbo.spEmpaqueConsultaPartidaEmpacada " + idOrdenEmbarque;
                else query = "exec INDAR_INACTIONWMS.dbo.spEmpaqueObtenerDetalleOrden " + idOrdenEmbarque;
                SqlDataAdapter da = new SqlDataAdapter(query, myConnnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            { 
             
            }
        
        }
    }
}
