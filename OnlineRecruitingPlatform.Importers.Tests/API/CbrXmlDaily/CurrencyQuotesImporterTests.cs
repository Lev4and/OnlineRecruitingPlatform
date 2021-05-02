using OnlineRecruitingPlatform.Importers.API.CbrXmlDaily;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.CbrXmlDaily
{
    public class CurrencyQuotesImporterTests
    {
        private readonly CurrencyQuotesImporter _importer;

        public CurrencyQuotesImporterTests()
        {
            _importer = new CurrencyQuotesImporter();
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
