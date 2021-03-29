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
    public class ApplicantNegotiationStatusesClientTests
    {
        private readonly ApplicantNegotiationStatusesClient _client;

        public ApplicantNegotiationStatusesClientTests()
        {
            _client = new ApplicantNegotiationStatusesClient();
        }

        [Fact]
        public async Task GetApplicantNegotiationStatuses_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetApplicantNegotiationStatuses();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApplicantNegotiationStatusesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.ApplicantNegotiationStatuses.Should().BeOfType<ApplicantNegotiationStatus[]>();
            result.ApplicantNegotiationStatuses.Should().HaveCountGreaterThan(0);
        }
    }
}
