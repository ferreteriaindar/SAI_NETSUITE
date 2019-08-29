using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Models.Transaccion
{
  public  class NumeroGuiaModel
    {
        public int idNumeroGuia { get; set; }
        public string NumeroGuia { get; set; }
        public int idPaqueteria { get; set; }
        public decimal ImporteTotal { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }

    }

    public class NumeroGuiaNetsuiteCModel
    {
        public int idNumeroGuia { get; set; }
        public string  Tipo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }



    }

    public class NumeroGuiaNetsuiteDModel
    {
        public int idNumeroGuia { get; set; }
        public int idFactura { get; set; }
        public string RazonAutorizacion { get; set; }

        public string Autorizacion { get; set; }

    }
}
