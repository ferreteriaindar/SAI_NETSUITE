namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    partial class empaquePantalla
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(empaquePantalla));
            this.colerror = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcentajeBultos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTIEMPO_100 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPedidos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacturas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacturas1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaTermino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBultos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFORMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMESA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESTINO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMesaUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReimprimir = new DevExpress.XtraEditors.SimpleButton();
            this.txtReimprimir = new DevExpress.XtraEditors.TextEdit();
            this.comboReimprmir = new System.Windows.Forms.ComboBox();
            this.backgroundWorkerEventos = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReimprimir.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colerror
            // 
            this.colerror.Caption = "ERROR";
            this.colerror.FieldName = "error";
            this.colerror.Name = "colerror";
            this.colerror.Visible = true;
            this.colerror.VisibleIndex = 7;
            this.colerror.Width = 168;
            // 
            // colPorcentajeBultos
            // 
            this.colPorcentajeBultos.Caption = "PORCENTAJE BULTOS";
            this.colPorcentajeBultos.FieldName = "PORCENTAJE_BULTOS";
            this.colPorcentajeBultos.Name = "colPorcentajeBultos";
            // 
            // colPedido
            // 
            this.colPedido.Caption = "Pedido";
            this.colPedido.FieldName = "Pedido";
            this.colPedido.Name = "colPedido";
            this.colPedido.Visible = true;
            this.colPedido.VisibleIndex = 0;
            this.colPedido.Width = 150;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 64);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1243, 468);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTIEMPO_100,
            this.colPedido,
            this.colMovId,
            this.colPedidos,
            this.colFacturas,
            this.colFacturas1,
            this.colResult,
            this.colFechaTermino,
            this.colEstatus,
            this.colPorcentajeBultos,
            this.colBultos,
            this.colUbicacion,
            this.colFORMA,
            this.colMESA,
            this.colDESTINO,
            this.colUsuario,
            this.colMesaUsuario,
            this.colerror});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colerror;
            gridFormatRule1.ColumnApplyTo = this.colerror;
            gridFormatRule1.Name = "ruleImprimir";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "Iif(Contains([error], \'Imprime\'), True, False)";
            formatConditionRuleValue1.PredefinedName = "Green Fill, Green Text";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colPorcentajeBultos;
            gridFormatRule2.Name = "rulWarning";
            formatConditionRuleExpression1.Expression = "Iif([PORCENTAJE_BULTOS] = 100 And [TIEMPO_100] Between(5, 10), True, False)";
            formatConditionRuleExpression1.PredefinedName = "Yellow Fill, Yellow Text";
            gridFormatRule2.Rule = formatConditionRuleExpression1;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.colPorcentajeBultos;
            gridFormatRule3.ColumnApplyTo = this.colPorcentajeBultos;
            gridFormatRule3.Name = "ruleDANGER";
            formatConditionRuleExpression2.Expression = "Iif([PORCENTAJE_BULTOS] = 100 And [TIEMPO_100] > 10, True, False)";
            formatConditionRuleExpression2.PredefinedName = "Red Fill, Red Text";
            gridFormatRule3.Rule = formatConditionRuleExpression2;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Column = this.colerror;
            gridFormatRule4.ColumnApplyTo = this.colerror;
            gridFormatRule4.Name = "ruleCFDI";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            formatConditionRuleValue2.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Blue;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseFont = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue2.Expression = "Iif(Contains([error], \'TIMBRAR\'), True, False)";
            formatConditionRuleValue2.PredefinedName = "Strikeout Text";
            formatConditionRuleValue2.Value1 = "CFDI TIMBRAR";
            gridFormatRule4.Rule = formatConditionRuleValue2;
            gridFormatRule5.ApplyToRow = true;
            gridFormatRule5.Column = this.colPedido;
            gridFormatRule5.ColumnApplyTo = this.colPedido;
            gridFormatRule5.Name = "Traspasos";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = "Traspaso";
            gridFormatRule5.Rule = formatConditionRuleValue3;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
            this.gridView1.FormatRules.Add(gridFormatRule5);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.RowHeight = 15;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colTIEMPO_100
            // 
            this.colTIEMPO_100.Caption = "TIEMPO_100";
            this.colTIEMPO_100.FieldName = "TIEMPO_100";
            this.colTIEMPO_100.Name = "colTIEMPO_100";
            // 
            // colMovId
            // 
            this.colMovId.Caption = "MovId";
            this.colMovId.FieldName = "MovId";
            this.colMovId.Name = "colMovId";
            this.colMovId.Visible = true;
            this.colMovId.VisibleIndex = 1;
            this.colMovId.Width = 158;
            // 
            // colPedidos
            // 
            this.colPedidos.Caption = "#PEDIDOS";
            this.colPedidos.FieldName = "#PEDIDOS";
            this.colPedidos.Name = "colPedidos";
            // 
            // colFacturas
            // 
            this.colFacturas.Caption = "#FACTURAS";
            this.colFacturas.FieldName = "#FACTURAS";
            this.colFacturas.Name = "colFacturas";
            this.colFacturas.Visible = true;
            this.colFacturas.VisibleIndex = 3;
            this.colFacturas.Width = 227;
            // 
            // colFacturas1
            // 
            this.colFacturas1.Caption = "FACTURAS1";
            this.colFacturas1.FieldName = "FACTURAS1";
            this.colFacturas1.Name = "colFacturas1";
            // 
            // colResult
            // 
            this.colResult.Caption = "RESULT";
            this.colResult.FieldName = "RESULT";
            this.colResult.Name = "colResult";
            // 
            // colFechaTermino
            // 
            this.colFechaTermino.Caption = "FECHA_TERMINO";
            this.colFechaTermino.FieldName = "FECHA_TERMINO";
            this.colFechaTermino.Name = "colFechaTermino";
            // 
            // colEstatus
            // 
            this.colEstatus.Caption = "Estatus";
            this.colEstatus.FieldName = "Estatus";
            this.colEstatus.Name = "colEstatus";
            // 
            // colBultos
            // 
            this.colBultos.Caption = "BULTOS";
            this.colBultos.FieldName = "BULTOS";
            this.colBultos.Name = "colBultos";
            this.colBultos.Visible = true;
            this.colBultos.VisibleIndex = 5;
            this.colBultos.Width = 84;
            // 
            // colUbicacion
            // 
            this.colUbicacion.Caption = "Ubicacion";
            this.colUbicacion.FieldName = "Ubicacion";
            this.colUbicacion.Name = "colUbicacion";
            // 
            // colFORMA
            // 
            this.colFORMA.Caption = "FORMA";
            this.colFORMA.FieldName = "FORMA";
            this.colFORMA.Name = "colFORMA";
            this.colFORMA.Visible = true;
            this.colFORMA.VisibleIndex = 2;
            this.colFORMA.Width = 449;
            // 
            // colMESA
            // 
            this.colMESA.Caption = "MESA";
            this.colMESA.FieldName = "MESA";
            this.colMESA.Name = "colMESA";
            // 
            // colDESTINO
            // 
            this.colDESTINO.Caption = "DESTINO";
            this.colDESTINO.FieldName = "DESTINO";
            this.colDESTINO.Name = "colDESTINO";
            this.colDESTINO.Visible = true;
            this.colDESTINO.VisibleIndex = 6;
            this.colDESTINO.Width = 97;
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Name = "colUsuario";
            // 
            // colMesaUsuario
            // 
            this.colMesaUsuario.Caption = "MESA-Usuario";
            this.colMesaUsuario.FieldName = "colMesaUsuario";
            this.colMesaUsuario.Name = "colMesaUsuario";
            this.colMesaUsuario.UnboundExpression = "Concat(ToStr([MESA]), Concat(\' -\', [Usuario]))";
            this.colMesaUsuario.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colMesaUsuario.Visible = true;
            this.colMesaUsuario.VisibleIndex = 4;
            this.colMesaUsuario.Width = 244;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(23, 18);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(132, 30);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(1064, 18);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(160, 30);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Completar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::SAI_NETSUITE.Properties.Resources._835;
            this.pictureBox.Location = new System.Drawing.Point(1026, 28);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(20, 20);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(943, 29);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(45, 19);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Inicio";
            this.labelStatus.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReimprimir);
            this.groupBox2.Controls.Add(this.txtReimprimir);
            this.groupBox2.Controls.Add(this.comboReimprmir);
            this.groupBox2.Location = new System.Drawing.Point(173, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 50);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reimprimir Bulto/Packing";
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnReimprimir.Location = new System.Drawing.Point(196, 19);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(75, 23);
            this.btnReimprimir.TabIndex = 2;
            this.btnReimprimir.Text = "Imprimir";
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // txtReimprimir
            // 
            this.txtReimprimir.Location = new System.Drawing.Point(90, 19);
            this.txtReimprimir.Name = "txtReimprimir";
            this.txtReimprimir.Size = new System.Drawing.Size(100, 22);
            this.txtReimprimir.TabIndex = 1;
            // 
            // comboReimprmir
            // 
            this.comboReimprmir.FormattingEnabled = true;
            this.comboReimprmir.Items.AddRange(new object[] {
            "FACTURA",
            "CONS"});
            this.comboReimprmir.Location = new System.Drawing.Point(7, 19);
            this.comboReimprmir.Name = "comboReimprmir";
            this.comboReimprmir.Size = new System.Drawing.Size(77, 24);
            this.comboReimprmir.TabIndex = 0;
            // 
            // backgroundWorkerEventos
            // 
            this.backgroundWorkerEventos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerEventos_DoWork);
            this.backgroundWorkerEventos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerEventos_RunWorkerCompleted);
            // 
            // empaquePantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.gridControl1);
            this.Name = "empaquePantalla";
            this.Size = new System.Drawing.Size(1243, 532);
            this.Load += new System.EventHandler(this.empaquePantalla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtReimprimir.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTIEMPO_100;
        private DevExpress.XtraGrid.Columns.GridColumn colPedido;
        private DevExpress.XtraGrid.Columns.GridColumn colMovId;
        private DevExpress.XtraGrid.Columns.GridColumn colPedidos;
        private DevExpress.XtraGrid.Columns.GridColumn colFacturas;
        private DevExpress.XtraGrid.Columns.GridColumn colFacturas1;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaTermino;
        private DevExpress.XtraGrid.Columns.GridColumn colEstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcentajeBultos;
        private DevExpress.XtraGrid.Columns.GridColumn colBultos;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFORMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMESA;
        private DevExpress.XtraGrid.Columns.GridColumn colDESTINO;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colMesaUsuario;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.Columns.GridColumn colerror;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnReimprimir;
        private DevExpress.XtraEditors.TextEdit txtReimprimir;
        private System.Windows.Forms.ComboBox comboReimprmir;
        private System.ComponentModel.BackgroundWorker backgroundWorkerEventos;
    }
}
