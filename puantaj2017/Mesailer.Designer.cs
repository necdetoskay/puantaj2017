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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.birimBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.personelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.hafta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarihDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.girissaatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cikis_saat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tatil = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.yemek = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mesaihesapla = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.personelGirisCikisDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.personelidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haftaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dakikaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tariharalikDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelMesaiDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.birimBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelGirisCikisDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelMesaiDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.birimBindingSource;
            this.comboBox1.DisplayMember = "fullad";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(243, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // birimBindingSource
            // 
            this.birimBindingSource.DataSource = typeof(puantaj2017.DAL.birim);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Birimler";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(280, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Personeller";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.personelBindingSource;
            this.comboBox2.DisplayMember = "adsoyad";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(281, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(242, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.ValueMember = "pdksid";
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // personelBindingSource
            // 
            this.personelBindingSource.DataSource = typeof(puantaj2017.DAL.Personel);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hafta,
            this.personelidDataGridViewTextBoxColumn,
            this.tarihDataGridViewTextBoxColumn,
            this.girissaatDataGridViewTextBoxColumn,
            this.cikis_saat,
            this.tatil,
            this.yemek,
            this.mesaihesapla});
            this.dataGridView1.DataSource = this.personelGirisCikisDataTableBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(495, 350);
            this.dataGridView1.TabIndex = 5;
            // 
            // hafta
            // 
            this.hafta.DataPropertyName = "hafta";
            this.hafta.HeaderText = "Hafta";
            this.hafta.Name = "hafta";
            this.hafta.Width = 50;
            // 
            // personelidDataGridViewTextBoxColumn
            // 
            this.personelidDataGridViewTextBoxColumn.DataPropertyName = "personelid";
            this.personelidDataGridViewTextBoxColumn.HeaderText = "personelid";
            this.personelidDataGridViewTextBoxColumn.Name = "personelidDataGridViewTextBoxColumn";
            this.personelidDataGridViewTextBoxColumn.Width = 50;
            // 
            // tarihDataGridViewTextBoxColumn
            // 
            this.tarihDataGridViewTextBoxColumn.DataPropertyName = "tarih";
            this.tarihDataGridViewTextBoxColumn.HeaderText = "tarih";
            this.tarihDataGridViewTextBoxColumn.Name = "tarihDataGridViewTextBoxColumn";
            // 
            // girissaatDataGridViewTextBoxColumn
            // 
            this.girissaatDataGridViewTextBoxColumn.DataPropertyName = "giris_saat";
            this.girissaatDataGridViewTextBoxColumn.HeaderText = "giris_saat";
            this.girissaatDataGridViewTextBoxColumn.Name = "girissaatDataGridViewTextBoxColumn";
            this.girissaatDataGridViewTextBoxColumn.Width = 70;
            // 
            // cikis_saat
            // 
            this.cikis_saat.DataPropertyName = "cikis_saat";
            this.cikis_saat.HeaderText = "cikis_saat";
            this.cikis_saat.Name = "cikis_saat";
            this.cikis_saat.Width = 70;
            // 
            // tatil
            // 
            this.tatil.DataPropertyName = "tatil";
            this.tatil.HeaderText = "Tatil";
            this.tatil.Name = "tatil";
            this.tatil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tatil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tatil.Width = 50;
            // 
            // yemek
            // 
            this.yemek.DataPropertyName = "yemek";
            this.yemek.HeaderText = "Yemek";
            this.yemek.Name = "yemek";
            this.yemek.Width = 50;
            // 
            // mesaihesapla
            // 
            this.mesaihesapla.DataPropertyName = "mesaihesapla";
            this.mesaihesapla.HeaderText = "Hesapla";
            this.mesaihesapla.Name = "mesaihesapla";
            this.mesaihesapla.Width = 50;
            // 
            // personelGirisCikisDataTableBindingSource
            // 
            this.personelGirisCikisDataTableBindingSource.DataSource = typeof(puantaj2017.DAL.puantajDataSet.PersonelGirisCikisDataTable);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Hesapla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personelidDataGridViewTextBoxColumn1,
            this.haftaDataGridViewTextBoxColumn,
            this.saatDataGridViewTextBoxColumn,
            this.dakikaDataGridViewTextBoxColumn,
            this.tariharalikDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.personelMesaiDataTableBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(505, 58);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(298, 349);
            this.dataGridView2.TabIndex = 7;
            // 
            // personelidDataGridViewTextBoxColumn1
            // 
            this.personelidDataGridViewTextBoxColumn1.DataPropertyName = "personelid";
            this.personelidDataGridViewTextBoxColumn1.HeaderText = "personelid";
            this.personelidDataGridViewTextBoxColumn1.Name = "personelidDataGridViewTextBoxColumn1";
            this.personelidDataGridViewTextBoxColumn1.ReadOnly = true;
            this.personelidDataGridViewTextBoxColumn1.Width = 35;
            // 
            // haftaDataGridViewTextBoxColumn
            // 
            this.haftaDataGridViewTextBoxColumn.DataPropertyName = "hafta";
            this.haftaDataGridViewTextBoxColumn.HeaderText = "hafta";
            this.haftaDataGridViewTextBoxColumn.Name = "haftaDataGridViewTextBoxColumn";
            this.haftaDataGridViewTextBoxColumn.ReadOnly = true;
            this.haftaDataGridViewTextBoxColumn.Width = 35;
            // 
            // saatDataGridViewTextBoxColumn
            // 
            this.saatDataGridViewTextBoxColumn.DataPropertyName = "saat";
            this.saatDataGridViewTextBoxColumn.HeaderText = "saat";
            this.saatDataGridViewTextBoxColumn.Name = "saatDataGridViewTextBoxColumn";
            this.saatDataGridViewTextBoxColumn.ReadOnly = true;
            this.saatDataGridViewTextBoxColumn.Width = 35;
            // 
            // dakikaDataGridViewTextBoxColumn
            // 
            this.dakikaDataGridViewTextBoxColumn.DataPropertyName = "dakika";
            this.dakikaDataGridViewTextBoxColumn.HeaderText = "dakika";
            this.dakikaDataGridViewTextBoxColumn.Name = "dakikaDataGridViewTextBoxColumn";
            this.dakikaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dakikaDataGridViewTextBoxColumn.Width = 35;
            // 
            // tariharalikDataGridViewTextBoxColumn
            // 
            this.tariharalikDataGridViewTextBoxColumn.DataPropertyName = "tariharalik";
            this.tariharalikDataGridViewTextBoxColumn.HeaderText = "tariharalik";
            this.tariharalikDataGridViewTextBoxColumn.Name = "tariharalikDataGridViewTextBoxColumn";
            this.tariharalikDataGridViewTextBoxColumn.ReadOnly = true;
            this.tariharalikDataGridViewTextBoxColumn.Width = 150;
            // 
            // personelMesaiDataTableBindingSource
            // 
            this.personelMesaiDataTableBindingSource.DataSource = typeof(puantaj2017.DAL.puantajDataSet.PersonelMesaiDataTable);
            // 
            // Mesailer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 419);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Name = "Mesailer";
            this.Text = "Mesailer";
            this.Load += new System.EventHandler(this.Mesailer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.birimBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelGirisCikisDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelMesaiDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource birimBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource personelBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource personelGirisCikisDataTableBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hafta;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarihDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn girissaatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cikis_saat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tatil;
        private System.Windows.Forms.DataGridViewCheckBoxColumn yemek;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mesaihesapla;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn haftaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dakikaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tariharalikDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource personelMesaiDataTableBindingSource;
    }
}