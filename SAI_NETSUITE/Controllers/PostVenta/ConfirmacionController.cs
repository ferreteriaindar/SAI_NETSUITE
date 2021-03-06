﻿using SAI_NETSUITE.Controllers.IWS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAI_NETSUITE.IWS;
using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;

namespace SAI_NETSUITE.Controllers.PostVenta
{
    class ConfirmacionController
    {

        public DataSet regresaembarque(string idembarque)
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string query = @"select ED.factura,'ENTREGADO' AS estado,ED.fechaHora,ED.persona,ED.comentarios,ED.facturaid ,(select companyId+' '+company from iws.dbo.Invoices I
								inner join iws.dbo.Customers c on i.Entity=c.internalid where TranId=ed.factura) as cliente from Indarneg.dbo.Embarques E
			                    left join Indarneg.dbo.EmbarquesD ED ON E.idEmbarque=ED.idEmbarque
			                    WHERE  E.estatus='TRANSITO' and ED.estado='TRANSITO'  AND E.idEmbarque=" + idembarque + " order by ED.IdEmbarqueD ASC";
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
				                        if exists(select factura from indarneg.dbo.embarquesD where factura='"+factura+ @"')
					                        begin
						                        SELECT i.TranId as factura,estado='ENTREGADO',fechaHora='',persona='',comentarios='',I.internalid,C.companyId+' '+C.company as cliente FROM IWS.DBO.Invoices I 
						                        left join iws.dbo.Customers C on i.Entity=c.internalid
						                        where  i.TranId=" + factura+@"
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
                    drr["facturaid"] = Convert.ToInt32(sdr.GetValue(5).ToString());
                    drr["cliente"] = sdr.GetValue(6).ToString();


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
                   
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("", myConnection);
                         cmd.CommandText = "update indarneg.dbo.embarquesD set fechahora=@fechahora,persona=@persona,estado=@estado,comentarios=@comentarios,facturaid=@facturaid,UsuarioConfirma=@UsuarioConfirma,fechaConfirmaPostventa=@fechaConfirmaPostventa where idembarque=@idembarque and factura=@factura";
                        //cmd.CommandText = "update indarneg.dbo.embarquesD set fechahora=@fechahora,persona=@persona,estado=@estado,comentarios=@comentarios,facturaid=@facturaid,UsuarioConfirma=@UsuarioConfirma where idembarque=@idembarque and factura=@factura";

                        cmd.Parameters.AddWithValue("@fechahora", dt.Rows[i]["fechahora"].ToString());
                        cmd.Parameters.AddWithValue("@persona", dt.Rows[i]["persona"].ToString());
                        cmd.Parameters.AddWithValue("@estado", dt.Rows[i]["estado"].ToString());
                        cmd.Parameters.AddWithValue("@comentarios", dt.Rows[i]["comentarios"].ToString());
                        cmd.Parameters.AddWithValue("@idembarque", embarque);
                        cmd.Parameters.AddWithValue("@factura", dt.Rows[i]["factura"].ToString());
                        cmd.Parameters.AddWithValue("@facturaid",Convert.ToInt32( dt.Rows[i]["facturaid"].ToString()));
                        cmd.Parameters.AddWithValue("@UsuarioConfirma", usuario);
                        cmd.Parameters.AddWithValue("@fechaConfirmaPostventa", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                    myConnection.Close();
                    myConnection.Open();

                    using (IndarnegEntities ctx = new IndarnegEntities())
                    {
                        int idembarque = Convert.ToInt32(embarque);
                        var totalLineas = (from ed in ctx.EmbarquesD where (ed.idEmbarque == idembarque) select ed).Count();
                        var entregados= (from ed in ctx.EmbarquesD where (ed.idEmbarque == idembarque && !ed.estado.Equals("TRANSITO")) select ed).Count();
                        if(totalLineas==entregados)
                        {
                            SqlCommand cmd2 = new SqlCommand("", myConnection);
                            cmd2.CommandText = "update indarneg.dbo.embarques set estatus='CONCLUIDO',fechaconcluido=getdate() WHERE IDEMBARQUE=" + embarque;
                            cmd2.ExecuteNonQuery();
                        }
                    }
                   

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
                    List<EmbarquesD> embd = regresaEmbarqueD(emb.idEmbarque,dt,usuario);
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

        private List<EmbarquesD> regresaEmbarqueD(int idEmbarque,DataTable dt,string usuario)
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
                    persona = dt.Rows[i]["persona"].ToString(),
                    comentarios = dt.Rows[i]["comentarios"].ToString(),
                    fechaConfirmaPostventa = DateTime.Now,
                    UsuarioConfirma=usuario

                };
                emb.Add(embd);
            }

            return emb;
        }


        public List<UpdateInvoiceModel> regresaInternalId(List<UpdateInvoiceModel> lista)
        {
            List<UpdateInvoiceModel> l = new List<UpdateInvoiceModel>();
            using (IWSEntities ctx = new IWSEntities())
            {
                foreach (var invoice in lista)
                {
                    UpdateInvoiceModel ium = new UpdateInvoiceModel();


                    ium.internalId = (from s in ctx.Invoices
                                      where s.TranId.Equals(invoice.internalId)
                                      select s.internalId.Value

                                      ).FirstOrDefault();
                    ium.custbody_nso_indr_receipt_date = invoice.custbody_nso_indr_receipt_date;
                    l.Add(ium);
                }

                return l;
                
            }






        }

        



        public string insertaFechaVencimientoNetsuite(UpdateInvoiceModel factura, Token token)
        {
            IWS.Connection conn = new IWS.Connection();
            string json = JsonConvert.SerializeObject(factura);
            var resultado = conn.POST("api/Invoice/UpdateInvoice", json, token.token,false);

            return resultado.ToString();
        }

        public string EmbarqueCSV(StringBuilder contenido, string name,Token token)
        {
            IWS.Connection conn = new IWS.Connection();
            Models.Transaccion.EmbarqueCSV csv = new EmbarqueCSV()
            {
                content = contenido.ToString(),
                name = name
            };
            string json = JsonConvert.SerializeObject(csv);
            var resultado = conn.POST("api/Invoice/UpdateReceiptDate", json, token.token, true);

            return resultado.ToString();
        }
      
    }
}
