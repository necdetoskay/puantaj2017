namespace PtakipDAL
{
    partial class Birimler
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.personelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coladsoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpuantaj1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsira1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.birimBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbirimad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfullad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsira = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpuantaj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.birimBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControl2);
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 494);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.personelBindingSource;
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(361, 16);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(468, 475);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // personelBindingSource
            // 
            this.personelBindingSource.DataSource = typeof(puantaj2017.DAL.Personel);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.coladsoyad,
            this.colpuantaj1,
            this.colsira1});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // colid1
            // 
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            this.colid1.Visible = true;
            this.colid1.VisibleIndex = 0;
            this.colid1.Width = 39;
            // 
            // coladsoyad
            // 
            this.coladsoyad.FieldName = "adsoyad";
            this.coladsoyad.Name = "coladsoyad";
            this.coladsoyad.Visible = true;
            this.coladsoyad.VisibleIndex = 1;
            this.coladsoyad.Width = 230;
            // 
            // colpuantaj1
            // 
            this.colpuantaj1.FieldName = "puantaj";
            this.colpuantaj1.Name = "colpuantaj1";
            this.colpuantaj1.Visible = true;
            this.colpuantaj1.VisibleIndex = 2;
            this.colpuantaj1.Width = 46;
            // 
            // colsira1
            // 
            this.colsira1.FieldName = "sira";
            this.colsira1.Name = "colsira1";
            this.colsira1.Visible = true;
            this.colsira1.VisibleIndex = 3;
            this.colsira1.Width = 31;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.birimBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(3, 16);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(358, 475);
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
            this.colpuantaj});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            this.colid.Width = 26;
            // 
            // colbirimad
            // 
            this.colbirimad.FieldName = "birimad";
            this.colbirimad.Name = "colbirimad";
            this.colbirimad.Visible = true;
            this.colbirimad.VisibleIndex = 1;
            this.colbirimad.Width = 126;
            // 
            // colfullad
            // 
            this.colfullad.FieldName = "fullad";
            this.colfullad.Name = "colfullad";
            this.colfullad.Visible = true;
            this.colfullad.VisibleIndex = 2;
            this.colfullad.Width = 99;
            // 
            // colsira
            // 
            this.colsira.FieldName = "sira";
            this.colsira.Name = "colsira";
            this.colsira.Visible = true;
            this.colsira.VisibleIndex = 3;
            this.colsira.Width = 33;
            // 
            // colpuantaj
            // 
            this.colpuantaj.FieldName = "puantaj";
            this.colpuantaj.Name = "colpuantaj";
            this.colpuantaj.Visible = true;
            this.colpuantaj.VisibleIndex = 4;
            this.colpuantaj.Width = 56;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.kaydetToolStripMenuItem_Click);
            // 
            // Birimler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 518);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Birimler";
            this.Text = "Birimler";
            this.Load += new System.EventHandler(this.Birimler_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.birimBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource birimBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colbirimad;
        private DevExpress.XtraGrid.Columns.GridColumn colfullad;
        private DevExpress.XtraGrid.Columns.GridColumn colsira;
        private DevExpress.XtraGrid.Columns.GridColumn colpuantaj;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private System.Windows.Forms.BindingSource personelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coladsoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colpuantaj1;
        private DevExpress.XtraGrid.Columns.GridColumn colsira1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
    }
}