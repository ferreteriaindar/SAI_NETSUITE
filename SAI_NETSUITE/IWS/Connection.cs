using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.IWS
{
    class Connection
    {
        public string POST(string url, string json, string head)
        {
            // ServiceReference1.WebService1Soap indar = new ServiceReference1.WebService1Soap();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.86.6:63333/" + url);
            request.ContentType = "application/json";
            request.Method = "POST";

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

        public string GET(string url,  string head)
        {
            // ServiceReference1.WebService1Soap indar = new ServiceReference1.WebService1Soap();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://192.168.86.6:63333/" + url);
            request.ContentType = "application/json";
            request.Method = "GET";

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
    }
}
