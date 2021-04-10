using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class EmployerRelationsClient : BaseHttpClient
    {
        public EmployerRelationsClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetEmployerRelations()
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
