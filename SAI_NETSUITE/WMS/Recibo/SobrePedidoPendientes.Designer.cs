namespace SAI_NETSUITE.WMS.Recibo
{
    partial class SobrePedidoPendientes
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SobrePedidoPendientes));
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadRecibida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaActualizado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODIGO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.FieldName = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 7;
            // 
            // colCantidadRecibida
            // 
            this.colCantidadRecibida.Caption = "CantidadRecibida";
            this.colCantidadRecibida.FieldName = "CantidadRecibida";
            this.colCantidadRecibida.Name = "colCantidadRecibida";
            this.colCantidadRecibida.Visible = true;
            this.colCantidadRecibida.VisibleIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 42);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1167, 492);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFechaActualizado,
            this.colMov,
            this.colMovId,
            this.colCODIGO,
            this.colProveedor,
            this.colClave,
            this.colCategoria,
            this.colCantidad,
            this.colCantidadRecibida});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colCantidad;
            gridFormatRule2.ColumnApplyTo = this.colCantidadRecibida;
            gridFormatRule2.Name = "verdeCompleto";
            formatConditionRuleExpression2.Expression = "Iif([Cantidad] = [CantidadRecibida], True, False)";
            formatConditionRuleExpression2.PredefinedName = "Green Fill, Green Text";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            // 
            // colFechaActualizado
            // 
            this.colFechaActualizado.Caption = "Fecha";
            this.colFechaActualizado.FieldName = "FechaActualizado";
            this.colFechaActualizado.Name = "colFechaActualizado";
            this.colFechaActualizado.Visible = true;
            this.colFechaActualizado.VisibleIndex = 0;
            // 
            // colMov
            // 
            this.colMov.Caption = "Mov";
            this.colMov.FieldName = "Mov";
            this.colMov.Name = "colMov";
            this.colMov.Visible = true;
            this.colMov.VisibleIndex = 1;
            // 
            // colMovId
            // 
            this.colMovId.Caption = "MovId";
            this.colMovId.FieldName = "MovId";
            this.colMovId.Name = "colMovId";
            this.colMovId.Visible = true;
            this.colMovId.VisibleIndex = 2;
            // 
            // colCODIGO
            // 
            this.colCODIGO.Caption = "CODIGO";
            this.colCODIGO.FieldName = "CODIGO";
            this.colCODIGO.Name = "colCODIGO";
            this.colCODIGO.Visible = true;
            this.colCODIGO.VisibleIndex = 3;
            // 
            // colProveedor
            // 
            this.colProveedor.Caption = "Proveedor";
            this.colProveedor.FieldName = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 4;
            // 
            // colClave
            // 
            this.colClave.Caption = "Clave";
            this.colClave.FieldName = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.Visible = true;
            this.colClave.VisibleIndex = 5;
            // 
            // colCategoria
            // 
            this.colCategoria.Caption = "Categoria";
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Visible = true;
            this.colCategoria.VisibleIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(21, 13);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Excel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // SobrePedidoPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl1);
            this.Name = "SobrePedidoPendientes";
            this.Size = new System.Drawing.Size(1167, 537);
            this.Load += new System.EventHandler(this.SobrePedidoPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaActualizado;
        private DevExpress.XtraGrid.Columns.GridColumn colMov;
        private DevExpress.XtraGrid.Columns.GridColumn colMovId;
        private DevExpress.XtraGrid.Columns.GridColumn colCODIGO;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadRecibida;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
