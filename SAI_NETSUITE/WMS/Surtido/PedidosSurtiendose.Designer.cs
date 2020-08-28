namespace SAI_NETSUITE.WMS.Surtido
{
    partial class PedidosSurtiendose
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement8 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement9 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement10 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.colMov = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colLabel = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colCantSurtida2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colNumPedido = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colPartidas = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colFormaEnvio = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colminutos = new DevExpress.XtraGrid.Columns.TileViewColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colMov
            // 
            this.colMov.Caption = "Mov";
            this.colMov.FieldName = "Mov";
            this.colMov.Name = "colMov";
            this.colMov.Visible = true;
            this.colMov.VisibleIndex = 0;
            // 
            // colLabel
            // 
            this.colLabel.Caption = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 3;
            // 
            // colCantSurtida2
            // 
            this.colCantSurtida2.Caption = "CantSurtida2";
            this.colCantSurtida2.DisplayFormat.FormatString = "p";
            this.colCantSurtida2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCantSurtida2.FieldName = "CantSurtida2";
            this.colCantSurtida2.Name = "colCantSurtida2";
            this.colCantSurtida2.Visible = true;
            this.colCantSurtida2.VisibleIndex = 2;
            // 
            // colNumPedido
            // 
            this.colNumPedido.Caption = "NumPedido";
            this.colNumPedido.FieldName = "NumPedido";
            this.colNumPedido.Name = "colNumPedido";
            this.colNumPedido.Visible = true;
            this.colNumPedido.VisibleIndex = 1;
            // 
            // colPartidas
            // 
            this.colPartidas.Caption = "PartidasFaltantes";
            this.colPartidas.FieldName = "Partidas";
            this.colPartidas.Name = "colPartidas";
            this.colPartidas.OptionsColumn.ShowCaption = true;
            this.colPartidas.Visible = true;
            this.colPartidas.VisibleIndex = 4;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.tileView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1363, 507);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // tileView1
            // 
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMov,
            this.colNumPedido,
            this.colCantSurtida2,
            this.colLabel,
            this.colPartidas,
            this.colFormaEnvio,
            this.colminutos});
            this.tileView1.ColumnSet.GroupColumn = this.colFormaEnvio;
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsTiles.IndentBetweenItems = 10;
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(150, 100);
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(25);
            this.tileView1.OptionsTiles.RowCount = 0;
            this.tileView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFormaEnvio, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.tileView1.TileColumns.Add(tableColumnDefinition2);
            this.tileView1.TileRows.Add(tableRowDefinition2);
            tileViewItemElement6.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement6.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement6.Column = this.colMov;
            tileViewItemElement6.Text = "colMov";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement7.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            tileViewItemElement7.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement7.Column = this.colLabel;
            tileViewItemElement7.StretchVertical = true;
            tileViewItemElement7.Text = "colLabel";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement7.TextLocation = new System.Drawing.Point(-9, 0);
            tileViewItemElement7.Width = 4;
            tileViewItemElement8.Appearance.Normal.BackColor = System.Drawing.Color.White;
            tileViewItemElement8.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement8.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement8.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement8.Column = this.colCantSurtida2;
            tileViewItemElement8.Text = "colCantSurtida2";
            tileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement9.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement9.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement9.Column = this.colNumPedido;
            tileViewItemElement9.Text = "colNumPedido";
            tileViewItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileViewItemElement10.Column = this.colPartidas;
            tileViewItemElement10.Text = "colPartidas";
            tileViewItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileView1.TileTemplate.Add(tileViewItemElement6);
            this.tileView1.TileTemplate.Add(tileViewItemElement7);
            this.tileView1.TileTemplate.Add(tileViewItemElement8);
            this.tileView1.TileTemplate.Add(tileViewItemElement9);
            this.tileView1.TileTemplate.Add(tileViewItemElement10);
            this.tileView1.ItemCustomize += new DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventHandler(this.tileView1_ItemCustomize);
            this.tileView1.DoubleClick += new System.EventHandler(this.tileView1_DoubleClick);
            // 
            // colFormaEnvio
            // 
            this.colFormaEnvio.FieldName = "FormaEnvio";
            this.colFormaEnvio.Name = "colFormaEnvio";
            this.colFormaEnvio.Visible = true;
            this.colFormaEnvio.VisibleIndex = 5;
            // 
            // colminutos
            // 
            this.colminutos.FieldName = "minutosTranscurridos";
            this.colminutos.Name = "colminutos";
            this.colminutos.Visible = true;
            this.colminutos.VisibleIndex = 6;
            // 
            // PedidosSurtiendose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "PedidosSurtiendose";
            this.Size = new System.Drawing.Size(1363, 507);
            this.Load += new System.EventHandler(this.PedidosSurtiendose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colMov;
        private DevExpress.XtraGrid.Columns.TileViewColumn colNumPedido;
        private DevExpress.XtraGrid.Columns.TileViewColumn colCantSurtida2;
        private DevExpress.XtraGrid.Columns.TileViewColumn colLabel;
        private DevExpress.XtraGrid.Columns.TileViewColumn colPartidas;
        private DevExpress.XtraGrid.Columns.TileViewColumn colFormaEnvio;
        private DevExpress.XtraGrid.Columns.TileViewColumn colminutos;
    }
}
