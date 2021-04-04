using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories
{
    public class BusinessTripReadinessTypesClient :  BaseHttpClient
    {
        public BusinessTripReadinessTypesClient() : base("directories/businessTripReadinessTypes")
        {

        }

        public BusinessTripReadinessTypesClient(HttpClient client) : base (client, "directories/businessTripReadinessTypes")
        {

        }

        public async Task<HttpResponseMessage> GetBusinessTripReadinessTypes()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetBusinessTripReadiness(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddBusinessTripReadiness(BusinessTripReadiness businessTripReadiness)
        {
            return await _client.PostAsync("", new StringContent($"{JsonConvert.SerializeObject(businessTripReadiness)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateBusinessTripReadiness(BusinessTripReadiness businessTripReadiness)
        {
            return await _client.PutAsync("", new StringContent($"{JsonConvert.SerializeObject(businessTripReadiness)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteBusinessTripReadiness(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
