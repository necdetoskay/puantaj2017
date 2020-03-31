namespace puantaj2017
{
    partial class Form1
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
            this.dateBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dateBitis = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesaiHesaplaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eBorçSorgulamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinVeRaporDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puantajExcelHazırlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avanslarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geçKalanlarRaporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aileFertleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puantajYeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelRaporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporTaraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borcuYokturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hazineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kalanİzinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bordroBankaKarşılaştırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.puantajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dosyaTarihİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.personelListBox = new System.Windows.Forms.ListBox();
            this.personelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.puantajDataSet = new puantaj2017.DAL.puantajDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tarihDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.girissaatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelGirisCikisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.izintipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarihDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aciklamaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelIzinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.maaşKontrolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puantajDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelGirisCikisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelIzinBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dateBaslangic
            // 
            this.dateBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBaslangic.Location = new System.Drawing.Point(6, 45);
            this.dateBaslangic.Name = "dateBaslangic";
            this.dateBaslangic.Size = new System.Drawing.Size(99, 20);
            this.dateBaslangic.TabIndex = 0;
            this.dateBaslangic.Value = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            // 
            // dateBitis
            // 
            this.dateBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBitis.Location = new System.Drawing.Point(146, 45);
            this.dateBitis.Name = "dateBitis";
            this.dateBitis.Size = new System.Drawing.Size(100, 20);
            this.dateBitis.TabIndex = 0;
            this.dateBitis.Value = new System.DateTime(2017, 3, 31, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateBaslangic);
            this.groupBox1.Controls.Add(this.dateBitis);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puantaj Aralığı";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(146, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bitiş Tarihi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Başlangıç Tarihi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem,
            this.ayarlarToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(765, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mesaiHesaplaToolStripMenuItem,
            this.eBorçSorgulamaToolStripMenuItem,
            this.izinVeRaporDurumuToolStripMenuItem,
            this.puantajExcelHazırlaToolStripMenuItem,
            this.avanslarToolStripMenuItem,
            this.geçKalanlarRaporToolStripMenuItem,
            this.aileFertleriToolStripMenuItem,
            this.puantajYeniToolStripMenuItem,
            this.personelRaporlarToolStripMenuItem,
            this.raporTaraToolStripMenuItem,
            this.borcuYokturToolStripMenuItem,
            this.hazineToolStripMenuItem,
            this.kalanİzinToolStripMenuItem,
            this.bESToolStripMenuItem,
            this.bordroBankaKarşılaştırToolStripMenuItem,
            this.maaşKontrolToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ayarlarToolStripMenuItem.Text = "İşlemler";
            // 
            // mesaiHesaplaToolStripMenuItem
            // 
            this.mesaiHesaplaToolStripMenuItem.Name = "mesaiHesaplaToolStripMenuItem";
            this.mesaiHesaplaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.mesaiHesaplaToolStripMenuItem.Text = "Mesai Hesapla";
            this.mesaiHesaplaToolStripMenuItem.Click += new System.EventHandler(this.mesaiHesaplaToolStripMenuItem_Click);
            // 
            // eBorçSorgulamaToolStripMenuItem
            // 
            this.eBorçSorgulamaToolStripMenuItem.Name = "eBorçSorgulamaToolStripMenuItem";
            this.eBorçSorgulamaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.eBorçSorgulamaToolStripMenuItem.Text = "E Borç Sorgulama";
            this.eBorçSorgulamaToolStripMenuItem.Click += new System.EventHandler(this.eBorçSorgulamaToolStripMenuItem_Click);
            // 
            // izinVeRaporDurumuToolStripMenuItem
            // 
            this.izinVeRaporDurumuToolStripMenuItem.Name = "izinVeRaporDurumuToolStripMenuItem";
            this.izinVeRaporDurumuToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.izinVeRaporDurumuToolStripMenuItem.Text = "İzin ve Rapor Durumu";
            this.izinVeRaporDurumuToolStripMenuItem.Click += new System.EventHandler(this.izinVeRaporDurumuToolStripMenuItem_Click);
            // 
            // puantajExcelHazırlaToolStripMenuItem
            // 
            this.puantajExcelHazırlaToolStripMenuItem.Name = "puantajExcelHazırlaToolStripMenuItem";
            this.puantajExcelHazırlaToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.puantajExcelHazırlaToolStripMenuItem.Text = "Puantaj Excel Hazırla";
            this.puantajExcelHazırlaToolStripMenuItem.Visible = false;
            this.puantajExcelHazırlaToolStripMenuItem.Click += new System.EventHandler(this.puantajExcelHazırlaToolStripMenuItem_Click);
            // 
            // avanslarToolStripMenuItem
            // 
            this.avanslarToolStripMenuItem.Name = "avanslarToolStripMenuItem";
            this.avanslarToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.avanslarToolStripMenuItem.Text = "Avanslar";
            this.avanslarToolStripMenuItem.Click += new System.EventHandler(this.avanslarToolStripMenuItem_Click);
            // 
            // geçKalanlarRaporToolStripMenuItem
            // 
            this.geçKalanlarRaporToolStripMenuItem.Name = "geçKalanlarRaporToolStripMenuItem";
            this.geçKalanlarRaporToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.geçKalanlarRaporToolStripMenuItem.Text = "Geç Kalanlar Rapor";
            this.geçKalanlarRaporToolStripMenuItem.Click += new System.EventHandler(this.geçKalanlarRaporToolStripMenuItem_Click);
            // 
            // aileFertleriToolStripMenuItem
            // 
            this.aileFertleriToolStripMenuItem.Name = "aileFertleriToolStripMenuItem";
            this.aileFertleriToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.aileFertleriToolStripMenuItem.Text = "Aile Fertleri";
            this.aileFertleriToolStripMenuItem.Visible = false;
            this.aileFertleriToolStripMenuItem.Click += new System.EventHandler(this.aileFertleriToolStripMenuItem_Click);
            // 
            // puantajYeniToolStripMenuItem
            // 
            this.puantajYeniToolStripMenuItem.Name = "puantajYeniToolStripMenuItem";
            this.puantajYeniToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.puantajYeniToolStripMenuItem.Text = "Puantaj Yeni";
            this.puantajYeniToolStripMenuItem.Click += new System.EventHandler(this.puantajYeniToolStripMenuItem_Click);
            // 
            // personelRaporlarToolStripMenuItem
            // 
            this.personelRaporlarToolStripMenuItem.Name = "personelRaporlarToolStripMenuItem";
            this.personelRaporlarToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.personelRaporlarToolStripMenuItem.Text = "Personel Raporlar";
            this.personelRaporlarToolStripMenuItem.Click += new System.EventHandler(this.personelRaporlarToolStripMenuItem_Click);
            // 
            // raporTaraToolStripMenuItem
            // 
            this.raporTaraToolStripMenuItem.Name = "raporTaraToolStripMenuItem";
            this.raporTaraToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.raporTaraToolStripMenuItem.Text = "Rapor Tara";
            this.raporTaraToolStripMenuItem.Visible = false;
            this.raporTaraToolStripMenuItem.Click += new System.EventHandler(this.raporTaraToolStripMenuItem_Click);
            // 
            // borcuYokturToolStripMenuItem
            // 
            this.borcuYokturToolStripMenuItem.Name = "borcuYokturToolStripMenuItem";
            this.borcuYokturToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.borcuYokturToolStripMenuItem.Text = "Borcu Yoktur";
            this.borcuYokturToolStripMenuItem.Click += new System.EventHandler(this.borcuYokturToolStripMenuItem_Click);
            // 
            // hazineToolStripMenuItem
            // 
            this.hazineToolStripMenuItem.Name = "hazineToolStripMenuItem";
            this.hazineToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.hazineToolStripMenuItem.Text = "Hazine";
            this.hazineToolStripMenuItem.Visible = false;
            this.hazineToolStripMenuItem.Click += new System.EventHandler(this.hazineToolStripMenuItem_Click);
            // 
            // kalanİzinToolStripMenuItem
            // 
            this.kalanİzinToolStripMenuItem.Name = "kalanİzinToolStripMenuItem";
            this.kalanİzinToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.kalanİzinToolStripMenuItem.Text = "Kalan İzin";
            this.kalanİzinToolStripMenuItem.Click += new System.EventHandler(this.kalanİzinToolStripMenuItem_Click);
            // 
            // bESToolStripMenuItem
            // 
            this.bESToolStripMenuItem.Name = "bESToolStripMenuItem";
            this.bESToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.bESToolStripMenuItem.Text = "BES";
            this.bESToolStripMenuItem.Click += new System.EventHandler(this.bESToolStripMenuItem_Click);
            // 
            // bordroBankaKarşılaştırToolStripMenuItem
            // 
            this.bordroBankaKarşılaştırToolStripMenuItem.Name = "bordroBankaKarşılaştırToolStripMenuItem";
            this.bordroBankaKarşılaştırToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.bordroBankaKarşılaştırToolStripMenuItem.Text = "Bordro Banka Karşılaştır";
            this.bordroBankaKarşılaştırToolStripMenuItem.Click += new System.EventHandler(this.bordroBankaKarşılaştırToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem1
            // 
            this.ayarlarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puantajToolStripMenuItem,
            this.dosyaTarihİşlemleriToolStripMenuItem});
            this.ayarlarToolStripMenuItem1.Name = "ayarlarToolStripMenuItem1";
            this.ayarlarToolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem1.Text = "Ayarlar";
            // 
            // puantajToolStripMenuItem
            // 
            this.puantajToolStripMenuItem.Name = "puantajToolStripMenuItem";
            this.puantajToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.puantajToolStripMenuItem.Text = "Puantaj";
            this.puantajToolStripMenuItem.Click += new System.EventHandler(this.puantajToolStripMenuItem_Click);
            // 
            // dosyaTarihİşlemleriToolStripMenuItem
            // 
            this.dosyaTarihİşlemleriToolStripMenuItem.Name = "dosyaTarihİşlemleriToolStripMenuItem";
            this.dosyaTarihİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.dosyaTarihİşlemleriToolStripMenuItem.Text = "Dosya Tarih İşlemleri";
            this.dosyaTarihİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.dosyaTarihİşlemleriToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Kayıtları Getir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personelListBox
            // 
            this.personelListBox.DataSource = this.personelBindingSource;
            this.personelListBox.DisplayMember = "adsoyad";
            this.personelListBox.FormattingEnabled = true;
            this.personelListBox.Location = new System.Drawing.Point(12, 126);
            this.personelListBox.Name = "personelListBox";
            this.personelListBox.Size = new System.Drawing.Size(209, 446);
            this.personelListBox.TabIndex = 4;
            this.personelListBox.ValueMember = "id";
            this.personelListBox.SelectedIndexChanged += new System.EventHandler(this.personelListBox_SelectedIndexChanged);
            // 
            // personelBindingSource
            // 
            this.personelBindingSource.DataMember = "Personel";
            this.personelBindingSource.DataSource = this.puantajDataSet;
            // 
            // puantajDataSet
            // 
            this.puantajDataSet.DataSetName = "puantajDataSet";
            this.puantajDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tarihDataGridViewTextBoxColumn,
            this.girissaatDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.personelGirisCikisBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(227, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(282, 446);
            this.dataGridView1.TabIndex = 5;
            // 
            // tarihDataGridViewTextBoxColumn
            // 
            this.tarihDataGridViewTextBoxColumn.DataPropertyName = "tarih";
            this.tarihDataGridViewTextBoxColumn.HeaderText = "tarih";
            this.tarihDataGridViewTextBoxColumn.Name = "tarihDataGridViewTextBoxColumn";
            this.tarihDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // girissaatDataGridViewTextBoxColumn
            // 
            this.girissaatDataGridViewTextBoxColumn.DataPropertyName = "giris_saat";
            this.girissaatDataGridViewTextBoxColumn.HeaderText = "giris_saat";
            this.girissaatDataGridViewTextBoxColumn.Name = "girissaatDataGridViewTextBoxColumn";
            this.girissaatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // personelGirisCikisBindingSource
            // 
            this.personelGirisCikisBindingSource.DataMember = "PersonelGirisCikis";
            this.personelGirisCikisBindingSource.DataSource = this.puantajDataSet;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.izintipDataGridViewTextBoxColumn,
            this.tarihDataGridViewTextBoxColumn1,
            this.aciklamaDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.personelIzinBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(515, 126);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(240, 446);
            this.dataGridView2.TabIndex = 6;
            // 
            // izintipDataGridViewTextBoxColumn
            // 
            this.izintipDataGridViewTextBoxColumn.DataPropertyName = "izintip";
            this.izintipDataGridViewTextBoxColumn.FillWeight = 30F;
            this.izintipDataGridViewTextBoxColumn.HeaderText = "izintip";
            this.izintipDataGridViewTextBoxColumn.Name = "izintipDataGridViewTextBoxColumn";
            this.izintipDataGridViewTextBoxColumn.Width = 30;
            // 
            // tarihDataGridViewTextBoxColumn1
            // 
            this.tarihDataGridViewTextBoxColumn1.DataPropertyName = "tarih";
            this.tarihDataGridViewTextBoxColumn1.HeaderText = "tarih";
            this.tarihDataGridViewTextBoxColumn1.Name = "tarihDataGridViewTextBoxColumn1";
            // 
            // aciklamaDataGridViewTextBoxColumn
            // 
            this.aciklamaDataGridViewTextBoxColumn.DataPropertyName = "aciklama";
            this.aciklamaDataGridViewTextBoxColumn.HeaderText = "aciklama";
            this.aciklamaDataGridViewTextBoxColumn.Name = "aciklamaDataGridViewTextBoxColumn";
            // 
            // personelIzinBindingSource
            // 
            this.personelIzinBindingSource.DataMember = "PersonelIzin";
            this.personelIzinBindingSource.DataSource = this.puantajDataSet;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(667, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Excel Hazırla";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // maaşKontrolToolStripMenuItem
            // 
            this.maaşKontrolToolStripMenuItem.Name = "maaşKontrolToolStripMenuItem";
            this.maaşKontrolToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.maaşKontrolToolStripMenuItem.Text = "Maaş Kontrol";
            this.maaşKontrolToolStripMenuItem.Click += new System.EventHandler(this.maaşKontrolToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 579);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.personelListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puantajDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelGirisCikisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelIzinBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateBaslangic;
        private System.Windows.Forms.DateTimePicker dateBitis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox personelListBox;
        private System.Windows.Forms.BindingSource personelBindingSource;
        private DAL.puantajDataSet puantajDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarihDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn girissaatDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource personelGirisCikisBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn izintipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarihDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn aciklamaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource personelIzinBindingSource;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem mesaiHesaplaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eBorçSorgulamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinVeRaporDurumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puantajExcelHazırlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avanslarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem puantajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geçKalanlarRaporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aileFertleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puantajYeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelRaporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporTaraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borcuYokturToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hazineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kalanİzinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dosyaTarihİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bordroBankaKarşılaştırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maaşKontrolToolStripMenuItem;
    }
}

