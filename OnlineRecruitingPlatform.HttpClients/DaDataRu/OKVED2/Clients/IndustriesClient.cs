using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Formatters;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Clients
{
    public class IndustriesClient : BaseHttpClient
    {
        public IndustriesClient() : base("okved2/")
        {

        }

        public async Task<HttpResponseMessage> GetIndustry(OKVED code)
        {
            try
            {
                if(code == null)
                {
                    throw new ArgumentNullException("code", "Параметр не может быть пустым.");
                }

                if (code.IsFormatWithSubClass())
                {
                    throw new FormatException("Параметр имеет неверный формат.");
                }

                return await _client.PostAsync("", new StringContent($"{JsonConvert.SerializeObject(new { query = code.GetFormat() })}", Encoding.UTF8, "application/json"));
            }
            catch
            {
                return null;
            }
        }
    }
}
