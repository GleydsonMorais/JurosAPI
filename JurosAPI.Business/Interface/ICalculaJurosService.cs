using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JurosAPI.Business.Interface
{
    public interface ICalculaJurosService
    {
        Task<string> CalculaJuros(decimal valorInicial, int tempo);
    }
}
