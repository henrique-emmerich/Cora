using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace Perséfone
{
    class dtc
    {
        SshClient cssh;
        

        public void sshopen(string ip,string porta, string user, string senha)
        {
            //cria a instância passando os dados para conexãs obtidos na chamada da função
            cssh = new SshClient(ip,Convert.ToInt32(porta), user, senha);
            try {cssh.Connect();}
            catch{ MessageBox.Show("Problemas na conexão com a OLT");}

            
        }

        public void sshclose()
        {
            if (cssh.IsConnected) { cssh.Disconnect();}
        }

        public string sshfw()
        {
            
            SshCommand dtccmd = cssh.RunCommand("show platform");
            string sshretorno = dtccmd.Result;
            MessageBox.Show(sshretorno);
            string fw, modelo;
            sshclose();
            return sshretorno;
        }

    }
}
