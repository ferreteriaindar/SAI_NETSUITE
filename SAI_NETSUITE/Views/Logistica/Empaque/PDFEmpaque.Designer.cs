namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    partial class PDFEmpaque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFEmpaque));
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnRecargar = new DevExpress.XtraEditors.SimpleButton();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTranId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltranid2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_ITEM_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Appearance.Image = global::SAI_NETSUITE.Properties.Resources.pdf;
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Caption.Appearance.Image = global::SAI_NETSUITE.Properties.Resources.pdf;
            this.repositoryItemPictureEdit1.Caption.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnRecargar);
            this.groupControl1.Controls.Add(this.btnImprimir);
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1345, 71);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Controles";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // btnRecargar
            // 
            this.btnRecargar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnRecargar.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.pdf;
            this.btnRecargar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRecargar.ImageOptions.SvgImage")));
            this.btnRecargar.Location = new System.Drawing.Point(10, 28);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(133, 38);
            this.btnRecargar.TabIndex = 1;
            this.btnRecargar.Text = "Imprimir";
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnImprimir.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.pdf;
            this.btnImprimir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImprimir.ImageOptions.SvgImage")));
            this.btnImprimir.Location = new System.Drawing.Point(1176, 28);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(133, 38);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(2, 79);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1345, 436);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTranId,
            this.coltranid2,
            this.colName,
            this.colLIST_ITEM_NAME});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // colTranId
            // 
            this.colTranId.Caption = "Factura";
            this.colTranId.FieldName = "TranId";
            this.colTranId.Name = "colTranId";
            this.colTranId.Visible = true;
            this.colTranId.VisibleIndex = 1;
            // 
            // coltranid2
            // 
            this.coltranid2.Caption = "Pedido";
            this.coltranid2.FieldName = "pedido";
            this.coltranid2.Name = "coltranid2";
            this.coltranid2.Visible = true;
            this.coltranid2.VisibleIndex = 2;
            // 
            // colName
            // 
            this.colName.Caption = "Cliente";
            this.colName.FieldName = "NAME";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            // 
            // colLIST_ITEM_NAME
            // 
            this.colLIST_ITEM_NAME.Caption = "FormaEnvio";
            this.colLIST_ITEM_NAME.FieldName = "LIST_ITEM_NAME";
            this.colLIST_ITEM_NAME.Name = "colLIST_ITEM_NAME";
            this.colLIST_ITEM_NAME.Visible = true;
            this.colLIST_ITEM_NAME.VisibleIndex = 4;
            // 
            // PDFEmpaque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 517);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "PDFEmpaque";
            this.Text = "PDFEmpaque";
            this.Load += new System.EventHandler(this.PDFEmpaque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTranId;
        private DevExpress.XtraGrid.Columns.GridColumn coltranid2;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_ITEM_NAME;
        private DevExpress.XtraEditors.SimpleButton btnRecargar;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
    }
}