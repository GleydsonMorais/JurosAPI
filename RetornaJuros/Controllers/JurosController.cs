using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurosAPI.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RetornaJuros.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly IRetornaJurosService _retornaJurosService;

        public JurosController(IRetornaJurosService retornaJurosService)
        {
            _retornaJurosService = retornaJurosService;
        }

        // GET: api/juros/taxajuros
        [HttpGet]
        [Route("api/juros/taxaJuros")]
        public string GetTaxaJuros() => _retornaJurosService.GetTaxaJuros();
    }
}
