using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
//using DevExpress.XtraBars.Docking2010.Views.Widget;
using Microsoft.Office.Interop.Excel;
using puantaj2017.DAL;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace puantaj2017
{
    public partial class IzinRapor : Form
    {
        public IzinRapor()
        {
            InitializeComponent();

        }
        public Application excel { get; set; }

        public Workbook workbook { get; set; }

        private puantajDataSet ds;
        private DateTime tarih1;
        private DateTime tarih2;
        private void IzinRapor_Load(object sender, EventArgs e)
        {

            ds = (puantajDataSet)Tag.GetType().GetProperty("DSet").GetValue(Tag, null);
            tarih1 = (DateTime)Tag.GetType().GetProperty("tarih1").GetValue(Tag, null);
            tarih2 = (DateTime)Tag.GetType().GetProperty("tarih2").GetValue(Tag, null);

            try
            {
                var list = (from p in ds.Personel
                            join
                                pi in ds.PersonelIzin on p.id equals pi.personelid
                            select new IzinGrid { ID = pi.ID, adsoyad = p.adsoyad, tarih = pi.tarih, izintip = pi.izintip, aciklama = pi.aciklama }).ToList();
                gridControl1.DataSource = list;
                //gridView1.ActiveFilterString = "[izintip] =7";
            }
            catch (Exception LL)
            {
                MessageBox.Show(LL.Message);

            }

        }

        private void CheckStatusIzin()
        {


        }

        private void CheckStatusList(puantajDataSet ds1, DateTime dateTime, DateTime tarih3)
        {


        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridControl1.DefaultView.DataRowCount; i++)
            {
                var row = gridControl1.DefaultView.GetRow(i);
            }
            //personel adı
            //rapor başlangıç tarihi
            //rapor bitiş tarihi
            //rapor günü

            //string FileName = "C:\\Grid.xls";
            //gridControl1.ExportToXls(FileName);
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void raporlarıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var raporlar = ((List<IzinGrid>)gridControl1.DataSource).Where(c => c.izintip == 7);


            List<puantajrapor> rpr = new List<puantajrapor>();
            puantajrapor rap;
            IzinGrid prev;
            IzinGrid next;
            IzinGrid cur;

            foreach (var rapor in raporlar.GroupBy(c => c.adsoyad))
            {
                if (rapor.Key.StartsWith("AYLİN"))
                {
                    
                }
                var rprlar = rapor.OrderBy(c=>c.tarih).ToList();

                puantajrapor rp = null;
                for (int i = 0; i < rprlar.Count; i++)
                {
                    if (rp == null)
                    {
                        rp=new puantajrapor();
                        rp.adsoyad = rapor.Key;
                        rp.baslangic = rprlar[i].tarih;
                        rp.bitis = rprlar[i].tarih;
                        rp.gun = 1;
                        rp.aciklama = rprlar[i].aciklama;
                    }
                    else
                    {
                        var a = rprlar[i];
                        
                        if (rp.bitis.AddDays(1).Date == a.tarih.Date && rp.aciklama==a.aciklama) //rapor devam ediyor
                        {
                            rp.bitis = a.tarih;
                            rp.gun += 1;
                        }
                        else//yeni rapora geçildi
                        {
                            rpr.Add(rp);
                            rp = new puantajrapor();
                            rp.adsoyad = rapor.Key;
                            rp.baslangic = rprlar[i].tarih;
                            rp.bitis = rprlar[i].tarih;
                            rp.gun = 1;
                            rp.aciklama = rprlar[i].aciklama;

                        }
                    }
                }

                rpr.Add(rp);


              //  var pers = rapor.FirstOrDefault();

                //if (rapor.Count() == 1)
                //{
                //    rap = new puantajrapor { adsoyad = pers.adsoyad, baslangic = pers.tarih, bitis = pers.tarih, gun = 1 };
                //    rpr.Add(rap);
                //}
                //else
                //{
                //    var gun = 1;
                //    foreach (var prap in rapor)
                //    {
                //        gun++;
                //        cur = prap;
                //        prev = rapor.FirstOrDefault(c => c.ID == cur.ID - 1);
                //        next = rapor.FirstOrDefault(c => c.ID == cur.ID + 1);
                //        if (prev == null)
                //        {
                //            gun = 1;
                //            rap = new puantajrapor { adsoyad = cur.adsoyad, baslangic = cur.tarih, bitis = cur.tarih, gun = gun };

                //            rpr.Add(rap);
                //            if (next != null)
                //                rap.bitis = next.tarih;
                //            continue;

                //        }
                //        var lastOrDefault = rpr.LastOrDefault();
                //        if (lastOrDefault != null)
                //        {
                //            lastOrDefault.bitis = cur.tarih;
                //            lastOrDefault.gun = gun;
                //        }
                //    }

                //}


            }
            RaporExcel("İzinler ve Raporlar", rpr);
            //rpr listesini excel e yazdır.
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
        private void RaporExcel(string izinler, List<puantajrapor> rpr)
        {//var a = rpr.GroupBy(c => c.adsoyad);

            var haftaiçi = 0;var haftasonu = 0;
            var aygün = 0;
            List<KeyValuePair<int, int>> sgkgun = new List<KeyValuePair<int, int>>();
            sgkgun.Add(new KeyValuePair<int, int>(31, 3));
            sgkgun.Add(new KeyValuePair<int, int>(30, 2));
            sgkgun.Add(new KeyValuePair<int, int>(29, 1));
            sgkgun.Add(new KeyValuePair<int, int>(28, 0));for (DateTime t1 = tarih1; t1 <= tarih2; t1 = t1.AddDays(1))
            {
                aygün++;
                if (t1.DayOfWeek == DayOfWeek.Sunday)
                {
                    haftasonu++;
                }
                else
                {
                    haftaiçi++;
                }
            }


            var worksheet = (Worksheet)workbook.Worksheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);


            worksheet.Name = izinler;
            excel.Visible = true;
            excel.DisplayAlerts = false;

            Range rg;var row = 2;
            var col = 1;

            //rg = worksheet.get_Range(ColumnIndexToColumnLetter(2) + 1, ColumnIndexToColumnLetter(6) + 1);
            //rg.Value2 = string.Format("AVANSLAR MERKEZ {0} AYI", tarih1.ToString("MMMMM"));
            //rg.Merge();
            //rg.Font.Size = 14;
            //rg.RowHeight = 57;
            //rg.Font.Bold = true;
            //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


            //row++;
            //#region Sıra no
            //rg = (Range)worksheet.Cells[row, col++];
            //rg.Value2 = "Sıra No";//rg.Font.Size = 11;
            //rg.ColumnWidth = 7.57;
            //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //rg.Font.Bold = true;
            //#endregion

            int say = 1;

            foreach (PropertyInfo info in typeof(puantajrapor).GetProperties())
            {
                if (info.Name == "ID") continue;

                say++;
                #region Sıra no 
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = info.Name;
                rg.Font.Size = 11;
                rg.ColumnWidth = 7.57;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Font.Bold = true;
                #endregion
            }
            col = 1;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(1) + 1, ColumnIndexToColumnLetter(4) + 1);
            rg.Value2 = "RAPORLAR";
            rg.Merge();
            rg.Font.Size = 14;
            rg.RowHeight = 57;
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            row += 1;



            foreach (var puantajrapor in rpr)
            {
                //#region ID
                //rg = (Range)worksheet.Cells[row, col++];
                //rg.Value2 = puantajrapor.ID;
                //rg.Font.Size = 11;
                //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //#endregion
                #region adsoayd
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = puantajrapor.adsoyad;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                #endregion
                #region baslangıç
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = puantajrapor.baslangic;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.NumberFormat = "dd/mm/yyyy";
                #endregion
                #region bitiş
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = puantajrapor.bitis;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.NumberFormat = "dd/mm/yyyy";
                #endregion
                #region gun
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = puantajrapor.gun;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                #endregion

                col = 1;
                row++;
            }

            #region GRİD ÇİZ

            rg = worksheet.get_Range(ColumnIndexToColumnLetter(1) + 1, ColumnIndexToColumnLetter(4) + --row);
            rg.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders.Color = Color.Black;

            #endregion


            ///rapor personel birleşik




            col = 6;
            row = 2;
            foreach (PropertyInfo info in typeof(puantajrapor).GetProperties())
            {
                if (info.Name == "ID" || info.Name == "baslangic" || info.Name == "bitis") continue;

                say++;
                #region Sıra no 
                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = info.Name;
                rg.Font.Size = 11; rg.ColumnWidth = 7.57;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Font.Bold = true;
                #endregion
            }

            //rg = (Range)worksheet.Cells[row, col++];
            //rg.Value2 = "Kesilecek Gün";
            //rg.Font.Size = 11; rg.ColumnWidth = 7.57;
            //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //rg.Font.Bold = true;

            //rg = (Range)worksheet.Cells[row, col++];
            //rg.Value2 = "Hafta İçi";
            //rg.Font.Size = 11; rg.ColumnWidth = 7.57;
            //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //rg.Font.Bold = true;

            //rg = (Range)worksheet.Cells[row, col++];
            //rg.Value2 = "Hafta Sonu";
            //rg.Font.Size = 11; rg.ColumnWidth = 7.57;
            //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //rg = (Range)worksheet.Cells[row, col++];
            //rg.Font.Bold = true;

            //rg.Value2 = "Sgk Gün";
            //rg.Font.Size = 11; rg.ColumnWidth = 7.57;
            //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //rg = (Range)worksheet.Cells[row, col++];
            //rg.Font.Bold = true;

            //rg.Value2 = "Yemek";
            //rg.Font.Size = 11; rg.ColumnWidth = 7.57;
            //rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //rg.Font.Bold = true;



            col = 6;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(6) + 1, ColumnIndexToColumnLetter(6 + 1) + 1);
            rg.Value2 = "RAPORLAR";
            rg.Merge();
            rg.Font.Size = 14;
            rg.RowHeight = 57;
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            row++;
            foreach (var puantajrapor in rpr.GroupBy(c => c.adsoyad))
            {



                //#region hesapla
                //var verilecekgün = aygün==31?3:2;
                //var kesilenhaftaiçi = 0;
                //var kesilenhaftasonu = 0;
                //var raporlugün = 0;
                //var kesilecekgun = 0;
                //foreach (var pntj in puantajrapor)
                //{
                //    for (DateTime t1 = pntj.baslangic; t1 <= pntj.bitis; t1 = t1.AddDays(1))
                //    {
                //        raporlugün++;
                //        if (verilecekgün > 0)
                //        {
                //            verilecekgün--;
                //        }
                //        else
                //        {
                //            if (t1.DayOfWeek == DayOfWeek.Sunday)
                //            {
                //                kesilenhaftasonu++;
                //                // kesilenhaftasonu++;
                //            }
                //            else
                //            {
                //                kesilenhaftaiçi++;
                //                // kesilenhaftaiçi++;
                //            }
                //        }
                //    }
                //}
                ////kesilecekgun = raporlugün - (aygün == 31 ? 3 : 2); 
                //#endregion
                #region adsoayd

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = puantajrapor.FirstOrDefault().adsoyad;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                #endregion

                #region gun
                var raporgun = puantajrapor.Sum(c => c.gun);

                rg = (Range)worksheet.Cells[row, col++];
                rg.Value2 = raporgun;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;



                #endregion

                //if (kesilecekgun > 0)
                //{

                //    rg = (Range)worksheet.Cells[row, col++];
                //    rg.Value2 = kesilecekgun;
                //    rg.Font.Size = 11; rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


                //    rg = (Range)worksheet.Cells[row, col++];
                //    rg.Value2 = kesilenhaftaiçi;
                //    rg.Font.Size = 11;
                //    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


                //    rg = (Range)worksheet.Cells[row, col++];
                //    rg.Value2 = kesilenhaftasonu;
                //    rg.Font.Size = 11;
                //    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //    int gunskg = sgkgun.SingleOrDefault(c => c.Key == aygün).Key - kesilecekgun;
                //    rg = (Range)worksheet.Cells[row, col++];
                //    rg.Value2 = gunskg;
                //    rg.Font.Size = 11;
                //    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                //    if (gunskg < 22)
                //    {
                //        var yemek = Math.Ceiling((350f / 22f) * gunskg);
                //        rg = (Range)worksheet.Cells[row, col++];
                //        rg.Value2 = yemek;
                //        rg.Font.Size = 11;
                //        rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //        rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //    }
                //}
                #region puantajgün
                //haftaiçi
                //haftasonu
                //aygün
                //kaç gün verilecek

                //if (raporgun - sgkgun.SingleOrDefault(c => c.Key == aygün).Value > 0)
                //{

                //};  
                //30 günse 2 gün ver kalanı kes
                //31 günse 3 gün ver kalanı kes
                //28 günse hiç verme
                #endregion
                col = 6;
                row++;
            }






        }

        private void izinleriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var izinler = ((List<IzinGrid>)gridControl1.DataSource).Where(c => c.izintip == 6);


            List<puantajizin> rpr = new List<puantajizin>();
            puantajizin rap;
            IzinGrid prev;
            IzinGrid next;
            IzinGrid cur;

            try
            {
                foreach (var personel in izinler.GroupBy(c => c.adsoyad))
                {
                    bool yeni = true;
                    foreach (var izin in personel)
                    {
                    }

                }
            }
            catch (Exception ex)
            {


            }



        }
    }



}
