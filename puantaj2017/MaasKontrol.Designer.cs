namespace puantaj2017
{
    partial class MaasKontrol
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
            this.nUDYil = new System.Windows.Forms.NumericUpDown();
            this.nUDAy = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.maasKontrolVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colyil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colavans = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldevkümülatifgv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colicra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhesaplanan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmikronet = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nUDYil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAy)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maasKontrolVMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nUDYil
            // 
            this.nUDYil.Location = new System.Drawing.Point(12, 35);
            this.nUDYil.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nUDYil.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDYil.Name = "nUDYil";
            this.nUDYil.Size = new System.Drawing.Size(94, 20);
            this.nUDYil.TabIndex = 0;
            this.nUDYil.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // nUDAy
            // 
            this.nUDAy.Location = new System.Drawing.Point(142, 35);
            this.nUDAy.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nUDAy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDAy.Name = "nUDAy";
            this.nUDAy.Size = new System.Drawing.Size(88, 20);
            this.nUDAy.TabIndex = 0;
            this.nUDAy.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nUDYil);
            this.panel1.Controls.Add(this.nUDAy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 74);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(446, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Kontrol Et";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hesapla";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Mikro Yükle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(139, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tahakkuk Ay";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mali Yıl";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.maasKontrolVMBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 74);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(850, 443);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // maasKontrolVMBindingSource
            // 
            this.maasKontrolVMBindingSource.DataSource = typeof(puantaj2017.MaasKontrolVM);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colad,
            this.colsoyad,
            this.colyil,
            this.colay,
            this.colbes,
            this.colavans,
            this.coldevkümülatifgv,
            this.colnet,
            this.gridColumn1,
            this.colkod,
            this.colicra,
            this.colhesaplanan,
            this.colmikronet});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colad
            // 
            this.colad.FieldName = "ad";
            this.colad.Name = "colad";
            this.colad.Visible = true;
            this.colad.VisibleIndex = 1;
            // 
            // colsoyad
            // 
            this.colsoyad.FieldName = "soyad";
            this.colsoyad.Name = "colsoyad";
            this.colsoyad.Visible = true;
            this.colsoyad.VisibleIndex = 2;
            // 
            // colyil
            // 
            this.colyil.FieldName = "yil";
            this.colyil.Name = "colyil";
            // 
            // colay
            // 
            this.colay.FieldName = "ay";
            this.colay.Name = "colay";
            // 
            // colbes
            // 
            this.colbes.DisplayFormat.FormatString = "n2";
            this.colbes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colbes.FieldName = "bes";
            this.colbes.Name = "colbes";
            this.colbes.Visible = true;
            this.colbes.VisibleIndex = 3;
            // 
            // colavans
            // 
            this.colavans.DisplayFormat.FormatString = "n2";
            this.colavans.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colavans.FieldName = "avans";
            this.colavans.Name = "colavans";
            this.colavans.Visible = true;
            this.colavans.VisibleIndex = 4;
            // 
            // coldevkümülatifgv
            // 
            this.coldevkümülatifgv.DisplayFormat.FormatString = "n2";
            this.coldevkümülatifgv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coldevkümülatifgv.FieldName = "devkümülatifgv";
            this.coldevkümülatifgv.Name = "coldevkümülatifgv";
            this.coldevkümülatifgv.Visible = true;
            this.coldevkümülatifgv.VisibleIndex = 5;
            // 
            // colnet
            // 
            this.colnet.DisplayFormat.FormatString = "n2";
            this.colnet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colnet.FieldName = "net";
            this.colnet.Name = "colnet";
            this.colnet.Visible = true;
            this.colnet.VisibleIndex = 7;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridodenen";
            this.gridColumn1.DisplayFormat.FormatString = "n2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.UnboundExpression = "[net] + [icra] + [avans] + [bes]";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            // 
            // colkod
            // 
            this.colkod.FieldName = "kod";
            this.colkod.Name = "colkod";
            this.colkod.Visible = true;
            this.colkod.VisibleIndex = 0;
            // 
            // colicra
            // 
            this.colicra.DisplayFormat.FormatString = "n2";
            this.colicra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colicra.FieldName = "icra";
            this.colicra.Name = "colicra";
            this.colicra.Visible = true;
            this.colicra.VisibleIndex = 6;
            // 
            // colhesaplanan
            // 
            this.colhesaplanan.FieldName = "hesaplanan";
            this.colhesaplanan.Name = "colhesaplanan";
            this.colhesaplanan.Visible = true;
            this.colhesaplanan.VisibleIndex = 9;
            // 
            // colmikronet
            // 
            this.colmikronet.FieldName = "mikronet";
            this.colmikronet.Name = "colmikronet";
            this.colmikronet.Visible = true;
            this.colmikronet.VisibleIndex = 10;
            // 
            // MaasKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 517);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "MaasKontrol";
            this.Text = "MaasKontrol";
            this.Load += new System.EventHandler(this.MaasKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDYil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAy)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maasKontrolVMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDYil;
        private System.Windows.Forms.NumericUpDown nUDAy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource maasKontrolVMBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colad;
        private DevExpress.XtraGrid.Columns.GridColumn colsoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colyil;
        private DevExpress.XtraGrid.Columns.GridColumn colay;
        private DevExpress.XtraGrid.Columns.GridColumn colbes;
        private DevExpress.XtraGrid.Columns.GridColumn colavans;
        private DevExpress.XtraGrid.Columns.GridColumn coldevkümülatifgv;
        private DevExpress.XtraGrid.Columns.GridColumn colnet;
        private DevExpress.XtraGrid.Columns.GridColumn colkod;
        private DevExpress.XtraGrid.Columns.GridColumn colicra;
        private DevExpress.XtraGrid.Columns.GridColumn colhesaplanan;
        private DevExpress.XtraGrid.Columns.GridColumn colmikronet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}