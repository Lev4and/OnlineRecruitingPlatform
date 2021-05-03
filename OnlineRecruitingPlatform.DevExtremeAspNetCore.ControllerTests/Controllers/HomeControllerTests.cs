using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.ControllerTests.Controllers
{
    public class HomeControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Index_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("/Home/Index");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }
    }
}
