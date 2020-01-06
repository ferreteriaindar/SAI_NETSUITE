namespace SAI_NETSUITE.Views.PostVenta
{
    partial class Confirmacion
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelAvance = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.separatorControl3 = new DevExpress.XtraEditors.SeparatorControl();
            this.btnBuscarEmbarque = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmbarque = new DevExpress.XtraEditors.TextEdit();
            this.labelEmbarque = new System.Windows.Forms.Label();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            this.btnAplicarFecha = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.btnBuscarFactura = new DevExpress.XtraEditors.SimpleButton();
            this.txtFactura = new DevExpress.XtraEditors.TextEdit();
            this.labelFactura = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colfechaHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersona = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomentarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ComboBox2Comentarios = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colfacturaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmbarque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBox2Comentarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelAvance);
            this.groupControl1.Controls.Add(this.pictureBox1);
            this.groupControl1.Controls.Add(this.separatorControl3);
            this.groupControl1.Controls.Add(this.btnBuscarEmbarque);
            this.groupControl1.Controls.Add(this.txtEmbarque);
            this.groupControl1.Controls.Add(this.labelEmbarque);
            this.groupControl1.Controls.Add(this.simpleButton3);
            this.groupControl1.Controls.Add(this.separatorControl2);
            this.groupControl1.Controls.Add(this.btnAplicarFecha);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.separatorControl1);
            this.groupControl1.Controls.Add(this.btnBuscarFactura);
            this.groupControl1.Controls.Add(this.txtFactura);
            this.groupControl1.Controls.Add(this.labelFactura);
            this.groupControl1.Location = new System.Drawing.Point(3, 4);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1222, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Controles";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // labelAvance
            // 
            this.labelAvance.AutoSize = true;
            this.labelAvance.Location = new System.Drawing.Point(380, 55);
            this.labelAvance.Name = "labelAvance";
            this.labelAvance.Size = new System.Drawing.Size(29, 17);
            this.labelAvance.TabIndex = 13;
            this.labelAvance.Text = "0/1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SAI_NETSUITE.Properties.Resources._835;
            this.pictureBox1.Location = new System.Drawing.Point(338, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 38);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // separatorControl3
            // 
            this.separatorControl3.AutoSizeMode = true;
            this.separatorControl3.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl3.Location = new System.Drawing.Point(157, 25);
            this.separatorControl3.Name = "separatorControl3";
            this.separatorControl3.Size = new System.Drawing.Size(20, 67);
            this.separatorControl3.TabIndex = 11;
            // 
            // btnBuscarEmbarque
            // 
            this.btnBuscarEmbarque.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnBuscarEmbarque.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.product_16x16;
            this.btnBuscarEmbarque.Location = new System.Drawing.Point(5, 72);
            this.btnBuscarEmbarque.Name = "btnBuscarEmbarque";
            this.btnBuscarEmbarque.Size = new System.Drawing.Size(132, 23);
            this.btnBuscarEmbarque.TabIndex = 10;
            this.btnBuscarEmbarque.Text = "BuscarEmbarque";
            this.btnBuscarEmbarque.Click += new System.EventHandler(this.btnBuscarEmbarque_Click);
            // 
            // txtEmbarque
            // 
            this.txtEmbarque.Location = new System.Drawing.Point(5, 48);
            this.txtEmbarque.Name = "txtEmbarque";
            this.txtEmbarque.Size = new System.Drawing.Size(132, 22);
            this.txtEmbarque.TabIndex = 9;
            this.txtEmbarque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmbarque_KeyPress);
            // 
            // labelEmbarque
            // 
            this.labelEmbarque.AutoSize = true;
            this.labelEmbarque.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmbarque.Location = new System.Drawing.Point(5, 26);
            this.labelEmbarque.Name = "labelEmbarque";
            this.labelEmbarque.Size = new System.Drawing.Size(118, 19);
            this.labelEmbarque.TabIndex = 8;
            this.labelEmbarque.Text = "POR EMBARQUE";
            // 
            // simpleButton3
            // 
            this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton3.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.apply_16x16;
            this.simpleButton3.Location = new System.Drawing.Point(1062, 40);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(142, 44);
            this.simpleButton3.TabIndex = 7;
            this.simpleButton3.Text = "Confirmar Facturas";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // separatorControl2
            // 
            this.separatorControl2.AutoSizeMode = true;
            this.separatorControl2.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl2.Location = new System.Drawing.Point(1036, 28);
            this.separatorControl2.Name = "separatorControl2";
            this.separatorControl2.Size = new System.Drawing.Size(20, 67);
            this.separatorControl2.TabIndex = 4;
            // 
            // btnAplicarFecha
            // 
            this.btnAplicarFecha.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnAplicarFecha.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.task_16x16;
            this.btnAplicarFecha.Location = new System.Drawing.Point(898, 40);
            this.btnAplicarFecha.Name = "btnAplicarFecha";
            this.btnAplicarFecha.Size = new System.Drawing.Size(132, 44);
            this.btnAplicarFecha.TabIndex = 6;
            this.btnAplicarFecha.Text = "Aplicar fecha a\r\nSeleccionados";
            this.btnAplicarFecha.Click += new System.EventHandler(this.btnAplicarFecha_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(711, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "FECHA";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(715, 51);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(173, 22);
            this.dateEdit1.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.dateEdit1, conditionValidationRule1);
            // 
            // separatorControl1
            // 
            this.separatorControl1.AutoSizeMode = true;
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.Location = new System.Drawing.Point(321, 26);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(20, 67);
            this.separatorControl1.TabIndex = 3;
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnBuscarFactura.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.template_16x16;
            this.btnBuscarFactura.Location = new System.Drawing.Point(183, 72);
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(132, 23);
            this.btnBuscarFactura.TabIndex = 2;
            this.btnBuscarFactura.Text = "Agregar Factura";
            this.btnBuscarFactura.Click += new System.EventHandler(this.btnBuscarFactura_Click);
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(183, 48);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(132, 22);
            this.txtFactura.TabIndex = 1;
            this.txtFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFactura_KeyPress);
            // 
            // labelFactura
            // 
            this.labelFactura.AutoSize = true;
            this.labelFactura.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFactura.Location = new System.Drawing.Point(199, 26);
            this.labelFactura.Name = "labelFactura";
            this.labelFactura.Size = new System.Drawing.Size(101, 19);
            this.labelFactura.TabIndex = 0;
            this.labelFactura.Text = "POR FACTURA";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 108);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.ComboBox2Comentarios});
            this.gridControl1.Size = new System.Drawing.Size(1222, 464);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFactura,
            this.colEstado,
            this.colfechaHora,
            this.colPersona,
            this.colcomentarios,
            this.colfacturaid});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colFactura
            // 
            this.colFactura.Caption = "Factura";
            this.colFactura.FieldName = "factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.Visible = true;
            this.colFactura.VisibleIndex = 1;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.ColumnEdit = this.repositoryItemComboBox1;
            this.colEstado.FieldName = "estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 2;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "ENTREGADO",
            "DESEMBARQUE",
            "CANCELADO"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // colfechaHora
            // 
            this.colfechaHora.Caption = "FECHAHORA";
            this.colfechaHora.FieldName = "fechaHora";
            this.colfechaHora.Name = "colfechaHora";
            this.colfechaHora.Visible = true;
            this.colfechaHora.VisibleIndex = 3;
            // 
            // colPersona
            // 
            this.colPersona.Caption = "Persona";
            this.colPersona.FieldName = "persona";
            this.colPersona.Name = "colPersona";
            this.colPersona.Visible = true;
            this.colPersona.VisibleIndex = 4;
            // 
            // colcomentarios
            // 
            this.colcomentarios.Caption = "Comentarios";
            this.colcomentarios.ColumnEdit = this.ComboBox2Comentarios;
            this.colcomentarios.FieldName = "comentarios";
            this.colcomentarios.Name = "colcomentarios";
            this.colcomentarios.Visible = true;
            this.colcomentarios.VisibleIndex = 5;
            // 
            // ComboBox2Comentarios
            // 
            this.ComboBox2Comentarios.AutoHeight = false;
            this.ComboBox2Comentarios.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBox2Comentarios.Items.AddRange(new object[] {
            "Efectivo",
            "Cheque",
            "Transferencia",
            "Contra Recibo",
            "Tarjeta",
            " "});
            this.ComboBox2Comentarios.Name = "ComboBox2Comentarios";
            // 
            // colfacturaid
            // 
            this.colfacturaid.Caption = "facturaid";
            this.colfacturaid.FieldName = "facturaid";
            this.colfacturaid.Name = "colfacturaid";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Confirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "Confirmacion";
            this.Size = new System.Drawing.Size(1228, 575);
            this.Load += new System.EventHandler(this.Confirmacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmbarque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBox2Comentarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscarFactura;
        private DevExpress.XtraEditors.TextEdit txtFactura;
        private System.Windows.Forms.Label labelFactura;
        private DevExpress.XtraEditors.SimpleButton btnAplicarFecha;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl3;
        private DevExpress.XtraEditors.SimpleButton btnBuscarEmbarque;
        private DevExpress.XtraEditors.TextEdit txtEmbarque;
        private System.Windows.Forms.Label labelEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colfechaHora;
        private DevExpress.XtraGrid.Columns.GridColumn colPersona;
        private DevExpress.XtraGrid.Columns.GridColumn colcomentarios;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.Windows.Forms.Label labelAvance;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraGrid.Columns.GridColumn colfacturaid;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox ComboBox2Comentarios;
    }
}
