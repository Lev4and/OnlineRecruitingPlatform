using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class DataManager
    {
        public IApplicantCommentAccessTypesRepository ApplicantCommentAccessTypes;
        public IIdentityRolesRepository Roles { get; set; }

        public DataManager(IApplicantCommentAccessTypesRepository applicantCommentAccessTypes, IIdentityRolesRepository roles)
        {
            ApplicantCommentAccessTypes = applicantCommentAccessTypes;
            Roles = roles;
        }
    }
}
