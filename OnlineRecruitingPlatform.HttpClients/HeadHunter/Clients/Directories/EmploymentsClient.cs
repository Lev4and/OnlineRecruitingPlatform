using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class EmploymentsClient : BaseHttpClient
    {
        public EmploymentsClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetEmployments()
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
