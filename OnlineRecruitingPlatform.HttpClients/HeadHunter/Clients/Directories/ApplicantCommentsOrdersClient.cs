using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class ApplicantCommentsOrdersClient : BaseHttpClient
    {
        public ApplicantCommentsOrdersClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetApplicantCommentsOrders()
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
