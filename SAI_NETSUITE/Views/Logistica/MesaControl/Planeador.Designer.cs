namespace SAI_NETSUITE.Views.Logistica.MesaControl
{
    partial class Planeador
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
            DevExpress.XtraPivotGrid.PivotGridFormatRule pivotGridFormatRule3 = new DevExpress.XtraPivotGrid.PivotGridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon4 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings formatRuleTotalTypeSettings3 = new DevExpress.XtraPivotGrid.FormatRuleTotalTypeSettings();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planeador));
            this.porSurtirField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCajasPendientes = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.fieldMov1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldNumPedido1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPrioridad1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldFormaEnvio1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldCliente1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldClave1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldNombre1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldIdEstilo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAREA1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldporsurtir1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldsurtido1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.surtidoField = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // porSurtirField
            // 
            this.porSurtirField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.porSurtirField.AreaIndex = 0;
            this.porSurtirField.Caption = "PorSurtir";
            this.porSurtirField.FieldName = "porsurtir";
            this.porSurtirField.Name = "porSurtirField";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCajasPendientes);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnActualizar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1342, 103);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCajasPendientes
            // 
            this.btnCajasPendientes.AllowFocus = false;
            this.btnCajasPendientes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCajasPendientes.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnCajasPendientes.Appearance.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCajasPendientes.Appearance.Options.UseBorderColor = true;
            this.btnCajasPendientes.Appearance.Options.UseFont = true;
            this.btnCajasPendientes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCajasPendientes.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.logistics;
            this.btnCajasPendientes.Location = new System.Drawing.Point(1145, 23);
            this.btnCajasPendientes.Name = "btnCajasPendientes";
            this.btnCajasPendientes.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnCajasPendientes.Size = new System.Drawing.Size(169, 57);
            this.btnCajasPendientes.TabIndex = 3;
            this.btnCajasPendientes.Text = "Cajas Pendientes";
            this.btnCajasPendientes.Click += new System.EventHandler(this.btnCajasPendientes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ultima Actualización:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(162, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(117, 21);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "labelControl1";
            // 
            // btnActualizar
            // 
            this.btnActualizar.AllowFocus = false;
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnActualizar.Location = new System.Drawing.Point(19, 23);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnActualizar.Size = new System.Drawing.Size(137, 57);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.ActiveFilterString = "";
            this.pivotGridControl1.DataMember = "spPlaneadorMesaControl";
            this.pivotGridControl1.DataSource = this.sqlDataSource1;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldMov1,
            this.fieldNumPedido1,
            this.fieldPrioridad1,
            this.fieldFormaEnvio1,
            this.fieldCliente1,
            this.fieldClave1,
            this.fieldNombre1,
            this.fieldIdEstilo1,
            this.fieldAREA1,
            this.fieldporsurtir1,
            this.fieldsurtido1,
            this.porSurtirField,
            this.surtidoField});
            pivotGridFormatRule1.Measure = this.porSurtirField;
            pivotGridFormatRule1.Name = "completo";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.PredefinedName = "Green Fill, Green Text";
            formatConditionRuleValue1.Value1 = 0;
            pivotGridFormatRule1.Rule = formatConditionRuleValue1;
            pivotGridFormatRule1.Settings = formatRuleTotalTypeSettings1;
            pivotGridFormatRule2.Measure = this.porSurtirField;
            pivotGridFormatRule2.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[porsurtir] >= 1 And [surtido] >= [porsurtir]";
            formatConditionRuleExpression1.PredefinedName = "Yellow Fill, Yellow Text";
            pivotGridFormatRule2.Rule = formatConditionRuleExpression1;
            pivotGridFormatRule2.Settings = formatRuleTotalTypeSettings2;
            pivotGridFormatRule3.Measure = this.porSurtirField;
            pivotGridFormatRule3.Name = "iconos";
            formatConditionIconSet1.CategoryName = "Shapes";
            formatConditionIconSetIcon1.PredefinedName = "TrafficLights4_1.png";
            formatConditionIconSetIcon1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "TrafficLights4_2.png";
            formatConditionIconSetIcon2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "TrafficLights4_3.png";
            formatConditionIconSetIcon3.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            formatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon4.PredefinedName = "TrafficLights4_4.png";
            formatConditionIconSetIcon4.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            formatConditionIconSetIcon4.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon4);
            formatConditionIconSet1.Name = "TrafficLights4";
            formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            pivotGridFormatRule3.Rule = formatConditionRuleIconSet1;
            formatRuleTotalTypeSettings3.ApplyToCell = false;
            formatRuleTotalTypeSettings3.ApplyToCustomTotalCell = false;
            pivotGridFormatRule3.Settings = formatRuleTotalTypeSettings3;
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule1);
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule2);
            this.pivotGridControl1.FormatRules.Add(pivotGridFormatRule3);
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 103);
            this.pivotGridControl1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsMenu.EnableFormatRulesMenu = true;
            this.pivotGridControl1.OptionsPrint.MergeRowFieldValues = false;
            this.pivotGridControl1.OptionsView.GroupFieldsInCustomizationWindow = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowTotals = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(1342, 401);
            this.pivotGridControl1.TabIndex = 1;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "SAI_NETSUITE.Properties.Settings.INDAR_INACTIONWMSConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "spPlaneadorMesaControl";
            storedProcQuery1.StoredProcName = "spPlaneadorMesaControl";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // fieldMov1
            // 
            this.fieldMov1.AreaIndex = 0;
            this.fieldMov1.FieldName = "Mov";
            this.fieldMov1.Name = "fieldMov1";
            // 
            // fieldNumPedido1
            // 
            this.fieldNumPedido1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNumPedido1.AreaIndex = 3;
            this.fieldNumPedido1.FieldName = "NumPedido";
            this.fieldNumPedido1.Name = "fieldNumPedido1";
            // 
            // fieldPrioridad1
            // 
            this.fieldPrioridad1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPrioridad1.AreaIndex = 0;
            this.fieldPrioridad1.FieldName = "Prioridad";
            this.fieldPrioridad1.Name = "fieldPrioridad1";
            // 
            // fieldFormaEnvio1
            // 
            this.fieldFormaEnvio1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldFormaEnvio1.AreaIndex = 1;
            this.fieldFormaEnvio1.FieldName = "FormaEnvio";
            this.fieldFormaEnvio1.Name = "fieldFormaEnvio1";
            // 
            // fieldCliente1
            // 
            this.fieldCliente1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCliente1.AreaIndex = 2;
            this.fieldCliente1.FieldName = "Cliente";
            this.fieldCliente1.Name = "fieldCliente1";
            // 
            // fieldClave1
            // 
            this.fieldClave1.AreaIndex = 1;
            this.fieldClave1.FieldName = "Clave";
            this.fieldClave1.Name = "fieldClave1";
            // 
            // fieldNombre1
            // 
            this.fieldNombre1.AreaIndex = 2;
            this.fieldNombre1.FieldName = "Nombre";
            this.fieldNombre1.Name = "fieldNombre1";
            // 
            // fieldIdEstilo1
            // 
            this.fieldIdEstilo1.AreaIndex = 3;
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
            // fieldporsurtir1
            // 
            this.fieldporsurtir1.AreaIndex = 4;
            this.fieldporsurtir1.FieldName = "porsurtir";
            this.fieldporsurtir1.Name = "fieldporsurtir1";
            // 
            // fieldsurtido1
            // 
            this.fieldsurtido1.AreaIndex = 5;
            this.fieldsurtido1.FieldName = "surtido";
            this.fieldsurtido1.Name = "fieldsurtido1";
            // 
            // surtidoField
            // 
            this.surtidoField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.surtidoField.AreaIndex = 1;
            this.surtidoField.Caption = "Surtido";
            this.surtidoField.FieldName = "surtido";
            this.surtidoField.Name = "surtidoField";
            this.surtidoField.Options.ShowCustomTotals = false;
            this.surtidoField.Options.ShowGrandTotal = false;
            this.surtidoField.Options.ShowSummaryTypeName = true;
            this.surtidoField.Options.ShowValues = false;
            this.surtidoField.Width = 50;
            // 
            // Planeador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Planeador";
            this.Size = new System.Drawing.Size(1342, 504);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldMov1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNumPedido1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPrioridad1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldFormaEnvio1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldCliente1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldClave1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNombre1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldIdEstilo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAREA1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldporsurtir1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldsurtido1;
        private DevExpress.XtraPivotGrid.PivotGridField porSurtirField;
        private DevExpress.XtraPivotGrid.PivotGridField surtidoField;
        private DevExpress.XtraEditors.SimpleButton btnCajasPendientes;
    }
}
