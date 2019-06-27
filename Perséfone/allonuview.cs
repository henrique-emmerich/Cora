using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perséfone
{
    public partial class onuview : Form
    {
        public onuview()
        {
            InitializeComponent();
        }

        private void Allonuview_Load(object sender, EventArgs e)
        {
            //dataGridView1.
            dataGridView1.Columns.Add("OLT","OLT");
            dataGridView1.Columns.Add("PON", "PON");
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns.Add("Serial", "Serial");
            dataGridView1.Columns.Add("RX dBm", "RX dBm");
            dataGridView1.Columns.Add("TX dBm", "TX dBm");
            dataGridView1.AutoResizeColumns();

            DataGridViewRow item = new DataGridViewRow();
            item.CreateCells(dataGridView1);

        }
    }
}
