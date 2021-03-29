namespace puantaj2017
{
    partial class IzinRapor
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
            this.ızinGridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coladsoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colizintip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colaciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yazdırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puantajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarıEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinleriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ızinGridBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.ızinGridBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(790, 498);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ızinGridBindingSource
            // 
            this.ızinGridBindingSource.DataSource = typeof(puantaj2017.DAL.IzinGrid);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coladsoyad,
            this.coltarih,
            this.colizintip,
            this.colaciklama,
            this.ID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.gridView1.Name = "gridView1";
            //this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            //this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            //this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            //this.gridView1.OptionsView.ShowGroupPanelColumnsAsSingleRow = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.coladsoyad, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colizintip, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // coladsoyad
            // 
            this.coladsoyad.FieldName = "adsoyad";
            this.coladsoyad.Name = "coladsoyad";
            this.coladsoyad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "adsoyad", "{0}")});
            this.coladsoyad.Visible = true;
            this.coladsoyad.VisibleIndex = 0;
            // 
            // coltarih
            // 
            this.coltarih.FieldName = "tarih";
            this.coltarih.Name = "coltarih";
            this.coltarih.Visible = true;
            this.coltarih.VisibleIndex = 0;
            // 
            // colizintip
            // 
            this.colizintip.Caption = "İzin Tipi";
            this.colizintip.FieldName = "izintip";
            this.colizintip.Name = "colizintip";
            this.colizintip.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "izintip", "{0}")});
            this.colizintip.Visible = true;
            this.colizintip.VisibleIndex = 1;
            // 
            // colaciklama
            // 
            this.colaciklama.FieldName = "aciklama";
            this.colaciklama.Name = "colaciklama";
            this.colaciklama.Visible = true;
            this.colaciklama.VisibleIndex = 2;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem,
            this.puantajToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(790, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.yazdırToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // yazdırToolStripMenuItem
            // 
            this.yazdırToolStripMenuItem.Name = "yazdırToolStripMenuItem";
            this.yazdırToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.yazdırToolStripMenuItem.Text = "Yazdır";
            this.yazdırToolStripMenuItem.Click += new System.EventHandler(this.yazdırToolStripMenuItem_Click);
            // 
            // puantajToolStripMenuItem
            // 
            this.puantajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raporlarıEkleToolStripMenuItem,
            this.izinleriEkleToolStripMenuItem});
            this.puantajToolStripMenuItem.Name = "puantajToolStripMenuItem";
            this.puantajToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.puantajToolStripMenuItem.Text = "Puantaj";
            // 
            // raporlarıEkleToolStripMenuItem
            // 
            this.raporlarıEkleToolStripMenuItem.Name = "raporlarıEkleToolStripMenuItem";
            this.raporlarıEkleToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.raporlarıEkleToolStripMenuItem.Text = "Raporları Ekle";
            this.raporlarıEkleToolStripMenuItem.Click += new System.EventHandler(this.raporlarıEkleToolStripMenuItem_Click);
            // 
            // izinleriEkleToolStripMenuItem
            // 
            this.izinleriEkleToolStripMenuItem.Name = "izinleriEkleToolStripMenuItem";
            this.izinleriEkleToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.izinleriEkleToolStripMenuItem.Text = "İzinleri Ekle";
            this.izinleriEkleToolStripMenuItem.Click += new System.EventHandler(this.izinleriEkleToolStripMenuItem_Click);
            // 
            // IzinRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 522);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IzinRapor";
            this.Text = "IzinRapor";
            this.Load += new System.EventHandler(this.IzinRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ızinGridBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource ızinGridBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn coladsoyad;
        private DevExpress.XtraGrid.Columns.GridColumn coltarih;
        private DevExpress.XtraGrid.Columns.GridColumn colizintip;
        private DevExpress.XtraGrid.Columns.GridColumn colaciklama;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yazdırToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private System.Windows.Forms.ToolStripMenuItem puantajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarıEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinleriEkleToolStripMenuItem;
    }
}