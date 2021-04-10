using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class ExperiencesClient : BaseHttpClient
    {
        public ExperiencesClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetExperiences()
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
