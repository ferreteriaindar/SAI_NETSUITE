namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    partial class AutorizacionJefe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutorizacionJefe));
            this.ComboJefe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpass = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.txtSolucion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAutorizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.LabelTitulo = new System.Windows.Forms.Label();
            this.labelFaltantes = new System.Windows.Forms.Label();
            this.lista = new System.Windows.Forms.ListView();
            this.btnDesembarcar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboJefe
            // 
            this.ComboJefe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboJefe.FormattingEnabled = true;
            this.ComboJefe.Location = new System.Drawing.Point(16, 65);
            this.ComboJefe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ComboJefe.Name = "ComboJefe";
            this.ComboJefe.Size = new System.Drawing.Size(260, 24);
            this.ComboJefe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "¿Quien Autoriza?";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(16, 116);
            this.txtpass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtpass.Name = "txtpass";
            this.txtpass.Properties.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(261, 22);
            this.txtpass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(16, 185);
            this.txtError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtError.MaxLength = 150;
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(563, 98);
            this.txtError.TabIndex = 4;
            // 
            // txtSolucion
            // 
            this.txtSolucion.Location = new System.Drawing.Point(20, 306);
            this.txtSolucion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSolucion.MaxLength = 150;
            this.txtSolucion.Multiline = true;
            this.txtSolucion.Name = "txtSolucion";
            this.txtSolucion.Size = new System.Drawing.Size(559, 106);
            this.txtSolucion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripcion del Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 287);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripcion de Solucion";
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAutorizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAutorizar.ImageOptions.Image")));
            this.btnAutorizar.Location = new System.Drawing.Point(453, 108);
            this.btnAutorizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(127, 32);
            this.btnAutorizar.TabIndex = 8;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.Location = new System.Drawing.Point(453, 146);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(127, 28);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // LabelTitulo
            // 
            this.LabelTitulo.AutoSize = true;
            this.LabelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitulo.Location = new System.Drawing.Point(117, 11);
            this.LabelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelTitulo.Name = "LabelTitulo";
            this.LabelTitulo.Size = new System.Drawing.Size(314, 25);
            this.LabelTitulo.TabIndex = 10;
            this.LabelTitulo.Text = "AUTORIZAR EL DOCUMENTO";
            // 
            // labelFaltantes
            // 
            this.labelFaltantes.AutoSize = true;
            this.labelFaltantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaltantes.Location = new System.Drawing.Point(341, 47);
            this.labelFaltantes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFaltantes.Name = "labelFaltantes";
            this.labelFaltantes.Size = new System.Drawing.Size(75, 17);
            this.labelFaltantes.TabIndex = 12;
            this.labelFaltantes.Text = "Faltantes";
            this.labelFaltantes.Visible = false;
            // 
            // lista
            // 
            this.lista.Location = new System.Drawing.Point(332, 66);
            this.lista.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(97, 110);
            this.lista.TabIndex = 13;
            this.lista.UseCompatibleStateImageBehavior = false;
            this.lista.View = System.Windows.Forms.View.List;
            this.lista.Visible = false;
            // 
            // btnDesembarcar
            // 
            this.btnDesembarcar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnDesembarcar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDesembarcar.ImageOptions.Image")));
            this.btnDesembarcar.Location = new System.Drawing.Point(455, 65);
            this.btnDesembarcar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDesembarcar.Name = "btnDesembarcar";
            this.btnDesembarcar.Size = new System.Drawing.Size(127, 32);
            this.btnDesembarcar.TabIndex = 14;
            this.btnDesembarcar.Text = "Desembarque";
            this.btnDesembarcar.Visible = false;
            this.btnDesembarcar.Click += new System.EventHandler(this.btnDesembarcar_Click);
            // 
            // AutorizacionJefe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 430);
            this.Controls.Add(this.btnDesembarcar);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.labelFaltantes);
            this.Controls.Add(this.LabelTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAutorizar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSolucion);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboJefe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AutorizacionJefe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutorizacionJefe";
            this.Load += new System.EventHandler(this.AutorizacionJefe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtpass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboJefe;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.TextBox txtSolucion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnAutorizar;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private System.Windows.Forms.Label LabelTitulo;
        private System.Windows.Forms.Label labelFaltantes;
        private System.Windows.Forms.ListView lista;
        private DevExpress.XtraEditors.SimpleButton btnDesembarcar;
    }
}