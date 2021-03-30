namespace SAI_NETSUITE.Views.Logistica.Reportes
{
    partial class ParametrosFacturasXEmbarcar
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.diasReporteXEmbarcarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidReporteXEmbarcar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasReporteXEmbarcarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.diasReporteXEmbarcarBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.gridControl1.Size = new System.Drawing.Size(800, 450);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // diasReporteXEmbarcarBindingSource
            // 
            this.diasReporteXEmbarcarBindingSource.DataSource = typeof(SAI_NETSUITE.DiasReporteXEmbarcar);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidReporteXEmbarcar,
            this.colEstado,
            this.colResponsable,
            this.colDias});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colidReporteXEmbarcar
            // 
            this.colidReporteXEmbarcar.FieldName = "idReporteXEmbarcar";
            this.colidReporteXEmbarcar.Name = "colidReporteXEmbarcar";
            // 
            // colEstado
            // 
            this.colEstado.ColumnEdit = this.repositoryItemComboBox1;
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 0;
            // 
            // colResponsable
            // 
            this.colResponsable.ColumnEdit = this.repositoryItemComboBox2;
            this.colResponsable.FieldName = "Responsable";
            this.colResponsable.Name = "colResponsable";
            this.colResponsable.Visible = true;
            this.colResponsable.VisibleIndex = 1;
            // 
            // colDias
            // 
            this.colDias.FieldName = "Dias";
            this.colDias.Name = "colDias";
            this.colDias.Visible = true;
            this.colDias.VisibleIndex = 2;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // ParametrosFacturasXEmbarcar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Name = "ParametrosFacturasXEmbarcar";
            this.Text = "ParametrosFacturasXEmbarcar";
            this.Load += new System.EventHandler(this.ParametrosFacturasXEmbarcar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diasReporteXEmbarcarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource diasReporteXEmbarcarBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colidReporteXEmbarcar;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn colDias;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
    }
}