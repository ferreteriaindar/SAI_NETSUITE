using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SAI_NETSUITE.Views.CXC
{
    public partial class entrega_block : UserControl
    {
      //  SqlConnection myConnection;
      //  SqlConnection myConnection2 = new SqlConnection("Data Source=192.168.87.100;" + "Initial Catalog=indarneg;" + "User id=sa;" + "Password=7Ind4r7;");

        string nombre, perfil;
        public entrega_block(string nom,string profile)
        {
            
            nombre = nom;
            perfil = profile;
            InitializeComponent();
          
            muestra_blocks();
        }

        private void muestra_blocks()
        {
            /*
            myConnection2.Open();
            string query = " select * from recibo_folios order by id desc;";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection2);
            DataSet ds = new DataSet();
            da.Fill(ds, "id");
           grid_block.DataSource = ds.Tables["id"];


            myConnection2.Close();
            */
        }


        private void guarda_sql()
        {

            SqlConnection myConnection2 = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            string query;
            int ultimo_block = 0, folio_fin = 0;
            myConnection2.Close();
            myConnection2.Open();
            query = "SELECT  top 1 * FROM    INDARNEG.DBO.recibo_folios ORDER BY ID DESC  ";
            SqlCommand cmd = new SqlCommand(query, myConnection2);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ultimo_block = Convert.ToInt32(sdr.GetValue(0).ToString());
                folio_fin = Convert.ToInt32(sdr.GetValue(5).ToString());


            }
            myConnection2.Close();

            //ultimo_block = Convert.ToInt32(grid_block.Rows[0].Cells[0].Value.ToString());
            //folio_fin = Convert.ToInt32(grid_block.Rows[0].Cells[5].Value.ToString());
            myConnection2.Close();
            myConnection2.Open();
            Debug.Write(ultimo_block);
            query = "insert into  INDARNEG.DBO.recibo_folios (id,nombre,fecha,serie,folio_inicio,folio_fin,cantidad,comentarios) values(@id,@nombre,@fecha,@serie,@folio_inicio,@folio_fin,@cantidad,@comentarios)";
            SqlCommand cmd2 = new SqlCommand(query, myConnection2);

            cmd2.Parameters.AddWithValue("@id", (ultimo_block + 1).ToString());
            cmd2.Parameters.AddWithValue("@nombre",searchEmpleado.Properties.GetDisplayText(searchEmpleado.EditValue));
            cmd2.Parameters.AddWithValue("@fecha", masked_fecha.Text);
            cmd2.Parameters.AddWithValue("@serie", txt_serie.Text);
            cmd2.Parameters.AddWithValue("@folio_inicio", (folio_fin + 1).ToString());
            cmd2.Parameters.AddWithValue("@folio_fin", (folio_fin + 50).ToString());
            cmd2.Parameters.AddWithValue("@cantidad", 50);
            cmd2.Parameters.AddWithValue("@comentarios", "entregado por: " + nombre + "  \n" + txt_comentarios.Text);
            
            cmd2.ExecuteNonQuery();
            myConnection2.Close();

            cargaInfo();
        }


        private void verifica_consecutivo()
        {
            /*myConnection2.Open();
            string checa, query = "select top 1 id,folio_inicio from recibo_folios where agente='" + txt_agente.Text.ToUpper() + "' order by id desc;";
            SqlCommand cmd = new SqlCommand(query, myConnection2);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {

                Procesos.Pagos.consecutivo conse = new Procesos.Pagos.consecutivo(sdr.GetValue(1).ToString());
                conse.ShowDialog();
                checa = Procesos.Pagos.consecutivo.t.Text;
                if (checa.Equals("si"))
                    guarda_sql();
                myConnection2.Close();
            }
            else*/ guarda_sql();
          //  myConnection2.Close();
        }


        private void presiona_enter(object sender, KeyPressEventArgs e)
        {
/*
            myConnection.Open();
            if (e.KeyChar == (char)13)
            {
                string query = "select nombre from agente where agente='" + txt_agente.Text.ToUpper() + "' and Estatus='ALTA'";
                SqlCommand cmd = new SqlCommand(query,myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    txt_nombre.Text = sdr.GetValue(0).ToString();
                }
                else { txt_nombre.Text = ""; MessageBox.Show("No exise ese Agente"); }
            }
            myConnection.Close();
           */
            
        }

        private void abre_buscarAgente(object sender, EventArgs e)
        {
          /*  SAI.Procesos.Pagos.buscaAgente ba = new buscaAgente(myConnection);
            ba.ShowDialog();
            txt_agente.Text = SAI.Procesos.Pagos.buscaAgente.t.Text;
            KeyPressEventArgs kpea = new KeyPressEventArgs((char)Keys.Enter);
            presiona_enter(null, kpea);*/
        }

        private void entrega_block_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reciboFoliosBlockDataSET.recibo_folios' table. You can move, or remove it, as needed.
  
            masked_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            List<Models.Catalogos.Empleado> lista = llenaEmpleados();
            searchEmpleado.Properties.DataSource = lista;
            cargaInfo();
        }

        public void cargaInfo()
        {
            SqlConnection myConnectio = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            string query = @"		SELECT        id, nombre, fecha, serie, folio_inicio, folio_fin, cantidad, comentarios, agente
                                    FROM            indarneg.dbo.recibo_folios
                                    ORDER BY id DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnectio);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            guarda_sql();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt_comentarios.Text = "";
            txt_serie.Text = "";
        }

        public List<Models.Catalogos.Empleado> llenaEmpleados()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var emp = from x in ctx.Entity.Where(s => s.ENTITY_TYPE.Equals("Employee")) select new Models.Catalogos.Empleado() { id = x.ENTITY_ID, nombre = x.NAME };
                return emp.ToList();

            }

        }

    }
}
