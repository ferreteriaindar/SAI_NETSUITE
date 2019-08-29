using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    public partial class NumerodGuia2cs : UserControl
    {
        DataTable dt = new DataTable();
        string sqlString, cliente, usuario;
        int total;
        public NumerodGuia2cs(string sql,string usr)
        {
           // sqlString = "Data Source=192.168.87.3;" + "Initial Catalog=IndarPruebas;" + "User id=sa;" + "Password=7Ind4r7;";
            sqlString = sql;
            usuario = usr;
            InitializeComponent();
            //InitializeComponent();
            dt.Columns.Add("movid", typeof(string));
            dt.Columns.Add("idfactura", typeof(string));
            dt.Columns.Add("idpedido", typeof(string));
            dt.Columns.Add("numeroguiafletera", typeof(string));
            dt.Columns.Add("autoriza", typeof(string));
            dt.Columns.Add("error", typeof(string));
            dt.Columns.Add("solucion", typeof(string));
            dt.Columns.Add("accion", typeof(string));
            dt.Columns.Add("tipoError", typeof(string));
            dt.Columns.Add("cliente", typeof(string));
            dt.Clear();
        }

        public void cargaFleteras()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = "select LIST_ITEM_NAME as fletera from iws.dbo.Paqueteria";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
                      gridLookUpEdit1.Properties.DataSource = ds.Tables[0];
            gridLookUpEdit1.Properties.ValueMember = "fletera";
           


        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            txtGuia.Select();
            gridLookUpEdit1.Enabled = false;
            buscaClaveFletera();
          
        }

        public void buscaClaveFletera()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select codigo from indarneg.dbo.fleteras where fletera='"+gridLookUpEdit1.EditValue.ToString()+"'";
            var resultado = cmd.ExecuteScalar().ToString();
            txtFletera.Text = resultado.ToString();
        
        }

        private void NumerodGuia2cs_Load(object sender, EventArgs e)
        {
            cargaFleteras();
            progressBarControl1.EditValue = 0;
        }

        private void txtGuia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtImporte.Select();
            }
        }


        public bool regresaTotalCliente()
        {
            int contar = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colCliente).ToString().Equals(cliente))
                    contar++;
            }

            if (contar == total) 
                    return true;
            else return false;
           
        }

        public bool repetido()
        {
            if (gridView1.RowCount == 0)
                return false;
            for (int i = 0; i < gridView1.RowCount; i++)
            { 
                if(txtFactura.Text.Equals(gridView1.GetRowCellValue(i,colfactura).ToString()))
                    return true;
            }
            return false;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(!txtFactura.Text.Equals(""))
            {
                if (!repetido())
                {
                    if (gridView1.RowCount == 0)
                    {
                        cliente = regresaCliente();
                        labelCliente.Text = "Cliente: " + cliente;
                        total = regresaTotalDocumentos();
                    }
                    SqlConnection myConnection = new SqlConnection(sqlString);
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    cmd.CommandText = "SELECT CASE WHEN EXISTS (select em.movid  " +
                                     "   from  EmbarqueD ed  " +
                                     "     JOIN EmbarqueMov em ON ED.EmbarqueMov=EM.ID  " +
                                     "   where  em.modulo='VTAS' " +
                                     "   and em.asignadoid=(select id from embarque where movid='" + txtEmbarque.Text + "' and mov='Embarque') " +
                                     "   and em.movid='" + txtFactura.Text + "' and em.cliente='" + cliente + "'" +
                                     "   group by em.movid)  " +
                                     "   then (select  case when numeroguiafletera is  null then 'SI' ELSE 'GUIA' end from venta where movid='" + txtFactura.Text + "'and mov='Factura Indar' and estatus='Concluido')   " +
                                     "   else 'ERROR' end as resultado";
                    Console.WriteLine(cmd.CommandText);
                    var resultado = cmd.ExecuteScalar().ToString();
                    if (resultado.ToString().Equals("ERROR") || resultado.ToString().Equals("GUIA"))
                    {

                        FlyoutAction action = new FlyoutAction();
                        action.Caption = "ATENCION";
                        if (ErrorPerteneceAlEmbarque())
                            action.Description = "Esta Factura si pertenece al embarque pero no al cliente  \n Se requiere Autorizacion";
                        if (!ErrorPerteneceAlEmbarque() && resultado.ToString().Equals("ERROR"))
                            action.Description = "Esta Factura no pertenece al embarque   \n Se requiere Autorizacion";
                        if (resultado.ToString().Equals("GUIA"))
                            action.Description = "Esta Factura ya tiene un numero de guia registrado  \n Se requiere Autorizacion";
                        action.Commands.Add(FlyoutCommand.OK);
                        action.Image = SAI_NETSUITE.Properties.Resources.Error_icon;
                        FlyoutDialog.Show(this.FindForm(), action);
                        string tipo = "";
                        if (ErrorPerteneceAlEmbarque() && resultado.ToString().Equals("ERROR"))
                        {
                            tipo = "Pertenece EMB,NO ES EL CLIENTE";
                        }
                        else if (!ErrorPerteneceAlEmbarque() && resultado.ToString().Equals("ERROR"))
                        {
                            tipo = "No Pertenece al EMB";
                        }
                        if (resultado.ToString().Equals("GUIA"))
                        {
                            tipo = "Ya tiene numero de Guia";
                        }


                        using (var form = new AutorizacionJefe(sqlString, txtEmbarque.Text, txtGuia.Text, tipo, txtFactura.Text))
                        {
                            var result = form.ShowDialog();
                            if (form.dr == DialogResult.OK)
                            {
                                dt.Rows.Add(txtFactura.Text, regresaId(txtFactura.Text, "Factura"), regresaId(txtFactura.Text, "Pedido"), "", AutorizacionJefe.combo.Text, AutorizacionJefe.t.Text, AutorizacionJefe.t2.Text, "SI", tipo,regresaCliente());

                            }
                        }
                        gridControl1.DataSource = dt;
                        //AutorizacionJefe aj = new AutorizacionJefe(sqlString);
                        //aj.ShowDialog();





                    }
                    else
                    { ////AQUI ES SI ES TODO NORMAL
                        SqlConnection myConnectionAux = new SqlConnection(sqlString);
                        myConnectionAux.Open();
                        SqlCommand cmd2 = new SqlCommand("", myConnectionAux);
                        cmd2.CommandText = "select em.movid,v.id as idfactura,v3.id as idpedido, isnull(v.numeroguiafletera,'OK') AS numeroguiafletera,em.cliente " +
                                         "   from  EmbarqueD ed  " +
                                         "     JOIN EmbarqueMov em ON ED.EmbarqueMov=EM.ID  " +
                                         "     LEFT join venta v on v.movid=em.movid and v.mov='Factura Indar' and v.estatus='Concluido'  " +
                                         "     left join venta  AS V2 ON V2.Mov = V.Origen and v2.movid=v.origenid and v2.mov='Pre Factura' " +
                                         "     left join venta as v3  ON V3.Mov = V2.Origen and v3.movid=v2.origenid and v3.mov in('Pedido','Pedido BO','Pedido SAD','Pedido Web') " +
                                         "   where  em.modulo='VTAS' " +
                                         "   and em.asignadoid=(select id from embarque where movid='" + txtEmbarque.Text + "' and mov='Embarque') " +
                                         "   and em.movid='" + txtFactura.Text + "' " +
                                         "   group by em.movid,v.id,v2.id,v3.id,v.numeroguiafletera,em.cliente";
                        Console.WriteLine(cmd2.CommandText);
                        SqlDataReader sdr = cmd2.ExecuteReader();
                        sdr.Read();
                        dt.Rows.Add(sdr.GetValue(0).ToString(), sdr.GetValue(1).ToString(), sdr.GetValue(2).ToString(), sdr.GetValue(3).ToString(), "", "", "", "NO", "", cliente);
                        gridControl1.DataSource = dt;


                    }
                    txtFactura.Text = "";
                    txtFactura.Select();
                    if (regresaTotalCliente())
                    {
                        btnGuardar.Visible = true;
                        FlyoutAction action = new FlyoutAction();
                        action.Caption = "ATENCION";
                        action.Description = "Ya estan registradas todas las facturas del cliente por favor guardar";
                        action.Commands.Add(FlyoutCommand.OK);
                        action.Image = SAI_NETSUITE.Properties.Resources.Error_icon;
                       FlyoutDialog.Show(this.FindForm(), action);
                        BtnAutorizaFaltantes.Visible = false;
                    }
                }
                else { MessageBox.Show("Factura Repetida"); txtFactura.Text = ""; txtFactura.Select(); }
            }
            revisaAvanceTotalEmbarque();
            actualizaBarra();

        }

        public int actualizaUltimoLista()
        {
            if (gridView1.RowCount == 0)
                return 1;
            else

                return gridView1.RowCount;
        }


        public void revisaAvanceTotalEmbarque()
        {

            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select idembarque from  indarneg.dbo.embarques where idembarque='" + txtEmbarque.Text + "'";
            var resultado = cmd.ExecuteScalar().ToString();

            for (int i = actualizaUltimoLista()-1; i < gridView1.RowCount; i++)
            {
                for (int j = 0; j < gridView2.RowCount; j++)
                {

                    //Console.WriteLine(gridView1.GetRowCellValue(i, colCliente).ToString());
                    //Console.WriteLine(gridView2.GetRowCellValue(j, colTopCliente).ToString());
                    //Console.WriteLine(resultado.ToString());
                    //Console.WriteLine(gridView2.GetRowCellValue(j, colTopId).ToString());
                    if (gridView1.GetRowCellValue(i, colCliente).ToString().Equals(gridView2.GetRowCellValue(j, colTopCliente).ToString()) && resultado.ToString().Equals(gridView2.GetRowCellValue(j, colTopId).ToString()))
                    {
                        if (Convert.ToDouble(gridView2.GetRowCellValue(j, colTopPrueba).ToString()) < 1)
                        {
                            double suma = Convert.ToDouble(gridView2.GetRowCellValue(j, colTopActual).ToString());
                            suma++;
                            gridView2.SetRowCellValue(j, colTopActual, suma);
                        }
                    }
                  
                }
            
            }
        
        
        }




        public string regresaId(string factura, string mov)
        {
              SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            if (mov.Equals("Factura"))
                cmd.CommandText = " select v.id from venta v where movid='" + factura + "' and mov='Factura Indar' and estatus='Concluido'";
            else cmd.CommandText = "select v3.id from venta v " +
                                "     left join venta  AS V2 ON V2.Mov = V.Origen and v2.movid=v.origenid and v2.mov='Pre Factura' " +
                                "     left join venta as v3  ON V3.Mov = V2.Origen and v3.movid=v2.origenid and v3.mov in('Pedido','Pedido BO','Pedido SAD','Pedido Web') " +
                                " where v.movid='" + factura + "' and v.mov='Factura Indar' and v.estatus='Concluido'";
                                
             var resultado= cmd.ExecuteScalar().ToString();
             return resultado.ToString();
        }

        public bool ErrorPerteneceAlEmbarque()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText=" select COUNT(EM.MOVID)   "+
                            "    from  EmbarqueD ed   "+
                            "      JOIN EmbarqueMov em ON ED.EmbarqueMov=EM.ID   "+
                            "    where  em.modulo='VTAS'  "+
                            "    and em.asignadoid=(select id from embarque where movid='"+txtEmbarque.Text+"' and mov='Embarque')  " +
                            "    and em.movid='"+txtFactura.Text+"'";
            var resultado = cmd.ExecuteScalar().ToString();
            if (resultado.ToString().Equals("0"))
                return false;
            else
            {
                //FlyoutAction action = new FlyoutAction();
                //action.Caption = "ATENCION";
                //action.Description = "Esta Factura si pertenece al embarque pero no al cliente  \n Se requiere Autorizacion";
                //action.Commands.Add(FlyoutCommand.OK);
                //action.Image = SAI.Properties.Resources.Error_icon;
                //FlyoutDialog.Show(this.FindForm(), action);
                return true;
            }

            
        }

        public int regresaTotalDocumentos()
        {

            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select COUNT(EM.MOVID)   "+
                              "  from  EmbarqueD ed   "+
                              "    JOIN EmbarqueMov em ON ED.EmbarqueMov=EM.ID   "+
                              "  where  em.modulo='VTAS'  "+
                              "  and em.asignadoid=(select id from embarque where movid='"+txtEmbarque.Text+"' and mov='Embarque')  " +
                              "   and em.cliente='"+regresaCliente()+"' ";
           // Console.WriteLine("TOTAL QUERY" + cmd.CommandText);
            int resultado = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            return resultado;
        }
        public string regresaCliente()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "select cliente from venta where movid='" + txtFactura.Text + "' and mov='Factura Indar' and estatus='Concluido'";
            var resultado = cmd.ExecuteScalar().ToString();
            return resultado.ToString();
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("Borrar Factura", "Confirmar", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
        }


        public bool  detectaRepetido()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().Equals(txtFactura.Text))
                {
                    return true;
                }
          
            }
            return false;
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAgregar_Click(null, null);
            }
        }

        private void txtBulto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAgregar_Click(null, null);
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
              //  txtFactura.Select();
                txtBulto.Select();
            }
        }

        public void registraGuiaFletera(string embarque,string guia,string importe,string bultos,string fletera )
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "insert into indarneg.dbo.numeroguia (embarque,numeroguia,importe,bultos,fecha,fletera) values(" +
                                " '" + embarque + "','" + guia + "'," + importe + "," + bultos + ",getdate(),'"+fletera+"')";
            cmd.ExecuteNonQuery();
            myConnection.Close();


        
        }

        public void enviaEmail(string autoriza,string factura,string error,string solucion)
        {
            MailMessage mail = new MailMessage();
            //mail.Attachments.Add(att);
            mail.From = new MailAddress("alertas@indar.com.mx", "Numero de Guia Indar");
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            string query = " select email from indarneg.dbo.sai_usuario  where perfil='Jefe Almacen' or usuario='Mvillalvazo'";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataReader sdr = cmd.ExecuteReader();
            //while (sdr.Read())
            //{
            //    mail.To.Add(new MailAddress(sdr.GetValue(0).ToString()));
            //}
            mail.To.Add(new MailAddress("rvelasco@indar.com.mx"));
            mail.Subject = " PRUEBA BORRAR Autorizacion de Registro de Numero de Guia" ;
            mail.Body = autoriza + " Autorizó el registro del numero de guia en la factura " + factura + " \n ERROR: " + error + " \n  SOLUCION: " + solucion + " \n \n \n \n Mensaje Generado desde el SAI";
            SmtpClient smtp = new SmtpClient("mail.indar.com.mx");
           // smtp.Send(mail);
        
        }

        public void registraElErrro(string embarque,string autoriza,string error,string solucion,string tipo,string guia)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "insert into indarneg.dbo.autorizacionnumeroguia (embarque,autoriza,error,solucion,tipo,fecha,guia) values (" +
                            " '" + embarque + "','" + autoriza + "','" + error + "','" + solucion + "','" + tipo + "',getdate(),'" + guia + "')";
            cmd.ExecuteNonQuery();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount >= 1 && ValidadorGuardar.Validate())
            {
                registraGuiaFletera(txtEmbarque.Text, txtGuia.Text, txtImporte.Text, txtBulto.Text, gridLookUpEdit1.EditValue.ToString());
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    //if (gridView1.GetRowCellValue(i, colAccion).ToString().Equals("SI"))
                    //{
                    //    enviaEmail(gridView1.GetRowCellValue(i, colAutoriza).ToString(), gridView1.GetRowCellValue(i, colfactura).ToString(), gridView1.GetRowCellValue(i, colerror).ToString(), gridView1.GetRowCellValue(i, colSolucion).ToString());
                    //  // Console.WriteLine(""
                    //   
                    //}
                    cmd.CommandText = "update venta  set fleteraIndar='" + gridLookUpEdit1.EditValue.ToString() + "', NumeroGuiaFletera ='" + txtGuia.Text + "' ,costoembarque=" + txtImporte.Text + ", facturaIndar='" + gridView1.GetRowCellValue(i, colfactura).ToString() + "' where id in ('" + gridView1.GetRowCellValue(i, colidfactura).ToString() + "','" + gridView1.GetRowCellValue(i, colidPedido).ToString() + "')";
                    cmd.ExecuteNonQuery();
                  
                  
                }
                dt.Clear();
                txtGuia.Text = "";
                txtImporte.Text = "";
                txtFactura.Text = "";
                txtBulto.Text = "";
                txtGuia.Select();
                cliente = "";

                if (Convert.ToDouble(progressBarControl1.EditValue.ToString()) >= 100)
                {
                    txtEmbarque.Text = "";
                    txtEmbarque.Select();
                    progressBarControl1.EditValue = 0;
                }



            }
            else MessageBox.Show("No hay ingresado Facturas");
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            dt.Clear();
            txtBulto.Text = "";
            txtFactura.Text = "";
            txtGuia.Text = "";
            txtImporte.Text = "";
            gridLookUpEdit1.Enabled = true;
            cargaFleteras();
            cliente = "";
            labelCliente.Text = "";


                 dt.Clear();
                txtGuia.Text = "";
                txtImporte.Text = "";
                txtFactura.Text = "";
                txtBulto.Text = "";
                txtGuia.Select();
                cliente = "";              
                    txtEmbarque.Text = "";
                    txtEmbarque.Enabled = true;
                    txtEmbarque.Select();
                    progressBarControl1.EditValue = 0;
                    gridTotal.DataSource = null;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {/*
            Distribucion.ReporteFacturas rf = new ReporteFacturas(sqlString);
            rf.Show();
            */
        }

        private void txtBulto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtFactura.Select();
            }
        }


        public void cargaEstatusRegistro()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = " select em.cliente,count(em.cliente)as total,e.id,0.0 as actual,0.0 as avance " +
                         "    from embarquemov em   " +
                         "    left join embarque e on em.asignadoid=e.id " +
                         "    where e.movid='"+txtEmbarque.Text+"' " +
                         "    group by em.cliente,e.id";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridTotal.DataSource = ds.Tables[0];
        
        
        }

        public void actualizaBarra()
        {
            double total=0, actual=0;
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                total = total + Convert.ToDouble(gridView2.GetRowCellValue(i, colTopTotal).ToString());
                actual = actual + Convert.ToDouble(gridView2.GetRowCellValue(i, colTopActual).ToString());
            }

            progressBarControl1.EditValue = (actual / total)*100;
           //

            if(Convert.ToDouble(progressBarControl1.EditValue.ToString())>=100)
            { 
                progressBarControl1.BackColor = Color.Green;
            FlyoutAction action = new FlyoutAction();
            action.Caption = "ACCION";
            action.Description = "EL EMBARQUE "+txtEmbarque.Text+" YA ESTA COMPLETO \n YA PUEDES LLEVARLO A POSTVENTA PARA SU VALIDACION";
            action.Commands.Add(FlyoutCommand.OK);
            //action.Image =SAI_NETSUITE.Properties.Resources.Documents_Black;
            FlyoutDialog.Show(this.FindForm(), action);
            registraenPOSTVENTA();
         
            }


           // Console.WriteLine("actual:" + actual + "total" + total + "resultado" + (actual / total).ToString());
        
        }


        public void registraenPOSTVENTA()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "insert into indarneg.dbo.validacionpostventaembarque (embarque,fecha,usuariodistribucion) "
                + "values ('" + txtEmbarque.Text + "',getdate(),'"+usuario+"')";
            cmd.ExecuteNonQuery();
            myConnection.Close();
            txtEmbarque.Enabled = true;
        
        }
        private void txtEmbarque_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)13)
            {
                txtEmbarque.Enabled = false;
                txtGuia.Select();
                cargaEstatusRegistro();
            }
            //if (e.KeyChar == (char)13)
            //{
            //    txtFactura.Select();
                   
               
            //}
        }



        public void preCarga()
        {
            SqlConnection myConecction = new SqlConnection(sqlString);
                            string query ="SELECT EmbarqueD.ID,  EmbarqueD.Orden, EmbarqueD.Estado, EmbarqueMov.Modulo,EmbarqueMov.ModuloID,EmbarqueMov.Mov,EmbarqueMov.MovID  "+
                                          "  , CAST(0 AS bit) as active, isnull(v.NumeroGuiaFletera,'OK') AS NumeroGuiaFletera,v.cliente "+
                                          "  FROM  EmbarqueD JOIN EmbarqueMov ON EmbarqueD.EmbarqueMov=EmbarqueMov.ID "+
                                          "  left join venta v on  EmbarqueMov.MovID=v.movid and v.mov='Factura Indar' and v.estatus='Concluido' "+
                                          "  left join cte ct on v.cliente=ct.cliente "+
                                          "   WHERE EmbarqueD.ID = (select id from embarque where movid="+txtEmbarque.Text+" and estatus not in('Sin Afectar','Cancelado') ) AND EmbarqueD.DesembarqueParcial=0  "+
                                          "   and ct.cliente=(select cliente from venta where movid="+txtFactura.Text+" and mov='Factura Indar' and estatus='Concluido') "+
                            "   ORDER BY EmbarqueD.Orden  ";
                            Console.WriteLine(query);
            SqlDataAdapter da = new SqlDataAdapter(query, myConecction);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];

        }

        private void BtnAutorizaFaltantes_Click(object sender, EventArgs e)
        {
            using (var form = new AutorizacionJefe(sqlString, txtEmbarque.Text, txtGuia.Text, "Faltante", txtFactura.Text,true,regresaFacturasFaltantes(),cliente))
            {
                var result = form.ShowDialog();
                if (form.dr == DialogResult.OK)
                {
                    ListView lista = AutorizacionJefe.list;
                    for (int i = 0; i < lista.Items.Count; i++)
                    {
                        dt.Rows.Add(lista.Items[i].SubItems[0].Text, regresaId(lista.Items[i].SubItems[0].Text, "Factura"), regresaId(lista.Items[i].SubItems[0].Text, "Pedido"), "OK", AutorizacionJefe.combo.Text, AutorizacionJefe.t.Text, AutorizacionJefe.t2.Text, "SI", "Faltante",cliente);
                    }

                }
            }
            if (regresaTotalCliente())
            {
                btnGuardar.Visible = true;
                FlyoutAction action = new FlyoutAction();
                action.Caption = "ATENCION";
                 action.Description = "Ya estan registradas todas las facturas del cliente por favor guardar";
                action.Commands.Add(FlyoutCommand.OK);
                action.Image = SAI_NETSUITE.Properties.Resources.Accept_icon;
                FlyoutDialog.Show(this.FindForm(), action);
                BtnAutorizaFaltantes.Visible = false;
            }

        }

        public string regresaFacturasFaltantes()
        {
            string encontradas="";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colCliente).ToString().Equals(cliente))
                { 
                    encontradas=encontradas+gridView1.GetRowCellValue(i,colfactura).ToString()+"@";
                }
            }
            Console.WriteLine("Antes de enviar:" + encontradas);
            return encontradas;

        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFletera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText="select fletera from fleteras where codigo='"+txtFletera.Text+"'";
                var resultado = cmd.ExecuteScalar().ToString();
                gridLookUpEdit1.EditValue = resultado.ToString();
                txtEmbarque.Select();
                gridLookUpEdit1.Enabled = false;
                     
            
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            actualizaBarra();
        }

        private void btnOtraGuia_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(null, null);
        }


       
    }
}
