using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class GetSalesInvoiceWMSModel
    {
        public ResultGetSalesInvoiceWMSModel result { get; set; }
    }

    public class ResultGetSalesInvoiceWMSModel
    {
        public ResponseStructure responseStructure { get; set; }
        public ResultadosGetSalesInvoiceWMSModel Resultados { get; set; }
    }

    public class ResultadosGetSalesInvoiceWMSModel
    {
        public int CustomerID { get; set; }
        public List<DocumentoGetSalesInvoiceWMSModel> Documentos { get; set; }
    }

    public class DocumentoGetSalesInvoiceWMSModel
    {
        public string tranid { get; set; }
        public string trandate { get; set; }
        public string createdfrom { get; set; }
        public string type { get; set; }
        public string statusref { get; set; }
        public string custbody_fe_uuid_cfdi_33 { get; set; }
        public string custbody_fe_sf_mensaje_respuesta { get; set; }
        public int internalid { get; set; }
    }


    public class sendGetSalesInvoiceWMSModel
    {
        public List<string> ids { get; set; }
    }
}
