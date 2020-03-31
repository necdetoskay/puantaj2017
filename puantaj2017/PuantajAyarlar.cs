using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puantaj2017.DAL;

namespace puantaj2017
{
    public partial class PuantajAyarlar : Form
    {
        ikEntities db=new ikEntities();
        public PuantajAyarlar()
        {
            InitializeComponent();
        }

        private void PuantajAyarlar_Load(object sender, EventArgs e)
        {
           
                var liste = db.birims.ToList();
                birimBindingSource.DataSource =liste;
            
        }

        private void PuantajAyarlar_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}
