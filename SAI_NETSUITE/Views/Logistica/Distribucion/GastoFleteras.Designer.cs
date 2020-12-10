namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    partial class GastoFleteras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GastoFleteras));
            this.searchVendor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.COLENTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaqueteria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidNumeroGuia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroGuia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidPaqueteria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporteGuia = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFactura = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.btnRegistra = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargaXml = new DevExpress.XtraEditors.SimpleButton();
            this.labelPath = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.searchVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteGuia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchVendor
            // 
            this.searchVendor.Location = new System.Drawing.Point(16, 38);
            this.searchVendor.Name = "searchVendor";
            this.searchVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchVendor.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchVendor.Size = new System.Drawing.Size(361, 22);
            this.searchVendor.TabIndex = 1;
            this.searchVendor.EditValueChanged += new System.EventHandler(this.searchVendor_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.COLENTITY,
            this.colPaqueteria});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "Nombre";
            this.colName.FieldName = "NAME";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // COLENTITY
            // 
            this.COLENTITY.Caption = "ENTITY ID";
            this.COLENTITY.FieldName = "ENTITY_ID";
            this.COLENTITY.Name = "COLENTITY";
            this.COLENTITY.Visible = true;
            this.COLENTITY.VisibleIndex = 1;
            // 
            // colPaqueteria
            // 
            this.colPaqueteria.Caption = "IDpaqueteria";
            this.colPaqueteria.FieldName = "PAQUETERIA_DISTRIBUCION_ID";
            this.colPaqueteria.Name = "colPaqueteria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Acreedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "CENTRO COSTOS:";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(150, 162);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(224, 22);
            this.textEdit1.TabIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(399, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(567, 557);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidNumeroGuia,
            this.colNumeroGuia,
            this.colidPaqueteria,
            this.colImporteTotal,
            this.colFecha});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // colidNumeroGuia
            // 
            this.colidNumeroGuia.Caption = "idNumeroGuia";
            this.colidNumeroGuia.FieldName = "idNumeroGuia";
            this.colidNumeroGuia.Name = "colidNumeroGuia";
            // 
            // colNumeroGuia
            // 
            this.colNumeroGuia.Caption = "NumeroGuia";
            this.colNumeroGuia.FieldName = "NumeroGuia";
            this.colNumeroGuia.Name = "colNumeroGuia";
            this.colNumeroGuia.Visible = true;
            this.colNumeroGuia.VisibleIndex = 1;
            // 
            // colidPaqueteria
            // 
            this.colidPaqueteria.Caption = "idPaqueteria";
            this.colidPaqueteria.FieldName = "idPaqueteria";
            this.colidPaqueteria.Name = "colidPaqueteria";
            // 
            // colImporteTotal
            // 
            this.colImporteTotal.Caption = "ImporteTotal";
            this.colImporteTotal.DisplayFormat.FormatString = "c";
            this.colImporteTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteTotal.FieldName = "ImporteTotal";
            this.colImporteTotal.Name = "colImporteTotal";
            this.colImporteTotal.Visible = true;
            this.colImporteTotal.VisibleIndex = 2;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "Importe Guias:";
            // 
            // txtImporteGuia
            // 
            this.txtImporteGuia.Location = new System.Drawing.Point(172, 342);
            this.txtImporteGuia.Name = "txtImporteGuia";
            this.txtImporteGuia.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteGuia.Properties.Appearance.Options.UseFont = true;
            this.txtImporteGuia.Properties.ReadOnly = true;
            this.txtImporteGuia.Size = new System.Drawing.Size(205, 28);
            this.txtImporteGuia.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Importe Factura:";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(172, 278);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura.Properties.Appearance.Options.UseFont = true;
            this.txtFactura.Properties.Mask.EditMask = "c";
            this.txtFactura.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFactura.Size = new System.Drawing.Size(204, 28);
            this.txtFactura.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "Num. Factura:";
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(173, 222);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Properties.Mask.EditMask = "c";
            this.textEdit3.Size = new System.Drawing.Size(204, 28);
            this.textEdit3.TabIndex = 16;
            // 
            // btnRegistra
            // 
            this.btnRegistra.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnRegistra.Appearance.BorderColor = System.Drawing.Color.White;
            this.btnRegistra.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistra.Appearance.Options.UseBackColor = true;
            this.btnRegistra.Appearance.Options.UseBorderColor = true;
            this.btnRegistra.Appearance.Options.UseFont = true;
            this.btnRegistra.AppearanceHovered.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegistra.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnRegistra.AppearanceHovered.Options.UseBackColor = true;
            this.btnRegistra.AppearanceHovered.Options.UseForeColor = true;
            this.btnRegistra.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnRegistra.Enabled = false;
            this.btnRegistra.Location = new System.Drawing.Point(7, 428);
            this.btnRegistra.Name = "btnRegistra";
            this.btnRegistra.Size = new System.Drawing.Size(370, 43);
            this.btnRegistra.TabIndex = 18;
            this.btnRegistra.Text = "Registrar en Netsuite";
            this.btnRegistra.Click += new System.EventHandler(this.btnRegistra_Click);
            // 
            // btnCargaXml
            // 
            this.btnCargaXml.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCargaXml.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.textbox_16x16;
            this.btnCargaXml.Location = new System.Drawing.Point(16, 67);
            this.btnCargaXml.Name = "btnCargaXml";
            this.btnCargaXml.Size = new System.Drawing.Size(361, 23);
            this.btnCargaXml.TabIndex = 19;
            this.btnCargaXml.Text = "carga XML";
            this.btnCargaXml.Click += new System.EventHandler(this.btnCargaXml_Click);
            // 
            // labelPath
            // 
            this.behaviorManager1.SetBehaviors(this.labelPath, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.Behaviors.Common.FileIconBehavior.Create(typeof(DevExpress.XtraEditors.Behaviors.FileIconBehaviorSourceForLabelControl), DevExpress.Utils.Behaviors.Common.FileIconSize.Small, ((System.Drawing.Image)(resources.GetObject("labelPath.Behaviors"))), global::SAI_NETSUITE.Properties.Resources.Error_icon)))});
            this.labelPath.Location = new System.Drawing.Point(16, 97);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(28, 16);
            this.labelPath.TabIndex = 20;
            this.labelPath.Text = "ruta:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GastoFleteras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.btnCargaXml);
            this.Controls.Add(this.btnRegistra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImporteGuia);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchVendor);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GastoFleteras";
            this.Size = new System.Drawing.Size(969, 563);
            this.Load += new System.EventHandler(this.GastoFleteras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteGuia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SearchLookUpEdit searchVendor;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn COLENTITY;
        private DevExpress.XtraGrid.Columns.GridColumn colPaqueteria;
        private DevExpress.XtraGrid.Columns.GridColumn colidNumeroGuia;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroGuia;
        private DevExpress.XtraGrid.Columns.GridColumn colidPaqueteria;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtImporteGuia;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtFactura;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.SimpleButton btnRegistra;
        private DevExpress.XtraEditors.SimpleButton btnCargaXml;
        private DevExpress.XtraEditors.LabelControl labelPath;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
