using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using puantaj2017.DAL;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace puantaj2017
{
    public partial class Form1 : Form
    {
        private readonly puantajDataSet ds = new puantajDataSet();
        private readonly ikEntities ik = new ikEntities();
        private readonly object misValue = Missing.Value;

        public Form1()
        {
            var wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (wp.Identity.Name != "KENTKONUT\\noskay")
                return;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void test()
        {
            var personel = ik.Personels.FirstOrDefault(c => c.sicilno == "1355");
            var girisliste =
                ds.PersonelGirisCikis.Where(
                    c => c.personelid == personel.pdksid && c.giris_saat < new TimeSpan(12, 0, 0));
            var izinliste = ds.PersonelIzin.Where(c => c.personelid == personel.pdksid);
        }

        private void perkotekyukle()
        {
            using (
                var con =
                    new MySqlConnection(
                        "Server=172.41.40.85;Database=perkotek;Uid=root;Pwd=max;AllowZeroDateTime=True;Charset=latin5"))
            {
                try
                {
                    var com = new MySqlCommand("", con);
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    #region personel listesi yükle

                    com.CommandText =
                        "select id,concat(adi,' ',soyadi) as  adsoyad from personel_kartlari where sirket_kod=5 or sirket_kod=1";
                    var adapter = new MySqlDataAdapter(com);
                    adapter.Fill(ds.Personel);

                    #endregion

                    #region personel giriş saatlerini yükle

                    com.CommandText =
                        string.Format(
                            "select personel_id as personelid,tarih,giris_saat,cikis_saat, week(tarih,1) as hafta from personel_giriscikis where tarih between '{0}' and '{1}'",
                            dateBaslangic.Value.ToString("yyyy-MM-dd"), dateBitis.Value.ToString("yyyy-MM-dd"));
                    adapter.Fill(ds.PersonelGirisCikis);

                    #endregion

                    #region personel izinlerini yükle

                    com.CommandText =
                        string.Format(
                            "select personel_id as personelid,tatil_id as izintip,tarih,aciklama from personel_izin where tarih between '{0}' and '{1}'",
                            dateBaslangic.Value.ToString("yyyy-MM-dd"), dateBitis.Value.ToString("yyyy-MM-dd"));
                    adapter.Fill(ds.PersonelIzin);

                    #endregion

                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.Personel.Clear();
            ds.PersonelGirisCikis.Clear();
            ds.PersonelIzin.Clear();


            perkotekyukle();
            test();
            personelListBox.DataSource = ds.Personel.OrderBy(c => c.adsoyad).ToList();
        }

        private void personelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var personel = (puantajDataSet.PersonelRow) personelListBox.SelectedItem;
            dataGridView1.DataSource = ds.PersonelGirisCikis.Where(c => c.personelid == personel.id).ToList();
            dataGridView2.DataSource = ds.PersonelIzin.Where(c => c.personelid == personel.id).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //seçili personel puantaj oluştur
            var personel = (puantajDataSet.PersonelRow) personelListBox.SelectedItem;
            MesaiHesapla(personel);

            PuantajGetir(personel);
        }

        private void MesaiHesapla(puantajDataSet.PersonelRow personel)
        {
        }

        private IList<Puantaj> PuantajGetir(puantajDataSet.PersonelRow personel)
        {
            if (personel == null) return new List<Puantaj>();

            var liste = new List<Puantaj>();
            for (var tarih = dateBaslangic.Value; tarih < dateBitis.Value; tarih = tarih.AddDays(1))
            {
                var giris = ds.PersonelGirisCikis.FirstOrDefault(c => c.personelid == personel.id && c.tarih == tarih);
                if (giris == null) //giriş kaydı yok
                {
                    var izin = ds.PersonelIzin.SingleOrDefault(c => c.personelid == personel.id && c.tarih == tarih);
                    if (izin == null)
                    {
                        if (tarih.DayOfWeek == DayOfWeek.Saturday || tarih.DayOfWeek == DayOfWeek.Sunday)
                        {
                            liste.Add(new Puantaj
                            {
                                adsoyad = personel.adsoyad,
                                tarih = tarih,
                                puantaj = "",
                                durum = tarih.ToString("dddd")
                            });
                        }
                    }
                    else
                    {
                        var puantaj = "";
                        switch (izin.izintip)
                        {
                            case 6: //yıllıkizin
                                puantaj = "Y.İ.";
                                break;
                            case 7: //rapor
                                puantaj = "R";
                                break;
                            case 5: //idari tatil
                                puantaj = "X";
                                break;
                            case 8: //denkleştirme
                                puantaj = "D";
                                break;
                            default: //3-ücretli izin,
                                puantaj = "?";
                                break;
                        }
                        liste.Add(new Puantaj
                        {
                            adsoyad = personel.adsoyad,
                            tarih = izin.tarih,
                            puantaj = puantaj,
                            durum = izin.aciklama
                        });
                    }
                }
                else
                    liste.Add(new Puantaj
                    {
                        adsoyad = personel.adsoyad,
                        tarih = giris.tarih,
                        puantaj = "X",
                        durum = giris.giris_saat.ToString()
                    });
            }
            return liste;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dosyayı oluştur
            //sayfa ekle birim adı ile


            var excel = new Application();
            excel.Visible = true;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;


            xlWorkBook = excel.Workbooks.Add(misValue);
            foreach (var birim in ik.birims.OrderBy(c => c.id))
            {
                var worksheet = xlWorkBook.Worksheets.Add();
                worksheet.Name = birim.birimad;
                tabloyuolustur(worksheet, birim); //tablo başlığını oluştur
                //personel verilerini ekle
                //tablo altlığını oluştur.
                // break;
            }
        }

        private void tabloyuolustur(Worksheet worksheet, birim birim)
        {
            Range rg;
            var row = 5;
            var col = 2;
            var left = 2;
            var right = 0;


            var gün1 = 0;
            var gün2 = 0;

            #region SIRA NO

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "SIRA NO";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.57;
            rg.RowHeight = 51.75;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region SİCİL NO

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "SİCİL NO";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 5;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region AD SOYAD

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "PERSONEL\r\nADI SOYADI";
            rg.Font.Size = 7;
            rg.ColumnWidth = 20;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region HİZMET KADROSU

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "HİZMET\r\nKADROSU";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 6.71;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region ÇALIŞMA ŞEKLİ

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "ÇALIŞMA ŞEKLİ";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.29;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            gün1 = col;

            #region AY GÜNLERİNİ EKLE

            for (var tarih = dateBaslangic.Value; tarih <= dateBitis.Value; tarih = tarih.AddDays(1))
            {
                rg = (Range) worksheet.Cells[row, col++];
                rg.Font.Size = 7;
                rg.ColumnWidth = 2.14;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rg.Value2 = tarih.Day.ToString();
            }

            #endregion

            gün2 = col - 1;

            #region ayıraç

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 0.25;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region ÇALIŞMA GÜNÜ

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "ÇALIŞMA GÜNÜ";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region YILLIK İZİN

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "YILLIK İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region DİĞER İZİN

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "DİĞER İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region RAPOR

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "RAPOR";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region ÜCRETSİZ İZİN

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "ÜCRETSİZ İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region FM1

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "FM1(NORMAL)";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region FM2

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "FM2(NORMAL)";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            #region AÇIKLAMA

            rg = (Range) worksheet.Cells[row, col++];
            rg.Value2 = "AÇIKLAMA";
            rg.Font.Size = 7;
            rg.ColumnWidth = 25.86;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion

            right = col - 1;

            var sıra = 1;
            row = 6;

            foreach (var personel in birim.Personels.Where(c => c.puantaj).OrderBy(c => c.sira))
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

                rg = (Range) worksheet.Cells[row, col];
                rg.Value2 = "F.M.";
                rg.Font.Size = 7;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                row++;
                rg = (Range) worksheet.Cells[row, col];
                rg.Value2 = "N.G.";
                rg.Font.Size = 7;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                #endregion

                //burada puantaj kayıtları gir.
                var liste = PuantajGetir(ds.Personel.SingleOrDefault(c => c.id == personel.pdksid));

                var g1 = ColumnIndexToColumnLetter(gün1 - 1);
                var g2 = ColumnIndexToColumnLetter(gün2);
                var r = 5;
                Range firstFind;
                var tarihRange = worksheet.get_Range(g1 + r, g2 + r);

                #region GÜNLÜK PUANTAJLAR

                foreach (var puan in liste)
                {
                    firstFind = tarihRange.Find(puan.tarih.Day, misValue, XlFindLookIn.xlValues, XlLookAt.xlPart,
                        XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false, misValue, misValue);

                    rg = (Range) worksheet.Cells[row, firstFind.Column];
                    rg.Value2 = puan.puantaj;

                    rg.Font.Size = 11;
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    if (puan.tarih.DayOfWeek == DayOfWeek.Saturday || puan.tarih.DayOfWeek == DayOfWeek.Sunday)
                    {
                        rg.Interior.Color = XlRgbColor.rgbDimGray;
                        ((Range) worksheet.Cells[row - 1, firstFind.Column]).Interior.Color = XlRgbColor.rgbDimGray;
                        ;
                    }
                    //if (puan.durum == "Cumartesi" || puan.durum == "Pazar")
                    //{
                    //    rg.Interior.Color = Excel.XlRgbColor.rgbDimGray;
                    //    ((Excel.Range)worksheet.Cells[row-1, firstFind.Column]).Interior.Color =Excel.XlRgbColor.rgbDimGray; ;
                    //}
                }

                #endregion

                row--;
                col = gün2 + 1;

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

            #region GRİD ÇİZ

            rg = worksheet.get_Range(ColumnIndexToColumnLetter(left) + 5, ColumnIndexToColumnLetter(right) + (row - 1));
            rg.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            rg.Borders.Color = Color.Black;

            #endregion
        }

        private static string ColumnIndexToColumnLetter(int colIndex)
        {
            var div = colIndex;
            var colLetter = string.Empty;
            var mod = 0;

            while (div > 0)
            {
                mod = (div - 1)%26;
                colLetter = (char) (65 + mod) + colLetter;
                div = (div - mod)/26;
            }
            return colLetter;
        }

        private void mesaiHesaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Mesailer {Tag = ds};
            form.ShowDialog();
        }
    }
}