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
    public class DriverLicenseTypesClientTests
    {
        private readonly DriverLicenseTypesClient _client;

        public DriverLicenseTypesClientTests()
        {
            _client = new DriverLicenseTypesClient();
        }

        [Fact]
        public async Task GetDriverLicenseTypes_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetDriverLicenseTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DriverLicenseTypesDirectory<DriverLicenseTypeIV>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.DriverLicenseTypes.Should().BeOfType<DriverLicenseTypeIV[]>();
            result.DriverLicenseTypes.Should().HaveCountGreaterThan(0);
        }
    }
}
