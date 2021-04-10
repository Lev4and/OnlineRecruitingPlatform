using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class GendersClient : BaseHttpClient
    {
        public GendersClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetGenders()
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
