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
    public class AreasClientTests
    {
        private readonly AreasClient _client;

        public AreasClientTests()
        {
            _client = new AreasClient();
        }

        [Fact]
        public async Task GetAreas_WithCurrentParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAreas(1384);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AreasDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Areas.Should().BeOfType<AreaIV[]>();
            result.Areas.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetAreas_WithInvalidParam_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetAreas(10000);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
