using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PtakipDAL;

namespace puantaj2017.DAL
{
    public class ptakipBL
    {
        public object Avanslar(DateTime t1, DateTime t2)
        {
            using (var ik = new ikEntities())
            {
                var liste = ik.Avanslars.Where(c => c.tarih >= t1 & c.tarih <= t2).Select(c => new
                {
                    SicilNo = c.Personel.sicilno,
                    AdSoyad = c.Personel.adsoyad,
                    Tutar = c.tutar
                }).ToList();
                return liste;
            }
        }

        public object Denklestirmeler(PerkotekContext per, DateTime t1, DateTime t2)
        {
            var ik = new ikEntities();
            var liste = per.personel.ToList();
            var denk = new ArrayList();
            foreach (var personel in liste)
            {
                foreach (var pTarih in personel.PTarihs)
                {
                    foreach (var pIzin in pTarih.Izins.Where(c => c.Tip == 8))
                    {
                        denk.Add(new
                        {
                            SicilNo =
                                ik.Personels.FirstOrDefault(c => c.pdksid == personel.ID) == null
                                    ? ""
                                    : ik.Personels.FirstOrDefault(c => c.pdksid == personel.ID).sicilno,
                            AdSoyad = personel.AdSoyad,
                            DenkleştirmeTarihi = pTarih.Tarih,
                            YerineÇalışılanTarih = pIzin.Aciklama
                        });
                    }
                }
            }
            return denk;
        }

        public object Yillikİzinler(PerkotekContext per, DateTime t1, DateTime t2)
        {
            var ik = new ikEntities();
            var liste = per.personel.Where(c => c.PTarihs.Any(d => d.Durum == "Y.İ.")).Select(e => new
            {
                e.AdSoyad,
                gunler = e.PTarihs.Where(f => f.Durum == "Y.İ.").Select(d => new
                {
                    d.Tarih
                }).ToList(),
                BaslangicTarih = "",
                BitisTarih = "",
                SicilNo = ik.Personels.FirstOrDefault(c => c.pdksid == e.ID) == null ? "" : ik.Personels.FirstOrDefault(c => c.pdksid == e.ID).sicilno
            }).ToList();

            DateTime dun = DateTime.MinValue;
            DateTime bugun = DateTime.MinValue;
            ArrayList lst = new ArrayList();
            List<PMazeret> rpr = new List<PMazeret>();
            PMazeret rap; DateTime prev;
            DateTime next;
            DateTime cur;

            foreach (var person in liste)
            {
                //if (person.gunler.Any())
                //{
                //    cur = person.gunler.FirstOrDefault().Tarih;
                rap = new PMazeret();
                //}
                var kaçgun = 1;
                foreach (var gun in person.gunler)
                {

                    cur = gun.Tarih;
                    prev = gun.Tarih.AddDays(-1);
                    next = gun.Tarih.AddDays(1);

                    if (person.gunler.Any(c => c.Tarih == prev))//bir gün önce mevcut
                    {
                        rap.Bitis = cur;
                    }
                    else
                    {
                        rap = new PMazeret { SicilNo = person.SicilNo, AdSoyad = person.AdSoyad, Baslangic = cur, Bitis = cur, Gun = kaçgun };
                    }


                    if (person.gunler.Any(c => c.Tarih == next))//bir gün sonra mevcut
                    {
                        kaçgun++;
                    }
                    else
                    {
                        rap.Gun = kaçgun;
                        rpr.Add(rap);
                        kaçgun = 1;
                    }
                }
            }
            return rpr;
        }
        public object Raporlar(PerkotekContext per, DateTime t1, DateTime t2)
        {
            var ik = new ikEntities();
            var liste = per.personel.Where(c => c.PTarihs.Any(d => d.Durum == "R")).Select(e => new
            {
                e.AdSoyad,
                gunler = e.PTarihs.Where(f => f.Durum == "R").Select(d => new
                {
                    d.Tarih
                }).ToList(),
                BaslangicTarih = "",
                BitisTarih = "",
                SicilNo = ik.Personels.FirstOrDefault(c => c.pdksid == e.ID) == null ? "" : ik.Personels.FirstOrDefault(c => c.pdksid == e.ID).sicilno
            }).ToList();

            DateTime dun = DateTime.MinValue;
            DateTime bugun = DateTime.MinValue;
            ArrayList lst = new ArrayList();
            List<PMazeret> rpr = new List<PMazeret>();
            PMazeret rap; DateTime prev;
            DateTime next;
            DateTime cur;

