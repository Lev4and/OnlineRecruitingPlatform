using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class LanguagesClient : BaseHttpClient
    {
        public LanguagesClient() : base("languages/")
        {

        }

        public async Task<HttpResponseMessage> GetLanguages()
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
