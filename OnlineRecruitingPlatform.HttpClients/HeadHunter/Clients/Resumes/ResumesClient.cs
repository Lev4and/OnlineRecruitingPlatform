using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Resumes
{
    public class ResumesClient : BaseHttpClient
    {
        public ResumesClient() : base("resumes/")
        {

        }

        public async Task<HttpResponseMessage> GetResumes(int perPage, int page)
        {
            try
            {
                return await _client.GetAsync($"?per_page={perPage}&page={page}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetResume(int id)
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
