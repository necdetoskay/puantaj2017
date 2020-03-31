namespace puantaj2017
{
    partial class Mesailer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaydetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.girişSaat830AyarlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesaileriYükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aaaaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelMesaiDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHafta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPersonelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonelAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGirisSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCikisSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTatil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYemek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dakika = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownYil = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAy = new System.Windows.Forms.NumericUpDown();
            this.cBEksikHesap = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::puantaj2017.WaitForm1), true, true);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personelMesaiDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAy)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem,
            this.yükleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(851, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydetToolStripMenuItem1,
            this.girişSaat830AyarlaToolStripMenuItem});
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.kaydetToolStripMenuItem.Text = "Ayarlar";
            // 
            // kaydetToolStripMenuItem1
            // 
            this.kaydetToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem1});
            this.kaydetToolStripMenuItem1.Name = "kaydetToolStripMenuItem1";
            this.kaydetToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.kaydetToolStripMenuItem1.Text = "Kaydet";
            this.kaydetToolStripMenuItem1.Click += new System.EventHandler(this.kaydetToolStripMenuItem1_Click);
            // 
            // excelToolStripMenuItem1
            // 
            this.excelToolStripMenuItem1.Name = "excelToolStripMenuItem1";
            this.excelToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.excelToolStripMenuItem1.Text = "Excel";
            this.excelToolStripMenuItem1.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // girişSaat830AyarlaToolStripMenuItem
            // 
            this.girişSaat830AyarlaToolStripMenuItem.Name = "girişSaat830AyarlaToolStripMenuItem";
            this.girişSaat830AyarlaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.girişSaat830AyarlaToolStripMenuItem.Text = "Giriş Saat 8:30 ayarla";
            this.girişSaat830AyarlaToolStripMenuItem.Click += new System.EventHandler(this.girişSaat830AyarlaToolStripMenuItem_Click);
            // 
            // yükleToolStripMenuItem
            // 
            this.yükleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mesaileriYükleToolStripMenuItem});
            this.yükleToolStripMenuItem.Name = "yükleToolStripMenuItem";
            this.yükleToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.yükleToolStripMenuItem.Text = "Yükle";
            // 
            // mesaileriYükleToolStripMenuItem
            // 
            this.mesaileriYükleToolStripMenuItem.Name = "mesaileriYükleToolStripMenuItem";
            this.mesaileriYükleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.mesaileriYükleToolStripMenuItem.Text = "Mesaileri Yükle";
            this.mesaileriYükleToolStripMenuItem.Click += new System.EventHandler(this.mesaileriYükleToolStripMenuItem_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.DataSource = this.personelMesaiDataBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 82);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(851, 337);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aaaaaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // aaaaaToolStripMenuItem
            // 
            this.aaaaaToolStripMenuItem.Name = "aaaaaToolStripMenuItem";
            this.aaaaaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.aaaaaToolStripMenuItem.Text = "Mesai Hesapla";
            this.aaaaaToolStripMenuItem.Click += new System.EventHandler(this.aaaaaToolStripMenuItem_Click);
            // 
            // personelMesaiDataBindingSource
            // 
            this.personelMesaiDataBindingSource.DataSource = typeof(puantaj2017.DAL.PersonelMesaiData);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHafta,
            this.colPersonelID,
            this.colPersonelAdSoyad,
            this.colTarih,
            this.gridColumn1,
            this.colGirisSaat,
            this.colCikisSaat,
            this.colTatil,
            this.colYemek,
            this.colHesapla,
            this.dakika});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ToplamDakika", this.dakika, "(Hafta: SUM={0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPersonelAdSoyad, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colHafta, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChanged);
            // 
            // colHafta
            // 
            this.colHafta.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colHafta.FieldName = "Hafta";
            this.colHafta.Name = "colHafta";
            this.colHafta.OptionsColumn.ReadOnly = true;
            this.colHafta.Visible = true;
            this.colHafta.VisibleIndex = 0;
            this.colHafta.Width = 85;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // colPersonelID
            // 
            this.colPersonelID.FieldName = "PersonelID";
            this.colPersonelID.Name = "colPersonelID";
            this.colPersonelID.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colPersonelID.OptionsColumn.ReadOnly = true;
            this.colPersonelID.Visible = true;
            this.colPersonelID.VisibleIndex = 0;
            this.colPersonelID.Width = 69;
            // 
            // colPersonelAdSoyad
            // 
            this.colPersonelAdSoyad.FieldName = "PersonelAdSoyad";
            this.colPersonelAdSoyad.Name = "colPersonelAdSoyad";
            this.colPersonelAdSoyad.OptionsColumn.ReadOnly = true;
            this.colPersonelAdSoyad.Visible = true;
            this.colPersonelAdSoyad.VisibleIndex = 2;
            this.colPersonelAdSoyad.Width = 116;
            // 
            // colTarih
            // 
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.OptionsColumn.ReadOnly = true;
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 1;
            this.colTarih.Width = 66;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Haftanın Günü";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 177;
            // 
            // colGirisSaat
            // 
            this.colGirisSaat.Caption = "Giriş Saat";
            this.colGirisSaat.FieldName = "GirisSaat";
            this.colGirisSaat.Name = "colGirisSaat";
            this.colGirisSaat.Visible = true;
            this.colGirisSaat.VisibleIndex = 2;
            this.colGirisSaat.Width = 68;
            // 
            // colCikisSaat
            // 
            this.colCikisSaat.Caption = "Çıkış Saat";
            this.colCikisSaat.FieldName = "CikisSaat";
            this.colCikisSaat.Name = "colCikisSaat";
            this.colCikisSaat.Visible = true;
            this.colCikisSaat.VisibleIndex = 3;
            this.colCikisSaat.Width = 70;
            // 
            // colTatil
            // 
            this.colTatil.Caption = "Tatil";
            this.colTatil.FieldName = "Tatil";
            this.colTatil.Name = "colTatil";
            this.colTatil.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colTatil.Visible = true;
            this.colTatil.VisibleIndex = 4;
            this.colTatil.Width = 51;
            // 
            // colYemek
            // 
            this.colYemek.Caption = "Yemek";
            this.colYemek.FieldName = "Yemek";
            this.colYemek.Name = "colYemek";
            this.colYemek.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colYemek.Visible = true;
            this.colYemek.VisibleIndex = 5;
            this.colYemek.Width = 57;
            // 
            // colHesapla
            // 
            this.colHesapla.Caption = "Hesapla";
            this.colHesapla.FieldName = "Hesapla";
            this.colHesapla.Name = "colHesapla";
            this.colHesapla.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colHesapla.Visible = true;
            this.colHesapla.VisibleIndex = 6;
            this.colHesapla.Width = 61;
            // 
            // dakika
            // 
            this.dakika.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dakika.FieldName = "ToplamDakika";
            this.dakika.Name = "dakika";
            this.dakika.Visible = true;
            this.dakika.VisibleIndex = 7;
            this.dakika.Width = 171;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownYil);
            this.panel1.Controls.Add(this.numericUpDownAy);
            this.panel1.Controls.Add(this.cBEksikHesap);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 58);
            this.panel1.TabIndex = 11;
            // 
            // numericUpDownYil
            // 
            this.numericUpDownYil.Location = new System.Drawing.Point(697, 3);
            this.numericUpDownYil.Maximum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.numericUpDownYil.Minimum = new decimal(new int[] {
            2006,
            0,
            0,
            0});
            this.numericUpDownYil.Name = "numericUpDownYil";
            this.numericUpDownYil.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownYil.TabIndex = 3;
            this.numericUpDownYil.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // numericUpDownAy
            // 
            this.numericUpDownAy.Location = new System.Drawing.Point(777, 3);
            this.numericUpDownAy.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownAy.Name = "numericUpDownAy";
            this.numericUpDownAy.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownAy.TabIndex = 3;
            // 
            // cBEksikHesap
            // 
            this.cBEksikHesap.AutoSize = true;
            this.cBEksikHesap.Location = new System.Drawing.Point(521, 4);
            this.cBEksikHesap.Name = "cBEksikHesap";
            this.cBEksikHesap.Size = new System.Drawing.Size(119, 17);
            this.cBEksikHesap.TabIndex = 2;
            this.cBEksikHesap.Text = "Eksik Saat Hesapla";
            this.cBEksikHesap.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Yükle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(138, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // Mesailer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 419);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mesailer";
            this.Text = "Mesailer";
            this.Load += new System.EventHandler(this.Mesailer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personelMesaiDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource personelMesaiDataBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colHafta;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelID;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelAdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colGirisSaat;
        private DevExpress.XtraGrid.Columns.GridColumn colCikisSaat;
        private DevExpress.XtraGrid.Columns.GridColumn colTatil;
        private DevExpress.XtraGrid.Columns.GridColumn colYemek;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapla;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaaaaToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn dakika;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem girişSaat830AyarlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yükleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesaileriYükleToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.CheckBox cBEksikHesap;
        private System.Windows.Forms.NumericUpDown numericUpDownAy;
        private System.Windows.Forms.NumericUpDown numericUpDownYil;
    }
}