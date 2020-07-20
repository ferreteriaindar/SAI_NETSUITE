using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    public partial class DetallePedido : Form
    {
        string mov, movid;

      

        public DetallePedido(string mov,string movid)
        {
            this.mov = mov;
            this.movid = movid;
            InitializeComponent();
        }

        private void DetallePedido_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        private void cargaDatos()
        {
            
            using (INDAR_INACTIONWMSEntities ctx = new INDAR_INACTIONWMSEntities())
            {
                if (mov.Equals("salesorder") || mov.Equals("Traspaso"))
                {
                    var datos = from o in ctx.OrdenEmbarque
                                join pr in ctx.PedidoRenglon on o.IdOrdenEmbarque equals pr.IdOrdenEmbarque
                                join e in ctx.Estilo on pr.IdEstilo equals e.IdEstilo
                                where o.Mov.Equals(mov) && o.NumPedido.Equals(movid)
                                select new { e.Clave,  pr.CantUnitarios, pr.CantSurtida, pr.CantConsolidada, pr.CantCancelada, e.Descripcion };

                    gridControl1.DataSource = datos.ToList();
                }
                else
                {
                    var datos = from o in ctx.OrdenEmbarque
                                join pr in ctx.PedidoRenglon on o.IdOrdenEmbarque equals pr.IdOrdenEmbarque
                                join e in ctx.Estilo on pr.IdEstilo equals e.IdEstilo
                                where o.Consolidado.Equals(movid)
                                select new {o.NumPedido, e.Clave, pr.CantUnitarios, pr.CantSurtida, pr.CantConsolidada, pr.CantCancelada, e.Descripcion, };

                    gridControl1.DataSource = datos.ToList();
                    gridView1.Columns["NumPedido"].Group();
           

                }

            }
        }
    }
}
