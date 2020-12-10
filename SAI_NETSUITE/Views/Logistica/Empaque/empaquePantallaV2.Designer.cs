namespace SAI_NETSUITE.Views.Logistica.Empaque
{
    partial class empaquePantallaV2
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(empaquePantallaV2));
            this.colerror = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMESA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPedidos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFACTURAS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnFacturar = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelAvance = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnReimprimir = new DevExpress.XtraEditors.SimpleButton();
            this.txtReimprimir = new DevExpress.XtraEditors.TextEdit();
            this.backgroundWorkerEventos = new System.ComponentModel.BackgroundWorker();
            this.btnOleada = new DevExpress.XtraEditors.SimpleButton();
            this.labelRowCount = new System.Windows.Forms.Label();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.timerAutomatico = new System.Windows.Forms.Timer(this.components);
            this.btnPedidoFactura = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReimprimir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colerror
            // 
            this.colerror.Caption = "error";
            this.colerror.FieldName = "error";
            this.colerror.Name = "colerror";
            this.colerror.Visible = true;
            this.colerror.VisibleIndex = 6;
            this.colerror.Width = 425;
            // 
            // colMov
            // 
            this.colMov.Caption = "Mov";
            this.colMov.FieldName = "Mov";
            this.colMov.Name = "colMov";
            this.colMov.Visible = true;
            this.colMov.VisibleIndex = 1;
            this.colMov.Width = 95;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 73);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1357, 524);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Century Gothic", 10.8F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMov,
            this.colNumPedido,
            this.colForma,
            this.colMESA,
            this.gridColumn1,
            this.colPedidos,
            this.colFACTURAS,
            this.colerror});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colerror;
            gridFormatRule1.ColumnApplyTo = this.colerror;
            gridFormatRule1.Name = "Timbrar";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "Iif(Contains([error], \'TIMBRAR:\') Or Contains([error], \'Timbra las Facturas\'), Tr" +
    "ue, False)";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colMov;
            gridFormatRule2.Name = "Traspaso";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
            formatConditionRuleValue1.Expression = "Iif(Contains([Mov], \'Traspaso\'), True, False)";
            gridFormatRule2.Rule = formatConditionRuleValue1;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.colMov;
            gridFormatRule3.ColumnApplyTo = this.colMov;
            gridFormatRule3.Name = "cotizacion";
            formatConditionRuleExpression2.Expression = "Iif([Mov] = \'cotizacion\', True, False)";
            formatConditionRuleExpression2.PredefinedName = "Yellow Fill, Yellow Text";
            gridFormatRule3.Rule = formatConditionRuleExpression2;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Column = this.colerror;
            gridFormatRule4.ColumnApplyTo = this.colerror;
            gridFormatRule4.Name = "Terminados";
            formatConditionRuleExpression3.Expression = "Iif(Contains([error], \'Terminado\'), True, False)";
            formatConditionRuleExpression3.PredefinedName = "Green Fill, Green Text";
            gridFormatRule4.Rule = formatConditionRuleExpression3;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colNumPedido
            // 
            this.colNumPedido.Caption = "NumPedido";
            this.colNumPedido.FieldName = "NumPedido";
            this.colNumPedido.Name = "colNumPedido";
            this.colNumPedido.Visible = true;
            this.colNumPedido.VisibleIndex = 2;
            this.colNumPedido.Width = 188;
            // 
            // colForma
            // 
            this.colForma.Caption = "Forma";
            this.colForma.FieldName = "Forma";
            this.colForma.Name = "colForma";
            this.colForma.Visible = true;
            this.colForma.VisibleIndex = 3;
            this.colForma.Width = 220;
            // 
            // colMESA
            // 
            this.colMESA.Caption = "Mesa";
            this.colMESA.FieldName = "MESA";
            this.colMESA.Name = "colMESA";
            this.colMESA.Visible = true;
            this.colMESA.VisibleIndex = 5;
            this.colMESA.Width = 163;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PedidosFactura";
            this.gridColumn1.FieldName = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.UnboundExpression = "ToStr([#FACTURAS]) + \' de \' + ToStr([#Pedidos])";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 96;
            // 
            // colPedidos
            // 
            this.colPedidos.Caption = "#Pedidos";
            this.colPedidos.FieldName = "#Pedidos";
            this.colPedidos.Name = "colPedidos";
            // 
            // colFACTURAS
            // 
            this.colFACTURAS.Caption = "#FACTURAS";
            this.colFACTURAS.FieldName = "#FACTURAS";
            this.colFACTURAS.Name = "colFACTURAS";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Appearance.Options.UseBackColor = true;
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(23, 23);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnActualizar.Size = new System.Drawing.Size(120, 32);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturar.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnFacturar.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Appearance.Options.UseBackColor = true;
            this.btnFacturar.Appearance.Options.UseFont = true;
            this.btnFacturar.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnFacturar.AppearanceHovered.Options.UseBorderColor = true;
            this.btnFacturar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnFacturar.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.gear;
            this.btnFacturar.Location = new System.Drawing.Point(1222, 23);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnFacturar.Size = new System.Drawing.Size(135, 32);
            this.btnFacturar.TabIndex = 2;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // labelAvance
            // 
            this.labelAvance.AutoSize = true;
            this.labelAvance.Location = new System.Drawing.Point(1148, 31);
            this.labelAvance.Name = "labelAvance";
            this.labelAvance.Size = new System.Drawing.Size(28, 17);
            this.labelAvance.TabIndex = 4;
            this.labelAvance.Text = "0/0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioGroup1);
            this.groupBox1.Controls.Add(this.btnReimprimir);
            this.groupBox1.Controls.Add(this.txtReimprimir);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(149, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 58);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reimprimir";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(6, 16);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Factura"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "ConsXXX"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Coti")});
            this.radioGroup1.Size = new System.Drawing.Size(211, 35);
            this.radioGroup1.TabIndex = 10;
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReimprimir.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnReimprimir.Appearance.Options.UseBackColor = true;
            this.btnReimprimir.Appearance.Options.UseFont = true;
            this.btnReimprimir.Appearance.Options.UseForeColor = true;
            this.btnReimprimir.AppearanceHovered.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnReimprimir.AppearanceHovered.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimir.AppearanceHovered.Options.UseBackColor = true;
            this.btnReimprimir.AppearanceHovered.Options.UseFont = true;
            this.btnReimprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnReimprimir.Location = new System.Drawing.Point(344, 14);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(75, 23);
            this.btnReimprimir.TabIndex = 1;
            this.btnReimprimir.Text = "IMPRIMIR";
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // txtReimprimir
            // 
            this.txtReimprimir.Location = new System.Drawing.Point(223, 15);
            this.txtReimprimir.Name = "txtReimprimir";
            this.txtReimprimir.Properties.Mask.EditMask = "f";
            this.txtReimprimir.Size = new System.Drawing.Size(115, 22);
            this.txtReimprimir.TabIndex = 0;
            // 
            // backgroundWorkerEventos
            // 
            this.backgroundWorkerEventos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerEventos_DoWork);
            this.backgroundWorkerEventos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerEventos_RunWorkerCompleted);
            // 
            // btnOleada
            // 
            this.btnOleada.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnOleada.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOleada.ImageOptions.Image")));
            this.btnOleada.Location = new System.Drawing.Point(602, 31);
            this.btnOleada.Name = "btnOleada";
            this.btnOleada.Size = new System.Drawing.Size(88, 36);
            this.btnOleada.TabIndex = 6;
            this.btnOleada.Text = "Oleadas";
            this.btnOleada.Click += new System.EventHandler(this.btnOleada_Click);
            // 
            // labelRowCount
            // 
            this.labelRowCount.AutoSize = true;
            this.labelRowCount.Location = new System.Drawing.Point(697, 43);
            this.labelRowCount.Name = "labelRowCount";
            this.labelRowCount.Size = new System.Drawing.Size(46, 17);
            this.labelRowCount.TabIndex = 7;
            this.labelRowCount.Text = "label1";
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(1000, 31);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.toggleSwitch1.Properties.OffText = "Apagado";
            this.toggleSwitch1.Properties.OnText = "Encendido";
            this.toggleSwitch1.Size = new System.Drawing.Size(142, 26);
            this.toggleSwitch1.TabIndex = 8;
            this.toggleSwitch1.Visible = false;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(997, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Automatico";
            this.label1.Visible = false;
            // 
            // timerAutomatico
            // 
            this.timerAutomatico.Interval = 120000;
            this.timerAutomatico.Tick += new System.EventHandler(this.timerAutomatico_Tick);
            // 
            // btnPedidoFactura
            // 
            this.btnPedidoFactura.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPedidoFactura.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPedidoFactura.ImageOptions.Image")));
            this.btnPedidoFactura.Location = new System.Drawing.Point(856, 23);
            this.btnPedidoFactura.Name = "btnPedidoFactura";
            this.btnPedidoFactura.Size = new System.Drawing.Size(135, 37);
            this.btnPedidoFactura.TabIndex = 10;
            this.btnPedidoFactura.Text = "Pedido/Factura";
            this.btnPedidoFactura.Click += new System.EventHandler(this.btnPedidoFactura_Click);
            // 
            // empaquePantallaV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPedidoFactura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.labelRowCount);
            this.Controls.Add(this.btnOleada);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelAvance);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.gridControl1);
            this.Name = "empaquePantallaV2";
            this.Size = new System.Drawing.Size(1360, 600);
            this.Load += new System.EventHandler(this.empaquePantallaV2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReimprimir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraGrid.Columns.GridColumn colMov;
        private DevExpress.XtraGrid.Columns.GridColumn colNumPedido;
        private DevExpress.XtraGrid.Columns.GridColumn colForma;
        private DevExpress.XtraGrid.Columns.GridColumn colMESA;
        private DevExpress.XtraGrid.Columns.GridColumn colPedidos;
        private DevExpress.XtraGrid.Columns.GridColumn colFACTURAS;
        private DevExpress.XtraGrid.Columns.GridColumn colerror;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnFacturar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelAvance;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnReimprimir;
        private DevExpress.XtraEditors.TextEdit txtReimprimir;
        private System.ComponentModel.BackgroundWorker backgroundWorkerEventos;
        private DevExpress.XtraEditors.SimpleButton btnOleada;
        private System.Windows.Forms.Label labelRowCount;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerAutomatico;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton btnPedidoFactura;
    }
}
