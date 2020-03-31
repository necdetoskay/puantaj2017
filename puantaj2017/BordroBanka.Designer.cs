namespace puantaj2017
{
    partial class BordroBanka
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
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bankaBordroVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVakifTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIBAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTahakkukTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::puantaj2017.WaitForm1), true, true);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankaBordroVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(397, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "Mikro ile Karşılaştır";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(14, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2006,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            2006,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(129, 32);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(94, 20);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Yıl";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(126, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ay";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 41);
            this.button1.TabIndex = 8;
            this.button1.Text = "VakıfBank Excel Seçiniz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bankaBordroVMBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 85);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(845, 449);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bankaBordroVMBindingSource
            // 
            this.bankaBordroVMBindingSource.DataSource = typeof(puantaj2017.BankaBordroVM);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdSoyad,
            this.colVakifTutar,
            this.colIBAN,
            this.colTahakkukTutar,
            this.fark});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colAdSoyad
            // 
            this.colAdSoyad.FieldName = "AdSoyad";
            this.colAdSoyad.Name = "colAdSoyad";
            this.colAdSoyad.Visible = true;
            this.colAdSoyad.VisibleIndex = 0;
            // 
            // colVakifTutar
            // 
            this.colVakifTutar.FieldName = "VakifTutar";
            this.colVakifTutar.Name = "colVakifTutar";
            this.colVakifTutar.Visible = true;
            this.colVakifTutar.VisibleIndex = 1;
            // 
            // colIBAN
            // 
            this.colIBAN.FieldName = "IBAN";
            this.colIBAN.Name = "colIBAN";
            // 
            // colTahakkukTutar
            // 
            this.colTahakkukTutar.FieldName = "TahakkukTutar";
            this.colTahakkukTutar.Name = "colTahakkukTutar";
            this.colTahakkukTutar.Visible = true;
            this.colTahakkukTutar.VisibleIndex = 2;
            // 
            // fark
            // 
            this.fark.Caption = "Fark";
            this.fark.FieldName = "Fark";
            this.fark.Name = "fark";
            this.fark.Visible = true;
            this.fark.VisibleIndex = 3;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 85);
            this.panel1.TabIndex = 10;
            // 
            // BordroBanka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 534);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "BordroBanka";
            this.Text = "BordroBanka";
            this.Load += new System.EventHandler(this.BordroBanka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankaBordroVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bankaBordroVMBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colVakifTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colIBAN;
        private DevExpress.XtraGrid.Columns.GridColumn colTahakkukTutar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn fark;
    }
}