namespace SAI_NETSUITE.WMS.administracion
{
    partial class bloquearPedido
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bloquearPedido));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.comboAccion = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccion = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.COLIdOrdenEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormaEnvio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrioridad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.colburo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBloqueado = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboAccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(4, 81);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1035, 453);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.COLIdOrdenEmbarque,
            this.colClave,
            this.colMov,
            this.colNumPedido,
            this.colFormaEnvio,
            this.colPrioridad,
            this.colNombre,
            this.colburo,
            this.colBloqueado});
            gridFormatRule1.Column = this.colBloqueado;
            gridFormatRule1.ColumnApplyTo = this.colBloqueado;
            gridFormatRule1.Name = "bloqueado";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "BLOQUEADO";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnAccion);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.comboAccion);
            this.groupControl1.Location = new System.Drawing.Point(4, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1035, 77);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Opciones";
            // 
            // comboAccion
            // 
            this.comboAccion.EditValue = "";
            this.comboAccion.Location = new System.Drawing.Point(5, 50);
            this.comboAccion.Name = "comboAccion";
            this.comboAccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboAccion.Properties.Items.AddRange(new object[] {
            "BLOQUEAR",
            "LIBERAR"});
            this.comboAccion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboAccion.Size = new System.Drawing.Size(192, 22);
            this.comboAccion.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.comboAccion, conditionValidationRule1);
            this.comboAccion.SelectedIndexChanged += new System.EventHandler(this.comboAccion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Acción";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAccion
            // 
            this.btnAccion.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAccion.Image = ((System.Drawing.Image)(resources.GetObject("btnAccion.Image")));
            this.btnAccion.Location = new System.Drawing.Point(203, 49);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(157, 23);
            this.btnAccion.TabIndex = 2;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(389, 49);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "deseleccionar";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // COLIdOrdenEmbarque
            // 
            this.COLIdOrdenEmbarque.Caption = "idEmbarque";
            this.COLIdOrdenEmbarque.FieldName = "IdOrdenEmbarque";
            this.COLIdOrdenEmbarque.Name = "COLIdOrdenEmbarque";
            // 
            // colClave
            // 
            this.colClave.Caption = "Cliente";
            this.colClave.FieldName = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.Visible = true;
            this.colClave.VisibleIndex = 1;
            // 
            // colMov
            // 
            this.colMov.Caption = "Mov";
            this.colMov.FieldName = "Mov";
            this.colMov.Name = "colMov";
            this.colMov.Visible = true;
            this.colMov.VisibleIndex = 2;
            // 
            // colNumPedido
            // 
            this.colNumPedido.Caption = "NumPedido";
            this.colNumPedido.FieldName = "NumPedido";
            this.colNumPedido.Name = "colNumPedido";
            this.colNumPedido.Visible = true;
            this.colNumPedido.VisibleIndex = 3;
            // 
            // colFormaEnvio
            // 
            this.colFormaEnvio.Caption = "FormaEnvio";
            this.colFormaEnvio.FieldName = "FormaEnvio";
            this.colFormaEnvio.Name = "colFormaEnvio";
            this.colFormaEnvio.Visible = true;
            this.colFormaEnvio.VisibleIndex = 4;
            // 
            // colPrioridad
            // 
            this.colPrioridad.Caption = "Prioridad";
            this.colPrioridad.FieldName = "Prioridad";
            this.colPrioridad.Name = "colPrioridad";
            this.colPrioridad.Visible = true;
            this.colPrioridad.VisibleIndex = 5;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Estatus PEDIDO";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 6;
            // 
            // colburo
            // 
            this.colburo.Caption = "En Buró";
            this.colburo.FieldName = "buro";
            this.colburo.Name = "colburo";
            // 
            // colBloqueado
            // 
            this.colBloqueado.Caption = "BLOQUEADO PARA SURTIR";
            this.colBloqueado.FieldName = "colBloqueado";
            this.colBloqueado.Name = "colBloqueado";
            this.colBloqueado.UnboundExpression = "Iif([buro] = 0, \'LIBERADO\', \'BLOQUEADO\')";
            this.colBloqueado.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBloqueado.Visible = true;
            this.colBloqueado.VisibleIndex = 7;
            // 
            // bloquearPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "bloquearPedido";
            this.Size = new System.Drawing.Size(1042, 537);
            this.Load += new System.EventHandler(this.bloquearPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboAccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit comboAccion;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnAccion;
        private DevExpress.XtraGrid.Columns.GridColumn COLIdOrdenEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colMov;
        private DevExpress.XtraGrid.Columns.GridColumn colNumPedido;
        private DevExpress.XtraGrid.Columns.GridColumn colFormaEnvio;
        private DevExpress.XtraGrid.Columns.GridColumn colPrioridad;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colburo;
        private DevExpress.XtraGrid.Columns.GridColumn colBloqueado;
    }
}
