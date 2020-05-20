namespace SAI_NETSUITE.Views.CXC
{
    partial class TimbradoPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimbradoPago));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimbrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargaInfo = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.backgroundWorkerCarga = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerTimbra = new System.ComponentModel.BackgroundWorker();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTimbrar);
            this.groupBox1.Controls.Add(this.btnCargaInfo);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1269, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1055, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "0/0";
            // 
            // btnTimbrar
            // 
            this.btnTimbrar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnTimbrar.Location = new System.Drawing.Point(1135, 22);
            this.btnTimbrar.Name = "btnTimbrar";
            this.btnTimbrar.Size = new System.Drawing.Size(128, 56);
            this.btnTimbrar.TabIndex = 1;
            this.btnTimbrar.Text = "Timbrar";
            this.btnTimbrar.Click += new System.EventHandler(this.btnTimbrar_Click);
            // 
            // btnCargaInfo
            // 
            this.btnCargaInfo.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnCargaInfo.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargaInfo.Appearance.Options.UseBackColor = true;
            this.btnCargaInfo.Appearance.Options.UseFont = true;
            this.btnCargaInfo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCargaInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCargaInfo.ImageOptions.Image")));
            this.btnCargaInfo.Location = new System.Drawing.Point(6, 22);
            this.btnCargaInfo.Name = "btnCargaInfo";
            this.btnCargaInfo.Size = new System.Drawing.Size(117, 56);
            this.btnCargaInfo.TabIndex = 0;
            this.btnCargaInfo.Text = "Cargar Info";
            this.btnCargaInfo.Click += new System.EventHandler(this.btnCargaInfo_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(9, 94);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1263, 511);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // backgroundWorkerCarga
            // 
            this.backgroundWorkerCarga.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCarga_DoWork);
            this.backgroundWorkerCarga.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCarga_RunWorkerCompleted);
            // 
            // backgroundWorkerTimbra
            // 
            this.backgroundWorkerTimbra.WorkerReportsProgress = true;
            this.backgroundWorkerTimbra.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTimbra_DoWork);
            this.backgroundWorkerTimbra.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTimbra_ProgressChanged);
            this.backgroundWorkerTimbra.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTimbra_RunWorkerCompleted);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(541, 37);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // TimbradoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TimbradoPago";
            this.Size = new System.Drawing.Size(1275, 626);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnCargaInfo;
        private DevExpress.XtraEditors.SimpleButton btnTimbrar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCarga;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTimbra;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
