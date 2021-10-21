using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = iTextSharp.text.Document;

namespace convesor.ws
{
    public class Conversor
    {
        private string caminhoEntrada;
        string[] linhasDoTxt = null;     
        LeitorDeTxt leitorDeTxt;
        string caminhoSaidaPdf = null;
        string caminhoCompletoDoArquivoTxt = null;
        LeitorJson leitorJson;
        string tituloDoArquivo = null;
        public Conversor()
        {
            leitorJson = new LeitorJson();
            leitorDeTxt = new LeitorDeTxt() ;
            caminhoSaidaPdf = leitorJson.PegarCaminhoDeSaidaPDF();
            caminhoEntrada = leitorJson.PegarCaminhoDeEntrada();

        }
        public void ConverterTxtEmPdf(string file)
        {
            try
            {            
                caminhoCompletoDoArquivoTxt = leitorJson.PegarCaminhoDeEntrada() + tituloDoArquivo;

                tituloDoArquivo = leitorDeTxt.LerNomeDoArquivo(file);

                linhasDoTxt = leitorDeTxt.LerLinhasDoTxt(file);

                string caminhoDoArquivoPDF = $@"{caminhoSaidaPdf}" + $"{tituloDoArquivo.Replace(".txt", "")}.pdf";
                FileStream arquivoPDF = new FileStream(caminhoDoArquivoPDF, FileMode.Create);
                Document doc = new Document(PageSize.A4);
                PdfWriter escritoPDF = PdfWriter.GetInstance(doc, arquivoPDF);

                Paragraph paragrafo = new Paragraph();

                foreach (var linha in linhasDoTxt)
                {
                    paragrafo.Add(linha+ "\n");
                }

                doc.Open();
                doc.Add(paragrafo);
                doc.Close();

                File.Copy(caminhoCompletoDoArquivoTxt, leitorJson.PegarCaminhoDeSaidaTxtProcessado() + $@"{tituloDoArquivo}");
                File.Delete(caminhoCompletoDoArquivoTxt);

            }
            catch (Exception ex)
            {
                File.Copy(caminhoCompletoDoArquivoTxt, leitorJson.PegarCaminhoDeSaidaTxtComFalha() + $@"{tituloDoArquivo}");
                File.Delete(caminhoCompletoDoArquivoTxt);
            }
        }

    }
}
