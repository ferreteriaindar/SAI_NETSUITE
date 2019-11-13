namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    partial class ReimprimirFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReimprimirFactura));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFactura = new DevExpress.XtraEditors.TextEdit();
            this.combotipo = new System.Windows.Forms.ComboBox();
            this.txtPedido = new DevExpress.XtraEditors.TextEdit();
            this.btnFactura = new DevExpress.XtraEditors.SimpleButton();
            this.btnPacking = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.dxValidationProvider2 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPedido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SAI_NETSUITE.Properties.Resources.pdf;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 71);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(224, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.pictureEdit1.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.Appearance.Image")));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.Appearance.Options.UseImage = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(63, 71);
            this.pictureEdit1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Packing\r\nList";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Factura";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(4, 82);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Properties.Mask.EditMask = "\\d+";
            this.txtFactura.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFactura.Properties.NullText = "Num Factura";
            this.txtFactura.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtFactura.Size = new System.Drawing.Size(141, 22);
            this.txtFactura.TabIndex = 4;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtFactura, conditionValidationRule3);
            // 
            // combotipo
            // 
            this.combotipo.FormattingEnabled = true;
            this.combotipo.Items.AddRange(new object[] {
            "Local",
            "Foraneo"});
            this.combotipo.Location = new System.Drawing.Point(177, 110);
            this.combotipo.Name = "combotipo";
            this.combotipo.Size = new System.Drawing.Size(141, 24);
            this.combotipo.TabIndex = 8;
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(177, 81);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Properties.NullText = "Num Pedido/Cons";
            this.txtPedido.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPedido.Size = new System.Drawing.Size(141, 22);
            this.txtPedido.TabIndex = 7;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider2.SetValidationRule(this.txtPedido, conditionValidationRule1);
            // 
            // btnFactura
            // 
            this.btnFactura.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnFactura.Appearance.Options.UseBackColor = true;
            this.btnFactura.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnFactura.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnFactura.Location = new System.Drawing.Point(4, 111);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(141, 23);
            this.btnFactura.TabIndex = 9;
            this.btnFactura.Text = "Imprimir";
            this.btnFactura.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnPacking
            // 
            this.btnPacking.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnPacking.Appearance.Options.UseBackColor = true;
            this.btnPacking.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPacking.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnPacking.Location = new System.Drawing.Point(177, 140);
            this.btnPacking.Name = "btnPacking";
            this.btnPacking.Size = new System.Drawing.Size(141, 23);
            this.btnPacking.TabIndex = 10;
            this.btnPacking.Text = "Imprimir";
            this.btnPacking.Click += new System.EventHandler(this.btnPacking_Click);
            // 
            // ReimprimirFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPacking);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.combotipo);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ReimprimirFactura";
            this.Size = new System.Drawing.Size(1123, 524);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPedido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtFactura;
        private System.Windows.Forms.ComboBox combotipo;
        private DevExpress.XtraEditors.TextEdit txtPedido;
        private DevExpress.XtraEditors.SimpleButton btnFactura;
        private DevExpress.XtraEditors.SimpleButton btnPacking;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider2;
    }
}
