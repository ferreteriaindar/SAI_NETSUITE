namespace SAI_NETSUITE.WMS.Reportes
{
    partial class reporteSurtipickingPIVOT
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
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule1 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings1 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule2 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings2 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            this.spNivelPickingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wMS_NivelPicking = new WMS_NivelPicking();
            this.spNivelPickingTableAdapter = new WMS_NivelPickingTableAdapters.spNivelPickingTableAdapter();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldNUMPEDIDO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPRIORIDAD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldFORMAENVIO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCLIENTE1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldNombre1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldarea1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldARITCULO1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldporsurtir1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldsurtido1 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.spNivelPickingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMS_NivelPicking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // spNivelPickingBindingSource
            // 
            this.spNivelPickingBindingSource.DataMember = "spNivelPicking";
            this.spNivelPickingBindingSource.DataSource = this.wMS_NivelPicking;
            // 
            // wMS_NivelPicking
            // 
            this.wMS_NivelPicking.DataSetName = "WMS_NivelPicking";
            this.wMS_NivelPicking.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spNivelPickingTableAdapter
            // 
            this.spNivelPickingTableAdapter.ClearBeforeFill = true;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.spNivelPickingBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldNUMPEDIDO1,
            this.fieldPRIORIDAD1,
            this.fieldFORMAENVIO1,
            this.fieldCLIENTE1,
            this.fieldNombre1,
            this.fieldarea1,
            this.fieldARITCULO1,
            this.fieldporsurtir1,
            this.fieldsurtido1});
            pivotGridFormatRule1.Measure = this.fieldporsurtir1;
            pivotGridFormatRule1.Name = "completo";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.PredefinedName = "Green Fill, Green Text";
            formatConditionRuleValue1.Value1 = 0;
            pivotGridFormatRule1.Rule = formatConditionRuleValue1;
            pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            pivotGridFormatRule2.Measure = this.fieldporsurtir1;
            pivotGridFormatRule2.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[porsurtir] >= 1 And [surtido] >= [porsurtir]";
            formatConditionRuleExpression1.PredefinedName = "Yellow Fill, Yellow Text";
            pivotGridFormatRule2.Rule = formatConditionRuleExpression1;
            pivotGridFormatRule2.Settings = formatRuleTotalTypeSettings2;
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule1);
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule2);
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsMenu.EnableFormatRulesMenu = true;
            this.pivotGridControl1.OptionsPrint.MergeRowFieldValues = false;
            this.pivotGridControl1.OptionsView.GroupFieldsInCustomizationWindow = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowTotals = false;
            
            this.pivotGridControl1.Size = new System.Drawing.Size(1341, 541);
            this.pivotGridControl1.TabIndex = 2;
            this.pivotGridControl1.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl1_CellDoubleClick);
            // 
            // fieldNUMPEDIDO1
            // 
            this.fieldNUMPEDIDO1.Area =  DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNUMPEDIDO1.AreaIndex = 3;
            this.fieldNUMPEDIDO1.FieldName = "NUMPEDIDO";
            this.fieldNUMPEDIDO1.Name = "fieldNUMPEDIDO1";
            // 
            // fieldPRIORIDAD1
            // 
            this.fieldPRIORIDAD1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPRIORIDAD1.AreaIndex = 0;
            this.fieldPRIORIDAD1.FieldName = "PRIORIDAD";
            this.fieldPRIORIDAD1.Name = "fieldPRIORIDAD1";
            // 
            // fieldFORMAENVIO1
            // 
            this.fieldFORMAENVIO1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFORMAENVIO1.AreaIndex = 1;
            this.fieldFORMAENVIO1.FieldName = "FORMAENVIO";
            this.fieldFORMAENVIO1.Name = "fieldFORMAENVIO1";
            // 
            // fieldCLIENTE1
            // 
            this.fieldCLIENTE1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCLIENTE1.AreaIndex = 2;
            this.fieldCLIENTE1.FieldName = "CLIENTE";
            this.fieldCLIENTE1.Name = "fieldCLIENTE1";
            // 
            // fieldNombre1
            // 
            this.fieldNombre1.AreaIndex = 0;
            this.fieldNombre1.FieldName = "Nombre";
            this.fieldNombre1.Name = "fieldNombre1";
            // 
            // fieldarea1
            // 
            this.fieldarea1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldarea1.AreaIndex = 0;
            this.fieldarea1.FieldName = "area";
            this.fieldarea1.Name = "fieldarea1";
            // 
            // fieldARITCULO1
            // 
            this.fieldARITCULO1.AreaIndex = 1;
            this.fieldARITCULO1.FieldName = "ARITCULO";
            this.fieldARITCULO1.Name = "fieldARITCULO1";
            // 
            // fieldporsurtir1
            // 
            this.fieldporsurtir1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldporsurtir1.AreaIndex = 0;
            this.fieldporsurtir1.FieldName = "porsurtir";
            this.fieldporsurtir1.Name = "fieldporsurtir1";
            // 
            // fieldsurtido1
            // 
            this.fieldsurtido1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldsurtido1.AreaIndex = 1;
            this.fieldsurtido1.FieldName = "surtido";
            this.fieldsurtido1.MinWidth = 0;
            this.fieldsurtido1.Name = "fieldsurtido1";
            this.fieldsurtido1.Options.ShowCustomTotals = false;
            this.fieldsurtido1.Options.ShowGrandTotal = false;
            this.fieldsurtido1.Options.ShowSummaryTypeName = true;
            this.fieldsurtido1.Options.ShowValues = false;
            this.fieldsurtido1.Width = 0;
            // 
            // reporteSurtipickingPIVOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pivotGridControl1);
            this.Name = "reporteSurtipickingPIVOT";
            this.Size = new System.Drawing.Size(1341, 541);
            this.Load += new System.EventHandler(this.reporteSurtipickingPIVOT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spNivelPickingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMS_NivelPicking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource spNivelPickingBindingSource;
        private WMS_NivelPicking wMS_NivelPicking;
        private WMS_NivelPickingTableAdapters.spNivelPickingTableAdapter spNivelPickingTableAdapter;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNUMPEDIDO1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPRIORIDAD1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldFORMAENVIO1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCLIENTE1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNombre1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldarea1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldARITCULO1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldporsurtir1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldsurtido1;
    }
}
