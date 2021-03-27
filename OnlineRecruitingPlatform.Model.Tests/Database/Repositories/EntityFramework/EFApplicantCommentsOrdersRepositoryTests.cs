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
    public class EFApplicantCommentsOrdersRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsApplicantCommentsOrder_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.ApplicantCommentsOrders.ContainsApplicantCommentsOrder(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsApplicantCommentsOrder_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.ContainsApplicantCommentsOrder("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsApplicantCommentsOrder_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.ContainsApplicantCommentsOrder("по убыванию даты публикации");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveApplicantCommentsOrder_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentsOrders.SaveApplicantCommentsOrder(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveApplicantCommentsOrder_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.SaveApplicantCommentsOrder(
                    new ApplicantCommentsOrder()
                    {
                        Name = "Тестовое значение"
                    });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveApplicantCommentsOrder_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.SaveApplicantCommentsOrder(
                    new ApplicantCommentsOrder()
                    {
                        Id = Guid.Parse("3b8e2de5-ed50-4412-9e87-6b6d6a88e6e7"),
                        Name = "по убыванию даты публикации"
                    });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveApplicantCommentsOrder_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.SaveApplicantCommentsOrder(
                    new Func<ApplicantCommentsOrder>(() =>
                    {
                        var entity = _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveApplicantCommentsOrder_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.SaveApplicantCommentsOrder(new Func<ApplicantCommentsOrder>(() =>
                {
                    return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder("Тестовое значение 2", true);

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetApplicantCommentsOrder_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetApplicantCommentsOrder_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentsOrder>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder(Guid.Parse("3b8e2de5-ed50-4412-9e87-6b6d6a88e6e7"));
            });

            result.Should().NotBe(default(ApplicantCommentsOrder));
        }

        [Fact, TestPriority(11)]
        public async Task GetApplicantCommentsOrder_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentsOrder>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder(Guid.NewGuid());
            });

            result.Should().Be(default(ApplicantCommentsOrder));
        }

        [Fact, TestPriority(12)]
        public async Task GetApplicantCommentsOrder_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetApplicantCommentsOrder_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentsOrder>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder("Тестовое значение 2");
            });

            result.Should().NotBe(default(ApplicantCommentsOrder));
        }

        [Fact, TestPriority(14)]
        public async Task GetApplicantCommentsOrder_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentsOrder>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder("Тестовое значение 3");
            });

            result.Should().Be(default(ApplicantCommentsOrder));
        }

        [Fact, TestPriority(15)]
        public async Task GetApplicantCommentsOrders_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<ApplicantCommentsOrder>>(() =>
            {
                return _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrders().ToList();
            });

            result.Should().BeOfType<List<ApplicantCommentsOrder>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteApplicantCommentsOrder_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentsOrders.DeleteApplicantCommentsOrder(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteApplicantCommentsOrder_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.ApplicantCommentsOrders.GetApplicantCommentsOrder("Тестовое значение 2");

                _dataManager.ApplicantCommentsOrders.DeleteApplicantCommentsOrder(entity.Id);

                return _dataManager.ApplicantCommentsOrders.ContainsApplicantCommentsOrder("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
