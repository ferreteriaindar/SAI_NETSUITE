﻿namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    partial class desembarque
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colrevisado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumEmbarque = new DevExpress.XtraEditors.TextEdit();
            this.btnEscanea = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEscaneaFac = new DevExpress.XtraEditors.TextEdit();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.btnDesembarcar = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscaEmbarque = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmbarque = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdembarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colentity_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltransito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comboEstado = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.COLformaenvio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomentario = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumEmbarque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscaneaFac.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmbarque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // colrevisado
            // 
            this.colrevisado.Caption = "Revisado";
            this.colrevisado.FieldName = "revisado";
            this.colrevisado.Name = "colrevisado";
            this.colrevisado.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.btnEscanea);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtEscaneaFac);
            this.groupControl1.Controls.Add(this.labelUbicacion);
            this.groupControl1.Controls.Add(this.separatorControl1);
            this.groupControl1.Controls.Add(this.btnDesembarcar);
            this.groupControl1.Controls.Add(this.btnBuscaEmbarque);
            this.groupControl1.Controls.Add(this.txtEmbarque);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 571);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Controles";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnImprimir);
            this.groupControl3.Controls.Add(this.label4);
            this.groupControl3.Controls.Add(this.txtNumEmbarque);
            this.groupControl3.Location = new System.Drawing.Point(5, 280);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(187, 109);
            this.groupControl3.TabIndex = 10;
            this.groupControl3.Text = "Re-Imprimir Embarque";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Appearance.Options.UseFont = true;
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnImprimir.Location = new System.Drawing.Point(52, 75);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Num. Embarque";
            // 
            // txtNumEmbarque
            // 
            this.txtNumEmbarque.Location = new System.Drawing.Point(5, 47);
            this.txtNumEmbarque.Name = "txtNumEmbarque";
            this.txtNumEmbarque.Properties.Mask.EditMask = "n0";
            this.txtNumEmbarque.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumEmbarque.Size = new System.Drawing.Size(177, 22);
            this.txtNumEmbarque.TabIndex = 0;
            // 
            // btnEscanea
            // 
            this.btnEscanea.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEscanea.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.search_16x16;
            this.btnEscanea.Location = new System.Drawing.Point(8, 205);
            this.btnEscanea.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnEscanea.LookAndFeel.UseWindowsXPTheme = true;
            this.btnEscanea.Name = "btnEscanea";
            this.btnEscanea.Size = new System.Drawing.Size(187, 23);
            this.btnEscanea.TabIndex = 9;
            this.btnEscanea.Text = "Escanea";
            this.btnEscanea.Click += new System.EventHandler(this.btnEscanea_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Escanea Factura";
            // 
            // txtEscaneaFac
            // 
            this.txtEscaneaFac.Location = new System.Drawing.Point(8, 177);
            this.txtEscaneaFac.Name = "txtEscaneaFac";
            this.txtEscaneaFac.Size = new System.Drawing.Size(187, 22);
            this.txtEscaneaFac.TabIndex = 7;
            this.txtEscaneaFac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEscaneaFac_KeyPress);
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.Location = new System.Drawing.Point(84, 27);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(42, 17);
            this.labelUbicacion.TabIndex = 6;
            this.labelUbicacion.Text = "label3";
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(5, 131);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(195, 23);
            this.separatorControl1.TabIndex = 5;
            // 
            // btnDesembarcar
            // 
            this.btnDesembarcar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDesembarcar.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.productshipments_16x16;
            this.btnDesembarcar.Location = new System.Drawing.Point(5, 251);
            this.btnDesembarcar.Name = "btnDesembarcar";
            this.btnDesembarcar.Size = new System.Drawing.Size(187, 23);
            this.btnDesembarcar.TabIndex = 4;
            this.btnDesembarcar.Text = "Desembarcar";
            this.btnDesembarcar.Click += new System.EventHandler(this.btnDesembarcar_Click);
            // 
            // btnBuscaEmbarque
            // 
            this.btnBuscaEmbarque.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnBuscaEmbarque.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.search_16x16;
            this.btnBuscaEmbarque.Location = new System.Drawing.Point(8, 102);
            this.btnBuscaEmbarque.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnBuscaEmbarque.LookAndFeel.UseWindowsXPTheme = true;
            this.btnBuscaEmbarque.Name = "btnBuscaEmbarque";
            this.btnBuscaEmbarque.Size = new System.Drawing.Size(187, 23);
            this.btnBuscaEmbarque.TabIndex = 3;
            this.btnBuscaEmbarque.Text = "Buscar";
            this.btnBuscaEmbarque.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtEmbarque
            // 
            this.txtEmbarque.Location = new System.Drawing.Point(8, 74);
            this.txtEmbarque.Name = "txtEmbarque";
            this.txtEmbarque.Size = new System.Drawing.Size(187, 22);
            this.txtEmbarque.TabIndex = 2;
            this.txtEmbarque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmbarque_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "UBICACION:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Embarque";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(209, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.comboEstado});
            this.gridControl1.Size = new System.Drawing.Size(800, 571);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdembarque,
            this.colfactura,
            this.colentity_id,
            this.coltransito,
            this.COLformaenvio,
            this.colrevisado,
            this.colcomentario});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colrevisado;
            gridFormatRule1.ColumnApplyTo = this.colrevisado;
            gridFormatRule1.Name = "formatOK";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.PredefinedName = "Green Fill, Green Text";
            formatConditionRuleValue1.Value1 = "1";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colIdembarque
            // 
            this.colIdembarque.Caption = "idEmbarque";
            this.colIdembarque.FieldName = "idembarque";
            this.colIdembarque.Name = "colIdembarque";
            // 
            // colfactura
            // 
            this.colfactura.Caption = "Factura";
            this.colfactura.FieldName = "factura";
            this.colfactura.Name = "colfactura";
            this.colfactura.Visible = true;
            this.colfactura.VisibleIndex = 1;
            // 
            // colentity_id
            // 
            this.colentity_id.Caption = "entity_id";
            this.colentity_id.FieldName = "entity_id";
            this.colentity_id.Name = "colentity_id";
            this.colentity_id.Visible = true;
            this.colentity_id.VisibleIndex = 2;
            // 
            // coltransito
            // 
            this.coltransito.Caption = "Estado";
            this.coltransito.ColumnEdit = this.comboEstado;
            this.coltransito.FieldName = "estado";
            this.coltransito.Name = "coltransito";
            this.coltransito.Visible = true;
            this.coltransito.VisibleIndex = 3;
            // 
            // comboEstado
            // 
            this.comboEstado.AutoHeight = false;
            this.comboEstado.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboEstado.Name = "comboEstado";
            // 
            // COLformaenvio
            // 
            this.COLformaenvio.Caption = "FormaEnvio";
            this.COLformaenvio.FieldName = "formaenvio";
            this.COLformaenvio.Name = "COLformaenvio";
            this.COLformaenvio.Visible = true;
            this.COLformaenvio.VisibleIndex = 4;
            // 
            // colcomentario
            // 
            this.colcomentario.Caption = "Comentario";
            this.colcomentario.FieldName = "comentario";
            this.colcomentario.Name = "colcomentario";
            this.colcomentario.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colcomentario.Visible = true;
            this.colcomentario.VisibleIndex = 5;
            // 
            // desembarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "desembarque";
            this.Size = new System.Drawing.Size(1012, 577);
            this.Load += new System.EventHandler(this.desembarque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumEmbarque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscaneaFac.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmbarque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboEstado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscaEmbarque;
        private DevExpress.XtraEditors.TextEdit txtEmbarque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnDesembarcar;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private System.Windows.Forms.Label labelUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colIdembarque;
        private DevExpress.XtraGrid.Columns.GridColumn colfactura;
        private DevExpress.XtraGrid.Columns.GridColumn colentity_id;
        private DevExpress.XtraGrid.Columns.GridColumn coltransito;
        private DevExpress.XtraGrid.Columns.GridColumn COLformaenvio;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtEscaneaFac;
        private DevExpress.XtraEditors.SimpleButton btnEscanea;
        private DevExpress.XtraGrid.Columns.GridColumn colrevisado;
        private DevExpress.XtraGrid.Columns.GridColumn colcomentario;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox comboEstado;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtNumEmbarque;
    }
}
