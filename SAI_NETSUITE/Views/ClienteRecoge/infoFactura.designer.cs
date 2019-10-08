namespace SAI_NETSUITE.Views.ClienteRecoge
{
    partial class infoFactura
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colarticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldrescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.LabeCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(668, 30);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 28);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "CERRAR";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(148, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inkar";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(17, 15);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(773, 266);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colarticulo,
            this.colCantidad,
            this.coldrescripcion,
            this.colNombre});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            // 
            // colarticulo
            // 
            this.colarticulo.Caption = "Articulo";
            this.colarticulo.FieldName = "articulo";
            this.colarticulo.Name = "colarticulo";
            this.colarticulo.Visible = true;
            this.colarticulo.VisibleIndex = 0;
            this.colarticulo.Width = 113;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.FieldName = "cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 1;
            this.colCantidad.Width = 99;
            // 
            // coldrescripcion
            // 
            this.coldrescripcion.Caption = "Descripcion";
            this.coldrescripcion.FieldName = "descripcion1";
            this.coldrescripcion.Name = "coldrescripcion";
            this.coldrescripcion.Visible = true;
            this.coldrescripcion.VisibleIndex = 2;
            this.coldrescripcion.Width = 830;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Situacion";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.LabeCliente);
            this.groupControl1.Controls.Add(this.textBox1);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Location = new System.Drawing.Point(16, 288);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(775, 85);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "CLIENTE:";
            // 
            // LabeCliente
            // 
            this.LabeCliente.AutoSize = true;
            this.LabeCliente.Location = new System.Drawing.Point(300, 44);
            this.LabeCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabeCliente.Name = "LabeCliente";
            this.LabeCliente.Size = new System.Drawing.Size(42, 17);
            this.LabeCliente.TabIndex = 4;
            this.LabeCliente.Text = "label2";
            // 
            // infoFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(807, 388);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "infoFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "infoFactura";
            this.Load += new System.EventHandler(this.infoFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colarticulo;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn coldrescripcion;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label LabeCliente;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
    }
}