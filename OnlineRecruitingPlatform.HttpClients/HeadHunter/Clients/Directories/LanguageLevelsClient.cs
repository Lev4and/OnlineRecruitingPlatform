using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class LanguageLevelsClient : BaseHttpClient
    {
        public LanguageLevelsClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetLanguageLevels()
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
