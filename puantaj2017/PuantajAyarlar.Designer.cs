namespace puantaj2017
{
    partial class PuantajAyarlar
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
            this.birimBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbirimad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfullad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsira = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpuantaj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.birimBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.birimBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(714, 428);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // birimBindingSource
            // 
            this.birimBindingSource.DataSource = typeof(puantaj2017.DAL.birim);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colbirimad,
            this.colfullad,
            this.colsira,
            this.colpuantaj,
            this.colPersonels});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Width = 98;
            // 
            // colbirimad
            // 
            this.colbirimad.FieldName = "birimad";
            this.colbirimad.Name = "colbirimad";
            this.colbirimad.Visible = true;
            this.colbirimad.VisibleIndex = 0;
            this.colbirimad.Width = 119;
            // 
            // colfullad
            // 
            this.colfullad.FieldName = "fullad";
            this.colfullad.Name = "colfullad";
            this.colfullad.Visible = true;
            this.colfullad.VisibleIndex = 1;
            this.colfullad.Width = 119;
            // 
            // colsira
            // 
            this.colsira.FieldName = "sira";
            this.colsira.Name = "colsira";
            this.colsira.Visible = true;
            this.colsira.VisibleIndex = 2;
            this.colsira.Width = 119;
            // 
            // colpuantaj
            // 
            this.colpuantaj.FieldName = "puantaj";
            this.colpuantaj.Name = "colpuantaj";
            this.colpuantaj.Visible = true;
            this.colpuantaj.VisibleIndex = 3;
            this.colpuantaj.Width = 119;
            // 
            // colPersonels
            // 
            this.colPersonels.Name = "colPersonels";
            this.colPersonels.Visible = true;
            this.colPersonels.VisibleIndex = 4;
            this.colPersonels.Width = 122;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.kaydetToolStripMenuItem_Click);
            // 
            // PuantajAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 452);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PuantajAyarlar";
            this.Text = "PuantajAyarlar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PuantajAyarlar_FormClosed);
            this.Load += new System.EventHandler(this.PuantajAyarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.birimBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource birimBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colbirimad;
        private DevExpress.XtraGrid.Columns.GridColumn colfullad;
        private DevExpress.XtraGrid.Columns.GridColumn colsira;
        private DevExpress.XtraGrid.Columns.GridColumn colpuantaj;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonels;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
    }
}