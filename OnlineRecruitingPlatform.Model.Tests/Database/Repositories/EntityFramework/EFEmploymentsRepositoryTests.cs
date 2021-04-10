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
    public class EFEmploymentsRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsEmployment_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Employments.ContainsEmployment(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsEmployment_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Employments.ContainsEmployment("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsEmployment_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Employments.ContainsEmployment("Полная занятость");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveEmployment_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Employments.SaveEmployment(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveEmployment_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Employments.SaveEmployment(new Employment() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveEmployment_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Employments.SaveEmployment(new Employment() { Name = "Полная занятость" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveEmployment_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Employments.SaveEmployment(
                    new Func<Employment>(() =>
                    {
                        var entity = _dataManager.Employments.GetEmployment("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveEmployment_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Employments.SaveEmployment(new Func<Employment>(() =>
                {
                    var entity = _dataManager.Employments.GetEmployment("Тестовое значение 2", true);

                    entity.Name = "Полная занятость";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetEmployment_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Employments.GetEmployment(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetEmployment_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Employment>(() =>
            {
                return _dataManager.Employments.GetEmployment(Guid.Parse("fe3c86b5-a939-42c5-ab73-60ef6fa31aa6"));
            });

            result.Should().NotBe(default(Employment));
        }

        [Fact, TestPriority(11)]
        public async Task GetEmployment_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Employment>(() =>
            {
                return _dataManager.Employments.GetEmployment(Guid.NewGuid());
            });

            result.Should().Be(default(Employment));
        }

        [Fact, TestPriority(12)]
        public async Task GetEmployment_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Employments.GetEmployment(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetEmployment_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Employment>(() =>
            {
                return _dataManager.Employments.GetEmployment("Тестовое значение 2");
            });

            result.Should().NotBe(default(Employment));
        }

        [Fact, TestPriority(14)]
        public async Task GetEmployment_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Employment>(() =>
            {
                return _dataManager.Employments.GetEmployment("Тестовое значение 3");
            });

            result.Should().Be(default(Employment));
        }

        [Fact, TestPriority(15)]
        public async Task GetEmployments_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<Employment>>(() =>
            {
                return _dataManager.Employments.GetEmployments().ToList();
            });

            result.Should().BeOfType<List<Employment>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteEmployment_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Employments.DeleteEmployment(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteEmployment_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.Employments.GetEmployment("Тестовое значение 2");

                _dataManager.Employments.DeleteEmployment(entity.Id);

                return _dataManager.Employments.ContainsEmployment("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
