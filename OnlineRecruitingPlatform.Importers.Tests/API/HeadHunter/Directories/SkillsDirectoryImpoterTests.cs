using OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.HeadHunter.Directories
{
    public class SkillsDirectoryImpoterTests
    {
        private readonly SkillsDirectoryImpoter _impoter;

        public SkillsDirectoryImpoterTests()
        {
            _impoter = new SkillsDirectoryImpoter();
        }

        [Fact]
        public async Task Import_WithParams()
        {
            await _impoter.Start(maxValueSkillId: 55);
        }
    }
}
