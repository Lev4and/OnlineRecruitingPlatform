using OnlineRecruitingPlatform.HttpClients.UrlBuilders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class SkillsClient : BaseHttpClient
    {
        public SkillsClient() : base("skills/")
        {

        }

        public async Task<HttpResponseMessage> GetSkill(int skillId)
        {
            try
            {
                return await _client.GetAsync($"?id={skillId}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetSkills(int[] skillsIds)
        {
            try
            {
                var values = new string[skillsIds.Length];

                for(int i = 0; i < skillsIds.Length; i++)
                {
                    values[i] = $"{skillsIds[i]}";
                }

                return await _client.GetAsync($"{UrlBuilder.GetUrlWithParamsForHttpRequest("id", values)}");
            }
            catch
            {
                return null;
            }
        }
    }
}
