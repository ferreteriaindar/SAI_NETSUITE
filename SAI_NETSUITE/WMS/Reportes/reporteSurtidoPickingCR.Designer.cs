namespace SAI.Almacen.WMS.Reportes
{
    partial class reporteSurtidoPickingCR
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
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings1 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporteSurtidoPickingCR));
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldCLIENTE1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldFormaEnvio1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPrioridad1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldclave1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldIdOrdenEmbarque1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldNumPedido1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldArea1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldnombre1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAreas21 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.ActiveFilterString = "";
            this.pivotGridControl1.DataMember = "Query";
            this.pivotGridControl1.DataSource = this.sqlDataSource1;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldCLIENTE1,
            this.fieldFormaEnvio1,
            this.fieldPrioridad1,
            this.fieldclave1,
            this.fieldIdOrdenEmbarque1,
            this.fieldNumPedido1,
            this.fieldArea1,
            this.fieldnombre1,
            this.fieldAreas21});
            pivotGridFormatRule1.Measure = this.fieldclave1;
            pivotGridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[nombre] = \'En Proceso\' And [clave] > 1";
            formatConditionRuleExpression1.PredefinedName = "Yellow Fill, Yellow Text";
            pivotGridFormatRule1.Rule = formatConditionRuleExpression1;
            pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule1);
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(1250, 547);
            this.pivotGridControl1.TabIndex = 0;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "SAI.Properties.Settings.INDAR_INACTIONWMSConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = "exec Indarwms.dbo.spNivelPickingCR\r\n";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // fieldCLIENTE1
            // 
            this.fieldCLIENTE1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCLIENTE1.AreaIndex = 3;
            this.fieldCLIENTE1.FieldName = "CLIENTE";
            this.fieldCLIENTE1.Name = "fieldCLIENTE1";
            this.fieldCLIENTE1.Options.ShowGrandTotal = false;
            this.fieldCLIENTE1.Options.ShowTotals = false;
            // 
            // fieldFormaEnvio1
            // 
            this.fieldFormaEnvio1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFormaEnvio1.AreaIndex = 2;
            this.fieldFormaEnvio1.FieldName = "FormaEnvio";
            this.fieldFormaEnvio1.Name = "fieldFormaEnvio1";
            this.fieldFormaEnvio1.Options.ShowGrandTotal = false;
            this.fieldFormaEnvio1.Options.ShowTotals = false;
            // 
            // fieldPrioridad1
            // 
            this.fieldPrioridad1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPrioridad1.AreaIndex = 1;
            this.fieldPrioridad1.FieldName = "Prioridad";
            this.fieldPrioridad1.Name = "fieldPrioridad1";
            this.fieldPrioridad1.Options.ShowGrandTotal = false;
            this.fieldPrioridad1.Options.ShowTotals = false;
            // 
            // fieldclave1
            // 
            this.fieldclave1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldclave1.AreaIndex = 0;
            this.fieldclave1.FieldName = "clave";
            this.fieldclave1.Name = "fieldclave1";
            this.fieldclave1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            // 
            // fieldIdOrdenEmbarque1
            // 
            this.fieldIdOrdenEmbarque1.AreaIndex = 0;
            this.fieldIdOrdenEmbarque1.FieldName = "IdOrdenEmbarque";
            this.fieldIdOrdenEmbarque1.Name = "fieldIdOrdenEmbarque1";
            this.fieldIdOrdenEmbarque1.Options.ShowGrandTotal = false;
            this.fieldIdOrdenEmbarque1.Options.ShowTotals = false;
            // 
            // fieldNumPedido1
            // 
            this.fieldNumPedido1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNumPedido1.AreaIndex = 4;
            this.fieldNumPedido1.FieldName = "NumPedido";
            this.fieldNumPedido1.Name = "fieldNumPedido1";
            this.fieldNumPedido1.Options.ShowGrandTotal = false;
            this.fieldNumPedido1.Options.ShowTotals = false;
            // 
            // fieldArea1
            // 
            this.fieldArea1.AreaIndex = 1;
            this.fieldArea1.FieldName = "Area";
            this.fieldArea1.Name = "fieldArea1";
            // 
            // fieldnombre1
            // 
            this.fieldnombre1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldnombre1.AreaIndex = 0;
            this.fieldnombre1.FieldName = "nombre";
            this.fieldnombre1.Name = "fieldnombre1";
            this.fieldnombre1.Options.ShowCustomTotals = false;
            this.fieldnombre1.Options.ShowGrandTotal = false;
            this.fieldnombre1.Options.ShowTotals = false;
            this.fieldnombre1.Options.ShowValues = false;
            // 
            // fieldAreas21
            // 
            this.fieldAreas21.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldAreas21.AreaIndex = 0;
            this.fieldAreas21.FieldName = "Areas2";
            this.fieldAreas21.Name = "fieldAreas21";
            // 
            // reporteSurtidoPickingCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pivotGridControl1);
            this.Name = "reporteSurtidoPickingCR";
            this.Size = new System.Drawing.Size(1250, 547);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCLIENTE1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldFormaEnvio1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPrioridad1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldclave1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldIdOrdenEmbarque1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNumPedido1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldArea1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldnombre1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAreas21;
    }
}
