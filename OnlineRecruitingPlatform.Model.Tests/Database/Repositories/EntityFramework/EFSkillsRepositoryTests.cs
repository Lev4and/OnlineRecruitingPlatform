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
    public class EFSkillsRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsSkill_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Skills.ContainsSkill(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsSkill_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Skills.ContainsSkill("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsSkill_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Skills.ContainsSkill("V-Ray");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveSkill_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Skills.SaveSkill(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveSkill_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Skills.SaveSkill(new Skill() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveSkill_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Skills.SaveSkill(new Skill() { Name = "V-Ray" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveSkill_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Skills.SaveSkill(
                    new Func<Skill>(() =>
                    {
                        var entity = _dataManager.Skills.GetSkill("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveSkill_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Skills.SaveSkill(new Func<Skill>(() =>
                {
                    var entity = _dataManager.Skills.GetSkill("Тестовое значение 2", true);

                    entity.Name = "V-Ray";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetSkill_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Skills.GetSkill(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetSkill_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Skill>(() =>
            {
                return _dataManager.Skills.GetSkill(Guid.Parse("12b07d2e-665f-470f-b518-2ee43c683caf"));
            });

            result.Should().NotBe(default(Skill));
        }

        [Fact, TestPriority(11)]
        public async Task GetSkill_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Skill>(() =>
            {
                return _dataManager.Skills.GetSkill(Guid.NewGuid());
            });

            result.Should().Be(default(Skill));
        }

        [Fact, TestPriority(12)]
        public async Task GetSkill_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Skills.GetSkill(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetSkill_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Skill>(() =>
            {
                return _dataManager.Skills.GetSkill("Тестовое значение 2");
            });

            result.Should().NotBe(default(Skill));
        }

        [Fact, TestPriority(14)]
        public async Task GetSkill_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Skill>(() =>
            {
                return _dataManager.Skills.GetSkill("Тестовое значение 3");
            });

            result.Should().Be(default(Skill));
        }

        [Fact, TestPriority(15)]
        public async Task GetSkills_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<Skill>>(() =>
            {
                return _dataManager.Skills.GetSkills().ToList();
            });

            result.Should().BeOfType<List<Skill>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteSkill_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Skills.DeleteSkill(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteSkill_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.Skills.GetSkill("Тестовое значение 2");

                _dataManager.Skills.DeleteSkill(entity.Id);

                return _dataManager.Skills.ContainsSkill("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
