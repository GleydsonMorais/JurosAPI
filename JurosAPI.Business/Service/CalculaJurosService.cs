using JurosAPI.Business.Interface;
using JurosAPI.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JurosAPI.Business.Service
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly IJurosRepository _jurosRepository;

        public CalculaJurosService(IJurosRepository jurosRepository)
        {
            _jurosRepository = jurosRepository;
        }

        public async Task<string> CalculaJuros(decimal valorInicial, int tempo)
        {
            var taxaJuros = await _jurosRepository.GetTaxaJuros();

            return (valorInicial * (decimal)(Math.Pow((1 + Convert.ToDouble(taxaJuros)), tempo))).ToString("F");
        }
    }
}
