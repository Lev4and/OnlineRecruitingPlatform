using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DataDovRu.OKVED2.Clients;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.DataDovRu.OKVED2.Clients
{
    public class OKVED2ClientTests
    {
        private readonly OKVED2Client _client;

        public OKVED2ClientTests()
        {
            _client = new OKVED2Client();
        }

        [Fact]
        public async Task GetOKVED2_WithoutParams_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetOKVED2();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IndustryIVDataDovRu[]>(resultJson)
                .Where(i => i.Code != null ? i.Code.Length == 2 : false).ToArray();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Should().BeOfType<IndustryIVDataDovRu[]>();
            result.Should().HaveCountGreaterThan(0);
        }
    }
}
