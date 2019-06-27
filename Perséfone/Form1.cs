using System;
using System.Windows.Forms;

namespace Perséfone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            principal fprincipal = new principal();
            fprincipal.ShowDialog();
            this.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ = txtuser.Focus();
        }
    }
}
