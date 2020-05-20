﻿using Newtonsoft.Json;
using SAI_NETSUITE.Models.Catalogos;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.CXC
{
    class PaymentInvoiceApplyController
    {


        public PaymentInvoiceApplyModel regresaPortafolio(string idZona)
        {

            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = con.GET("api/Customer/GetPayment_Invoice_Apply?idZona=" + idZona, SAI_NETSUITE.Properties.Resources.token);
            PaymentInvoiceApplyModel piam = JsonConvert.DeserializeObject<PaymentInvoiceApplyModel>(json);
            return piam;
        }

        public List<FormaPagoSAT> regresaListaFormaPago()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var sat = from i in ctx.FormaPagoSAT select i;
                return sat.ToList();

            }
        }
        public bool ApplyPaymentMethod(ApplyPaymentCSVModel csv)
        {
            SAI_NETSUITE.IWS.Connection con = new SAI_NETSUITE.IWS.Connection();
            string json = JsonConvert.SerializeObject(csv);
           string response = con.POST("api/Customer/Apply_PaymentCSV", json, SAI_NETSUITE.Properties.Resources.token);
           respuesta res = JsonConvert.DeserializeObject<respuesta>(response);
            if (res.result.Equals("true"))
                return true;
            else return false;           


        }
    }
}