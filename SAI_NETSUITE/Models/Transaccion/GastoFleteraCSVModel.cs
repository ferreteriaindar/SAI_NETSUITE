using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
 public   class GastoFleteraCSVModel
    {
        public string  xml { get; set; }
        public string DepartmentHead { get; set; }
        public string Vendor { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Reference { get; set; }
        public string Item { get; set; }
        public decimal? Rate { get; set; }
        public string Quantity { get; set; }
        public string Tax { get; set; }
        public string Department { get; set; }

        public string Relacion { get; set; }
        public string NumGuia { get; set; }
        public string Comentario { get; set; }
    }

    public class GastoFleteraSend
    {
        public string csv { get; set; }
        public string name { get; set; }
        public string content { get; set; }

        public string csvName { get; set; }
    }
}
