using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Directories
{
    public class ApplicantCommentAccessTypesClientTests
    {
        private readonly ApplicantCommentAccessTypesClient _client;

        public ApplicantCommentAccessTypesClientTests()
        {
            _client = new ApplicantCommentAccessTypesClient();
        }

        [Fact]
        public async Task GetApplicantCommentAccessTypes_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetApplicantCommentAccessTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApplicantCommentAccessTypesDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.ApplicantCommentAccessTypes.Should().BeOfType<ApplicantCommentAccessType[]>();
            result.ApplicantCommentAccessTypes.Should().HaveCountGreaterThan(0);
        }
    }
}
