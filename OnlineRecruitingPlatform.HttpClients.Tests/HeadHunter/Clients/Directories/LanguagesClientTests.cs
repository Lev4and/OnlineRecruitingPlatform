using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Directories
{
    public class LanguagesClientTests
    {
        private readonly LanguagesClient _client;

        public LanguagesClientTests()
        {
            _client = new LanguagesClient();
        }

        [Fact]
        public async Task GetLanguages_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetLanguages();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LanguageIV[]>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<LanguageIV[]>();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
