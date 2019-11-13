using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class BalanceDocumentsModel
    {

        public ResultBalance result { get; set; }
     
    }

    public class ResultBalance
    {
        public ResponseStructure responseStructure { get; set; }
        public Resultados Resultados { get; set; }
    }
    public class Documento
    {
        public string Id_documento { get; set; }
        public string Doc { get; set; }
        public string No_documento { get; set; }
        public string Fecha_emision { get; set; }
        public string Fecha_vencimiento { get; set; }
        public string Importe_documento { get; set; }
        public string Saldo_documento { get; set; }
        public string Descuento_pronto_pago { get; set; }
        public string Evento { get; set; }
        public string Plazo { get; set; }
        public string referencia { get; set; }
    }

    public class Resultados
    {
        //public string CustomerID { get; set; }
        public List<Documento> Documentos { get; set; }
    }
}
