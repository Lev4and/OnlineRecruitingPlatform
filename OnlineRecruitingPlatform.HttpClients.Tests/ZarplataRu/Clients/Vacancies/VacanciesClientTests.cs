using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients.Vacancies;
using OnlineRecruitingPlatform.Model.API.ZarplataRu;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OnlineRecruitingPlatform.Model.Gzip;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.ZarplataRu.Clients.Vacancies
{
    public class VacanciesClientTests
    {
        private readonly VacanciesClient _client;

        public VacanciesClientTests()
        {
            _client = new VacanciesClient();
        }

        [Fact]
        public async Task GetVacancies_WithZoroParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetVacancies(0, 0);
            var resultByteArrayGzip = await response.Content.ReadAsByteArrayAsync();
            var resultByteArray = Decompresser.Decompress(resultByteArrayGzip);
            var resultString = Encoding.UTF8.GetString(resultByteArray, 0, resultByteArray.Length);
            var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Vacancies.Should().NotBeNull();
            result.Vacancies.Length.Should().Be(0);
        }

        [Fact]
        public async Task GetVacancies_WithNormalParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetVacancies(100, 100);
            var resultByteArrayGzip = await response.Content.ReadAsByteArrayAsync();
            var resultByteArray = Decompresser.Decompress(resultByteArrayGzip);
            var resultString = Encoding.UTF8.GetString(resultByteArray, 0, resultByteArray.Length);
            var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Vacancies.Should().NotBeNull();
            result.Vacancies.Length.Should().Be(100);
        }

        [Fact]
        public async Task GetVacancies_WithLargeParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.GetVacancies(100, 10000);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
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
            var response = await _client.GetVacancy(201718465);
            var resultByteArrayGzip = await response.Content.ReadAsByteArrayAsync();
            var resultByteArray = Decompresser.Decompress(resultByteArrayGzip);
            var resultString = Encoding.UTF8.GetString(resultByteArray, 0, resultByteArray.Length);
            var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Vacancies.Should().NotBeNull();
            result.Vacancies.Length.Should().Be(1);
            result.Vacancies[0].Should().BeOfType<VacancyIV>();
        }
    }
}
