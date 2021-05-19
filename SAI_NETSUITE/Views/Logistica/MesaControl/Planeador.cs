﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAI_NETSUITE.Models.Transaccion;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DashboardCommon;

namespace SAI_NETSUITE.Views.Logistica.MesaControl
{
    public partial class Planeador : UserControl
    {
        public Planeador()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource



            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
           // sqlDataSource1.Fill();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                MessageBox.Show("Espera todavia no termina");
            else
            {
                btnActualizar.ImageOptions.Image = SAI_NETSUITE.Properties.Resources.gear;
                backgroundWorker1.RunWorkerAsync();
               // sqlDataSource1.Fill();


               
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
             Controllers.Logistica.MesaControl.PlaneadorController pc = new Controllers.Logistica.MesaControl.PlaneadorController();

             List<PlaneadorModel> lista = pc.GetPlaneadors();

             e.Result = lista;

          

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
              List<PlaneadorModel> lista =(List<PlaneadorModel>) e.Result;
              pivotGridControl1.DataSource = lista;


            //ESTO ES PARA PONER BOLITAS AL FINAL DEL PIVOT  SE PUEDE QUITAR
                    PivotGridFormatRule newRule = new PivotGridFormatRule();
                    newRule.Measure = porSurtirField;         
                    newRule = pivotGridControl1.FormatRules[2];
                  /*  FormatRuleSettings settins = newRule.Settings;
                    Console.WriteLine(settins.ToString());*/
                    //   settins{ "Format cells where Column field is fieldAREA1 and Row field is Grand Total"};
                    newRule.Settings = new FormatRuleFieldIntersectionSettings
                    {
                        Column = fieldAREA1,
                        Row= pivotGridControl1.Fields["Grand Total"]
                };
                    pivotGridControl1.FormatRules[2].Settings = newRule.Settings;
            //ESTO ES PARA PONER BOLITAS AL FINAL DEL PIVOT  SE PUEDE QUITAR



            // sqlDataSource1.Fill();
            btnActualizar.ImageOptions.Image = null;
            labelControl1.Text = DateTime.Now.ToShortTimeString();
        }

        private void sqlDataSource1_ValidateCustomSqlQuery(object sender, DevExpress.DataAccess.ValidateCustomSqlQueryEventArgs e)
        {
           e.Valid = true;
        }

        private void btnCajasPendientes_Click(object sender, EventArgs e)
        {
            Controllers.Logistica.MesaControl.CajasPendientes cp = new Controllers.Logistica.MesaControl.CajasPendientes();
            cp.Show();
        }

        private void pivotGridControl1_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            PivotDrillDownDataSource drillDownDataSource;

            drillDownDataSource = e.CreateDrillDownDataSource();

            Console.WriteLine("");
            if (drillDownDataSource.RowCount > 0)
            {
                XtraForm dataform = CreateDrillDownForm(drillDownDataSource);
                dataform.ShowDialog();
                dataform.Dispose();
            }
        }





        private XtraForm CreateDrillDownForm(PivotDrillDownDataSource dataSource)
        {
            XtraForm form = new XtraForm();
            GridControl grid = new GridControl();
            grid.Parent = form;
            grid.Dock = DockStyle.Fill;
            grid.DataSource = dataSource;
            grid.DataSource =
            form.Bounds = new Rectangle(100, 100, 800, 400);
            GridView gridView1 = new GridView();
            grid.MainView = gridView1;
        //    gridView1.Columns["OrderDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            form.Text = string.Format("Underlying Data - {0} Records", dataSource.RowCount);
            return form;
        }
    }
}