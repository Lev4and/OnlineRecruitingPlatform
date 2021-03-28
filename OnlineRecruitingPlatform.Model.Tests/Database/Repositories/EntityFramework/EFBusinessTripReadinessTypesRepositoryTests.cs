using FluentAssertions;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Tests.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Model.Tests.Database.Repositories.EntityFramework
{
    [TestCaseOrderer("OnlineRecruitingPlatform.Model.Tests.TestCaseOrdering.PriorityOrderer", "OnlineRecruitingPlatform.Model.Tests")]
    public class EFBusinessTripReadinessTypesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsBusinessTripReadiness_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.BusinessTripReadinessTypes.ContainsBusinessTripReadiness(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsBusinessTripReadiness_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.ContainsBusinessTripReadiness("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsBusinessTripReadiness_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.ContainsBusinessTripReadiness("готов к командировкам");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveBusinessTripReadiness_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.BusinessTripReadinessTypes.SaveBusinessTripReadiness(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveBusinessTripReadiness_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.SaveBusinessTripReadiness(
                    new BusinessTripReadiness()
                    {
                        Name = "Тестовое значение"
                    });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveBusinessTripReadiness_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.SaveBusinessTripReadiness(
                    new BusinessTripReadiness()
                    {
                        Id = Guid.Parse("a935b5b1-1ac3-40fe-9fdc-eb497471390b"),
                        Name = "готов к командировкам"
                    });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveBusinessTripReadiness_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.SaveBusinessTripReadiness(
                    new Func<BusinessTripReadiness>(() =>
                    {
                        var entity = _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveBusinessTripReadiness_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.SaveBusinessTripReadiness(new Func<BusinessTripReadiness>(() =>
                {
                    return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness("Тестовое значение 2", true);

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetBusinessTripReadiness_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetBusinessTripReadiness_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<BusinessTripReadiness>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness(Guid.Parse("a935b5b1-1ac3-40fe-9fdc-eb497471390b"));
            });

            result.Should().NotBe(default(BusinessTripReadiness));
        }

        [Fact, TestPriority(11)]
        public async Task GetBusinessTripReadiness_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<BusinessTripReadiness>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness(Guid.NewGuid());
            });

            result.Should().Be(default(BusinessTripReadiness));
        }

        [Fact, TestPriority(12)]
        public async Task GetBusinessTripReadiness_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetBusinessTripReadiness_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<BusinessTripReadiness>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness("Тестовое значение 2");
            });

            result.Should().NotBe(default(BusinessTripReadiness));
        }

        [Fact, TestPriority(14)]
        public async Task GetBusinessTripReadiness_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<BusinessTripReadiness>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness("Тестовое значение 3");
            });

            result.Should().Be(default(BusinessTripReadiness));
        }

        [Fact, TestPriority(15)]
        public async Task GetBusinessTripReadinessTypes_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<BusinessTripReadiness>>(() =>
            {
                return _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadinessTypes().ToList();
            });

            result.Should().BeOfType<List<BusinessTripReadiness>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteBusinessTripReadiness_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.BusinessTripReadinessTypes.DeleteBusinessTripReadiness(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteBusinessTripReadiness_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.BusinessTripReadinessTypes.GetBusinessTripReadiness("Тестовое значение 2");

                _dataManager.BusinessTripReadinessTypes.DeleteBusinessTripReadiness(entity.Id);

                return _dataManager.BusinessTripReadinessTypes.ContainsBusinessTripReadiness("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
