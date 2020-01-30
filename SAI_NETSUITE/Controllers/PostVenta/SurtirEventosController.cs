using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.PostVenta
{
    class SurtirEventosController
    {


        public TransferOrderSearchModel regresaDatos()
        {
            
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/Inventory/GetTransferOrders", SAI_NETSUITE.Properties.Resources.token);
            TransferOrderSearchModel list = JsonConvert.DeserializeObject<TransferOrderSearchModel>(json);
            return list;
        }
    }
}
