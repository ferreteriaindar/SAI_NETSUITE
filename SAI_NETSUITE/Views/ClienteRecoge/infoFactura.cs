using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.ClienteRecoge
{
    public partial class infoFactura : Form
    {
        
        string  factura,mov,id;

        public infoFactura( string fact, string tipo,string idmov)
        {
            
                      
            factura = fact;
            id = idmov;
            mov = tipo;
            InitializeComponent();
        }

        private void infoFactura_Load(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString);
            string query = "";
            string filtro = "Factura Indar";
            switch (mov)
            { 
                case "I": query = @"select IT.itemid as articulo,de.quantity as cantidad,It.purchasedescription as descripcion1,c.companyId as cliente from iws.dbo.Invoices I
                                    left join  iws.dbo.InvoicesDetail DE on i.TranId=de.InvoicesId
                                    left join iws.dbo.Items It ON DE.item=IT.id
                                    LEFT JOIN IWS.DBO.Customers C on i.Entity=c.internalid
                                     where i.TranId=" + factura;
                    break;
                
                case "PE": query= "select vd.articulo,vd.cantidad,a.descripcion1, v.cliente from ventad vd left join venta v on vd.id = v.id left join art a on vd.articulo = a.articulo where v.movid = '" + factura + "'  and v.mov = '"+filtro+"' ";
                    break;
            }

 
            if (!id.Equals("*"))
                query = @"select e.Clave as articulo,pr.CantUnitarios as cantidad,e.Descripcion as descripcion1,ct.Clave as cliente,eoe.Nombre from  INDGDLSQL01.INDAR_INACTIONWMS.dbo.ordenembarque  OE
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.EstatusOrdenEmbarque eoe on oe.IdEstatusOrdenEmbarque=eoe.IdEstatusOrdenEmbarque
                            LEFT JOIN  INDGDLSQL01.INDAR_INACTIONWMS.dbo.pedidorenglon  pr on oe.IdOrdenEmbarque=pr.IdOrdenEmbarque
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Estilo E ON pr.IdEstilo=e.IdEstilo
                            left join INDGDLSQL01.INDAR_INACTIONWMS.dbo.Cliente ct on oe.IdCliente=ct.IdCliente
                            where oe.idPedido=" + id;
            Console.WriteLine(query);
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "id");
            // grid_folios.DataSource = ds.Tables["id"];
              gridControl1.DataSource = ds.Tables["id"];
                 myConnection.Close();
                 myConnection.Open();   
                /* SqlCommand cmd = new SqlCommand("", myConnection);
                 cmd.CommandText = "select ordencompra from venta where movid='" + factura + "'";
                    textBox1.Text= cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "select ct.nombre from cte ct left join venta v on ct.cliente=v.cliente where v.movid='"+factura+"' and mov='"+filtro+"'";
                    LabeCliente.Text = cmd.ExecuteScalar().ToString();
                    myConnection.Close();*/

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
