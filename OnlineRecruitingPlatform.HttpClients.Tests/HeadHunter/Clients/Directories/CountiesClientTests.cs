using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Directories
{
    public class CountiesClientTests
    {
        private readonly CountiesClient _client;

        public CountiesClientTests()
        {
            _client = new CountiesClient();
        }

        [Fact]
        public async Task GetCounties_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCounties();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CountryIV[]>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<CountryIV[]>();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
