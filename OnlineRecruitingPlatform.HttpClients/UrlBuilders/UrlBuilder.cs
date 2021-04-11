using System.Collections.Generic;

namespace OnlineRecruitingPlatform.HttpClients.UrlBuilders
{
    public static class UrlBuilder
    {
        public static string GetUrlWithParamsForHttpRequest(string key, string[] values)
        {
            var parametersUrl = "";

            for(int i = 0; i < values.Length; i++)
            {
                if (!string.IsNullOrEmpty(values[i]))
                {
                    parametersUrl += (parametersUrl.Length == 0 ? $"?{key}={values[i]}" : $"&{key}={values[i]}");
                }
            }

            return parametersUrl;
        }

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
