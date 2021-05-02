using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.CbrXmlDaily.Clients
{
    public class CurrencyQuotesClient : BaseHttpClient
    {
        public CurrencyQuotesClient() : base("archive/")
        {

        }

        public async Task<HttpResponseMessage> GetCurrencyQuotes(DateTime timestamp)
        {
            try
            {
                return await _client.GetAsync($"{timestamp.ToString("yyyy")}/{timestamp.ToString("MM")}/{timestamp.ToString("dd")}/daily_json.js");
            }
            catch
            {
                return null;
            }
        }
    }
}
