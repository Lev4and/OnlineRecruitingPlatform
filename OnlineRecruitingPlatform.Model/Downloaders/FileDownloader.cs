using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Model.Downloaders
{
    public class FileDownloader
    {
        private string _baseUrl;

        private protected HttpClient _client;
        private protected HttpContent _content;
        private protected HttpClientHandler _handler;

        public FileDownloader(string urlToFile)
        {
            _baseUrl = $"{urlToFile}";

            _handler = new HttpClientHandler();
            _handler.AllowAutoRedirect = false;
            _handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            _client = new HttpClient(_handler);
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("OnlineRecruitingPlatform/1.0 (onlinerecruitingplatform.u1321851.plsk.regruhosting.ru)");
        }

        public async Task<HttpResponseMessage> Download()
        {
            try
            {
                return await _client.GetAsync("");
            }
            catch
            {
                return null;
            }
        }
    }
}
