using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using DevExpress.XtraReports.UI;

namespace SAI_NETSUITE.WMS
{
    public partial class wms_usuarios : UserControl
    {
        string sqlString;
        public wms_usuarios(string sql)
        {
            sqlString = sql;
            InitializeComponent();
        }

        private void wms_usuarios_Load(object sender, EventArgs e)
        {
            cargaUsuarios();
        }

        public void cargaUsuarios()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = @"select u.Nombre,
                            u.Usuario,
                            recibo= ISNULL( (select  case when nombre='Recibo' then 'SI' ELSE 'NO' END from INDGDLSQL01.INDAR_INACTIONWMS.dbo.modulo m left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Permiso p on p.IdModulo=m.IdModulo where p.IdUsuario=U.IdUsuario and m.Nombre='Recibo') ,'NO'),
                            almacenado= ISNULL((select  case when nombre='Almacenado' then 'SI' ELSE 'NO' END from INDGDLSQL01.INDAR_INACTIONWMS.dbo.modulo m left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Permiso p on p.IdModulo=m.IdModulo where p.IdUsuario=U.IdUsuario and m.Nombre='Almacenado') ,'NO'),
                            traspaso= ISNULL( (select  case when nombre='Traspaso' then 'SI' ELSE 'NO' END from INDGDLSQL01.INDAR_INACTIONWMS.dbo.modulo m left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Permiso p on p.IdModulo=m.IdModulo where p.IdUsuario=U.IdUsuario and m.Nombre='Traspaso'),'NO') ,
                            Supervisor = case when u.IDTIPOUSUARIO=1 then 'SI' else 'NO' END 
                             from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuario u";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        
        }

        private void btnGenerarCredencial_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("nombre", typeof(string));
            dt.Columns.Add("usuario", typeof(string));
            dt.Columns.Add("pass", typeof(string));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoUsuarios_Click(object sender, EventArgs e)
        {
            if(dxValidationProvider1.Validate())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("nombre", typeof(string));
                dt.Columns.Add("usuario", typeof(string));
                dt.Columns.Add("pass", typeof(string));

                int  supervisor=0,recibo=0,acomodo=0;
                if(checkNuevoSupervisor.Checked)
                    supervisor=1;
                if(checkNuevoRecibo.Checked)
                    recibo=1;
                if(checkNuevoAcomodo.Checked)
                    acomodo=1;


                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"insert into INDGDLSQL01.INDAR_INACTIONWMS.dbo.Usuarios_proceso (Nombrecompleto,Usuario,Contrasenia,IdTipoUsuario,Recibo,Almacenado,Traspaso,InventarioFisico) 
                               VALUES (@Nombrecompleto,@Usuario,@Contrasenia,@IdTipoUsuario,@Recibo,@Almacenado,@Traspaso,@InventarioFisico)";
                cmd.Parameters.AddWithValue("@Nombrecompleto", txtNuevoUsuarios.Text);
                cmd.Parameters.AddWithValue("@Usuario", txtNuevoNumEMP.Text);
                cmd.Parameters.AddWithValue("@Contrasenia", txtNuevoPass.Text);
                cmd.Parameters.AddWithValue("@IdTipoUsuario", supervisor);
                cmd.Parameters.AddWithValue("@Recibo", recibo);
                cmd.Parameters.AddWithValue("@Almacenado", acomodo);
                cmd.Parameters.AddWithValue("@Traspaso", acomodo);
                cmd.Parameters.AddWithValue("@InventarioFisico", acomodo);
                cmd.ExecuteNonQuery();


                dt.Rows.Add(txtNuevoUsuarios.Text, txtNuevoNumEMP.Text, txtNuevoPass.Text);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                credencialWMS cwms = new credencialWMS();
                cwms.DataSource = ds;
                
                using ( ReportPrintTool printTool = new ReportPrintTool(cwms))
                {
                   // printTool.Print();
                    //or printTool.PrintDialog();
                   // printTool.ShowPreview();
                    printTool.ShowRibbonPreviewDialog();
                }
            // ds.WriteXmlSchema(@"S:\XML\Almacen\credencialwms.xml");
            }
        }
    }
}
