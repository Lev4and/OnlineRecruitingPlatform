using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class AreasClient : BaseHttpClient
    {
        public AreasClient() : base("areas/")
        {

        }

        public async Task<HttpResponseMessage> GetAreas(int regionId)
        {
            try
            {
                return await _client.GetAsync($"{regionId}/");
            }
            catch
            {
                return null;
            }
        }
    }
}
