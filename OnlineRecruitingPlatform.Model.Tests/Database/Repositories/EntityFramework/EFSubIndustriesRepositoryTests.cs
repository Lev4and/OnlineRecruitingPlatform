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
    public class EFSubIndustriesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsSubIndustry_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.SubIndustries.ContainsSubIndustry(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsSubIndustry_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.SubIndustries.ContainsSubIndustry("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsSubIndustry_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.SubIndustries.ContainsSubIndustry("Научные исследования и разработки в области технических наук");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveSubIndustry_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.SubIndustries.SaveSubIndustry(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveSubIndustry_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry() { IndustryId = Guid.Parse("A6757C24-5B28-4457-6699-08D906F07030"), Code = "00.1", Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveSubIndustry_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry() { IndustryId = Guid.Parse("A6757C24-5B28-4457-6699-08D906F07030"), Code =  "72.19.2", Name = "Научные исследования и разработки в области технических наук" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveSubIndustry_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.SubIndustries.SaveSubIndustry(
                    new Func<SubIndustry>(() =>
                    {
                        var entity = _dataManager.SubIndustries.GetSubIndustry("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveSubIndustry_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.SubIndustries.SaveSubIndustry(new Func<SubIndustry>(() =>
                {
                    var entity = _dataManager.SubIndustries.GetSubIndustry("Тестовое значение 2", true);

                    entity.Name = "Научные исследования и разработки в области технических наук";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetSubIndustry_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.SubIndustries.GetSubIndustry(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetSubIndustry_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<SubIndustry>(() =>
            {
                return _dataManager.SubIndustries.GetSubIndustry(Guid.Parse("24384B6C-DDF6-495B-D6AF-08D906F189DC"));
            });

            result.Should().NotBe(default(SubIndustry));
        }

        [Fact, TestPriority(11)]
        public async Task GetSubIndustry_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<SubIndustry>(() =>
            {
                return _dataManager.SubIndustries.GetSubIndustry(Guid.NewGuid());
            });

            result.Should().Be(default(SubIndustry));
        }

        [Fact, TestPriority(12)]
        public async Task GetSubIndustry_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.SubIndustries.GetSubIndustry(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetSubIndustry_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<SubIndustry>(() =>
            {
                return _dataManager.SubIndustries.GetSubIndustry("Тестовое значение 2");
            });

            result.Should().NotBe(default(SubIndustry));
        }

        [Fact, TestPriority(14)]
        public async Task GetSubIndustry_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<SubIndustry>(() =>
            {
                return _dataManager.SubIndustries.GetSubIndustry("Тестовое значение 3");
            });

            result.Should().Be(default(SubIndustry));
        }

        [Fact, TestPriority(15)]
        public async Task GetSubIndustries_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<SubIndustry>>(() =>
            {
                return _dataManager.SubIndustries.GetSubIndustries().ToList();
            });

            result.Should().BeOfType<List<SubIndustry>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteSubIndustry_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.SubIndustries.DeleteSubIndustry(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteSubIndustry_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.SubIndustries.GetSubIndustry("Тестовое значение 2");

                _dataManager.SubIndustries.DeleteSubIndustry(entity.Id);

                return _dataManager.SubIndustries.ContainsSubIndustry("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
