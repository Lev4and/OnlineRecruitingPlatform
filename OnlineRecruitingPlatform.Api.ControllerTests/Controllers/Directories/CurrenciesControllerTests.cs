using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Api.ControllerTests.Attributes;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Api.ControllerTests.Controllers.Directories
{
    [TestCaseOrderer("OnlineRecruitingPlatform.Api.ControllerTests.TestCaseOrdering.PriorityOrderer", "OnlineRecruitingPlatform.Api.ControllerTests")]
    public class CurrenciesControllerTests : IntegrationTest
    {
        private string _baseUrl;
        private string _badParam;

        private Guid _existentEntityId;

        private Currency _existentEntity;
        private Currency _existentEntityWithDefaultId;

        private Currency _nonExistentEntity;
        private Currency _nonExistentEntityWithDefaultId;

        public CurrenciesControllerTests()
        {
            _baseUrl = "api/directories/currencies/";
            _badParam = "BadParam";

            _existentEntityId = Guid.Parse("54e54987-a36b-4276-a792-bd6e03e40ca6");

            _existentEntity = new Currency() { Id = _existentEntityId, Code = "RUB", Abbreviation = "Russian Ruble", Designation = "₽", Name = "Российский рубль" };
            _existentEntityWithDefaultId = new Currency() { Code = "RUB", Abbreviation = "Russian Ruble", Designation = "₽", Name = "Российский рубль" };

            _nonExistentEntity = new Currency() { Code = "TEST", Abbreviation = "Test Currency", Designation = "$", Name = "Тестовая валюта" };
            _nonExistentEntityWithDefaultId = new Currency() { Code = "TEST", Abbreviation = "Test Currency", Designation = "$", Name = "Тестовая валюта" };
        }

        [Fact, TestPriority(1)]
        public async Task GetCurrencies_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Currency>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<List<Currency>>();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task GetCurrency_WithInvalidParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}{_badParam}");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(3)]
        public async Task GetCurrency_WithNonExistentDataParams_ReturnHttpStatusCode204Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}{Guid.NewGuid()}");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(4)]
        public async Task GetCurrency_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}{_existentEntityId}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Currency>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<Currency>();
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(5)]
        public async Task AddCurrency_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(null)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(6)]
        public async Task AddCurrency_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_existentEntity)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(7)]
        public async Task AddCurrency_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_existentEntityWithDefaultId)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(8)]
        public async Task AddCurrency_WithNonExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntityWithDefaultId)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(9)]
        public async Task UpdateCurrency_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(null)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(10)]
        public async Task UpdateCurrency_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntityWithDefaultId)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(11)]
        public async Task UpdateCurrency_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetCurrenciesId(_nonExistentEntity.Name);

            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntity)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(12)]
        public async Task UpdateCurrency_WithNonExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetCurrenciesId(_nonExistentEntity.Name);
            _nonExistentEntity.Name = "Тестовая валюта 2";

            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntity)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(13)]
        public async Task DeleteCurrency_WithInvalidParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.DeleteAsync($"{_baseUrl}{_badParam}");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(14)]
        public async Task DeleteCurrency_WithParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity = new Currency();
            _nonExistentEntity.Id = await GetCurrenciesId("Тестовая валюта 2");
            _nonExistentEntity.Name = "Тестовая валюта 2";

            var response = await _client.DeleteAsync($"{_baseUrl}{_nonExistentEntity.Id}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        private async Task<Guid> GetCurrenciesId(string name)
        {
            var response = await _client.GetAsync($"{_baseUrl}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Currency>>(resultJson);

            return result.SingleOrDefault(a => a.Name == name).Id;
        }
    }
}
