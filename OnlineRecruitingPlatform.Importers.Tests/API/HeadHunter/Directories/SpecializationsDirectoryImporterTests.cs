using OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.HeadHunter.Directories
{
    public class SpecializationsDirectoryImporterTests
    {
        private readonly SpecializationsDirectoryImporter _importer;

        public SpecializationsDirectoryImporterTests()
        {
            _importer = new SpecializationsDirectoryImporter();
        }

        [Fact]
        public async Task Import_WithParams()
        {
            await _importer.Start();

            while (_importer.IsRunning())
            {

            }
        }
    }
}
