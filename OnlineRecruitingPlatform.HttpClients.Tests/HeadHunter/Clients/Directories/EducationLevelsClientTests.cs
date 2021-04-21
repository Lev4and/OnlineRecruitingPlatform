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
    public class EducationLevelsClientTests
    {
        private readonly EducationLevelsClient _client;

        public EducationLevelsClientTests()
        {
            _client = new EducationLevelsClient();
        }

        [Fact]
        public async Task GetEducationLevels_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetEducationLevels();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EducationLevelsDirectory<EducationLevelIV>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.EducationLevels.Should().BeOfType<EducationLevelIV[]>();
            result.EducationLevels.Should().HaveCountGreaterThan(0);
        }
    }
}
