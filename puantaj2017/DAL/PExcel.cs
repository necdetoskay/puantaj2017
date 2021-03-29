using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Office.Utils;
using Microsoft.Office.Interop.Excel;
using puantaj2017.DAL;
using PtakipDAL;

namespace puantaj2017.DAL
{
    public class PExcel
    {
        private readonly object misValue = Missing.Value;
        private PerkotekContext per;
        public PExcel(PerkotekContext per)
        {
            this.per = per;
        }

        #region puantaj  excel hazırlama
        public void AylikPuantaj(DateTime tarih1, DateTime tarih2)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkBook;
            object misValue = Missing.Value;
            xlWorkBook = excel.Workbooks.Add(misValue);
            excel.Visible = true;
            Worksheet xlWorkSheet;
            using (var ik = new ikEntities())
            {
                foreach (var birim in ik.birims.Where(c => c.puantaj == true).OrderBy(c => c.sira))
                {
                    var sira = 1; 
                    var margin = 3;
                    var bakilan = 0;
                    var sayi = birim.Personels.Count(c => c.puantaj);
                   
                    

                    if (sayi > 10+margin)
                    {
                        var sayfa = sayi / 10;
                        var fc = sayi % 10;
                        if (fc > margin) sayfa++;
                        var d = sayi / sayfa;

                        var take = d + (sayi%d);
                        while (bakilan < sayi)
                        {
                            xlWorkSheet = xlWorkBook.Worksheets.Add();
                            xlWorkSheet.Name = birim.birimad + sira;
                            tabloyuolustur(xlWorkSheet, birim.Personels.Where(c => c.puantaj).OrderByDescending(c=>c.sira).Skip(bakilan).Take(take), tarih1, tarih2);
                            //Debug.WriteLine(string.Format("Bakılan aralık: {0} - {1}",bakilan,take));
                            bakilan +=take;
                            take = sayi - (bakilan*sira);
                            sira++;
                        }
                    }
                    else
                    {

                        xlWorkSheet = xlWorkBook.Worksheets.Add();
                        xlWorkSheet.Name = birim.birimad + sira.ToString();
                        tabloyuolustur(xlWorkSheet, birim.Personels.Where(c => c.puantaj), tarih1, tarih2);
                    }

                  


                    //sayı 10 dan büyükse birimi ikiye ayır

                    //xlWorkSheet = xlWorkBook.Worksheets.Add();
                    //xlWorkSheet.Name = birim.birimad;
                    //tabloyuolustur(xlWorkSheet, birim, tarih1, tarih2); //tablo başlığını oluştur
                                                                      //personel verilerini ekle
                                                                      //tablo altlığını oluştur.
                }
            }
        }

