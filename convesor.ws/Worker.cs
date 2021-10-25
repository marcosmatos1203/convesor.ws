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
        LeitorDeTxt leitorDeTxt;
        WatcherFolder watcher;

        public Worker(ILogger<Worker> logger)
        {
            leitorJson = new LeitorJson();
            leitorDeTxt = new LeitorDeTxt();
            caminhoEntrada = leitorJson.PegarCaminhoDeEntrada();
            _logger = logger;
            watcher = new WatcherFolder();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            //Parallel.ForEach(Directory.GetFiles(caminhoEntrada, "*.txt"), (arquivo) =>
            //{
            //    Conversor conversor = new Conversor();

            //    conversor.ConverterTxtEmPdf(arquivo);
            //});

            stopwatch.Stop();

            Console.WriteLine("Tempo decorrido EM PARALELO {0} segundos",
             stopwatch.ElapsedMilliseconds);
       
            watcher.Observar();
        }

        private void OnActionOccurOnFolderPath(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("=== Algumas mudanças aconteceram ===");
            Console.WriteLine(e.ChangeType);
            Console.WriteLine(e.Name);
        }
    }
}
