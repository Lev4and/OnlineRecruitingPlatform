using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Model.Deserializers
{
    public static class BaseDeserializer
    {
        public static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(resultJson);

                return result;
            }

            return (T)default;
        }
    }
}
