using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SAI_NETSUITE.Controllers.Logistica.Distribucion
{
    class NumeroGuiaController
    {

        public bool existeEmbarque(string embarque)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = "select count(*) as resultado from Indarneg.dbo.Embarques where estatus NOT IN ('CONCLUIDO','CANCELADO') AND  idEmbarque=" + embarque;
                var resultado = cmd.ExecuteScalar().ToString();
                if (!resultado.ToString().Equals("0"))
                    return true;
                
            }
            return false;
        }


        public DataTable regresaFacturas1(List<string> lista)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("facturas", typeof(string));
            dt.Columns.Add("cliente", typeof(string));
            dt.Columns.Add("embarque", typeof(string));
            dt.Columns.Add("check", typeof(bool));

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                string joined = string.Join(",", lista);
                string query = @"select factura,ed.entity_id as cliente,e.idEmbarque as embarque ,0 as [check] from Indarneg.dbo.Embarques E
                                LEFT JOIN Indarneg.DBO.EmbarquesD ed on e.idEmbarque=ed.idEmbarque
                                where e.idEmbarque  in (" + joined + ")";

                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                da.Fill(dt);
            }


            return dt;

        }


        public bool existaFacturaEnAlgunEmbarque(string factura)
        {
            using (SqlConnection myConnectio = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnectio.Open();
                SqlCommand cmd = new SqlCommand("", myConnectio);
                cmd.CommandText = "SELECT COUNT(*) AS RESULTADO FROM Indarneg.DBO.EmbarquesD where  factura = '" + factura + "'";
                var resultado = cmd.ExecuteScalar().ToString();

                if (resultado.ToString().Equals("0"))
                    return false;
                else return true;
            }
                      
        }

        public bool tieneNumerodeGuia(string factura)
        {
            using (SqlConnection myConnectio = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString))
            {
                myConnectio.Open();
                SqlCommand cmd = new SqlCommand("", myConnectio);
                cmd.CommandText = @"select top 1 NumeroGuia from Indarneg.dbo.NumeroGuiaNetsuiteD  D
                                left join Indarneg.dbo.NumeroGuiaNetsuite N on d.idNumeroGuia = n.idNumeroGuia
                                where Factura = '"+factura+@"'
                                order by n.idNumeroGuia desc";
                var resultado = cmd.ExecuteScalar().ToString();
                if (resultado != null)
                    return true;
                else return false;
                
            }

        }
        
    }
}
