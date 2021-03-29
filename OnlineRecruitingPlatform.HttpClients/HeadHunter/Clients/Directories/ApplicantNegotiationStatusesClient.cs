using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class ApplicantNegotiationStatusesClient : BaseHttpClient
    {
        public ApplicantNegotiationStatusesClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetApplicantNegotiationStatuses()
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
