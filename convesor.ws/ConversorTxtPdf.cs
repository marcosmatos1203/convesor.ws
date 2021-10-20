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
                       
            

           
        }
    }
}
