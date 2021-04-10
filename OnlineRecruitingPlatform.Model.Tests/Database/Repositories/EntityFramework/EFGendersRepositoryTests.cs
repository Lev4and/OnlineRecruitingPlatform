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
    public class EFGendersRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsGender_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Genders.ContainsGender(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsGender_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Genders.ContainsGender("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsGender_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Genders.ContainsGender("Мужской");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveGender_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Genders.SaveGender(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveGender_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Genders.SaveGender(new Gender() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveGender_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Genders.SaveGender(new Gender() { Name = "Мужской" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveGender_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Genders.SaveGender(
                    new Func<Gender>(() =>
                    {
                        var entity = _dataManager.Genders.GetGender("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveGender_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Genders.SaveGender(new Func<Gender>(() =>
                {
                    var entity = _dataManager.Genders.GetGender("Тестовое значение 2", true);

                    entity.Name = "Мужской";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetGender_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Genders.GetGender(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetGender_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Gender>(() =>
            {
                return _dataManager.Genders.GetGender(Guid.Parse("96b2d51d-abae-43b0-84c3-41aa80033dc4"));
            });

            result.Should().NotBe(default(Gender));
        }

        [Fact, TestPriority(11)]
        public async Task GetGender_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Gender>(() =>
            {
                return _dataManager.Genders.GetGender(Guid.NewGuid());
            });

            result.Should().Be(default(Gender));
        }

        [Fact, TestPriority(12)]
        public async Task GetGender_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Genders.GetGender(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetGender_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Gender>(() =>
            {
                return _dataManager.Genders.GetGender("Тестовое значение 2");
            });

            result.Should().NotBe(default(Gender));
        }

        [Fact, TestPriority(14)]
        public async Task GetGender_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Gender>(() =>
            {
                return _dataManager.Genders.GetGender("Тестовое значение 3");
            });

            result.Should().Be(default(Gender));
        }

        [Fact, TestPriority(15)]
        public async Task GetExperiences_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<Gender>>(() =>
            {
                return _dataManager.Genders.GetGenders().ToList();
            });

            result.Should().BeOfType<List<Gender>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteGender_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Genders.DeleteGender(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteGender_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.Genders.GetGender("Тестовое значение 2");

                _dataManager.Genders.DeleteGender(entity.Id);

                return _dataManager.Genders.ContainsGender("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
