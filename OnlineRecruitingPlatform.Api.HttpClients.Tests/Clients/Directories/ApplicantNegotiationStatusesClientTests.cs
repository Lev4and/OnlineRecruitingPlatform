using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories;
using OnlineRecruitingPlatform.Api.HttpClients.Tests.Attributes;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Api.HttpClients.Tests.Clients.Directories
{
    [TestCaseOrderer("OnlineRecruitingPlatform.Api.HttpClients.Tests.TestCaseOrdering.PriorityOrderer", "OnlineRecruitingPlatform.Api.HttpClients.Tests")]
    public class ApplicantNegotiationStatusesClientTests : IntegrationTest
    {
        private string _badParam;

        private Guid _existentEntityId;

        private ApplicantNegotiationStatus _existentEntity;
        private ApplicantNegotiationStatus _existentEntityWithDefaultId;

        private ApplicantNegotiationStatus _nonExistentEntity;
        private ApplicantNegotiationStatus _nonExistentEntityWithDefaultId;

        private readonly ApplicantNegotiationStatusesClient _applicantNegotiationStatusesClient;

        public ApplicantNegotiationStatusesClientTests()
        {
            _badParam = "BadParam";

            _existentEntityId = Guid.Parse("d0397f1b-8e31-40b4-a450-0f200649f1a3");

            _existentEntity = new ApplicantNegotiationStatus() { Id = _existentEntityId, Name = "Все" };
            _existentEntityWithDefaultId = new ApplicantNegotiationStatus() { Name = "Все" };

            _nonExistentEntity = new ApplicantNegotiationStatus() { Name = "Тестовое значение" };
            _nonExistentEntityWithDefaultId = new ApplicantNegotiationStatus() { Name = "Тестовое значение" };

            _applicantNegotiationStatusesClient = new ApplicantNegotiationStatusesClient(_client);
        }

        [Fact, TestPriority(1)]
        public async Task GetApplicantNegotiationStatuses_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantNegotiationStatusesClient.GetApplicantNegotiationStatuses();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ApplicantNegotiationStatus>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<List<ApplicantNegotiationStatus>>();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task GetApplicantNegotiationStatus_WithInvalidParams_ReturnFormatException()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _applicantNegotiationStatusesClient.GetApplicantNegotiationStatus(Guid.Parse($"{_badParam}"));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(3)]
        public async Task GetApplicantNegotiationStatus_WithNonExistentDataParams_ReturnHttpStatusCode204Response()
        {
            var response = await _applicantNegotiationStatusesClient.GetApplicantNegotiationStatus(Guid.NewGuid());

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(4)]
        public async Task GetApplicantNegotiationStatus_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantNegotiationStatusesClient.GetApplicantNegotiationStatus(_existentEntityId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApplicantNegotiationStatus>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<ApplicantNegotiationStatus>();
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(5)]
        public async Task AddApplicantNegotiationStatus_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantNegotiationStatusesClient.AddApplicantNegotiationStatus(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(6)]
        public async Task AddApplicantNegotiationStatus_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantNegotiationStatusesClient.AddApplicantNegotiationStatus(_existentEntity);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(7)]
        public async Task AddApplicantNegotiationStatus_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantNegotiationStatusesClient.AddApplicantNegotiationStatus(_existentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(8)]
        public async Task AddApplicantNegotiationStatus_WithNonExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantNegotiationStatusesClient.AddApplicantNegotiationStatus(_nonExistentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(9)]
        public async Task UpdateApplicantNegotiationStatus_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantNegotiationStatusesClient.UpdateApplicantNegotiationStatus(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(10)]
        public async Task UpdateApplicantNegotiationStatus_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantNegotiationStatusesClient.UpdateApplicantNegotiationStatus(_nonExistentEntityWithDefaultId);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(11)]
        public async Task UpdateApplicantNegotiationStatus_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetApplicantNegotiationStatusId(_nonExistentEntity.Name);

            var response = await _applicantNegotiationStatusesClient.UpdateApplicantNegotiationStatus(_nonExistentEntity);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(12)]
        public async Task UpdateApplicantNegotiationStatus_WithNonExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetApplicantNegotiationStatusId(_nonExistentEntity.Name);
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _applicantNegotiationStatusesClient.UpdateApplicantNegotiationStatus(_nonExistentEntity);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(13)]
        public async Task DeleteApplicantNegotiationStatus_WithInvalidParams_ReturnFormatException()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _applicantNegotiationStatusesClient.DeleteApplicantNegotiationStatus(Guid.Parse($"{_badParam}"));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(14)]
        public async Task DeleteApplicantNegotiationStatus_WithParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity = new ApplicantNegotiationStatus();
            _nonExistentEntity.Id = await GetApplicantNegotiationStatusId("Тестовое значение 2");
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _applicantNegotiationStatusesClient.DeleteApplicantNegotiationStatus(_nonExistentEntity.Id);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        private async Task<Guid> GetApplicantNegotiationStatusId(string name)
        {
            var response = await _applicantNegotiationStatusesClient.GetApplicantNegotiationStatuses();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ApplicantNegotiationStatus>>(resultJson);

            return result.SingleOrDefault(a => a.Name == name).Id;
        }
    }
}
