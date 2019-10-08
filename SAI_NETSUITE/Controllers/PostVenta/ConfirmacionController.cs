using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.PostVenta
{
    class ConfirmacionController
    {

        public DataSet regresaembarque(string idembarque)
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select ED.factura,ED.estado,ED.fechaHora,ED.persona,ED.comentarios from Indarneg.dbo.Embarques E
			                    left join Indarneg.dbo.EmbarquesD ED ON E.idEmbarque=ED.idEmbarque
			                    WHERE  E.estatus='TRANSITO' AND E.idEmbarque=" + idembarque;
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(ds);
            }
             return ds;
        }

        public DataRow regresaFactura(string factura, DataRow dr)
        {
            DataRow drr = dr;
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"if exists(select top 1  ED.factura,E.estatus from  Indarneg.dbo.Embarques  E
			                        LEFT JOIN Indarneg.DBO.EmbarquesD ED on e.idEmbarque=ed.idEmbarque
			                        where ed.estado in('ENTREGADO','TRANSITO') and  ed.factura='" + factura+@"' ORDER BY E.idEmbarque DESC)
			                        SELECT 'ENTREGADA' AS RESULTADO
			                        ELSE
				                        BEGIN 
				                        if exists(select factura from indarneg.dbo.embarquesD where factura='"+factura+@"')
					                        begin
						                        SELECT i.TranId as factura,estado='ENTREGADO',fechaHora='',persona='',comentarios='' FROM IWS.DBO.Invoices I 
						                        left join iws.dbo.Customers C on i.Entity=c.internalid
						                        where  i.TranId="+factura+@"
					                        end
				                        else
				                        select 'NO EXISTE' AS RESULTADO
				                        END";
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr.GetValue(0).ToString().Equals("ENTREGADA") || sdr.GetValue(0).ToString().Equals("NO EXISTE"))
                    drr["factura"] = sdr.GetValue(0).ToString();
                else
                {
                    drr["factura"] = sdr.GetValue(0).ToString();
                    drr["estado"] = sdr.GetValue(1).ToString();
                    drr["fechaHora"] = sdr.GetValue(2).ToString();
                    drr["persona"] = sdr.GetValue(3).ToString();
                    drr["comentarios"] = sdr.GetValue(4).ToString();


                }
            }
                return drr;
        }


        public bool confirmaEmbarque(string usuario, DataTable dt,string embarque)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand("", myConnection);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmd.CommandText = "update indarneg.dbo.embarquesD set fechahora=@fechahora,persona=@persona,estado=@estado,comentarios=@comentarios where idembarque=@idembarque and factura=@factura";
                        cmd.Parameters.AddWithValue("@fechahora", dt.Rows[i]["fechahora"].ToString());
                        cmd.Parameters.AddWithValue("@persona", dt.Rows[i]["persona"].ToString());
                        cmd.Parameters.AddWithValue("@estado", dt.Rows[i]["estado"].ToString());
                        cmd.Parameters.AddWithValue("@comentarios", dt.Rows[i]["comentarios"].ToString());
                        cmd.Parameters.AddWithValue("@idembarque", embarque);
                        cmd.Parameters.AddWithValue("@factura", dt.Rows[i]["factura"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                    cmd.CommandText = "update indarneg.dbo.embarques set estatus='CONCLUIDO',fechaconcluido=getdate() WHERE IDEMBARQUE=" + embarque;
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool registraEmbarqueConcluido(string usuario, DataTable dt)
        {

            try
            {
                using (IndarnegEntities ctx = new IndarnegEntities())
                {
                    Embarques emb = new Embarques()
                    {
                        estatus = "CONCLUIDO",
                        fecha = DateTime.Now,
                        usuario = usuario,
                        fechaConcluido=DateTime.Now
                        

                    };
                    ctx.Embarques.Add(emb);
                    ctx.SaveChanges();
                    List<EmbarquesD> embd = regresaEmbarqueD(emb.idEmbarque,dt);
                    foreach (var detalle in embd)
                    {
                        ctx.EmbarquesD.Add(detalle);
                    }

                    ctx.SaveChanges();
                    new Views.Logistica.Distribucion.embarqueMasivo(usuario).generaReporte(emb.idEmbarque);
                    return true;
                };
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private List<EmbarquesD> regresaEmbarqueD(int idEmbarque,DataTable dt)
        {
            List<EmbarquesD> emb = new List<EmbarquesD>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                EmbarquesD embd = new EmbarquesD
                {
                    idEmbarque = idEmbarque,

                    estado = "ENTREGADO",
                    factura = dt.Rows[i]["factura"].ToString(),
                    fechaHora = dt.Rows[i]["fechahora"].ToString(),
                    persona=dt.Rows[i]["persona"].ToString(),
                    comentarios=dt.Rows[i]["comentarios"].ToString()

                };
                emb.Add(embd);
            }

            return emb;
        }
    }
}
