namespace puantaj2017
{
    partial class PuantajForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birimlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avanslarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yıllıkİzinlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.denkleştirmelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mazeretlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdksRaporİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.girişÇıkışlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::puantaj2017.WaitForm1), true, true);
            this.geçKalanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(127, 19);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 63);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(346, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Excel Hazırla";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Hazırla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 87);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(669, 360);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.gridView1.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem,
            this.raporlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.birimlerToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // birimlerToolStripMenuItem
            // 
            this.birimlerToolStripMenuItem.Name = "birimlerToolStripMenuItem";
            this.birimlerToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.birimlerToolStripMenuItem.Text = "Birimler";
            this.birimlerToolStripMenuItem.Click += new System.EventHandler(this.birimlerToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avanslarToolStripMenuItem,
            this.yıllıkİzinlerToolStripMenuItem,
            this.raporlarToolStripMenuItem1,
            this.denkleştirmelerToolStripMenuItem,
            this.mazeretlerToolStripMenuItem,
            this.pdksRaporİşlemleriToolStripMenuItem,
            this.girişÇıkışlarToolStripMenuItem,
            this.geçKalanlarToolStripMenuItem});
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            // 
            // avanslarToolStripMenuItem
            // 
            this.avanslarToolStripMenuItem.Name = "avanslarToolStripMenuItem";
            this.avanslarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.avanslarToolStripMenuItem.Text = "Avanslar";
            this.avanslarToolStripMenuItem.Click += new System.EventHandler(this.avanslarToolStripMenuItem_Click);
            // 
            // yıllıkİzinlerToolStripMenuItem
            // 
            this.yıllıkİzinlerToolStripMenuItem.Name = "yıllıkİzinlerToolStripMenuItem";
            this.yıllıkİzinlerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yıllıkİzinlerToolStripMenuItem.Text = "Yıllık İzinler";
            this.yıllıkİzinlerToolStripMenuItem.Click += new System.EventHandler(this.yıllıkİzinlerToolStripMenuItem_Click);
            // 
            // raporlarToolStripMenuItem1
            // 
            this.raporlarToolStripMenuItem1.Name = "raporlarToolStripMenuItem1";
            this.raporlarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.raporlarToolStripMenuItem1.Text = "Raporlar";
            this.raporlarToolStripMenuItem1.Click += new System.EventHandler(this.raporlarToolStripMenuItem1_Click);
            // 
            // denkleştirmelerToolStripMenuItem
            // 
            this.denkleştirmelerToolStripMenuItem.Name = "denkleştirmelerToolStripMenuItem";
            this.denkleştirmelerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.denkleştirmelerToolStripMenuItem.Text = "Denkleştirmeler";
            this.denkleştirmelerToolStripMenuItem.Click += new System.EventHandler(this.denkleştirmelerToolStripMenuItem_Click);
            // 
            // mazeretlerToolStripMenuItem
            // 
            this.mazeretlerToolStripMenuItem.Name = "mazeretlerToolStripMenuItem";
            this.mazeretlerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mazeretlerToolStripMenuItem.Text = "Mazeretler";
            this.mazeretlerToolStripMenuItem.Click += new System.EventHandler(this.mazeretlerToolStripMenuItem_Click);
            // 
            // pdksRaporİşlemleriToolStripMenuItem
            // 
            this.pdksRaporİşlemleriToolStripMenuItem.Name = "pdksRaporİşlemleriToolStripMenuItem";
            this.pdksRaporİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pdksRaporİşlemleriToolStripMenuItem.Text = "Pdks Rapor İşlemleri";
            this.pdksRaporİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.pdksRaporİşlemleriToolStripMenuItem_Click);
            // 
            // girişÇıkışlarToolStripMenuItem
            // 
            this.girişÇıkışlarToolStripMenuItem.Name = "girişÇıkışlarToolStripMenuItem";
            this.girişÇıkışlarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.girişÇıkışlarToolStripMenuItem.Text = "Giriş Çıkışlar";
            this.girişÇıkışlarToolStripMenuItem.Click += new System.EventHandler(this.girişÇıkışlarToolStripMenuItem_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // geçKalanlarToolStripMenuItem
            // 
            this.geçKalanlarToolStripMenuItem.Name = "geçKalanlarToolStripMenuItem";
            this.geçKalanlarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.geçKalanlarToolStripMenuItem.Text = "Geç Kalanlar";
            this.geçKalanlarToolStripMenuItem.Click += new System.EventHandler(this.geçKalanlarToolStripMenuItem_Click);
            // 
            // PuantajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 447);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PuantajForm";
            this.Text = "Puantaj";
            this.Load += new System.EventHandler(this.Puantaj_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem birimlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avanslarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yıllıkİzinlerToolStripMenuItem;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem denkleştirmelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mazeretlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pdksRaporİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem girişÇıkışlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geçKalanlarToolStripMenuItem;
    }
}