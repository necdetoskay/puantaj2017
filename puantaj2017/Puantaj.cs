using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using Microsoft.Office.Interop.Excel;
using puantaj2017.DAL;
using PtakipDAL;

namespace puantaj2017
{
    public partial class PuantajForm : Form
    {
        private PerkotekContext per = new PerkotekContext();
        private readonly object misValue = Missing.Value;
        public PuantajForm()
        {
            InitializeComponent();
            gridView1.RowCellStyle += GridView1_RowCellStyle;
            gridView1.MasterRowExpanded += GridView1_MasterRowExpanded;
        }
        private void GridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            //GridView view = sender as GridView;
            //GridView detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            //detailView.Columns[1].DisplayFormat.FormatString = "hh\\:mm";
            //detailView.Columns[2].DisplayFormat.FormatString = "hh\\:mm";
        }

        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "Giris" || e.Column.FieldName == "Cikis")
            {

                e.Column.DisplayFormat.FormatString = "hh:mm";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            var start = dateTimePicker1.Value;
            var end = dateTimePicker2.Value;
            per.PuantajHazirla(start, end, true);

            var ik = new ikEntities();

            gridControl1.BeginUpdate();
            gridView1.Columns.Clear();
            try
            {

                var liste = (from p in per.personel
                             join ikp in ik.Personels on p.ID equals ikp.pdksid
                             where ikp.puantaj & ikp.puantaj
                             select new
                             {
                                 SicilNo = ikp.sicilno,
                                 BirimID = ikp.birimid,
                                 BirimAd = ikp.birim.birimad,
                                 AdSoyad = p.AdSoyad,
                                 Tarihler = p.PTarihs,
                                 ID = p.ID
                             }).ToList();
                gridControl1.DataSource = liste;

            }
            catch (Exception x)
            {

            }
            gridControl1.EndUpdate();
            splashScreenManager1.CloseWaitForm();
        }
        private void Puantaj_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Excel Dosyası Hazırlansın mı", "Puantaj Hazırla", MessageBoxButtons.YesNo) !=
                DialogResult.Yes) return;

            var excel = new PExcel(per);
            excel.AylikPuantaj(dateTimePicker1.Value, dateTimePicker2.Value);
        }


        private void birimlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Birimler();
            form.ShowDialog();
        }
        private void avanslarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liste = new ptakipBL().Avanslar(dateTimePicker1.Value, dateTimePicker2.Value);
            var form = new Rapor(liste);
            form.ShowDialog();
            return;
            gridControl1.BeginUpdate();
            gridView1.Columns.Clear();

            gridControl1.DataSource = liste;

            gridControl1.EndUpdate();
        }

        private void yıllıkİzinlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liste = new ptakipBL().Yillikİzinler(per, dateTimePicker1.Value, dateTimePicker2.Value);

            var form = new Rapor(liste);
            form.Text = "Yıllık İzinler";
            form.ShowDialog();
           
        }

        private void raporlarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var liste = new ptakipBL().Raporlar(per, dateTimePicker1.Value, dateTimePicker2.Value);

            var form = new Rapor(liste);
            form.Text = "İstirahat ve Raporlar";
            form.ShowDialog();
        }

        private void denkleştirmelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liste = new ptakipBL().Denklestirmeler(per, dateTimePicker1.Value, dateTimePicker2.Value);

            var form = new Rapor(liste);
            form.Text = "Denkleştirmeler";
            form.ShowDialog();
        }

        private void mazeretlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liste = new ptakipBL().Mazeretler(per, dateTimePicker1.Value, dateTimePicker2.Value);

            var form = new Rapor(liste);
            form.Text = "Mazeret İzinleri";
            form.ShowDialog();
        }
        private void pdksRaporİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oo = new ptakipBL();
            oo.RaporTara();
        }

        private void girişÇıkışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liste = new ptakipBL().GirisCikislar(per, dateTimePicker1.Value, dateTimePicker2.Value);
            var form = new Rapor(liste);
            form.Text = "Personel Giriş Çıkışları";
            form.ShowDialog();
        }

        private void geçKalanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liste = new ptakipBL().GecKalanlar(per, dateTimePicker1.Value, dateTimePicker2.Value);
            var form = new Rapor(liste);
            form.Text = "Geç Kalanlar";
            form.ShowDialog();
        }
    }
}
