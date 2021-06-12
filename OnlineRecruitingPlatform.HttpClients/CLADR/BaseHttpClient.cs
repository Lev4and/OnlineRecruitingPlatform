using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlineRecruitingPlatform.HttpClients.CLADR
{
    public class BaseHttpClient
    {
        private string _baseUrl;
        private protected const string _token = "ZfhD3zS8F9fDyBs3Kzszynn828aTDBG9";

        private protected HttpClient _client;
        private protected HttpContent _content;
        private protected HttpClientHandler _handler;

        public BaseHttpClient()
        {
            _baseUrl = $"https://kladr-api.ru/api.php";

            _handler = new HttpClientHandler();
            _handler.AllowAutoRedirect = false;
            _handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            _client = new HttpClient(_handler);
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("OnlineRecruitingPlatform/1.0 (online-recruiting-platform-asp-net-core.ru)");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
