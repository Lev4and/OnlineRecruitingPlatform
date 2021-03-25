using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFIdentityRolesRepository : IIdentityRolesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFIdentityRolesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public IQueryable<IdentityRole> GetIdentityRoles()
        {
            return _context.Roles.AsNoTracking();
        }

        public IQueryable<IdentityRole> GetMainIdentityRoles()
        {
            return _context.Roles.Where(r => r.Name != "Администратор").AsNoTracking();
        }
    }
}
