using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puantaj2017
{
    public partial class DosyaTarih : Form
    {
        public DosyaTarih()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var res= folderBrowserDialog1.ShowDialog();
           var yol = folderBrowserDialog1.SelectedPath;

            if(MessageBox.Show("İşleme devam edilsin mi?","", MessageBoxButtons.YesNo)!= DialogResult.Yes) return;string[] files=Directory.GetFiles(yol);
            var file = new List<PuantajFile>();
            var tarih = DateTime.Now;
            foreach (var s in files){
                var f=new FileInfo(s);
                f.CreationTime = tarih;
                f.LastAccessTime = tarih;
                f.LastWriteTime = tarih;
                tarih = tarih.AddMinutes(new Random().Next((int)numericUpDown1.Value, (int)numericUpDown2.Value));
            }
          

        }

        private void DosyaTarih_Load(object sender, EventArgs e)
        {

        }
    }

    class PuantajFile
    {
        public string path { get; set; }
        public string filename { get; set; }
                
    }
}
