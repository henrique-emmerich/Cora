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
        //public string alarm()
        //{
        //    //SshCommand dtccmd = cssh.RunCommand("show alarm");
        //    //string alarme = dtccmd.Result;
        //    //string[] alarm = alarme.Split('\n');
        //    //return alarm;

        //}
        public string hostname()
        {
            SshCommand dtccmd = cssh.RunCommand("config" + "\n" + "show hostname");
            string name = dtccmd.Result.Substring(9, 12);
            return name;
        }
        public string[,] Onus()
        {
            SshCommand dtccmd = cssh.RunCommand("show interface gpon onu");
            string sshresult= dtccmd.Result;                 // atribui o retorno a uma string simples
            sshresult = sshresult.Remove(0, 208);            // remove do retorno o cabeçalho
            sshresult= sshresult.Remove(sshresult.Length-1); // remove do retorno a ultima linha
            string[] onuresults = sshresult.Split('\n');     // divide o retorno em cada quebra de linha

            string[,] onustatus= new string[onuresults.Length,5];   //Matriz que armazenara e retornará  as infos das onus 
            
            //a matriz vai ter apenas 4 colunas...
            //PON - ID - serial - descrição

            //percorre cada linha da string e armazena nas respectivas linhas
            for (int l = 0;l<onuresults.Length;l++) //for que percorre as linhas
            {
                onustatus[l, 0] = onuresults[l].Substring(4, 1);    //recorta a pon
                onustatus[l, 1] = onuresults[l].Substring(10, 3);   //recorta o id
                onustatus[l, 2] = onuresults[l].Substring(19, 12);  //recorta o serial 35
                onustatus[l, 3] = onuresults[l].Substring(68);      //recorta o description
                onustatus[l, 4] = onuresults[l].Substring(35, 4);   //pega o status da onu se esta up ou down

                onustatus[l, 1] = onustatus[l, 1].Trim();//remove o espaço vazio no final do ID (quando o id for tipo: 1)
                onustatus[l, 3] = onustatus[l, 3].Trim(); //remove o espaço vazio no final da onu
                onustatus[l, 4] = onustatus[l, 4].Trim(); //se o status for Up... remove o espaço vazio no final

            }
            //retornando um array inteiro...
            //proximo passo retornar uma matriz...
            //converter toda a tabela trazida pelo
           
            return onustatus;
        }
        public int[] statusonu()
        {
            string[,] ONU = Onus();
            //int x= ONU.Length;
            int[] onuupdown = {1,1,1};

            for (int l = 0; l<ONU.GetLength(0); l++) //for que percorre as linhas
            {
                if (ONU[l, 4] == "Up") { onuupdown[0] += 1; }
                else if(ONU[l, 4] == "Down") { onuupdown[1] += 1; }
            }

            onuupdown[2] = onuupdown[0] + onuupdown[1];


            return onuupdown;
        }
        public string[] rastreio()
        {
            SshCommand dtccmd = cssh.RunCommand("show interface gpon discovered-onus");
            string sshresult = dtccmd.Result;
            string[] rastreio= {"eret","dfd"};


            if (sshresult== "% No entries found.") { }
            else { MessageBox.Show(sshresult); }
            return rastreio;

        }

        //fim da classe dtc
    }

    
}

