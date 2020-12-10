namespace SAI_NETSUITE.Views.Compras
{
    partial class ActualizaBasesCompras
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
            this.btnArticuloWeb = new DevExpress.XtraEditors.SimpleButton();
            this.btnPromoCompras = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnArticuloWeb
            // 
            this.btnArticuloWeb.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnArticuloWeb.Appearance.Options.UseBackColor = true;
            this.btnArticuloWeb.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnArticuloWeb.Location = new System.Drawing.Point(45, 31);
            this.btnArticuloWeb.Name = "btnArticuloWeb";
            this.btnArticuloWeb.Size = new System.Drawing.Size(227, 84);
            this.btnArticuloWeb.TabIndex = 0;
            this.btnArticuloWeb.Text = "Actualiza Articulos Web";
            this.btnArticuloWeb.Click += new System.EventHandler(this.btnArticuloWeb_Click);
            // 
            // btnPromoCompras
            // 
            this.btnPromoCompras.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnPromoCompras.Appearance.Options.UseBackColor = true;
            this.btnPromoCompras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPromoCompras.Location = new System.Drawing.Point(305, 31);
            this.btnPromoCompras.Name = "btnPromoCompras";
            this.btnPromoCompras.Size = new System.Drawing.Size(252, 84);
            this.btnPromoCompras.TabIndex = 1;
            this.btnPromoCompras.Text = "Actualiza Promos Compras";
            this.btnPromoCompras.Click += new System.EventHandler(this.btnPromoCompras_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // ActualizaBasesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPromoCompras);
            this.Controls.Add(this.btnArticuloWeb);
            this.Name = "ActualizaBasesCompras";
            this.Size = new System.Drawing.Size(1277, 436);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnArticuloWeb;
        private DevExpress.XtraEditors.SimpleButton btnPromoCompras;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
