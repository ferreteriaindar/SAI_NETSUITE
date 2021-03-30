namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    partial class FacturasXEmbarcar
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
            this.colPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCotizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConsolidado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCondicionPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormaEnvio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFletera = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotalEmbarques = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstadoEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComentarioEmbarque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstadoFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ComentarioFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaFleteXConfirmar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChofer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiasPermitidos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.comboFiltro = new System.Windows.Forms.ComboBox();
            this.btnParametros = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.dateIni = new DevExpress.XtraEditors.DateEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 108);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1170, 489);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPedido,
            this.colCotizacion,
            this.colConsolidado,
            this.colMovimiento,
            this.colFactura,
            this.colFechaFactura,
            this.colCliente,
            this.colNota,
            this.colCondicionPago,
            this.colImporte,
            this.colFormaEnvio,
            this.colFletera,
            this.colEmbarque,
            this.coltotalEmbarques,
            this.colFechaEmbarque,
            this.colEstadoEmbarque,
            this.colComentarioEmbarque,
            this.colEstadoFactura,
            this.ComentarioFactura,
            this.colFechaFleteXConfirmar,
            this.colFechaEntrega,
            this.colusuario,
            this.colChofer,
            this.colResponsable,
            this.colDiasPermitidos,
            this.colEstatus,
            this.colDias});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colPedido
            // 
            this.colPedido.Caption = "Pedido ";
            this.colPedido.FieldName = "Pedido";
            this.colPedido.Name = "colPedido";
            this.colPedido.Visible = true;
            this.colPedido.VisibleIndex = 0;
            // 
            // colCotizacion
            // 
            this.colCotizacion.Caption = "Cotizacion";
            this.colCotizacion.FieldName = "Cotizacion";
            this.colCotizacion.Name = "colCotizacion";
            this.colCotizacion.Visible = true;
            this.colCotizacion.VisibleIndex = 1;
            // 
            // colConsolidado
            // 
            this.colConsolidado.Caption = "Consolidado";
            this.colConsolidado.FieldName = "Consolidado";
            this.colConsolidado.Name = "colConsolidado";
            this.colConsolidado.Visible = true;
            this.colConsolidado.VisibleIndex = 2;
            // 
            // colMovimiento
            // 
            this.colMovimiento.Caption = "Movimiento";
            this.colMovimiento.FieldName = "Movimiento";
            this.colMovimiento.Name = "colMovimiento";
            this.colMovimiento.Visible = true;
            this.colMovimiento.VisibleIndex = 3;
            // 
            // colFactura
            // 
            this.colFactura.Caption = "Factura";
            this.colFactura.FieldName = "Factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.Visible = true;
            this.colFactura.VisibleIndex = 4;
            // 
            // colFechaFactura
            // 
            this.colFechaFactura.Caption = "FechaFactura";
            this.colFechaFactura.FieldName = "FechaFactura";
            this.colFechaFactura.Name = "colFechaFactura";
            this.colFechaFactura.Visible = true;
            this.colFechaFactura.VisibleIndex = 5;
            // 
            // colCliente
            // 
            this.colCliente.Caption = "Cliente";
            this.colCliente.FieldName = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.Visible = true;
            this.colCliente.VisibleIndex = 6;
            // 
            // colNota
            // 
            this.colNota.Caption = "Nota";
            this.colNota.FieldName = "Nota";
            this.colNota.Name = "colNota";
            this.colNota.Visible = true;
            this.colNota.VisibleIndex = 7;
            // 
            // colCondicionPago
            // 
            this.colCondicionPago.Caption = "CondicionPago";
            this.colCondicionPago.FieldName = "CondicionPago";
            this.colCondicionPago.Name = "colCondicionPago";
            this.colCondicionPago.Visible = true;
            this.colCondicionPago.VisibleIndex = 8;
            // 
            // colImporte
            // 
            this.colImporte.Caption = "Importe";
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 9;
            // 
            // colFormaEnvio
            // 
            this.colFormaEnvio.Caption = "FormaEnvio";
            this.colFormaEnvio.FieldName = "FormaEnvio";
            this.colFormaEnvio.Name = "colFormaEnvio";
            this.colFormaEnvio.Visible = true;
            this.colFormaEnvio.VisibleIndex = 10;
            // 
            // colFletera
            // 
            this.colFletera.Caption = "Fletera";
            this.colFletera.FieldName = "Fletera";
            this.colFletera.Name = "colFletera";
            this.colFletera.Visible = true;
            this.colFletera.VisibleIndex = 11;
            // 
            // colEmbarque
            // 
            this.colEmbarque.Caption = "Embarque";
            this.colEmbarque.FieldName = "Embarque";
            this.colEmbarque.Name = "colEmbarque";
            this.colEmbarque.Visible = true;
            this.colEmbarque.VisibleIndex = 13;
            // 
            // coltotalEmbarques
            // 
            this.coltotalEmbarques.Caption = "totalEmbarques";
            this.coltotalEmbarques.FieldName = "totalEmbarques";
            this.coltotalEmbarques.Name = "coltotalEmbarques";
            this.coltotalEmbarques.OptionsColumn.AllowEdit = false;
            this.coltotalEmbarques.OptionsColumn.ReadOnly = true;
            this.coltotalEmbarques.Visible = true;
            this.coltotalEmbarques.VisibleIndex = 12;
            // 
            // colFechaEmbarque
            // 
            this.colFechaEmbarque.Caption = "FechaEmbarque";
            this.colFechaEmbarque.FieldName = "FechaEmbarque";
            this.colFechaEmbarque.Name = "colFechaEmbarque";
            this.colFechaEmbarque.Visible = true;
            this.colFechaEmbarque.VisibleIndex = 14;
            // 
            // colEstadoEmbarque
            // 
            this.colEstadoEmbarque.Caption = "EstadoEmbarque";
            this.colEstadoEmbarque.FieldName = "EstadoEmbarque";
            this.colEstadoEmbarque.Name = "colEstadoEmbarque";
            this.colEstadoEmbarque.Visible = true;
            this.colEstadoEmbarque.VisibleIndex = 15;
            // 
            // colComentarioEmbarque
            // 
            this.colComentarioEmbarque.Caption = "ComentarioEmbarque";
            this.colComentarioEmbarque.FieldName = "ComentarioEmbarque";
            this.colComentarioEmbarque.Name = "colComentarioEmbarque";
            this.colComentarioEmbarque.Visible = true;
            this.colComentarioEmbarque.VisibleIndex = 16;
            // 
            // colEstadoFactura
            // 
            this.colEstadoFactura.Caption = "EstadoFactura";
            this.colEstadoFactura.FieldName = "EstadoFactura";
            this.colEstadoFactura.Name = "colEstadoFactura";
            this.colEstadoFactura.Visible = true;
            this.colEstadoFactura.VisibleIndex = 17;
            // 
            // ComentarioFactura
            // 
            this.ComentarioFactura.Caption = "ComentarioFactura";
            this.ComentarioFactura.FieldName = "ComentarioFactura";
            this.ComentarioFactura.Name = "ComentarioFactura";
            this.ComentarioFactura.Visible = true;
            this.ComentarioFactura.VisibleIndex = 18;
            // 
            // colFechaFleteXConfirmar
            // 
            this.colFechaFleteXConfirmar.Caption = "FechaFleteXConfirmar";
            this.colFechaFleteXConfirmar.FieldName = "FechaFleteXConfirmar";
            this.colFechaFleteXConfirmar.Name = "colFechaFleteXConfirmar";
            this.colFechaFleteXConfirmar.Visible = true;
            this.colFechaFleteXConfirmar.VisibleIndex = 19;
            // 
            // colFechaEntrega
            // 
            this.colFechaEntrega.Caption = "FechaEntrega";
            this.colFechaEntrega.FieldName = "FechaEntrega";
            this.colFechaEntrega.Name = "colFechaEntrega";
            this.colFechaEntrega.Visible = true;
            this.colFechaEntrega.VisibleIndex = 20;
            // 
            // colusuario
            // 
            this.colusuario.Caption = "usuario";
            this.colusuario.FieldName = "usuario";
            this.colusuario.Name = "colusuario";
            this.colusuario.Visible = true;
            this.colusuario.VisibleIndex = 21;
            // 
            // colChofer
            // 
            this.colChofer.Caption = "Chofer";
            this.colChofer.FieldName = "Chofer";
            this.colChofer.Name = "colChofer";
            this.colChofer.Visible = true;
            this.colChofer.VisibleIndex = 22;
            // 
            // colResponsable
            // 
            this.colResponsable.Caption = "Responsable";
            this.colResponsable.FieldName = "Responsable";
            this.colResponsable.Name = "colResponsable";
            this.colResponsable.Visible = true;
            this.colResponsable.VisibleIndex = 24;
            // 
            // colDiasPermitidos
            // 
            this.colDiasPermitidos.Caption = "DiasPermitidos";
            this.colDiasPermitidos.FieldName = "DiasPermitidos";
            this.colDiasPermitidos.Name = "colDiasPermitidos";
            this.colDiasPermitidos.Visible = true;
            this.colDiasPermitidos.VisibleIndex = 25;
            // 
            // colEstatus
            // 
            this.colEstatus.Caption = "Estatus";
            this.colEstatus.FieldName = "colEstatus";
            this.colEstatus.Name = "colEstatus";
            this.colEstatus.UnboundExpression = "Iif([Dias] <= [DiasPermitidos], \'POR VENCER\', \'VENCIDO\')";
            this.colEstatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colEstatus.Visible = true;
            this.colEstatus.VisibleIndex = 26;
            // 
            // colDias
            // 
            this.colDias.Caption = "Dias";
            this.colDias.FieldName = "Dias";
            this.colDias.Name = "colDias";
            this.colDias.ShowUnboundExpressionMenu = true;
            this.colDias.Visible = true;
            this.colDias.VisibleIndex = 23;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ReadOnly = true;
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.comboFiltro);
            this.groupControl1.Controls.Add(this.btnParametros);
            this.groupControl1.Controls.Add(this.btnExcel);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.dateFin);
            this.groupControl1.Controls.Add(this.dateIni);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1163, 98);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Controles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filtros";
            // 
            // comboFiltro
            // 
            this.comboFiltro.FormattingEnabled = true;
            this.comboFiltro.Items.AddRange(new object[] {
            "Completo",
            "Vivos",
            "Sin Embarque",
            "SIN FILTRO",
            "AGS01 OFICINA AGUASCALIENTES",
            "BJX02 OFICINA LEON",
            "QRO03 OFICINA QRO",
            "CUL04 OFICINA CULIACAN",
            "MLM05 OFICINA MORELIA",
            "TRC06 OFICINA TORREON",
            "GDL07 CLIENTE RECOGE",
            "MTY08 OFICINA MONTERREY"});
            this.comboFiltro.Location = new System.Drawing.Point(525, 50);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(179, 24);
            this.comboFiltro.TabIndex = 7;
            this.comboFiltro.SelectedIndexChanged += new System.EventHandler(this.comboFiltro_SelectedIndexChanged);
            // 
            // btnParametros
            // 
            this.btnParametros.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnParametros.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnParametros.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.settings;
            this.btnParametros.Location = new System.Drawing.Point(929, 41);
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(125, 39);
            this.btnParametros.TabIndex = 6;
            this.btnParametros.Text = "Parámetros";
            this.btnParametros.Click += new System.EventHandler(this.btnParametros_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnExcel.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.xls__1_;
            this.btnExcel.Location = new System.Drawing.Point(1083, 41);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 39);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.AllowFocus = false;
            this.btnConsultar.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnConsultar.Appearance.Options.UseBorderColor = true;
            this.btnConsultar.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
            this.btnConsultar.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.btnConsultar.AppearanceHovered.Options.UseBackColor = true;
            this.btnConsultar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnConsultar.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.btnConsultar.AppearancePressed.Options.UseBorderColor = true;
            this.btnConsultar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnConsultar.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.gear;
            this.btnConsultar.Location = new System.Drawing.Point(319, 33);
            this.btnConsultar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(105, 56);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Inicio";
            // 
            // dateFin
            // 
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(169, 56);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.Mask.EditMask = "yyyyMMdd";
            this.dateFin.Size = new System.Drawing.Size(144, 22);
            this.dateFin.TabIndex = 1;
            // 
            // dateIni
            // 
            this.dateIni.EditValue = null;
            this.dateIni.Location = new System.Drawing.Point(5, 56);
            this.dateIni.Name = "dateIni";
            this.dateIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIni.Properties.Mask.EditMask = "yyyyMMdd";
            this.dateIni.Size = new System.Drawing.Size(144, 22);
            this.dateIni.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FacturasXEmbarcar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FacturasXEmbarcar";
            this.Size = new System.Drawing.Size(1170, 597);
            this.Load += new System.EventHandler(this.FacturasXEmbarcar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraEditors.DateEdit dateIni;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton btnParametros;
        private DevExpress.XtraGrid.Columns.GridColumn colPedido;
        private DevExpress.XtraGrid.Columns.GridColumn colCotizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colConsolidado;
        private DevExpress.XtraGrid.Columns.GridColumn colMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNota;
        private DevExpress.XtraGrid.Columns.GridColumn colCondicionPago;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colFormaEnvio;
        private DevExpress.XtraGrid.Columns.GridColumn colFletera;
        private DevExpress.XtraGrid.Columns.GridColumn colEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colEstadoEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colComentarioEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colEstadoFactura;
        private DevExpress.XtraGrid.Columns.GridColumn ComentarioFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaFleteXConfirmar;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colusuario;
        private DevExpress.XtraGrid.Columns.GridColumn colChofer;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn colDiasPermitidos;
        private DevExpress.XtraGrid.Columns.GridColumn colEstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDias;
        private DevExpress.XtraGrid.Columns.GridColumn coltotalEmbarques;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboFiltro;
    }
}
