using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.ControllerTests
{
    public class IntegrationTest
    {
        private protected readonly HttpClient _client;

        public IntegrationTest()
        {
            _client = new WebApplicationFactory<Startup>().CreateClient();
        }
    }
}
