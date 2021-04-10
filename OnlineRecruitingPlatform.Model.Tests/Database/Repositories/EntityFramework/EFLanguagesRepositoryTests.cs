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
    public class EFLanguagesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsLanguage_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Languages.ContainsLanguage(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsLanguage_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Languages.ContainsLanguage("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsLanguage_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Languages.ContainsLanguage("Русский");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveLanguage_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Languages.SaveLanguage(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveLanguage_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Languages.SaveLanguage(new Language() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveLanguage_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Languages.SaveLanguage(new Language() { Name = "Русский" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveLanguage_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Languages.SaveLanguage(
                    new Func<Language>(() =>
                    {
                        var entity = _dataManager.Languages.GetLanguage("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveLanguage_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Languages.SaveLanguage(new Func<Language>(() =>
                {
                    var entity = _dataManager.Languages.GetLanguage("Тестовое значение 2", true);

                    entity.Name = "Русский";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetLanguage_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Languages.GetLanguage(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetLanguage_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Language>(() =>
            {
                return _dataManager.Languages.GetLanguage(Guid.Parse("fe4a3683-bbca-4967-8791-ce0e224f498f"));
            });

            result.Should().NotBe(default(Language));
        }

        [Fact, TestPriority(11)]
        public async Task GetLanguage_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Language>(() =>
            {
                return _dataManager.Languages.GetLanguage(Guid.NewGuid());
            });

            result.Should().Be(default(Language));
        }

        [Fact, TestPriority(12)]
        public async Task GetLanguage_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Languages.GetLanguage(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetLanguage_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Language>(() =>
            {
                return _dataManager.Languages.GetLanguage("Тестовое значение 2");
            });

            result.Should().NotBe(default(Language));
        }

        [Fact, TestPriority(14)]
        public async Task GetLanguage_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Language>(() =>
            {
                return _dataManager.Languages.GetLanguage("Тестовое значение 3");
            });

            result.Should().Be(default(Language));
        }

        [Fact, TestPriority(15)]
        public async Task GetLanguages_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<Language>>(() =>
            {
                return _dataManager.Languages.GetLanguages().ToList();
            });

            result.Should().BeOfType<List<Language>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteLanguage_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Languages.DeleteLanguage(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteLanguage_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.Languages.GetLanguage("Тестовое значение 2");

                _dataManager.Languages.DeleteLanguage(entity.Id);

                return _dataManager.Languages.ContainsLanguage("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
