using OnlineRecruitingPlatform.Importers.API.DataMosRu.OKPDTR;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.DataMosRu.OKPDTR
{
    public class ProfessionsImporterTests
    {
        private readonly ProfessionsImporter _importer;

        public ProfessionsImporterTests()
        {
            _importer = new ProfessionsImporter();
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
