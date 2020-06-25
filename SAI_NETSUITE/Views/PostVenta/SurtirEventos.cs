using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Models.Transaccion;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Views.PostVenta
{
    public partial class SurtirEventos : UserControl
    {
        TransferOrderSearchModel tosm;
        public SurtirEventos()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            tosm = new Controllers.PostVenta.SurtirEventosController().regresaDatos();
            IndarnegEntities ctx = new IndarnegEntities();
            var eventos = ctx.EventosSurtidos.Select(s => s.tranid).ToList();
            //gridControl1.DataSource = tosm.result.Distinct().Where(w=> !eventos.Contains(w.tranid)).Select(i=> new { i.tranid ,i.fecha,i.creadopor,i.memo,i.internalid}).ToList();
            var distincts =tosm.result.Distinct().Where(w => !eventos.Contains(w.tranid)).Select(i => new { i.tranid, i.fecha, i.creadopor, i.memo, i.internalid }).ToList();
            gridControl1.DataSource = distincts.Distinct().ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 1)
            {
                
                


                    int internalId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "internalid").ToString());
                var paraWMS = tosm.result.Where(w => w.internalid.Equals(internalId) ).GroupBy(l => l.articulo)
                    .Select(cl => new DocumentosTransferOrderSearch {articulo=cl.First().articulo, cantidad = cl.Sum(c => c.cantidad), tranid = cl.First().tranid,internalid=internalId }).ToList();
                Console.WriteLine(paraWMS.ToString());

                using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    cmd.CommandText = @"INSERT INTO INDGDLSQL01.INDAR_INACTIONWMS.int.pedido (id, mov, movid ,fechaEmision, cliente, horaEmision ,formaEnvio, lugarEnvio, fletera ,fechaIngreso, fechaActualizacion, estatusSincronizacion ,fechaEntrega)
                                       select " + paraWMS.First().internalid.ToString() + ",'Traspaso'," + paraWMS.First().tranid.ToString() + ",'" + paraWMS.First().fecha + "','C000000',GETDATE(),'CCI LOCAL','ENTREGAR A POSTVENTA','OFICINA POSTVENTA',null,null,0,null";

                    if (cmd.ExecuteNonQuery() > 0)
                    {/*
                        cmd.CommandText = @"INSERT INTO INDGDLSQL01.INDAR_INACTIONWMS.int.pedidodetalle (id, articulo,cantidad ,fechaIngreso, fechaActualizacion,estatusSincronizacion )
                                          select " + paraWMS.First().internalid.ToString() + "," + paraWMS.First().articulo.ToString() + "," + paraWMS.First().cantidad + ",null,null,0";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            cmd.CommandText = @"insert into indarneg.dbo.EventosSurtidos(tranid,fecha)
                                              select " + paraWMS.First().tranid + ",getdate()";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Ingresado Correctamente");
                        }*/
                      
                            foreach (var item in paraWMS)
                            {
                                cmd.CommandText = @"INSERT INTO INDGDLSQL01.INDAR_INACTIONWMS.int.pedidodetalle (id, articulo,cantidad ,fechaIngreso, fechaActualizacion,estatusSincronizacion )
                                          select " + item.internalid.ToString() + ",'" + item.articulo.ToString() + "'," + item.cantidad + ",null,null,0";
                                cmd.ExecuteNonQuery();
                            }
                        
                       
                        cmd.CommandText = @"insert into indarneg.dbo.EventosSurtidos(tranid,fecha)
                                              select " + paraWMS.First().tranid + ",getdate()";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ingresado Correctamente");
                        myConnection.Close();
                    }
                    else
                    {
                        myConnection.Open();
                        MessageBox.Show("Error al Insertar a Wms");

                    }
                    

                };

            }
            else MessageBox.Show("Solo un movimiento a la vez");
            btnConsultar_Click(null, null);
        }
    }
}
