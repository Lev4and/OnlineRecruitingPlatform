using FluentAssertions;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Companies;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Companies
{
    public class CompaniesClientTests
    {
        private readonly CompaniesClient _client;

        public CompaniesClientTests()
        {
            _client = new CompaniesClient();
        }

        [Fact]
        public async Task GetCompanies_WithNegativeParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCompanies(-1, -1);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompaniesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Companies.Should().BeOfType<CompanyIV[]>();
            result.Companies.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetCompanies_WithNegativePageNumberParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCompanies(-1);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompaniesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Companies.Should().BeOfType<CompanyIV[]>();
            result.Companies.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetCompanies_WithNegativePerPageParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCompanies(perPage: -1);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompaniesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Companies.Should().BeOfType<CompanyIV[]>();
            result.Companies.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetCompanies_WithLargeSomeKindOfParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCompanies(perPage: 100000);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompaniesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Companies.Should().BeOfType<CompanyIV[]>();
            result.Companies.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetCompanies_WithoutParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCompanies();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompaniesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Companies.Should().BeOfType<CompanyIV[]>();
            result.Companies.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetCompany_WithInvalidParam_ReturnHttpStatusCode404Response()
        {
            var response = await _client.GetCompany(-1);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetCompany_WithParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetCompany(1179134);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CompanyIV>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<CompanyIV>();
            result.Should().NotBeNull();
        }
    }
}
