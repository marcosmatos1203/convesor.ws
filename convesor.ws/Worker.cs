using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();                       

                Parallel.ForEach(Directory.GetFiles(caminhoEntrada, "*.txt"), (a) => conversor.ConverterTxtEmPdf(a));

                stopwatch.Stop();

                Console.WriteLine("Tempo decorrido EM PARALELO {0} segundos",
                 stopwatch.ElapsedMilliseconds);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
