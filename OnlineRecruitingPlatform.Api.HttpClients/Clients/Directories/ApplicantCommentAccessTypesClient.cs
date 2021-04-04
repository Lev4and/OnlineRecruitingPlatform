using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Api.HttpClients.Clients.Directories
{
    public class ApplicantCommentAccessTypesClient : BaseHttpClient
    {
        public ApplicantCommentAccessTypesClient() : base("directories/applicantCommentAccessTypes")
        {

        }

        public ApplicantCommentAccessTypesClient(HttpClient client) : base(client, "directories/applicantCommentAccessTypes")
        {

        }

        public async Task<HttpResponseMessage> GetApplicantCommentAccessTypes()
        {
            return await _client.GetAsync("");
        }

        public async Task<HttpResponseMessage> GetApplicantCommentAccessType(Guid id)
        {
            return await _client.GetAsync($"{id}");
        }

        public async Task<HttpResponseMessage> AddApplicantCommentAccessType(ApplicantCommentAccessType applicantCommentAccessType)
        {
            return await _client.PostAsync($"", new StringContent($"{JsonConvert.SerializeObject(applicantCommentAccessType)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> UpdateApplicantCommentAccessType(ApplicantCommentAccessType applicantCommentAccessType)
        {
            return await _client.PutAsync($"", new StringContent($"{JsonConvert.SerializeObject(applicantCommentAccessType)}", Encoding.UTF8, "application/json"));
        }

        public async Task<HttpResponseMessage> DeleteApplicantCommentAccessType(Guid id)
        {
            return await _client.DeleteAsync($"{id}");
        }
    }
}
