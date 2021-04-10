using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories
{
    public class DriverLicenseTypesClient : BaseHttpClient
    {
        public DriverLicenseTypesClient() : base ("dictionaries/")
        {
            
        }

        public async Task<HttpResponseMessage> GetDriverLicenseTypes()
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
