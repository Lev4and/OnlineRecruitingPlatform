using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories
{
    public class ApplicantCommentsOrdersClient : BaseHttpClient
    {
        public ApplicantCommentsOrdersClient() : base("directories/applicantCommentsOrders")
        {

        }

        public ApplicantCommentsOrdersClient(HttpClient client) : base(client, "directories/applicantCommentsOrders")
        {

        }

        public async Task<HttpResponseMessage> GetApplicantCommentsOrders()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetApplicantCommentsOrder(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddApplicantCommentsOrder(ApplicantCommentsOrder applicantCommentsOrder)
        {
            return await _client.PostAsync("", new StringContent($"{JsonConvert.SerializeObject(applicantCommentsOrder)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateApplicantCommentsOrder(ApplicantCommentsOrder applicantCommentsOrder)
        {
            return await _client.PutAsync("", new StringContent($"{JsonConvert.SerializeObject(applicantCommentsOrder)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteApplicantCommentsOrder(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
