﻿using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients.Resumes
{
    public class ResumesClient : BaseHttpClient
    {
        public ResumesClient() : base("resumes/")
        {

        }

        public async Task<HttpResponseMessage> GetResumes(int limit, int offset, string searchString = "", string searchStringByLocation = "")
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
