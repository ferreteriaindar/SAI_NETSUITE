using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.WMS.Empaque
{
    public partial class empaque : DevExpress.XtraEditors.XtraUserControl
    {
        string sqlString, idOrdenEmbarque, idempaque;
        int IdUsuarioWms;
        DataTable dt;
        public empaque(string sql,int idwms)
        {
           sqlString= "Data Source=192.168.87.100;" + "Initial Catalog=INDAR_INACTIONWMS_PRUEBAS;" + "User id=sa;" + "Password=7Ind4r7;";
           // sqlString = sql;
            IdUsuarioWms = idwms;
            InitializeComponent();
        }

        private void empaque_Load(object sender, EventArgs e)
        {
            cargaPedidosLista();
        }


        public void cargaPedidosLista()
        {
            SqlConnection myConnnection = new SqlConnection(sqlString);
            string query = "exec INDAR_INACTIONWMS_pruebas.dbo.spObtenerOrdenesEmpaque ";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            searchLookUpEdit1.Properties.DataSource = ds.Tables[0];
            searchLookUpEdit1.Properties.ValueMember = "IDORDENEMBARQUE";
            searchLookUpEdit1.Properties.DisplayMember = "NOPEDIDO";
        
        
        }
        public void inicializaDT()
        {
            dt = new DataTable();
            dt.Columns.Add("ARTICULO", typeof(string));
            dt.Columns.Add("DESCRIPCION", typeof(string));
            dt.Columns.Add("CANTIDAD", typeof(decimal));
            dt.Columns.Add("TOTAL", typeof(decimal));
            dt.TableName = "pedido";
           
            gridControl1.DataSource = dt;
        }

        private void btnPorPedido_Click(object sender, EventArgs e)
        {
            idOrdenEmbarque = "";
            idempaque = "";
            if (!dxValidationProvider1.Validate())
                MessageBox.Show("Escoge al menos un pedido");
            else
            {
                inicializaDT();
                SqlConnection myConnnection = new SqlConnection(sqlString);
                myConnnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnnection);
                cmd.CommandText = @"exec INDAR_INACTIONWMS_PRUEBAS.dbo.spEmpaqueValidarOrden " + searchLookUpEdit1.EditValue.ToString() + "," + IdUsuarioWms.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read() && sdr.HasRows)
                {
                    if (!sdr.GetValue(1).ToString().Equals("0"))
                    {
                        MessageBox.Show("Este pedido lo esta empacando otra personas verifica");
                    }
                    else
                    {
                        InicializaEmpaque(searchLookUpEdit1.EditValue.ToString(), IdUsuarioWms);
                    }
                    idOrdenEmbarque = searchLookUpEdit1.EditValue.ToString();
                
                }
            
            }
        }


        public void InicializaEmpaque(string idPedido, int idUsuario)
        { 
        
                           SqlConnection myConnnection = new SqlConnection(sqlString);
           
                myConnnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnnection);
                cmd.CommandText = @"exec INDAR_INACTIONWMS_PRUEBAS.dbo.spEmpaqueIniciarProceso " + idPedido + "," + idUsuario.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read() && sdr.HasRows)
                {
                     idempaque = sdr.GetValue(0).ToString();
                    int cantidad = Convert.ToInt32(sdr.GetValue(1).ToString());
                    string pf = sdr.GetValue(2).ToString();
                    string pp = sdr.GetValue(3).ToString();
                    labelPF.Text = "PF:"+pf;
                    labelPP.Text = "PP: " + pp;
                    groupControl2.Visible = true;
                    labelPedido.Text = searchLookUpEdit1.Properties.GetDisplayTextByKeyValue(searchLookUpEdit1.EditValue);
                }

        
        }

        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            detallePedido dt = new detallePedido(sqlString, idOrdenEmbarque, 0);
          
            dt.ShowDialog();
        }

        private void btnInfoPedido_Click(object sender, EventArgs e)
        {
            detallePedido dt = new detallePedido(sqlString, idOrdenEmbarque, 1);
          
            dt.ShowDialog();
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cuentaArticulo(txtCodigoBarras.Text, idOrdenEmbarque);
                txtCodigoBarras.Text = "";
                txtCodigoBarras.Select();
           
            }
        }

        public int estaCompleto(string articulo, decimal cantidad)
        {

            //regresa 1 SI ESTA COMPLETO, REGRESA 0 SI NO ESTA COMPLETO  Y REGRESA 2 SI EXCEDE
            int regresa;
            regresa = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, colArticulo).ToString().Equals(articulo))
                {
                    decimal actual = Convert.ToDecimal(gridView1.GetRowCellValue(i, colCantidad).ToString());
                    decimal total = Convert.ToDecimal(gridView1.GetRowCellValue(i, colTotal).ToString());
                    if(actual==total)
                    regresa = 1;
                 
                  
                }
            }
            return regresa;
        }

        public bool esNuevo(string art)
        {
            bool regresa;
            regresa = true;
            for (int i = 0; i < gridView1.RowCount;i++ )
            {
                if (gridView1.GetRowCellValue(i, colArticulo).ToString().Equals(art))
                    regresa = false;
                Console.WriteLine("No es NUEVO" + art);
            }
           Console.WriteLine("si es nuevo "+art);
           return regresa;
        }



        public void sumaArticulo(string art, decimal contado)
        {
            Console.WriteLine("ENTRA SUMA\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().Equals(art))
                {
                    Console.WriteLine(dt.Rows[i][0].ToString()+"="+art);
                    decimal actual = Convert.ToDecimal(dt.Rows[i][2].ToString());
                    decimal total = Convert.ToDecimal(dt.Rows[1][3].ToString());
                    if ((actual + contado) > total)
                        MessageBox.Show("La cantidad excede");
                    else
                    {
                        actual += contado;
                        dt.Rows[i][2] = actual;
                    }
                       
                }
            
            }
        //    for (int i = 0; i < gridView1.RowCount; i++)
        //    {
        //        if (gridView1.GetRowCellValue(i, colArticulo).ToString().Equals(art))
        //        {
        //            decimal actual = Convert.ToDecimal(gridView1.GetRowCellValue(i, colCantidad).ToString());
        //            actual += actual + contado;
        //            gridView1.SetRowCellValue(i, colCantidad, actual);
        //        }
         //   }
        
        
        }
        public void cuentaArticulo(string articulo, string idOrden)
        {
            string art = "",descripcion="";
            decimal cant = 0;
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("", myConnection);
            cmd.CommandText = "exec INDAR_INACTIONWMS_pruebas.dbo.spObtenerArticulosEmpaque " + idOrden + ",N'" + articulo + "'";
            Console.WriteLine(cmd.CommandText);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read() && sdr.HasRows)
            {
                art = sdr.GetValue(1).ToString();
                descripcion=sdr.GetValue(2).ToString();
                cant = Convert.ToDecimal(sdr.GetValue(3).ToString());
                Console.WriteLine(art);
            
            }
            if (art.Equals("NoValido")|| art.Equals("NoExiste"))
                MessageBox.Show("Articulo no Valido");
            else
            {
                
                //Valida si ya esta completo  PRIMERo  haz un if con una funcion
                cantidadArticulo ca = new cantidadArticulo(art, cant.ToString());
                ca.StartPosition = FormStartPosition.CenterScreen;
                ca.ShowDialog();
                Console.WriteLine("CANTIDAD"+ca.cantidad);
                if (ca.cantidad!=-1) // detect qu eno haya cerrado la ventana
                {

                  //  Console.WriteLine("Entra:"+ca.cantidad.ToString());
                    if (estaCompleto(art, ca.cantidad)==1)
                        MessageBox.Show("El articulo ya esta empacado");
                    else
                    {
                        sumaArticulo(art, ca.cantidad);
                        gridControl1.DataSource = null;
                        gridControl1.DataSource = dt;
                    }
                    if (esNuevo(art)) /// CHECA SI  EL ARTICULO ES LA PRIMERA VEZ QUE LO INGRESA
                    {
                        dt.Rows.Add(art, descripcion, ca.cantidad,cant);
                      
                        gridControl1.DataSource = null;
                        gridControl1.DataSource = dt;
                
                      
                    }
                    
                    //if (estaCompleto(art, cant))
                    //    MessageBox.Show("ya esta completo ese articulo");
                }
            }
            
        
        
        }

        public void agregaArticulo(string arti, string descri, decimal canti)
        {
            gridView1.AddNewRow();
            int rowHandle = gridView1.GetRowHandle(gridView1.DataRowCount);
            if (gridView1.IsNewItemRow(rowHandle))
            {
                gridView1.SetRowCellValue(rowHandle, gridView1.Columns[0], arti);
                gridView1.SetRowCellValue(rowHandle, gridView1.Columns[1], descri);
                gridView1.SetRowCellValue(rowHandle, gridView1.Columns[2], canti);
            }
        
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
         
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            Empaque.kilogramos kg = new kilogramos();
            kg.StartPosition = FormStartPosition.CenterScreen;
            kg.ShowDialog();
            if (!kg.kilos.Equals("NO"))
            {

                guardaUnitarios(kg.kilos);
            }
    
        }

        public string generaStringArticulo(string tipo)
        {
            string query = idOrdenEmbarque;
            if (tipo.Equals("GUARDAR"))
                query = query + "," + idempaque;
            query = query + ",N'";

                    for(int i=0;i<dt.Rows.Count;i++)
                      {
                          query = query + dt.Rows[i][0].ToString()+"|"+dt.Rows[i][2].ToString()+"|";
                          if ((dt.Rows.Count - i) == 1)
                              query = query + "2'";
                          else query = query + "2&";
                        }
                  if(tipo.Equals("GUARDAR"))
                      query=query+","+IdUsuarioWms;
               
            return query;        
        }

        public void guardaUnitarios(string kilos)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText ="exec dbo.spEmpaqueValidarUnitario "+ generaStringArticulo("VALIDAR");
                Console.WriteLine("QUERY VALIDAR\n");
                Console.WriteLine(cmd.CommandText);


                cmd.ExecuteNonQuery();
                cmd.CommandText ="exec dbo.spEmpaqueGuardarUnitario "+ generaStringArticulo("GUARDAR");
                Console.WriteLine("QUERY Guardar\n");
                Console.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                cmd.CommandText = "exec dbo.spGenerarEtiquetaCajaEmpaque N'',N'" + kilos + "'," + IdUsuarioWms.ToString();
                string etiqueta = cmd.ExecuteScalar().ToString();
                Console.WriteLine("ETIQUETA: "+etiqueta);
                if (searchLookUpEdit1.Properties.GetDisplayTextByKeyValue(searchLookUpEdit1.EditValue).Contains("CONS"))
                {
                    cmd.CommandText = "exec dbo.spEmpaqueImprimirEtiquetaCajaTarima " + idOrdenEmbarque + ",N'" + etiqueta + @"',N'',N'CajaEmpaque',1";
                }else cmd.CommandText="exec dbo.spEmpaqueImprimirEtiquetaCajaTarima "+idOrdenEmbarque+",N'"+etiqueta+@"',N'',N'CajaEmpaque',0";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "exec dbo.spEmpaqueRelacionarEtiquetaCajaEmpaque " + idempaque + ",N'" + etiqueta + "',N''," + IdUsuarioWms.ToString();

                //cmd.CommandText = "exec dbo.spEmpaqueObtenerLocalidadDestino " + idempaque + "," + idOrdenEmbarque;
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "exec dbo.spEmpaqueCargarCajasEmpacadas " + idOrdenEmbarque;
                //cmd.ExecuteNonQuery();
                ////REVISAR EL QUERY CUANDO SOLO PONGO UNA ETIQUETA SIN COMPLETAR EL PEDIDO
                //cmd.CommandText = "exec dbo.spEmpaqueImprimirEtiquetaCajaTarima "+idempaque+",N'',N'N/A',N'PackingList',0";
                ////exec dbo.spEmpaqueImprimirEtiquetaCajaTarima 106591,N'C1804160010',N'',N'CajaEmpaque',0
                ////exec dbo.spEmpaqueRelacionarEtiquetaCajaEmpaque 106591,N'C1804160010',N'',47
                ////exec dbo.spEmpaqueObtenerLocalidadDestino 106591,104781
                ////exec dbo.spEmpaqueCargarCajasEmpacadas 104781
                ////CUANDO   ESCANEAS LA ETIQUETA  Y ANTES DEL LPEXX
                ////exec dbo.spEmpaqueDepositarEmpacado 106591,N'LPE045',N'113457',47

                //cmd.ExecuteNonQuery();
                //MessageBox.Show("EMPACADO");


                
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en Validar Unitarios Reintentar");
            }
           
        
        }

        private void btnEmbarque_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
        
         
           string query = @"SELECT 'C1804180001' AS CAJAEMPAQUE, CASE WHEN MAX(OE.CONSOLIDADO) IS NULL THEN MAX(OE.NUMPEDIDO) ELSE MAX(OE.CONSOLIDADO) END AS FACTURA,
		CASE WHEN MAX(OE.CONSOLIDADO) IS NULL THEN MAX(OE.Mov) ELSE MAX(OE.CONSOLIDADO) END AS TIPOPEDIDO,
		C.CLAVE AS CLIENTE, C.NOMBRE AS NOMCLIENTE, ISNULL(OE.FLETERA, '') AS RUTA, (SELECT SUM(PESO) FROM CAJAEMPAQUE WHERE CODIGO = 'C1804180001') AS PESO,
		-- CASE WHEN OE.LUGARENVIO IS NOT NULL THEN SUBSTRING(OE.LUGARENVIO,1,24) ELSE CASE WHEN C.DIRECCION IS NOT NULL THEN SUBSTRING(C.DIRECCION,1,24) ELSE 'SIN DATOS' END END AS DESTINO,
		CASE WHEN OE.LUGARENVIO IS NOT NULL THEN OE.LUGARENVIO ELSE CASE WHEN C.DIRECCION IS NOT NULL THEN C.DIRECCION ELSE 'SIN DATOS' END END AS DESTINO,
		est.clave  AS PRODUCTO, CASE WHEN LEN(EST.DESCRIPCION) < 25 THEN est.descripcion ELSE EST.DESCRIPCION END AS DESCRIPCION, EST.UNIDAD AS UNIDAD, SUM(U.CANTIDAD) AS CANTIDAD, US.USUARIO		FROM ORDENEMBARQUE OE INNER JOIN EMPAQUE E ON OE.IDORDENEMBARQUE = E.IDORDENEMBARQUE		INNER JOIN EMPAQUEDETALLE ED ON ED.IDEMPAQUE = E.IDEMPAQUE		INNER JOIN UNITARIO U ON U.IDUNITARIO = ED.IDUNITARIO		INNER JOIN PRODUCTO P ON P.IDPRODUCTO = U.IDPRODUCTO		INNER JOIN ESTILO EST ON EST.IDESTILO = P.IDESTILO		INNER JOIN CLIENTE C ON C.IDCLIENTE = OE.IDCLIENTE		INNER JOIN USUARIO US ON US.IDUSUARIO = ED.IDUSUARIOACTUALIZA		WHERE E.IdEmpaque = 127295		GROUP BY C.CLAVE, C.NOMBRE, EST.CLAVE, EST.DESCRIPCION, EST.UNIDAD, US.USUARIO, OE.FLETERA, OE.LUGARENVIO, C.DIRECCION";
           SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
           DataSet ds = new DataSet();
           da.Fill(ds);
           ds.WriteXmlSchema(@"S:\XML\Almacen\etiqueta.xml");

        }


    }
}