            foreach (var person in liste)
            {
                //if (person.gunler.Any())
                //{
                //    cur = person.gunler.FirstOrDefault().Tarih;
                rap = new PMazeret();
                //}
                var kaçgun = 1;
                foreach (var gun in person.gunler)
                {

                    cur = gun.Tarih;
                    prev = gun.Tarih.AddDays(-1);
                    next = gun.Tarih.AddDays(1);

                    if (person.gunler.Any(c => c.Tarih == prev))//bir gün önce mevcut
                    {
                        rap.Bitis = cur;
                    }
                    else
                    {
                        rap = new PMazeret { SicilNo = person.SicilNo, AdSoyad = person.AdSoyad, Baslangic = cur, Bitis = cur, Gun = kaçgun };
                    }


                    if (person.gunler.Any(c => c.Tarih == next))//bir gün sonra mevcut
                    {
                        kaçgun++;
                    }
                    else
                    {
                        rap.Gun = kaçgun;
                        rpr.Add(rap);
                        kaçgun = 1;
                    }
                }
            }
            return rpr;
        }

        public object IzinDurum(int ikid)
        {
            using (var ik = new ikEntities())
            {
                var personel = ik.Personels.SingleOrDefault(c => c.id == ikid);
                var isegiris = personel.giristarihi;
                var dogumyil = personel.dogumtarihi.Value.Year;
                var liste = personel.Izins.OrderBy(d => d.baslangictarih).Select(c => new
                {
                    c.Personel.adsoyad,
                    c.yil,
                    c.baslangictarih,
                    c.bitistarihi,
                    c.gun,
                    c.izintip,
                    c.aciklama
                }).ToList();

                var baş = isegiris.Value;
                var kıç = baş;
                var izin = new PYillikIzin();
                int kidem = 0;
                var yaş = 0;
                var hakedilen = 0;
                while (kıç <= DateTime.Now)
                {

                    kıç = baş.AddYears(1);
                    kidem++;
                    if (liste.Any(c => c.izintip == 3 & c.baslangictarih >= baş & c.baslangictarih <= kıç))
                    {
                        foreach (var ücretsiz in liste.Where(c => c.izintip == 3 & c.baslangictarih >= baş & c.baslangictarih <= kıç))
                        {
                            kıç = kıç.AddDays(ücretsiz.gun);
                        }
                    }
                    yaş = kıç.Year - dogumyil;

                    hakedilen = yaş > 50 | kidem > 5 ? 20 : 14;
                    izin.PYillikIzinKidems.Add(new PYillikIzinKidem
                    {
                        kidem = kidem,
                        KidemBaslangic = baş,
                        KidemBitis = kıç,
                        hakedilenizin = hakedilen
                        //,PIzins = liste.Where(d=>d.yil==kıç.Year).Select(c=> new PIzin
                        //{
                        //    Aciklama = c.aciklama,
                        //    Baslangic = c.baslangictarih,
                        //    Bitis = c.bitistarihi,
                        //    Gun = c.gun,
                        //    Yillik = c.izintip==0

                        //}).ToList()
                    });
                    baş = kıç;
                }





                return izin.PYillikIzinKidems.ToList();

                //var mid = ik.Personels.SingleOrDefault(c => c.sicilno == "472").mikroid;
                //using (var mikro = new MikroDB_V15_KENTEntities())
                //{
                //    var izinler = mikro.PERSONEL_IZINLERI.Where(d => d.pz_pers_kod == "0472").Select(e => new
                //    {
                //        e.pz_baslangictarih,
                //        e.pz_pers_kod,
                //        e.pz_gerceklesen_donus_tarihi,
                //        e.pz_gun_sayisi,
                //        e.pz_izin_aciklama,
                //        e.pz_izin_tipi,
                //        e.pz_izin_yil,
                //        e.pz_iptal,
                //        e.pz_izin_no
                //    }).ToList();
                //    return izinler;
                //}
            }

            return null;
        }

        public object Mazeretler(PerkotekContext per, DateTime t1, DateTime t2)
        {
            var ik = new ikEntities();
            var liste = per.personel.ToList();
            var mazeret = new ArrayList();
            foreach (var personel in liste)
            {
                foreach (var pTarih in personel.PTarihs)
                {
                    foreach (var pIzin in pTarih.Izins.Where(c => c.Tip == 9))
                    {
                        mazeret.Add(new
                        {
                            SicilNo =
                                ik.Personels.FirstOrDefault(c => c.pdksid == personel.ID) == null
                                    ? ""
                                    : ik.Personels.FirstOrDefault(c => c.pdksid == personel.ID).sicilno,
                            Tarih = pTarih.Tarih,
                            AdSoyad = personel.AdSoyad,
                            Baslangic = pIzin.Gidis,
                            Bitis = pIzin.Gelis,
                            Aciklama = pIzin.Aciklama
                        });
                    }
                }
            }
            return mazeret;
        }


