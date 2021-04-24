using System.Diagnostics;
using OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.HeadHunter.Directories
{
    public class RegionsDirectoryImporterTests
    {
        private readonly RegionsDirectoryImporter _importer;

        public RegionsDirectoryImporterTests()
        {
            _importer = new RegionsDirectoryImporter();
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
