using JurosAPI.Business.Model.Config;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JurosAPI.Business.Repositories
{
    public interface IJurosRepository
    {
        Task<string> GetTaxaJuros();
    }

    public class JurosRepository : IJurosRepository
    {
        private readonly UrlAPIConfig _urlAPIConfig;

        public JurosRepository(IOptions<UrlAPIConfig> urlAPIConfig)
        {
            _urlAPIConfig = urlAPIConfig.Value;
        }

        public async Task<string> GetTaxaJuros()
        {
            RestClient Client = new RestClient(_urlAPIConfig.RetornaJuros);
            RestRequest request = new RestRequest("api/juros/taxaJuros", Method.GET);

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3;

            IRestResponse<string> response = await Client.ExecuteAsync<string>(request);

            return response.Data;
        }
    }
}
