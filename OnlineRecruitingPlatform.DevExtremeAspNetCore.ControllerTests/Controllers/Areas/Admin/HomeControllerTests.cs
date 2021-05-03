using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.ControllerTests.Controllers.Areas.Admin
{
    public class HomeControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Index_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            var response = await _client.GetAsync("/Admin/Home/Index");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }
    }
}
