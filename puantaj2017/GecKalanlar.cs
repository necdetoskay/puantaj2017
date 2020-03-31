using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Export.Web;
using DevExpress.XtraPrinting.Native;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Outlook;
using MySql.Data.MySqlClient;
using puantaj2017.DAL;
using Application = Microsoft.Office.Interop.Outlook.Application;
using Exception = System.Exception;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace puantaj2017
{
    public partial class GecKalanlar : Form
    {
        private readonly object misValue = Missing.Value;
        private DateTime baslangic;
        private DateTime bitis;
        public GecKalanlar()
        {
            InitializeComponent();
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = true;

            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;
        }

        private void GridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                view.DeleteSelectedRows();
                e.Handled = true;
            }

        }


        private void GecKalanlar_Load(object sender, EventArgs e)
        {
            // var l = GecKalanlarYukle();
        }

        private List<PuantajTakip> GecKalanlarYukle()
        {
            var liste = new List<PuantajTakip>();
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
                    com.CommandText = string.Format(
                        "SELECT kodlar_departman.aciklama as Departman, personel_kartlari.id,concat(personel_kartlari.adi, ' ', personel_kartlari.soyadi) as adsoyad," +
                        "personel_giriscikis.tarih, personel_giriscikis.giris_saat,personel_giriscikis.cikis_saat,CEIL((TIME_TO_SEC(personel_giriscikis.giris_saat) - TIME_TO_SEC('08:30'))/60) as fark,pi1.aciklama,pi1.gidis_saat,pi1.gelis_saat " +
                        "FROM personel_giriscikis left join personel_izin pi1 on pi1.personel_id = personel_giriscikis.personel_id and pi1.tarih = personel_giriscikis.tarih " +
                        "INNER JOIN personel_kartlari ON personel_giriscikis.personel_id = personel_kartlari.id " +
                        "INNER JOIN kodlar_departman on personel_kartlari.departman_kod=kodlar_departman.kod " +
                        "where(personel_giriscikis.tarih BETWEEN '{0}' and '{1}') and personel_kartlari.sirket_kod = 8 " +
                        // "and giris_saat > cast('08:35:00' as time) and giris_saat < cast('12:00:00' as time) " +
                        "and DAYOFWEEK(personel_giriscikis.tarih) != 7  and DAYOFWEEK(personel_giriscikis.tarih) != 1 ORDER BY adsoyad ASC",
                        baslangic.ToString("yyyy-MM-dd"), bitis.ToString("yyyy-MM-dd"));
                    //new DateTime(2017,08,01).ToString("yyyy-MM-dd"), new DateTime(2017, 10, 11).ToString("yyyy-MM-dd"));

                    #endregion
                    var reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        TimeSpan ts;
                        var id = int.Parse(reader["id"].ToString());
                        var departman = reader["Departman"].ToString();
                        var adsoyad = reader["adsoyad"].ToString();
                        var tarih = DateTime.Parse(reader["tarih"].ToString());
                        var giris = reader["giris_saat"];
                        var cikis = reader["cikis_saat"];
                        var mazeretAciklama = reader["aciklama"];
                        var mazeretGidisSaat = reader["gidis_saat"];
                        var mazeretGelisSaat = reader["gelis_saat"];
                        var fark = reader["fark"];
                        var pers = liste.FirstOrDefault(c => c.AdSoyad == adsoyad & c.Tarih == tarih);
                        if (pers == null)
                        {
                            pers = new PuantajTakip
                            {
                                ID = id,
                                Departman = departman,
                                AdSoyad = adsoyad,
                                Tarih = tarih,
                                MazeretAciklama = mazeretAciklama,
                                MazeretGelisSaat = mazeretGelisSaat,
                                MazeretGidisSaat = mazeretGidisSaat
                            };
                            try
                            {
                                if (giris != DBNull.Value)
                                    pers.Hareketler.Add((TimeSpan)giris);
                                else
                                {

                                }
                                if (cikis != DBNull.Value)
                                    pers.Hareketler.Add((TimeSpan)cikis);
                                else
                                {

                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            liste.Add(pers);
                        }
                        else
                        {
                            if (giris != DBNull.Value)
                                pers.Hareketler.Add((TimeSpan)giris);
                            else
                            {

                            }
                            if (cikis != DBNull.Value)
                                pers.Hareketler.Add((TimeSpan)cikis);
                            else
                            {

                            }
                        }
                        //adı çek listede varsa kaydı çek, saat bilgisini ekle
                        //listede yoksa yeni oluştur, bilgileri ekle 
                        //liste.Add(new GecKalanlarVM
                        //{
                        //    Departman = reader["Departman"].ToString(),
                        //    AdSoyad = reader["adsoyad"].ToString(),
                        //    Giris = reader["tarih"],
                        //    Saat=reader["giris_saat"],
                        //    Fark = int.Parse(reader["fark"].ToString()),
                        //    MazeretAciklama = reader["aciklama"],
                        //    MazeretGidisSaat = reader["gidis_saat"],
                        //    MazeretGelisSaat = reader["gelis_saat"]
                        //});


                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }

                foreach (var takip in liste)
                {
                    var girisler = takip.Hareketler.OrderBy(c => c.Hours).ThenBy(c => c.Minutes);
                    var first = girisler.FirstOrDefault();
                    var last = girisler.LastOrDefault();
                    var fark = (int)first.Subtract(new TimeSpan(8, 30, 0)).TotalMinutes;
                    takip.Giris = first;
                    takip.Fark = fark > 0 ? fark : 0;
                    if (first != last)
                        takip.Cikis = girisler.LastOrDefault();
                }

                return liste;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            puantajTakipBindingSource1.DataSource = GecKalanlarYukle();
        }

        private void excelGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.ExportToXlsx(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\geçkalanlar.xlsx",
                new XlsxExportOptionsEx { });
            return;


            //GridView gridView = gridControl1.FocusedView as GridView;
            //var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<PuantajTakip>();

            //var excel = new Application(); excel.Visible = true;

            //Workbook xlWorkBook;
            //xlWorkBook = excel.Workbooks.Add(misValue);
            //Worksheet worksheet = xlWorkBook.Worksheets.Add();
        }



        private void geçKalanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridView1.Columns["Departman"].GroupIndex = 0;
            gridView1.Columns["AdSoyad"].GroupIndex = 1;
            gridView1.ActiveFilterString = "[Fark] > '5' and [MazeretGidisSaat] <> '08:30:00'";
        }

        private void çıkıştaKartBasmayanlarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gridView1.ClearGrouping();
            gridView1.ActiveFilterString =
                "[Cikis] = '00:00:00' and [MazeretGidisSaat] <> '00:00:00' and [MazeretGelisSaat] <> '00:00:00'";
        }private void monthEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ilk =  new DateTime(DateTime.Now.Year, monthEdit1.Month, 1);
            var son =new DateTime(DateTime.Now.Year, monthEdit1.Month + 1, 1).Subtract(new TimeSpan(1, 0, 0, 0));
            baslangic = ilk;
            bitis = son;}

        private void button2_Click(object sender, EventArgs e)
        {

            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<PuantajTakip>().ToList();
            using (var db = new ikEntities())
            {
                var pers =
                    db.Personels.Select(
                        c =>
                            new
                            {
                                ID = c.pdksid,
                                DepartmanID = c.birimid,
                                DepartmanAd = c.birim.birimad,
                                FullAd = c.birim.fullad
                            });
                for (int i = 0; i < rows.Count(); i++)
                {
                    int id = rows[i].ID;
                    var p = pers.FirstOrDefault(d => d.ID == id);
                    if (p == null)
                    {
                        Console.WriteLine(rows[i].AdSoyad + "\t\r");
                        continue;
                    }
                    rows[i].Departman = p.DepartmanID.ToString();
                }



               



                foreach (var grp in rows.GroupBy(c => c.Departman))
                {


                    int birimid = int.Parse(grp.Key);StringBuilder table = new StringBuilder();
                    var birimtoplam = grp.Sum(c => c.Fark);
                    var birim = pers.FirstOrDefault(c => c.DepartmanID == birimid);
                    table.Append(
                        "<table style='border:1px solid black; width:100%; border-collapse:collapse'><thead><tr><td><strong>" +
                        birim.FullAd + "<strong></td><td   style='border:1px solid black;border-collapse:collapse'><strong>" + birimtoplam +
                        " Dk.<strong></td></tr></thead><tbod>");
                    foreach (var p in grp.GroupBy(d => d.ID))
                    {
                        var personeltoplam = p.Sum(d => d.Fark);
                        table.Append(
                            "<tr style='border:1px solid black;border-collapse:collapse margin-left:20px;'><td  style='border:1px solid black;border-collapse:collapse'><span style='width:20px;display: inline-table;'></span><strong>     " +
                            p.FirstOrDefault().AdSoyad + "</strong></td><td  style='border:1px solid black;border-collapse:collapse'><strong>" +
                            personeltoplam + " Dk.</strong></td></tr>");
                        foreach (var puantajTakip in p.OrderBy(c => c.Tarih))
                        {
                            table.Append(
                                "<tr style='border:1px solid black;border-collapse:collapse margin-left:40px;'><td  style='border:1px solid black;border-collapse:collapse'><span style='width:40px;display: inline-table;'></span>" +
                                puantajTakip.Tarih.ToShortDateString() + " " + puantajTakip.Giris +
                                "</td><td style='border:1px solid black;border-collapse:collapse'>" + puantajTakip.Fark + " Dk.</td></tr>");
                        }
                    }
                    table.Append("</tbody></table>");

                    if(MessageBox.Show(birim.FullAd+" Mail Atılsın mı","Geç Kalanlar Mail", MessageBoxButtons.YesNo)!= DialogResult.Yes) continue;

                    MailGonder.Gonder("noskay@kentkonut.com.tr",
                        new[] {"noskay@kentkonut.com.tr","derya.aslan@kentkonut.com.tr"}, birim.FullAd+" 2018 "+monthEdit1.Text+" Geç Kalanlar", table.ToString());
                   }

                return;

                if (gridView1.GroupCount == 0)
                {return;
                    for (int rowHandle = 0; rowHandle < gridView1.RowCount; rowHandle++)
                    {
                        foreach (GridColumn gc in gridView1.Columns)
                            Console.WriteLine(String.Format("{0} ", gridView1.GetRowCellDisplayText(rowHandle, gc)));

                    }
                }
                else
                {



                    List<GridColumn> groupedColumnsList = new List<GridColumn>();
                    foreach (GridColumn groupedColumn in gridView1.GroupedColumns)
                        groupedColumnsList.Add(groupedColumn);

                    for (int rowHandle = -1; gridView1.IsValidRowHandle(rowHandle); rowHandle--)
                    {
                        // Console.WriteLine(gridView1.GetGroupRowDisplayText(rowHandle) + "\r\n");

                        if (gridView1.GetChildRowHandle(rowHandle, 0) > -1)

                            for (int childRowHandle = 0;
                                childRowHandle < gridView1.GetChildRowCount(rowHandle);
                                childRowHandle++)
                            {
                                var adsoyad =
                                    gridView1.GetRowCellDisplayText(
                                        gridView1.GetChildRowHandle(rowHandle, childRowHandle),
                                        gridView1.Columns["AdSoyad"]);
                                var tarih =
                                    gridView1.GetRowCellDisplayText(
                                        gridView1.GetChildRowHandle(rowHandle, childRowHandle),
                                        gridView1.Columns["Tarih"]);
                                var departman =
                                    gridView1.GetRowCellDisplayText(
                                        gridView1.GetChildRowHandle(rowHandle, childRowHandle),
                                        gridView1.Columns["Departman"]);
                                var giris =
                                    gridView1.GetRowCellDisplayText(
                                        gridView1.GetChildRowHandle(rowHandle, childRowHandle),
                                        gridView1.Columns["Giris"]);

                                var fark =
                                    gridView1.GetRowCellDisplayText(
                                        gridView1.GetChildRowHandle(rowHandle, childRowHandle),
                                        gridView1.Columns["Fark"]);


                                Console.WriteLine(string.Format("{0} {1} {2} {3} {4}", departman, adsoyad, tarih, giris,
                                    fark));

                            }
                    }
                }
            }
        }

    }

    
}


