using OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.HeadHunter.Directories
{
    public class CountriesDirectoryImporterTests
    {
        private readonly CountriesDirectoryImporter _importer;

        public CountriesDirectoryImporterTests()
        {
            _importer = new CountriesDirectoryImporter();
        }

        [Fact]
        public async Task Import_WithParams()
        {
            await _importer.Start();
        }
    }
}
