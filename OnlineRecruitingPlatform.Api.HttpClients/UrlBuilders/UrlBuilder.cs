using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Api.HttpClients.UrlBuilders
{
    public static class UrlBuilder
    {
        public static string GetUrlWithParamsForHttpRequest(Dictionary<string, string> parameters)
        {
            var parametersUrl = "";

            foreach (var parameter in parameters)
            {
                if (!string.IsNullOrEmpty(parameter.Value))
                {
                    parametersUrl += (parametersUrl.Length == 0 ? $"?{parameter.Key}={parameter.Value}" : $"&{parameter.Key}={parameter.Value}");
                }
            }

            return parametersUrl;
        }
    }
}
