namespace SAI_NETSUITE.Views.Ventas.Reportes
{
    partial class rastrearART
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BTNCARGAR = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnExcel);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.textBox1);
            this.groupControl1.Controls.Add(this.BTNCARGAR);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1241, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExcel.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.exporttoxls_16x16;
            this.btnExcel.Location = new System.Drawing.Point(328, 41);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 41);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "CLIENTE";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 23);
            this.textBox1.TabIndex = 6;
            // 
            // BTNCARGAR
            // 
            this.BTNCARGAR.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.BTNCARGAR.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.recurrence_16x16;
            this.BTNCARGAR.Location = new System.Drawing.Point(204, 41);
            this.BTNCARGAR.Name = "BTNCARGAR";
            this.BTNCARGAR.Size = new System.Drawing.Size(87, 41);
            this.BTNCARGAR.TabIndex = 5;
            this.BTNCARGAR.Text = "Consultar";
            this.BTNCARGAR.Click += new System.EventHandler(this.BTNCARGAR_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(4, 111);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1241, 441);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // rastrearART
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "rastrearART";
            this.Size = new System.Drawing.Size(1248, 555);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton BTNCARGAR;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
