namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    partial class reporteEmbarques
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
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfechaConcluido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_ITEM_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomentarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colestatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colestado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpersona = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfechaHora = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1258, 73);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Controles";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.exporttoxls_16x161;
            this.simpleButton2.Location = new System.Drawing.Point(112, 38);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(88, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Excel";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnConsultar.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.textbox_16x16;
            this.btnConsultar.Location = new System.Drawing.Point(18, 38);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 23);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 82);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1258, 498);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidEmbarque,
            this.colfecha,
            this.colfechaConcluido,
            this.colLIST_ITEM_NAME,
            this.colcomentarios,
            this.colestatus,
            this.colusuario,
            this.colNAME,
            this.colfactura,
            this.colestado,
            this.colpersona,
            this.colfechaHora});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colidEmbarque, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colidEmbarque
            // 
            this.colidEmbarque.Caption = "No. Embarque";
            this.colidEmbarque.FieldName = "idEmbarque";
            this.colidEmbarque.Name = "colidEmbarque";
            this.colidEmbarque.Visible = true;
            this.colidEmbarque.VisibleIndex = 0;
            // 
            // colfecha
            // 
            this.colfecha.Caption = "Fecha";
            this.colfecha.FieldName = "fecha";
            this.colfecha.Name = "colfecha";
            this.colfecha.Visible = true;
            this.colfecha.VisibleIndex = 0;
            // 
            // colfechaConcluido
            // 
            this.colfechaConcluido.Caption = "FechaConcluido";
            this.colfechaConcluido.FieldName = "fechaConcluido";
            this.colfechaConcluido.Name = "colfechaConcluido";
            this.colfechaConcluido.Visible = true;
            this.colfechaConcluido.VisibleIndex = 1;
            // 
            // colLIST_ITEM_NAME
            // 
            this.colLIST_ITEM_NAME.Caption = "Paqueteria";
            this.colLIST_ITEM_NAME.FieldName = "LIST_ITEM_NAME";
            this.colLIST_ITEM_NAME.Name = "colLIST_ITEM_NAME";
            this.colLIST_ITEM_NAME.Visible = true;
            this.colLIST_ITEM_NAME.VisibleIndex = 2;
            // 
            // colcomentarios
            // 
            this.colcomentarios.Caption = "Paqueteria";
            this.colcomentarios.FieldName = "comentarios";
            this.colcomentarios.Name = "colcomentarios";
            this.colcomentarios.Visible = true;
            this.colcomentarios.VisibleIndex = 3;
            // 
            // colestatus
            // 
            this.colestatus.Caption = "Estatus";
            this.colestatus.FieldName = "estatus";
            this.colestatus.Name = "colestatus";
            this.colestatus.Visible = true;
            this.colestatus.VisibleIndex = 4;
            // 
            // colusuario
            // 
            this.colusuario.Caption = "Usuario";
            this.colusuario.FieldName = "usuario";
            this.colusuario.Name = "colusuario";
            this.colusuario.Visible = true;
            this.colusuario.VisibleIndex = 5;
            // 
            // colNAME
            // 
            this.colNAME.Caption = "Asignado";
            this.colNAME.FieldName = "CHOFER";
            this.colNAME.Name = "colNAME";
            this.colNAME.Visible = true;
            this.colNAME.VisibleIndex = 6;
            // 
            // colfactura
            // 
            this.colfactura.Caption = "Factura";
            this.colfactura.FieldName = "factura";
            this.colfactura.Name = "colfactura";
            this.colfactura.Visible = true;
            this.colfactura.VisibleIndex = 7;
            // 
            // colestado
            // 
            this.colestado.Caption = "Estado";
            this.colestado.FieldName = "estado";
            this.colestado.Name = "colestado";
            this.colestado.Visible = true;
            this.colestado.VisibleIndex = 8;
            // 
            // colpersona
            // 
            this.colpersona.Caption = "Persona";
            this.colpersona.FieldName = "persona";
            this.colpersona.Name = "colpersona";
            this.colpersona.Visible = true;
            this.colpersona.VisibleIndex = 9;
            // 
            // colfechaHora
            // 
            this.colfechaHora.Caption = "fechaHora";
            this.colfechaHora.FieldName = "fechaHora";
            this.colfechaHora.Name = "colfechaHora";
            this.colfechaHora.Visible = true;
            this.colfechaHora.VisibleIndex = 10;
            // 
            // reporteEmbarques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "reporteEmbarques";
            this.Size = new System.Drawing.Size(1264, 583);
            this.Load += new System.EventHandler(this.reporteEmbarques_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colidEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha;
        private DevExpress.XtraGrid.Columns.GridColumn colfechaConcluido;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_ITEM_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colcomentarios;
        private DevExpress.XtraGrid.Columns.GridColumn colestatus;
        private DevExpress.XtraGrid.Columns.GridColumn colusuario;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colfactura;
        private DevExpress.XtraGrid.Columns.GridColumn colestado;
        private DevExpress.XtraGrid.Columns.GridColumn colpersona;
        private DevExpress.XtraGrid.Columns.GridColumn colfechaHora;
    }
}
