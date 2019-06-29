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
        //Variáveis declaradas para uso em toda classe

        dtc datacom = new dtc();

        public principal()
        {
            InitializeComponent();
           
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //carrega os dados da olt1
            datacom.sshopen("10.255.93.11", "22", "admin", "D#2115kpq");
            lbl_olt1_modelo.Text = datacom.modelo();
            lbl_olt1_fw.Text = datacom.fw();
            lbl_olt1_name.Text = datacom.hostname();

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
            // ATIVAR NO FINAL DOS TESTES
            //onuview allonu = new onuview();
            //allonu.Show();
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
