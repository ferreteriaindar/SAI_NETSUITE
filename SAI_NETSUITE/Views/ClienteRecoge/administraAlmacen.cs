using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace  SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class administraAlmacen : Form
    {
        string sqlString;
        public administraAlmacen(string sql)
        {
            sqlString = SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1;
            InitializeComponent();
        }

        private void administraAlmacen_Load(object sender, EventArgs e)
        {
            cargaFormasEnvio();
            txtFactura.Select();
        }

        public void cargaFormasEnvio()
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            string query = "select LIST_ID,LIST_ITEM_NAME from IWS.DBO.FORMAENVIO";
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            lookformaenvio.Properties.DataSource = ds.Tables[0];
            lookformaenvio.Properties.DisplayMember = "LIST_ITEM_NAME";
            lookformaenvio.Properties.ValueMember = "LIST_ID";
        }

        private void comboOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboOpcion.Text.Equals("Eliminar de Almacen"))
            {    btnBuscar.Text="Eliminar";
                labelFormaenvio.Visible=false;
                txtFormaEnvioActual.Visible=false;
                labelNuevaFormaEnvio.Visible=false;
                lookformaenvio.Visible = false;
                btnCambiar.Visible=false;
            }
            else
            {
                btnBuscar.Text="Buscar";
                labelFormaenvio.Visible = true;
                txtFormaEnvioActual.Visible = true;
                labelNuevaFormaEnvio.Visible = true;
              lookformaenvio.Visible = true;
                btnCambiar.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(sqlString);
            myConnection.Open();
            if (dxValidationProvider1.Validate())
            {
                if (validadorOpcion.Validate())
                {
                    if (comboOpcion.EditValue.ToString().Equals("Eliminar Factura"))
                    {
                        
                        SqlCommand cmd = new SqlCommand("", myConnection);
                        cmd.CommandText = "update  indarneg.dbo.almacencterecoge set check1=1 where factura='" +txtFactura.Text + "'";
                        cmd.ExecuteNonQuery();
                    }
                    else 
                    {
                        lookformaenvio.Visible = true;
                        SqlCommand cmd = new SqlCommand("", myConnection);
                        cmd.CommandText = @"SELECT FE.LIST_ITEM_NAME FROM IWS.DBO.Invoices I
                            INNER JOIN  IWS.DBO.FormaEnvio FE ON I.ShippingWay = FE.LIST_ID
                                WHERE TRANID=" + txtFactura.Text;

                        txtFormaEnvioActual.Text = cmd.ExecuteScalar().ToString();
                        txtFormaEnvioActual.Visible = true;
                    }
                }
                else MessageBox.Show("Escoge Una Opcion");
            }
            else MessageBox.Show("Ingresa Un Factura");
            

            validadorCombo.Validate();
                
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate() && validadorCombo.Validate() && validadorOpcion.Validate())
            {
                SqlConnection myConnection = new SqlConnection(sqlString);
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "select  1";// "select count(factura) from indarneg.dbo.almacencterecoge where factura='" + txtFactura.Text + "'";
                switch (cmd.ExecuteScalar().ToString())
                {
                    case "1":
                        cmd.CommandText = "update IWS.DBO.INVOICES set ShippingWay='" + lookformaenvio.EditValue.ToString() + "' where TRANID=" + txtFactura.Text + 
                                          " update  indarneg.dbo.almacencterecoge set check1=1 where factura='" + txtFactura.Text + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cambio realizado con exito");
                        break;
                    case "0": MessageBox.Show("Factura No se encuentra \n en el Almacen de Cte. Recoge");
                        break;
                    default: break;
                }
            }

        }
    }
}
