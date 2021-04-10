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
    public class EFExperiencesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsExperience_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Experiences.ContainsExperience(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsExperience_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Experiences.ContainsExperience("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsExperience_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Experiences.ContainsExperience("От 1 года до 3 лет");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveExperience_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Experiences.SaveExperience(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveExperience_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Experiences.SaveExperience(new Experience() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveExperience_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Experiences.SaveExperience(new Experience() { Name = "От 1 года до 3 лет" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveExperience_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Experiences.SaveExperience(
                    new Func<Experience>(() =>
                    {
                        var entity = _dataManager.Experiences.GetExperience("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveExperience_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Experiences.SaveExperience(new Func<Experience>(() =>
                {
                    var entity = _dataManager.Experiences.GetExperience("Тестовое значение 2", true);

                    entity.Name = "От 1 года до 3 лет";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetExperience_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Experiences.GetExperience(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetExperience_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Experience>(() =>
            {
                return _dataManager.Experiences.GetExperience(Guid.Parse("2cafdb0e-931d-48e1-b388-889cba0a1e74"));
            });

            result.Should().NotBe(default(Experience));
        }

        [Fact, TestPriority(11)]
        public async Task GetExperience_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Experience>(() =>
            {
                return _dataManager.Experiences.GetExperience(Guid.NewGuid());
            });

            result.Should().Be(default(Experience));
        }

        [Fact, TestPriority(12)]
        public async Task GetExperience_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Experiences.GetExperience(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetExperience_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Experience>(() =>
            {
                return _dataManager.Experiences.GetExperience("Тестовое значение 2");
            });

            result.Should().NotBe(default(Experience));
        }

        [Fact, TestPriority(14)]
        public async Task GetExperience_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Experience>(() =>
            {
                return _dataManager.Experiences.GetExperience("Тестовое значение 3");
            });

            result.Should().Be(default(Experience));
        }

        [Fact, TestPriority(15)]
        public async Task GetExperiences_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<Experience>>(() =>
            {
                return _dataManager.Experiences.GetExperiences().ToList();
            });

            result.Should().BeOfType<List<Experience>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteExperience_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Experiences.DeleteExperience(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteExperience_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.Experiences.GetExperience("Тестовое значение 2");

                _dataManager.Experiences.DeleteExperience(entity.Id);

                return _dataManager.Experiences.ContainsExperience("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
