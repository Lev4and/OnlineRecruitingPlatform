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
    public class BusinessTripReadinessTypesControllerTests : IntegrationTest
    {
        private string _baseUrl;
        private string _badParam;

        private Guid _existentEntityId;

        private BusinessTripReadiness _existentEntity;
        private BusinessTripReadiness _existentEntityWithDefaultId;

        private BusinessTripReadiness _nonExistentEntity;
        private BusinessTripReadiness _nonExistentEntityWithDefaultId;

        public BusinessTripReadinessTypesControllerTests()
        {
            _baseUrl = "api/directories/businessTripReadinessTypes/";
            _badParam = "BadParam";

            _existentEntityId = Guid.Parse("75617930-6a72-4a02-aae2-b9f9a3afab86");

            _existentEntity = new BusinessTripReadiness() { Id = _existentEntityId, Name = "готов к редким командировкам" };
            _existentEntityWithDefaultId = new BusinessTripReadiness() { Name = "готов к редким командировкам" };

            _nonExistentEntity = new BusinessTripReadiness() { Name = "Тестовое значение" };
            _nonExistentEntityWithDefaultId = new BusinessTripReadiness() { Name = "Тестовое значение" };
        }

        [Fact, TestPriority(1)]
        public async Task GetBusinessTripReadinessTypes_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BusinessTripReadiness>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<List<BusinessTripReadiness>>();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task GetBusinessTripReadiness_WithInvalidParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}{_badParam}");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(3)]
        public async Task GetBusinessTripReadiness_WithNonExistentDataParams_ReturnHttpStatusCode204Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}{Guid.NewGuid()}");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(4)]
        public async Task GetBusinessTripReadiness_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetAsync($"{_baseUrl}{_existentEntityId}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BusinessTripReadiness>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<BusinessTripReadiness>();
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(5)]
        public async Task AddBusinessTripReadiness_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(null)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(6)]
        public async Task AddBusinessTripReadiness_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_existentEntity)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(7)]
        public async Task AddBusinessTripReadiness_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_existentEntityWithDefaultId)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(8)]
        public async Task AddBusinessTripReadiness_WithNonExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.PostAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntityWithDefaultId)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(9)]
        public async Task UpdateBusinessTripReadiness_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(null)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(10)]
        public async Task UpdateBusinessTripReadiness_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntityWithDefaultId)}", Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(11)]
        public async Task UpdateBusinessTripReadiness_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetBusinessTripReadinessId(_nonExistentEntity.Name);

            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntity)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(12)]
        public async Task UpdateBusinessTripReadiness_WithNonExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetBusinessTripReadinessId(_nonExistentEntity.Name);
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _client.PutAsync($"{_baseUrl}", new StringContent($"{JsonConvert.SerializeObject(_nonExistentEntity)}", Encoding.UTF8, "application/json"));
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(13)]
        public async Task DeleteBusinessTripReadiness_WithInvalidParams_ReturnHttpStatusCode400Response()
        {
            var response = await _client.DeleteAsync($"{_baseUrl}{_badParam}");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(14)]
        public async Task DeleteBusinessTripReadiness_WithParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity = new BusinessTripReadiness();
            _nonExistentEntity.Id = await GetBusinessTripReadinessId("Тестовое значение 2");
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _client.DeleteAsync($"{_baseUrl}{_nonExistentEntity.Id}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        private async Task<Guid> GetBusinessTripReadinessId(string name)
        {
            var response = await _client.GetAsync($"{_baseUrl}");
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BusinessTripReadiness>>(resultJson);

            return result.SingleOrDefault(a => a.Name == name).Id;
        }
    }
}
