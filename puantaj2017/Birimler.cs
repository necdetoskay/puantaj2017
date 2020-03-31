using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puantaj2017.DAL;


namespace PtakipDAL
{
    public partial class Birimler : Form
    {
        private ikEntities db = new ikEntities();
        public Birimler()
        {
            InitializeComponent();
        }

        private void Birimler_Load(object sender, EventArgs e)
        {
            var birims = db.birims.Select(c => new
            {
                ID = c.id,
                birimad = c.birimad,
                fullad = c.fullad,
                Puantaj = c.puantaj,
                Personels = c.Personels.Select(d => new
                {
                    id = d.id,adsoyad = d.adsoyad,
                    puantaj = d.puantaj
                }).ToList()}).ToList();
            var birim = db.birims.ToList();
            birim.ForEach(d=>d.Personels=d.Personels.ToList());

            birimBindingSource.DataSource = birim;
            gridControl1.BeginInit();


            gridControl1.DataSource = birimBindingSource;

            gridControl1.EndInit();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
           var a= (birim)birimBindingSource.Current;
            personelBindingSource.DataSource = a.Personels;
            gridControl2.DataSource =personelBindingSource;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.SaveChanges();}
    }
}
