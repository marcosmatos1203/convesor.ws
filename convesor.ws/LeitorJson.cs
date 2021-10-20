using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convesor.ws
{
    public class LeitorJson
    {
        IConfigurationRoot config;
        public LeitorJson()
        {
            config = new ConfigurationBuilder()
                     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                     .AddJsonFile("appsettings.json").Build();
        }   

        public string PegarCaminhoDeEntrada()
        {
            return config.GetSection("Diretorios").GetSection("RepositorioEntrada").Value;
        }

        public string PegarCaminhoDeSaida()
        {

            return config.GetSection("Diretorios").GetSection("RepositorioSaida").Value; 
        }
        public string PegarCaminhoDeSaidaParaErro()
        {

            return config.GetSection("Diretorios").GetSection("RepositorioErro").Value;
        }
    }
}
