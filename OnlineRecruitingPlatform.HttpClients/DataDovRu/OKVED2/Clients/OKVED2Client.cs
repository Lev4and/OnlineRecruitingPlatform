using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.DataDovRu.OKVED2.Clients
{
    public class OKVED2Client : BaseHttpClient
    {
        public OKVED2Client() : base("opendata/7710168515-okved2014/data-20190514T0100.json/")
        {

        }

        public async Task<HttpResponseMessage> GetOKVED2()
        {
            try
            {
                return await _client.GetAsync($"?encoding=UTF-8&access_token={_accessToken}");
            }
            catch
            {
                return null;
            }
        }
    }
}
