using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Models;
using Xunit;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.ControllerTests.Controllers
{
    public class AccountControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Login_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("Account/Login");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Login_WithNullParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Login", new StringContent("", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Login_WithNullViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel()), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Login_WithViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new LoginViewModel(){ Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Login_WithInvalidViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Login", new StringContent(JsonConvert.SerializeObject(new RegisterViewModel() { Email = "andrey.levchenko.2001@yandex.ru", Login = "Lev4and", Password = "!Lev4and", RoleId = "2AABA004-1052-4F53-9EB3-18FA85386AD5" }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Register_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("Account/Register");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Register_WithNullParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Register", new StringContent("", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Register_WithNullViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Register", new StringContent(JsonConvert.SerializeObject(new RegisterViewModel()), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Register_WithViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Register", new StringContent(JsonConvert.SerializeObject(new RegisterViewModel(){ Email = "andrey.levchenko.2001@yandex.ru", Login = "Lev4and", Password = "!Lev4and", RoleId = "2AABA004-1052-4F53-9EB3-18FA85386AD5" }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Register_WithInvalidViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/Register", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task ForgetPassword_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("Account/ForgetPassword");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task ForgetPassword_WithNullParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/ForgetPassword", new StringContent("", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task ForgetPassword_WithNullViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/ForgetPassword", new StringContent(JsonConvert.SerializeObject(new ForgetPasswordViewModel()), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task ForgetPassword_WithViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/ForgetPassword", new StringContent(JsonConvert.SerializeObject(new ForgetPasswordViewModel(){ Email = "andrey.levchenko.2001@gmail.com" }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task ForgetPassword_WithInvalidViewModelParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync("Account/ForgetPassword", new StringContent(JsonConvert.SerializeObject(new LoginViewModel() { Email = "andrey.levchenko.2001@gmail.com", Password = "!Lev4and*" }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }

        [Fact]
        public async Task Logout_WithoutAnyParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync("Account/Logout");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Headers.ContentType.MediaType.Should().Be("text/html");
        }
    }
}
