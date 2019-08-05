namespace SAI_NETSUITE.WMS.Empaque
{
    partial class empaque
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(empaque));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPorPedido = new DevExpress.XtraEditors.SimpleButton();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnCaja = new DevExpress.XtraEditors.SimpleButton();
            this.btnEmbarque = new DevExpress.XtraEditors.SimpleButton();
            this.labelPP = new System.Windows.Forms.Label();
            this.labelPF = new System.Windows.Forms.Label();
            this.btnInfoPedido = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetallePedido = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new DevExpress.XtraEditors.TextEdit();
            this.labelPedido = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colArticulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarras.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btnPorPedido);
            this.groupControl1.Controls.Add(this.searchLookUpEdit1);
            this.groupControl1.Location = new System.Drawing.Point(3, 4);
            this.groupControl1.LookAndFeel.SkinName = "Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1096, 75);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Ordenes de Empaque";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista Pedidos";
            // 
            // btnPorPedido
            // 
            this.btnPorPedido.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPorPedido.Location = new System.Drawing.Point(695, 47);
            this.btnPorPedido.LookAndFeel.SkinName = "Metropolis";
            this.btnPorPedido.Name = "btnPorPedido";
            this.btnPorPedido.Size = new System.Drawing.Size(90, 23);
            this.btnPorPedido.TabIndex = 1;
            this.btnPorPedido.Text = "Iniciar";
            this.btnPorPedido.Click += new System.EventHandler(this.btnPorPedido_Click);
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.EditValue = "Escanea la caja y/o Pedido";
            this.searchLookUpEdit1.Location = new System.Drawing.Point(15, 48);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(648, 23);
            this.searchLookUpEdit1.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.searchLookUpEdit1, conditionValidationRule1);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnCaja);
            this.groupControl2.Controls.Add(this.btnEmbarque);
            this.groupControl2.Controls.Add(this.labelPP);
            this.groupControl2.Controls.Add(this.labelPF);
            this.groupControl2.Controls.Add(this.btnInfoPedido);
            this.groupControl2.Controls.Add(this.btnDetallePedido);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.txtCodigoBarras);
            this.groupControl2.Controls.Add(this.labelPedido);
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(3, 85);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1096, 544);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Revisado de Empaque";
            this.groupControl2.Visible = false;
            // 
            // btnCaja
            // 
            this.btnCaja.Location = new System.Drawing.Point(733, 70);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(98, 38);
            this.btnCaja.TabIndex = 12;
            this.btnCaja.Text = "Etiqueta de\r\nCaja";
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // btnEmbarque
            // 
            this.btnEmbarque.Location = new System.Drawing.Point(916, 70);
            this.btnEmbarque.Name = "btnEmbarque";
            this.btnEmbarque.Size = new System.Drawing.Size(98, 38);
            this.btnEmbarque.TabIndex = 11;
            this.btnEmbarque.Text = "Listo para\r\nEmbarque";
            this.btnEmbarque.Click += new System.EventHandler(this.btnEmbarque_Click);
            // 
            // labelPP
            // 
            this.labelPP.AutoSize = true;
            this.labelPP.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPP.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelPP.Location = new System.Drawing.Point(976, 29);
            this.labelPP.Name = "labelPP";
            this.labelPP.Size = new System.Drawing.Size(38, 21);
            this.labelPP.TabIndex = 10;
            this.labelPP.Text = "PP:";
            // 
            // labelPF
            // 
            this.labelPF.AutoSize = true;
            this.labelPF.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPF.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelPF.Location = new System.Drawing.Point(904, 29);
            this.labelPF.Name = "labelPF";
            this.labelPF.Size = new System.Drawing.Size(37, 21);
            this.labelPF.TabIndex = 9;
            this.labelPF.Text = "PF:";
            // 
            // btnInfoPedido
            // 
            this.btnInfoPedido.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnInfoPedido.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoPedido.ImageOptions.Image")));
            this.btnInfoPedido.Location = new System.Drawing.Point(383, 29);
            this.btnInfoPedido.Name = "btnInfoPedido";
            this.btnInfoPedido.Size = new System.Drawing.Size(29, 23);
            this.btnInfoPedido.TabIndex = 8;
            this.btnInfoPedido.Click += new System.EventHandler(this.btnInfoPedido_Click);
            // 
            // btnDetallePedido
            // 
            this.btnDetallePedido.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnDetallePedido.Location = new System.Drawing.Point(353, 29);
            this.btnDetallePedido.Name = "btnDetallePedido";
            this.btnDetallePedido.Size = new System.Drawing.Size(24, 23);
            this.btnDetallePedido.TabIndex = 7;
            this.btnDetallePedido.Text = "...";
            this.btnDetallePedido.Click += new System.EventHandler(this.btnDetallePedido_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Codigo de Barras";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(8, 74);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Properties.Appearance.BorderColor = System.Drawing.Color.Black;
            this.txtCodigoBarras.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarras.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("txtCodigoBarras.Properties.Appearance.Image")));
            this.txtCodigoBarras.Properties.Appearance.Options.UseBorderColor = true;
            this.txtCodigoBarras.Properties.Appearance.Options.UseFont = true;
            this.txtCodigoBarras.Properties.Appearance.Options.UseImage = true;
            this.txtCodigoBarras.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCodigoBarras.Size = new System.Drawing.Size(383, 34);
            this.txtCodigoBarras.TabIndex = 2;
            this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress);
            // 
            // labelPedido
            // 
            this.labelPedido.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPedido.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelPedido.Appearance.Options.UseFont = true;
            this.labelPedido.Appearance.Options.UseForeColor = true;
            this.labelPedido.Location = new System.Drawing.Point(6, 29);
            this.labelPedido.Name = "labelPedido";
            this.labelPedido.Size = new System.Drawing.Size(120, 22);
            this.labelPedido.TabIndex = 1;
            this.labelPedido.Text = "labelControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 145);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1085, 394);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colArticulo,
            this.colDescripcion,
            this.colCantidad,
            this.colTotal});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // colArticulo
            // 
            this.colArticulo.Caption = "ARTICULO";
            this.colArticulo.FieldName = "ARTICULO";
            this.colArticulo.Name = "colArticulo";
            this.colArticulo.Visible = true;
            this.colArticulo.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "DESCRIPCION";
            this.colDescripcion.FieldName = "DESCRIPCION";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "CANTIDAD";
            this.colCantidad.FieldName = "CANTIDAD";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 2;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "total";
            this.colTotal.FieldName = "TOTAL";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 3;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // empaque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "empaque";
            this.Size = new System.Drawing.Size(1102, 632);
            this.Load += new System.EventHandler(this.empaque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarras.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnPorPedido;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnEmbarque;
        private System.Windows.Forms.Label labelPP;
        private System.Windows.Forms.Label labelPF;
        private DevExpress.XtraEditors.SimpleButton btnInfoPedido;
        private DevExpress.XtraEditors.SimpleButton btnDetallePedido;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtCodigoBarras;
        private DevExpress.XtraEditors.LabelControl labelPedido;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn colArticulo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.SimpleButton btnCaja;
    }
}
