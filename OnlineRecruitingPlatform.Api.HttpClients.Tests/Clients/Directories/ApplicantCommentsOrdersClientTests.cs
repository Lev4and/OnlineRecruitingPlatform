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
    public class ApplicantCommentsOrdersClientTests : IntegrationTest
    {
        private string _badParam;

        private Guid _existentEntityId;

        private ApplicantCommentsOrder _existentEntity;
        private ApplicantCommentsOrder _existentEntityWithDefaultId;

        private ApplicantCommentsOrder _nonExistentEntity;
        private ApplicantCommentsOrder _nonExistentEntityWithDefaultId;

        private readonly ApplicantCommentsOrdersClient _applicantCommentsOrdersClient;

        public ApplicantCommentsOrdersClientTests()
        {
            _badParam = "BadParam";

            _existentEntityId = Guid.Parse("3b8e2de5-ed50-4412-9e87-6b6d6a88e6e7");

            _existentEntity = new ApplicantCommentsOrder() { Id = _existentEntityId, Name = "по убыванию даты публикации" };
            _existentEntityWithDefaultId = new ApplicantCommentsOrder() { Name = "по убыванию даты публикации" };

            _nonExistentEntity = new ApplicantCommentsOrder() { Name = "Тестовое значение" };
            _nonExistentEntityWithDefaultId = new ApplicantCommentsOrder() { Name = "Тестовое значение" };

            _applicantCommentsOrdersClient = new ApplicantCommentsOrdersClient(_client);
        }

        [Fact, TestPriority(1)]
        public async Task GetApplicantCommentsOrders_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentsOrdersClient.GetApplicantCommentsOrders();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ApplicantCommentsOrder>>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<List<ApplicantCommentsOrder>>();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(2)]
        public async Task GetApplicantCommentsOrder_WithInvalidParams_ReturnFormatException()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _applicantCommentsOrdersClient.GetApplicantCommentsOrder(Guid.Parse($"{_badParam}"));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(3)]
        public async Task GetApplicantCommentsOrder_WithNonExistentDataParams_ReturnHttpStatusCode204Response()
        {
            var response = await _applicantCommentsOrdersClient.GetApplicantCommentsOrder(Guid.NewGuid());

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(4)]
        public async Task GetApplicantCommentsOrder_WithParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentsOrdersClient.GetApplicantCommentsOrder(_existentEntityId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApplicantCommentsOrder>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<ApplicantCommentsOrder>();
            result.Should().NotBeNull();
        }

        [Fact, TestPriority(5)]
        public async Task AddApplicantCommentsOrder_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentsOrdersClient.AddApplicantCommentsOrder(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(6)]
        public async Task AddApplicantCommentsOrder_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentsOrdersClient.AddApplicantCommentsOrder(_existentEntity);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(7)]
        public async Task AddApplicantCommentsOrder_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentsOrdersClient.AddApplicantCommentsOrder(_existentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(8)]
        public async Task AddApplicantCommentsOrder_WithNonExistentDataWithDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            var response = await _applicantCommentsOrdersClient.AddApplicantCommentsOrder(_nonExistentEntityWithDefaultId);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(9)]
        public async Task UpdateApplicantCommentsOrder_WithNullParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentsOrdersClient.UpdateApplicantCommentsOrder(null);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(10)]
        public async Task UpdateApplicantCommentsOrder_WithExistentDataWithDefaultIdParams_ReturnHttpStatusCode400Response()
        {
            var response = await _applicantCommentsOrdersClient.UpdateApplicantCommentsOrder(_nonExistentEntityWithDefaultId);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact, TestPriority(11)]
        public async Task UpdateApplicantCommentsOrder_WithExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetApplicantCommentsOrderId(_nonExistentEntity.Name);

            var response = await _applicantCommentsOrdersClient.UpdateApplicantCommentsOrder(_nonExistentEntity);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeFalse();
        }

        [Fact, TestPriority(12)]
        public async Task UpdateApplicantCommentsOrder_WithNonExistentDataWithNotDefaultIdParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity.Id = await GetApplicantCommentsOrderId(_nonExistentEntity.Name);
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _applicantCommentsOrdersClient.UpdateApplicantCommentsOrder(_nonExistentEntity);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        [Fact, TestPriority(13)]
        public async Task DeleteApplicantCommentsOrder_WithInvalidParams_ReturnFormatException()
        {
            await Task.Run(() =>
            {
                new Func<Task>(async () =>
                {
                    await _applicantCommentsOrdersClient.DeleteApplicantCommentsOrder(Guid.Parse($"{_badParam}"));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(14)]
        public async Task DeleteApplicantCommentsOrder_WithParams_ReturnHttpStatusCode200Response()
        {
            _nonExistentEntity = new ApplicantCommentsOrder();
            _nonExistentEntity.Id = await GetApplicantCommentsOrderId("Тестовое значение 2");
            _nonExistentEntity.Name = "Тестовое значение 2";

            var response = await _applicantCommentsOrdersClient.DeleteApplicantCommentsOrder(_nonExistentEntity.Id);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<bool>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeTrue();
        }

        private async Task<Guid> GetApplicantCommentsOrderId(string name)
        {
            var response = await _applicantCommentsOrdersClient.GetApplicantCommentsOrders();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ApplicantCommentsOrder>>(resultJson);

            return result.SingleOrDefault(a => a.Name == name).Id;
        }
    }
}
