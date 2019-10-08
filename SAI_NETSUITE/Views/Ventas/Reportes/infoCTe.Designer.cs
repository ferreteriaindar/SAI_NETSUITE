namespace SAI_NETSUITE.Views.Ventas.Reportes
{
    partial class infoCTe
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.BTNCARGAR = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(4, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1334, 479);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.textBox1);
            this.groupControl1.Controls.Add(this.btnExcel);
            this.groupControl1.Controls.Add(this.BTNCARGAR);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1335, 74);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 23);
            this.textBox1.TabIndex = 2;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExcel.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.exporttoxls_16x16;
            this.btnExcel.Location = new System.Drawing.Point(288, 28);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 41);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // BTNCARGAR
            // 
            this.BTNCARGAR.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.BTNCARGAR.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.recurrence_16x16;
            this.BTNCARGAR.Location = new System.Drawing.Point(25, 28);
            this.BTNCARGAR.Name = "BTNCARGAR";
            this.BTNCARGAR.Size = new System.Drawing.Size(87, 41);
            this.BTNCARGAR.TabIndex = 0;
            this.BTNCARGAR.Text = "Consultar";
            this.BTNCARGAR.Click += new System.EventHandler(this.BTNCARGAR_Click);
            // 
            // infoCTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "infoCTe";
            this.Size = new System.Drawing.Size(1341, 553);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton BTNCARGAR;
    }
}
