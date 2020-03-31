using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Office.Interop.Excel;
using puantaj2017.DAL;
using PtakipDAL;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace puantaj2017
{
    public partial class Mesailer : Form
    {
        private ikEntities db = new ikEntities();
        PerkotekContext per = new PerkotekContext();

        private puantajDataSet ds;
        private readonly object misValue = Missing.Value;

        public Mesailer()
        {
            InitializeComponent();
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.RowStyle += GridView1_RowStyle;
        }

        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                try
                {
                    var id = int.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["PersonelID"]));
                    var tarih = DateTime.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["Tarih"]));
                    var giris = TimeSpan.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["GirisSaat"]));
                    var cikis = TimeSpan.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["CikisSaat"]));

                    var izinler = ds.PersonelIzin.Where(
                        c => c.Saatlik && c.personelid == id && c.tarih == tarih &&
                            (c.gidis_saat == new TimeSpan(8, 30, 0) || c.gelis_saat == new TimeSpan(17, 30, 0)));
                    //if (izinler.Any())
                    //{
                    //    var first = izinler.FirstOrDefault();
                    //    var frst = ds.PersonelGirisCikis.FirstOrDefault(c => c.personelid == id && c.tarih == tarih);
                    //    if (first.gidis_saat == new TimeSpan(8, 30, 0))// || first.gelis_saat == new TimeSpan(17, 30, 0))
                    //    {//        frst.giris_saat = new TimeSpan(8, 30, 0);
                    //        e.Appearance.BackColor = Color.Bisque;
                    //    }

                    //    if (first.gelis_saat == new TimeSpan(17, 30, 0))// || first.gelis_saat == new TimeSpan(17, 30, 0))
                    //    {
                    //        frst.cikis_saat = "17:30:00";
                    //        e.Appearance.BackColor = Color.Bisque;
                    //    }

                    //}
                    if (
                        ds.PersonelIzin.Any(
                            c =>
                                c.Saatlik && c.personelid == id && c.tarih == tarih &&
                                (c.gidis_saat == new TimeSpan(8, 30, 0) || c.gelis_saat == new TimeSpan(17, 30, 0))))
                    {
                        e.Appearance.BackColor = Color.Bisque;
                    }
                }
                catch (Exception xxx)
                {
                    Console.WriteLine(xxx.Message);
                }


            }
            //if (e.Column.FieldName == "UnitsOnOrder" || e.Column.FieldName == "UnitPrice")
            //{
            //    string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Category"]);
            //    if (category == "Seafood")
            //    {
            //        e.Appearance.BackColor = Color.DeepSkyBlue;
            //        e.Appearance.BackColor2 = Color.LightCyan;
            //    }
            //}
        }

        private void GridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            PersonelMesaiData rw;
            rw = (PersonelMesaiData)view.GetRow(e.RowHandle);

            if (e.Column.Caption != "")
            {
                if (rw.Hesapla)
                {
                    rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes -
                                      (rw.Yemek ? 60 : 0) - (rw.Tatil ? 0 : 480);
                }
                else
                    rw.ToplamDakika = 0;
            }
        }

        private void GridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view == null) return;
                int rowIndex = e.ListSourceRowIndex;
                var haftaningunu = Convert.ToDateTime(view.GetListSourceRowCellValue(rowIndex, "Tarih"));
                //var giris = TimeSpan.Parse(view.GetListSourceRowCellValue(rowIndex, "GirisSaat").ToString());
                //var cikis = TimeSpan.Parse(view.GetListSourceRowCellValue(rowIndex, "CikisSaat").ToString());
                //var tatil = Convert.ToBoolean(view.GetListSourceRowCellValue(rowIndex, "Tatil"));
                //var yemek = Convert.ToBoolean(view.GetListSourceRowCellValue(rowIndex, "Yemek"));
                //var hesapla = Convert.ToBoolean(view.GetListSourceRowCellValue(rowIndex, "Hesapla"));
                if (e.Column.FieldName == "Haftanın Günü")
                {
                    e.Value = haftaningunu.ToString("dddd");
                }
                //else if (e.Column.FieldName == "ToplamDakika")
                //{
                //    var dakika = (int)(hesapla ? cikis.Subtract(giris).TotalMinutes-(yemek?0:60)-(tatil?60: 480) : 0);
                //    e.Value = dakika;
                //}
                //else 
                //if (e.Column.FieldName == "Tatil")
                //{
                //    if (haftaningunu.DayOfWeek == DayOfWeek.Saturday | haftaningunu.DayOfWeek == DayOfWeek.Sunday)
                //    {
                //        e.Value = true;
                //    }
                //}
            }
            catch (Exception ex)
            {


            }

        }

        private List<PersonelMesaiData> sourceList;
        private void Mesailer_Load(object sender, EventArgs e)
        {

            return;

            //PersonelMesaiData
            ds = (puantajDataSet)Tag;
            try
            {
                var source = (from p in ds.Personel
                              join pgc in ds.PersonelGirisCikis on p.id equals pgc.personelid
                              select new PersonelMesaiData
                              {
                                  Hafta = pgc.hafta,
                                  PersonelID = p.id,
                                  PersonelAdSoyad = p.adsoyad,
                                  Tarih = pgc.tarih,
                                  GirisSaat = pgc.giris_saat,
                                  CikisSaat = pgc.cikis_saat,
                                  Yemek = true,
                                  Hesapla = true,
                                  ToplamDakika = 0,
                                  Tatil = pgc.tarih.DayOfWeek == DayOfWeek.Sunday | pgc.tarih.DayOfWeek == DayOfWeek.Saturday
                              });






                var liste = source.ToList();


                for (int i = 0; i < liste.Count; i++)
                {
                    try
                    {
                        var izin =
                                       ds.PersonelIzin.Where(
                                           c => c.personelid == liste[i].PersonelID && c.tarih == liste[i].Tarih);
                        if (izin.Any(c => c.Saatlik))
                        {
                            var mazeret = izin.FirstOrDefault(c => c.Saatlik);
                            if (mazeret.gidis_saat == new TimeSpan(8, 30, 0))
                            {
                                liste[i].GirisSaat = new TimeSpan(8, 30, 0);
                            }
                            if (mazeret.gelis_saat == new TimeSpan(17, 30, 0))
                            {
                                liste[i].CikisSaat = "17:30:00";
                            }
                        }
                    }
                    catch (Exception ichata)
                    {

                    }

                }

                sourceList = liste;
                gridControl1.DataSource = sourceList;
            }
            catch (Exception xx)
            {
                // throw;
            }



            //foreach (var personelMesaiData in source)
            //{
            //    var tarih = DateTime.Parse(personelMesaiData.Tarih.ToShortDateString());
            //    var izin =
            //        ds.PersonelIzin.Where(
            //            c => c.personelid == personelMesaiData.PersonelID && c.tarih == personelMesaiData.Tarih);
            //    if (izin.Any(c => c.Saatlik))
            //    {
            //        var mazeret = izin.FirstOrDefault(c => c.Saatlik);
            //        if (mazeret.gidis_saat == new TimeSpan(8, 30, 0))
            //        {
            //            personelMesaiData.GirisSaat = new TimeSpan(8, 30, 0);
            //        }
            //        if (mazeret.gelis_saat == new TimeSpan(17, 30, 0))
            //        {
            //            personelMesaiData.CikisSaat = "17:30:00";
            //        }
            //    }
            //}



        }

        private int GetWeekNumber(DateTime tarih)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(tarih, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }


        private void aaaaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<PersonelMesaiData>();

            if (!cBEksikHesap.Checked)
            {
                rows = rows.Where(c => c.Hesapla);
            }

            //foreach (var row in rows.Where(c => c.Hesapla).GroupBy(c => c.Hafta))
            foreach (var row in rows.GroupBy(c => c.Hafta))
            {
                foreach (var rw in row)
                {
                    try
                    {
                        rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes - (rw.Yemek ? 60 : 0) - (rw.Tatil ? 0 : 480);
                        if (!cBEksikHesap.Checked)
                        {
                            if (rw.ToplamDakika < 0)
                            {
                                rw.Hesapla = false;
                                rw.ToplamDakika = 0;
                            }
                        }
                        else
                        {
                            rw.Hesapla = true;
                        }


                    }
                    catch (Exception x1)
                    {


                    }
                }
            }


            //if (gridView1.GroupCount == 0)
            //    for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
            //    {
            //        foreach (GridColumn gc in gridView1.Columns)
            //            Console.WriteLine(String.Format("{0} ", gridView1.GetRowCellDisplayText(rowHandle, gc)));

            //    }
            //else
            //{
            //    // Get the list of grouped columns
            //    List<GridColumn> groupedColumnsList = new List<GridColumn>();
            //    foreach (GridColumn groupedColumn in gridView1.GroupedColumns)
            //        groupedColumnsList.Add(groupedColumn);

            //    for (int rowHandle = -1; gridView1.IsValidRowHandle(rowHandle); rowHandle--)
            //    {
            //        Console.WriteLine(gridView1.GetGroupRowDisplayText(rowHandle) + "\r\n");
            //        if (gridView1.GetChildRowHandle(rowHandle, 0) > -1)

            //            for (int childRowHandle = 0; childRowHandle < gridView1.GetChildRowCount(rowHandle); childRowHandle++)
            //            {
            //                var id =
            //                    gridView1.GetRowCellDisplayText(gridView1.GetChildRowHandle(rowHandle, childRowHandle),
            //                        gridView1.Columns["PersonelID"]);
            //                var tarih = gridView1.GetRowCellDisplayText(gridView1.GetChildRowHandle(rowHandle, childRowHandle),
            //                        gridView1.Columns["Tarih"]);




            //            }
            //    }
            //}


            //PersonelMesaiData row = (PersonelMesaiData)gridView.GetRow(gridView.FocusedRowHandle);



            //var mesai = (List<PersonelMesaiData>) gridView1.DataSource;        ;//.DefaultView.DataSource;
            //var me = mesai.Where(c => c.PersonelID == row.PersonelID);
            //for (int i = 0; i < gridView1.DataRowCount; i++) {
            //    var rw=gridView1.GetRow(i);
            //}

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<PersonelMesaiData>().Where(c => c.Hesapla);

            var excel = new Application();
            excel.Visible = true;
            Workbook xlWorkBook;
            xlWorkBook = excel.Workbooks.Add(misValue);
            Worksheet worksheet = xlWorkBook.Worksheets.Add(); ;

            Range rg;
            int row = 2;
            int col = 2;

            rg = (Range)worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col + 4) + (row));
            rg.ColumnWidth = 20.25;
            rg.Merge();
            rg.Value2 = string.Format("Personel Ad Soyad: {0}", rows.FirstOrDefault().PersonelAdSoyad);
            //rg.Orientation = 90;
            rg.Font.Size = 12;
            //rg.ColumnWidth = 2.57;
            //rg.RowHeight = 51.75;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            var toplammesai = 0;

            foreach (var rw in rows.GroupBy(c => c.Hafta))
            {
                col = 2;
                row += 2;
                rg.ColumnWidth = 18.57;
                rg = (Range)worksheet.Cells[row, col];
                rg.Value2 = string.Format("Hafta: {0}", rw.Key);
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Font.Bold = true;
                row++;

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = "TARİH";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Font.Bold = true;

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = "Gün";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Font.Bold = true;

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = "Giriş Saati";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Font.Bold = true;

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = "Çıkış Saati";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Font.Bold = true;

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = "Toplam Dakika";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter; rg.Font.Bold = true;
                col = 2;
                row++;
                var haftalikmesai = 0; foreach (var r in rw)
                {
                    rg = (Range)worksheet.Cells[row, col++];
                    rg.Value2 = r.Tarih.ToShortDateString();
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rg = (Range)worksheet.Cells[row, col++];
                    rg.Value2 = r.Tarih.ToString("dddd");
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rg = (Range)worksheet.Cells[row, col++];
                    rg.Value2 = r.GirisSaat.ToString(@"hh\:mm");
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rg = (Range)worksheet.Cells[row, col++];
                    if (r.CikisSaat != null) rg.Value2 = TimeSpan.Parse(r.CikisSaat).ToString(@"hh\:mm");
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    rg = (Range)worksheet.Cells[row, col++];
                    rg.Value2 = r.ToplamDakika;
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    row++;
                    col = 2;
                    haftalikmesai += r.ToplamDakika;
                }

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = "Yapılan Fazla Mesai :";
                rg.Font.Bold = true;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = haftalikmesai;

                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = "'- 5 Saat";

                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


                var mesai = haftalikmesai - 300;
                var haftaliksaat = (int)(mesai / 60);
                var haftalikdakika = (int)(mesai % 60);

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = mesai;

                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                var mes = mesai > 0 ? string.Format("{0} Saat {1} dakika", haftaliksaat, haftalikdakika) : "";
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = mes;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                toplammesai += mesai > 0 ? mesai : 0;
            }
            row += 3;
            col = 2;

            rg = (Range)worksheet.Cells[row, col];
            rg.Value2 = "TOPLAM MESAİ";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rg = (Range)worksheet.Cells[row + 1, col];
            rg.Value2 = toplammesai;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


            col++;

            rg = (Range)worksheet.Cells[row, col];
            rg.Value2 = "TOPLAM SAAT";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rg = (Range)worksheet.Cells[row + 1, col];
            rg.Value2 = (int)(toplammesai / 60);
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


            col++;
            rg = (Range)worksheet.Cells[row, col];
            rg.Value2 = "TOPLAM DAKİKA";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            rg = (Range)worksheet.Cells[row + 1, col];
            rg.Value2 = (int)(toplammesai % 60);
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            MesaiKaydet(rows,toplammesai);
            //soru sor database e kaydet
           
        }

        private void MesaiKaydet(IEnumerable<PersonelMesaiData> rows,int toplammesai )
        {

            if (MessageBox.Show("Mesai Kayıt Edilsin mi?", "Mesai Kaydet", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var personelMesaiData = rows.FirstOrDefault();
                if (personelMesaiData != null)
                {
                    var pdksid = personelMesaiData.PersonelID;
                    var personel = db.Personels.FirstOrDefault(c => c.pdksid == pdksid);
                    var ay = (int)numericUpDownAy.Value;
                    var yıl = (int)numericUpDownYil.Value;

                    var mesai = (int)(toplammesai / 60);
                    if (toplammesai % 60 >= 30)
                    {
                        mesai++;
                    }
                    var varmı = personel.PersonelMesais.Any(c => c.yil == yıl & c.ay == ay);

                    if (varmı)
                    {
                        if (MessageBox.Show("Var Olan KAyıt Güncellensin mi?", "", MessageBoxButtons.YesNo) ==
                            DialogResult.Yes)
                        {
                            personel.PersonelMesais.FirstOrDefault(c => c.ay == ay & c.yil == yıl).mesai1 = mesai;
                        }
                    }
                    else
                    {

                        personel.PersonelMesais.Add(new PersonelMesai
                        {
                            ay = ay,
                            yil = yıl,
                            mesai1 = mesai
                        });
                    }
                    db.SaveChanges();
                }
                //personel id
                //yıl
                //ay

                //daha önce kayıt varsa sor üzerine yazılsın mı?
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
        private void kaydetToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void girişSaat830AyarlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<PersonelMesaiData>();

            foreach (var rw in rows)
            {
                try
                {
                    if (rw.Tarih.DayOfWeek != DayOfWeek.Saturday && rw.Tarih.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (rw.GirisSaat < new TimeSpan(8, 30, 00))
                            rw.GirisSaat = new TimeSpan(8, 30, 00);
                    }
                    else
                    {

                    }
                    //rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes - (rw.Yemek ? 60 : 0) - (rw.Tatil ? 0 : 480);
                }
                catch (Exception x1)
                {


                }
            }
            aaaaaToolStripMenuItem_Click(null, null);
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void mesaileriYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MesaileriYukle()
        {

            var start = dateTimePicker1.Value;
            var end = dateTimePicker2.Value;
            per.PuantajHazirla(start, end, true);
            //PersonelMesaiData
            ds = (puantajDataSet)Tag;
            try
            {
                var source = (from p in ds.Personel
                              join pgc in ds.PersonelGirisCikis on p.id equals pgc.personelid
                              select new PersonelMesaiData
                              {
                                  Hafta = pgc.hafta > 52 ? 1 : pgc.hafta,
                                  PersonelID = p.id,
                                  PersonelAdSoyad = p.adsoyad,
                                  Tarih = pgc.tarih,
                                  GirisSaat = pgc.giris_saat,
                                  CikisSaat = pgc.cikis_saat,
                                  Yemek = true,
                                  Hesapla = true,
                                  ToplamDakika = 0,
                                  Tatil = pgc.tarih.DayOfWeek == DayOfWeek.Sunday | pgc.tarih.DayOfWeek == DayOfWeek.Saturday
                              });


                List<PersonelMesaiData> list = new List<PersonelMesaiData>();
                foreach (var pers in per.personel)
                {
                    foreach (var pgun in pers.PTarihs.OrderBy(c => c.Tarih))
                    {
                        list.Add(new PersonelMesaiData()
                        {
                            Hafta = GetWeekNumber(pgun.Tarih) > 52 ? 1 : GetWeekNumber(pgun.Tarih),
                            PersonelID = pers.ID,
                            PersonelAdSoyad = pers.AdSoyad,
                            Tarih = pgun.Tarih,
                            GirisSaat = pgun.Giris,
                            CikisSaat = pgun.Cikis.ToString(),
                            Yemek = true,
                            Hesapla = true,
                            ToplamDakika = 0,
                            Tatil = pgun.Tarih.DayOfWeek == DayOfWeek.Sunday | pgun.Tarih.DayOfWeek == DayOfWeek.Saturday

                        });

                    }

                }

                var liste = list.ToList();
                for (int i = 0; i < liste.Count; i++)
                {
                    try
                    {
                        var izin =
                                       ds.PersonelIzin.Where(
                                           c => c.personelid == liste[i].PersonelID && c.tarih == liste[i].Tarih);
                        if (izin.Any(c => c.Saatlik))
                        {
                            var mazeret = izin.FirstOrDefault(c => c.Saatlik);
                            if (mazeret.gidis_saat == new TimeSpan(8, 30, 0))
                            {
                                liste[i].GirisSaat = new TimeSpan(8, 30, 0);
                            }
                            if (mazeret.gelis_saat == new TimeSpan(17, 30, 0))
                            {
                                liste[i].CikisSaat = "17:30:00";
                            }
                        }
                    }
                    catch (Exception ichata)
                    {

                    }

                }

                sourceList = liste;
                gridControl1.DataSource = sourceList;
            }
            catch (Exception xx)
            {
                // throw;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDownAy.Value < 1)
            {
                MessageBox.Show("Tahakkuk ayı belirtilmemiş");
                return;}

            splashScreenManager1.ShowWaitForm();
            MesaileriYukle();
            splashScreenManager1.CloseWaitForm();
        }

       
    }
}