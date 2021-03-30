﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    public partial class ParametrosFacturasXEmbarcar : Form
    {
        SAI_NETSUITE.IndarnegEntities dbContext = new SAI_NETSUITE.IndarnegEntities();
        public ParametrosFacturasXEmbarcar()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
           // SAI_NETSUITE.IndarnegEntities dbContext = new SAI_NETSUITE.IndarnegEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.DiasReporteXEmbarcar.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    diasReporteXEmbarcarBindingSource.DataSource = dbContext.DiasReporteXEmbarcar.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            dbContext.SaveChanges();
        }



        private void cargaResponsables()
        {

            using (IndarnegEntities ctx = new IndarnegEntities())
            {

                List<string> Responsable = (from i in ctx.DiasReporteXEmbarcar
                                            select i.Responsable).Distinct().ToList();
                repositoryItemComboBox2.Items.AddRange(Responsable.ToList());
            }
        }

        public void cargaEstados()
        {
            using (IndarnegEntities ctx = new IndarnegEntities())
            {

                List<string> estados = (from i in ctx.DiasReporteXEmbarcar
                                        select i.Estado).Distinct().ToList();
                repositoryItemComboBox1.Items.AddRange(estados.ToList());
            }


        }

        private void ParametrosFacturasXEmbarcar_Load(object sender, EventArgs e)
        {
            cargaEstados();
            cargaResponsables();
        }
    }
}
