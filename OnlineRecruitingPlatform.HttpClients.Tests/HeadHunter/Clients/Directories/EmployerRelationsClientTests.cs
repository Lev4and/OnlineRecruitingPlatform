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
    public class EmployerRelationsClientTests
    {
        private readonly EmployerRelationsClient _client;

        public EmployerRelationsClientTests()
        {
            _client = new EmployerRelationsClient();
        }

        [Fact]
        public async Task GetEmployerRelations_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetEmployerRelations();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EmployerRelationsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.EmployerRelations.Should().BeOfType<EmployerRelation[]>();
            result.EmployerRelations.Should().HaveCountGreaterThan(0);
        }
    }
}
