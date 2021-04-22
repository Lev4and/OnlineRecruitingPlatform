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
    public class SubIndustriesClientTests
    {
        private readonly SubIndustriesClient _client;

        public SubIndustriesClientTests()
        {
            _client = new SubIndustriesClient();
        }

        [Fact]
        public async Task GetSubIndustry_WithParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSubIndustry(new OKVED(62, 0));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Suggestions.Should().BeOfType<Suggestion<SubIndustryIV>[]>();
            result.Suggestions.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetSubIndustry_WithInvalidParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSubIndustry(new OKVED(1));

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetSubIndustry_WithNullStringParam_ReturnNullResponse()
        {
            var response = await _client.GetSubIndustry(null);

            response.Should().BeNull();
        }
    }
}
