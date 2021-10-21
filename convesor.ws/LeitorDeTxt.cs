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

        public string[] LerLinhasDoTxt(string file)
        {       
            return File.ReadAllLines(file);                       
        }

        public string LerNomeDoArquivo(string file)
        {          
            var fileInfo = new FileInfo(file);

            return fileInfo.Name;         
        }
    }
}