        public object MikroIzinler()
        {
            using (var mikro = new MikroDB_V15_KENTEntities())
            {
                return mikro.PERSONEL_IZINLERI.Where(c => c.pz_pers_kod == "0472").Select(d => new
                {
                    d.pz_izin_tipi,
                    d.pz_izin_no,
                    d.pz_baslangictarih,
                    d.pz_gerceklesen_donus_tarihi,
                    d.pz_gun_sayisi,
                    d.pz_izin_aciklama
                }).ToList();
            }

            return null;

        }


        public void RaporTara()
        {
            var form = new RaporTara();
            form.ShowDialog();
            //List<string> files = result == null ? null : result.GetImageFiles();
            //Console.WriteLine("Scanned: " + string.Join(", ", files == null ? new string[0] : files.ToArray()));
        }


        public object GirisCikislar(PerkotekContext per, DateTime value, DateTime dateTime)
        {
            var ik = new ikEntities();
            var liste = per.personel.ToList();
            var giriscikis = new ArrayList();
            foreach (var personel in liste)
            {
                var p = ik.Personels.SingleOrDefault(c => c.adsoyad == personel.AdSoyad);
                foreach (var pTarih in personel.PTarihs)
                {
                    if (pTarih.Harekets.Any())
                    {
                        var o = pTarih.Harekets.OrderBy(c => c.Ticks);
                        giriscikis.Add(new
                        {
                            SicilNo = p.sicilno,
                            AdSoyad = personel.AdSoyad,
                            Birim = p.birim.fullad,
                            Tarih = pTarih.Tarih,
                            Giris = o.First(),
                            Cikis = o.Last()
                        });
                    }
                }
            }
            return giriscikis;
        }

        public object GecKalanlar(PerkotekContext per, DateTime value, DateTime dateTime)
        {
            var mgiris=new TimeSpan(08,30,00);//gerekirse database ten çek
            var mcikis=new TimeSpan(17,30,00);//gerekirse database ten çek
            var geckalmadk = 5;
            var geçkalma = 0;     

            var ik = new ikEntities();
            var liste = per.personel.ToList();
            var geckalanlar = new ArrayList();
            foreach (var personel in liste)
            {
                var p = ik.Personels.SingleOrDefault(c => c.adsoyad == personel.AdSoyad);
                if (p != null){
                    var birimad = p.birim.fullad;
               

                    foreach (var pTarih in personel.PTarihs)
                    {
                        if(pTarih.Tarih.DayOfWeek== DayOfWeek.Saturday || pTarih.Tarih.DayOfWeek== DayOfWeek.Sunday) continue;

                        if (!pTarih.Harekets.Any()) continue;

                        if (pTarih.Izins.Any(c=>(c.Saatlik && c.Gidis.ToString()==mgiris.ToString())|| !c.Saatlik))
                            continue;
                        var giris = pTarih.Harekets.FirstOrDefault();

                        if (giris.Subtract(mgiris).TotalMinutes > (mcikis.Subtract(mgiris).TotalMinutes/2)) continue;
                        geçkalma = (int)giris.Subtract(mgiris).TotalMinutes;

                        if (geçkalma > geckalmadk)
                        {
                            geckalanlar.Add(new
                            {
                                SicilNo=p.sicilno,
                                Birim=birimad,
                                AdSoyad=p.adsoyad,
                                Tarih=pTarih.Tarih,
                                GirisSaat=giris,
                                Fark= geçkalma
                            });
                        }

                        //izin varmı varsa giriştemi var çıkıştamı yoksa aradamı
                        //tarih tekse girişmi eksik çıkışmı

                        //sicilno,birim,personeladsoyad,tarih,girişsaat,geç kalma,birim sorumlusu
                    }
                }
            }

            return geckalanlar;
        }
    }



    public class PMazeret
    {
        public string SicilNo { get; set; }
        public string AdSoyad { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public int Gun { get; set; }
    }

    public class PYillikIzin
    {
        public PYillikIzin()
        {
            PYillikIzinKidems = new List<PYillikIzinKidem>();
        }

        public List<PYillikIzinKidem> PYillikIzinKidems { get; set; }
    }

    public class PYillikIzinKidem
    {
        public int kidem { get; set; }
        public int hakedilenizin { get; set; }

        public DateTime KidemBaslangic { get; set; }
        public DateTime KidemBitis { get; set; }

        public List<PIzin> PIzins { get; set; }

        public PYillikIzinKidem()
        {
            PIzins = new List<PIzin>();
        }
    }

    public class PIzin
    {
        public bool Yillik { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public int Gun { get; set; }
        public string Aciklama { get; set; }
    }

}
