using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class NonCertifiedPaymentSearchModel
    {

        public ResultNonCertifiedPaymentSearchModel result { get; set; }

    }

    public class ResultNonCertifiedPaymentSearchModel
    {
        public ResponseStructure responseStructure { get; set; }
        public ResultadosNonCertifiedPaymentSearchModel Resultados { get; set; }

    }




    public class ResultadosNonCertifiedPaymentSearchModel
    {
        public int CustomerID { get; set; }
        public List<DocumentoNonCertifiedPaymentSearchModel> Documentos { get; set; }
    }

    public class DocumentoNonCertifiedPaymentSearchModel
    {
        public string Tipo { get; set; }
        public string NumDoc { get; set; }
        public string Origen { get; set; }
        public string Fecha { get; set; }
        public decimal Monto { get; set; }
        public string MontoRestante { get; set; }
        public string Estatus { get; set; }
        public string error { get; set; }
        public int internalId { get; set; }
    }
}
