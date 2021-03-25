using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class DataManager
    {
        public IIdentityRolesRepository Roles { get; set; }

        public DataManager(IIdentityRolesRepository roles)
        {
            Roles = roles;
        }
    }
}
