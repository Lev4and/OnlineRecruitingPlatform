using System;
using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Vacancies;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Vacancies;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Vacancies
{
    public class VacanciesClientTests
    {
        private readonly VacanciesClient _client;

        public VacanciesClientTests()
        {
            _client = new VacanciesClient();
        }

        [Fact]
        public async Task GetVacancy_WithNegativeParam_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetVacancy(-1);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetVacancy_WithZeroParam_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetVacancy(0);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetVacancy_WithPositiveNoExistedIdParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetVacancy(1);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetVacancy_WithPositiveExistedIdParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetVacancy(44331626);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VacancyIV>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().NotBeNull();
            result.Should().BeOfType<VacancyIV>();
        }

        [Fact]
        public async Task GetVacancies_WithCorrectParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetVacancies(new DateTime(2021, 5, 10, 12, 0, 0), new DateTime(2021, 5, 10, 16, 0, 0), 1, 1);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Vacancies.Should().NotBeNull();
            result.Vacancies.Should().BeOfType<VacancyIV[]>();
            result.Vacancies.Should().HaveCountGreaterThan(0);
        }
    }
}
