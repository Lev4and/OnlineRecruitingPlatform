using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace OnlineRecruitingPlatform.Api.HttpClients.Tests
{
    public class IntegrationTest
    {
        protected private readonly HttpClient _client;

        public IntegrationTest()
        {
            _client = new WebApplicationFactory<Startup>().CreateClient();
        }
    }
}
