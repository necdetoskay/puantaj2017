using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using puantaj2017.DAL;
using Excel = Microsoft.Office.Interop.Excel;

namespace puantaj2017
{
    public partial class Form1 : Form
    {
        puantajDataSet ds = new puantajDataSet();
        ikEntities ik=new ikEntities();
        object misValue = System.Reflection.Missing.Value;
        public Form1()
        {
            WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (wp.Identity.Name != "KENTKONUT\\noskay")
                return;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void test()
        {
            var personel = ik.Personels.FirstOrDefault(c=>c.sicilno=="1355");
            var girisliste = ds.PersonelGirisCikis.Where(c => c.personelid == personel.pdksid && c.giris_saat<new TimeSpan(12,0,0));
            var izinliste = ds.PersonelIzin.Where(c => c.personelid == personel.pdksid);
        }
        private void perkotekyukle()
        {
            using (var con = new MySqlConnection("Server=172.41.40.85;Database=perkotek;Uid=root;Pwd=max;AllowZeroDateTime=True;Charset=latin5"))
            {
                try
                {
                    
                    var com = new MySqlCommand("", con);
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    #region personel listesi yükle
                    com.CommandText =
                                  "select id,concat(adi,' ',soyadi) as  adsoyad from personel_kartlari where sirket_kod=5";
                    var adapter = new MySqlDataAdapter(com);
                    adapter.Fill(ds.Personel);
                    #endregion
                    #region personel giriş saatlerini yükle
                    com.CommandText =
                                   string.Format(
                                       "select personel_id as personelid,tarih,giris_saat from personel_giriscikis where tarih between '{0}' and '{1}'",
                                      dateBaslangic.Value.ToString("yyyy-MM-dd"), dateBitis.Value.ToString("yyyy-MM-dd"));
                    adapter.Fill(ds.PersonelGirisCikis);
                    #endregion
                    #region personel izinlerini yükle
                    com.CommandText = string.Format("select personel_id as personelid,tatil_id as izintip,tarih,aciklama from personel_izin where tarih between '{0}' and '{1}'",
                                     dateBaslangic.Value.ToString("yyyy-MM-dd"), dateBitis.Value.ToString("yyyy-MM-dd"));
                    adapter.Fill(ds.PersonelIzin); 
                    #endregion

                    con.Close();
                }
                catch (Exception ex)
                {

                    con.Close();
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            perkotekyukle();
            test();
            personelListBox.DataSource = ds.Personel.OrderBy(c=>c.adsoyad).ToList();
        }

        private void personelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var personel = (puantajDataSet.PersonelRow)personelListBox.SelectedItem;
            dataGridView1.DataSource = ds.PersonelGirisCikis.Where(c => c.personelid == personel.id).ToList();
            dataGridView2.DataSource=ds.PersonelIzin.Where(c => c.personelid == personel.id).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //seçili personel puantaj oluştur
            var personel= (puantajDataSet.PersonelRow)personelListBox.SelectedItem;
            PuantajGetir(personel);
        }

        private IList<Puantaj> PuantajGetir(puantajDataSet.PersonelRow personel)
        {
            if(personel==null) return new List<Puantaj>();

            var liste=new List<Puantaj>();
            for (DateTime tarih = dateBaslangic.Value; tarih < dateBitis.Value; tarih=tarih.AddDays(1))
            {
                var giris = ds.PersonelGirisCikis.FirstOrDefault(c => c.personelid == personel.id &&c.tarih==tarih);
                if (giris == null)//giriş kaydı yok
                {
                    var izin = ds.PersonelIzin.SingleOrDefault(c => c.personelid == personel.id && c.tarih == tarih);
                    if (izin == null)
                    {
                        if (tarih.DayOfWeek == DayOfWeek.Saturday || tarih.DayOfWeek == DayOfWeek.Sunday)
                        {
                            liste.Add(new Puantaj{ adsoyad = personel.adsoyad, tarih = tarih, puantaj = "", durum = tarih.ToString("dddd") });
                        }
                    }
                    else
                    {
                        var puantaj = "";
                        switch (izin.izintip)
                        {
                            case 6://yıllıkizin
                                puantaj = "Y.İ.";
                                break;
                            case 7://rapor
                                puantaj = "R";
                                break;
                            case 5://idari tatil
                                puantaj = "X";
                                break;
                            case 8://denkleştirme
                                puantaj = "D";
                                break;
                            default://3-ücretli izin,
                                puantaj = "?";
                                break;

                        }
                        liste.Add(new Puantaj{adsoyad = personel.adsoyad, tarih = izin.tarih, puantaj = puantaj, durum = izin.aciklama});
                    }
                }else
                    liste.Add(new Puantaj{adsoyad = personel.adsoyad, tarih = giris.tarih, puantaj="X", durum = giris.giris_saat.ToString()});
            }
            return liste;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dosyayı oluştur
            //sayfa ekle birim adı ile
            

            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            

            xlWorkBook = excel.Workbooks.Add(misValue);
            foreach (var birim in ik.birims.OrderBy(c=>c.id))
            {
                var worksheet = xlWorkBook.Worksheets.Add();
                worksheet.Name = birim.birimad;
                tabloyuolustur(worksheet,birim);//tablo başlığını oluştur
                //personel verilerini ekle
                //tablo altlığını oluştur.
                // break;
                

            }

          


        }

        private void tabloyuolustur(Excel.Worksheet worksheet, birim birim)
        {
            Excel.Range rg;
            int row = 5;
            int col = 2;
            int left = 2;
            int right = 0;


            int gün1 = 0;
            int gün2 = 0;


            #region SIRA NO
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "SIRA NO";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.57;
            rg.RowHeight = 51.75;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region SİCİL NO
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "SİCİL NO";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 5;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region AD SOYAD
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "PERSONEL\r\nADI SOYADI";
            rg.Font.Size = 7;
            rg.ColumnWidth = 20;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region HİZMET KADROSU
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "HİZMET\r\nKADROSU";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 6.71;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region ÇALIŞMA ŞEKLİ
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "ÇALIŞMA ŞEKLİ";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.29;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; 
            #endregion

            gün1 = col;

            #region AY GÜNLERİNİ EKLE
            for (DateTime tarih = dateBaslangic.Value; tarih <= dateBitis.Value; tarih = tarih.AddDays(1))
            {
                rg = (Excel.Range)worksheet.Cells[row, col++];
                rg.Font.Size = 7;
                rg.ColumnWidth = 2.14;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rg.Value2 = tarih.Day.ToString();
            } 
            #endregion

            gün2 = col - 1;

            #region ayıraç
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 0.25;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region ÇALIŞMA GÜNÜ
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "ÇALIŞMA GÜNÜ";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region YILLIK İZİN
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "YILLIK İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region DİĞER İZİN
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "DİĞER İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region RAPOR
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "RAPOR";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region ÜCRETSİZ İZİN
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "ÜCRETSİZ İZİN";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region FM1
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "FM1(NORMAL)";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region FM2
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "FM2(NORMAL)";
            rg.Orientation = 90;
            rg.Font.Size = 7;
            rg.ColumnWidth = 2.14;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            #endregion

            #region AÇIKLAMA
            rg = (Excel.Range)worksheet.Cells[row, col++];
            rg.Value2 = "AÇIKLAMA";
            rg.Font.Size = 7;
            rg.ColumnWidth = 25.86;
            rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter; 
            #endregion

            right = col-1;

            var sıra = 1;
            row = 6;
            
            foreach (var personel in birim.Personels.Where(c=>c.puantaj).OrderBy(c=>c.sira))
            {
                col = 2;

                #region SIRA NO
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = sıra.ToString();
                rg.Font.Size = 11;
                //rg.ColumnWidth = 2.57;
                //rg.RowHeight = 51.75;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                col++;
                #endregion

                #region SİCİL NO
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = personel.sicilno;
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                col++;
                #endregion

                #region PERSONEL AS SOYAD
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = personel.adsoyad;
                rg.Font.Size = 8;
                rg.WrapText = true;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                col++;
                #endregion

                #region HİZMET KADROSU
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "İŞÇİ";
                rg.Font.Size = 8;
                rg.WrapText = true;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                col++;
                #endregion


                #region ÇALIŞMA ŞEKLİ
                rg = (Excel.Range)worksheet.Cells[row, col];
                rg.Value2 = "F.M.";
                rg.Font.Size = 7;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                row++;
                rg = (Excel.Range)worksheet.Cells[row, col];
                rg.Value2 = "N.G.";
                rg.Font.Size = 7;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                #endregion

                //burada puantaj kayıtları gir.
                var liste = PuantajGetir(ds.Personel.SingleOrDefault(c=>c.id==personel.pdksid));

                var g1 = ColumnIndexToColumnLetter(gün1-1);
                var g2 = ColumnIndexToColumnLetter(gün2);
                var r = 5;
                Excel.Range firstFind;
                Excel.Range tarihRange = worksheet.get_Range(g1+r, g2+r);

                #region GÜNLÜK PUANTAJLAR
                foreach (var puan in liste)
                {
                    firstFind = tarihRange.Find(puan.tarih.Day, misValue, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, misValue, misValue);

                    rg = (Excel.Range)worksheet.Cells[row, firstFind.Column];
                    rg.Value2 = puan.puantaj;

                    rg.Font.Size = 11;
                    rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    if (puan.tarih.DayOfWeek == DayOfWeek.Saturday || puan.tarih.DayOfWeek == DayOfWeek.Sunday)
                    {
                        rg.Interior.Color = Excel.XlRgbColor.rgbDimGray;
                        ((Excel.Range)worksheet.Cells[row - 1, firstFind.Column]).Interior.Color = Excel.XlRgbColor.rgbDimGray; ;
                    }
                    //if (puan.durum == "Cumartesi" || puan.durum == "Pazar")
                    //{
                    //    rg.Interior.Color = Excel.XlRgbColor.rgbDimGray;
                    //    ((Excel.Range)worksheet.Cells[row-1, firstFind.Column]).Interior.Color =Excel.XlRgbColor.rgbDimGray; ;
                    //}
                }
                #endregion


                row--;
                col = gün2+1;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                col++;
                rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row, ColumnIndexToColumnLetter(col) + (row + 1));
                rg.Merge();
                rg.Value2 = "";
                rg.Font.Size = 11;
                rg.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rg.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //col++;





                //var index = firstFind.Column;



                //row--;
                row +=2;
                sıra++;

            }

          
            #region GRİD ÇİZ
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(left) + 5, ColumnIndexToColumnLetter(right) + (row - 1));
            rg.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            rg.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            rg.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            rg.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            rg.Borders.Color = Color.Black; 
            #endregion


        }
        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }
    }
}