        private void tabloyuolustur(Worksheet worksheet, IEnumerable<Personel> personels, DateTime tarih1, DateTime tarih2)
        {

            Range rg;
            var row = 5;
            var col = 2;
            var left = 2;
            var right = 0;


            var gün1 = 0;
            var gün2 = 0;

            #region SIRA NO

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "SIRA NO";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.57;
            rg.RowHeight = 51.75;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region SİCİL NO

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "SİCİL NO";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 5;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region AD SOYAD

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "PERSONEL\r\nADI SOYADI";
            rg.Font.Size = 7;
            rg.ColumnWidth = 20;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region HİZMET KADROSU

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "HİZMET\r\nKADROSU";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 6.71;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region ÇALIŞMA ŞEKLİ

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "ÇALIŞMA ŞEKLİ";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.29;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            gün1 = col;

            #region AY GÜNLERİNİ EKLE

            for (var tarih = tarih1; tarih <= tarih2; tarih = tarih.AddDays(1))
            {
                rg = (Range)worksheet.Cells[row, col++];
                rg.Font.Size = 7;
                rg.ColumnWidth = 2.14;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Value2 = tarih.Day.ToString();
            }

            #endregion

            gün2 = col - 1;

            #region ayıraç

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 0.25;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region ÇALIŞMA GÜNÜ

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "ÇALIŞMA GÜNÜ";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region YILLIK İZİN

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "YILLIK İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region DİĞER İZİN

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "DİĞER İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region RAPOR

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "RAPOR";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region ÜCRETSİZ İZİN

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "ÜCRETSİZ İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region FM1

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "FM1(NORMAL)";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region FM2

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "FM2(NORMAL)";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region AÇIKLAMA

            rg = (Range)worksheet.Cells[row, col++];
            rg.Value2 = "AÇIKLAMA";
            rg.Font.Size = 7;
            rg.ColumnWidth = 15.86;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            right = col - 1;

            var sıra = 1;
            row = 6;

            foreach (var personel in personels)
            {
                col = 2;

                #region SIRA NO

                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = sıra.ToString();
                rg.Font.Size = 11;
                //rg.ColumnWidth = 2.57;
                //rg.RowHeight = 51.75;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                col++;

                #endregion

                #region SİCİL NO

                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = personel.sicilno;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                col++;

                #endregion

                #region PERSONEL AS SOYAD

                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = personel.adsoyad;
                rg.Font.Size = 8;
                rg.WrapText = true;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                col++;

                #endregion

                #region HİZMET KADROSU

                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "İŞÇİ";
                rg.Font.Size = 8;
                rg.WrapText = true;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                col++;

                #endregion

                #region ÇALIŞMA ŞEKLİ

                rg = (Range)worksheet.Cells[row, col];
                rg.Value2 = "F.M.";
                rg.Font.Size = 7;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                row++;
                rg = (Range)worksheet.Cells[row, col];
                rg.Value2 = "N.G.";
                rg.Font.Size = 7;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                #endregion//burada puantaj kayıtları gir.


                var liste = per.personel.FirstOrDefault(c => c.ID == personel.pdksid);
                if (liste == null)
                {
                    row += 1;
                    sıra++;
                    continue;
                }
                var g1 = ColumnIndexToColumnLetter(gün1 - 1);
                var g2 = ColumnIndexToColumnLetter(gün2);
                var r = 5;
                Range firstFind;
                var tarihRange = worksheet.get_Range(g1 + r, g2 + r);

                #region GÜNLÜK PUANTAJLAR

                var çalışma = 0;
                var rapor = 0;
                var yıllıkizin = 0;


                //liste personelin aylık puantaj bilgileri
                for (var t = tarih1; t <= tarih2; t = t.AddDays(1))
                {
                    firstFind = tarihRange.Find(t.Day, misValue, XlFindLookIn.xlValues, XlLookAt.xlPart,
                       XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false, misValue, misValue);

                    rg = (Range)worksheet.Cells[row, firstFind.Column];
                    var puan = liste.PTarihs.FirstOrDefault(c => c.Tarih == t.Date);
                    var haftasonu = t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday;
                    if (puan != null)
                    {
                        rg.Value2 = puan.Durum;
                        switch (puan.Durum)
                        {
                            case "R":
                                rapor++;
                                break;
                            case "Y.İ.":
                                yıllıkizin++;
                                çalışma++;
                                break;
                            case "??":
                                break;
                            default:
                                {

                                    çalışma++;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        if (haftasonu)
                            çalışma++;
                    }
                    rg.Font.Size = 11;
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    if (haftasonu)
                    {
                        rg.Interior.Color = XlRgbColor.rgbDimGray;
                        ((Range)worksheet.Cells[row - 1, firstFind.Column]).Interior.Color = XlRgbColor.rgbDimGray;


                    }
                }


                //foreach (var puan in liste.PTarihs)
                //{
                //    firstFind = tarihRange.Find(puan.Tarih.Day, misValue, XlFindLookIn.xlValues, XlLookAt.xlPart,
                //        XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false, misValue, misValue);


                //    //if (puan.durum == "Cumartesi" || puan.durum == "Pazar")
                //    //{
                //    //    rg.Interior.Color = Excel.XlRgbColor.rgbDimGray;
                //    //    ((Excel.Range)worksheet.Cells[row-1, firstFind.Column]).Interior.Color =Excel.XlRgbColor.rgbDimGray; ;
                //    //}
                //}

                #endregion


                row--;
                col = gün2 + 1;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = çalışma > 0 ? çalışma.ToString() : "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = yıllıkizin > 0 ? yıllıkizin.ToString() : "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = rapor > 0 ? rapor.ToString() : "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                    ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;





                //col++;


                //var index = firstFind.Column;


                //row--;
                row += 2;
                sıra++;
            }
            var gridrow = row;

            row += 3;
            col = 2;

            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                   ColumnIndexToColumnLetter(right) + (row));
            rg.Merge();
            rg.RowHeight = 32.25;
            rg.Value2 = "GENEL MÜDÜRLÜK MAKAMINA";
            rg.Font.Size = 11;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            row++;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                 ColumnIndexToColumnLetter(right) + (row));
            rg.Merge();
            rg.Value2 = "PERSONELLERİN AYLIK PUANTAJI İLE PUANTAJDA BELİRTİLEN TARİH " +
                        "VE SAATLERDE ZORUNLU OLARAK YAPTIRILMIŞ OLAN\r\nMESAİ " +
                        "ÜCRETLERİNİN ÖDENMESİ HUSUSUNDA GEREĞİNİ ARZ EDERİM";
            rg.Font.Size = 11;
            rg.RowHeight = 32.25;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            row++;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                ColumnIndexToColumnLetter(col + 6) + (row));
            rg.Merge();
            rg.Value2 = "NOT:";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            col += 7;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                ColumnIndexToColumnLetter(col + 7) + (row));
            rg.Merge();
            rg.Value2 = "PERSONEL";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            col += 14;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
               ColumnIndexToColumnLetter(col + 8) + (row));
            rg.Merge();
            rg.Value2 = "ŞEF";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            col += 14;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
               ColumnIndexToColumnLetter(col + 8) + (row));
            rg.Merge();
            rg.Value2 = "MÜDÜR";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            row++;
            col = 2;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                ColumnIndexToColumnLetter(col + 6) + (row));
            rg.Merge();
            rg.Value2 = "NG:NORMAL GÜN";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            row++;
            col = 2;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
               ColumnIndexToColumnLetter(col + 6) + (row));
            rg.Merge();
            rg.Value2 = "FM:FAZLA MESAİ";
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            var bottom = row + 5;


            col = 2;
            row = 2;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
                  ColumnIndexToColumnLetter(right) + (row));
            rg.Merge();
            rg.RowHeight = 35.25;
            rg.Font.Bold = true;
            rg.Value2 = "KENT KONUT İNŞAAT SANAYİ VE TİCARET A.Ş.";
            rg.Font.Size = 14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            row++;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
               ColumnIndexToColumnLetter(col + 4) + (row));
            rg.Merge();
            rg.Value2 = string.Format("AY:  {0}", tarih1.ToString("MMMM"));
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            col += 5;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
               ColumnIndexToColumnLetter(right) + (row));
            rg.Merge();
            rg.Value2 =personels.First().birim.fullad.ToUpper();
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;




            #region GRİD ÇİZ

            rg = worksheet.get_Range(ColumnIndexToColumnLetter(left) + 5, ColumnIndexToColumnLetter(right) + (gridrow - 1));
            rg.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders.Color = Color.Black;

            #endregion

            //yazdırma alanı belirle
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(2) + 2,
              ColumnIndexToColumnLetter(right) + (row + 5));
            worksheet.PageSetup.PrintArea = String.Format("{0}{1}:{2}{3}", ColumnIndexToColumnLetter(2), 2, ColumnIndexToColumnLetter(right), bottom);
            worksheet.PageSetup.FitToPagesWide = 1;
            worksheet.PageSetup.FitToPagesTall = 1;
            worksheet.PageSetup.Zoom = false;
            worksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;

         


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
        #endregion
    }
}
