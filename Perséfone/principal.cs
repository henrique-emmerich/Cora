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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void VisualizaçãoDeONUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todas as visualizações usam o mesmo Form
            //chama o form de visualização de ONUs
            onuview allonu = new onuview();
            allonu.Show();
        }

        private void Btn_olt1_all_onu_Click(object sender, EventArgs e)
        {
            //todas as visualizações usam o mesmo Form
            //chama o form de visualização de ONUs
            onuview allonu = new onuview();
            allonu.Show();
        }

        private void Btn_olt2_all_onu_Click(object sender, EventArgs e)
        {
            //todas as visualizações usam o mesmo Form
            //chama o form de visualização de ONUs
            onuview allonu = new onuview();
            allonu.Show();
        }
    }
}
