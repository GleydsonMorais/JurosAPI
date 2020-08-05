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
    public class JurosController : ControllerBase
    {
        public readonly ICalculaJurosService _calculaJurosService;

        public JurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }
        
        [HttpGet]
        [Route("api/juros/calculajuros/{valorInicial}/{tempo}")]
        public async Task<decimal> CalculaJuros(decimal valorInicial, int tempo) => await _calculaJurosService.CalculaJuros(valorInicial, tempo);
    }
}
