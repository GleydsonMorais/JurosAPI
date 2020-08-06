using CalculaJuros.Fixtures;
using RetornaJuros.Fixtures;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace JurosAPI.Test.IntegrationTests
{
    [CollectionDefinition(nameof(IntegrationApiTestFixtureRetornaJuros))]
    public class IntegrationApiTestFixtureRetornaJuros : ICollectionFixture<IntegrationTestFixture<StartupRetornaJuros>>
    {

    }

    [CollectionDefinition(nameof(IntegrationApiTestFixtureCalculaJuros))]
    public class IntegrationApiTestFixtureCalculaJuros : ICollectionFixture<IntegrationTestFixture<StartupCalculaJuros>>
    {

    }

    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly AppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestFixture()
        {
            var clientOptions = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new AppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }
        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
