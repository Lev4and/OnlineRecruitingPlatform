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
    public class EFDriverLicenseTypesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsDriverLicenseType_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.DriverLicenseTypes.ContainsDriverLicenseType(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsDriverLicenseType_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.DriverLicenseTypes.ContainsDriverLicenseType("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsDriverLicenseType_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.DriverLicenseTypes.ContainsDriverLicenseType("B");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveDriverLicenseType_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.DriverLicenseTypes.SaveDriverLicenseType(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveDriverLicenseType_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.DriverLicenseTypes.SaveDriverLicenseType(new DriverLicenseType() { Name = "Тестовое значение" });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveDriverLicenseType_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.DriverLicenseTypes.SaveDriverLicenseType(new DriverLicenseType() { Name = "B" });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveDriverLicenseType_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.DriverLicenseTypes.SaveDriverLicenseType(
                    new Func<DriverLicenseType>(() =>
                    {
                        var entity = _dataManager.DriverLicenseTypes.GetDriverLicenseType("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveDriverLicenseType_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.DriverLicenseTypes.SaveDriverLicenseType(new Func<DriverLicenseType>(() =>
                {
                    var entity = _dataManager.DriverLicenseTypes.GetDriverLicenseType("Тестовое значение 2", true);

                    entity.Name = "B";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetDriverLicenseType_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.DriverLicenseTypes.GetDriverLicenseType(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetDriverLicenseType_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<DriverLicenseType>(() =>
            {
                return _dataManager.DriverLicenseTypes.GetDriverLicenseType(Guid.Parse("11c7efc4-419e-4493-83c6-00ea86c6f21a"));
            });

            result.Should().NotBe(default(DriverLicenseType));
        }

        [Fact, TestPriority(11)]
        public async Task GetDriverLicenseType_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<DriverLicenseType>(() =>
            {
                return _dataManager.DriverLicenseTypes.GetDriverLicenseType(Guid.NewGuid());
            });

            result.Should().Be(default(DriverLicenseType));
        }

        [Fact, TestPriority(12)]
        public async Task GetDriverLicenseType_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.DriverLicenseTypes.GetDriverLicenseType(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetDriverLicenseType_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<DriverLicenseType>(() =>
            {
                return _dataManager.DriverLicenseTypes.GetDriverLicenseType("Тестовое значение 2");
            });

            result.Should().NotBe(default(DriverLicenseType));
        }

        [Fact, TestPriority(14)]
        public async Task GetDriverLicenseType_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<DriverLicenseType>(() =>
            {
                return _dataManager.DriverLicenseTypes.GetDriverLicenseType("Тестовое значение 3");
            });

            result.Should().Be(default(DriverLicenseType));
        }

        [Fact, TestPriority(15)]
        public async Task GetDriverLicenseTypes_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<DriverLicenseType>>(() =>
            {
                return _dataManager.DriverLicenseTypes.GetDriverLicenseTypes().ToList();
            });

            result.Should().BeOfType<List<DriverLicenseType>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteDriverLicenseType_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.DriverLicenseTypes.DeleteDriverLicenseType(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteDriverLicenseType_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.DriverLicenseTypes.GetDriverLicenseType("Тестовое значение 2");

                _dataManager.DriverLicenseTypes.DeleteDriverLicenseType(entity.Id);

                return _dataManager.DriverLicenseTypes.ContainsDriverLicenseType("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
