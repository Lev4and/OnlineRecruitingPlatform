using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients.Companies
{
    public class CompaniesClient : BaseHttpClient
    {
        public CompaniesClient() : base("companies/")
        {

        }

        public async Task<HttpResponseMessage> GetCompanies(int limit, int offset)
        {
            try
            {
                return await _client.GetAsync($"?limit={limit}&offset={offset}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetCompany(int id)
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
