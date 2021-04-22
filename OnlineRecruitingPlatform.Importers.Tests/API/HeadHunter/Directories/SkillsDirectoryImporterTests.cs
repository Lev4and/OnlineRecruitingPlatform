using OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.HeadHunter.Directories
{
    public class SkillsDirectoryImporterTests
    {
        private readonly SkillsDirectoryImporter _importer;

        public SkillsDirectoryImporterTests()
        {
            _importer = new SkillsDirectoryImporter();
        }

        [Fact]
        public async Task Import_WithParams()
        {
            await _importer.Start(maxValueId: 55);
        }
    }
}
