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
    public partial class DesgloseMovimientosQV : UserControl
    {
        public DesgloseMovimientosQV()
        {
            InitializeComponent();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {

            if (dxValidationProvider1.Validate()&& !backgroundWorker1.IsBusy)
            {
                DateTime inicio = Convert.ToDateTime(dateEdit1.EditValue.ToString());
                DateTime fin = Convert.ToDateTime(dateEdit2.EditValue.ToString());
                List<object> argumentos = new List<object>();
                argumentos.Add(inicio);
                argumentos.Add(fin);
                btnGenerarReporte.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                backgroundWorker1.RunWorkerAsync(argument: argumentos);
            }
            else MessageBox.Show("Tienes que elegir las fecha \n o espera a que termine -_-!");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string carpeta = string.Empty;
            carpeta = System.IO.Path.GetTempPath();

            gridControl2.ExportToXlsx(carpeta + "\\DesgloseQV.xlsx");
            Process pdfexport = new Process();
            pdfexport.StartInfo.FileName = "EXCEL.exe";
            pdfexport.StartInfo.Arguments = carpeta + "\\DesgloseQV.xlsx";
            pdfexport.Start();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> argumentList = e.Argument as List<object>;
            DateTime inicio =(DateTime) argumentList[0];
            DateTime fin = (DateTime)argumentList[1];

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.SERVERWEB))
            {
                string query = @"USE IndarWeb

                        SET DATEFORMAT dmy

                              SELECT Id,Renglon,
                              Cliente,Rama,Agente,Mov,MovId,Concepto,Fecha,Ejercicio,Periodo,Almacen,Margen,Articulo,ArtFechaAlta,Descontinuado,
                              FormaEnvioAnte,FormaEnvio,DesctoIndarEvento,DesctoIndarPlazo,
                              IndarDescNormal,IndarDescNegociado,ErrorEnDesc = CASE WHEN IndarDescNormal > 100 OR IndarDescNegociado > 100 THEN 1 ELSE 0 END,
                              AnomaliaCatalogo,AnomaliaTipo,ListaPrecioVta,
                              Cantidad,Importe,ImporteBruto,ImporteDescOfrecido,ImporteDescOfrecido2,
                              Costo,CostoCorrecto,CostoCORREGIR,
                              VentaaPrecioCosto,
                              BonoPor,NegociaPor,ApoyoMKTPor,PPagoPor,
                              Bono     = VentaaPrecioCosto*BonoPor,
                              Negocia  = (VentaaPrecioCosto-(VentaaPrecioCosto*BonoPor))*NegociaPor,
                              ApoyoMKT = (VentaaPrecioCosto-(VentaaPrecioCosto*BonoPor)-(VentaaPrecioCosto*NegociaPor))*ApoyoMKTPor,
                              PPago    = (VentaaPrecioCosto-(VentaaPrecioCosto*BonoPor)-(VentaaPrecioCosto*NegociaPor)-(VentaaPrecioCosto*ApoyoMKTPor))*PPagoPor,
                              CostoNetodelMes,CostoNetodelMes2
                              FROM (
                                    SELECT VD.Id,VD.Renglon,
                                    V.Cliente,CT.Rama,Agente = ISNULL(V.Agente,''),
                                    V.Mov,V.MovId,
                                    Concepto          = '',
                                    Fecha             = V.FechaEmision,
                                    Ejercicio         = YEAR(V.FechaEmision),
                                    Periodo           = MONTH(V.FechaEmision),
                                    Almacen           = ISNULL(V.Almacen,0),
                                    Margen            = CASE WHEN SUBSTRING(VD.Articulo,1,2) IN ('B8','I9') THEN 'MB' ELSE 'MN' END,
                                    Articulo          = UPPER(VD.Articulo),
                                    ArtFechaAlta      = CONVERT(VARCHAR(10),A.Alta, 103),
                                    Descontinuado     = ISNULL(AD.Descontinuados,'NO'),
                                    FormaEnvioAnte    = NULL,
                                    FormaEnvio        = ISNULL(V.FormaEnvio,''), --// *********************** CHECAR SI ESTOS CAMPOS TAMBIEN ESTAN LLENOS EN LAS DEVOLUCIONES
                                    DesctoIndarEvento = UPPER(ISNULL(V.DesctoIndarEvento,'VENTA NORMAL')),
                                    DesctoIndarPlazo  = ISNULL(V.Condicion,''),
                                    IndarDescNormal   = ISNULL(V.IndarDescNormal,0),
                                    IndarDescNegociado= ISNULL(V.IndarDescNegociado,0),
                                    AnomaliaCatalogo  = UPPER(ISNULL(V.AnomaliaCatalogo,'')),
                                    AnomaliaTipo      = NULL, --// ************************************ CHECAR ESTE DESPUES
                                    ListaPrecioVta    = ISNULL(V.ListaPreciosEsp,'(Precio Lista)'),
                                    Cantidad          = CASE WHEN V.MOV = 'Invoice' THEN VD.Cantidad ELSE VD.Cantidad*-1 END,
                                    Importe           = CASE WHEN V.MOV = 'Invoice'
                                                                 THEN ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO )
                                                                 ELSE ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO*-1 ) 
                                                                 END,
                                    ImporteBruto      = CASE WHEN V.MOV = 'Invoice'
                                                                 THEN ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO )
                                                                 ELSE ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO*-1 ) 
                                                                 END,
                                    ImporteDescOfrecido=CASE WHEN V.MOV = 'Invoice'
                                                THEN ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO ) * (1-((ISNULL(V.IndarDescNormal,4)+ISNULL(V.IndarDescNegociado,0))/100))
                                                ELSE ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO*-1 ) * (1-((ISNULL(V.IndarDescNormal,4)+ISNULL(V.IndarDescNegociado,0))/100))
                                                END,
                                    ImporteDescOfrecido2=CASE WHEN IsNull(AD.Descontinuados,'') <> 'SI' THEN
                                                               CASE WHEN V.MOV = 'Invoice'
                                                                        THEN ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO ) * (1-((ISNULL(V.IndarDescNormal,4)+ISNULL(V.IndarDescNegociado,0))/100))
                                                                        ELSE ( ( ((VD.CANTIDAD*VD.PRECIO))*(1-(ISNULL(V.DESCUENTOGLOBAL,0)/100)) )*V.TIPOCAMBIO*-1 ) * (1-((ISNULL(V.IndarDescNormal,4)+ISNULL(V.IndarDescNegociado,0))/100))
                                                                   END     
                                                             ELSE 0 END,
                                    Costo         = ISNULL(VD.COSTO,0),
                                    CostoCorrecto = 0,
                                    CostoCORREGIR = ISNULL(AC.CostoCorregir,0),
                        --'Formula: CostoCorrecto - Costo',
                                    VentaaPrecioCosto=CASE WHEN V.MOV = 'Invoice'
                                                THEN ( ( ISNULL(VD.COSTO,0)+ISNULL(AC.CostoCorregir,0) ) *ISNULL(VD.CANTIDAD,0) )*V.TIPOCAMBIO
                                                ELSE ( ( ISNULL(VD.COSTO,0)-ISNULL(AC.CostoCorregir,0) ) *ISNULL(VD.CANTIDAD,0) )*V.TIPOCAMBIO*-1
                                                END,
                                    BonoPor     = ISNULL(FA.BONOS/100,0),
                                    NegociaPor  = ISNULL(FA.NEGOCIACION/100,0),
                                    ApoyoMKTPor = ISNULL(FA.ApoyoMKT/100,0),
                                    PPagoPor    = ISNULL(FA.PRONTOPAGO/100,0),
                                    CostoNetodelMes=CASE WHEN V.MOV = 'Invoice'
                                                THEN ( ( ISNULL(VD.COSTO,0)+ISNULL(AC.CostoCorregir,0) ) *ISNULL(VD.CANTIDAD,0) )*V.TIPOCAMBIO*(1-ISNULL(FA.BONOS/100,0))*(1-ISNULL(FA.NEGOCIACION/100,0))*(1-ISNULL(FA.ApoyoMKT/100,0))*(1-ISNULL(FA.PRONTOPAGO/100,0))
                                                ELSE ( ( ISNULL(VD.COSTO,0)-ISNULL(AC.CostoCorregir,0) ) *ISNULL(VD.CANTIDAD,0) )*V.TIPOCAMBIO*-1*(1-ISNULL(FA.BONOS/100,0))*(1-ISNULL(FA.NEGOCIACION/100,0))*(1-ISNULL(FA.ApoyoMKT/100,0))*(1-ISNULL(FA.PRONTOPAGO/100,0))
                                                END,
                                    CostoNetodelMes2 = CASE WHEN IsNull(AD.Descontinuados,'') <> 'SI' THEN
                                                                       CASE WHEN V.MOV = 'Invoice'
                                                                       THEN ( ( ISNULL(VD.COSTO,0)+ISNULL(AC.CostoCorregir,0) ) *ISNULL(VD.CANTIDAD,0) )*V.TIPOCAMBIO*(1-ISNULL(FA.BONOS/100,0))*(1-ISNULL(FA.NEGOCIACION/100,0))*(1-ISNULL(FA.ApoyoMKT/100,0))*(1-ISNULL(FA.PRONTOPAGO/100,0))
                                                                       ELSE ( ( ISNULL(VD.COSTO,0)-ISNULL(AC.CostoCorregir,0) ) *ISNULL(VD.CANTIDAD,0) )*V.TIPOCAMBIO*-1*(1-ISNULL(FA.BONOS/100,0))*(1-ISNULL(FA.NEGOCIACION/100,0))*(1-ISNULL(FA.ApoyoMKT/100,0))*(1-ISNULL(FA.PRONTOPAGO/100,0))
                                                                       END
                                                              ELSE 0 END
                                    FROM VENTAD     VD with(NoLock)
                                    LEFT JOIN VENTA V  with(NoLock) ON V.ID = VD.ID AND V.ERP = VD.ERP
                                    LEFT JOIN CTE   CT with(NoLock) ON CT.CLIENTE = V.CLIENTE
                                    LEFT JOIN ART   A  with(NoLock) ON A.ARTICULO = VD.ARTICULO
                                    LEFT JOIN SERVER5.Indar.dbo.ArtDescontinuadosHistorico   AD with(NoLock) ON AD.Articulo = VD.ARTICULO AND AD.Ejercicio = YEAR(V.FechaEmision) AND AD.Periodo = MONTH(V.FechaEmision)
                                    LEFT JOIN SERVER5.Indar.dbo.avFabBonosyDescxLinea        FA with(NoLock) ON FA.EJERCICIO = YEAR(V.FechaEmision) AND FA.PERIODO = MONTH(V.FechaEmision) AND FA.LINEA = A.LINEA
                                    LEFT JOIN (SELECT Mov,MovId,Articulo,CostoCorregir=SUM(CostoCorregir)
                                                     FROM SERVER5.Indar.dbo.ArtCostoCorregir with(NoLock)
                                                     GROUP BY Mov,MovId,Articulo
                                                     ) AC ON AC.MOV = V.MOV AND AC.MOVID = V.MOVID AND AC.ARTICULO = VD.ARTICULO
                                    WHERE V.FECHAEMISION >= '" + inicio.ToShortDateString() + @"' AND V.FECHAEMISION <= '" + fin.ToShortDateString() + @"'
                                    AND V.MOV IN ('Invoice','Credit Memo') AND V.ESTATUS IN ('Open','Paid In Full','Fully Applied')
                                    AND V.CLIENTE NOT IN ('FSF','D002','D057','D091','D104','C000001','D147')
                                    AND ISNULL(A.CategoriaActivoFijo,'') = '' --// **************** ESTE YO CREO QUE YA NO VA, CHECAR DESPUES
                                    AND ISNULL(A.Tipo,'') NOT IN ('Estructura','Servicio')
                        --AND VD.Articulo = 'M9 RB810T05'
                        --LIKE 'M9%'
                              ) AS V
                        ORDER BY V.MOVID,V.Articulo";

                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.SelectCommand.CommandTimeout = 0;
                DataSet ds = new DataSet();
                da.Fill(ds);
                //  gridControl2.DataSource = ds.Tables[0];
                e.Result = ds;

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnGenerarReporte.ImageOptions.Image = null;
            DataSet ds = (DataSet)e.Result;
            gridControl2.DataSource = ds.Tables[0];

        }
    }
}
