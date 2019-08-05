namespace SAI_NETSUITE.WMS.Slotting
{
    partial class caducables
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelVigencia = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelArticulo = new System.Windows.Forms.Label();
            this.btnAplicar = new DevExpress.XtraEditors.SimpleButton();
            this.toggleSwitch2 = new DevExpress.XtraEditors.ToggleSwitch();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.searArticulo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searArticulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelVigencia);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.labelArticulo);
            this.groupControl1.Controls.Add(this.btnAplicar);
            this.groupControl1.Controls.Add(this.toggleSwitch2);
            this.groupControl1.Controls.Add(this.toggleSwitch1);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.searArticulo);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1082, 105);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Articulo";
            // 
            // labelVigencia
            // 
            this.labelVigencia.AutoSize = true;
            this.labelVigencia.Location = new System.Drawing.Point(817, 38);
            this.labelVigencia.Name = "labelVigencia";
            this.labelVigencia.Size = new System.Drawing.Size(82, 17);
            this.labelVigencia.TabIndex = 7;
            this.labelVigencia.Text = "DiasVigencia";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(820, 58);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Mask.EditMask = "n0";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Size = new System.Drawing.Size(100, 22);
            this.textEdit1.TabIndex = 6;
            // 
            // labelArticulo
            // 
            this.labelArticulo.AutoSize = true;
            this.labelArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelArticulo.Location = new System.Drawing.Point(9, 80);
            this.labelArticulo.Name = "labelArticulo";
            this.labelArticulo.Size = new System.Drawing.Size(2, 19);
            this.labelArticulo.TabIndex = 5;
            // 
            // btnAplicar
            // 
            this.btnAplicar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAplicar.Location = new System.Drawing.Point(989, 54);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // toggleSwitch2
            // 
            this.toggleSwitch2.Location = new System.Drawing.Point(383, 71);
            this.toggleSwitch2.Name = "toggleSwitch2";
            this.toggleSwitch2.Properties.OffText = "FechaCaducidad";
            this.toggleSwitch2.Properties.OnText = "FechaElaboracion";
            this.toggleSwitch2.Size = new System.Drawing.Size(207, 26);
            this.toggleSwitch2.TabIndex = 3;
            this.toggleSwitch2.EditValueChanged += new System.EventHandler(this.toggleSwitch2_EditValueChanged);
            this.toggleSwitch2.DockChanged += new System.EventHandler(this.toggleSwitch2_DockChanged);
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(383, 39);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "No Caducable";
            this.toggleSwitch1.Properties.OnText = "Si Caducable";
            this.toggleSwitch1.Size = new System.Drawing.Size(207, 26);
            this.toggleSwitch1.TabIndex = 2;
            this.toggleSwitch1.EditValueChanged += new System.EventHandler(this.toggleSwitch1_EditValueChanged);
            this.toggleSwitch1.DockChanged += new System.EventHandler(this.toggleSwitch1_DockChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Articulo";
            // 
            // searArticulo
            // 
            this.searArticulo.Location = new System.Drawing.Point(6, 55);
            this.searArticulo.Name = "searArticulo";
            this.searArticulo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searArticulo.Properties.PopupView = this.searchLookUpEdit1View;
            this.searArticulo.Size = new System.Drawing.Size(247, 22);
            this.searArticulo.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.searArticulo, conditionValidationRule1);
            this.searArticulo.EditValueChanged += new System.EventHandler(this.searArticulo_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // caducables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "caducables";
            this.Size = new System.Drawing.Size(1089, 322);
            this.Load += new System.EventHandler(this.caducables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searArticulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnAplicar;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch2;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchLookUpEdit searArticulo;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.Windows.Forms.Label labelArticulo;
        private System.Windows.Forms.Label labelVigencia;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}
