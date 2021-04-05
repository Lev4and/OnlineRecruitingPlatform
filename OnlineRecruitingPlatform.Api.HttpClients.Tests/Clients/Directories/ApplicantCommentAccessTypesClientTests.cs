using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories;
using OnlineRecruitingPlatform.Api.HttpClients.Tests.Attributes;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Api.HttpClients.Tests.Clients.Directories
{
    [TestCaseOrderer("OnlineRecruitingPlatform.Api.HttpClients.Tests.TestCaseOrdering.PriorityOrderer", "OnlineRecruitingPlatform.Api.HttpClients.Tests")]
    public class ApplicantCommentAccessTypesClientTests : IntegrationTest
    {
        private string _badParam;

        private Guid _existentEntityId;

        private ApplicantCommentAccessType _existentEntity;
        private ApplicantCommentAccessType _existentEntityWithDefaultId;

        private ApplicantCommentAccessType _nonExistentEntity;
        private ApplicantCommentAccessType _nonExistentEntityWithDefaultId;

        private readonly ApplicantCommentAccessTypesClient _applicantCommentAccessTypesClient;

        public ApplicantCommentAccessTypesClientTests()
        {
            _badParam = "BadParam";

            _existentEntityId = Guid.Parse("7f58d693-b60b-4bce-a6a3-412af6e3c941");

            _existentEntity = new ApplicantCommentAccessType() { Id = _existentEntityId, Name = "Виден только мне" };
            _existentEntityWithDefaultId = new ApplicantCommentAccessType() { Name = "Виден только мне" };

            _nonExistentEntity = new ApplicantCommentAccessType() { Name = "Тестовое значение" };
            _nonExistentEntityWithDefaultId = new ApplicantCommentAccessType() { Name = "Тестовое значение" };

            _applicantCommentAccessTypesClient = new ApplicantCommentAccessTypesClient(_client);
        }

        [Fact, TestPriority(1)]
        public async Task GetApplicantCommentAccessTypes_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentAccessTypesClient.GetApplicantCommentAccessTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ApplicantCommentAccessType>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<List<ApplicantCommentAccessType>>();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task GetApplicantCommentAccessType_WithInvalidParams_ReturnFormatException()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _applicantCommentAccessTypesClient.GetApplicantCommentAccessType(Guid.Parse($"{_badParam}"));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(3)]
        public async Task GetApplicantCommentAccessType_WithNonExistentDataParams_ReturnHttpStatusCode204Response()
        {
            var response = await _applicantCommentAccessTypesClient.GetApplicantCommentAccessType(Guid.NewGuid());

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(4)]
        public async Task GetApplicantCommentAccessType_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentAccessTypesClient.GetApplicantCommentAccessType(_existentEntityId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApplicantCommentAccessType>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<ApplicantCommentAccessType>();
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(5)]
        public async Task AddApplicantCommentAccessType_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentAccessTypesClient.AddApplicantCommentAccessType(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(6)]
        public async Task AddApplicantCommentAccessType_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentAccessTypesClient.AddApplicantCommentAccessType(_existentEntity);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(7)]
        public async Task AddApplicantCommentAccessType_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentAccessTypesClient.AddApplicantCommentAccessType(_existentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(8)]
        public async Task AddApplicantCommentAccessType_WithNonExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentAccessTypesClient.AddApplicantCommentAccessType(_nonExistentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(9)]
        public async Task UpdateApplicantCommentAccessType_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentAccessTypesClient.UpdateApplicantCommentAccessType(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(10)]
        public async Task UpdateApplicantCommentAccessType_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentAccessTypesClient.UpdateApplicantCommentAccessType(_nonExistentEntityWithDefaultId);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(11)]
        public async Task UpdateApplicantCommentAccessType_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetApplicantCommentAccessTypeId(_nonExistentEntity.Name);

            var response = await _applicantCommentAccessTypesClient.UpdateApplicantCommentAccessType(_nonExistentEntity);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(12)]
        public async Task UpdateApplicantCommentAccessType_WithNonExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetApplicantCommentAccessTypeId(_nonExistentEntity.Name);
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _applicantCommentAccessTypesClient.UpdateApplicantCommentAccessType(_nonExistentEntity);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(13)]
        public async Task DeleteApplicantCommentAccessType_WithInvalidParams_ReturnFormatException()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _applicantCommentAccessTypesClient.DeleteApplicantCommentAccessType(Guid.Parse(_badParam));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(14)]
        public async Task DeleteApplicantCommentAccessType_WithParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity = new ApplicantCommentAccessType();
            _nonExistentEntity.Id = await GetApplicantCommentAccessTypeId("Тестовое значение 2");
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _applicantCommentAccessTypesClient.DeleteApplicantCommentAccessType(_nonExistentEntity.Id);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        private async Task<Guid> GetApplicantCommentAccessTypeId(string name)
        {
            var response = await _applicantCommentAccessTypesClient.GetApplicantCommentAccessTypes();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ApplicantCommentAccessType>>(resultJson);

            return result.SingleOrDefault(a => a.Name == name).Id;
        }
    }
}
