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
    public class ExperiencesClientTests
    {
        private readonly ExperiencesClient _client;

        public ExperiencesClientTests()
        {
            _client = new ExperiencesClient();
        }

        [Fact]
        public async Task GetExperiences_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetExperiences();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ExperiencesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Experiences.Should().BeOfType<Experience[]>();
            result.Experiences.Should().HaveCountGreaterThan(0);
        }
    }
}
