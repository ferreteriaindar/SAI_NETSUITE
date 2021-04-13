using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.IWS
{
    class Connection
    {

        public string POST(string url, string json, string head,bool type)
        {
            // ServiceReference1.WebService1Soap indar = new ServiceReference1.WebService1Soap();
            try
            {
               //   HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.86.6:63333/" + url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(regresaIWSurl() + url);
                request.ContentType = "application/json";
                request.Method = type ? "POST" : "PUT";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                if (head != "")
                {
                    string header = "Authorization: Bearer " + head;
                    request.Headers.Add(header);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = streamReader.ReadToEnd();

                    return responseText;

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string GET(string url, string json, string head, bool type)
        {
            // ServiceReference1.WebService1Soap indar = new ServiceReference1.WebService1Soap();
            try
            {
                 // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.86.6:63333/" + url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(regresaIWSurl() + url);
                request.ContentType = "application/json";
                request.Method = "GET";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                if (head != "")
                {
                    string header = "Authorization: Bearer " + head;
                    request.Headers.Add(header);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = streamReader.ReadToEnd();

                    return responseText;

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string regresaIWSurl()
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                string query = "select top 1 URL from iws.dbo.url_iws where app = 'SAI'";
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(query, myConnection);
                var resultado = cmd.ExecuteScalar().ToString();
                myConnection.Close();
                return resultado.ToString();
            }

        }
       
    }
}
