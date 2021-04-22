using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Clients;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Formatters;
using OnlineRecruitingPlatform.Model.API.DaDataRu.OKVED2;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.DaDataRu.OKVED2.Clients
{
    public class IndustriesClientTests
    {
        private readonly IndustriesClient _client;

        public IndustriesClientTests()
        {
            _client = new IndustriesClient();
        }

        [Fact]
        public async Task GetIndustry_WithParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetIndustry(new OKVED(1));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SuggestionsIndustriesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Suggestions.Should().BeOfType<Suggestion<IndustryIV>[]>();
            result.Suggestions.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetIndustry_WithInvalidParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetIndustry(new OKVED(0));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SuggestionsIndustriesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Suggestions.Should().BeOfType<Suggestion<IndustryIV>[]>();
            result.Suggestions.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetIndustry_WithNullStringParam_ReturnNullResponse()
        {
            var response = await _client.GetIndustry(null);

            response.Should().BeNull();
        }
    }
}
