using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Gzip;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Model.Deserializers
{
    public static class GzipDeserializer
    {
        public static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var resultByteArrayGzip = await response.Content.ReadAsByteArrayAsync();
                var resultByteArray = Decompresser.Decompress(resultByteArrayGzip);
                var resultString = Encoding.UTF8.GetString(resultByteArray, 0, resultByteArray.Length);
                var result = JsonConvert.DeserializeObject<T>(resultString);

                return result;
            }

            return (T)default;
        }
    }
}
