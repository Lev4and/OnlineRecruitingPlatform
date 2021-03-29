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
    public class BusinessTripReadinessTypesClientTests
    {
        private readonly BusinessTripReadinessTypesClient _client;

        public BusinessTripReadinessTypesClientTests()
        {
            _client = new BusinessTripReadinessTypesClient();
        }

        [Fact]
        public async Task GetBusinessTripReadinessTypes_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetBusinessTripReadinessTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BusinessTripReadinessTypesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.BusinessTripReadinessTypes.Should().BeOfType<BusinessTripReadiness[]>();
            result.BusinessTripReadinessTypes.Should().HaveCountGreaterThan(0);
        }
    }
}
