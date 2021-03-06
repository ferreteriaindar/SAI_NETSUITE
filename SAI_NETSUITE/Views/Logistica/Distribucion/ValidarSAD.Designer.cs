﻿namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    partial class ValidarSAD
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsadID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportePedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescuentoTotalPP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportePP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexcepcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcxcComentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAutorizar = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAutorizar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btActualizar);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1251, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(544, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "VALIDAR PEDIDO SAD";
            // 
            // btActualizar
            // 
            this.btActualizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btActualizar.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.recurrence_16x16;
            this.btActualizar.Location = new System.Drawing.Point(7, 22);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(102, 23);
            this.btActualizar.TabIndex = 0;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 67);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnAutorizar});
            this.gridControl1.Size = new System.Drawing.Size(1251, 526);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsadID,
            this.colPedido,
            this.colImportePedido,
            this.colCliente,
            this.colNombre,
            this.colFechaFactura,
            this.colFactura,
            this.colImporteFactura,
            this.colDescuentoTotalPP,
            this.colImportePP,
            this.colexcepcion,
            this.colcomentario,
            this.colcxcComentario,
            this.colmonto,
            this.colBTN});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colsadID
            // 
            this.colsadID.Caption = "sad.sadID";
            this.colsadID.FieldName = "sadID";
            this.colsadID.Name = "colsadID";
            // 
            // colPedido
            // 
            this.colPedido.Caption = "Pedido";
            this.colPedido.FieldName = "Pedido";
            this.colPedido.Name = "colPedido";
            this.colPedido.Visible = true;
            this.colPedido.VisibleIndex = 0;
            // 
            // colImportePedido
            // 
            this.colImportePedido.Caption = "ImportePedido";
            this.colImportePedido.DisplayFormat.FormatString = "c2";
            this.colImportePedido.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportePedido.FieldName = "ImportePedido";
            this.colImportePedido.Name = "colImportePedido";
            this.colImportePedido.Visible = true;
            this.colImportePedido.VisibleIndex = 1;
            // 
            // colCliente
            // 
            this.colCliente.Caption = "Cliente";
            this.colCliente.FieldName = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.Visible = true;
            this.colCliente.VisibleIndex = 2;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 3;
            // 
            // colFechaFactura
            // 
            this.colFechaFactura.Caption = "FechaFactura";
            this.colFechaFactura.FieldName = "FechaFactura";
            this.colFechaFactura.Name = "colFechaFactura";
            this.colFechaFactura.Visible = true;
            this.colFechaFactura.VisibleIndex = 4;
            // 
            // colFactura
            // 
            this.colFactura.Caption = "Factura";
            this.colFactura.FieldName = "Factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.Visible = true;
            this.colFactura.VisibleIndex = 5;
            // 
            // colImporteFactura
            // 
            this.colImporteFactura.Caption = "ImporteFactura";
            this.colImporteFactura.DisplayFormat.FormatString = "c2";
            this.colImporteFactura.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteFactura.FieldName = "ImporteFactura";
            this.colImporteFactura.Name = "colImporteFactura";
            this.colImporteFactura.Visible = true;
            this.colImporteFactura.VisibleIndex = 6;
            // 
            // colDescuentoTotalPP
            // 
            this.colDescuentoTotalPP.Caption = "DescuentoTotalPP";
            this.colDescuentoTotalPP.FieldName = "DescuentoTotalPP";
            this.colDescuentoTotalPP.Name = "colDescuentoTotalPP";
            this.colDescuentoTotalPP.Visible = true;
            this.colDescuentoTotalPP.VisibleIndex = 7;
            // 
            // colImportePP
            // 
            this.colImportePP.Caption = "ImportePP";
            this.colImportePP.DisplayFormat.FormatString = "c2";
            this.colImportePP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImportePP.FieldName = "ImportePP";
            this.colImportePP.Name = "colImportePP";
            this.colImportePP.Visible = true;
            this.colImportePP.VisibleIndex = 8;
            // 
            // colexcepcion
            // 
            this.colexcepcion.Caption = "excepcion";
            this.colexcepcion.FieldName = "excepcion";
            this.colexcepcion.Name = "colexcepcion";
            this.colexcepcion.Visible = true;
            this.colexcepcion.VisibleIndex = 9;
            // 
            // colcomentario
            // 
            this.colcomentario.Caption = "comentario";
            this.colcomentario.FieldName = "comentario";
            this.colcomentario.Name = "colcomentario";
            this.colcomentario.Visible = true;
            this.colcomentario.VisibleIndex = 10;
            // 
            // colcxcComentario
            // 
            this.colcxcComentario.Caption = "cxcComentario";
            this.colcxcComentario.FieldName = "cxcComentario";
            this.colcxcComentario.Name = "colcxcComentario";
            this.colcxcComentario.Visible = true;
            this.colcxcComentario.VisibleIndex = 11;
            // 
            // colmonto
            // 
            this.colmonto.Caption = "monto";
            this.colmonto.FieldName = "cxcMonto";
            this.colmonto.Name = "colmonto";
            this.colmonto.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colmonto.Visible = true;
            this.colmonto.VisibleIndex = 12;
            // 
            // colBTN
            // 
            this.colBTN.Caption = "gridColumn1";
            this.colBTN.ColumnEdit = this.btnAutorizar;
            this.colBTN.Name = "colBTN";
            this.colBTN.Visible = true;
            this.colBTN.VisibleIndex = 13;
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.AutoHeight = false;
            editorButtonImageOptions1.Image = global::SAI_NETSUITE.Properties.Resources.Accept_icon;
            this.btnAutorizar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "AUTORIZAR", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnAutorizar.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnAutorizar_ButtonClick);
            // 
            // ValidarSAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ValidarSAD";
            this.Size = new System.Drawing.Size(1257, 596);
            this.Load += new System.EventHandler(this.ValidarSAD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAutorizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btActualizar;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colsadID;
        private DevExpress.XtraGrid.Columns.GridColumn colPedido;
        private DevExpress.XtraGrid.Columns.GridColumn colImportePedido;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colDescuentoTotalPP;
        private DevExpress.XtraGrid.Columns.GridColumn colImportePP;
        private DevExpress.XtraGrid.Columns.GridColumn colexcepcion;
        private DevExpress.XtraGrid.Columns.GridColumn colcomentario;
        private DevExpress.XtraGrid.Columns.GridColumn colcxcComentario;
        private DevExpress.XtraGrid.Columns.GridColumn colmonto;
        private DevExpress.XtraGrid.Columns.GridColumn colBTN;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnAutorizar;
    }
}
