using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convesor.ws
{
    public class LeitorDeTxt
    {
        private string CaminhoEntrada;


        public LeitorDeTxt(string caminhoEntrada)
        {
            CaminhoEntrada = caminhoEntrada;

        }

        public string[] LerLinhasDoTxt()
        {
            var file = Directory.GetFiles(CaminhoEntrada);

            return File.ReadAllLines(file[0]);          
           
        }
    }
}
