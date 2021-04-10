using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class EmployerTypesClient : BaseHttpClient
    {
        public EmployerTypesClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetEmployerTypes()
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
