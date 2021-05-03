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
    public class FIASControllerTests : IntegrationTest
    {
        [Fact]
        private async Task Regions_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            var response = await _client.GetAsync("Admin/FIAS/Regions/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        private async Task Areas_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            var response = await _client.GetAsync("Admin/FIAS/Areas/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        private async Task Places_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            var response = await _client.GetAsync("Admin/FIAS/Places/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        private async Task Cities_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            var response = await _client.GetAsync("Admin/FIAS/Cities/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        private async Task Streets_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            var response = await _client.GetAsync("Admin/FIAS/Streets/");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
            response.RequestMessage.RequestUri.PathAndQuery.Should().Be("Admin/FIAS/Streets/");
        }
    }
}
