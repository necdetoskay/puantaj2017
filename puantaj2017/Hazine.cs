using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace puantaj2017
{
    public partial class Hazine : Form
    {
        private DateTime empty = new DateTime(1899, 12, 31);
        private TimeSpan oneday = new TimeSpan(1, 0, 0, 0);
        private List<string> tahsil=new List<string>();

        public Hazine()
        {
            InitializeComponent();

            tahsil.AddRange(new[]{
                "Yok","İlk Okul",
                "Orta okul",
                "Lise",
                "Yüksek Okul",
                "Üniversite",
                "Yüksek Lisans"
            });
        }

        private void btnHazirla_Click(object sender, System.EventArgs e)
        {
            var yilbasi = new DateTime(int.Parse(comboBox1.SelectedItem.ToString()), 01, 01);
            var yilsonu = new DateTime(int.Parse(comboBox1.SelectedItem.ToString()), 12, 31);
            using (var db = new MikroDB_V15_KENTEntities())
            {
                var donembasi = db.PERSONELLERs.Where(c => c.per_giris_tar.Value <= yilsonu &&
                                                           (c.per_cikis_tar.Value > yilsonu ||
                                                            c.per_cikis_tar.Value == empty))
                    .Select(c => new HazinePersonel
                    {
                        AdSoyad = c.per_adi + " " + c.per_soyadi,
                        Giris = c.per_giris_tar.Value,
                        Cikis = c.per_cikis_tar.Value == empty ? null : c.per_cikis_tar,
                        Cinsiyet = c.per_nuf_cinsiyet == 0 ? "ERKEK" : "KADIN",
                        DogumTarihi=c.per_nuf_dogum_tarih.Value,
                        Tahsil = c.per_kim_tahsil,
                        Okul = c.per_okul_ad
                    }).ToList();

                gridControl1.DataSource = donembasi;
            }
        }
    }public class HazinePersonel
    {
        public string AdSoyad { get; set; }
        public DateTime Giris { get; set; }
        public DateTime? Cikis { get; set; }
        public string Cinsiyet { get; set; }
     

        public string Okul { get; set; }
        public byte? Tahsil { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}
