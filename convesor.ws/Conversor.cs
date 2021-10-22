using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;
using Document = iTextSharp.text.Document;

namespace convesor.ws
{
    public class Conversor
    {
        string[] linhasDoTxt = null;
        LeitorDeTxt leitorDeTxt;
        string caminhoSaidaPdf = null;
        string caminhoCompletoDoArquivoTxt = null;
        LeitorJson leitorJson;
        string tituloDoArquivo = null;
        public Conversor()
        {
            leitorJson = new LeitorJson();
            leitorDeTxt = new LeitorDeTxt();
            caminhoSaidaPdf = leitorJson.PegarCaminhoDeSaidaPDF();

        }
        public void ConverterTxtEmPdf(string file)
        {
            try
            {
                Console.WriteLine("Convertendo arquivo: " + file);
                
                tituloDoArquivo = leitorDeTxt.LerNomeDoArquivo(file);
                
                caminhoCompletoDoArquivoTxt = leitorJson.PegarCaminhoDeEntrada() + tituloDoArquivo;
                
                linhasDoTxt = leitorDeTxt.LerLinhasDoTxt(file);

                string caminhoDoArquivoPDF = $@"{caminhoSaidaPdf}" + $"{tituloDoArquivo.Replace(".txt", "")}.pdf";
               
                FileStream arquivoPDF = new FileStream(caminhoDoArquivoPDF, FileMode.Create);
               
                Document doc = new Document(PageSize.A4);

                PdfWriter.GetInstance(doc, arquivoPDF);

                doc.Open();

                foreach (var linha in linhasDoTxt)
                {
                    doc.Add(new Paragraph(linha + "\n"));                  
                }           
                
                doc.Close();

                File.Copy(caminhoCompletoDoArquivoTxt, leitorJson.PegarCaminhoDeSaidaTxtProcessado() + $@"{tituloDoArquivo}");
                File.Delete(caminhoCompletoDoArquivoTxt);

                Console.WriteLine("Finalizando arquivo: " + file);
            }
            catch (Exception ex)
            {
                File.Copy(caminhoCompletoDoArquivoTxt, leitorJson.PegarCaminhoDeSaidaTxtComFalha() + $@"{tituloDoArquivo}");
                File.Delete(caminhoCompletoDoArquivoTxt);
            }
        }

    }
}
