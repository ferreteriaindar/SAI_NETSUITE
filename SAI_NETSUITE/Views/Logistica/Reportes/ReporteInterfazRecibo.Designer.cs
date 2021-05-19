namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    partial class ReporteInterfazRecibo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.coltranid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colfrom_location = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colto_location = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltrandate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadRecibida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadNoRecibida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaModificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstatusSincronizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // coltranid
            // 
            this.coltranid.Caption = "NS_tranid";
            this.coltranid.FieldName = "tranid";
            this.coltranid.Name = "coltranid";
            this.coltranid.Visible = true;
            this.coltranid.VisibleIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExcel);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.btnCargar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1313, 108);
            this.panelControl1.TabIndex = 0;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(25, 41);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(212, 22);
            this.dateEdit1.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.dateEdit1, conditionValidationRule2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha";
            // 
            // btnCargar
            // 
            this.btnCargar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCargar.Location = new System.Drawing.Point(243, 20);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(191, 68);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 108);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1313, 327);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coltranid,
            this.colfrom_location,
            this.colto_location,
            this.colitem,
            this.colquantity,
            this.coltrandate,
            this.colMovId,
            this.colArticulo,
            this.colCantidadRecibida,
            this.colCantidadNoRecibida,
            this.colFechaModificacion,
            this.colEstatusSincronizacion,
            this.colmov});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.coltranid;
            gridFormatRule2.ColumnApplyTo = this.coltranid;
            gridFormatRule2.Name = "vacioNS";
            formatConditionRuleExpression2.Expression = "Iif([tranid] = null, True, False)";
            formatConditionRuleExpression2.PredefinedName = "Red Fill, Red Text";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            // 
            // colfrom_location
            // 
            this.colfrom_location.Caption = "NS_Origen";
            this.colfrom_location.FieldName = "from_location";
            this.colfrom_location.Name = "colfrom_location";
            this.colfrom_location.Visible = true;
            this.colfrom_location.VisibleIndex = 9;
            // 
            // colto_location
            // 
            this.colto_location.Caption = "NS_Destino";
            this.colto_location.FieldName = "to_location";
            this.colto_location.Name = "colto_location";
            this.colto_location.Visible = true;
            this.colto_location.VisibleIndex = 10;
            // 
            // colitem
            // 
            this.colitem.Caption = "NS_Articulo";
            this.colitem.FieldName = "item";
            this.colitem.Name = "colitem";
            this.colitem.Visible = true;
            this.colitem.VisibleIndex = 11;
            // 
            // colquantity
            // 
            this.colquantity.Caption = "NS_Cantidad";
            this.colquantity.FieldName = "quantity";
            this.colquantity.Name = "colquantity";
            this.colquantity.Visible = true;
            this.colquantity.VisibleIndex = 7;
            // 
            // coltrandate
            // 
            this.coltrandate.Caption = "NS_Fecha";
            this.coltrandate.FieldName = "trandate";
            this.coltrandate.Name = "coltrandate";
            this.coltrandate.Visible = true;
            this.coltrandate.VisibleIndex = 12;
            // 
            // colMovId
            // 
            this.colMovId.Caption = "WMS_MovId";
            this.colMovId.FieldName = "MovId";
            this.colMovId.Name = "colMovId";
            this.colMovId.Visible = true;
            this.colMovId.VisibleIndex = 2;
            // 
            // colArticulo
            // 
            this.colArticulo.Caption = "WMS_Articulo";
            this.colArticulo.FieldName = "Articulo";
            this.colArticulo.Name = "colArticulo";
            this.colArticulo.Visible = true;
            this.colArticulo.VisibleIndex = 3;
            // 
            // colCantidadRecibida
            // 
            this.colCantidadRecibida.Caption = "WMS_CantidadRecibida";
            this.colCantidadRecibida.FieldName = "CantidadRecibida";
            this.colCantidadRecibida.Name = "colCantidadRecibida";
            this.colCantidadRecibida.Visible = true;
            this.colCantidadRecibida.VisibleIndex = 4;
            // 
            // colCantidadNoRecibida
            // 
            this.colCantidadNoRecibida.Caption = "WMS_CantidadNoRecibida";
            this.colCantidadNoRecibida.FieldName = "CantidadNoRecibida";
            this.colCantidadNoRecibida.Name = "colCantidadNoRecibida";
            this.colCantidadNoRecibida.Visible = true;
            this.colCantidadNoRecibida.VisibleIndex = 5;
            // 
            // colFechaModificacion
            // 
            this.colFechaModificacion.Caption = "WMS_Fecha";
            this.colFechaModificacion.FieldName = "FechaModificacion";
            this.colFechaModificacion.Name = "colFechaModificacion";
            this.colFechaModificacion.Visible = true;
            this.colFechaModificacion.VisibleIndex = 0;
            // 
            // colEstatusSincronizacion
            // 
            this.colEstatusSincronizacion.Caption = "WMS_EstatusSincronizacion";
            this.colEstatusSincronizacion.FieldName = "EstatusSincronizacion";
            this.colEstatusSincronizacion.Name = "colEstatusSincronizacion";
            this.colEstatusSincronizacion.Visible = true;
            this.colEstatusSincronizacion.VisibleIndex = 6;
            // 
            // colmov
            // 
            this.colmov.Caption = "WMS_Mov";
            this.colmov.FieldName = "mov";
            this.colmov.Name = "colmov";
            this.colmov.Visible = true;
            this.colmov.VisibleIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExcel.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.xls__1_;
            this.btnExcel.Location = new System.Drawing.Point(1143, 20);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(154, 68);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // ReporteInterfazRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ReporteInterfazRecibo";
            this.Size = new System.Drawing.Size(1313, 435);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnCargar;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraGrid.Columns.GridColumn coltranid;
        private DevExpress.XtraGrid.Columns.GridColumn colfrom_location;
        private DevExpress.XtraGrid.Columns.GridColumn colto_location;
        private DevExpress.XtraGrid.Columns.GridColumn colitem;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private DevExpress.XtraGrid.Columns.GridColumn coltrandate;
        private DevExpress.XtraGrid.Columns.GridColumn colMovId;
        private DevExpress.XtraGrid.Columns.GridColumn colArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadRecibida;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadNoRecibida;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaModificacion;
        private DevExpress.XtraGrid.Columns.GridColumn colEstatusSincronizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colmov;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
    }
}
