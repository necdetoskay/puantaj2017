using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using puantaj2017.DAL;

namespace puantaj2017
{
    public partial class Form1 : Form
    {
        puantajDataSet ds = new puantajDataSet();
        ikEntities ik=new ikEntities();
        public Form1()
        {
            WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (wp.Identity.Name != "KENTKONUT\\noskay")
                return;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            perkotekyukle();
            test();
        }

        private void test()
        {
            var personel = ik.Personels.FirstOrDefault();
            var liste = ds.PersonelGirisCikis.Where(c => c.personelid == personel.pdksid && c.giris_saat<new TimeSpan(12,0,0));

        }
        private void perkotekyukle()
        {
            using (var con = new MySqlConnection("Server=172.41.40.85;Database=perkotek;Uid=root;Pwd=max;AllowZeroDateTime=True;Charset=latin5"))
            {
                try
                {
                    
                    var com = new MySqlCommand("", con);
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    com.CommandText =
                        "select id,concat(adi,' ',soyadi) as  adsoyad from personel_kartlari where sirket_kod=5";
                    var adapter = new MySqlDataAdapter(com);
                    adapter.Fill(ds.Personel);
                    com.CommandText =
                        string.Format(
                            "select personel_id as personelid,tarih,giris_saat from personel_giriscikis where tarih between '{0}' and '{1}'",
                           new DateTime(2017,01,01).ToString("yyyy-MM-dd"), new DateTime(2017, 01, 31).ToString("yyyy-MM-dd"));
                    adapter.Fill(ds.PersonelGirisCikis);
                    con.Close();
                }
                catch (Exception ex)
                {

                    con.Close();
                }


            }
        }
    }
}
