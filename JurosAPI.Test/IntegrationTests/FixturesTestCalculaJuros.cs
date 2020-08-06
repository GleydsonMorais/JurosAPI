using CalculaJuros.Fixtures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JurosAPI.Test.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureCalculaJuros))]
    public class FixturesTestCalculaJuros
    {
        private readonly IntegrationTestFixture<StartupCalculaJuros> _integrationTestFixture;

        public FixturesTestCalculaJuros(IntegrationTestFixture<StartupCalculaJuros> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Fact]
        public async Task Get_ReturnsOkResponse_CalculaJuros()
        {
            var response = await _integrationTestFixture.Client.GetAsync("/api/juros/calculajuros/100/5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_ReturnsOkResponse_ShowMeTheCode()
        {
            var response = await _integrationTestFixture.Client.GetAsync("/api/minhaapi/showmethecode");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_CorrectContentType_TaxaJuros()
        {
            var response = await _integrationTestFixture.Client.GetAsync("/api/minhaapi/showmethecode");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }

        [Fact]
        public void CalculaJuros()
        {
            var expected = "105,10";
            decimal valorInicial = 100;
            int tempo = 5;
            string taxaJuros = "0,01";

            var result = (valorInicial * (decimal)(Math.Pow((1 + Convert.ToDouble(taxaJuros)), tempo))).ToString("F");

            Assert.Equal(expected, result);
        }
    }
}
