using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.DataMosRu.OKPDTR.Clients
{
    public class PositionsClient : BaseHttpClient
    {
        public PositionsClient() : base("datasets/2748/rows/")
        {

        }

        public async Task<HttpResponseMessage> GetPositions()
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
