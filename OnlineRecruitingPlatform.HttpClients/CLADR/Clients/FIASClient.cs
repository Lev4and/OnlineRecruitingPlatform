using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.CLADR.Clients
{
    public class FIASClient : BaseHttpClient
    {
        public FIASClient() : base()
        {

        }

        public async Task<HttpResponseMessage> GetRegion(string regionName)
        {
            try
            {
                regionName.Replace("Республика", "");
                regionName.Replace("республика", "");
                regionName.Replace("область", "");
                regionName.Replace("край", "");
                regionName.Replace("АО", "");
                
                return await _client.GetAsync($"?query={regionName}&contentType=region&token={_token}");
            }
            catch
            {
                return null;
            }
        }
    }
}
