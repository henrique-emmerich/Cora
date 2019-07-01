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

        //statusonu onusstatu

        public void sshopen(string ip, string porta, string user, string senha)
        {
            //cria a instância passando os dados para conexãs obtidos na chamada da função
            cssh = new SshClient(ip, Convert.ToInt32(porta), user, senha);
            try { cssh.Connect(); }
            catch { MessageBox.Show("Problemas na conexão com a OLT"); }


        }
        public void sshclose()
        {
            if (cssh.IsConnected) { cssh.Disconnect(); }
        }
        public string fw()
        {
            SshCommand dtccmd = cssh.RunCommand("show platform");
            string sshretorno = dtccmd.Result.Substring(278, 9);
            return sshretorno;
            sshclose();
        }
        public string modelo()
        {
            SshCommand dtccmd = cssh.RunCommand("show platform");
            string sshretorno = dtccmd.Result.Substring(167, 6);
            return sshretorno;
            sshclose();
        }
        public string alarm()
        {
            SshCommand dtccmd = cssh.RunCommand("show alarm");
            string alarme = dtccmd.Result;
            return alarme;

        }
        public string hostname()
        {
            SshCommand dtccmd = cssh.RunCommand("config" + "\n" + "show hostname");
            string name = dtccmd.Result.Substring(9, 12);
            return name;
        }

        //public statusonu onus()
        //{
        //    return new statusonu() { onudown = 34, onutotal = 23, onuup = 45 };
        //}

        public int[] onus()
        {
            //tentando retornar um array na função
            int onuup = 14;
            int onudown = 15;
            int onutotal = onuup + onudown;
            int[] onustatus= { onuup, onudown,onutotal };
           return onustatus[];
        }


        //fim da classe dtc
    }

    
}

