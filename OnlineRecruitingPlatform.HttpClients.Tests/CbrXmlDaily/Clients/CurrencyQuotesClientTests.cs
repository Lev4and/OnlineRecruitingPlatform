using FluentAssertions;
using OnlineRecruitingPlatform.HttpClients.CbrXmlDaily.Clients;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.API.CbrXmlDaily;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.CbrXmlDaily.Clients
{
    public class CurrencyQuotesClientTests
    {
        private readonly CurrencyQuotesClient _client;

        public CurrencyQuotesClientTests()
        {
            _client = new CurrencyQuotesClient();
        }

        [Fact]
        public async Task GetCurrencyQuotes_WithTodayDateParam_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetCurrencyQuotes(DateTime.Now);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetCurrencyQuotes_WithMinValueDateParam_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetCurrencyQuotes(DateTime.MinValue);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetCurrencyQuotes_WithYesterdayParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCurrencyQuotes(DateTime.Now.AddDays(-1));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DailyCurrencyQuotes>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().NotBeNull();
            result.Should().BeOfType<DailyCurrencyQuotes>();

            result.CurrencyQuoteDirectory.Should().NotBeNull();
            result.CurrencyQuoteDirectory.Should().BeOfType<CurrencyQuoteDirectory>();

        }
    }
}
