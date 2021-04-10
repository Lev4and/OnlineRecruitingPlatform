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
    public class EFLanguageLevelsRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsLanguageLevel_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.LanguageLevels.ContainsLanguageLevel(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsLanguageLevel_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.LanguageLevels.ContainsLanguageLevel("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsLanguageLevel_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.LanguageLevels.ContainsLanguageLevel("L1 — Родной");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveLanguageLevel_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.LanguageLevels.SaveLanguageLevel(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveLanguageLevel_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.LanguageLevels.SaveLanguageLevel(new LanguageLevel() { Designation = "T", Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveLanguageLevel_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.LanguageLevels.SaveLanguageLevel(new LanguageLevel() { Designation = "L1", Name = "L1 — Родной" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveLanguageLevel_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.LanguageLevels.SaveLanguageLevel(
                    new Func<LanguageLevel>(() =>
                    {
                        var entity = _dataManager.LanguageLevels.GetLanguageLevel("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveLanguageLevel_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.LanguageLevels.SaveLanguageLevel(new Func<LanguageLevel>(() =>
                {
                    var entity = _dataManager.LanguageLevels.GetLanguageLevel("Тестовое значение 2", true);

                    entity.Name = "L1 — Родной";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetLanguageLevel_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.LanguageLevels.GetLanguageLevel(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetLanguageLevel_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<LanguageLevel>(() =>
            {
                return _dataManager.LanguageLevels.GetLanguageLevel(Guid.Parse("12744a67-b113-4d34-a03c-0edb511f58e4"));
            });

            result.Should().NotBe(default(LanguageLevel));
        }

        [Fact, TestPriority(11)]
        public async Task GetLanguageLevel_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<LanguageLevel>(() =>
            {
                return _dataManager.LanguageLevels.GetLanguageLevel(Guid.NewGuid());
            });

            result.Should().Be(default(LanguageLevel));
        }

        [Fact, TestPriority(12)]
        public async Task GetLanguageLevel_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.LanguageLevels.GetLanguageLevel(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetLanguageLevel_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<LanguageLevel>(() =>
            {
                return _dataManager.LanguageLevels.GetLanguageLevel("Тестовое значение 2");
            });

            result.Should().NotBe(default(LanguageLevel));
        }

        [Fact, TestPriority(14)]
        public async Task GetLanguageLevel_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<LanguageLevel>(() =>
            {
                return _dataManager.LanguageLevels.GetLanguageLevel("Тестовое значение 3");
            });

            result.Should().Be(default(LanguageLevel));
        }

        [Fact, TestPriority(15)]
        public async Task GetLanguageLevels_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<LanguageLevel>>(() =>
            {
                return _dataManager.LanguageLevels.GetLanguageLevels().ToList();
            });

            result.Should().BeOfType<List<LanguageLevel>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteLanguageLevel_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.LanguageLevels.DeleteLanguageLevel(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteLanguageLevel_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.LanguageLevels.GetLanguageLevel("Тестовое значение 2");

                _dataManager.LanguageLevels.DeleteLanguageLevel(entity.Id);

                return _dataManager.LanguageLevels.ContainsLanguageLevel("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
