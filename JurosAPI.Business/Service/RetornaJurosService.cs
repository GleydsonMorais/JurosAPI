using JurosAPI.Business.Interface;
using JurosAPI.Business.Model.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace JurosAPI.Business.Service
{
    public class RetornaJurosService : IRetornaJurosService
    {
        private readonly JurosConfig _jurosConfig;

        public RetornaJurosService(IOptions<JurosConfig> jurosConfig)
        {
            _jurosConfig = jurosConfig.Value;
        }

        public string GetTaxaJuros() => _jurosConfig.TaxaDeJurosAtual;
    }
}
