﻿using Newtonsoft.Json;
using SAI_NETSUITE.Models.Transaccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Controllers.Logistica.Distribucion
{
    class GastoFleterasController
    {

        public List<Models.Catalogos.Vendor> regresaVendors()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var z = (from i in ctx.Entity
                         where (i.ENTITY_TYPE.Equals("Vendor") && i.PAQUETERIA_DISTRIBUCION_ID != null)
                         select new Models.Catalogos.Vendor { ENTITY_ID = i.ENTITY_ID, NAME = i.NAME, PAQUETERIA_DISTRIBUCION_ID = i.PAQUETERIA_DISTRIBUCION_ID , OficinaNameFletara = i.NAME}).ToList();

                //AGREGAR LAS OFICINAS QUE  APUNTAN A UN PROVEEDOR REPETIDO
                Models.Catalogos.Vendor OfLeon = new Models.Catalogos.Vendor() { ENTITY_ID = 25102, NAME = "OF LEON", PAQUETERIA_DISTRIBUCION_ID = 44, OficinaNameFletara = "A2710 PAQUETERIA Y MENSAJERIA EL GRAN CAÑON SA DE CV" };
                z.Add(OfLeon);
                return z;
            }
            
        }

        public  DataSet /*List<NumeroGuiaNetsuite> */regresaGuias(string v)
        {
            /*int idpaqueteria = Convert.ToInt32(v);

            IndarnegEntities ctx = new IndarnegEntities();
            
                var guias = (from i in ctx.NumeroGuiaNetsuite
                             where (i.idPaqueteria== idpaqueteria)
                             select i).ToList();
                return guias.ToList();*/

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                var Oficinas= new[] { "24", "25", "26", "27", "28", "29", "44", "51" };
                string query = "EXECUTE IndarWms.dbo.[spCostoGuiasFletera] " + v;
                if (Oficinas.Any(x=>v.Contains(x)))
                    query = "EXECUTE IndarWms.dbo.spCostoGuiaXEmbarque "+v;
                SqlCommand cmd = new SqlCommand(query, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            };
           

        }

        public string regresaDepartmentGuia(string  idNumeroGuiua)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"select TOP 1  DEPA.DEPARTMENT_ID from Indarneg.dbo.NumeroGuiaNetsuite NG
