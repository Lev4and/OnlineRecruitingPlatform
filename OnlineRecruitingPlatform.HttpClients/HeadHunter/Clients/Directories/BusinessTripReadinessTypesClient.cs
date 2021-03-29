using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class BusinessTripReadinessTypesClient : BaseHttpClient
    {
        public BusinessTripReadinessTypesClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetBusinessTripReadinessTypes()
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
