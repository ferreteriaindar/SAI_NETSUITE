namespace SAI_NETSUITE.Views.CXC
{
    partial class entrega_block
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(entrega_block));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colagente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfolio_inicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfolio_fin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colserie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomentarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_comentarios = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_serie = new System.Windows.Forms.TextBox();
            this.masked_fecha = new System.Windows.Forms.MaskedTextBox();
            this.searchEmpleado = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpleadoNAme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpleadoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGuarda = new DevExpress.XtraEditors.SimpleButton();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Location = new System.Drawing.Point(16, 107);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1191, 351);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ENTREGADOS";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(4, 19);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1183, 328);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colagente,
            this.colnombre,
            this.colfecha,
            this.colfolio_inicio,
            this.colfolio_fin,
            this.colserie,
            this.colcantidad,
            this.colcomentarios});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colagente
            // 
            this.colagente.FieldName = "agente";
            this.colagente.Name = "colagente";
            this.colagente.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colagente.Visible = true;
            this.colagente.VisibleIndex = 8;
            // 
            // colnombre
            // 
            this.colnombre.FieldName = "nombre";
            this.colnombre.Name = "colnombre";
            this.colnombre.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colnombre.Visible = true;
            this.colnombre.VisibleIndex = 1;
            // 
            // colfecha
            // 
            this.colfecha.FieldName = "fecha";
            this.colfecha.Name = "colfecha";
            this.colfecha.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colfecha.Visible = true;
            this.colfecha.VisibleIndex = 2;
            // 
            // colfolio_inicio
            // 
            this.colfolio_inicio.FieldName = "folio_inicio";
            this.colfolio_inicio.Name = "colfolio_inicio";
            this.colfolio_inicio.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colfolio_inicio.Visible = true;
            this.colfolio_inicio.VisibleIndex = 4;
            // 
            // colfolio_fin
            // 
            this.colfolio_fin.FieldName = "folio_fin";
            this.colfolio_fin.Name = "colfolio_fin";
            this.colfolio_fin.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colfolio_fin.Visible = true;
            this.colfolio_fin.VisibleIndex = 5;
            // 
            // colserie
            // 
            this.colserie.FieldName = "serie";
            this.colserie.Name = "colserie";
            this.colserie.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colserie.Visible = true;
            this.colserie.VisibleIndex = 3;
            // 
            // colcantidad
            // 
            this.colcantidad.FieldName = "cantidad";
            this.colcantidad.Name = "colcantidad";
            this.colcantidad.Visible = true;
            this.colcantidad.VisibleIndex = 6;
            // 
            // colcomentarios
            // 
            this.colcomentarios.FieldName = "comentarios";
            this.colcomentarios.Name = "colcomentarios";
            this.colcomentarios.Visible = true;
            this.colcomentarios.VisibleIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnGuarda);
            this.groupBox2.Controls.Add(this.searchEmpleado);
            this.groupBox2.Controls.Add(this.txt_comentarios);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_serie);
            this.groupBox2.Controls.Add(this.masked_fecha);
            this.groupBox2.Location = new System.Drawing.Point(17, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1191, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Captura Datos";
            // 
            // txt_comentarios
            // 
            this.txt_comentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_comentarios.Location = new System.Drawing.Point(605, 20);
            this.txt_comentarios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_comentarios.Multiline = true;
            this.txt_comentarios.Name = "txt_comentarios";
            this.txt_comentarios.Size = new System.Drawing.Size(253, 56);
            this.txt_comentarios.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Serie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // txt_serie
            // 
            this.txt_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_serie.Location = new System.Drawing.Point(529, 42);
            this.txt_serie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_serie.Name = "txt_serie";
            this.txt_serie.Size = new System.Drawing.Size(67, 22);
            this.txt_serie.TabIndex = 2;
            // 
            // masked_fecha
            // 
            this.masked_fecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.masked_fecha.Location = new System.Drawing.Point(432, 42);
            this.masked_fecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.masked_fecha.Mask = "00/00/0000";
            this.masked_fecha.Name = "masked_fecha";
            this.masked_fecha.Size = new System.Drawing.Size(89, 22);
            this.masked_fecha.TabIndex = 1;
            this.masked_fecha.ValidatingType = typeof(System.DateTime);
            // 
            // searchEmpleado
            // 
            this.searchEmpleado.Location = new System.Drawing.Point(7, 41);
            this.searchEmpleado.Name = "searchEmpleado";
            this.searchEmpleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchEmpleado.Properties.DisplayMember = "nombre";
            this.searchEmpleado.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchEmpleado.Properties.ValueMember = "id";
            this.searchEmpleado.Size = new System.Drawing.Size(418, 22);
            this.searchEmpleado.TabIndex = 10;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpleadoNAme,
            this.colEmpleadoId});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colEmpleadoNAme
            // 
            this.colEmpleadoNAme.Caption = "Nombre";
            this.colEmpleadoNAme.FieldName = "nombre";
            this.colEmpleadoNAme.Name = "colEmpleadoNAme";
            this.colEmpleadoNAme.Visible = true;
            this.colEmpleadoNAme.VisibleIndex = 0;
            // 
            // colEmpleadoId
            // 
            this.colEmpleadoId.Caption = "ID";
            this.colEmpleadoId.FieldName = "id";
            this.colEmpleadoId.Name = "colEmpleadoId";
            // 
            // btnGuarda
            // 
            this.btnGuarda.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuarda.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image1")));
            this.btnGuarda.Location = new System.Drawing.Point(867, 25);
            this.btnGuarda.Name = "btnGuarda";
            this.btnGuarda.Size = new System.Drawing.Size(101, 46);
            this.btnGuarda.TabIndex = 11;
            this.btnGuarda.Text = "Registrar";
            this.btnGuarda.Click += new System.EventHandler(this.btnGuarda_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnLimpiar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(974, 25);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 46);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // entrega_block
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "entrega_block";
            this.Size = new System.Drawing.Size(1224, 473);
            this.Load += new System.EventHandler(this.entrega_block_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_serie;
        private System.Windows.Forms.MaskedTextBox masked_fecha;
        private System.Windows.Forms.TextBox txt_comentarios;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        
       
       
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colagente;
        private DevExpress.XtraGrid.Columns.GridColumn colnombre;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha;
        private DevExpress.XtraGrid.Columns.GridColumn colfolio_inicio;
        private DevExpress.XtraGrid.Columns.GridColumn colfolio_fin;
        private DevExpress.XtraGrid.Columns.GridColumn colserie;
        private DevExpress.XtraGrid.Columns.GridColumn colcantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colcomentarios;
        private DevExpress.XtraEditors.SearchLookUpEdit searchEmpleado;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpleadoNAme;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpleadoId;
        private DevExpress.XtraEditors.SimpleButton btnGuarda;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
    }
}