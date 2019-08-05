namespace SAI.Almacen.WMS.Surtido
{
    partial class SurtidoresConectado
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan2 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurtidoresConectado));
            this.colNombre = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.colUsuario = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_38 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_37 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_36 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_35 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_34 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_33 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_32 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_31 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_30 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_29 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_28 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_27 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_26 = new DevExpress.XtraEditors.SimpleButton();
            this.P2_25 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton30 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton21 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_38 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_37 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_36 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_35 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_34 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_33 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_32 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_31 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_30 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_29 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_28 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_27 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_26 = new DevExpress.XtraEditors.SimpleButton();
            this.P1_25 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            // 
            // colArea
            // 
            this.colArea.Caption = "Area";
            this.colArea.FieldName = "Area";
            this.colArea.Name = "colArea";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.tileView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(573, 608);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // tileView1
            // 
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsuario,
            this.colNombre,
            this.colArea});
            this.tileView1.ColumnSet.GroupColumn = this.colArea;
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(124, 60);
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(3);
            this.tileView1.OptionsTiles.RowCount = 3;
            this.tileView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colArea, DevExpress.Data.ColumnSortOrder.Ascending)});
            tableColumnDefinition3.Length.Value = 23D;
            tableColumnDefinition4.Length.Value = 101D;
            this.tileView1.TileColumns.Add(tableColumnDefinition3);
            this.tileView1.TileColumns.Add(tableColumnDefinition4);
            this.tileView1.TileRows.Add(tableRowDefinition2);
            tableSpan2.RowSpan = 2;
            this.tileView1.TileSpans.Add(tableSpan2);
            tileViewItemElement3.Column = this.colNombre;
            tileViewItemElement3.ColumnIndex = 1;
            tileViewItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.Text = "colNombre";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.Appearance.Normal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            tileViewItemElement4.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.StretchVertical = true;
            tileViewItemElement4.Text = "";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement4.Width = 9;
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            this.tileView1.ItemCustomize += new DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventHandler(this.tileView1_ItemCustomize);
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.simpleButton2);
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Controls.Add(this.P2_38);
            this.groupControl2.Controls.Add(this.P2_37);
            this.groupControl2.Controls.Add(this.P2_36);
            this.groupControl2.Controls.Add(this.P2_35);
            this.groupControl2.Controls.Add(this.P2_34);
            this.groupControl2.Controls.Add(this.P2_33);
            this.groupControl2.Controls.Add(this.P2_32);
            this.groupControl2.Controls.Add(this.P2_31);
            this.groupControl2.Controls.Add(this.P2_30);
            this.groupControl2.Controls.Add(this.P2_29);
            this.groupControl2.Controls.Add(this.P2_28);
            this.groupControl2.Controls.Add(this.P2_27);
            this.groupControl2.Controls.Add(this.P2_26);
            this.groupControl2.Controls.Add(this.P2_25);
            this.groupControl2.Controls.Add(this.simpleButton30);
            this.groupControl2.Controls.Add(this.simpleButton21);
            this.groupControl2.Controls.Add(this.P1_38);
            this.groupControl2.Controls.Add(this.P1_37);
            this.groupControl2.Controls.Add(this.P1_36);
            this.groupControl2.Controls.Add(this.P1_35);
            this.groupControl2.Controls.Add(this.P1_34);
            this.groupControl2.Controls.Add(this.P1_33);
            this.groupControl2.Controls.Add(this.P1_32);
            this.groupControl2.Controls.Add(this.P1_31);
            this.groupControl2.Controls.Add(this.P1_30);
            this.groupControl2.Controls.Add(this.P1_29);
            this.groupControl2.Controls.Add(this.P1_28);
            this.groupControl2.Controls.Add(this.P1_27);
            this.groupControl2.Controls.Add(this.P1_26);
            this.groupControl2.Controls.Add(this.P1_25);
            this.groupControl2.Location = new System.Drawing.Point(579, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(752, 602);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Ubicaciones";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.Black;
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(9, 105);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(688, 30);
            this.simpleButton1.TabIndex = 52;
            this.simpleButton1.Text = "39";
            // 
            // P2_38
            // 
            this.P2_38.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_38.Appearance.Options.UseBorderColor = true;
            this.P2_38.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_38.Location = new System.Drawing.Point(616, 141);
            this.P2_38.Name = "P2_38";
            this.P2_38.Size = new System.Drawing.Size(31, 124);
            this.P2_38.TabIndex = 51;
            this.P2_38.Text = "38";
            // 
            // P2_37
            // 
            this.P2_37.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_37.Appearance.Options.UseBorderColor = true;
            this.P2_37.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_37.Location = new System.Drawing.Point(582, 141);
            this.P2_37.Name = "P2_37";
            this.P2_37.Size = new System.Drawing.Size(31, 124);
            this.P2_37.TabIndex = 50;
            this.P2_37.Text = "37";
            // 
            // P2_36
            // 
            this.P2_36.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_36.Appearance.Options.UseBorderColor = true;
            this.P2_36.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_36.Location = new System.Drawing.Point(529, 141);
            this.P2_36.Name = "P2_36";
            this.P2_36.Size = new System.Drawing.Size(31, 124);
            this.P2_36.TabIndex = 49;
            this.P2_36.Text = "36";
            // 
            // P2_35
            // 
            this.P2_35.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_35.Appearance.Options.UseBorderColor = true;
            this.P2_35.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_35.Location = new System.Drawing.Point(495, 141);
            this.P2_35.Name = "P2_35";
            this.P2_35.Size = new System.Drawing.Size(31, 124);
            this.P2_35.TabIndex = 48;
            this.P2_35.Text = "35";
            // 
            // P2_34
            // 
            this.P2_34.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_34.Appearance.Options.UseBorderColor = true;
            this.P2_34.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_34.Location = new System.Drawing.Point(445, 141);
            this.P2_34.Name = "P2_34";
            this.P2_34.Size = new System.Drawing.Size(31, 124);
            this.P2_34.TabIndex = 47;
            this.P2_34.Text = "34";
            // 
            // P2_33
            // 
            this.P2_33.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_33.Appearance.Options.UseBorderColor = true;
            this.P2_33.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_33.Location = new System.Drawing.Point(411, 141);
            this.P2_33.Name = "P2_33";
            this.P2_33.Size = new System.Drawing.Size(31, 124);
            this.P2_33.TabIndex = 46;
            this.P2_33.Text = "33";
            // 
            // P2_32
            // 
            this.P2_32.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_32.Appearance.Options.UseBorderColor = true;
            this.P2_32.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_32.Location = new System.Drawing.Point(362, 141);
            this.P2_32.Name = "P2_32";
            this.P2_32.Size = new System.Drawing.Size(31, 124);
            this.P2_32.TabIndex = 45;
            this.P2_32.Text = "32";
            // 
            // P2_31
            // 
            this.P2_31.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_31.Appearance.Options.UseBorderColor = true;
            this.P2_31.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_31.Location = new System.Drawing.Point(328, 141);
            this.P2_31.Name = "P2_31";
            this.P2_31.Size = new System.Drawing.Size(31, 124);
            this.P2_31.TabIndex = 44;
            this.P2_31.Text = "31";
            // 
            // P2_30
            // 
            this.P2_30.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_30.Appearance.Options.UseBorderColor = true;
            this.P2_30.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_30.Location = new System.Drawing.Point(278, 141);
            this.P2_30.Name = "P2_30";
            this.P2_30.Size = new System.Drawing.Size(31, 124);
            this.P2_30.TabIndex = 43;
            this.P2_30.Text = "30";
            // 
            // P2_29
            // 
            this.P2_29.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_29.Appearance.Options.UseBorderColor = true;
            this.P2_29.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_29.Location = new System.Drawing.Point(244, 141);
            this.P2_29.Name = "P2_29";
            this.P2_29.Size = new System.Drawing.Size(31, 124);
            this.P2_29.TabIndex = 42;
            this.P2_29.Text = "29";
            // 
            // P2_28
            // 
            this.P2_28.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_28.Appearance.Options.UseBorderColor = true;
            this.P2_28.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_28.Location = new System.Drawing.Point(191, 141);
            this.P2_28.Name = "P2_28";
            this.P2_28.Size = new System.Drawing.Size(31, 124);
            this.P2_28.TabIndex = 41;
            this.P2_28.Text = "28";
            // 
            // P2_27
            // 
            this.P2_27.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_27.Appearance.Options.UseBorderColor = true;
            this.P2_27.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_27.Location = new System.Drawing.Point(157, 141);
            this.P2_27.Name = "P2_27";
            this.P2_27.Size = new System.Drawing.Size(31, 124);
            this.P2_27.TabIndex = 40;
            this.P2_27.Text = "27";
            // 
            // P2_26
            // 
            this.P2_26.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_26.Appearance.Options.UseBorderColor = true;
            this.P2_26.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_26.Location = new System.Drawing.Point(107, 141);
            this.P2_26.Name = "P2_26";
            this.P2_26.Size = new System.Drawing.Size(31, 124);
            this.P2_26.TabIndex = 39;
            this.P2_26.Text = "26";
            // 
            // P2_25
            // 
            this.P2_25.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P2_25.Appearance.Options.UseBorderColor = true;
            this.P2_25.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P2_25.Location = new System.Drawing.Point(73, 141);
            this.P2_25.Name = "P2_25";
            this.P2_25.Size = new System.Drawing.Size(31, 124);
            this.P2_25.TabIndex = 38;
            this.P2_25.Text = "25";
            // 
            // simpleButton30
            // 
            this.simpleButton30.Appearance.BorderColor = System.Drawing.Color.Black;
            this.simpleButton30.Appearance.Options.UseBorderColor = true;
            this.simpleButton30.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton30.Location = new System.Drawing.Point(9, 141);
            this.simpleButton30.Name = "simpleButton30";
            this.simpleButton30.Size = new System.Drawing.Size(31, 304);
            this.simpleButton30.TabIndex = 37;
            this.simpleButton30.Text = "24";
            // 
            // simpleButton21
            // 
            this.simpleButton21.Appearance.BorderColor = System.Drawing.Color.Black;
            this.simpleButton21.Appearance.Options.UseBorderColor = true;
            this.simpleButton21.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton21.Location = new System.Drawing.Point(666, 141);
            this.simpleButton21.Name = "simpleButton21";
            this.simpleButton21.Size = new System.Drawing.Size(31, 304);
            this.simpleButton21.TabIndex = 36;
            this.simpleButton21.Text = "39";
            // 
            // P1_38
            // 
            this.P1_38.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_38.Appearance.Options.UseBorderColor = true;
            this.P1_38.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_38.Location = new System.Drawing.Point(616, 321);
            this.P1_38.Name = "P1_38";
            this.P1_38.Size = new System.Drawing.Size(31, 124);
            this.P1_38.TabIndex = 34;
            this.P1_38.Text = "38";
            // 
            // P1_37
            // 
            this.P1_37.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_37.Appearance.Options.UseBorderColor = true;
            this.P1_37.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_37.Location = new System.Drawing.Point(582, 321);
            this.P1_37.Name = "P1_37";
            this.P1_37.Size = new System.Drawing.Size(31, 124);
            this.P1_37.TabIndex = 32;
            this.P1_37.Text = "37";
            // 
            // P1_36
            // 
            this.P1_36.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_36.Appearance.Options.UseBorderColor = true;
            this.P1_36.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_36.Location = new System.Drawing.Point(529, 321);
            this.P1_36.Name = "P1_36";
            this.P1_36.Size = new System.Drawing.Size(31, 124);
            this.P1_36.TabIndex = 30;
            this.P1_36.Text = "36";
            // 
            // P1_35
            // 
            this.P1_35.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_35.Appearance.Options.UseBorderColor = true;
            this.P1_35.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_35.Location = new System.Drawing.Point(495, 321);
            this.P1_35.Name = "P1_35";
            this.P1_35.Size = new System.Drawing.Size(31, 124);
            this.P1_35.TabIndex = 28;
            this.P1_35.Text = "35";
            // 
            // P1_34
            // 
            this.P1_34.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_34.Appearance.Options.UseBorderColor = true;
            this.P1_34.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_34.Location = new System.Drawing.Point(445, 321);
            this.P1_34.Name = "P1_34";
            this.P1_34.Size = new System.Drawing.Size(31, 124);
            this.P1_34.TabIndex = 26;
            this.P1_34.Text = "34";
            // 
            // P1_33
            // 
            this.P1_33.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_33.Appearance.Options.UseBorderColor = true;
            this.P1_33.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_33.Location = new System.Drawing.Point(411, 321);
            this.P1_33.Name = "P1_33";
            this.P1_33.Size = new System.Drawing.Size(31, 124);
            this.P1_33.TabIndex = 24;
            this.P1_33.Text = "33";
            // 
            // P1_32
            // 
            this.P1_32.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_32.Appearance.Options.UseBorderColor = true;
            this.P1_32.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_32.Location = new System.Drawing.Point(362, 321);
            this.P1_32.Name = "P1_32";
            this.P1_32.Size = new System.Drawing.Size(31, 124);
            this.P1_32.TabIndex = 22;
            this.P1_32.Text = "32";
            // 
            // P1_31
            // 
            this.P1_31.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_31.Appearance.Options.UseBorderColor = true;
            this.P1_31.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_31.Location = new System.Drawing.Point(328, 321);
            this.P1_31.Name = "P1_31";
            this.P1_31.Size = new System.Drawing.Size(31, 124);
            this.P1_31.TabIndex = 20;
            this.P1_31.Text = "31";
            // 
            // P1_30
            // 
            this.P1_30.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_30.Appearance.Options.UseBorderColor = true;
            this.P1_30.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_30.Location = new System.Drawing.Point(278, 321);
            this.P1_30.Name = "P1_30";
            this.P1_30.Size = new System.Drawing.Size(31, 124);
            this.P1_30.TabIndex = 18;
            this.P1_30.Text = "30";
            // 
            // P1_29
            // 
            this.P1_29.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_29.Appearance.Options.UseBorderColor = true;
            this.P1_29.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_29.Location = new System.Drawing.Point(244, 321);
            this.P1_29.Name = "P1_29";
            this.P1_29.Size = new System.Drawing.Size(31, 124);
            this.P1_29.TabIndex = 16;
            this.P1_29.Text = "29";
            // 
            // P1_28
            // 
            this.P1_28.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_28.Appearance.Options.UseBorderColor = true;
            this.P1_28.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_28.Location = new System.Drawing.Point(191, 321);
            this.P1_28.Name = "P1_28";
            this.P1_28.Size = new System.Drawing.Size(31, 124);
            this.P1_28.TabIndex = 14;
            this.P1_28.Text = "28";
            // 
            // P1_27
            // 
            this.P1_27.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_27.Appearance.Options.UseBorderColor = true;
            this.P1_27.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_27.Location = new System.Drawing.Point(157, 321);
            this.P1_27.Name = "P1_27";
            this.P1_27.Size = new System.Drawing.Size(31, 124);
            this.P1_27.TabIndex = 12;
            this.P1_27.Text = "27";
            // 
            // P1_26
            // 
            this.P1_26.Appearance.BorderColor = System.Drawing.Color.Black;
            this.P1_26.Appearance.Options.UseBorderColor = true;
            this.P1_26.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_26.Location = new System.Drawing.Point(107, 321);
            this.P1_26.Name = "P1_26";
            this.P1_26.Size = new System.Drawing.Size(31, 124);
            this.P1_26.TabIndex = 8;
            this.P1_26.Text = "26";
            // 
            // P1_25
            // 
            this.P1_25.Appearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.P1_25.Appearance.Options.UseBorderColor = true;
            this.P1_25.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.P1_25.Location = new System.Drawing.Point(73, 321);
            this.P1_25.Name = "P1_25";
            this.P1_25.Size = new System.Drawing.Size(31, 124);
            this.P1_25.TabIndex = 4;
            this.P1_25.Text = "25";
            this.P1_25.ToolTip = "10-14";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(40, 45);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(111, 33);
            this.simpleButton2.TabIndex = 53;
            this.simpleButton2.Text = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // SurtidoresConectado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.gridControl1);
            this.Name = "SurtidoresConectado";
            this.Size = new System.Drawing.Size(1334, 608);
            this.Load += new System.EventHandler(this.SurtidoresConectado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colUsuario;
        private DevExpress.XtraGrid.Columns.TileViewColumn colNombre;
        private DevExpress.XtraGrid.Columns.TileViewColumn colArea;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton P2_38;
        private DevExpress.XtraEditors.SimpleButton P2_37;
        private DevExpress.XtraEditors.SimpleButton P2_36;
        private DevExpress.XtraEditors.SimpleButton P2_35;
        private DevExpress.XtraEditors.SimpleButton P2_34;
        private DevExpress.XtraEditors.SimpleButton P2_33;
        private DevExpress.XtraEditors.SimpleButton P2_32;
        private DevExpress.XtraEditors.SimpleButton P2_31;
        private DevExpress.XtraEditors.SimpleButton P2_30;
        private DevExpress.XtraEditors.SimpleButton P2_29;
        private DevExpress.XtraEditors.SimpleButton P2_28;
        private DevExpress.XtraEditors.SimpleButton P2_27;
        private DevExpress.XtraEditors.SimpleButton P2_26;
        private DevExpress.XtraEditors.SimpleButton P2_25;
        private DevExpress.XtraEditors.SimpleButton simpleButton30;
        private DevExpress.XtraEditors.SimpleButton simpleButton21;
        private DevExpress.XtraEditors.SimpleButton P1_38;
        private DevExpress.XtraEditors.SimpleButton P1_37;
        private DevExpress.XtraEditors.SimpleButton P1_36;
        private DevExpress.XtraEditors.SimpleButton P1_35;
        private DevExpress.XtraEditors.SimpleButton P1_34;
        private DevExpress.XtraEditors.SimpleButton P1_33;
        private DevExpress.XtraEditors.SimpleButton P1_32;
        private DevExpress.XtraEditors.SimpleButton P1_31;
        private DevExpress.XtraEditors.SimpleButton P1_30;
        private DevExpress.XtraEditors.SimpleButton P1_29;
        private DevExpress.XtraEditors.SimpleButton P1_28;
        private DevExpress.XtraEditors.SimpleButton P1_27;
        private DevExpress.XtraEditors.SimpleButton P1_26;
        private DevExpress.XtraEditors.SimpleButton P1_25;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
