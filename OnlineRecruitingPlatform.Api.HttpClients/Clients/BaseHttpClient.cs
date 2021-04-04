using OnlineRecruitingPlatform.Api.HttpClients.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlineRecruitingPlatform.Api.HttpClients.Clients
{
    public class BaseHttpClient
    {
        protected private string _baseUrl;

        protected private HttpClient _client;
        protected private HttpContent _content;
        protected private HttpClientHandler _clientHandler;

        public BaseHttpClient(string urlToController)
        {
            _baseUrl = ConfigHttpClients.GetAddressServer(urlToController);

            _clientHandler = new HttpClientHandler();
            _clientHandler.AllowAutoRedirect = false;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _client = new HttpClient(_clientHandler);

            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.UserAgent.ParseAdd(ConfigHttpClients.UserAgent);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public BaseHttpClient(HttpClient client, string urlToController)
        {
            ConfigHttpClients.UserAgent = "xUnit OnlineRecruitingPlatform.HttpClients.Tests/1.0 ()";
            ConfigHttpClients.Protocol = client.BaseAddress.Scheme;
            ConfigHttpClients.Port = $"{client.BaseAddress.Port}";
            ConfigHttpClients.Domain = client.BaseAddress.Host;

            _baseUrl = ConfigHttpClients.GetAddressServer(urlToController);

            _client = client;
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.UserAgent.ParseAdd(ConfigHttpClients.UserAgent);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
