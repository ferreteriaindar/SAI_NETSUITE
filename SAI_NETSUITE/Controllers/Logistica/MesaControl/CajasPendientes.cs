using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Controllers.Logistica.MesaControl
{
    public partial class CajasPendientes : DevExpress.XtraEditors.XtraForm
    {
        public CajasPendientes()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargaDatos();

        }

        private void cargaDatos()
        {
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            string query = @"SELECT  ISNULL(OE.Consolidado,OE.NumPedido) PedidoConsolidado, OE.FormaEnvio
	                       ,OE.Prioridad, L1.Codigo Caja, E.Clave Articulo, SUM(RDA.Cantidad) Cantidad
	                       ,L2.Codigo UbicacionOrigen,US.Usuario, Us.nombre, RDA.FechaActualizado FechaSurtido
	                       ,DATEDIFF(MINUTE,RDA.FechaActualizado,GETDATE()) TiempoEspera
                    FROM INDAR_INACTIONWMS.DBO.Localidad L WITH(NOLOCK)
                    INNER JOIN INDAR_INACTIONWMS.DBO.UnitarioLocalidad UL WITH(NOLOCK) ON L.IdLocalidad = UL.IdLocalidad
                    INNER JOIN INDAR_INACTIONWMS.DBO.Unitario U WITH(NOLOCK) ON UL.IdUnitario = U.IdUnitario
                    INNER JOIN INDAR_INACTIONWMS.DBO.Producto P WITH(NOLOCK) ON U.IdProducto = P.IdProducto
                    INNER JOIN INDAR_INACTIONWMS.DBO.Estilo E WITH(NOLOCK) ON P.IdEstilo = E.IdEstilo
                    INNER JOIN INDAR_INACTIONWMS.DBO.RecoleccionDetalleAbierta RDA WITH(NOLOCK) ON U.IdUnitario = RDA.IdUnitario
                    INNER JOIN INDAR_INACTIONWMS.DBO.Localidad L2 WITH(NOLOCK) ON RDA.IdLocalidad = L2.IdLocalidad
                    INNER JOIN INDAR_INACTIONWMS.DBO.Localidad L1 WITH(NOLOCK) ON RDA.IdLocalidadTransito = L1.IdLocalidad
                    INNER JOIN INDAR_INACTIONWMS.DBO.Usuario US WITH(NOLOCK) ON RDA.IdUsuarioActualiza = US.IdUsuario
                    INNER JOIN INDAR_INACTIONWMS.DBO.OrdenEmbarque OE WITH(NOLOCK) ON RDA.IdOrdenEmbarque = OE.IdOrdenEmbarque
                    WHERE OE.IdEstatusOrdenEmbarque = 5
                    GROUP BY	  ISNULL(OE.Consolidado,OE.NumPedido), OE.FormaEnvio
		                      ,OE.Prioridad, L1.Codigo, US.Usuario, US.Nombre
		                      ,RDA.FechaActualizado, E.Clave, L2.Codigo
                    ORDER BY Prioridad";

            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }
    }
}