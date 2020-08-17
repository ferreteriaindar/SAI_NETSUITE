using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    public class ApplyCreditMemoSendModel
    {
        public string internalId { get; set; }
        public List<InvoiceApplyCreditMemoSendModel> invoices { get; set; }
        public string custbody_fe_metodo_de_pago { get; set; }
        public string custbody_cfdi_tipo_relacion_33 { get; set; }

    }
    public class InvoiceApplyCreditMemoSendModel
    {
        public int Id { get; set; }
        public string discount { get; set; }
    }
}
