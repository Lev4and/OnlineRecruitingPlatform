using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class CurrenciesClient : BaseHttpClient
    {
        public CurrenciesClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetCurrencies()
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
