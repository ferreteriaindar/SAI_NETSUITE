using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
    class SaleOrderCancelSearchModel
    {
        public ResultSaleOrderCancelSearchModel result { get; set; }
    }

  
    public class  ResultSaleOrderCancelSearchModel

    {
        public ResponseStructure responseStructure { get; set; }
        public ResultadosSaleOrderCancelSearchModel Resultados { get; set; }
    }


    public class ResultadosSaleOrderCancelSearchModel
    {
        public int CustomerID { get; set; }
        public List<DocumentoSaleOrderCancelSearchModel> Documentos { get; set; }
    }


    public class DocumentoSaleOrderCancelSearchModel
    {
        public string internalid { get; set; }
        public string type { get; set; }
        public string tranid { get; set; }
        public string statusText { get; set; }
        public string companyname { get; set; }
        public string entityid { get; set; }
        public string itemid { get; set; }
        public string custitem_categoria_articulo { get; set; }
        public string custrecord_representante_vtas { get; set; }
        public string custrecord_representante_vtasText { get; set; }
        public string custrecord_apoyo_ventas { get; set; }
        public string custrecord_apoyo_ventasText { get; set; }
        public string trandate { get; set; }
        public string quantity { get; set; }
        public string quantitycommitted { get; set; }
    }
}
