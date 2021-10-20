using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace convesor.ws
{
    public class ConversorTxtPdf : BackgroundService
    {
        private readonly ILogger<ConversorTxtPdf> _logger;

        public ConversorTxtPdf(ILogger<ConversorTxtPdf> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
        public void GerarPDF(object txt)
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json").Build();


            //var folderSettings = ConfigurationBinder.Bind<FolderSettings>(config.GetConfigurationSection("Diretorio"));
            //var caminhoSaida = folderSettings.TargetFolderLocations["RepositorioSaida"];


            //string diretorioSaida = "";
            //string nomeArquivo = $@"..\..\..\" + "Contrato.pdf";
            //FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            //Document doc = new Document(PageSize.A4);
            //PdfWriter escritoPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            ////doc.Open();
            //string dados = "";

            //Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));

            //paragrafo.Alignment = Element.ALIGN_LEFT;
            //paragrafo.Add("==================================\n");
            //paragrafo.Add("Cliente: " + locacao.Cliente.Nome + " " + "RG: " + locacao.Cliente.RG + "\n");
            //paragrafo.Add("Condutor: " + locacao.Condutor.Nome + " " + "RG: " + locacao.Condutor.Rg + "\n");
            //paragrafo.Add("==================================\n");

            //paragrafo.Add("Veiculo: " + locacao.Veiculo.Modelo + "\n");
            //paragrafo.Add("Placa: " + locacao.Veiculo.Placa + "\n");
            //paragrafo.Add("Cor: " + locacao.Veiculo.Cor + "\n");
            //paragrafo.Add("==================================\n");

            //foreach (var taxasServicos in locacao.TaxasServicos)
            //{
            //    paragrafo.Add("Taxas e Serviços: " + taxasServicos.Descricao + "\n");
            //}

            //paragrafo.Add("==================================\n");
            //paragrafo.Add("PLano Selecionado: " + locacao.plano + "\n");
            //paragrafo.Add("==================================\n");
            //paragrafo.Add("Data de Locação: " + locacao.dataLocacao.ToShortDateString() + "\n");
            //paragrafo.Add("==================================\n");
            //paragrafo.Add("Data de Devolução: " + locacao.dataDevolucao.ToShortDateString() + "\n");
            //paragrafo.Add("==================================\n");

            //if (locacao.Cupom != null)
            //{
            //    if (locacao.Cupom.ValorMinimo <= locacao.CalcularValorLocacao())
            //    {
            //        if (locacao.Cupom.ValorFixo != 0)
            //            paragrafo.Add("Cupom: " + locacao.Cupom.Nome + "\nValor do Desconto: " + locacao.Cupom.ValorFixo + "R$\n");

            //        else
            //            paragrafo.Add("Cupom: " + locacao.Cupom.Nome + "\nPorcentagem de Desconto na Locação: " + locacao.Cupom.ValorPercentual + "%\n");

            //        paragrafo.Add("==================================\n");
            //    }

            //    else
            //    {
            //        paragrafo.Add("Cupom: " + locacao.Cupom.Nome + "\n");
            //        paragrafo.Add("Cupom atualmente inválido, pois o valor total não cumpre os requisitos do cupom!\n");
            //    }
            //}

            //paragrafo.Add("==================================\n");
            //paragrafo.Add("Valor Total:" + locacao.CalcularValorLocacao() + "\n");

            //doc.Open();
            //doc.Add(paragrafo);
            //doc.Close();

            //return nomeArquivo;
        }
    }
}
