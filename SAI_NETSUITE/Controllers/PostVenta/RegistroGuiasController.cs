using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

namespace SAI_NETSUITE.Controllers.PostVenta
{
    class RegistroGuiasController
    {


        public List<Departamentos> GetDepartments()
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var result = from I in ctx.Departments
                             select new Departamentos { DEPARTMENT_ID = I.DEPARTMENT_ID, NAME = I.NAME };
                return result.ToList();
            }

        }



        public List<Municipio_Estado> GetMunicipio_Estados()
        {
            string query = "select distinct delegacion,estado from server5.indar.dbo.codigopostal order by delegacion,estado";
            SqlConnection myConnection = new SqlConnection(SAI_NETSUITE.Properties.Settings.Default.INDAR_INACTIONWMSConnectionString1);
            SqlDataAdapter da = new SqlDataAdapter(query, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var list = ds.Tables[0].AsEnumerable().Select(r => new Municipio_Estado()
            {
                municipio = (string)r["delegacion"],
                estado = (string)r["estado"],
            }
                ).ToList();

                return list;

        }



        public class Municipio_Estado
            {
            public string  municipio { get; set; }
            public string estado { get; set; }
        }

        public class Departamentos
        {
            public int DEPARTMENT_ID { get; set; }

            public string NAME { get; set; }
        }

        public bool guiaRepetida(string guia)
        {

            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                if (ctx.NumeroGuiaNetsuite.Any(x => x.NumeroGuia == guia))
                    return true;
                else return false; // no hay repetidos y si se puede registrar
            }
        }

        public bool registrGuia(string Numguia, string txtImporte, string vendor, string department, string municipio, string estado, string clasificador,string paqueteriaID,string usuario)
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                NumeroGuiaNetsuite guia = new NumeroGuiaNetsuite();
                guia.clasificador = clasificador;
                guia.department_id =Convert.ToInt32( vendor);
                guia.estado = estado;
                guia.Fecha = DateTime.Now;
                guia.idPaqueteria = Convert.ToInt32(paqueteriaID);
                guia.NumeroGuia = Numguia;
                guia.ImporteTotal = Convert.ToDecimal(txtImporte);
                guia.municipio = municipio;
                guia.Usuario = usuario;

                ctx.NumeroGuiaNetsuite.Add(guia);
              int returnValue=  ctx.SaveChanges();
                if (returnValue > 0)
                    return true;
                else return false;
            }
        }
    }
}
