﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI.Almacen.WMS.Reportes
{
    public partial class reporteSurtidoPickingCR : UserControl
    {
        public reporteSurtidoPickingCR()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            pivotGridControl1.DataSource = cargaInfo().Tables[0];
        }


        public DataSet cargaInfo()
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            { 
                string query="exec Indarwms.dbo.spNivelPickingCR";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
            
            }
         
            return ds;
        
        }
    }
}
