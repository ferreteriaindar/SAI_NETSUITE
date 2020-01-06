using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class ArqueoModel
    {
        public ResultArqueo result { get; set; }

      
    }


    public class ResultArqueo
    {
        public List<DocumentosArqueoModel> Documentos { get; set; }

    }

    public class DocumentosArqueoModel
    {
        public string zona { get; set; }
        public string cliente { get; set; }
        public string nombre { get; set; }
        public string type { get; set; }
        public string numero { get; set; }
        public string fecha { get; set; }
        public string vencimiento { get; set; }
        public string Dias { get; set; }
        public string importe { get; set; }
        public string saldo { get; set; }
        public string porcentaje { get; set; }
        public string memo { get; set; }
        public string cobro { get; set; }
    }
}
