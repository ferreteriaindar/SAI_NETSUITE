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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(empaquePantalla));
            this.colPorcentajeBultos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colerror = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTIEMPO_100 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPedido = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPDF = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colPorcentajeBultos
            // 
            this.colPorcentajeBultos.Caption = "PORCENTAJE BULTOS";
            this.colPorcentajeBultos.FieldName = "PORCENTAJE_BULTOS";
            this.colPorcentajeBultos.Name = "colPorcentajeBultos";
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
            gridFormatRule1.Column = this.colPorcentajeBultos;
            gridFormatRule1.ColumnApplyTo = this.colPorcentajeBultos;
            gridFormatRule1.Name = "ruleBultos%";
            formatConditionRuleValue1.PredefinedName = "Green Fill, Green Text";
            formatConditionRuleValue1.Value1 = 100;
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
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.PredefinedName = "Strikeout Text";
            formatConditionRuleValue2.Value1 = "CFDI TIMBRAR";
            gridFormatRule4.Rule = formatConditionRuleValue2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.RowHeight = 15;
            // 
            // colTIEMPO_100
            // 
            this.colTIEMPO_100.Caption = "TIEMPO_100";
            this.colTIEMPO_100.FieldName = "TIEMPO_100";
            this.colTIEMPO_100.Name = "colTIEMPO_100";
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
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(185, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nomenclatura";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(200, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Retrasado";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.LightGreen;
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(105, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Listo Facturar";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Timbrar CDFI";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Appearance.Options.UseFont = true;
            this.btnPDF.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPDF.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.printviapdf_16x161;
            this.btnPDF.Location = new System.Drawing.Point(865, 18);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(132, 30);
            this.btnPDF.TabIndex = 6;
            this.btnPDF.Text = "PDF";
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // empaquePantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnPDF;
    }
}
