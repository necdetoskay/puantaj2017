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

namespace puantaj2017
{
    public partial class Rapor : Form
    {
        private object liste;
        public Rapor(object liste)
        {
            this.liste = liste;
            InitializeComponent();
        }

        private void Rapor_Load(object sender, EventArgs e)
        {
            gridControl1.BeginUpdate();
            gridView1.Columns.Clear();
           
            gridControl1.DataSource = liste;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = true;

            gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;

            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;


            foreach (var column in gridView1.Columns)
            {
                var c = (DevExpress.XtraGrid.Columns.GridColumn) column;
                if (c.ColumnType == typeof (TimeSpan))
                {
                    c.DisplayFormat.FormatString =@"{0:hh}:{0:mm}";
                }
            }
           


            gridControl1.EndUpdate();
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
    }
}
