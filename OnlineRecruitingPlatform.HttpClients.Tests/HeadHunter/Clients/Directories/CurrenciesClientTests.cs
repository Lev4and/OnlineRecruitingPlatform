using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Directories
{
    public class CurrenciesClientTests
    {
        private readonly CurrenciesClient _client;

        public CurrenciesClientTests()
        {
            _client = new CurrenciesClient();
        }

        [Fact]
        public async Task GetCurrencies_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCurrencies();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CurrenciesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Currencies.Should().BeOfType<Currency[]>();
            result.Currencies.Should().HaveCountGreaterThan(0);
        }
    }
}
