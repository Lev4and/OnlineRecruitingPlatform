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
    public class EFEmployerTypesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsEmployerType_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.EmployerTypes.ContainsEmployerType(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsEmployerType_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerTypes.ContainsEmployerType("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsEmployerType_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerTypes.ContainsEmployerType("Прямой работодатель");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveEmployerType_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerTypes.SaveEmployerType(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveEmployerType_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerTypes.SaveEmployerType(new EmployerType() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveEmployerType_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerTypes.SaveEmployerType(new EmployerType() { Name = "Прямой работодатель" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveEmployerType_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerTypes.SaveEmployerType(
                    new Func<EmployerType>(() =>
                    {
                        var entity = _dataManager.EmployerTypes.GetEmployerType("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveEmployerType_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerTypes.SaveEmployerType(new Func<EmployerType>(() =>
                {
                    var entity = _dataManager.EmployerTypes.GetEmployerType("Тестовое значение 2", true);

                    entity.Name = "Прямой работодатель";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetEmployerType_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerTypes.GetEmployerType(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetEmployerType_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerType>(() =>
            {
                return _dataManager.EmployerTypes.GetEmployerType(Guid.Parse("ed023d74-53be-4961-8195-d4cf4f9e08db"));
            });

            result.Should().NotBe(default(EmployerType));
        }

        [Fact, TestPriority(11)]
        public async Task GetEmployerType_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerType>(() =>
            {
                return _dataManager.EmployerTypes.GetEmployerType(Guid.NewGuid());
            });

            result.Should().Be(default(EmployerType));
        }

        [Fact, TestPriority(12)]
        public async Task GetEmployerType_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerTypes.GetEmployerType(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetEmployerType_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerType>(() =>
            {
                return _dataManager.EmployerTypes.GetEmployerType("Тестовое значение 2");
            });

            result.Should().NotBe(default(EmployerType));
        }

        [Fact, TestPriority(14)]
        public async Task GetEmployerType_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerType>(() =>
            {
                return _dataManager.EmployerTypes.GetEmployerType("Тестовое значение 3");
            });

            result.Should().Be(default(EmployerType));
        }

        [Fact, TestPriority(15)]
        public async Task GetEmployerTypes_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<EmployerType>>(() =>
            {
                return _dataManager.EmployerTypes.GetEmployerTypes().ToList();
            });

            result.Should().BeOfType<List<EmployerType>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteEmployerType_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerTypes.DeleteEmployerType(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteEmployerType_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.EmployerTypes.GetEmployerType("Тестовое значение 2");

                _dataManager.EmployerTypes.DeleteEmployerType(entity.Id);

                return _dataManager.EmployerTypes.ContainsEmployerType("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
