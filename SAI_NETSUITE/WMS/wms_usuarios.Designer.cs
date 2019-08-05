namespace SAI_NETSUITE.WMS
{
    partial class wms_usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wms_usuarios));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecibo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALmacenado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTraspaso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupervisorf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnGenerarCredencial = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnNuevoUsuarios = new DevExpress.XtraEditors.SimpleButton();
            this.checkNuevoAcomodo = new DevExpress.XtraEditors.CheckEdit();
            this.checkNuevoRecibo = new DevExpress.XtraEditors.CheckEdit();
            this.checkNuevoSupervisor = new DevExpress.XtraEditors.CheckEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNuevoPass = new DevExpress.XtraEditors.TextEdit();
            this.txtNuevoNumEMP = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevoUsuarios = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkNuevoAcomodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNuevoRecibo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNuevoSupervisor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoNumEMP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoUsuarios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(721, 639);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre,
            this.colUsuario,
            this.colRecibo,
            this.colALmacenado,
            this.colTraspaso,
            this.colSupervisorf});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "ColUsuario";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 2;
            // 
            // colRecibo
            // 
            this.colRecibo.Caption = "Recibo";
            this.colRecibo.FieldName = "recibo";
            this.colRecibo.Name = "colRecibo";
            this.colRecibo.Visible = true;
            this.colRecibo.VisibleIndex = 3;
            // 
            // colALmacenado
            // 
            this.colALmacenado.Caption = "Almacenado";
            this.colALmacenado.FieldName = "almacenado";
            this.colALmacenado.Name = "colALmacenado";
            this.colALmacenado.Visible = true;
            this.colALmacenado.VisibleIndex = 4;
            // 
            // colTraspaso
            // 
            this.colTraspaso.Caption = "Traspaso";
            this.colTraspaso.FieldName = "traspaso";
            this.colTraspaso.Name = "colTraspaso";
            this.colTraspaso.Visible = true;
            this.colTraspaso.VisibleIndex = 5;
            // 
            // colSupervisorf
            // 
            this.colSupervisorf.Caption = "Supervisor";
            this.colSupervisorf.FieldName = "Supervisor";
            this.colSupervisorf.Name = "colSupervisorf";
            this.colSupervisorf.Visible = true;
            this.colSupervisorf.VisibleIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnGenerarCredencial);
            this.groupControl1.Location = new System.Drawing.Point(731, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(370, 100);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "CONTROLES";
            // 
            // btnGenerarCredencial
            // 
            this.btnGenerarCredencial.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarCredencial.Image")));
            this.btnGenerarCredencial.Location = new System.Drawing.Point(5, 37);
            this.btnGenerarCredencial.Name = "btnGenerarCredencial";
            this.btnGenerarCredencial.Size = new System.Drawing.Size(105, 44);
            this.btnGenerarCredencial.TabIndex = 0;
            this.btnGenerarCredencial.Text = "m ";
            this.btnGenerarCredencial.Click += new System.EventHandler(this.btnGenerarCredencial_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnNuevoUsuarios);
            this.groupControl2.Controls.Add(this.checkNuevoAcomodo);
            this.groupControl2.Controls.Add(this.checkNuevoRecibo);
            this.groupControl2.Controls.Add(this.checkNuevoSupervisor);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.txtNuevoPass);
            this.groupControl2.Controls.Add(this.txtNuevoNumEMP);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.txtNuevoUsuarios);
            this.groupControl2.Location = new System.Drawing.Point(731, 435);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(365, 207);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "NUEVO USUARIO";
            // 
            // btnNuevoUsuarios
            // 
            this.btnNuevoUsuarios.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnNuevoUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoUsuarios.Image")));
            this.btnNuevoUsuarios.Location = new System.Drawing.Point(257, 126);
            this.btnNuevoUsuarios.Name = "btnNuevoUsuarios";
            this.btnNuevoUsuarios.Size = new System.Drawing.Size(103, 56);
            this.btnNuevoUsuarios.TabIndex = 9;
            this.btnNuevoUsuarios.Text = "Generar \r\nUsuario\r\n";
            this.btnNuevoUsuarios.Click += new System.EventHandler(this.btnNuevoUsuarios_Click);
            // 
            // checkNuevoAcomodo
            // 
            this.checkNuevoAcomodo.Location = new System.Drawing.Point(8, 170);
            this.checkNuevoAcomodo.Name = "checkNuevoAcomodo";
            this.checkNuevoAcomodo.Properties.Caption = "Acomodo";
            this.checkNuevoAcomodo.Size = new System.Drawing.Size(84, 20);
            this.checkNuevoAcomodo.TabIndex = 8;
            // 
            // checkNuevoRecibo
            // 
            this.checkNuevoRecibo.Location = new System.Drawing.Point(8, 144);
            this.checkNuevoRecibo.Name = "checkNuevoRecibo";
            this.checkNuevoRecibo.Properties.Caption = "Recibo";
            this.checkNuevoRecibo.Size = new System.Drawing.Size(75, 20);
            this.checkNuevoRecibo.TabIndex = 7;
            // 
            // checkNuevoSupervisor
            // 
            this.checkNuevoSupervisor.Location = new System.Drawing.Point(8, 118);
            this.checkNuevoSupervisor.Name = "checkNuevoSupervisor";
            this.checkNuevoSupervisor.Properties.Caption = "Supervisor";
            this.checkNuevoSupervisor.Size = new System.Drawing.Size(98, 20);
            this.checkNuevoSupervisor.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Num Empleado";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNuevoPass
            // 
            this.txtNuevoPass.Location = new System.Drawing.Point(183, 89);
            this.txtNuevoPass.Name = "txtNuevoPass";
            this.txtNuevoPass.Size = new System.Drawing.Size(177, 22);
            this.txtNuevoPass.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtNuevoPass, conditionValidationRule1);
            // 
            // txtNuevoNumEMP
            // 
            this.txtNuevoNumEMP.Location = new System.Drawing.Point(8, 89);
            this.txtNuevoNumEMP.Name = "txtNuevoNumEMP";
            this.txtNuevoNumEMP.Size = new System.Drawing.Size(100, 22);
            this.txtNuevoNumEMP.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtNuevoNumEMP, conditionValidationRule2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // txtNuevoUsuarios
            // 
            this.txtNuevoUsuarios.Location = new System.Drawing.Point(6, 48);
            this.txtNuevoUsuarios.Name = "txtNuevoUsuarios";
            this.txtNuevoUsuarios.Size = new System.Drawing.Size(354, 22);
            this.txtNuevoUsuarios.TabIndex = 0;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txtNuevoUsuarios, conditionValidationRule3);
            // 
            // wms_usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "wms_usuarios";
            this.Size = new System.Drawing.Size(1104, 645);
            this.Load += new System.EventHandler(this.wms_usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkNuevoAcomodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNuevoRecibo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNuevoSupervisor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoNumEMP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoUsuarios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colRecibo;
        private DevExpress.XtraGrid.Columns.GridColumn colALmacenado;
        private DevExpress.XtraGrid.Columns.GridColumn colTraspaso;
        private DevExpress.XtraGrid.Columns.GridColumn colSupervisorf;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnGenerarCredencial;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnNuevoUsuarios;
        private DevExpress.XtraEditors.CheckEdit checkNuevoAcomodo;
        private DevExpress.XtraEditors.CheckEdit checkNuevoRecibo;
        private DevExpress.XtraEditors.CheckEdit checkNuevoSupervisor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtNuevoPass;
        private DevExpress.XtraEditors.TextEdit txtNuevoNumEMP;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtNuevoUsuarios;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}
