﻿namespace SAI_NETSUITE.Views.Ventas.Apoyos
{
    partial class PedidoEstatusBO
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
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colquantitycommitted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtNumpedido = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstatusWMS = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCambiarBo = new DevExpress.XtraEditors.SimpleButton();
            this.txtFecha = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtestatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNombreCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedido = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colitem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colitemdescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colquantitybackordered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colalmacen2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colalmacen31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPedido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // colquantitycommitted
            // 
            this.colquantitycommitted.Caption = "Reservado";
            this.colquantitycommitted.FieldName = "quantitycommitted";
            this.colquantitycommitted.Name = "colquantitycommitted";
            this.colquantitycommitted.Visible = true;
            this.colquantitycommitted.VisibleIndex = 3;
            this.colquantitycommitted.Width = 144;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Right;
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.txtNumpedido);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txtEstatusWMS);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.txtTipo);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.btnCambiarBo);
            this.groupControl1.Controls.Add(this.txtFecha);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.txtestatus);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.TxtNombreCliente);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtPedido);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1288, 97);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Controles";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(999, 36);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 17;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.btnCambiarBo_Click);
            // 
            // txtNumpedido
            // 
            this.txtNumpedido.AutoSize = true;
            this.txtNumpedido.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumpedido.Location = new System.Drawing.Point(227, 34);
            this.txtNumpedido.Name = "txtNumpedido";
            this.txtNumpedido.Size = new System.Drawing.Size(69, 21);
            this.txtNumpedido.TabIndex = 16;
            this.txtNumpedido.Text = "Pedido";
            this.txtNumpedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(227, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "PEDIDO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(599, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "CLIENTE:";
            // 
            // txtEstatusWMS
            // 
            this.txtEstatusWMS.AutoSize = true;
            this.txtEstatusWMS.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstatusWMS.Location = new System.Drawing.Point(834, 38);
            this.txtEstatusWMS.Name = "txtEstatusWMS";
            this.txtEstatusWMS.Size = new System.Drawing.Size(69, 21);
            this.txtEstatusWMS.TabIndex = 13;
            this.txtEstatusWMS.Text = "Pedido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(697, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "ESTATUS WMS:";
            // 
            // txtTipo
            // 
            this.txtTipo.AutoSize = true;
            this.txtTipo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Location = new System.Drawing.Point(453, 70);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(69, 21);
            this.txtTipo.TabIndex = 11;
            this.txtTipo.Text = "Pedido";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(369, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "TIPO:";
            // 
            // btnCambiarBo
            // 
            this.btnCambiarBo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCambiarBo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCambiarBo.Enabled = false;
            this.btnCambiarBo.Location = new System.Drawing.Point(1095, 13);
            this.btnCambiarBo.Name = "btnCambiarBo";
            this.btnCambiarBo.Size = new System.Drawing.Size(151, 69);
            this.btnCambiarBo.TabIndex = 9;
            this.btnCambiarBo.Text = "Ingresar a WMS";
            this.btnCambiarBo.Click += new System.EventHandler(this.btnCambiarBo_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.AutoSize = true;
            this.txtFecha.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(683, 70);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(69, 21);
            this.txtFecha.TabIndex = 8;
            this.txtFecha.Text = "Pedido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(599, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "FECHA:";
            // 
            // txtestatus
            // 
            this.txtestatus.AutoSize = true;
            this.txtestatus.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtestatus.Location = new System.Drawing.Point(453, 38);
            this.txtestatus.Name = "txtestatus";
            this.txtestatus.Size = new System.Drawing.Size(69, 21);
            this.txtestatus.TabIndex = 6;
            this.txtestatus.Text = "Pedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "ESTATUS:";
            // 
            // TxtNombreCliente
            // 
            this.TxtNombreCliente.AutoSize = true;
            this.TxtNombreCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreCliente.Location = new System.Drawing.Point(453, 13);
            this.TxtNombreCliente.Name = "TxtNombreCliente";
            this.TxtNombreCliente.Size = new System.Drawing.Size(69, 21);
            this.TxtNombreCliente.TabIndex = 4;
            this.TxtNombreCliente.Text = "Pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(369, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "CLIENTE:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnConsultar.Location = new System.Drawing.Point(24, 57);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(130, 34);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pedido";
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(24, 33);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(130, 22);
            this.txtPedido.TabIndex = 0;
            this.txtPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPedido_KeyPress);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(4, 107);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1288, 458);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colitem,
            this.colitemid,
            this.colitemdescription,
            this.colquantity,
            this.colquantitycommitted,
            this.colquantitybackordered,
            this.colalmacen2,
            this.colalmacen31});
            gridFormatRule1.Column = this.colquantitycommitted;
            gridFormatRule1.ColumnApplyTo = this.colquantitycommitted;
            gridFormatRule1.Name = "VerdeTodoReservado";
            formatConditionRuleExpression1.Expression = "Iif([quantitycommitted] > 0 And [quantitybackordered] = 0, True, False)";
            formatConditionRuleExpression1.PredefinedName = "Green Fill, Green Text";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.Column = this.colquantitycommitted;
            gridFormatRule2.ColumnApplyTo = this.colquantitycommitted;
            gridFormatRule2.Name = "RojoBackOrdertodos";
            formatConditionRuleExpression2.Expression = "Iif([quantitycommitted] = 0 And [quantitybackordered] > 0, True, False)";
            formatConditionRuleExpression2.PredefinedName = "Red Fill, Red Text";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colitem
            // 
            this.colitem.Caption = "Articulo";
            this.colitem.FieldName = "item";
            this.colitem.Name = "colitem";
            this.colitem.Visible = true;
            this.colitem.VisibleIndex = 0;
            this.colitem.Width = 223;
            // 
            // colitemid
            // 
            this.colitemid.Caption = "itemid ";
            this.colitemid.FieldName = "itemid";
            this.colitemid.Name = "colitemid";
            // 
            // colitemdescription
            // 
            this.colitemdescription.Caption = "Descripcion";
            this.colitemdescription.FieldName = "itemdescription";
            this.colitemdescription.Name = "colitemdescription";
            this.colitemdescription.Visible = true;
            this.colitemdescription.VisibleIndex = 1;
            this.colitemdescription.Width = 615;
            // 
            // colquantity
            // 
            this.colquantity.Caption = "Cantidad";
            this.colquantity.FieldName = "quantity";
            this.colquantity.Name = "colquantity";
            this.colquantity.Visible = true;
            this.colquantity.VisibleIndex = 2;
            this.colquantity.Width = 144;
            // 
            // colquantitybackordered
            // 
            this.colquantitybackordered.Caption = "BackOrder";
            this.colquantitybackordered.FieldName = "quantitybackordered";
            this.colquantitybackordered.Name = "colquantitybackordered";
            this.colquantitybackordered.Visible = true;
            this.colquantitybackordered.VisibleIndex = 4;
            this.colquantitybackordered.Width = 144;
            // 
            // colalmacen2
            // 
            this.colalmacen2.Caption = "Disp. Alm. 2";
            this.colalmacen2.FieldName = "almacen2";
            this.colalmacen2.Name = "colalmacen2";
            this.colalmacen2.Visible = true;
            this.colalmacen2.VisibleIndex = 5;
            this.colalmacen2.Width = 144;
            // 
            // colalmacen31
            // 
            this.colalmacen31.Caption = "Disp. Alm. 31";
            this.colalmacen31.FieldName = "almacen31";
            this.colalmacen31.Name = "colalmacen31";
            this.colalmacen31.Visible = true;
            this.colalmacen31.VisibleIndex = 6;
            this.colalmacen31.Width = 148;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // PedidoEstatusBO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "PedidoEstatusBO";
            this.Size = new System.Drawing.Size(1295, 568);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPedido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtPedido;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtestatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TxtNombreCliente;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnCambiarBo;
        private DevExpress.XtraGrid.Columns.GridColumn colitem;
        private DevExpress.XtraGrid.Columns.GridColumn colitemid;
        private DevExpress.XtraGrid.Columns.GridColumn colitemdescription;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private DevExpress.XtraGrid.Columns.GridColumn colquantitycommitted;
        private DevExpress.XtraGrid.Columns.GridColumn colquantitybackordered;
        private DevExpress.XtraGrid.Columns.GridColumn colalmacen2;
        private DevExpress.XtraGrid.Columns.GridColumn colalmacen31;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.Label txtTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtEstatusWMS;
        private System.Windows.Forms.Label label7;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.Label txtNumpedido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
