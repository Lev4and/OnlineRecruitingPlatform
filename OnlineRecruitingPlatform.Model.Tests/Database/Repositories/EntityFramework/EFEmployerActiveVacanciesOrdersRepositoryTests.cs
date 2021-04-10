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
    public class EFEmployerActiveVacanciesOrdersRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsEmployerActiveVacanciesOrder_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.EmployerActiveVacanciesOrders.ContainsEmployerActiveVacanciesOrder(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsEmployerActiveVacanciesOrder_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.ContainsEmployerActiveVacanciesOrder("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsEmployerActiveVacanciesOrder_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.ContainsEmployerActiveVacanciesOrder("по заголовку, в обратном порядке");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveEmployerActiveVacanciesOrder_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerActiveVacanciesOrders.SaveEmployerActiveVacanciesOrder(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveEmployerActiveVacanciesOrder_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.SaveEmployerActiveVacanciesOrder(new EmployerActiveVacanciesOrder() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveEmployerActiveVacanciesOrder_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.SaveEmployerActiveVacanciesOrder(new EmployerActiveVacanciesOrder() { Name = "по заголовку, в обратном порядке" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveEmployerActiveVacanciesOrder_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.SaveEmployerActiveVacanciesOrder(
                    new Func<EmployerActiveVacanciesOrder>(() =>
                    {
                        var entity = _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveEmployerActiveVacanciesOrder_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.SaveEmployerActiveVacanciesOrder(new Func<EmployerActiveVacanciesOrder>(() =>
                {
                    var entity = _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder("Тестовое значение 2", true);

                    entity.Name = "по заголовку, в обратном порядке";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetEmployerActiveVacanciesOrder_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetEmployerActiveVacanciesOrder_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerActiveVacanciesOrder>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder(Guid.Parse("547c7ea3-fdad-47d5-911e-4a7ac0c4114e"));
            });

            result.Should().NotBe(default(EmployerActiveVacanciesOrder));
        }

        [Fact, TestPriority(11)]
        public async Task GetEmployerActiveVacanciesOrder_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerActiveVacanciesOrder>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder(Guid.NewGuid());
            });

            result.Should().Be(default(EmployerActiveVacanciesOrder));
        }

        [Fact, TestPriority(12)]
        public async Task GetEmployerActiveVacanciesOrder_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetEmployerActiveVacanciesOrder_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerActiveVacanciesOrder>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder("Тестовое значение 2");
            });

            result.Should().NotBe(default(EmployerActiveVacanciesOrder));
        }

        [Fact, TestPriority(14)]
        public async Task GetEmployerActiveVacanciesOrder_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerActiveVacanciesOrder>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder("Тестовое значение 3");
            });

            result.Should().Be(default(EmployerActiveVacanciesOrder));
        }

        [Fact, TestPriority(15)]
        public async Task GetEmployerActiveVacanciesOrders_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<EmployerActiveVacanciesOrder>>(() =>
            {
                return _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrders().ToList();
            });

            result.Should().BeOfType<List<EmployerActiveVacanciesOrder>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteEmployerActiveVacanciesOrder_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerActiveVacanciesOrders.DeleteEmployerActiveVacanciesOrder(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteEmployerActiveVacanciesOrder_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.EmployerActiveVacanciesOrders.GetEmployerActiveVacanciesOrder("Тестовое значение 2");

                _dataManager.EmployerActiveVacanciesOrders.DeleteEmployerActiveVacanciesOrder(entity.Id);

                return _dataManager.EmployerActiveVacanciesOrders.ContainsEmployerActiveVacanciesOrder("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
