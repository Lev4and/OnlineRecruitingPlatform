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
    public class ApplicantCommentsOrdersClientTests
    {
        private readonly ApplicantCommentsOrdersClient _client;

        public ApplicantCommentsOrdersClientTests()
        {
            _client = new ApplicantCommentsOrdersClient();
        }

        [Fact]
        public async Task GetApplicantCommentsOrders_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetApplicantCommentsOrders();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApplicantCommentsOrdersDirectory<ApplicantCommentsOrderIV>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.ApplicantCommentsOrders.Should().BeOfType<ApplicantCommentsOrderIV[]>();
            result.ApplicantCommentsOrders.Should().HaveCountGreaterThan(0);
        }
    }
}
