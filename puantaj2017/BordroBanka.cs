using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Excel = Microsoft.Office.Interop.Excel;

namespace puantaj2017
{
    public partial class BordroBanka : Form
    {
        private string bordro = "";
        private string banka = "";
        List<BankaBordroVM> liste = new List<BankaBordroVM>();
        public BordroBanka()
        {
            InitializeComponent();// Fill a ExcelDataSource
            numericUpDown1.Maximum = 3000;
            numericUpDown1.Value = DateTime.Now.Year;
            numericUpDown2.Value = DateTime.Now.Month - 1;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<BankaBordroVM>();
            using (var db = new MikroDB_V15_KENTEntities())
            {
                foreach (var row in rows)
                {
                    try
                    {
                        var per = db.PERSONELLERs.FirstOrDefault(c => c.per_ucr_hesapno == row.IBAN && c.per_cikis_tar == new DateTime(1899, 12, 31));
                        if (per != null)
                        {
                            var pkod = per.per_kod;
                            var net = db.PERSONEL_TAHAKKUKLARI.Where(
                                    c =>
                                        c.pt_pkod == pkod && c.pt_maliyil == numericUpDown1.Value &&
                                        c.pt_tah_ay == numericUpDown2.Value).Sum(c => c.pt_net);
                            if (net == null)
                            {
                                row.TahakkukTutar = 0;
                            }
                            else
                            {
                                row.TahakkukTutar = Math.Round(decimal.Parse(net.ToString()), 2);
                            }
                          
                            row.Fark = row.VakifTutar - row.TahakkukTutar;
                          
                        }
                    }
                    catch (Exception x)
                    {

                    }
                }
            }
            gridControl1.RefreshDataSource();
        }
        private void BordroBanka_Load(object sender, EventArgs e)
        {
            gridView1.CellValueChanged += gridView1_CellValueChanged;
        }

     

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            BankaBordroVM rw;
            rw = (BankaBordroVM)view.GetRow(e.RowHandle);
            if (e.Column.Caption != "Tahakkuk Tutar")
            {
                try
                {
                    rw.Fark = rw.VakifTutar - rw.TahakkukTutar;
                    if (rw.Fark > 0)
                    {
                        
                    }
                }
                catch (Exception xxxx)
                {

                    throw;
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = @"\\fileserver\İnsan kaynakları\";
            openFileDialog1.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog1.Title = "Excel Dosyası Seçiniz..";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                splashScreenManager1.ShowWaitForm();
                string DosyaYolu = openFileDialog1.FileName;
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(DosyaYolu, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel._Worksheet worksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = worksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                for (int i = 11; i <= rowCount; i++)
                {
                    try
                    {
                        var adsoyad = (xlRange.Cells[i, 1] as Excel.Range).Value2;
                        var iban = (xlRange.Cells[i, 5] as Excel.Range).Value2;
                        var tutar = (decimal)(xlRange.Cells[i, 4] as Excel.Range).Value2;
                        try
                        {
                            liste.Add(new BankaBordroVM
                            {
                                AdSoyad = adsoyad,
                                IBAN = iban,
                                VakifTutar = tutar
                            });
                        }
                        catch (Exception x) { }
                    }
                    catch (Exception xl) { }
                }
                xlWorkbook.Close(true, null, null);
                xlApp.Quit();

                releaseObject(worksheet);
                releaseObject(xlWorkbook);
                releaseObject(xlApp);

                gridControl1.DataSource = liste;
                gridView1.RefreshData();
                gridControl1.RefreshDataSource();

                splashScreenManager1.CloseWaitForm();
            }

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle > -1)
            {
                decimal fark = (decimal)View.GetRowCellValue(e.RowHandle, View.Columns["Fark"]);
                if (fark != 0)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.Red;
                }
            }
        }


    }


    public class BankaBordroVM
    {
        public string AdSoyad { get; set; }
        public decimal VakifTutar { get; set; }
        public string IBAN { get; set; }
        public decimal TahakkukTutar { get; set; }
        public decimal Fark { get; set; }
    }
}