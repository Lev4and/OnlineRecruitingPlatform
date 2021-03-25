using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IIdentityRolesRepository
    {
        IQueryable<IdentityRole> GetIdentityRoles();

        IQueryable<IdentityRole> GetMainIdentityRoles();
    }
}
