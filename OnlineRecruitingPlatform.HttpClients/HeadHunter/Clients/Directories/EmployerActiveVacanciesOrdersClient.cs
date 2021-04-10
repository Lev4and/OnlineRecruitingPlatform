using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class EmployerActiveVacanciesOrdersClient : BaseHttpClient
    {
        public EmployerActiveVacanciesOrdersClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetEmployerActiveVacanciesOrders()
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
