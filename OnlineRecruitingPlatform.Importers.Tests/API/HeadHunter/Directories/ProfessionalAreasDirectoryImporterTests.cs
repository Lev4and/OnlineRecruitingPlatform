using OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.HeadHunter.Directories
{
    public class ProfessionalAreasDirectoryImporterTests
    {
        private readonly ProfessionalAreasDirectoryImporter _importer;

        public ProfessionalAreasDirectoryImporterTests()
        {
            _importer = new ProfessionalAreasDirectoryImporter();
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
