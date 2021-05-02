using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlineRecruitingPlatform.HttpClients.DaDataRu
{
    public class BaseHttpClient
    {
        private string _baseUrl;
        private readonly string _authorizationToken;

        private protected HttpClient _client;
        private protected HttpContent _content;
        private protected HttpClientHandler _handler;

        public BaseHttpClient(string pathAndQueryUrl)
        {
            _baseUrl = $"https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/{pathAndQueryUrl}";
            _authorizationToken = "363ae91a17f38ccbf02f0cdb52038ee061197c4e";

            _handler = new HttpClientHandler();
            _handler.AllowAutoRedirect = false;
            _handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            _client = new HttpClient(_handler);
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("OnlineRecruitingPlatform/1.0 (onlinerecruitingplatform.u1321851.plsk.regruhosting.ru)");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _authorizationToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
