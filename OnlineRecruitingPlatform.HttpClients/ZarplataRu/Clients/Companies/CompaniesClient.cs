using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients.Companies
{
    public class CompaniesClient : BaseHttpClient
    {
        public CompaniesClient() : base("companies/")
        {

        }

        public async Task<HttpResponseMessage> GetCompanies(int limit, int offset, string searchString = "", string searchStringByLocation = "")
        {
            try
            {
                return await _client.GetAsync($"?limit={limit}&offset={offset}&q={searchString}%20{searchStringByLocation}");
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
