using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace convesor.ws
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private string caminhoEntrada;
        LeitorJson leitorJson;


        public Worker(ILogger<Worker> logger)
        {
            leitorJson = new LeitorJson();
            caminhoEntrada = leitorJson.PegarCaminhoDeEntrada();

            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
               
            while (!stoppingToken.IsCancellationRequested)
            {
                Conversor conversor = new Conversor();

                var arquivosDaPastaDeEntrada = Directory.GetFiles(caminhoEntrada, ".txt");

                foreach (var arquivo in arquivosDaPastaDeEntrada)
                {
                    conversor.ConverterTxtEmPdf(arquivo);
                }

                //ListenDirector
                //FileSystemWatch

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
