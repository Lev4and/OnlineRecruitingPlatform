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
    public class EFEducationLevelsRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsEducationLevel_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.EducationLevels.ContainsEducationLevel(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsEducationLevel_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EducationLevels.ContainsEducationLevel("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsEducationLevel_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EducationLevels.ContainsEducationLevel("Среднее");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveEducationLevel_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EducationLevels.SaveEducationLevel(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveEducationLevel_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EducationLevels.SaveEducationLevel(new EducationLevel() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveEducationLevel_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EducationLevels.SaveEducationLevel(new EducationLevel() { Name = "Среднее" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveEducationLevel_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EducationLevels.SaveEducationLevel(
                    new Func<EducationLevel>(() =>
                    {
                        var entity = _dataManager.EducationLevels.GetEducationLevel("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveEducationLevel_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.EducationLevels.SaveEducationLevel(new Func<EducationLevel>(() =>
                {
                    var entity = _dataManager.EducationLevels.GetEducationLevel("Тестовое значение 2", true);

                    entity.Name = "Среднее";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetEducationLevel_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EducationLevels.GetEducationLevel(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetEducationLevel_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EducationLevel>(() =>
            {
                return _dataManager.EducationLevels.GetEducationLevel(Guid.Parse("2a91b0b8-d93b-459a-9625-3bbc81a58382"));
            });

            result.Should().NotBe(default(EducationLevel));
        }

        [Fact, TestPriority(11)]
        public async Task GetEducationLevel_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EducationLevel>(() =>
            {
                return _dataManager.EducationLevels.GetEducationLevel(Guid.NewGuid());
            });

            result.Should().Be(default(EducationLevel));
        }

        [Fact, TestPriority(12)]
        public async Task GetEducationLevel_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EducationLevels.GetEducationLevel(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetEducationLevel_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<EducationLevel>(() =>
            {
                return _dataManager.EducationLevels.GetEducationLevel("Тестовое значение 2");
            });

            result.Should().NotBe(default(EducationLevel));
        }

        [Fact, TestPriority(14)]
        public async Task GetEducationLevel_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<EducationLevel>(() =>
            {
                return _dataManager.EducationLevels.GetEducationLevel("Тестовое значение 3");
            });

            result.Should().Be(default(EducationLevel));
        }

        [Fact, TestPriority(15)]
        public async Task GetEducationLevels_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<EducationLevel>>(() =>
            {
                return _dataManager.EducationLevels.GetEducationLevels().ToList();
            });

            result.Should().BeOfType<List<EducationLevel>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteEducationLevel_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.EducationLevels.DeleteEducationLevel(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteEducationLevel_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.EducationLevels.GetEducationLevel("Тестовое значение 2");

                _dataManager.EducationLevels.DeleteEducationLevel(entity.Id);

                return _dataManager.EducationLevels.ContainsEducationLevel("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
