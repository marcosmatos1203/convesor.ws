using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convesor.ws
{
    public class WatcherFolder
    {
        LeitorJson leitorJson;

        public WatcherFolder()
        {
            leitorJson = new LeitorJson();
        }

        public void Observar()
        {
            var fileSystemWatcher = new FileSystemWatcher(leitorJson.PegarCaminhoDeEntrada())
            {
                Filter = "*.txt",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Attributes,
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Created += OnCreated;
        
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Conversor conversor = new Conversor();

            Task.Run(() =>conversor.ConverterTxtEmPdf(e.FullPath));
        }
    }
}
