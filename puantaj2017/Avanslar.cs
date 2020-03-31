using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Office.Interop.Excel;
using puantaj2017.DAL;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace puantaj2017
{
    public partial class Avanslar : Form
    {
        public DateTime tarih1 { get; set; }
        public DateTime tarih2 { get; set; }
        public Application excel { get; set; }

        public Workbook workbook { get; set; }

        public Avanslar()
        {
            InitializeComponent();
        }

        private void Avanslar_Load(object sender, EventArgs e)
        {
            using (ikEntities db=new ikEntities() )
            {
              var avans= db.Avanslars.Where(c => c.tarih >= tarih1 & c.tarih <= tarih2).
                    Select(c => new AvanslarVM()
                    {
                        PersoneKod = c.Personel.sicilno,AdSoyad = c.Personel.adsoyad,Tarih = c.tarih.Value,Tutar = c.tutar
                    });
                avanslarVMBindingSource.DataSource = avans.ToList();
            }
            

        }
        private static string ColumnIndexToColumnLetter(int colIndex)
        {
            var div = colIndex;
            var colLetter = string.Empty;
            var mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (div - mod) / 26;
            }
            return colLetter;
        }

        private void excelEEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<AvanslarVM>();



            var worksheet = (Worksheet)workbook.Worksheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);
          

            worksheet.Name = "Avanslar";
            excel.Visible = true;
            excel.DisplayAlerts = false;

            Range rg;
            var row = 1;
            var col = 2;

            rg = worksheet.get_Range(ColumnIndexToColumnLetter(2)+1,ColumnIndexToColumnLetter(6)+1);
            rg.Value2 = string.Format("AVANSLAR MERKEZ {0} AYI",tarih1.ToString("MMMM").ToUpper());
            rg.Merge();
            rg.Font.Size = 14;
            rg.RowHeight = 57;
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


            row++;
            #region Sıra no
            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "Sıra No";
            rg.Font.Size = 11;
            rg.ColumnWidth = 7.57;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rg.Font.Bold = true;
            #endregion

            #region Personel Ad Soyad
            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "AD SOYAD";
            rg.Font.Size = 11;
            rg.ColumnWidth = 23.71;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rg.Font.Bold = true;
            #endregion

            #region Sicil No

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "SİCİL NO";
            rg.Font.Size = 11;
            rg.ColumnWidth =13.57;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rg.Font.Bold = true;
            #endregion



            #region Personel TARİH
            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "AVANS TARİHİ";
            rg.Font.Size = 11;
            rg.ColumnWidth = 14.43;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rg.Font.Bold = true;
            #endregion

            #region Personel TUTAR
            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "TUTAR";
            rg.Font.Size = 11;
            rg.ColumnWidth = 16.71;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rg.Font.Bold = true;
            #endregion

            row++;

            var sira = 1;
            var toplam = 0;
            foreach (var avanslarVm in rows)
            {
                col = 2;
                #region SIRA
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = sira.ToString();
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                #endregion
                #region adsoyad
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = avanslarVm.AdSoyad;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                #endregion
                #region sicilno
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = avanslarVm.PersoneKod;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                #endregion
                #region avanstarihi
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = avanslarVm.Tarih;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.NumberFormat = "dd/mm/yyyy";
                #endregion
                #region avanstarihi
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = avanslarVm.Tutar;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.NumberFormat = "#,##0.00 TL";
                #endregion

                toplam += avanslarVm.Tutar;
                sira++;
                row++;

            }
            row += 2;
            col = 5;

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "TOPLAM";
            rg.Font.Size = 14;
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;



            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = toplam;
            rg.Font.Size = 14;
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rg.NumberFormat = "#,##0.00 TL";






        }
    }
}
