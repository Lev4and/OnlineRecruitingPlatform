using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DataMosRu.OKPDTR.Clients;
using OnlineRecruitingPlatform.Model.API.DataMosRu.OKPDTR;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.DataMosRu.OKPDTR.Clients
{
    public class PositionsClientTests
    {
        private readonly PositionsClient _client;

        public PositionsClientTests()
        {
            _client = new PositionsClient();
        }

        [Fact]
        public async Task GetPositions_WithParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetPositions();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Profession[]>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<Profession[]>();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
