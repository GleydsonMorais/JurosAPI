using JurosAPI.Business.Interface;
using JurosAPI.Business.Model.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace JurosAPI.Business.Service
{
    public class MinhaAPIService : IMinhaAPIService
    {
        private readonly MinhaAPIConfig _minhaAPIConfig;

        public MinhaAPIService(IOptions<MinhaAPIConfig> minhaAPIConfig)
        {
            _minhaAPIConfig = minhaAPIConfig.Value;
        }

        public string ShowMeTheCode() => _minhaAPIConfig.UrlCode;
    }
}
