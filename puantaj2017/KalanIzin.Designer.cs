namespace puantaj2017
{
    partial class KalanIzin
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
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo1 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo2 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo3 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo4 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo5 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo6 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo7 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo8 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.FieldInfo fieldInfo9 = new DevExpress.DataAccess.Excel.FieldInfo();
            DevExpress.DataAccess.Excel.ExcelSourceOptions excelSourceOptions1 = new DevExpress.DataAccess.Excel.ExcelSourceOptions();
            DevExpress.DataAccess.Excel.ExcelWorksheetSettings excelWorksheetSettings1 = new DevExpress.DataAccess.Excel.ExcelWorksheetSettings();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.excelDataSource1 = new DevExpress.DataAccess.Excel.ExcelDataSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonelKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdıSoyadı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSicilNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiriştarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKıdemtarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKıdemyılı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKıdemayı = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKıdemgünü = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToplamkalanyıllıkizingünü = new DevExpress.XtraGrid.Columns.GridColumn();
            this.birim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birimleriEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailGönderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.excelDataSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(709, 502);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // excelDataSource1
            // 
            this.excelDataSource1.FileName = "C:\\Users\\noskay\\Desktop\\izinler.xlsx";
            this.excelDataSource1.Name = "excelDataSource1";
            fieldInfo1.Name = "Personel Kodu";
            fieldInfo1.Type = typeof(string);
            fieldInfo2.Name = "Adı Soyadı";
            fieldInfo2.Type = typeof(string);
            fieldInfo3.Name = "Sicil No";
            fieldInfo3.Type = typeof(string);
            fieldInfo4.Name = "Giriş tarihi";
            fieldInfo4.Type = typeof(System.DateTime);
            fieldInfo5.Name = "Kıdem tarihi";
            fieldInfo5.Type = typeof(System.DateTime);
            fieldInfo6.Name = "Kıdem yılı";
            fieldInfo6.Type = typeof(double);
            fieldInfo7.Name = "Kıdem ayı";
            fieldInfo7.Type = typeof(double);
            fieldInfo8.Name = "Kıdem günü";
            fieldInfo8.Type = typeof(double);
            fieldInfo9.Name = "Toplam kalan yıllık izin günü";
            fieldInfo9.Type = typeof(double);
            this.excelDataSource1.Schema.AddRange(new DevExpress.DataAccess.Excel.FieldInfo[] {
            fieldInfo1,
            fieldInfo2,
            fieldInfo3,
            fieldInfo4,
            fieldInfo5,
            fieldInfo6,
            fieldInfo7,
            fieldInfo8,
            fieldInfo9});
            excelWorksheetSettings1.CellRange = null;
            excelWorksheetSettings1.WorksheetName = "izinler";
            excelSourceOptions1.ImportSettings = excelWorksheetSettings1;
            this.excelDataSource1.SourceOptions = excelSourceOptions1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonelKodu,
            this.colAdıSoyadı,
            this.colSicilNo,
            this.colGiriştarihi,
            this.colKıdemtarihi,
            this.colKıdemyılı,
            this.colKıdemayı,
            this.colKıdemgünü,
            this.colToplamkalanyıllıkizingünü,
            this.birim});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colPersonelKodu
            // 
            this.colPersonelKodu.FieldName = "Personel Kodu";
            this.colPersonelKodu.Name = "colPersonelKodu";
            this.colPersonelKodu.Visible = true;
            this.colPersonelKodu.VisibleIndex = 0;
            this.colPersonelKodu.Width = 69;
            // 
            // colAdıSoyadı
            // 
            this.colAdıSoyadı.FieldName = "Adı Soyadı";
            this.colAdıSoyadı.Name = "colAdıSoyadı";
            this.colAdıSoyadı.Visible = true;
            this.colAdıSoyadı.VisibleIndex = 2;
            this.colAdıSoyadı.Width = 62;
            // 
            // colSicilNo
            // 
            this.colSicilNo.FieldName = "Sicil No";
            this.colSicilNo.Name = "colSicilNo";
            this.colSicilNo.Visible = true;
            this.colSicilNo.VisibleIndex = 3;
            this.colSicilNo.Width = 62;
            // 
            // colGiriştarihi
            // 
            this.colGiriştarihi.FieldName = "Giriş tarihi";
            this.colGiriştarihi.Name = "colGiriştarihi";
            this.colGiriştarihi.Visible = true;
            this.colGiriştarihi.VisibleIndex = 4;
            this.colGiriştarihi.Width = 62;
            // 
            // colKıdemtarihi
            // 
            this.colKıdemtarihi.FieldName = "Kıdem tarihi";
            this.colKıdemtarihi.Name = "colKıdemtarihi";
            this.colKıdemtarihi.Visible = true;
            this.colKıdemtarihi.VisibleIndex = 5;
            this.colKıdemtarihi.Width = 62;
            // 
            // colKıdemyılı
            // 
            this.colKıdemyılı.FieldName = "Kıdem yılı";
            this.colKıdemyılı.Name = "colKıdemyılı";
            this.colKıdemyılı.Visible = true;
            this.colKıdemyılı.VisibleIndex = 6;
            this.colKıdemyılı.Width = 62;
            // 
            // colKıdemayı
            // 
            this.colKıdemayı.FieldName = "Kıdem ayı";
            this.colKıdemayı.Name = "colKıdemayı";
            this.colKıdemayı.Visible = true;
            this.colKıdemayı.VisibleIndex = 7;
            this.colKıdemayı.Width = 62;
            // 
            // colKıdemgünü
            // 
            this.colKıdemgünü.FieldName = "Kıdem günü";
            this.colKıdemgünü.Name = "colKıdemgünü";
            this.colKıdemgünü.Visible = true;
            this.colKıdemgünü.VisibleIndex = 8;
            this.colKıdemgünü.Width = 62;
            // 
            // colToplamkalanyıllıkizingünü
            // 
            this.colToplamkalanyıllıkizingünü.FieldName = "Toplam kalan yıllık izin günü";
            this.colToplamkalanyıllıkizingünü.Name = "colToplamkalanyıllıkizingünü";
            this.colToplamkalanyıllıkizingünü.Visible = true;
            this.colToplamkalanyıllıkizingünü.VisibleIndex = 9;
            this.colToplamkalanyıllıkizingünü.Width = 65;
            // 
            // birim
            // 
            this.birim.Caption = "Birim";
            this.birim.FieldName = "Birim";
            this.birim.Name = "birim";
            this.birim.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.birim.Visible = true;
            this.birim.VisibleIndex = 1;
            this.birim.Width = 123;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.birimleriEkleToolStripMenuItem,
            this.mailGönderToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // birimleriEkleToolStripMenuItem
            // 
            this.birimleriEkleToolStripMenuItem.Name = "birimleriEkleToolStripMenuItem";
            this.birimleriEkleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.birimleriEkleToolStripMenuItem.Text = "Birimleri Ekle";
            this.birimleriEkleToolStripMenuItem.Click += new System.EventHandler(this.birimleriEkleToolStripMenuItem_Click);
            // 
            // mailGönderToolStripMenuItem
            // 
            this.mailGönderToolStripMenuItem.Name = "mailGönderToolStripMenuItem";
            this.mailGönderToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mailGönderToolStripMenuItem.Text = "Mail Gönder";
            this.mailGönderToolStripMenuItem.Click += new System.EventHandler(this.mailGönderToolStripMenuItem_Click);
            // 
            // KalanIzin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 526);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KalanIzin";
            this.Text = "KalanIzin";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.DataAccess.Excel.ExcelDataSource excelDataSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colAdıSoyadı;
        private DevExpress.XtraGrid.Columns.GridColumn colSicilNo;
        private DevExpress.XtraGrid.Columns.GridColumn colGiriştarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colKıdemtarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colKıdemyılı;
        private DevExpress.XtraGrid.Columns.GridColumn colKıdemayı;
        private DevExpress.XtraGrid.Columns.GridColumn colKıdemgünü;
        private DevExpress.XtraGrid.Columns.GridColumn colToplamkalanyıllıkizingünü;
        private DevExpress.XtraGrid.Columns.GridColumn birim;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem birimleriEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailGönderToolStripMenuItem;
    }
}