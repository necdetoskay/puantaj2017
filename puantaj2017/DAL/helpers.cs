using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace puantaj2017.DAL
{
    public static class MailGonder
    {
        public static void Gonder(string gonderen, string[] alıcı, string konu, string body)
        {
            try
            {using (SmtpClient client = new SmtpClient("owa.kentkonut.com.tr", 25))
                {client.Credentials = new System.Net.NetworkCredential("noskay", "0renegade*");
                    //client.EnableSsl = true;
                    using (MailMessage message = new MailMessage()
                    {
                        From = new MailAddress(gonderen)
                    })
                    {
                        message.Subject = konu;
                        message.IsBodyHtml = true;
                        message.Body = body;

                        foreach (var s in alıcı) { message.To.Add(s); }
                        client.Send(message);
                    }
                }
            }
            catch (Exception exxxx)
            {

                throw;
            }
        }
    }

    public class Hareketler 
    {
        public List<Hareket> Denkleştirme { get; set; }
        public List<Hareket> Ücretliİzin { get; set; }
        public List<Hareket> Rapor { get; set; }
        public List<Hareket> Yıllıkİzin { get; set; }
        public List<Hareket> EksikHareket { get; set; }

        public Hareketler()
        {
            Denkleştirme=new List<Hareket>();
            Ücretliİzin = new List<Hareket>();
            Rapor = new List<Hareket>();
            Yıllıkİzin = new List<Hareket>();
            EksikHareket = new List<Hareket>();

        }

    }

    public class Hareket
    {
        public int PersonelID { get; set; }
        public string AdSoyad { get; set; }
        public DateTime Tarih { get; set; }
        public string HareketTipi { get; set; }
    }

    public class PuantajTakip
    {
        public int ID { get; set; }
        public string Departman { get; set; }
        public string AdSoyad { get; set; }
        public DateTime Tarih { get; set; }

        public List<TimeSpan> Hareketler { get; set; }
        public PuantajTakip()
        {
            Hareketler = new List<TimeSpan>();
        }

        public int Fark { get; set; }

        public TimeSpan Giris { get; set; }
        public TimeSpan Cikis { get; set; }

        public object MazeretAciklama { get; set; }
        public object MazeretGidisSaat { get; set; }
        public object MazeretGelisSaat { get; set; }
        }
    public class GecKalanlarVM
    {
        public int PersonelId { get; set; }
        public string Departman { get; set; }
        public string AdSoyad { get; set; }
        public object Giris { get; set; }
        public object Saat { get; set; }
        public int Fark { get; set; }
        public object MazeretAciklama { get; set; }
        public object MazeretGidisSaat { get; set; }
        public object MazeretGelisSaat { get; set; }
    }

    public class puantajrapor
    {
        public int ID { get; set; }
        public string adsoyad { get; set; }
        public DateTime baslangic { get; set; }
        public DateTime bitis { get; set; }
        public int gun { get; set; }
        public string aciklama { get; set; }
    }

    public class puantajizin
    {
        public int ID { get; set; }
        public string adsoyad { get; set; }
        public DateTime baslangic { get; set; }
        public DateTime bitis { get; set; }
        public string aciklama { get; set; }
    }


    public class AvanslarVM
    {
        public string AdSoyad { get; set; }
        public string PersoneKod { get; set; }
        public int Tutar { get; set; }
        public DateTime Tarih { get; set; }
    }
    public class Puantaj
    {
        public string adsoyad { get; set; }
        public DateTime tarih { get; set; }
        public string puantaj { get; set; }
        public string durum { get; set; }
    }

    public class SirketCBItem
    {
        public string ŞirketAdı { get; set; }
        public string YeniŞubeKod { get; set; }
        public string EskiŞubeKod { get; set; }
        public string SıraNo { get; set; }
        public string İlKodu { get; set; }
        public string AracıNumarası { get; set; }
        public override string ToString()
        {
            return ŞirketAdı.ToString();
        }
    }

    public class IzinGrid
    {
        public int ID { get; set; }
        public string adsoyad { get; set; }
        public DateTime tarih { get; set; }
        public int izintip { get; set; }
        public string aciklama { get; set; }
    }


    public class PersonelMesaiData{
        public int Hafta { get; set; }
        public int PersonelID { get; set; }
        public string PersonelAdSoyad { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan GirisSaat { get; set; }
        public string CikisSaat { get; set; }
      
        public bool Yemek { get; set; }
        public bool Hesapla { get; set; }
        public int ToplamDakika { get; set; }
        public bool Tatil { get; set; }
    }



    public static class ExtensionsClasses
    {

        // Export DataTable into an excel file with field names in the header line
        // - Save excel file without ever making it visible if filepath is given
        // - Don't save excel file, just make it visible if no filepath is given
        public static void ExportToExcel(this DataTable tbl, string excelFilePath = null)
        {
            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }






}