using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAI_NETSUITE.Views.Ventas.Apoyos
{
    public partial class ConvertirSAD : UserControl
    {
        string usuario;
        public ConvertirSAD(string usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
            {
                MessageBox.Show("Ingresa todos los datos");
            }
            else
            {
                int internalID =  Existe(Convert.ToInt32(txtPedido.Text));
                if (internalID < 1)
                    MessageBox.Show("No existe Factura");
                else
                {
                    if (ExisteSAD(internalID))
                        MessageBox.Show("REPETIDO YA EXISTE REGISTRO");
                    else
                    {
                        try
                        {//INSERTAR EL SAD
                            using (IndarnegEntities ctx = new IndarnegEntities())
                            {
                                SAD S = new SAD()
                                {
                                    comentario = txtComentario.Text,
                                    fecha = DateTime.Now,
                                    excepcion = comboBoxEdit1.Text,
                                    usuario = usuario,
                                    pedido = Convert.ToInt32(txtPedido.Text),
                                    pedidoID = Existe(Convert.ToInt32(txtPedido.Text))

                                };
                                ctx.SAD.Add(S);
                                ctx.SaveChanges();
                                MessageBox.Show("TERMINADO");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("error");
                        }
                    }
                }


            }
        }

        public int Existe(int numFac)
        {
            using (IWSEntities ctx = new IWSEntities())
            {
                var internalID = (from i in ctx.SaleOrders
                                  where i.tranId==(numFac)
                                  select i).SingleOrDefault();
                if (internalID == null)
                    return 0;


                return internalID.internalId;


            }
        }

        public bool ExisteSAD(int internalID)
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {
                var sad = (from i in ctx.SAD
                           where i.pedidoID==internalID
                           select i.usuario).SingleOrDefault();
                if (sad != null)
                    return true;
                else return false;
            }

        }

    }
}

