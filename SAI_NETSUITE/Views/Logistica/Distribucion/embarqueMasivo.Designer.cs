namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    partial class embarqueMasivo
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnConsultaFactura = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFactura = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTRANSACTION_NUMBER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcompanyid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFORMAENVIO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAQUETERIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.searchPaqueteria = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchEmpleado = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpleadoNAme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpleadoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEmbarcar = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumEmbarque = new DevExpress.XtraEditors.TextEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPaqueteria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumEmbarque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Controls.Add(this.btnConsultaFactura);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtFactura);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(290, 110);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Controles";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::SAI_NETSUITE.Properties.Resources._835;
            this.pictureEdit1.Location = new System.Drawing.Point(183, 77);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(46, 28);
            this.pictureEdit1.TabIndex = 3;
            // 
            // btnConsultaFactura
            // 
            this.btnConsultaFactura.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaFactura.Appearance.Options.UseFont = true;
            this.btnConsultaFactura.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnConsultaFactura.Location = new System.Drawing.Point(102, 77);
            this.btnConsultaFactura.Name = "btnConsultaFactura";
            this.btnConsultaFactura.Size = new System.Drawing.Size(75, 23);
            this.btnConsultaFactura.TabIndex = 2;
            this.btnConsultaFactura.Text = "Consultar";
            this.btnConsultaFactura.Click += new System.EventHandler(this.btnConsultaFactura_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Factura";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(5, 49);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(280, 22);
            this.txtFactura.TabIndex = 0;
            this.txtFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFactura_KeyPress);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(299, 3);
            this.gridControl1.MainView = this.GridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(828, 551);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // GridView1
            // 
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTRANSACTION_NUMBER,
            this.colcompanyid,
            this.colCREATE_DATE,
            this.colFORMAENVIO,
            this.colPAQUETERIA});
            this.GridView1.GridControl = this.gridControl1;
            this.GridView1.Name = "GridView1";
            // 
            // colTRANSACTION_NUMBER
            // 
            this.colTRANSACTION_NUMBER.Caption = "Factura";
            this.colTRANSACTION_NUMBER.FieldName = "TRANSACTION_NUMBER";
            this.colTRANSACTION_NUMBER.Name = "colTRANSACTION_NUMBER";
            this.colTRANSACTION_NUMBER.Visible = true;
            this.colTRANSACTION_NUMBER.VisibleIndex = 0;
            // 
            // colcompanyid
            // 
            this.colcompanyid.Caption = "Cliente";
            this.colcompanyid.FieldName = "companyid";
            this.colcompanyid.Name = "colcompanyid";
            this.colcompanyid.Visible = true;
            this.colcompanyid.VisibleIndex = 1;
            // 
            // colCREATE_DATE
            // 
            this.colCREATE_DATE.Caption = "FECHA";
            this.colCREATE_DATE.FieldName = "CREATE_DATE";
            this.colCREATE_DATE.Name = "colCREATE_DATE";
            this.colCREATE_DATE.Visible = true;
            this.colCREATE_DATE.VisibleIndex = 2;
            // 
            // colFORMAENVIO
            // 
            this.colFORMAENVIO.Caption = "FormaEnvio";
            this.colFORMAENVIO.FieldName = "FORMAENVIO";
            this.colFORMAENVIO.Name = "colFORMAENVIO";
            this.colFORMAENVIO.Visible = true;
            this.colFORMAENVIO.VisibleIndex = 3;
            // 
            // colPAQUETERIA
            // 
            this.colPAQUETERIA.Caption = "Paqueteria";
            this.colPAQUETERIA.FieldName = "PAQUETERIA";
            this.colPAQUETERIA.Name = "colPAQUETERIA";
            this.colPAQUETERIA.Visible = true;
            this.colPAQUETERIA.VisibleIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.searchPaqueteria);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.txtComentarios);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.searchEmpleado);
            this.groupControl2.Controls.Add(this.btnEmbarcar);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Location = new System.Drawing.Point(3, 119);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(290, 282);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Asignar Chofer";
            // 
            // searchPaqueteria
            // 
            this.searchPaqueteria.Location = new System.Drawing.Point(6, 95);
            this.searchPaqueteria.Name = "searchPaqueteria";
            this.searchPaqueteria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchPaqueteria.Properties.DisplayMember = "LIST_ITEM_NAME";
            this.searchPaqueteria.Properties.PopupView = this.gridView2;
            this.searchPaqueteria.Properties.ValueMember = "LIST_ID";
            this.searchPaqueteria.Size = new System.Drawing.Size(275, 22);
            this.searchPaqueteria.TabIndex = 8;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.searchPaqueteria, conditionValidationRule1);
            this.searchPaqueteria.EditValueChanged += new System.EventHandler(this.searchLookUpEdit1_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fletera";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(5, 195);
            this.txtComentarios.MaxLength = 249;
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(279, 82);
            this.txtComentarios.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Comentarios";
            // 
            // searchEmpleado
            // 
            this.searchEmpleado.Location = new System.Drawing.Point(6, 48);
            this.searchEmpleado.Name = "searchEmpleado";
            this.searchEmpleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchEmpleado.Properties.DisplayMember = "nombre";
            this.searchEmpleado.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchEmpleado.Properties.ValueMember = "id";
            this.searchEmpleado.Size = new System.Drawing.Size(279, 22);
            this.searchEmpleado.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.searchEmpleado, conditionValidationRule2);
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
            // btnEmbarcar
            // 
            this.btnEmbarcar.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmbarcar.Appearance.Options.UseFont = true;
            this.btnEmbarcar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnEmbarcar.Location = new System.Drawing.Point(102, 123);
            this.btnEmbarcar.Name = "btnEmbarcar";
            this.btnEmbarcar.Size = new System.Drawing.Size(75, 23);
            this.btnEmbarcar.TabIndex = 3;
            this.btnEmbarcar.Text = "Embarcar";
            this.btnEmbarcar.Click += new System.EventHandler(this.btnEmbarcar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chofer";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnImprimir);
            this.groupControl3.Controls.Add(this.label3);
            this.groupControl3.Controls.Add(this.txtNumEmbarque);
            this.groupControl3.Location = new System.Drawing.Point(3, 407);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(290, 81);
            this.groupControl3.TabIndex = 4;
            this.groupControl3.Text = "Re-Imprimir Embarque";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Appearance.Options.UseFont = true;
            this.btnImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnImprimir.Location = new System.Drawing.Point(210, 46);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Num. Embarque";
            // 
            // txtNumEmbarque
            // 
            this.txtNumEmbarque.Location = new System.Drawing.Point(5, 47);
            this.txtNumEmbarque.Name = "txtNumEmbarque";
            this.txtNumEmbarque.Properties.Mask.EditMask = "n0";
            this.txtNumEmbarque.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumEmbarque.Size = new System.Drawing.Size(199, 22);
            this.txtNumEmbarque.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // embarqueMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "embarqueMasivo";
            this.Size = new System.Drawing.Size(1130, 557);
            this.Load += new System.EventHandler(this.embarqueMasivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPaqueteria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumEmbarque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultaFactura;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtFactura;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnEmbarcar;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtNumEmbarque;
        private DevExpress.XtraGrid.Columns.GridColumn colTRANSACTION_NUMBER;
        private DevExpress.XtraGrid.Columns.GridColumn colcompanyid;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colFORMAENVIO;
        private DevExpress.XtraGrid.Columns.GridColumn colPAQUETERIA;
        private DevExpress.XtraEditors.SearchLookUpEdit searchEmpleado;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpleadoNAme;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpleadoId;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchPaqueteria;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label label5;
    }
}
