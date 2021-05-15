using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients.Vacancies
{
    public class VacanciesClient : BaseHttpClient
    {
        public VacanciesClient() : base("vacancies/")
        {

        }

        public async Task<HttpResponseMessage> GetVacancies(int limit, int offset)
        {
            try
            {
                return await _client.GetAsync($"?limit={limit}&offset={offset}&period=today&is_new_only=1");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetVacancy(int id)
        {
            try
            {
                return await _client.GetAsync($"{id}/");
            }
            catch
            {
                return null;
            }
        }
    }
}
