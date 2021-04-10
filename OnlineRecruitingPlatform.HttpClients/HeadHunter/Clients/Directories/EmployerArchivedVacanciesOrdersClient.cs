using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class EmployerArchivedVacanciesOrdersClient : BaseHttpClient
    {
        public EmployerArchivedVacanciesOrdersClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetEmployerArchivedVacanciesOrders()
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
