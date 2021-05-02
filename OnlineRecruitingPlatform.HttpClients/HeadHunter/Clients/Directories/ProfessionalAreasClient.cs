using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class ProfessionalAreasClient : BaseHttpClient
    {
        public ProfessionalAreasClient() : base("specializations/")
        {

        }

        public async Task<HttpResponseMessage> GetProfessionalAreas()
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
