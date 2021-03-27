using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace OnlineRecruitingPlatform.Model.Tests.Database.Repositories.EntityFramework
{
    public class EFIdentityRolesRepositoryTests : DatabaseBaseTest
    {
        [Fact]
        public async Task GetIdentityRoles_WithoutAnyParams_ReturnNotBeNullCollection()
        {
            var result = await Task.Run<List<IdentityRole>>(() =>
            {
                return _dataManager.Roles.GetIdentityRoles().ToList();
            });

            result.Should().BeOfType<List<IdentityRole>>();
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetMainIdentityRoles_WithoutAnyParams_ReturnNotBeNullCollection()
        {
            var result = await Task.Run<List<IdentityRole>>(() =>
            {
                return _dataManager.Roles.GetMainIdentityRoles().ToList();
            });

            result.Should().BeOfType<List<IdentityRole>>();
            result.Should().NotBeNull();
            result.Should().NotContain(r => r.Name == "Администратор");
        }
    }
}
