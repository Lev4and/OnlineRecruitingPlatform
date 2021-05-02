using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Directories
{
    public class SpecializationsClientTests
    {
        private readonly SpecializationsClient _client;

        public SpecializationsClientTests()
        {
            _client = new SpecializationsClient();
        }

        [Fact]
        public async Task GetSpecializations_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSpecializations();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProfessionalAreaIVWithSpecializations[]>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<ProfessionalAreaIVWithSpecializations[]>();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
