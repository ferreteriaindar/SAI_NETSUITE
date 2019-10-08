namespace SAI_NETSUITE.Views.ClienteRecoge
{ 
    partial class borrarClienteFila
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.comboBox1);
            this.groupControl1.Location = new System.Drawing.Point(13, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(243, 64);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Ingresa el Motivo";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(149, 25);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(89, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Eliminar Cliente";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "REGRESA OTRO DIA",
            "REGRESA AL RATO",
            "CANCELA",
            "OTRO"});
            this.comboBox1.Location = new System.Drawing.Point(8, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // borrarClienteFila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(263, 89);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "borrarClienteFila";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "borrarClienteFila";
            this.Load += new System.EventHandler(this.borrarClienteFila_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}