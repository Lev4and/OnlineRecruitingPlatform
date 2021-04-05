using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories;
using OnlineRecruitingPlatform.Api.HttpClients.Tests.Attributes;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Api.HttpClients.Tests.Clients.Directories
{
    [TestCaseOrderer("OnlineRecruitingPlatform.Api.HttpClients.Tests.TestCaseOrdering.PriorityOrderer", "OnlineRecruitingPlatform.Api.HttpClients.Tests")]
    public class BusinessTripReadinessTypesClientTests : IntegrationTest
    {
        private string _badParam;

        private Guid _existentEntityId;

        private BusinessTripReadiness _existentEntity;
        private BusinessTripReadiness _existentEntityWithDefaultId;

        private BusinessTripReadiness _nonExistentEntity;
        private BusinessTripReadiness _nonExistentEntityWithDefaultId;

        private readonly BusinessTripReadinessTypesClient _businessTripReadinessTypesClient;

        public BusinessTripReadinessTypesClientTests()
        {
            _badParam = "BadParam";

            _existentEntityId = Guid.Parse("75617930-6a72-4a02-aae2-b9f9a3afab86");

            _existentEntity = new BusinessTripReadiness() { Id = _existentEntityId, Name = "готов к редким командировкам" };
            _existentEntityWithDefaultId = new BusinessTripReadiness() { Name = "готов к редким командировкам" };

            _nonExistentEntity = new BusinessTripReadiness() { Name = "Тестовое значение" };
            _nonExistentEntityWithDefaultId = new BusinessTripReadiness() { Name = "Тестовое значение" };

            _businessTripReadinessTypesClient = new BusinessTripReadinessTypesClient(_client);
        }

        [Fact, TestPriority(1)]
        public async Task GetBusinessTripReadinessTypes_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _businessTripReadinessTypesClient.GetBusinessTripReadinessTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BusinessTripReadiness>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<List<BusinessTripReadiness>>();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task GetBusinessTripReadiness_WithInvalidParams_ReturnFormatException()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _businessTripReadinessTypesClient.GetBusinessTripReadiness(Guid.Parse($"{_badParam}"));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(3)]
        public async Task GetBusinessTripReadiness_WithNonExistentDataParams_ReturnHttpStatusCode204Response()
        {
            var response = await _businessTripReadinessTypesClient.GetBusinessTripReadiness(Guid.NewGuid());

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(4)]
        public async Task GetBusinessTripReadiness_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _businessTripReadinessTypesClient.GetBusinessTripReadiness(_existentEntityId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BusinessTripReadiness>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<BusinessTripReadiness>();
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(5)]
        public async Task AddBusinessTripReadiness_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _businessTripReadinessTypesClient.AddBusinessTripReadiness(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(6)]
        public async Task AddBusinessTripReadiness_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _businessTripReadinessTypesClient.AddBusinessTripReadiness(_existentEntity);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(7)]
        public async Task AddBusinessTripReadiness_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _businessTripReadinessTypesClient.AddBusinessTripReadiness(_existentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(8)]
        public async Task AddBusinessTripReadiness_WithNonExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _businessTripReadinessTypesClient.AddBusinessTripReadiness(_nonExistentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(9)]
        public async Task UpdateBusinessTripReadiness_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _businessTripReadinessTypesClient.UpdateBusinessTripReadiness(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(10)]
        public async Task UpdateBusinessTripReadiness_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _businessTripReadinessTypesClient.UpdateBusinessTripReadiness(_nonExistentEntityWithDefaultId);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(11)]
        public async Task UpdateBusinessTripReadiness_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetBusinessTripReadinessId(_nonExistentEntity.Name);

            var response = await _businessTripReadinessTypesClient.UpdateBusinessTripReadiness(_nonExistentEntity);
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

            var response = await _businessTripReadinessTypesClient.UpdateBusinessTripReadiness(_nonExistentEntity);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(13)]
        public async Task DeleteBusinessTripReadiness_WithInvalidParams_ReturnHttpStatusCode400Response()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _businessTripReadinessTypesClient.DeleteBusinessTripReadiness(Guid.Parse($"{_badParam}"));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(14)]
        public async Task DeleteBusinessTripReadiness_WithParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity = new BusinessTripReadiness();
            _nonExistentEntity.Id = await GetBusinessTripReadinessId("Тестовое значение 2");
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _businessTripReadinessTypesClient.DeleteBusinessTripReadiness(_nonExistentEntity.Id);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        private async Task<Guid> GetBusinessTripReadinessId(string name)
        {
            var response = await _businessTripReadinessTypesClient.GetBusinessTripReadinessTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<BusinessTripReadiness>>(resultJson);

            return result.SingleOrDefault(a => a.Name == name).Id;
        }
    }
}
