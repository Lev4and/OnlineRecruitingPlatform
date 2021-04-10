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
    public class EFEmployerArchivedVacanciesOrdersRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsEmployerArchivedVacanciesOrder_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.EmployerArchivedVacanciesOrders.ContainsEmployerArchivedVacanciesOrder(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsEmployerArchivedVacanciesOrder_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.ContainsEmployerArchivedVacanciesOrder("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsEmployerArchivedVacanciesOrder_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.ContainsEmployerArchivedVacanciesOrder("по заголовку, в обратном порядке");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveEmployerArchivedVacanciesOrder_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerArchivedVacanciesOrders.SaveEmployerArchivedVacanciesOrder(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveEmployerArchivedVacanciesOrder_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.SaveEmployerArchivedVacanciesOrder(new EmployerArchivedVacanciesOrder() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveEmployerArchivedVacanciesOrder_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.SaveEmployerArchivedVacanciesOrder(new EmployerArchivedVacanciesOrder() { Name = "по заголовку, в обратном порядке" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveEmployerArchivedVacanciesOrder_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.SaveEmployerArchivedVacanciesOrder(
                    new Func<EmployerArchivedVacanciesOrder>(() =>
                    {
                        var entity = _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveEmployerArchivedVacanciesOrder_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.SaveEmployerArchivedVacanciesOrder(new Func<EmployerArchivedVacanciesOrder>(() =>
                {
                    var entity = _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder("Тестовое значение 2", true);

                    entity.Name = "по заголовку, в обратном порядке";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetEmployerArchivedVacanciesOrder_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetEmployerArchivedVacanciesOrder_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerArchivedVacanciesOrder>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder(Guid.Parse("343be3ec-149a-4a28-8625-dc08ac53630b"));
            });

            result.Should().NotBe(default(EmployerArchivedVacanciesOrder));
        }

        [Fact, TestPriority(11)]
        public async Task GetEmployerArchivedVacanciesOrder_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerArchivedVacanciesOrder>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder(Guid.NewGuid());
            });

            result.Should().Be(default(EmployerArchivedVacanciesOrder));
        }

        [Fact, TestPriority(12)]
        public async Task GetEmployerArchivedVacanciesOrder_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetEmployerArchivedVacanciesOrder_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerArchivedVacanciesOrder>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder("Тестовое значение 2");
            });

            result.Should().NotBe(default(EmployerArchivedVacanciesOrder));
        }

        [Fact, TestPriority(14)]
        public async Task GetEmployerArchivedVacanciesOrder_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerArchivedVacanciesOrder>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder("Тестовое значение 3");
            });

            result.Should().Be(default(EmployerArchivedVacanciesOrder));
        }

        [Fact, TestPriority(15)]
        public async Task GetEmployerArchivedVacanciesOrders_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<EmployerArchivedVacanciesOrder>>(() =>
            {
                return _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrders().ToList();
            });

            result.Should().BeOfType<List<EmployerArchivedVacanciesOrder>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteEmployerArchivedVacanciesOrder_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerArchivedVacanciesOrders.DeleteEmployerArchivedVacanciesOrder(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteEmployerArchivedVacanciesOrder_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.EmployerArchivedVacanciesOrders.GetEmployerArchivedVacanciesOrder("Тестовое значение 2");

                _dataManager.EmployerArchivedVacanciesOrders.DeleteEmployerArchivedVacanciesOrder(entity.Id);

                return _dataManager.EmployerArchivedVacanciesOrders.ContainsEmployerArchivedVacanciesOrder("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
