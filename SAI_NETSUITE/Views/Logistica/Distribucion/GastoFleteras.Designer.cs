namespace SAI_NETSUITE.Views.Logistica.Distribucion
{
    partial class GastoFleteras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GastoFleteras));
            this.searchVendor = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.COLENTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaqueteria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOficinaNameFletara = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEsOficina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidNumeroGuia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroGuia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidPaqueteria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporteTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporteGuia = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFacturaImporte = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumFactura = new DevExpress.XtraEditors.TextEdit();
            this.btnRegistra = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargaXml = new DevExpress.XtraEditors.SimpleButton();
            this.labelPath = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUUID = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.gridFinal = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFinalidNumeroGuia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalimporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalNumeroGuia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalCAJAS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalBULTOS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalATADO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalTARIMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalFacturas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalMETODO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalcomentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalPaqueteria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalimporteSinIVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalretencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAutorizar = new DevExpress.XtraEditors.SimpleButton();
            this.checkAutorizado = new DevExpress.XtraEditors.CheckEdit();
            this.txtSubtotal = new DevExpress.XtraEditors.TextEdit();
            this.BtnAddGuia = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.searchVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteGuia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFacturaImporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAutorizado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubtotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchVendor
            // 
            this.searchVendor.Location = new System.Drawing.Point(16, 38);
            this.searchVendor.Name = "searchVendor";
            this.searchVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchVendor.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchVendor.Size = new System.Drawing.Size(361, 22);
            this.searchVendor.TabIndex = 1;
            this.searchVendor.EditValueChanged += new System.EventHandler(this.searchVendor_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.COLENTITY,
            this.colPaqueteria,
            this.colOficinaNameFletara,
            this.colEsOficina});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "Nombre";
            this.colName.FieldName = "NAME";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // COLENTITY
            // 
            this.COLENTITY.Caption = "ENTITY ID";
            this.COLENTITY.FieldName = "ENTITY_ID";
            this.COLENTITY.Name = "COLENTITY";
            this.COLENTITY.Visible = true;
            this.COLENTITY.VisibleIndex = 1;
            // 
            // colPaqueteria
            // 
            this.colPaqueteria.Caption = "IDpaqueteria";
            this.colPaqueteria.FieldName = "PAQUETERIA_DISTRIBUCION_ID";
            this.colPaqueteria.Name = "colPaqueteria";
            // 
            // colOficinaNameFletara
            // 
            this.colOficinaNameFletara.Caption = "OficinaNameFletara";
            this.colOficinaNameFletara.FieldName = "OficinaNameFletara";
            this.colOficinaNameFletara.Name = "colOficinaNameFletara";
            // 
            // colEsOficina
            // 
            this.colEsOficina.Caption = "EsOficina";
            this.colEsOficina.FieldName = "EsOficina";
            this.colEsOficina.Name = "colEsOficina";
            this.colEsOficina.Visible = true;
            this.colEsOficina.VisibleIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Acreedor";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(399, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(819, 327);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidNumeroGuia,
            this.colNumeroGuia,
            this.colidPaqueteria,
            this.colImporteTotal,
            this.colFecha});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // colidNumeroGuia
            // 
            this.colidNumeroGuia.Caption = "idNumeroGuia";
            this.colidNumeroGuia.FieldName = "idNumeroGuia";
            this.colidNumeroGuia.Name = "colidNumeroGuia";
            // 
            // colNumeroGuia
            // 
            this.colNumeroGuia.Caption = "NumeroGuia";
            this.colNumeroGuia.FieldName = "NumeroGuia";
            this.colNumeroGuia.Name = "colNumeroGuia";
            this.colNumeroGuia.Visible = true;
            this.colNumeroGuia.VisibleIndex = 1;
            // 
            // colidPaqueteria
            // 
            this.colidPaqueteria.Caption = "idPaqueteria";
            this.colidPaqueteria.FieldName = "idPaqueteria";
            this.colidPaqueteria.Name = "colidPaqueteria";
            // 
            // colImporteTotal
            // 
            this.colImporteTotal.Caption = "ImporteTotal";
            this.colImporteTotal.DisplayFormat.FormatString = "c";
            this.colImporteTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporteTotal.FieldName = "CostoTotal";
            this.colImporteTotal.Name = "colImporteTotal";
            this.colImporteTotal.Visible = true;
            this.colImporteTotal.VisibleIndex = 2;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "Importe Guias:";
            // 
            // txtImporteGuia
            // 
            this.txtImporteGuia.Location = new System.Drawing.Point(173, 338);
            this.txtImporteGuia.Name = "txtImporteGuia";
            this.txtImporteGuia.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteGuia.Properties.Appearance.Options.UseFont = true;
            this.txtImporteGuia.Properties.ReadOnly = true;
            this.txtImporteGuia.Size = new System.Drawing.Size(203, 28);
            this.txtImporteGuia.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Importe Sin Iva:";
            // 
            // txtFacturaImporte
            // 
            this.txtFacturaImporte.Location = new System.Drawing.Point(173, 307);
            this.txtFacturaImporte.Name = "txtFacturaImporte";
            this.txtFacturaImporte.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFacturaImporte.Properties.Appearance.Options.UseFont = true;
            this.txtFacturaImporte.Properties.Mask.EditMask = "c";
            this.txtFacturaImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFacturaImporte.Properties.ReadOnly = true;
            this.txtFacturaImporte.Size = new System.Drawing.Size(203, 28);
            this.txtFacturaImporte.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "Num. Factura:";
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(177, 221);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFactura.Properties.Appearance.Options.UseFont = true;
            this.txtNumFactura.Properties.Mask.EditMask = "c";
            this.txtNumFactura.Properties.ReadOnly = true;
            this.txtNumFactura.Size = new System.Drawing.Size(203, 28);
            this.txtNumFactura.TabIndex = 16;
            // 
            // btnRegistra
            // 
            this.btnRegistra.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnRegistra.Appearance.BorderColor = System.Drawing.Color.White;
            this.btnRegistra.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistra.Appearance.Options.UseBackColor = true;
            this.btnRegistra.Appearance.Options.UseBorderColor = true;
            this.btnRegistra.Appearance.Options.UseFont = true;
            this.btnRegistra.AppearanceHovered.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegistra.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnRegistra.AppearanceHovered.Options.UseBackColor = true;
            this.btnRegistra.AppearanceHovered.Options.UseForeColor = true;
            this.btnRegistra.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnRegistra.Location = new System.Drawing.Point(3, 463);
            this.btnRegistra.Name = "btnRegistra";
            this.btnRegistra.Size = new System.Drawing.Size(370, 43);
            this.btnRegistra.TabIndex = 18;
            this.btnRegistra.Text = "Registrar en Netsuite";
            this.btnRegistra.Visible = false;
            this.btnRegistra.Click += new System.EventHandler(this.btnRegistra_Click);
            // 
            // btnCargaXml
            // 
            this.btnCargaXml.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnCargaXml.ImageOptions.Image = global::SAI_NETSUITE.Properties.Resources.textbox_16x16;
            this.btnCargaXml.Location = new System.Drawing.Point(16, 67);
            this.btnCargaXml.Name = "btnCargaXml";
            this.btnCargaXml.Size = new System.Drawing.Size(361, 23);
            this.btnCargaXml.TabIndex = 19;
            this.btnCargaXml.Text = "carga XML";
            this.btnCargaXml.Click += new System.EventHandler(this.btnCargaXml_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.behaviorManager1.SetBehaviors(this.labelPath, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.Behaviors.Common.FileIconBehavior.Create(typeof(DevExpress.XtraEditors.Behaviors.FileIconBehaviorSourceForLabelControl), DevExpress.Utils.Behaviors.Common.FileIconSize.Small, ((System.Drawing.Image)(resources.GetObject("labelPath.Behaviors"))), global::SAI_NETSUITE.Properties.Resources.Error_icon)))});
            this.labelPath.Location = new System.Drawing.Point(16, 97);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(361, 16);
            this.labelPath.TabIndex = 20;
            this.labelPath.Text = "ruta:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 22);
            this.label4.TabIndex = 22;
            this.label4.Text = "UUID:";
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(71, 170);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUUID.Properties.Appearance.Options.UseFont = true;
            this.txtUUID.Properties.Mask.EditMask = "c";
            this.txtUUID.Properties.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(305, 28);
            this.txtUUID.TabIndex = 21;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(173, 384);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Retención IVA";
            this.checkEdit1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.checkEdit1.Size = new System.Drawing.Size(204, 20);
            this.checkEdit1.TabIndex = 23;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // gridFinal
            // 
            this.gridFinal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFinal.Location = new System.Drawing.Point(399, 354);
            this.gridFinal.MainView = this.gridView2;
            this.gridFinal.Name = "gridFinal";
            this.gridFinal.Size = new System.Drawing.Size(819, 272);
            this.gridFinal.TabIndex = 24;
            this.gridFinal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFinalidNumeroGuia,
            this.colFinalimporte,
            this.colFinalNumeroGuia,
            this.colFinalCAJAS,
            this.colFinalBULTOS,
            this.colFinalATADO,
            this.colFinalTARIMA,
            this.colFinalFacturas,
            this.colFinalMETODO,
            this.colFinalcomentario,
            this.colFinalPaqueteria,
            this.colFinalimporteSinIVA,
            this.colFinalretencion});
            this.gridView2.GridControl = this.gridFinal;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.MultiSelect = true;
            this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            this.gridView2.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView2_RowUpdated);
            // 
            // colFinalidNumeroGuia
            // 
            this.colFinalidNumeroGuia.Caption = "idNumeroGuia";
            this.colFinalidNumeroGuia.FieldName = "idNumeroGuia";
            this.colFinalidNumeroGuia.Name = "colFinalidNumeroGuia";
            // 
            // colFinalimporte
            // 
            this.colFinalimporte.Caption = "Importe";
            this.colFinalimporte.DisplayFormat.FormatString = "c2";
            this.colFinalimporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFinalimporte.FieldName = "colFinalimporte";
            this.colFinalimporte.Name = "colFinalimporte";
            this.colFinalimporte.OptionsColumn.ReadOnly = true;
            this.colFinalimporte.UnboundExpression = "[importeSinIVA] * [retencion]";
            this.colFinalimporte.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colFinalimporte.Visible = true;
            this.colFinalimporte.VisibleIndex = 2;
            // 
            // colFinalNumeroGuia
            // 
            this.colFinalNumeroGuia.Caption = "NumeroGuia";
            this.colFinalNumeroGuia.FieldName = "NumeroGuia";
            this.colFinalNumeroGuia.Name = "colFinalNumeroGuia";
            this.colFinalNumeroGuia.Visible = true;
            this.colFinalNumeroGuia.VisibleIndex = 1;
            // 
            // colFinalCAJAS
            // 
            this.colFinalCAJAS.Caption = "CAJAS";
            this.colFinalCAJAS.FieldName = "CAJAS";
            this.colFinalCAJAS.Name = "colFinalCAJAS";
            this.colFinalCAJAS.OptionsColumn.ReadOnly = true;
            this.colFinalCAJAS.Visible = true;
            this.colFinalCAJAS.VisibleIndex = 4;
            // 
            // colFinalBULTOS
            // 
            this.colFinalBULTOS.Caption = "BULTOS";
            this.colFinalBULTOS.FieldName = "BULTOS";
            this.colFinalBULTOS.Name = "colFinalBULTOS";
            this.colFinalBULTOS.OptionsColumn.ReadOnly = true;
            this.colFinalBULTOS.Visible = true;
            this.colFinalBULTOS.VisibleIndex = 3;
            // 
            // colFinalATADO
            // 
            this.colFinalATADO.Caption = "ATADO";
            this.colFinalATADO.FieldName = "ATADO";
            this.colFinalATADO.Name = "colFinalATADO";
            this.colFinalATADO.OptionsColumn.ReadOnly = true;
            this.colFinalATADO.Visible = true;
            this.colFinalATADO.VisibleIndex = 5;
            // 
            // colFinalTARIMA
            // 
            this.colFinalTARIMA.Caption = "TARIMA";
            this.colFinalTARIMA.FieldName = "TARIMA";
            this.colFinalTARIMA.Name = "colFinalTARIMA";
            this.colFinalTARIMA.OptionsColumn.ReadOnly = true;
            this.colFinalTARIMA.Visible = true;
            this.colFinalTARIMA.VisibleIndex = 6;
            // 
            // colFinalFacturas
            // 
            this.colFinalFacturas.Caption = "Facturas";
            this.colFinalFacturas.FieldName = "Facturas";
            this.colFinalFacturas.Name = "colFinalFacturas";
            // 
            // colFinalMETODO
            // 
            this.colFinalMETODO.Caption = "METODO";
            this.colFinalMETODO.FieldName = "METODO";
            this.colFinalMETODO.Name = "colFinalMETODO";
            // 
            // colFinalcomentario
            // 
            this.colFinalcomentario.Caption = "Comentario";
            this.colFinalcomentario.FieldName = "comentario";
            this.colFinalcomentario.Name = "colFinalcomentario";
            this.colFinalcomentario.OptionsColumn.ReadOnly = true;
            this.colFinalcomentario.Visible = true;
            this.colFinalcomentario.VisibleIndex = 7;
            // 
            // colFinalPaqueteria
            // 
            this.colFinalPaqueteria.Caption = "paqueteria";
            this.colFinalPaqueteria.FieldName = "paqueteria";
            this.colFinalPaqueteria.Name = "colFinalPaqueteria";
            // 
            // colFinalimporteSinIVA
            // 
            this.colFinalimporteSinIVA.Caption = "importeSinIVA";
            this.colFinalimporteSinIVA.FieldName = "importeSinIVA";
            this.colFinalimporteSinIVA.Name = "colFinalimporteSinIVA";
            this.colFinalimporteSinIVA.OptionsColumn.ReadOnly = true;
            this.colFinalimporteSinIVA.Visible = true;
            this.colFinalimporteSinIVA.VisibleIndex = 8;
            // 
            // colFinalretencion
            // 
            this.colFinalretencion.Caption = "retencion";
            this.colFinalretencion.FieldName = "retencion";
            this.colFinalretencion.Name = "colFinalretencion";
            this.colFinalretencion.Visible = true;
            this.colFinalretencion.VisibleIndex = 9;
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Appearance.BackColor = System.Drawing.Color.Gold;
            this.btnAutorizar.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutorizar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnAutorizar.Appearance.Options.UseBackColor = true;
            this.btnAutorizar.Appearance.Options.UseFont = true;
            this.btnAutorizar.Appearance.Options.UseForeColor = true;
            this.btnAutorizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAutorizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAutorizar.ImageOptions.Image")));
            this.btnAutorizar.Location = new System.Drawing.Point(3, 512);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(369, 42);
            this.btnAutorizar.TabIndex = 26;
            this.btnAutorizar.Text = "Autorizacion";
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // checkAutorizado
            // 
            this.checkAutorizado.Location = new System.Drawing.Point(7, 384);
            this.checkAutorizado.Name = "checkAutorizado";
            this.checkAutorizado.Properties.Caption = "Autorizado";
            this.checkAutorizado.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.checkAutorizado.Properties.ReadOnly = true;
            this.checkAutorizado.Size = new System.Drawing.Size(110, 20);
            this.checkAutorizado.TabIndex = 27;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(173, 278);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Properties.Appearance.Options.UseFont = true;
            this.txtSubtotal.Properties.Mask.EditMask = "c";
            this.txtSubtotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSubtotal.Properties.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(203, 28);
            this.txtSubtotal.TabIndex = 28;
            // 
            // BtnAddGuia
            // 
            this.BtnAddGuia.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnAddGuia.Appearance.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddGuia.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnAddGuia.Appearance.Options.UseBackColor = true;
            this.BtnAddGuia.Appearance.Options.UseFont = true;
            this.BtnAddGuia.Appearance.Options.UseForeColor = true;
            this.BtnAddGuia.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.BtnAddGuia.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.BtnAddGuia.Location = new System.Drawing.Point(3, 570);
            this.BtnAddGuia.Name = "BtnAddGuia";
            this.BtnAddGuia.Size = new System.Drawing.Size(369, 42);
            this.BtnAddGuia.TabIndex = 29;
            this.BtnAddGuia.Text = "Agregar Guía";
            this.BtnAddGuia.Click += new System.EventHandler(this.BtnAddGuia_Click);
            // 
            // GastoFleteras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnAddGuia);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.checkAutorizado);
            this.Controls.Add(this.btnAutorizar);
            this.Controls.Add(this.gridFinal);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUUID);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.btnCargaXml);
            this.Controls.Add(this.btnRegistra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumFactura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFacturaImporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImporteGuia);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchVendor);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GastoFleteras";
            this.Size = new System.Drawing.Size(1221, 629);
            this.Load += new System.EventHandler(this.GastoFleteras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteGuia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFacturaImporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAutorizado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubtotal.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SearchLookUpEdit searchVendor;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn COLENTITY;
        private DevExpress.XtraGrid.Columns.GridColumn colPaqueteria;
        private DevExpress.XtraGrid.Columns.GridColumn colidNumeroGuia;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroGuia;
        private DevExpress.XtraGrid.Columns.GridColumn colidPaqueteria;
        private DevExpress.XtraGrid.Columns.GridColumn colImporteTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtImporteGuia;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtFacturaImporte;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtNumFactura;
        private DevExpress.XtraEditors.SimpleButton btnRegistra;
        private DevExpress.XtraEditors.SimpleButton btnCargaXml;
        private DevExpress.XtraEditors.LabelControl labelPath;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtUUID;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraGrid.GridControl gridFinal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalidNumeroGuia;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalNumeroGuia;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalCAJAS;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalBULTOS;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalATADO;
        private DevExpress.XtraEditors.SimpleButton btnAutorizar;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalTARIMA;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalFacturas;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalMETODO;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalimporte;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalcomentario;
        private DevExpress.XtraEditors.CheckEdit checkAutorizado;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalPaqueteria;
        private DevExpress.XtraGrid.Columns.GridColumn colOficinaNameFletara;
        private DevExpress.XtraEditors.TextEdit txtSubtotal;
        private DevExpress.XtraGrid.Columns.GridColumn colEsOficina;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalimporteSinIVA;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalretencion;
        private DevExpress.XtraEditors.SimpleButton BtnAddGuia;
    }
}
