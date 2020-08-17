using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class CreditMemoApplySearchModel
    {
        public ResultCreditMemoApplySearchModel result { get; set; }
    }

    public class ResultCreditMemoApplySearchModel
    {
        public ResponseStructure responseStructure { get; set; }
        public ResultadosCreditMemoApplySearchModel Resultados { get; set; }
    }

    public class ResultadosCreditMemoApplySearchModel
    {
        public int CustomerID { get; set; }
        public List<DocumentoCreditMemoApplySearchModel> Documentos { get; set; }
    }

    public class DocumentoCreditMemoApplySearchModel
    {
        public string type { get; set; }
        public int internalid { get; set; }
        public string tranid { get; set; }
        public string entity { get; set; }
        public double amountremaining { get; set; }
        public string datecreated { get; set; }
        public string memo { get; set; }
        public string formaPago { get; set; }
        public string tipoRelacion { get; set; }
    }


}
