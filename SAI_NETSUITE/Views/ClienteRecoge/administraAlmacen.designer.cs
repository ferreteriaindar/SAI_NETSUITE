namespace SAI_NETSUITE.Views.ClienteRecoge
{
    partial class administraAlmacen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNuevaFormaEnvio = new System.Windows.Forms.Label();
            this.labelFormaenvio = new System.Windows.Forms.Label();
            this.txtFormaEnvioActual = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCambiar = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtFactura = new DevExpress.XtraEditors.TextEdit();
            this.validadorCombo = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.validadorOpcion = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.comboOpcion = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookformaenvio = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.formaenvio = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validadorCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validadorOpcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboOpcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookformaenvio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factura";
            // 
            // labelNuevaFormaEnvio
            // 
            this.labelNuevaFormaEnvio.AutoSize = true;
            this.labelNuevaFormaEnvio.Location = new System.Drawing.Point(16, 229);
            this.labelNuevaFormaEnvio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNuevaFormaEnvio.Name = "labelNuevaFormaEnvio";
            this.labelNuevaFormaEnvio.Size = new System.Drawing.Size(132, 17);
            this.labelNuevaFormaEnvio.TabIndex = 3;
            this.labelNuevaFormaEnvio.Text = "Nueva Forma Envio";
            this.labelNuevaFormaEnvio.Visible = false;
            // 
            // labelFormaenvio
            // 
            this.labelFormaenvio.AutoSize = true;
            this.labelFormaenvio.Location = new System.Drawing.Point(16, 170);
            this.labelFormaenvio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFormaenvio.Name = "labelFormaenvio";
            this.labelFormaenvio.Size = new System.Drawing.Size(83, 17);
            this.labelFormaenvio.TabIndex = 4;
            this.labelFormaenvio.Text = "FormaEnvio";
            this.labelFormaenvio.Visible = false;
            // 
            // txtFormaEnvioActual
            // 
            this.txtFormaEnvioActual.Location = new System.Drawing.Point(20, 190);
            this.txtFormaEnvioActual.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormaEnvioActual.Name = "txtFormaEnvioActual";
            this.txtFormaEnvioActual.ReadOnly = true;
            this.txtFormaEnvioActual.Size = new System.Drawing.Size(199, 22);
            this.txtFormaEnvioActual.TabIndex = 5;
            this.txtFormaEnvioActual.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Opcion";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscar.Location = new System.Drawing.Point(63, 121);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(63, 294);
            this.btnCambiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(100, 28);
            this.btnCambiar.TabIndex = 9;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.Visible = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(20, 37);
            this.txtFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(200, 22);
            this.txtFactura.TabIndex = 10;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.User9;
            this.dxValidationProvider1.SetValidationRule(this.txtFactura, conditionValidationRule1);
            // 
            // comboOpcion
            // 
            this.comboOpcion.Location = new System.Drawing.Point(16, 89);
            this.comboOpcion.Margin = new System.Windows.Forms.Padding(4);
            this.comboOpcion.Name = "comboOpcion";
            this.comboOpcion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboOpcion.Properties.Items.AddRange(new object[] {
            "Cambiar Forma Envio",
            "Eliminar Factura"});
            this.comboOpcion.Size = new System.Drawing.Size(204, 22);
            this.comboOpcion.TabIndex = 12;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.User9;
            this.validadorOpcion.SetValidationRule(this.comboOpcion, conditionValidationRule2);
            // 
            // lookformaenvio
            // 
            this.lookformaenvio.Location = new System.Drawing.Point(15, 249);
            this.lookformaenvio.Margin = new System.Windows.Forms.Padding(4);
            this.lookformaenvio.Name = "lookformaenvio";
            this.lookformaenvio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookformaenvio.Properties.DisplayMember = "LIST_ITEM_NAME";
            this.lookformaenvio.Properties.PopupView = this.searchLookUpEdit1View;
            this.lookformaenvio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookformaenvio.Properties.ValueMember = "LIST_ID";
            this.lookformaenvio.Size = new System.Drawing.Size(205, 22);
            this.lookformaenvio.TabIndex = 11;
            this.lookformaenvio.EditValueChanged += new System.EventHandler(this.comboOpcion_SelectedIndexChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.formaenvio});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "gridColumn1";
            this.colId.FieldName = "LIST_ID";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // formaenvio
            // 
            this.formaenvio.Caption = "FORMAENVIO";
            this.formaenvio.FieldName = "LIST_ITEM_NAME";
            this.formaenvio.Name = "formaenvio";
            this.formaenvio.Visible = true;
            this.formaenvio.VisibleIndex = 1;
            // 
            // administraAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 361);
            this.Controls.Add(this.comboOpcion);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFormaEnvioActual);
            this.Controls.Add(this.labelFormaenvio);
            this.Controls.Add(this.labelNuevaFormaEnvio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookformaenvio);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "administraAlmacen";
            this.Text = "administraAlmacen";
            this.Load += new System.EventHandler(this.administraAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validadorCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validadorOpcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboOpcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookformaenvio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNuevaFormaEnvio;
        private System.Windows.Forms.Label labelFormaenvio;
        private System.Windows.Forms.TextBox txtFormaEnvioActual;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.SimpleButton btnCambiar;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit txtFactura;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider validadorCombo;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider validadorOpcion;
        private DevExpress.XtraEditors.ComboBoxEdit comboOpcion;
        private DevExpress.XtraEditors.SearchLookUpEdit lookformaenvio;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn formaenvio;
    }
}