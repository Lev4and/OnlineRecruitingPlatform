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
    public class EFApplicantCommentAccessTypesRepositoryTest : DatabaseBaseTest
    {
        [Fact, TestPriority(1)]
        public async Task ContainsApplicantCommentAccessType_WithoutAnyParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() => { _dataManager.ApplicantCommentAccessTypes.ContainsApplicantCommentAccessType(""); }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(2)]
        public async Task ContainsApplicantCommentAccessType_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            { 
                return _dataManager.ApplicantCommentAccessTypes.ContainsApplicantCommentAccessType("Тестовое значение");
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(3)]
        public async Task ContainsApplicantCommentAccessType_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.ContainsApplicantCommentAccessType("Виден мне и моим коллегам");
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(4)]
        public async Task SaveApplicantCommentAccessType_Add_WithNullParams_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentAccessTypes.SaveApplicantCommentAccessType(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(5)]
        public async Task SaveApplicantCommentAccessType_Add_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.SaveApplicantCommentAccessType(
                    new ApplicantCommentAccessType()
                    {
                        Name = "Тестовое значение"
                    });
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(6)]
        public async Task SaveApplicantCommentAccessType_Add_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.SaveApplicantCommentAccessType(
                    new ApplicantCommentAccessType()
                    {
                        Id = Guid.Parse("a8bac010-7dab-4149-ae01-ea533c8125da"),
                        Name = "Виден мне и моим коллегам"
                    });
            });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(7)]
        public async Task SaveApplicantCommentAccessType_Modify_WithParams_ReturnTrue()
        {
            var result = await Task.Run<bool>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.SaveApplicantCommentAccessType(
                    new Func<ApplicantCommentAccessType>(() =>
                    {
                        var entity = _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType("Тестовое значение", true);

                        entity.Name = "Тестовое значение 2";

                        return entity;
                    }).Invoke());
            });

            result.Should().BeTrue();
        }

        [Fact, TestPriority(8)]
        public async Task SaveApplicantCommentAccessType_Modify_WithParams_ReturnFalse()
        {
            var result = await Task.Run<bool>(() =>
                {
                    return _dataManager.ApplicantCommentAccessTypes.SaveApplicantCommentAccessType(new Func<ApplicantCommentAccessType>(() =>
                    {
                        return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType("Тестовое значение 2", true);

                    }).Invoke());
                });

            result.Should().BeFalse();
        }

        [Fact, TestPriority(9)]
        public async Task GetApplicantCommentAccessType_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(10)]
        public async Task GetApplicantCommentAccessType_WithIdParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentAccessType>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType(Guid.Parse("7f58d693-b60b-4bce-a6a3-412af6e3c941"));
            });

            result.Should().NotBe(default(ApplicantCommentAccessType));
        }

        [Fact, TestPriority(11)]
        public async Task GetApplicantCommentAccessType_WithIdParam_ReturnDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentAccessType>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType(Guid.NewGuid());
            });

            result.Should().Be(default(ApplicantCommentAccessType));
        }

        [Fact, TestPriority(12)]
        public async Task GetApplicantCommentAccessType_WithNullNameParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType(null);
                }).Should().Throw<ArgumentNullException>();
            });
        }

        [Fact, TestPriority(13)]
        public async Task GetApplicantCommentAccessType_WithNameParam_ReturnNotBeDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentAccessType>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType("Тестовое значение 2");
            });

            result.Should().NotBe(default(ApplicantCommentAccessType));
        }

        [Fact, TestPriority(14)]
        public async Task GetApplicantCommentAccessType_WithNameParam_ReturnDefaultObject()
        {
            var result = await Task.Run<ApplicantCommentAccessType>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType("Тестовое значение 3");
            });

            result.Should().Be(default(ApplicantCommentAccessType));
        }

        [Fact, TestPriority(15)]
        public async Task GetApplicantCommentAccessTypes_WithoutAnyParams_ReturnCollection()
        {
            var result = await Task.Run<List<ApplicantCommentAccessType>>(() =>
            {
                return _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessTypes().ToList();
            });

            result.Should().BeOfType<List<ApplicantCommentAccessType>>();
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact, TestPriority(16)]
        public async Task DeleteApplicantCommentAccessType_WithInvalidIdParam_ReturnException()
        {
            await Task.Run(() =>
            {
                new Action(() =>
                {
                    _dataManager.ApplicantCommentAccessTypes.DeleteApplicantCommentAccessType(Guid.Parse(""));
                }).Should().Throw<FormatException>();
            });
        }

        [Fact, TestPriority(17)]
        public async Task DeleteApplicantCommentAccessType_WithIdParam_ReturnNotExist()
        {
            var result = await Task.Run<bool>(() =>
            {
                var entity = _dataManager.ApplicantCommentAccessTypes.GetApplicantCommentAccessType("Тестовое значение 2");

                _dataManager.ApplicantCommentAccessTypes.DeleteApplicantCommentAccessType(entity.Id);

                return _dataManager.ApplicantCommentAccessTypes.ContainsApplicantCommentAccessType("Тестовое значение 2");
            });

            result.Should().BeFalse();
        }
    }
}
