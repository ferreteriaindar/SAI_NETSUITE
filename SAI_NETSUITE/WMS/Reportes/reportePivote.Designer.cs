namespace SAI_NETSUITE.WMS.Reportes
{
    partial class reportePivote
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
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule1 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings1 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule2 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings2 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            this.fieldPORSURTIR1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldIdOrdenEmbarque1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldMov1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldNumPedido1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldClave1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldIdEstilo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAREA1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldFechaIngreso1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPrioridad1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCLIENTE1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldFormaEnvio1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSURTIDO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldPORSURTIR1
            // 
            this.fieldPORSURTIR1.Area =  DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldPORSURTIR1.AreaIndex = 0;
            this.fieldPORSURTIR1.FieldName = "PORSURTIR";
            this.fieldPORSURTIR1.Name = "fieldPORSURTIR1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.ActiveFilterString = "";
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldIdOrdenEmbarque1,
            this.fieldMov1,
            this.fieldNumPedido1,
            this.fieldClave1,
            this.fieldIdEstilo1,
            this.fieldAREA1,
            this.fieldFechaIngreso1,
            this.fieldPrioridad1,
            this.fieldCLIENTE1,
            this.fieldFormaEnvio1,
            this.fieldSURTIDO1,
            this.fieldPORSURTIR1});
            pivotGridFormatRule1.Measure = this.fieldPORSURTIR1;
            pivotGridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.PredefinedName = "Green Fill, Green Text";
            formatConditionRuleValue1.Value1 = ((short)(0));
            pivotGridFormatRule1.Rule = formatConditionRuleValue1;
            pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            pivotGridFormatRule2.Measure = this.fieldPORSURTIR1;
            pivotGridFormatRule2.Name = "Format1";
            formatConditionRuleExpression1.Expression = "[PORSURTIR] >= 1 And [SURTIDO] >= [PORSURTIR]";
            formatConditionRuleExpression1.PredefinedName = "Yellow Fill, Yellow Text";
            pivotGridFormatRule2.Rule = formatConditionRuleExpression1;
            pivotGridFormatRule2.Settings = formatRuleTotalTypeSettings2;
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule1);
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule2);
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(969, 611);
            this.pivotGridControl1.TabIndex = 1;
            this.pivotGridControl1.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl1_CellDoubleClick_1);
            // 
            // fieldIdOrdenEmbarque1
            // 
            this.fieldIdOrdenEmbarque1.AreaIndex = 0;
            this.fieldIdOrdenEmbarque1.FieldName = "IdOrdenEmbarque";
            this.fieldIdOrdenEmbarque1.Name = "fieldIdOrdenEmbarque1";
            // 
            // fieldMov1
            // 
            this.fieldMov1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldMov1.AreaIndex = 4;
            this.fieldMov1.FieldName = "Mov";
            this.fieldMov1.Name = "fieldMov1";
            // 
            // fieldNumPedido1
            // 
            this.fieldNumPedido1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNumPedido1.AreaIndex = 5;
            this.fieldNumPedido1.FieldName = "NumPedido";
            this.fieldNumPedido1.Name = "fieldNumPedido1";
            // 
            // fieldClave1
            // 
            this.fieldClave1.AreaIndex = 1;
            this.fieldClave1.FieldName = "Clave";
            this.fieldClave1.Name = "fieldClave1";
            // 
            // fieldIdEstilo1
            // 
            this.fieldIdEstilo1.AreaIndex = 2;
            this.fieldIdEstilo1.FieldName = "IdEstilo";
            this.fieldIdEstilo1.Name = "fieldIdEstilo1";
            // 
            // fieldAREA1
            // 
            this.fieldAREA1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldAREA1.AreaIndex = 0;
            this.fieldAREA1.FieldName = "AREA";
            this.fieldAREA1.Name = "fieldAREA1";
            // 
            // fieldFechaIngreso1
            // 
            this.fieldFechaIngreso1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFechaIngreso1.AreaIndex = 3;
            this.fieldFechaIngreso1.CellFormat.FormatString = "g";
            this.fieldFechaIngreso1.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fieldFechaIngreso1.FieldName = "FechaIngreso";
            this.fieldFechaIngreso1.Name = "fieldFechaIngreso1";
            this.fieldFechaIngreso1.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            // 
            // fieldPrioridad1
            // 
            this.fieldPrioridad1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPrioridad1.AreaIndex = 0;
            this.fieldPrioridad1.FieldName = "Prioridad";
            this.fieldPrioridad1.Name = "fieldPrioridad1";
            // 
            // fieldCLIENTE1
            // 
            this.fieldCLIENTE1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCLIENTE1.AreaIndex = 2;
            this.fieldCLIENTE1.FieldName = "CLIENTE";
            this.fieldCLIENTE1.Name = "fieldCLIENTE1";
            // 
            // fieldFormaEnvio1
            // 
            this.fieldFormaEnvio1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFormaEnvio1.AreaIndex = 1;
            this.fieldFormaEnvio1.FieldName = "FormaEnvio";
            this.fieldFormaEnvio1.Name = "fieldFormaEnvio1";
            // 
            // fieldSURTIDO1
            // 
            this.fieldSURTIDO1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldSURTIDO1.AreaIndex = 1;
            this.fieldSURTIDO1.FieldName = "SURTIDO";
            this.fieldSURTIDO1.Name = "fieldSURTIDO1";
            this.fieldSURTIDO1.Options.ShowValues = false;
            // 
            // reportePivote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pivotGridControl1);
            this.Name = "reportePivote";
            this.Size = new System.Drawing.Size(969, 611);
            this.Load += new System.EventHandler(this.reportePivote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldIdOrdenEmbarque1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldMov1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNumPedido1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldClave1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldIdEstilo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAREA1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldFechaIngreso1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPrioridad1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCLIENTE1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldFormaEnvio1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSURTIDO1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPORSURTIR1;

    }
}
