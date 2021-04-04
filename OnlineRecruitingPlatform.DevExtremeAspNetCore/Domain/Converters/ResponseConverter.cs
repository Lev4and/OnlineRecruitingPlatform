using Newtonsoft.Json;
using System.Net.Http;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Domain.Converters
{
    public static class ResponseConverter
    {
        public static T Convert<T>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
