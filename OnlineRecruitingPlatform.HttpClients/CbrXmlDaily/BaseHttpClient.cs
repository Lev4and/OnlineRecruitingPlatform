using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlineRecruitingPlatform.HttpClients.CbrXmlDaily
{
    public class BaseHttpClient
    {
        private string _baseUrl;

        private protected HttpClient _client;
        private protected HttpContent _content;
        private protected HttpClientHandler _handler;

        public BaseHttpClient(string pathAndQueryUrl)
        {
            _baseUrl = $"https://www.cbr-xml-daily.ru/{pathAndQueryUrl}";

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
