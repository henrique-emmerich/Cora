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

        public string[,] onus()
        {
            SshCommand dtccmd = cssh.RunCommand("show interface gpon onu");
            string sshresult= dtccmd.Result;                 // atribui o retorno a uma string simples
            sshresult = sshresult.Remove(0, 208);            // remove do retorno o cabeçalho
            sshresult= sshresult.Remove(sshresult.Length-1); // remove do retorno a ultima linha
            string[] onuresults = sshresult.Split('\n');     // divide o retorno em cada quebra de linha

            string[,] onustatus= new string[onuresults.Length,4];   //Matriz que armazenara e retornará  as infos das onus 
            
            //a matriz vai ter apenas 4 colunas...
            //PON - ID - serial - descrição

            //percorre cada linha da string e armazena nas respectivas linhas
            for (int l = 0;l<=onuresults.Length;l++) //for que percorre as linhas
            {
                onustatus[l, 0] = onuresults[l].Substring(4, 1);    //recorta a pon
                onustatus[l, 1] = onuresults[l].Substring(10, 1);   //recorta o id
                onustatus[l, 2] = onuresults[l].Substring(19, 12);  //recorta o serial
                onustatus[l, 3] = onuresults[l].Substring(68);      //recorta o description
            }
            









            //retornando um array inteiro...
            //proximo passo retornar uma matriz...
            //converter toda a tabela trazida pelo
           
            return onustatus;
        }


        //fim da classe dtc
    }

    
}

