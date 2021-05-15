using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.CLADR.Clients;
using OnlineRecruitingPlatform.Model.API.CLADR;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.CLADR.Clients
{
    public class FIASClientTests
    {
        private readonly FIASClient _client;

        public FIASClientTests()
        {
            _client = new FIASClient();
        }

        [Fact]
        public async Task GetBuilding_WithCorrectParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetBuilding("Москва, Лесная улица, 7");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultContent>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Contents.Should().BeOfType<Content[]>();
            result.Contents.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetBuilding_WithCorrectSearchStringAndTrueWithParentParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetBuilding("Москва, Лесная улица, 7", true);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultContent>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Contents.Should().BeOfType<Content[]>();
            result.Contents.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetRegion_WithCorrectSearchStringParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetRegion("Челябинская область");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultContent>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Contents.Should().BeOfType<Content[]>();
            result.Contents.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetCity_WithCorrectSearchStringParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCity("Город Челябинск");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultContent>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Contents.Should().BeOfType<Content[]>();
            result.Contents.Should().HaveCountGreaterThan(0);
        }
    }
}
