﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.EditForm.Helpers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using puantaj2017.DAL;

namespace puantaj2017
{



    public partial class KalanIzin : Form
    {
        private List<Pers> personel;
        public KalanIzin()
        {


            using (var db = new ikEntities())
            {
                personel = db.Personels.Select(c => new Pers { tc = c.tcno, birim = c.birim.birimad }).ToList();
            }
            InitializeComponent();
            gridView1.CustomUnboundColumnData += GridView1_CustomUnboundColumnData;
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a ExcelDataSource
            excelDataSource1.Fill();
        }

        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {

        }
        private void birimleriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int rowIndex = e.ListSourceRowIndex;
            //var haftaningunu = Convert.ToDateTime(view.GetListSourceRowCellValue(rowIndex, "Tarih"));
            gridView1.Columns["Birim"].GroupIndex = 0;
        }
        private void GridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            try{

                GridView view = sender as GridView;

                if (e.Column.FieldName == "Birim")
                {
                    var tc = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Sicil No");
                    var p = personel.FirstOrDefault(c => c.tc == tc.ToString());
                    e.Value = p.birim.Replace("2", "1");}



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

        private void mailGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {


            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows();

            List<GridColumn> groupedColumnsList = new List<GridColumn>();
            foreach (GridColumn groupedColumn in gridView.GroupedColumns)
            {
                groupedColumnsList.Add(groupedColumn);
            }
            StringBuilder table = new StringBuilder();


            for (int rowHandle = -1; gridView.IsValidRowHandle(rowHandle); rowHandle--)
            {
                string birimadi = gridView.GetGroupRowDisplayText(rowHandle);

                if (
                    MessageBox.Show(birimadi + "Birimi izinleri mail atılsın mı?", "",
                        MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                //MessageBox.Show(gridView.GetGroupRowDisplayText(rowHandle) + "\r\n");
                if (gridView.GetChildRowHandle(rowHandle, 0) > -1)
                {
                    table.Append(
                    "<table style='border:1px solid black; width:100%; border-collapse:collapse'><thead><tr><td><strong>" +
                    "Personel Adı<strong></td><td   style='border:1px solid black;border-collapse:collapse'><strong>" +
                    " Kalan İzin Günü<strong></td></tr></thead><tbody>");

                    for (int childRowHandle = 0; childRowHandle < gridView.GetChildRowCount(rowHandle); childRowHandle++)
                    {

                        // MessageBox.Show(String.Format("{0} ", gridView.GetRowCellDisplayText(gridView.GetChildRowHandle(rowHandle, childRowHandle), gridView.Columns[1])));

                        //foreach (var p in grp.GroupBy(d => d.ID))
                        //{//    var personeltoplam = p.Sum(d => d.Fark);
                        table.Append(
                            "<tr style='border:1px solid black;border-collapse:collapse margin-left:20px;'><td  style='border:1px solid black;border-collapse:collapse'><span style='width:20px;display: inline-table;'></span><strong>     " +
                            gridView.GetRowCellDisplayText(gridView.GetChildRowHandle(rowHandle, childRowHandle),
                                gridView.Columns[1]) +
                            "</strong></td><td  style='border:1px solid black;border-collapse:collapse'><strong>" +
                            gridView.GetRowCellDisplayText(gridView.GetChildRowHandle(rowHandle, childRowHandle),
                                gridView.Columns[8]) + " Gün.</strong></td></tr>");
                        //}
                    }
                    table.Append("</tbody></table>");

                    MailGonder.Gonder("noskay@kentkonut.com.tr",
                        new[] { "noskay@kentkonut.com.tr", "derya.aslan@kentkonut.com.tr" }, birimadi.ToUpper()+" Kalan İzinler", table.ToString());
                    table.Clear();}
            }



        }
    }
    public class Pers
    {
        public string tc { get; set; }
        public string birim { get; set; }
    }
}