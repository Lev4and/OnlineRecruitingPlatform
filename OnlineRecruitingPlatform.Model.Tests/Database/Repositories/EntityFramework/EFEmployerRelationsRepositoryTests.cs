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
    public class EFEmployerRelationsRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsEmployerRelation_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.EmployerRelations.ContainsEmployerRelation(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsEmployerRelation_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerRelations.ContainsEmployerRelation("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsEmployerRelation_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerRelations.ContainsEmployerRelation("Скрыт из поиска вакансий");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveEmployerRelation_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerRelations.SaveEmployerRelation(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveEmployerRelation_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerRelations.SaveEmployerRelation(new EmployerRelation() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveEmployerRelation_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerRelations.SaveEmployerRelation(new EmployerRelation() { Name = "Скрыт из поиска вакансий" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveEmployerRelation_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerRelations.SaveEmployerRelation(
                    new Func<EmployerRelation>(() =>
                    {
                        var entity = _dataManager.EmployerRelations.GetEmployerRelation("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveEmployerRelation_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EmployerRelations.SaveEmployerRelation(new Func<EmployerRelation>(() =>
                {
                    var entity = _dataManager.EmployerRelations.GetEmployerRelation("Тестовое значение 2", true);

                    entity.Name = "Скрыт из поиска вакансий";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetEmployerRelation_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerRelations.GetEmployerRelation(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetEmployerRelation_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerRelation>(() =>
            {
                return _dataManager.EmployerRelations.GetEmployerRelation(Guid.Parse("bb8df7dd-755a-4889-b24b-df83702fb0ac"));
            });

            result.Should().NotBe(default(EmployerRelation));
        }

        [Fact, TestPriority(11)]
        public async Task GetEmployerRelation_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerRelation>(() =>
            {
                return _dataManager.EmployerRelations.GetEmployerRelation(Guid.NewGuid());
            });

            result.Should().Be(default(EmployerRelation));
        }

        [Fact, TestPriority(12)]
        public async Task GetEmployerRelation_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerRelations.GetEmployerRelation(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetEmployerRelation_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EmployerRelation>(() =>
            {
                return _dataManager.EmployerRelations.GetEmployerRelation("Тестовое значение 2");
            });

            result.Should().NotBe(default(EmployerRelation));
        }

        [Fact, TestPriority(14)]
        public async Task GetEmployerRelation_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EmployerRelation>(() =>
            {
                return _dataManager.EmployerRelations.GetEmployerRelation("Тестовое значение 3");
            });

            result.Should().Be(default(EmployerRelation));
        }

        [Fact, TestPriority(15)]
        public async Task GetEmployerRelations_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<EmployerRelation>>(() =>
            {
                return _dataManager.EmployerRelations.GetEmployerRelations().ToList();
            });

            result.Should().BeOfType<List<EmployerRelation>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteEmployerRelation_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EmployerRelations.DeleteEmployerRelation(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteEmployerRelation_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.EmployerRelations.GetEmployerRelation("Тестовое значение 2");

                _dataManager.EmployerRelations.DeleteEmployerRelation(entity.Id);

                return _dataManager.EmployerRelations.ContainsEmployerRelation("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
