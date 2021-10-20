using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convesor.ws
{
    public class Conversor
    {
        string[] linhasDoTxt = null;
        LeitorJson leitorJson;
        LeitorDeTxt leitorDeTxt;
        public Conversor()
        {
            leitorJson = new LeitorJson();
            leitorDeTxt = new LeitorDeTxt(leitorJson.PegarCaminhoDeEntrada()) ;

        }

        public void ConverterTxtEmPdf()
        {
            try
            {
                linhasDoTxt = leitorDeTxt.LerLinhasDoTxt();
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
