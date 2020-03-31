using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using PtakipDAL;

namespace puantaj2017
{
    public partial class PTakip : Form
    {
        public PTakip()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var per = new PerkotekContext();
            gridControl1.BeginUpdate();
            gridView1.Columns.Clear();
        
            switch (comboBox1.SelectedIndex)
            {
                case 0://geç kalanlar
                    var gec = per.GeçKalanlar(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, true);
                    bSPtakip.DataSource = gec.ToList();
                    gridControl1.DataSource = bSPtakip.DataSource;
                    gridControl1.Update();
                    break;
                case 1://Çıkışta Kart Basmayanlar
                    var ckb = per.CıkıstaKartBasmayanlar(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, true);
                    bSPtakip.DataSource = ckb.ToList();
                    gridControl1.DataSource = bSPtakip.DataSource;
                    gridControl1.Update();break;
                case 2:  //Giriş Yapmayanlar
                    var gy = per.GirisYapmayanlar(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, true);
                    bSPtakip.DataSource = gy.ToList();
                    gridControl1.DataSource = bSPtakip.DataSource;
                    break;
                case 3:   //İzinli Gelmeyenler
                    var ig = per.IzinliGelmeyenler(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, true);
                    bSPtakip.DataSource = ig.ToList();
                    gridControl1.DataSource = bSPtakip.DataSource;
                    break;
                case 4:
                    break;
            }
            gridControl1.EndUpdate();

        }

        private void PTakip_Load(object sender, EventArgs e)
        {

        }
    }
}
