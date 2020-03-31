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
    public partial class Hareketler : Form
    {
        public Hareketler()
        {
            InitializeComponent();
        }

        private void Hareketler_Load(object sender, EventArgs e)
        {
            hareketBindingSource.DataSource = (List<Hareket>) this.Tag;
        }
    }
}
