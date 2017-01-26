using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using puantaj2017.DAL;

namespace puantaj2017
{
    public partial class Mesailer : Form
    {
        private puantajDataSet ds;

        public Mesailer()
        {
            InitializeComponent();
        }

        private void Mesailer_Load(object sender, EventArgs e)
        {
            ds = (puantajDataSet) Tag;
            using (var db = new ikEntities())
            {
                comboBox1.DataSource = db.birims.ToList();
                comboBox1.SelectedIndex = -1;
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var personelpdksid = (int) comboBox2.SelectedValue;
            var liste = ds.PersonelGirisCikis.Where(c => c.personelid == personelpdksid);

            //var grliste = liste.GroupBy(c => c.hafta).ToList();
            //foreach (var haft in grliste)
            //{
            //    foreach (var gun in haft)
            //    {
            //        try
            //        {
            //            //hafta içi ise 9 saat düş
            //            //hafta sonu ise 1 saat düş


            //            Console.WriteLine(new
            //            {
            //                hafta = gun.hafta,
            //                tarih =gun.tarih,
            //                giris = gun.giris_saat,
            //                cikis = gun.cikis_saat,
            //                calismasure = TimeSpan.Parse(gun.cikis_saat).Subtract(gun.giris_saat),
            //                mesai= TimeSpan.Parse(gun.cikis_saat).Subtract(gun.giris_saat).TotalMinutes-540
            //            });
            //        }
            //        catch (Exception)
            //        {


            //        }
            //    }
            //}

            personelGirisCikisDataTableBindingSource.DataSource = liste;
            // dataGridView1.DataSource = liste.ToList();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (int.Parse(row.Cells[0].Value.ToString())%2 == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                var date = (DateTime) row.Cells[2].Value;
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    row.Cells[5].Value = true;
                }

                if (row.Cells[3].Value == null || row.Cells[4].Value == null)
                {
                    row.Cells[7].Value = false;
                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (var db = new ikEntities())
            {
                comboBox2.DataSource = db.Personels.Where(c => c.birimid == (int) comboBox1.SelectedValue).ToList();
                comboBox2.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelGirisCikisDataTableBindingSource.EndEdit();


            var items =
                (EnumerableRowCollection<puantajDataSet.PersonelGirisCikisRow>)
                    personelGirisCikisDataTableBindingSource.DataSource;

            foreach (var item in items.Where(c => c.mesaihesapla).GroupBy(c => c.hafta))
            {
                var haftalik = 0;
                foreach (var personelGirisCikisRow in item)
                {
                    try
                    {
                        var calisma = (int)
                            TimeSpan.Parse(personelGirisCikisRow.cikis_saat)
                                .Subtract(personelGirisCikisRow.giris_saat)
                                .TotalMinutes;
                        var mesai = calisma - (personelGirisCikisRow.tatil ? 60 : 540);
                        haftalik += mesai;
                        //Console.WriteLine(new { personelGirisCikisRow.tarih, mesai });
                    }
                    catch (Exception mx)
                    {
                    }
                }

                //Console.WriteLine(new {hafta=item.Key, haftalik, saat= haftalik / 60,dakika= haftalik % 60});


                ds.PersonelMesai.AddPersonelMesaiRow(
                    item.FirstOrDefault().personelid,
                    item.Key,
                    (haftalik/60) - 5,
                    haftalik%60,
                    item.FirstOrDefault().tarih.ToShortDateString() + "-" +
                    item.LastOrDefault().tarih.ToShortDateString()
                    );

                personelMesaiDataTableBindingSource.DataSource =
                    ds.PersonelMesai.Where(c => c.personelid == (int) comboBox2.SelectedValue);
            }
        }
    }
}