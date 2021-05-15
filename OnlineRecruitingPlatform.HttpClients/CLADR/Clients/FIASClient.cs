using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.CLADR.Clients
{
    public class FIASClient : BaseHttpClient
    {
        public FIASClient() : base()
        {

        }

        public async Task<HttpResponseMessage> GetBuilding(string stringSearch, bool withParent = false)
        {
            try
            {
                if (withParent)
                {
                    return await _client.GetAsync($"?query={stringSearch.Replace(@"/", @"\/")}&withParent=1&oneString=1&contentType=building&limit=1&token={_token}");
                }
                else
                {
                    return await _client.GetAsync($"?query={stringSearch.Replace(@"/", @"\/")}&oneString=1&contentType=building&limit=1&token={_token}");
                }
            }
            catch
            {
                return null;
            }
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

        public async Task<HttpResponseMessage> GetCity(string cityName)
        {
            try
            {
                cityName.Replace("Город", "");
                cityName.Replace("город", "");

                return await _client.GetAsync($"?query={cityName}&contentType=city&token={_token}");
            }
            catch
            {
                return null;
            }
        }
    }
}
