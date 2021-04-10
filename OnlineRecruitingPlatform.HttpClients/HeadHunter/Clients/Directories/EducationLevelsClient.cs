﻿using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class EducationLevelsClient : BaseHttpClient
    {
        public EducationLevelsClient() : base("dictionaries/")
        {

        }

        public async Task<HttpResponseMessage> GetEducationLevels()
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
