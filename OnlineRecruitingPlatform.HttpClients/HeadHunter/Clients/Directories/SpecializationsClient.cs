using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class SpecializationsClient : BaseHttpClient
    {
        public SpecializationsClient() : base("specializations/")
        {

        }

        public async Task<HttpResponseMessage> GetSpecializations()
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
