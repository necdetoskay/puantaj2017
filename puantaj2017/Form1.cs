using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Outlook;

using puantaj2017.DAL;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Exception = System.Exception;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;


namespace puantaj2017
{
    public partial class Form1 : Form
    {


        private List<Hareket> hareketler = new List<Hareket>();
        private puantajDataSet ds = new puantajDataSet();
        private readonly ikEntities ik = new ikEntities();
        private readonly object misValue = Missing.Value;
        private Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        private Workbook xlWorkBook;

        public Form1()
        {

            //try
            //{
            //    using (SmtpClient client = new SmtpClient("owa.kentkonut.com.tr", 25))
            //    {
            //        using (MailMessage message = new MailMessage()
            //        {
            //            From = new MailAddress("noskay@kentkonut.com.tr")})
            //        {

            //            message.To.Add("noskay@kentkonut.com.tr");
            //            client.Credentials = new System.Net.NetworkCredential("noskay", "25951697");
            //            client.EnableSsl = true;
            //            client.Send(message);
            //        }
            //    }
            //}
            //catch (Exception exxxx)
            //{

            //    throw;
            //}

            //MailItem mail = null;
            //Recipients mailRecipients = null;
            //Recipient mailRecipient = null;
            //Application app = new Microsoft.Office.Interop.Outlook.Application();try
            //{
            //    mail = app.CreateItem(OlItemType.olMailItem)
            //        as MailItem;
            //    mail.Subject = "A programatically generated e-mail";
            //    mailRecipients = mail.Recipients;mailRecipient = mailRecipients.Add("noskay@kentkonut.com.tr");
            //    mail.To = "noskay@kentkonut.com.tr";
            //    mailRecipient.Resolve();
            //    if (mailRecipient.Resolved){
            //        mail.Send();}
            //    else
            //    {
            //        System.Windows.Forms.MessageBox.Show(
            //            "There is no such record in your address book.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message,
            //         "An exception is occured in the code of add-in.");
            //}
            //finally
            //{
            //    if (mailRecipient != null) Marshal.ReleaseComObject(mailRecipient);
            //    if (mailRecipients != null) Marshal.ReleaseComObject(mailRecipients);
            //    if (mail != null) Marshal.ReleaseComObject(mail);
            //}



#if DEBUG
            //var perkotek = new PtakipDAL.PerkotekContext();
            //perkotek.PuantajHazirla(new DateTime(2017, 03, 01), new DateTime(2017, 03, 31));


            //foreach (var personel in perkotek.personel)
            //{
            //    for (var tarih = new DateTime(2017, 03, 01); tarih <= new DateTime(2017, 03, 31); tarih = tarih.AddDays(1))
            //    {
            //        Console.WriteLine(string.Format("{0},{1},{2}", tarih.ToShortDateString(), personel.AdSoyad, perkotek.Puantaj(personel.ID, tarih)));
            //    }
            //}

#endif

            var wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            if (wp.Identity.Name != "KENTKONUT\\noskay")
                return;
            InitializeComponent();
            xlWorkBook = excel.Workbooks.Add(misValue);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateBaslangic.Value = DateTime.Now;
            dateBitis.Value = DateTime.Now;
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
                        "select id,concat(adi,' ',soyadi) as  adsoyad from personel_kartlari where sirket_kod=8 OR sirket_kod=9";
                    var adapter = new MySqlDataAdapter(com);
                    adapter.Fill(ds.Personel);

                    #endregion

                    #region personel giriş saatlerini yükle

                    com.CommandText =
                        string.Format(
                            "select personel_id as personelid,tarih,giris_saat,cikis_saat, week(tarih,1) as hafta from personel_giriscikis where tarih >= '{0}' and   tarih<= '{1}'",
                            dateBaslangic.Value.ToString("yyyy-MM-dd"), dateBitis.Value.ToString("yyyy-MM-dd"));
                    adapter.Fill(ds.PersonelGirisCikis);

                    #endregion

                    #region personel izinlerini yükle

                    com.CommandText =
                        string.Format(
                            "select id as ID, personel_id as personelid,tatil_id as izintip,tarih,gidis_saat,gelis_saat,saatlik,aciklama from personel_izin where tarih between '{0}' and '{1}'",
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
            ds = new puantajDataSet();



            perkotekyukle();
            //test();
            try
            {
                personelListBox.DataSource = ds.Personel.OrderBy(c => c.adsoyad).ToList();
            }
            catch (Exception px)
            {


            }
        }

        private void personelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var personel = (puantajDataSet.PersonelRow)personelListBox.SelectedItem;
            dataGridView1.DataSource = ds.PersonelGirisCikis.Where(c => c.personelid == personel.id).ToList();
            dataGridView2.DataSource = ds.PersonelIzin.Where(c => c.personelid == personel.id).ToList();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //seçili personel puantaj oluştur
        //    var personel = (puantajDataSet.PersonelRow)personelListBox.SelectedItem;
        //    MesaiHesapla(personel);

        //    PuantajGetir(personel);
        //}

        //private void MesaiHesapla(puantajDataSet.PersonelRow personel)
        //{
        //}

        private IList<Puantaj> PuantajGetir(puantajDataSet.PersonelRow personel)
        {
            if (personel == null) return new List<Puantaj>();

            var liste = new List<Puantaj>();
            for (var tarih = dateBaslangic.Value; tarih <= dateBitis.Value; tarih = tarih.AddDays(1))
            {




                var izin = ds.PersonelIzin.FirstOrDefault(c => c.personelid == personel.id && c.tarih == tarih);
                var giris = ds.PersonelGirisCikis.FirstOrDefault(c => c.personelid == personel.id && c.tarih == tarih);
                if (giris == null) //giriş kaydı yok iziv veya rapor var
                {

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
                        else
                        {
                            liste.Add(new Puantaj
                            {
                                adsoyad = personel.adsoyad,
                                tarih = tarih,
                                puantaj = "??",
                                durum = tarih.ToString("dddd")
                            });
                            hareketler.Add(new Hareket { HareketTipi = "Eksik Hareket", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                        }
                    }
                    else
                    {
                        var puantaj = "";
                        switch (izin.izintip)
                        {
                            case 6: //yıllıkizin
                                puantaj = "Y.İ.";
                                hareketler.Add(new Hareket { HareketTipi = "Yıllıkİzin", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                            case 7: //rapor
                                puantaj = "R";
                                hareketler.Add(new Hareket { HareketTipi = "Rapor", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                            case 5: //idari tatil
                                puantaj = "X";
                                break;
                            case 8: //denkleştirme
                                puantaj = "D";
                                hareketler.Add(new Hareket { HareketTipi = "Denkleştirme", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                            case 3: //Ücretli İzin
                                puantaj = "Ü.İ";
                                hareketler.Add(new Hareket { HareketTipi = "Ücretliİzin", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                            default: //3-ücretsiz izin,
                                puantaj = "?";
                                hareketler.Add(new Hareket { HareketTipi = "EksikHareket", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
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
                {//giriş kaydı var fakat girip rapor almış olabilir
                    if (izin == null)
                    {
                        liste.Add(new Puantaj
                        {
                            adsoyad = personel.adsoyad,
                            tarih = giris.tarih,
                            puantaj = "X",
                            durum = giris.giris_saat.ToString()
                        });
                    }
                    else
                    {
                        var puantaj = "";
                        switch (izin.izintip)
                        {
                            case 6: //yıllıkizin
                                puantaj = "Y.İ.";
                                hareketler.Add(new Hareket { HareketTipi = "Yıllıkİzin", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                            case 7: //rapor
                                puantaj = "R";
                                hareketler.Add(new Hareket { HareketTipi = "Rapor", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                            case 5: //idari tatilpuantaj = "X";
                                break;
                            case 8: //denkleştirme
                                puantaj = "D";
                                hareketler.Add(new Hareket { HareketTipi = "Denkleştirme", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                            case 3: //Ücretli İzin
                                puantaj = "Ü.İ";
                                hareketler.Add(new Hareket { HareketTipi = "Ücretliİzin", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                break;
                                //default: //3-ücretsiz izin,
                                //    puantaj = "?";
                                //    hareketler.Add(new Hareket { HareketTipi = "EksikHareket", AdSoyad = personel.adsoyad, PersonelID = personel.id, Tarih = tarih });
                                //    break;
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
            }
            return liste;
        }

        private void button3_Click(object sender, EventArgs e)
        {


            foreach (var birim in ik.birims.Where(c => c.puantaj == true).OrderByDescending(c => c.id))
            {
                foreach (var personel in birim.Personels.Where(c => c.puantaj).OrderBy(c => c.sira))
                {
                    var liste = PuantajGetir(ds.Personel.SingleOrDefault(c => c.id == personel.pdksid));
                }

            }

            var form = new Hareketler();
            form.Tag = hareketler;
            form.ShowDialog();



            //dosyayı oluştur
            //sayfa ekle birim adı ile


            //var excel = new Application();
            //excel.Visible = true;
            //Workbook xlWorkBook;
            //Worksheet xlWorkSheet;


            //xlWorkBook = excel.Workbooks.Add(misValue);
            //foreach (var birim in ik.birims.OrderByDescending(c => c.id))
            //{
            //    var worksheet = xlWorkBook.Worksheets.Add();
            //    worksheet.Name = birim.birimad;
            //    tabloyuolustur(worksheet, birim); //tablo başlığını oluştur
            //                                      //personel verilerini ekle
            //                                      //tablo altlığını oluştur.

            //}
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

            for (var tarih = dateBaslangic.Value; tarih <= dateBitis.Value; tarih = tarih.AddDays(1))
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

                #endregion

                //burada puantaj kayıtları gir.
                var liste = PuantajGetir(ds.Personel.SingleOrDefault(c => c.id == personel.pdksid));

                var g1 = ColumnIndexToColumnLetter(gün1 - 1);
                var g2 = ColumnIndexToColumnLetter(gün2);
                var r = 5;
                Range firstFind;
                var tarihRange = worksheet.get_Range(g1 + r, g2 + r);

                #region GÜNLÜK PUANTAJLAR

                var çalışma = 0;
                var rapor = 0;
                var yıllıkizin = 0;

                foreach (var puan in liste)
                {
                    firstFind = tarihRange.Find(puan.tarih.Day, misValue, XlFindLookIn.xlValues, XlLookAt.xlPart,
                        XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false, misValue, misValue);

                    rg = (Range)worksheet.Cells[row, firstFind.Column];
                    rg.Value2 = puan.puantaj;
                    switch (puan.puantaj)
                    {
                        case "R":
                            rapor++;
                            break;
                        case "Y.İ.":
                            yıllıkizin++; çalışma++;
                            break;
                        case "??":
                            break;
                        default:
                            {

                                çalışma++;
                                break;
                            }
                    }

                    rg.Font.Size = 11;
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                    if (puan.tarih.DayOfWeek == DayOfWeek.Saturday || puan.tarih.DayOfWeek == DayOfWeek.Sunday)
                    {
                        rg.Interior.Color = XlRgbColor.rgbDimGray;
                        ((Range)worksheet.Cells[row - 1, firstFind.Column]).Interior.Color = XlRgbColor.rgbDimGray;
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
            rg.Value2 = string.Format("AY:  {0}", dateBitis.Value.ToString("MMMM"));
            rg.Font.Bold = true;
            rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

            col += 5;
            rg = worksheet.get_Range(ColumnIndexToColumnLetter(col) + row,
               ColumnIndexToColumnLetter(right) + (row));
            rg.Merge();
            rg.Value2 = birim.fullad.ToUpper();
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

        private static string ColumnIndexToColumnLetter(int colIndex){
            var div = colIndex;
            var colLetter = string.Empty;
            var mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (div - mod) / 26;}
            return colLetter;}
        private void mesaiHesaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Mesailer { Tag = ds };
            form.ShowDialog();
        }

        private void eBorçSorgulamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EBorcSorgulama form = new EBorcSorgulama();
            form.ShowDialog();
        }

        private void izinVeRaporDurumuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new IzinRapor() { Tag = new { DSet = ds, tarih1 = dateBaslangic.Value, tarih2 = dateBitis.Value }, excel = excel, workbook = xlWorkBook };
            form.ShowDialog();
        }


        private void puantajExcelHazırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {//excel = new Application();
            excel.Visible = true;

            Worksheet xlWorkSheet;


            // xlWorkBook = excel.Workbooks.Add(misValue);
            foreach (var birim in ik.birims.Where(c => c.puantaj == true).OrderByDescending(c => c.id))
            {
                var worksheet = xlWorkBook.Worksheets.Add();
                worksheet.Name = birim.birimad;
                tabloyuolustur(worksheet, birim); //tablo başlığını oluştur
                                                  //personel verilerini ekle
                                                  //tablo altlığını oluştur.

            }
        }

        private void avanslarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var avans = new Avanslar { tarih1 = dateBaslangic.Value, tarih2 = dateBitis.Value, excel = excel, workbook = xlWorkBook };
            avans.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            xlWorkBook.Close();
            excel.Workbooks.Close();
            excel.Quit(); releaseObject(excel);
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

        private void puantajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var puanayar = new PuantajAyarlar();
            puanayar.ShowDialog();
        }

        private void geçKalanlarRaporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GecKalanlar();
            form.ShowDialog();
        }

        private void aileFertleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }private void puantajYeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PuantajForm();
            form.ShowDialog();//yeni formu çağır

        }

        private void personelRaporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new PTakip();
            f.ShowDialog();
        }

        private void raporTaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RaporTara();
            form.ShowDialog();
        }

        private void borcuYokturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new BorcuYoktur();
            form.ShowDialog();}

        private void hazineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Hazine();
            form.ShowDialog();

        }private void kalanİzinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new KalanIzin().ShowDialog();
        }

        private void dosyaTarihİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DosyaTarih().ShowDialog();
        }

        private void bESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BES().ShowDialog();
        }

        private void bordroBankaKarşılaştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BordroBanka().ShowDialog();
        }

        private void maaşKontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MaasKontrol().ShowDialog();
        }
    }
}