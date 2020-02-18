using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using SAI_NETSUITE.Views.Compras.Entradas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.PostVenta
{
    class RegresarEventosController
    {



        public ResultadosInventoryEvents cargaDatos()
        {

            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/Inventory/InventoryEventsToList", SAI_NETSUITE.Properties.Resources.token);
            ResultadosInventoryEvents list = JsonConvert.DeserializeObject<ResultadosInventoryEvents>(json);
            return list;
        }

        public bool InsertIREvento(List<DocumentosInventoryEventsToList> lista,bool almacen)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                IR iR = new IR()
                {
                    date = DateTime.Now,
                    mov = almacen==true?"IRP":"IRE",
                    vendor="POSTVENTA"

                };
                ctx.IR.Add(iR);
                List<IRD> iRDs = new List<IRD>();
                foreach (var item in lista)
                {
                    IRD iRD = new IRD()
                    {
                        idIR = iR.id,
                        itemid = item.nombre,
                        quantity = Convert.ToInt32(item.disponible),
                    };
                    iRDs.Add(iRD);
                }
                ctx.IRD.AddRange(iRDs);
                ctx.SaveChanges();

                    try
                    {
                        using (IndarnegEntities ctxNeg = new IndarnegEntities())
                        {
                            spWMS_InsertaIR_Result result = ctxNeg.spWMS_InsertaIR(iR.id).FirstOrDefault();
                            if (result.rows != null && result.rows < 1)
                            {

                                return false;
                            }
                            else
                            {
                            Reporte(iR.id.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }


            return false;
        }


        public void Reporte(string id)
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                /*string query = @"select ir.id,ir.mov,ir.vendor,ir.date,IRD.itemid,ird.sourceTran,ird.sourceNumber from  iws.dbo.ir IR
                                left join iws.dbo.IRD IRD ON ir.id=IRD.idIR
                                where ir.id="+id;*/
                string query = @"select ir.id,ir.mov,ir.vendor,ir.date,IRD.itemid,ird.sourceTran,
                                    sourceNumber = (select ',' + CONVERT(varchar(10), ird2.sourceNumber) from iws.dbo.IRD ird2 where ird2.idIR = IR.id and ird2.itemid = IRD.itemid for xml path('') )
                                from iws.dbo.ir IR
                                left join iws.dbo.IRD IRD ON ir.id = IRD.idIR
                                            where ir.id = " + id.ToString() + @"
                                group by IR.id,ir.mov,ir.vendor,ir.date,IRD.itemid,ird.sourceTran";
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);

                da.Fill(ds);
                //ds.WriteXmlSchema(@"S:\XML\Compras\IR.xml");

            }
            hojaIR ir = new hojaIR();
            ir.DataSource = ds;
            ReportPrintTool printTool = new ReportPrintTool(ir);
            printTool.ShowRibbonPreview();

        }
    }
}
