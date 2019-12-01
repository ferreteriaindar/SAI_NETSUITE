using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SAI_NETSUITE.Views.Compras.Reportes
{
    public partial class RepOCPendientes : UserControl
    {
        public RepOCPendientes()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.SERVER87_5))
            {
                string query = @"select * from  openquery([NETSUITE],'
                select T.TRANSACTION_TYPE as Mov,T.TRANID as MovId,L.FULL_NAME AS Almacen,T.trandate as fechaEmision,DUE_DATE as FechaEntregaOC,TL.EXPECTED_RECEIPT_DATE AS FechaEntregaArticulo,
                AGENTE_COMPRADOR AS Agente,AGENTE_COMPRADOR as Nombre,E.name as Proveedor,LDA.LIST_ITEM_NAME AS Linea,LGA.LIST_ITEM_NAME AS Grupo,I.MPN AS ClaveFabricante,I.FULL_NAME as Articulo,
                PURCHASEDESCRIPTION as Descripcion1,DATEDIFF(day,DUE_DATE,T.trandate) AS TiempoEntrega,''DIAS'' as TiempoEntregaUnidad,TL.ITEM_COUNT AS Cantidad,NVL(TL.ITEM_COUNT-TL.NUMBER_BILLED,0) AS CantidadPendiente,
                tl.ITEM_UNIT_PRICE  AS Cost,TL.PRECIO_LISTA_PROVEEDOR AS CostoEstandar,LCDA.LIST_ITEM_NAME AS Categoria,LTC.LIST_ITEM_NAME AS CategoriaIndar,
                case when NVL(TL.ITEM_COUNT-TL.NUMBER_BILLED,0)=0 then 0
	                 when NVL(TL.ITEM_COUNT-TL.NUMBER_BILLED,0)<>0 then (TL.ITEM_COUNT-TL.NUMBER_BILLED)*tl.PRECIO_LISTA_PROVEEDOR 
	                 end  AS SALDO,T.EXCHANGE_RATE AS TipoCmabio,T.SUBTOTAL_FORMATO as Importe,T.STATUS AS Situacion,T.FOLIO_PROVEEDOR AS FolioProveedor,TL.MEMO AS ObservacionesIndar,''*'' as Referencia


                from 
                [Ferreteria indar SA de CV].[Administrator].[transactions]  T
                INNER JOIN [Ferreteria indar SA de CV].[Administrator].[locations] L ON T.location_id=l.Location_id
                INNER JOIN [Ferreteria indar SA de CV].[Administrator].[TRANSACTION_LINES]    TL ON T.TRANSACTION_ID=TL.TRANSACTION_ID
                INNER join [Ferreteria indar SA de CV].[Administrator].VENDORS E ON T.ENTITY_ID=E.vendor_id
                INNER JOIN [Ferreteria indar SA de CV].[Administrator].ITEMS I ON TL.ITEM_ID=I.ITEM_ID
                INNER JOIN [Ferreteria indar SA de CV].[Administrator].NSO___DESCUENTOS_COMERCIALES DC ON I.ITEM_ID=DC.ITEM_ID
                INNER JOIN [Ferreteria indar SA de CV].[Administrator].LISTA_LÍNEA_DEL_ARTÍCULO LDA ON DC.LINEA_ID=LDA.LIST_ID
                INNER JOIN  [Ferreteria indar SA de CV].[Administrator].LISTA_GRUPO_DEL_ARTICULO LGA ON I.GRUPO_ID=LGA.LIST_ID
                INNER JOIN  [Ferreteria indar SA de CV].[Administrator].LISTA_CATEGORÍA_DE_ARTÍCULO LCDA ON I.CATEGORA_ID=LCDA.LIST_ID
                INNER JOIN [Ferreteria indar SA de CV].[Administrator].LISTA_TIPO_CLASIFICACIÓN_ART LTC ON I.TIPO_DE_CLASIFICACIN_ID=LTC.LIST_ID
                WHERE TRANSACTION_TYPE=''Purchase Order''  AND STATUS IN (''Pending Receipt'',''Pending Supervisor Approval'',''Partially Received'')')";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gridControl1.DataSource = ds.Tables[0];

            };
        }

        private void BTNexcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl1.ExportToXlsx(carpeta + "\\OCPENDIENTE.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\OCPENDIENTE.xlsx";
            pdfexport.Start();
        }
    }
}
