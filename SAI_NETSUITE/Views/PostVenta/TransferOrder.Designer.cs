namespace SAI_NETSUITE.Views.PostVenta
{
    partial class TransferOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferOrder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.txtImprimir = new DevExpress.XtraEditors.TextEdit();
            this.btnWMS = new DevExpress.XtraEditors.SimpleButton();
            this.btnActualiza = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colbaserecordtype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltranid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImprimir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Controls.Add(this.txtImprimir);
            this.groupBox1.Controls.Add(this.btnWMS);
            this.groupBox1.Controls.Add(this.btnActualiza);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1249, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btnImprimir
            // 
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(425, 30);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(122, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtImprimir
            // 
            this.txtImprimir.Location = new System.Drawing.Point(309, 31);
            this.txtImprimir.Name = "txtImprimir";
            this.txtImprimir.Properties.Mask.EditMask = "f0";
            this.txtImprimir.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImprimir.Size = new System.Drawing.Size(100, 22);
            this.txtImprimir.TabIndex = 2;
            // 
            // btnWMS
            // 
            this.btnWMS.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnWMS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWMS.ImageOptions.Image")));
            this.btnWMS.Location = new System.Drawing.Point(132, 31);
            this.btnWMS.Name = "btnWMS";
            this.btnWMS.Size = new System.Drawing.Size(122, 23);
            this.btnWMS.TabIndex = 1;
            this.btnWMS.Text = "Enviar WMS";
            this.btnWMS.Click += new System.EventHandler(this.btnWMS_Click);
            // 
            // btnActualiza
            // 
            this.btnActualiza.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnActualiza.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualiza.ImageOptions.Image")));
            this.btnActualiza.Location = new System.Drawing.Point(6, 31);
            this.btnActualiza.Name = "btnActualiza";
            this.btnActualiza.Size = new System.Drawing.Size(99, 23);
            this.btnActualiza.TabIndex = 0;
            this.btnActualiza.Text = "Actualizar";
            this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(4, 81);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1249, 412);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colbaserecordtype,
            this.coltranid,
            this.colFecha});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colbaserecordtype
            // 
            this.colbaserecordtype.Caption = "Movimiento";
            this.colbaserecordtype.FieldName = "baserecordtype";
            this.colbaserecordtype.Name = "colbaserecordtype";
            this.colbaserecordtype.Visible = true;
            this.colbaserecordtype.VisibleIndex = 1;
            // 
            // coltranid
            // 
            this.coltranid.Caption = "Numero";
            this.coltranid.FieldName = "tranid";
            this.coltranid.Name = "coltranid";
            this.coltranid.Visible = true;
            this.coltranid.VisibleIndex = 2;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "fechaIngreso";
            this.colFecha.FieldName = "fechaIngreso";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 3;
            // 
            // TransferOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TransferOrder";
            this.Size = new System.Drawing.Size(1256, 496);
            this.Load += new System.EventHandler(this.TransferOrder_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtImprimir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnActualiza;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.TextEdit txtImprimir;
        private DevExpress.XtraEditors.SimpleButton btnWMS;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colbaserecordtype;
        private DevExpress.XtraGrid.Columns.GridColumn coltranid;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
    }
}
