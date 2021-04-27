using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.CLADR.Clients;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Formatters;
using OnlineRecruitingPlatform.Model.API.DaDataRu.OKVED2;
using OnlineRecruitingPlatform.Model.Database.Entities;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.CLADR.Clients
{
    public class FIASClientTests
    {
        private readonly FIASClient _client;

        public FIASClientTests()
        {
            _client = new FIASClient();
        }
    }
}
