using FluentAssertions;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.HttpClients.Tests.HeadHunter.Clients.Directories
{
    public class SkillsClientTests
    {
        private readonly SkillsClient _client;

        public SkillsClientTests()
        {
            _client = new SkillsClient();
        }

        [Fact]
        public async Task GetSkill_WithNegativeParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSkill(-1);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SkillsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Skills.Should().BeOfType<Skill[]>();
            result.Skills.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetSkill_WithZeroParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSkill(0);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SkillsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Skills.Should().BeOfType<Skill[]>();
            result.Skills.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetSkill_WithPositiveParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSkill(1);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SkillsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Skills.Should().BeOfType<Skill[]>();
            result.Skills.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetSkill_WithHugeParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSkill(int.MaxValue);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SkillsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Skills.Should().BeOfType<Skill[]>();
            result.Skills.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetSkills_WithNullParam_ReturnNullResponse()
        {
            var response = await _client.GetSkills(null);

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetSkills_WithArrayZeroLengthParam_ReturnHttpStatusCode400Response()
        {
            var response = await _client.GetSkills(new int[0] { });
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SkillsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetSkills_WithArrayParam_ReturnHttpStatusCode200Response()
        {
            var response = await _client.GetSkills(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SkillsDirectory>(resultJson);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            result.Skills.Should().BeOfType<Skill[]>();
            result.Skills.Should().HaveCount(9);
        }
    }
}
