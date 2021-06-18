using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Companies
{
    public class CompaniesClient : BaseHttpClient
    {
        public CompaniesClient() : base("employers/")
        {

        }

        public async Task<HttpResponseMessage> GetCompany(int companyId)
        {
            try
            {
                return await _client.GetAsync($"{companyId}/");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetCompanies(int pageNumber = 0, int perPage = 100, string searchString = "", string searchStringByLocation = "")
        {
            try
            {
                if (pageNumber < 0)
                {
                    pageNumber = 0;
                }

                if(perPage <= 0 || perPage > 100)
                {
                    perPage = 20;
                }

                return await _client.GetAsync($"?page={pageNumber}&per_page={perPage}&text={searchString}%20{searchStringByLocation}");
            }
            catch
            {
                return null;
            }
        }
    }
}
