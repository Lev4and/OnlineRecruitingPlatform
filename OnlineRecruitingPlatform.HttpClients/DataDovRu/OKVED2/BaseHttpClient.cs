using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlineRecruitingPlatform.HttpClients.DataDovRu
{
    public class BaseHttpClient
    {
        private string _baseUrl;

        private protected const string _accessToken = "6ff4350b1d21e1b1bfc053d6bee84e93";

        private protected HttpClient _client;
        private protected HttpContent _content;
        private protected HttpClientHandler _handler;

        public BaseHttpClient(string pathAndQueryUrl)
        {
            _baseUrl = $"https://data.gov.ru/{pathAndQueryUrl}";

            _handler = new HttpClientHandler();
            _handler.AllowAutoRedirect = false;
            _handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            _client = new HttpClient(_handler);
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("OnlineRecruitingPlatform/1.0 (onlinerecruitingplatform.u1321851.plsk.regruhosting.ru)");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
