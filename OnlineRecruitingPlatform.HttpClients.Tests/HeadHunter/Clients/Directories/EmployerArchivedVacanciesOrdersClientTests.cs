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
    public class EmployerArchivedVacanciesOrdersClientTests
    {
        private readonly EmployerArchivedVacanciesOrdersClient _client;

        public EmployerArchivedVacanciesOrdersClientTests()
        {
            _client = new EmployerArchivedVacanciesOrdersClient();
        }

        [Fact]
        public async Task GetEmployerArchivedVacanciesOrders_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetEmployerArchivedVacanciesOrders();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EmployerArchivedVacanciesOrdersDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.EmployerArchivedVacanciesOrders.Should().BeOfType<EmployerArchivedVacanciesOrder[]>();
            result.EmployerArchivedVacanciesOrders.Should().HaveCountGreaterThan(0);
        }
    }
}
