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
    public class LanguageLevelsClientTests
    {
        private readonly LanguageLevelsClient _client;

        public LanguageLevelsClientTests()
        {
            _client = new LanguageLevelsClient();
        }

        [Fact]
        public async Task GetLanguageLevels_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetLanguageLevels();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LanguageLevelsDirectory<LanguageLevelIV>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.LanguageLevels.Should().BeOfType<LanguageLevelIV[]>();
            result.LanguageLevels.Should().HaveCountGreaterThan(0);
        }
    }
}
