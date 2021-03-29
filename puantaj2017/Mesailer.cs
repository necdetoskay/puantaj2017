using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Office.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout.Modes;
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
            // gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            gridView1.RowStyle += GridView1_RowStyle;
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            gridView1.CustomSummaryCalculate += GridView1_CustomSummaryCalculate;
           // gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
            
        }
        //class RowInfo {
        //    public RowInfo(GridView view, int rowHandle) {
        //        this.RowHandle = rowHandle;
        //        this.View = view;
        //    }
        //    public GridView View;
        //    public int RowHandle;
        //}
     
        private void Hesapla(PersonelMesaiData rw)
        {
            var saatkes = -300;
            var gmdak = 0;
            if (!rw.Hesapla) return;
               

            if (rw.MesaiSekli == MesaiSekli.Normal) // 9 saat düşülecek
            {
                rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes - (rw.Tatil ? 0 : 480) - (rw.Yemek ? 60 : 0);

                saatkes += rw.ToplamDakika;
                int saat = (int)(saatkes / 60);
                if (saat > 0)
                {
                    rw.fm1saat = saat;
                    rw.fm1dakika = saatkes % 60;
                    saatkes = rw.fm1dakika;
                }
            }
            else if (rw.MesaiSekli == MesaiSekli.ResmiTatil) //resmi tatilde sadece yemek düşülecek
            {
                rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes - (rw.Yemek ? 60 : 0);

            }
            else
            { //gece mesaisinde  7,5 saat haricinde tümü mexai olarak hesaplanacak

                rw.ToplamDakika = (int)(new TimeSpan(23, 59, 0).Subtract(rw.GirisSaat).TotalMinutes + TimeSpan.Parse(rw.CikisSaat).Subtract(new TimeSpan(0, 0, 0)).TotalMinutes - 450);
                gmdak += rw.ToplamDakika;
                int saat = (int)(gmdak / 60);
                if (saat > 0)
                {
                    rw.gmsaat = saat;
                    rw.gmdakika = gmdak % 60;
                    gmdak = gmdak % 60;
                }
            }

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
        //void GirisCikisDegistir(object sender, EventArgs e) {
        //    DXMenuCheckItem item = sender as DXMenuCheckItem;
        //    RowInfo info = item.Tag as RowInfo;
        //    var rw =(puantaj2017.DAL.PersonelMesaiData)this.gridView1.GetRow(info.RowHandle);
        //    var t = rw.GirisSaat;
        //    rw.GirisSaat = TimeSpan.Parse(rw.CikisSaat);
        //    rw.CikisSaat = t.ToString();
        //    Hesapla(rw);
        //    //yeniden hesapla

        //    //info.View.
        //    //info.View.OptionsView.AllowCellMerge = item.Checked;
        //}

        //DXMenuCheckItem CreateMenuItemCellMerging(GridView view, int rowHandle)
        //{
        //    DXMenuCheckItem checkItem = new DXMenuCheckItem("Giriş Çıkış Değiştir",
        //        view.OptionsView.AllowCellMerge, null, new EventHandler(GirisCikisDegistir));
        //    checkItem.Tag = new RowInfo(view, rowHandle);
        //    //checkItem.ImageOptions.Image = imageCollection1.Images[1];
        //    return checkItem;
        //}

        //private void GridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row) {
        //        int rowHandle = e.HitInfo.RowHandle;
        //        // Delete existing menu items, if any.
        //        //e.Menu.Items.Clear();
        //        // Add the Rows submenu with the 'Delete Row' command
              
        //        // Add the 'Cell Merging' check menu item.
        //        DXMenuItem item = CreateMenuItemCellMerging(view, rowHandle);
        //        item.BeginGroup = true;
        //        e.Menu.Items.Add(item);
        //    }
        //}

        private void GridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            e.TotalValue = e.FieldValue;
         
        }

        private void rowHesapla(CellValueChangedEventArgs e, PersonelMesaiData rw)
        {
            //yemek
            //hesapla
            //tatil
            //resmi tatil
            //gece mesai

            //çıkış-giriş

            switch (rw.MesaiSekli)
            {
                case MesaiSekli.Normal:

                    break;
                case MesaiSekli.ResmiTatil:
                    break;
                default://gece mesai
                    break;


            }
            if (e.Column.Caption == "Yemek")
            {
                if (rw.Yemek)
                {
                    //mesaiden 60 dk düş
                }
            }

        }

        private void GridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            PersonelMesaiData rw;
            rw = (PersonelMesaiData)view.GetRow(e.RowHandle);
            rowHesapla(e, rw);
        
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

        }

        private void GridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            PersonelMesaiData rw;
            rw = (PersonelMesaiData)view.GetRow(e.RowHandle);

            if (e.Column.Caption != "")
            {
                if (e.Column.Caption == "Hesapla")
                {

                }
                if (e.Column.Caption == "ResmiTatil")
                {
                    rw.FM2 = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes -
                                     (rw.Yemek ? 60 : 0);
                    rw.ToplamDakika = 0;

                    gridControl1.Update();
                    return;
                }
                if (e.Column.Caption == "GeceMesai")
                {
                    rw.ToplamDakika = new TimeSpan(23, 59, 0).Subtract(rw.GirisSaat).Minutes + TimeSpan.Parse(rw.CikisSaat).Subtract(new TimeSpan(0, 0, 0)).Minutes - 450;

                    return;
                }
                if (rw.Hesapla)
                {
                    rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes -
                                      (rw.Yemek ? 60 : 0) - (rw.Tatil ? 0 : 480);
                }
                else
                    rw.ToplamDakika = 0;
            }
            //view.ValidateEditor();
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
                if (e.Column.FieldName == "haftaningunu")
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




        }

        private int GetWeekNumber(DateTime tarih)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(tarih, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }


        private void HesaplaToolStripMenuItem_Click(object sender, EventArgs e)//hesapla
        {
            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<PersonelMesaiData>();

            if (!cBEksikHesap.Checked)
            {
                rows = rows.Where(c => c.Hesapla);
            }

            //foreach (var row in rows.Where(c => c.Hesapla).GroupBy(c => c.Hafta))
            var saatkes = -300;
            var gmdak = 0;
            foreach (var row in rows.GroupBy(c => c.Hafta))
            {
                saatkes = -300;
               // gmdak = 0;

                foreach (var rw in row)
                {
                    try
                    {

                        Hesapla(rw);
                        //if(!rw.Hesapla)
                        //    continue;

                        //if (rw.MesaiSekli == MesaiSekli.Normal) // 9 saat düşülecek
                        //{
                        //    rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes - (rw.Tatil?0: 480) - (rw.Yemek ? 60 : 0);

                        //    saatkes += rw.ToplamDakika;
                        //    int saat = (int)(saatkes / 60);
                        //    if (saat > 0)
                        //    {
                        //        rw.fm1saat = saat;
                        //        rw.fm1dakika = saatkes % 60;
                        //        saatkes = rw.fm1dakika;
                        //    }
                        //}
                        //else if (rw.MesaiSekli == MesaiSekli.ResmiTatil) //resmi tatilde sadece yemek düşülecek
                        //{
                        //    rw.ToplamDakika = (int)TimeSpan.Parse(rw.CikisSaat).Subtract(rw.GirisSaat).TotalMinutes - (rw.Yemek ? 60 : 0);
                           
                        //}
                        //else
                        //{ //gece mesaisinde  7,5 saat haricinde tümü mexai olarak hesaplanacak

                        //    rw.ToplamDakika = (int)(new TimeSpan(23, 59, 0).Subtract(rw.GirisSaat).TotalMinutes + TimeSpan.Parse(rw.CikisSaat).Subtract(new TimeSpan(0, 0, 0)).TotalMinutes - 450);
                        //    gmdak += rw.ToplamDakika;
                        //    int saat = (int) (gmdak / 60);
                        //    if(saat>0)
                        //    {
                        //        rw.gmsaat = saat;
                        //        rw.gmdakika = gmdak % 60;
                        //        gmdak = gmdak % 60;
                        //    }
                        //}

                        //if (!cBEksikHesap.Checked)
                        //{
                        //    if (rw.ToplamDakika < 0)
                        //    {
                        //        rw.Hesapla = false;
                        //        rw.ToplamDakika = 0;
                        //    }
                        //}
                        //else
                        //{
                        //    rw.Hesapla = true;
                        //}

                       



                    }
                    catch (Exception x1)
                    {


                    }
                }
            }

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
            var toplamfm2 = 0;



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
                if (rw.Any(c => c.FM2 > 0))
                {
                    rg = (Range)worksheet.Cells[row, col++];
                    rg.Value2 = "R.T. Toplam Dakika";
                    rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter; rg.Font.Bold = true;
                }




                col = 2;
                row++;
                var haftalikmesai = 0;
                var haftalikfm2 = 0;

                foreach (var r in rw)
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
                    if (r.FM2 > 0)
                    {
                        rg = (Range)worksheet.Cells[row, col++];
                        rg.Value2 = r.FM2;
                        rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    }


                    row++;
                    col = 2;
                    haftalikmesai += r.ToplamDakika;
                    haftalikfm2 += r.FM2;
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

                ////////////////////////////////////////////
                var mesai = haftalikmesai - 300;
                var haftaliksaat = (int)(mesai / 60);
                var haftalikdakika = (int)(mesai % 60);
                /////////////////////////////////

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
                toplamfm2 += haftalikfm2 > 0 ? haftalikfm2 : 0;
                /////////////////////////////////
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
            ////////////////////////

            if (toplamfm2 > 0)
            {
                row += 3;
                col = 2;



                rg = (Range)worksheet.Cells[row, col];
                rg.Value2 = "TOPLAM TATİL MESAİ";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rg = (Range)worksheet.Cells[row + 1, col];
                rg.Value2 = toplamfm2;
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


                col++;

                rg = (Range)worksheet.Cells[row, col];
                rg.Value2 = "TOPLAM TATİL SAAT";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rg = (Range)worksheet.Cells[row + 1, col];
                rg.Value2 = (int)(toplamfm2 / 60);
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;


                col++;
                rg = (Range)worksheet.Cells[row, col];
                rg.Value2 = "TOPLAM TATİL DAKİKA";
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rg = (Range)worksheet.Cells[row + 1, col];
                rg.Value2 = (int)(toplamfm2 % 60);
                rg.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                rg.Cells.VerticalAlignment = XlVAlign.xlVAlignCenter;
            }






            MesaiKaydet(rows, toplammesai, toplamfm2);
            //soru sor database e kaydet

        }

        private void MesaiKaydet(IEnumerable<PersonelMesaiData> rows, int toplammesai, int toplamfm2 = 0)
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
                    var fm2 = (int)(toplamfm2 / 60);
                    if (toplamfm2 % 60 >= 30)
                    {
                        fm2++;
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
                            mesai1 = mesai,
                            mesai2 = fm2
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
            HesaplaToolStripMenuItem_Click(null, null);
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var a = gridView1.CalcHitInfo(gridControl1.PointToClient(Cursor.Position));
            //var row=gridView1.GetRow(a.RowHandle);


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
                            Tatil = pgun.Tarih.DayOfWeek == DayOfWeek.Sunday | pgun.Tarih.DayOfWeek == DayOfWeek.Saturday,
                            MesaiSekli = pgun.Giris < TimeSpan.Parse(pgun.Cikis.ToString()) ? MesaiSekli.Normal : MesaiSekli.Gece

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
                liste.ForEach(c =>
                {
                    if (c.GirisSaat == TimeSpan.Parse(c.CikisSaat))
                    {
                        c.Hesapla = false;

                    }
                    else
                    {
                        if (c.MesaiSekli == MesaiSekli.Normal)
                        {
                            c.ToplamDakika = (int)TimeSpan.Parse(c.CikisSaat).Subtract(c.GirisSaat).TotalMinutes - (c.Yemek ? 60 : 0) - (c.Tatil ? 0 : 480);


                        }
                        else
                        {
                            c.ToplamDakika = (int)(new TimeSpan(23, 59, 0).Subtract(c.GirisSaat).TotalMinutes + TimeSpan.Parse(c.CikisSaat).Subtract(new TimeSpan(0, 0, 0)).TotalMinutes - 450);
                        }
                    }

                });

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
                return;
            }

            //splashScreenManager1.ShowWaitForm();
            MesaileriYukle();
            //splashScreenManager1.CloseWaitForm();
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridControl1.PrintDialog();
        }

        private void excelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            gridControl1.ExportToXlsx(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\test.xlsx");
        }
    }
}