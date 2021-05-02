using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Directories
{
    public class ProfessionalAreasClientTests
    {
        private readonly ProfessionalAreasClient _client;

        public ProfessionalAreasClientTests()
        {
            _client = new ProfessionalAreasClient();
        }

        [Fact]
        public async Task GetProfessionalAreas_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetProfessionalAreas();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProfessionalAreaIV[]>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<ProfessionalAreaIV[]>();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
