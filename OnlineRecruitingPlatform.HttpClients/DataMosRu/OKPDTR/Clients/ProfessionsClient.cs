using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.HttpClients.DataMosRu.OKPDTR.Clients
{
    public class ProfessionsClient : BaseHttpClient
    {
        public ProfessionsClient() : base("datasets/2749/rows/")
        {

        }

        public async Task<HttpResponseMessage> GetProfessions()
        {
            try
            {
                return await _client.PostAsync($"?api_key={_apiKey}", new StringContent($"{JsonConvert.SerializeObject(new string[] { "NAME", "KOD" })}", Encoding.UTF8, "application/json"));
            }
            catch
            {
                return null;
            }
        }
    }
}
