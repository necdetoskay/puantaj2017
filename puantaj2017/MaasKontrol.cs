using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using puantaj2017.DAL;

namespace puantaj2017
{
    public partial class MaasKontrol : Form
    {
        private MikroDB_V15_KENTEntities db=new MikroDB_V15_KENTEntities();
        private ikEntities ik=new ikEntities();
        public MaasKontrol()
        {
            InitializeComponent();
        }

        private void MaasKontrol_Load(object sender, EventArgs e)
        {
            nUDYil.Value = DateTime.Now.Year;
            nUDAy.Value = DateTime.Now.Month;
        }

        private void button1_Click(object sender, EventArgs e)//mikro tahakkuk yükle
        {
            var query = db.PERSONELLERs.Join(db.PERSONEL_TAHAKKUKLARI,
                pers => pers.per_kod,
                tah => tah.pt_pkod, (pers, tah) => new MaasKontrolVM
                {
                    ad = pers.per_adi,
                    soyad = pers.per_soyadi,
                    kod= pers.per_kod,
                    yil=tah.pt_maliyil.Value,
                    ay=tah.pt_tah_ay.Value,icra =tah.pt_ozksnt3.Value,
                    bes=tah.pt_otobes_tutari.Value,
                    devkümülatifgv= tah.pt_devgvmatrah.Value,odenen = tah.pt_net.Value,
                    net= tah.pt_net.Value,
                    avans = tah.pt_ozksnt5.Value,
                    brütücret = tah.pt_brutucret.Value,
                    brütyemek = tah.pt_sosyrdm8.Value,
                    agi = tah.pt_asgarigecimindirimi.Value
                }).Where(c=>c.yil==nUDYil.Value & c.ay==nUDAy.Value-1);


            //var liste=db.PERSONEL_TAHAKKUKLARI.Where(c => c.pt_maliyil == nUDYil.Value & c.pt_tah_ay == nUDAy.Value).Select(c=> new MaasKontrolVM
            //{
            //    icra = c.pt_ozksnt.Value,
            //    bes=c.pt_otobes_tutari.Value,
            //    kümülatifgv = c.pt_devgvmatrah.Value,
            //    net=c.pt_net.Value,
            //    kod = c.pt_pkod,
            //    avans = c.pt_ozksnt5.Value

            //}).ToList();
            maasKontrolVMBindingSource.DataSource = query.ToList();
        }

        public decimal NetMaas(int maliyil = 2018,
            decimal brütmaaş = 4307.32m,
            decimal brütyemek = 350.0m,
            decimal kümülatifgvm = 0.0m,
            decimal agi = 152.21m, decimal yemekistisna = 4.05m)
        {var dilim = ik.vergi_dilim.FirstOrDefault(c => c.yil == maliyil).vergi_dilim_detay.ToList();

            var yemekistisnatutar = yemekistisna * 22;
            var sgkmatrah = brütmaaş + brütyemek - yemekistisnatutar;
            var sgkprim = Math.Round(sgkmatrah * 0.14m, 2);
            var işsizlikprim = Math.Round(sgkmatrah * 0.01m, 2);
            var damga = Math.Round((brütmaaş + brütyemek) * 0.00759m, 2);var gelirvergimatrah = brütmaaş + brütyemek - sgkprim - işsizlikprim;
            var kümülatif = kümülatifgvm + gelirvergimatrah;
            var gelirvergisi = 0m;

            for (int i = 0; i < dilim.Count; i++)
            {
                if (kümülatifgvm > dilim[i].ust){
                    }
                else
                {
                    if (kümülatif > dilim[i].ust)
                    {
                        var üst = ((kümülatif - dilim[i].ust) * dilim[i + 1].oran) / 100;
                        var alt = ((dilim[i].ust - kümülatifgvm) * dilim[i].oran) / 100;
                        gelirvergisi = alt + üst;
                        gelirvergisi = Math.Round(gelirvergisi, 2);
                        break;
                        //iki dilim
                    }
                    else
                    {
                        //tek dilim
                        gelirvergisi += (gelirvergimatrah * dilim[i].oran) / 100;

                        gelirvergisi = Math.Round(gelirvergisi, 2);
                        break;
                    }
                }
            }
            //gelirvergisi hesapla
            gelirvergisi -= agi;

            var net = brütmaaş + brütyemek - sgkprim - gelirvergisi - damga - işsizlikprim;


            return net;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl1.FocusedView as GridView;
            var rows = gridView.DataController.GetAllFilteredAndSortedRows().Cast<MaasKontrolVM>();
            using (var db = new MikroDB_V15_KENTEntities())
            {
                foreach (var row in rows)
                {
                    try
                    {
                        row.hesaplanan = (double)NetMaas((int)nUDYil.Value, (decimal)row.brütücret, (decimal)row.brütyemek, (decimal)row.devkümülatifgv,(decimal)row.agi,4.05m);
                    }
                    catch (Exception x)
                    {

                    }
                }
            }
            gridControl1.RefreshDataSource();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }

    public class MaasKontrolVM
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public int yil { get; set; }
        public int ay { get; set; }
        public double bes { get; set; }
        public double avans { get; set; }
        public double devkümülatifgv { get; set; }
        public double net { get; set; }
        public double odenen { get; set; }
        public string kod { get; set; }
        public double icra { get; set; }
        public double hesaplanan { get; set; }
        public double mikronet { get; set; }
        public double brütücret { get; set; }
        public double brütyemek { get; set; }
        public double agi { get; set; }
        public override string ToString()
        {
            return ad + ' ' + soyad;
        }
    }
}
