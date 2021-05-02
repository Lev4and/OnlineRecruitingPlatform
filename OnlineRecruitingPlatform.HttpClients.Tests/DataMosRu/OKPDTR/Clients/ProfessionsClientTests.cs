using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DataMosRu.OKPDTR.Clients;
using OnlineRecruitingPlatform.Model.API.DataMosRu.OKPDTR;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Profession = OnlineRecruitingPlatform.Model.API.DataMosRu.OKPDTR.Profession;

namespace OnlineRecruitingPlatform.HttpClients.Tests.DataMosRu.OKPDTR.Clients
{
    public class ProfessionsClientTests
    {
        private readonly ProfessionsClient _client;

        public ProfessionsClientTests()
        {
            _client = new ProfessionsClient();
        }

        [Fact]
        public async Task GetProfessions_WithParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetProfessions();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Profession[]>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<Profession[]>();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
