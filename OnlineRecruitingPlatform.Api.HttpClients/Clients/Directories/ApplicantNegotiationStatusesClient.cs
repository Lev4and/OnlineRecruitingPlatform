using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories
{
    public class ApplicantNegotiationStatusesClient : BaseHttpClient
    {
        public ApplicantNegotiationStatusesClient() : base("directories/applicantNegotiationStatuses")
        {

        }

        public ApplicantNegotiationStatusesClient(HttpClient client) : base(client, "directories/applicantNegotiationStatuses")
        {

        }

        public async Task<HttpResponseMessage> GetApplicantNegotiationStatuses()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetApplicantNegotiationStatus(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddApplicantNegotiationStatus(ApplicantNegotiationStatus applicantNegotiationStatus)
        {
            return await _client.PostAsync("", new StringContent($"{JsonConvert.SerializeObject(applicantNegotiationStatus)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateApplicantNegotiationStatus(ApplicantNegotiationStatus applicantNegotiationStatus)
        {
            return await _client.PutAsync("", new StringContent($"{JsonConvert.SerializeObject(applicantNegotiationStatus)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteApplicantNegotiationStatus(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
