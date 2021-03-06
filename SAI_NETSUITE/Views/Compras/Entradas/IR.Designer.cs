﻿namespace SAI_NETSUITE.Views.Compras.Entradas
{
    partial class IR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IR));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.txtReimprimir = new DevExpress.XtraEditors.TextEdit();
            this.btnEnviar = new DevExpress.XtraEditors.SimpleButton();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.BTNImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidReceipt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVendor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReimprimir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colCategoria
            // 
            this.colCategoria.Caption = "Categoria";
            this.colCategoria.FieldName = "LIST_ITEM_NAME";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Visible = true;
            this.colCategoria.VisibleIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnEliminar);
            this.groupControl1.Controls.Add(this.txtReimprimir);
            this.groupControl1.Controls.Add(this.btnEnviar);
            this.groupControl1.Controls.Add(this.btnActualizar);
            this.groupControl1.Controls.Add(this.BTNImprimir);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1291, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Controles";
            // 
            // btnEliminar
            // 
            this.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEliminar.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.Error_icon;
            this.btnEliminar.Location = new System.Drawing.Point(957, 29);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 65);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtReimprimir
            // 
            this.txtReimprimir.Location = new System.Drawing.Point(27, 66);
            this.txtReimprimir.Name = "txtReimprimir";
            this.txtReimprimir.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReimprimir.Properties.Appearance.Options.UseFont = true;
            this.txtReimprimir.Properties.Mask.EditMask = "n0";
            this.txtReimprimir.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtReimprimir.Size = new System.Drawing.Size(104, 28);
            this.txtReimprimir.TabIndex = 3;
            // 
            // btnEnviar
            // 
            this.btnEnviar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEnviar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.ImageOptions.Image")));
            this.btnEnviar.Location = new System.Drawing.Point(1162, 29);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(124, 67);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar WMS";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(157, 28);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(111, 31);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // BTNImprimir
            // 
            this.BTNImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.BTNImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTNImprimir.ImageOptions.Image")));
            this.BTNImprimir.Location = new System.Drawing.Point(27, 29);
            this.BTNImprimir.Name = "BTNImprimir";
            this.BTNImprimir.Size = new System.Drawing.Size(104, 31);
            this.BTNImprimir.TabIndex = 0;
            this.BTNImprimir.Text = "Reimprimir";
            this.BTNImprimir.Click += new System.EventHandler(this.BTNImprimir_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(4, 110);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1290, 424);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIR,
            this.colType,
            this.colidReceipt,
            this.colLocation,
            this.colVendor,
            this.colitemid,
            this.colCantidad,
            this.colCategoria});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colCategoria;
            gridFormatRule1.Name = "insumos";
            formatConditionRuleExpression1.Expression = "Iif([LIST_ITEM_NAME] = \'INSUMOS\', True, False)";
            formatConditionRuleExpression1.PredefinedName = "Green Fill";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colVendor, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colIR
            // 
            this.colIR.Caption = "ID";
            this.colIR.FieldName = "id";
            this.colIR.Name = "colIR";
            // 
            // colType
            // 
            this.colType.Caption = "TIPO";
            this.colType.FieldName = "type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            // 
            // colidReceipt
            // 
            this.colidReceipt.Caption = "Numero";
            this.colidReceipt.FieldName = "idReceipt";
            this.colidReceipt.Name = "colidReceipt";
            this.colidReceipt.Visible = true;
            this.colidReceipt.VisibleIndex = 2;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Almacen";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 3;
            // 
            // colVendor
            // 
            this.colVendor.Caption = "Proveedor";
            this.colVendor.FieldName = "Vendor";
            this.colVendor.Name = "colVendor";
            this.colVendor.Visible = true;
            this.colVendor.VisibleIndex = 0;
            // 
            // colitemid
            // 
            this.colitemid.Caption = "Articulo";
            this.colitemid.FieldName = "itemid";
            this.colitemid.Name = "colitemid";
            this.colitemid.Visible = true;
            this.colitemid.VisibleIndex = 4;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.FieldName = "itemquantity";
            this.colCantidad.Name = "colCantidad";
            // 
            // IR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "IR";
            this.Size = new System.Drawing.Size(1297, 537);
            this.Load += new System.EventHandler(this.IR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtReimprimir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnEnviar;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.SimpleButton BTNImprimir;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colIR;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colidReceipt;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colVendor;
        private DevExpress.XtraGrid.Columns.GridColumn colitemid;
        private DevExpress.XtraEditors.TextEdit txtReimprimir;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraEditors.SimpleButton btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
    }
}
