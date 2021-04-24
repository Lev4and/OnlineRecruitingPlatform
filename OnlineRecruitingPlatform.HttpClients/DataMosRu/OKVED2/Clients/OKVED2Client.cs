using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OnlineRecruitingPlatform.HttpClients.DataMosRu.OKVED2.Clients
{
    public class OKVED2Client : BaseHttpClient
    {
        public OKVED2Client() : base("datasets/2745/rows/")
        {
            
        }

        public async Task<HttpResponseMessage> GetOKVED2()
        {
            try
            {
                return await _client.PostAsync($"?api_key={_apiKey}", new StringContent($"{JsonConvert.SerializeObject(new string[]{ "Number", "Name", "Kod" })}", Encoding.UTF8, "application/json"));
            }
            catch
            {
                return null;
            }
        }
    }
}