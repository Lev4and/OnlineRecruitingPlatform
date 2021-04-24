using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class CountiesClient : BaseHttpClient
    {
        public CountiesClient() : base ("areas/countries/")
        {

        }

        public async Task<HttpResponseMessage> GetCounties()
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
