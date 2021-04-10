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
    public class EmployerActiveVacanciesOrdersClientTests
    {
        private readonly EmployerActiveVacanciesOrdersClient _client;

        public EmployerActiveVacanciesOrdersClientTests()
        {
            _client = new EmployerActiveVacanciesOrdersClient();
        }

        [Fact]
        public async Task GetEmployerActiveVacanciesOrders_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetEmployerActiveVacanciesOrders();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EmployerActiveVacanciesOrdersDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.EmployerActiveVacanciesOrders.Should().BeOfType<EmployerActiveVacanciesOrder[]>();
            result.EmployerActiveVacanciesOrders.Should().HaveCountGreaterThan(0);
        }
    }
}
