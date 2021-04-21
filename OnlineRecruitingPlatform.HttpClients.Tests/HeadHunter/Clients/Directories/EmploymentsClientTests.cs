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
    public class EmploymentsClientTests
    {
        private readonly EmploymentsClient _client;

        public EmploymentsClientTests()
        {
            _client = new EmploymentsClient();
        }

        [Fact]
        public async Task GetEmployments_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetEmployments();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EmploymentsDirectory<EmploymentIV>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Employments.Should().BeOfType<EmploymentIV[]>();
            result.Employments.Should().HaveCountGreaterThan(0);
        }
    }
}
