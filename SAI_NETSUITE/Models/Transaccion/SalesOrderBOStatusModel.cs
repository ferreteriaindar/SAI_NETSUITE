using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class SalesOrderBOStatusModel
    {
        public List<SalesOrderBOStatusModelDetalle> result { get; set; }
    }


    public class SalesOrderBOStatusModelDetalle
    {
        public string pedido { get; set; }
        public string status { get; set; }
        public DateTime fecha { get; set; }
        public string customername { get; set; }
        public string itemid { get; set; }
        public string item { get; set; }
        public string itemdescription { get; set; }
        public int quantity { get; set; }
        public int quantitycommitted { get; set; }
        public int quantitybackordered { get; set; }
        public int almacen2 { get; set; }
        public int almacen31 { get; set; }

        public string typeOrder { get; set; }
    }
}
