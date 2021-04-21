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
    public class GendersClientTests
    {
        private readonly GendersClient _client;

        public GendersClientTests()
        {
            _client = new GendersClient();
        }

        [Fact]
        public async Task GetGenders_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetGenders();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GendersDirectory<GenderIV>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Genders.Should().BeOfType<GenderIV[]>();
            result.Genders.Should().HaveCountGreaterThan(0);
        }
    }
}
