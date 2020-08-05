using JurosAPI.Business.Interface;
using JurosAPI.Business.Model.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace JurosAPI.Business.Service
{
    public class JurosService : IRetornaJurosService, ICalculaJurosService
    {
        private readonly JurosConfig _jurosConfig;

        public JurosService(IOptions<JurosConfig> jurosConfig)
        {
            _jurosConfig = jurosConfig.Value;
        }

        public decimal GetTaxaJuros() => Convert.ToDecimal(_jurosConfig.TaxaDeJurosAtual);
    }
}
