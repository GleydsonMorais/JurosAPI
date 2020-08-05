using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurosAPI.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class MinhaAPIController : ControllerBase
    {
        private readonly IMinhaAPIService _minhaAPIService;

        public MinhaAPIController(IMinhaAPIService minhaAPIService)
        {
            _minhaAPIService = minhaAPIService;
        }
        
        [HttpGet]
        [Route("api/minhaapi/showmethecode")]
        public string ShowMeTheCode() => _minhaAPIService.ShowMeTheCode();
    }
}
