using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Tests.Attributes;
using Xunit;

namespace OnlineRecruitingPlatform.Model.Tests.Database.Repositories.EntityFramework
{
    [TestCaseOrderer("OnlineRecruitingPlatform.Model.Tests.TestCaseOrdering.PriorityOrderer", "OnlineRecruitingPlatform.Model.Tests")]
    public class EFCurrenciesRepositoryTests : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsCurrency_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.Currencies.ContainsCurrency(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsCurrency_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Currencies.ContainsCurrency("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsCurrency_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Currencies.ContainsCurrency("Российский рубль");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveCurrency_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Currencies.SaveCurrency(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveCurrency_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Currencies.SaveCurrency(
                    new Currency()
                    {
                        Code = "CUR",
                        Abbreviation = "Currency",
                        Designation = "$",
                        Name = "Валюта"
                    });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveCurrency_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Currencies.SaveCurrency(
                    new Currency()
                    {
                        Code = "RUB",
                        Abbreviation = "Russian Ruble",
                        Designation = "₽",
                        Name = "Российский рубль"
                    });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveCurrency_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Currencies.SaveCurrency(
                    new Func<Currency>(() =>
                    {
                        var entity = _dataManager.Currencies.GetCurrency("Валюта", true);

                        entity.Name = "Валюта 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveCurrency_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.Currencies.SaveCurrency(new Func<Currency>(() =>
                {
                    var entity = _dataManager.Currencies.GetCurrency("Валюта 2", true);

                    entity.Name = "Российский рубль";

                    return entity;

                }).Invoke());
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetCurrency_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Currencies.GetCurrency(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetCurrency_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Currency>(() =>
            {
                return _dataManager.Currencies.GetCurrency(Guid.Parse("54e54987-a36b-4276-a792-bd6e03e40ca6"));
            });

            result.Should().NotBe(default(Currency));
        }

        [Fact, TestPriority(11)]
        public async Task GetBusinessTripReadiness_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Currency>(() =>
            {
                return _dataManager.Currencies.GetCurrency(Guid.NewGuid());
            });

            result.Should().Be(default(Currency));
        }

        [Fact, TestPriority(12)]
        public async Task GetCurrency_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Currencies.GetCurrency(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetCurrency_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<Currency>(() =>
            {
                return _dataManager.Currencies.GetCurrency("Валюта 2");
            });

            result.Should().NotBe(default(Currency));
        }

        [Fact, TestPriority(14)]
        public async Task GetCurrency_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<Currency>(() =>
            {
                return _dataManager.Currencies.GetCurrency("Валюта 3");
            });

            result.Should().Be(default(Currency));
        }

        [Fact, TestPriority(15)]
        public async Task GetCurrencies_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<Currency>>(() =>
            {
                return _dataManager.Currencies.GetCurrencies().ToList();
            });

            result.Should().BeOfType<List<Currency>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteCurrency_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.Currencies.DeleteCurrency(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteCurrency_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.Currencies.GetCurrency("Валюта 2");

                _dataManager.Currencies.DeleteCurrency(entity.Id);

                return _dataManager.Currencies.ContainsCurrency("Валюта 2");
            });

            result.Should().BeFalse();
        }
    }
}
