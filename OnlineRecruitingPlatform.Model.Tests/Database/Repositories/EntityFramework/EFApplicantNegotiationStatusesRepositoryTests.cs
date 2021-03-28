using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Tests.Attributes;
using Xunit;

namespace OnlineRecruitingPlatform.Model.Tests.Database.Repositories.EntityFramework
{
    [TestCaseOrderer("OnlineRecruitingPlatform.Model.Tests.TestCaseOrdering.PriorityOrderer", "OnlineRecruitingPlatform.Model.Tests")]
    public class EFApplicantNegotiationStatusesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsApplicantNegotiationStatus_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.ApplicantNegotiationStatuses.ContainsApplicantNegotiationStatus(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsApplicantNegotiationStatus_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.ContainsApplicantNegotiationStatus("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsApplicantNegotiationStatus_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.ContainsApplicantNegotiationStatus("Все");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveApplicantNegotiationStatus_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantNegotiationStatuses.SaveApplicantNegotiationStatus(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveApplicantNegotiationStatus_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.SaveApplicantNegotiationStatus(
                    new ApplicantNegotiationStatus()
                    {
                        Name = "Тестовое значение"
                    });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveApplicantNegotiationStatus_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.SaveApplicantNegotiationStatus(
                    new ApplicantNegotiationStatus()
                    {
                        Name = "Все"
                    });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveApplicantNegotiationStatus_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.SaveApplicantNegotiationStatus(
                    new Func<ApplicantNegotiationStatus>(() =>
                    {
                        var entity = _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveApplicantNegotiationStatus_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.SaveApplicantNegotiationStatus(new Func<ApplicantNegotiationStatus>(() =>
                {
                    return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus("Тестовое значение 2", true);

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetApplicantNegotiationStatus_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetApplicantNegotiationStatus_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<ApplicantNegotiationStatus>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus(Guid.Parse("d0397f1b-8e31-40b4-a450-0f200649f1a3"));
            });

            result.Should().NotBe(default(ApplicantNegotiationStatus));
        }

        [Fact, TestPriority(11)]
        public async Task GetApplicantNegotiationStatus_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<ApplicantNegotiationStatus>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus(Guid.NewGuid());
            });

            result.Should().Be(default(ApplicantNegotiationStatus));
        }

        [Fact, TestPriority(12)]
        public async Task GetApplicantNegotiationStatus_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetApplicantNegotiationStatus_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<ApplicantNegotiationStatus>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus("Тестовое значение 2");
            });

            result.Should().NotBe(default(ApplicantNegotiationStatus));
        }

        [Fact, TestPriority(14)]
        public async Task GetApplicantNegotiationStatus_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<ApplicantNegotiationStatus>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus("Тестовое значение 3");
            });

            result.Should().Be(default(ApplicantNegotiationStatus));
        }

        [Fact, TestPriority(15)]
        public async Task GetApplicantNegotiationStatuses_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<ApplicantNegotiationStatus>>(() =>
            {
                return _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatuses().ToList();
            });

            result.Should().BeOfType<List<ApplicantNegotiationStatus>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteApplicantNegotiationStatus_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantNegotiationStatuses.DeleteApplicantNegotiationStatus(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteApplicantNegotiationStatus_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.ApplicantNegotiationStatuses.GetApplicantNegotiationStatus("Тестовое значение 2");

                _dataManager.ApplicantNegotiationStatuses.DeleteApplicantNegotiationStatus(entity.Id);

                return _dataManager.ApplicantNegotiationStatuses.ContainsApplicantNegotiationStatus("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
