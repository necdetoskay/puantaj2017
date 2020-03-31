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
    public partial class TEST : Form
    {
        public TEST()
        {
            InitializeComponent();
        }

        private void TEST_Load(object sender, EventArgs e)
        {
            var ot = new ptakipBL();
          //  var izinler = ot.IzinDurum(0);


            gridControl1.BeginUpdate();
            gridView1.Columns.Clear();
            var liste = ot.MikroIzinler();//ot.IzinDurum(2298);
            gridControl1.DataSource = liste;

            gridControl1.EndUpdate();

        }
    }
}
