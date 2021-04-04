using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories
{
    public class CurrenciesClient : BaseHttpClient
    {
        public CurrenciesClient() : base("directories/currencies")
        {

        }

        public CurrenciesClient(HttpClient client) : base (client, "directories/currencies")
        {

        }

        public async Task<HttpResponseMessage> GetCurrencies()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetCurrency(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddCurrency(Currency currency)
        {
            return await _client.PostAsync("", new StringContent($"{JsonConvert.SerializeObject(currency)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateCurrency(Currency currency)
        {
            return await _client.PutAsync("", new StringContent($"{JsonConvert.SerializeObject(currency)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteCurrency(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
