using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class RegionsClient : BaseHttpClient
    {
        public RegionsClient() : base("areas/")
        {

        }

        public async Task<HttpResponseMessage> GetRegions(int countryId)
        {
            try
            {
                return await _client.GetAsync($"{countryId}/");
            }
            catch
            {
                return null;
            }
        }
    }
}