INNER JOIN Indarneg.dbo.NumeroGuiaNetsuiteD  NGD ON NG.idNumeroGuia=NGD.idNumeroGuia
INNER JOIN IWS.dbo.Invoices I on NGD.Factura=I.TranId
INNER JOIN (
SELECT D4.NAME+' : '+ D3.NAME+' : '+D2.NAME+' : '+D1.NAME   AS DEPARTAMENTO,D1.DEPARTMENT_ID FROM IWS.dbo.Departments D1  
INNER JOIN IWS.dbo.Departments D2 ON D1.PARENT_ID=D2.DEPARTMENT_ID
INNER JOIN IWS.dbo.Departments D3 ON D2.PARENT_ID=D3.DEPARTMENT_ID
INNER JOIN IWS.dbo.Departments D4 ON D3.PARENT_ID=D4.DEPARTMENT_ID
) DEPA ON I.DepartamentoCliente=DEPA.DEPARTAMENTO

                                    where NG.idNumeroGuia=" + idNumeroGuiua;
                var resultado = cmd.ExecuteScalar().ToString();
                return resultado != null ? resultado.ToString() : "";
            }

        }



        public string regresaDepartmentFactura(string factura)
        {
            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("", myConnection);
                cmd.CommandText = @"select TOP 1  DEPA.DEPARTMENT_ID from IWS.dbo.Invoices I INNER JOIN (
SELECT D4.NAME+' : '+ D3.NAME+' : '+D2.NAME+' : '+D1.NAME   AS DEPARTAMENTO,D1.DEPARTMENT_ID FROM IWS.dbo.Departments D1  
INNER JOIN IWS.dbo.Departments D2 ON D1.PARENT_ID=D2.DEPARTMENT_ID
INNER JOIN IWS.dbo.Departments D3 ON D2.PARENT_ID=D3.DEPARTMENT_ID
INNER JOIN IWS.dbo.Departments D4 ON D3.PARENT_ID=D4.DEPARTMENT_ID
) DEPA ON I.DepartamentoCliente=DEPA.DEPARTAMENTO

                                    where I.TranId=" + factura;
                var resultado = cmd.ExecuteScalar().ToString();
                return resultado != null ? resultado.ToString() : "";
            }

        }

        internal object RegresaGridFinalXEmbarque(List<GastoFleteraModel> listaGuias,string importeEmbarque)
        {

            List<GastoFleteraModel> lista = new List<GastoFleteraModel>();

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                foreach (var item in listaGuias)
                {
                    string query = "exec  indarwms.dbo.spCostoGuiasFleteraGridXEmbarque " + item.idNumeroGuia;
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read() && sdr.HasRows)
                    {
                        GastoFleteraModel gfm = new GastoFleteraModel();

                        gfm.idNumeroGuia = item.idNumeroGuia;
                        gfm.NumeroGuia = item.NumeroGuia;                       
                        gfm.CAJAS = sdr.GetInt32(1);
                       // gfm.importe = item.importe;
                        gfm.Facturas = sdr.GetString(2);
                        gfm.METODO = "EMBARQUE";
                        gfm.cliente = sdr.GetString(0);
                        gfm.comentario = " ";
                        lista.Add(gfm);
                    }
                    myConnection.Close();
                }

                var SUMA = lista.Sum(x => x.CAJAS);

                foreach (var item in lista)
                {
                    item.importe = item.CAJAS *  (Convert.ToDecimal(importeEmbarque) / Convert.ToInt32(SUMA.ToString()));
                }

                return lista;
            }
        }

        public List<GastoFleteraModel> RegresaGridFinal(List<GastoFleteraModel> listaGuias)
        {
            List<GastoFleteraModel> lista = new List<GastoFleteraModel>();

            using (SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1))
            {
                foreach (var item in listaGuias)
                {
                    string query = "exec  indarwms.dbo.spCostoGuiasFleteraGrid " + item.idNumeroGuia;

                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read() && sdr.HasRows)
                    {
                        GastoFleteraModel gfm = new GastoFleteraModel();

                        gfm.idNumeroGuia = item.idNumeroGuia;
                            gfm.NumeroGuia = item.NumeroGuia;
                        gfm.importe = item.importe;
                        gfm.CAJAS = sdr.GetInt32(0);
                        gfm.BULTOS = sdr.GetInt32(1);
                        gfm.ATADO = sdr.GetInt32(2);
                        gfm.TARIMA = sdr.GetInt32(3);
                        gfm.Facturas = sdr.GetString(4);
                        gfm.METODO = sdr.GetString(5);
                        gfm.paqueteria = sdr.GetString(6);
                        gfm.comentario = " ";


                      
                        lista.Add(gfm);
                    }
                    myConnection.Close();
                }

                return lista.ToList();
          
            }
        }

        public bool enviarBill(StringBuilder sb, string xmlString, string name,int csvName)
        {

            GastoFleteraSend gfs = new GastoFleteraSend
            {
                content = xmlString, //xmlString.Replace("\"", "\\\""),
                csv = Encoding.UTF8.GetString(Encoding.Default.GetBytes(sb.ToString())),
                name = name ,
                csvName=csvName.ToString()
            };
            string json = JsonConvert.SerializeObject(gfs);
            Console.WriteLine(json);
            return true;
        }

        public List<GastoFleteraCSVModel> regresaLineaBill(GastoFleteraModel item,bool retencion)
        {
            List<GastoFleteraCSVModel> listaRegresar = new List<GastoFleteraCSVModel>();
            var listaFacturas = new Dictionary<string, decimal?>();
            string[] array = item.Facturas.Split(',');
            IWSEntities ctx = new IWSEntities();
            foreach (var factura in array)
            {
                decimal tranid = Convert.ToInt32(factura);
                decimal? importe = ctx.Invoices.Where(x => x.TranId==(tranid)).Select(x => x.Total).FirstOrDefault().Value;
                listaFacturas.Add(factura, importe);
            }
            decimal? suma = 0;
            foreach (var dic in listaFacturas)
            {
                suma = suma + dic.Value;
            }

            decimal iva = retencion ? (decimal)1.12 :(decimal) 1.16;
            decimal? subtotal = item.importe / iva;

            foreach (var factura in listaFacturas)
            {
                GastoFleteraCSVModel aux = new GastoFleteraCSVModel()
                {
                    Date = DateTime.Now.ToShortDateString(),
                    DepartmentHead = "180", // "20000-DIRECCIÓN COMERCIAL : 25100-GERENCIA VTAS TELEFONICAS : 25100-ZONA 100",
                    Location = "LOGISTICA",
                    Quantity = "1",
                    Department = regresaDepartmentFactura(factura.Key),
                    Item = retencion ? "FLETES CON RETENCION" : "FLETES SIN RETENCION",
                    Rate = subtotal / suma * factura.Value,
                    Tax = retencion ? "RET IVA FLETES:GPO RET FLETE" : "IVA 16%:IVA 16%",
                    Relacion= "Invoice #"+factura.Key.ToString()

                };
                listaRegresar.Add(aux);
            }

            return listaRegresar;
        }

        public List<GastoFleteraCSVModel> regresaLineaBillporEtiquetas(GastoFleteraModel item, bool retencion)
        {
            throw new NotImplementedException();
        }

        public bool validarContrasena(string pass)
        {
            return true;
        }
    }
}