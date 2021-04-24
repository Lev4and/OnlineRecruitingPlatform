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
    public class EFIndustriesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsIndustry_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Industries.ContainsIndustry(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsIndustry_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Industries.ContainsIndustry("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsIndustry_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Industries.ContainsIndustry("Деятельность в области информационных технологий");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveIndustry_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Industries.SaveIndustry(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveIndustry_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Industries.SaveIndustry(new Industry() { Code = "00", Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveIndustry_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Industries.SaveIndustry(new Industry() { Code = "63", Name = "Деятельность в области информационных технологий" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveIndustry_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Industries.SaveIndustry(
                    new Func<Industry>(() =>
                    {
                        var entity = _dataManager.Industries.GetIndustry("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveIndustry_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Industries.SaveIndustry(new Func<Industry>(() =>
                {
                    var entity = _dataManager.Industries.GetIndustry("Тестовое значение 2", true);

                    entity.Name = "Деятельность в области информационных технологий";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetIndustry_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Industries.GetIndustry(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetIndustry_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Industry>(() =>
            {
                return _dataManager.Industries.GetIndustry(Guid.Parse("6E972960-A1D7-4A0D-6691-08D906F07030"));
            });

            result.Should().NotBe(default(Industry));
        }

        [Fact, TestPriority(11)]
        public async Task GetIndustry_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Industry>(() =>
            {
                return _dataManager.Industries.GetIndustry(Guid.NewGuid());
            });

            result.Should().Be(default(Industry));
        }

        [Fact, TestPriority(12)]
        public async Task GetIndustry_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Industries.GetIndustry(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetIndustry_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Industry>(() =>
            {
                return _dataManager.Industries.GetIndustry("Тестовое значение 2");
            });

            result.Should().NotBe(default(Industry));
        }

        [Fact, TestPriority(14)]
        public async Task GetIndustry_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Industry>(() =>
            {
                return _dataManager.Industries.GetIndustry("Тестовое значение 3");
            });

            result.Should().Be(default(Industry));
        }

        [Fact, TestPriority(15)]
        public async Task GetIndustries_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<Industry>>(() =>
            {
                return _dataManager.Industries.GetIndustries().ToList();
            });

            result.Should().BeOfType<List<Industry>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteIndustry_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Industries.DeleteIndustry(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteIndustry_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.Industries.GetIndustry("Тестовое значение 2");

                _dataManager.Industries.DeleteIndustry(entity.Id);

                return _dataManager.Industries.ContainsIndustry("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
