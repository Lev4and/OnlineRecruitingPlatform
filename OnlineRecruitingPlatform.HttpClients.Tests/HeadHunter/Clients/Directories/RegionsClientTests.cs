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
    public class RegionsClientTests
    {
        private readonly RegionsClient _client;

        public RegionsClientTests()
        {
            _client = new RegionsClient();
        }

        [Fact]
        public async Task GetCounties_WithCurrentParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetRegions(113);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RegionsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Regions.Should().BeOfType<RegionIV[]>();
            result.Regions.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetCounties_WithInvalidParam_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetRegions(250);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
