using FluentAssertions;
using RetornaJuros.Fixtures;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JurosAPI.Test.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureRetornaJuros))]
    public class FixturesTestRetornaJuros
    {
        private readonly IntegrationTestFixture<StartupRetornaJuros> _integrationTestFixture;

        public FixturesTestRetornaJuros(IntegrationTestFixture<StartupRetornaJuros> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
        }

        [Fact]
        public async Task Get_ReturnsOkResponse_TaxaJuros()
        {
            var response = await _integrationTestFixture.Client.GetAsync("/api/juros/taxaJuros");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_CorrectContentType_TaxaJuros()
        {
            var response = await _integrationTestFixture.Client.GetAsync("/api/juros/taxaJuros");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }
    }
}
