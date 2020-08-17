using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class Payment_CreditMemo_certifiedModel
    {
        public ResultPayment_CreditMemo_certified result { get; set; }

    }

    public class ResultPayment_CreditMemo_certified
    {
        public ResponseStructure responseStructure { get; set; }
        public RespuestatPayment_CreditMemo_certified Resultados { get; set; }
    }
    public class RespuestatPayment_CreditMemo_certified
    {
        public int CustomerID { get; set; }
        public List<DocumentoPayment_CreditMemo_certified> Documentos { get; set; }
    }

    public class DocumentoPayment_CreditMemo_certified
    {
        public string tranid { get; set; }
        public string uuid { get; set; }
        public object respuesta { get; set; }
        public string factura { get; set; }
        public object facturaId { get; set; }
        public string zona { get; set; }
        public string mensaje { get; set; }
        public string type { get; set; }
        public string customer { get; set; }

    }


    public class resumenPaymentCreditReport
    {
        public int row { get; set; }
        public string customer { get; set; }
        public string pago { get; set; }
        public string  nota { get; set; }
        public string uuuid { get; set; }
        public string mensaje { get; set; }
        public string url { get; set; }

    }
}
