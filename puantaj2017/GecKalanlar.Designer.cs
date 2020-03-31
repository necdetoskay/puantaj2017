namespace puantaj2017
{
    partial class GecKalanlar
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.monthEdit1 = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelGönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geçKalanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkıştaKartBasmayanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.puantajTakipBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDepartman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiris = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GirisSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCikis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMazeretAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMazeretGidisSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMazeretGelisSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthEdit1.Properties)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puantajTakipBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hazırla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.monthEdit1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 57);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(710, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Mail Gönder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // monthEdit1
            // 
            this.monthEdit1.Location = new System.Drawing.Point(25, 31);
            this.monthEdit1.Name = "monthEdit1";
            this.monthEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.monthEdit1.Size = new System.Drawing.Size(153, 20);
            this.monthEdit1.TabIndex = 3;
            this.monthEdit1.SelectedIndexChanged += new System.EventHandler(this.monthEdit1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raporlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelGönderToolStripMenuItem,
            this.geçKalanlarToolStripMenuItem,
            this.çıkıştaKartBasmayanlarToolStripMenuItem});
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            // 
            // excelGönderToolStripMenuItem
            // 
            this.excelGönderToolStripMenuItem.Name = "excelGönderToolStripMenuItem";
            this.excelGönderToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.excelGönderToolStripMenuItem.Text = "Excel Gönder";
            this.excelGönderToolStripMenuItem.Click += new System.EventHandler(this.excelGönderToolStripMenuItem_Click);
            // 
            // geçKalanlarToolStripMenuItem
            // 
            this.geçKalanlarToolStripMenuItem.Name = "geçKalanlarToolStripMenuItem";
            this.geçKalanlarToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.geçKalanlarToolStripMenuItem.Text = "Geç Kalanlar";
            this.geçKalanlarToolStripMenuItem.Click += new System.EventHandler(this.geçKalanlarToolStripMenuItem_Click);
            // 
            // çıkıştaKartBasmayanlarToolStripMenuItem
            // 
            this.çıkıştaKartBasmayanlarToolStripMenuItem.Name = "çıkıştaKartBasmayanlarToolStripMenuItem";
            this.çıkıştaKartBasmayanlarToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.çıkıştaKartBasmayanlarToolStripMenuItem.Text = "Çıkışta Kart Basmayanlar";
            this.çıkıştaKartBasmayanlarToolStripMenuItem.Click += new System.EventHandler(this.çıkıştaKartBasmayanlarToolStripMenuItem_Click_1);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.puantajTakipBindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 57);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(846, 472);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // puantajTakipBindingSource1
            // 
            this.puantajTakipBindingSource1.DataSource = typeof(puantaj2017.DAL.PuantajTakip);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDepartman,
            this.ID,
            this.colAdSoyad,
            this.colTarih,
            this.colGiris,
            this.GirisSaat,
            this.colCikis,
            this.colMazeretAciklama,
            this.colMazeretGidisSaat,
            this.colMazeretGelisSaat,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Fark", null, "(Fark: SUM={0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsPrint.PrintPreview = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.SynchronizeClones = false;
            // 
            // colDepartman
            // 
            this.colDepartman.FieldName = "Departman";
            this.colDepartman.Name = "colDepartman";
            this.colDepartman.Visible = true;
            this.colDepartman.VisibleIndex = 1;
            this.colDepartman.Width = 77;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 63;
            // 
            // colAdSoyad
            // 
            this.colAdSoyad.FieldName = "AdSoyad";
            this.colAdSoyad.Name = "colAdSoyad";
            this.colAdSoyad.Visible = true;
            this.colAdSoyad.VisibleIndex = 2;
            this.colAdSoyad.Width = 118;
            // 
            // colTarih
            // 
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 3;
            this.colTarih.Width = 61;
            // 
            // colGiris
            // 
            this.colGiris.FieldName = "Giris";
            this.colGiris.Name = "colGiris";
            this.colGiris.Visible = true;
            this.colGiris.VisibleIndex = 4;
            this.colGiris.Width = 63;
            // 
            // GirisSaat
            // 
            this.GirisSaat.Caption = "gridColumn2";
            this.GirisSaat.FieldName = "GirisSaat";
            this.GirisSaat.Name = "GirisSaat";
            this.GirisSaat.UnboundExpression = "Concat(GetDate([Tarih]), \' \', [Giris])";
            this.GirisSaat.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.GirisSaat.Visible = true;
            this.GirisSaat.VisibleIndex = 5;
            this.GirisSaat.Width = 90;
            // 
            // colCikis
            // 
            this.colCikis.FieldName = "Cikis";
            this.colCikis.Name = "colCikis";
            this.colCikis.Visible = true;
            this.colCikis.VisibleIndex = 7;
            this.colCikis.Width = 76;
            // 
            // colMazeretAciklama
            // 
            this.colMazeretAciklama.FieldName = "MazeretAciklama";
            this.colMazeretAciklama.Name = "colMazeretAciklama";
            this.colMazeretAciklama.OptionsColumn.AllowEdit = false;
            this.colMazeretAciklama.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colMazeretAciklama.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colMazeretAciklama.Visible = true;
            this.colMazeretAciklama.VisibleIndex = 8;
            this.colMazeretAciklama.Width = 76;
            // 
            // colMazeretGidisSaat
            // 
            this.colMazeretGidisSaat.FieldName = "MazeretGidisSaat";
            this.colMazeretGidisSaat.Name = "colMazeretGidisSaat";
            this.colMazeretGidisSaat.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colMazeretGidisSaat.Visible = true;
            this.colMazeretGidisSaat.VisibleIndex = 9;
            this.colMazeretGidisSaat.Width = 108;
            // 
            // colMazeretGelisSaat
            // 
            this.colMazeretGelisSaat.FieldName = "MazeretGelisSaat";
            this.colMazeretGelisSaat.Name = "colMazeretGelisSaat";
            this.colMazeretGelisSaat.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colMazeretGelisSaat.Visible = true;
            this.colMazeretGelisSaat.VisibleIndex = 10;
            this.colMazeretGelisSaat.Width = 67;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.FieldName = "Fark";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Fark", "SUM={0:0.##}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 29;
            // 
            // GecKalanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 529);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GecKalanlar";
            this.Text = "Geç Kalanlar Raporu";
            this.Load += new System.EventHandler(this.GecKalanlar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthEdit1.Properties)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puantajTakipBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelGönderToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource puantajTakipBindingSource1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartman;
        private DevExpress.XtraGrid.Columns.GridColumn colAdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colGiris;
        private DevExpress.XtraGrid.Columns.GridColumn colCikis;
        private DevExpress.XtraGrid.Columns.GridColumn colMazeretAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colMazeretGidisSaat;
        private DevExpress.XtraGrid.Columns.GridColumn colMazeretGelisSaat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ToolStripMenuItem geçKalanlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkıştaKartBasmayanlarToolStripMenuItem;
        private DevExpress.XtraScheduler.UI.MonthEdit monthEdit1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn GirisSaat;
    }
}