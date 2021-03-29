using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class ApplicantCommentAccessTypesClient : BaseHttpClient
    {
        public ApplicantCommentAccessTypesClient() : base ("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetApplicantCommentAccessTypes()
        {
            try
            {
                return await _client.GetAsync("");
            }
            catch
            {
                return null;
            }
        }
    }
}
