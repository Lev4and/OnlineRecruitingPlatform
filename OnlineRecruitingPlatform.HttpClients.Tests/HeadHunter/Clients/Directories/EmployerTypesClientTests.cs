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
    public class EmployerTypesClientTests
    {
        private readonly EmployerTypesClient _client;

        public EmployerTypesClientTests()
        {
            _client = new EmployerTypesClient();
        }

        [Fact]
        public async Task GetEmployerTypes_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetEmployerTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EmployerTypesDirectory<EmployerTypeIV>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.EmployerTypes.Should().BeOfType<EmployerTypeIV[]>();
            result.EmployerTypes.Should().HaveCountGreaterThan(0);
        }
    }
}
