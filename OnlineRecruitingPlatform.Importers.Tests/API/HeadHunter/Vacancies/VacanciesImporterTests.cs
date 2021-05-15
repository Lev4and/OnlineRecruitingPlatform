using OnlineRecruitingPlatform.Importers.API.HeadHunter.Vacancies;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.HeadHunter.Vacancies
{
    public class VacanciesImporterTests
    {
        private readonly VacanciesImporter _importer;

        public VacanciesImporterTests()
        {
            _importer = new VacanciesImporter();
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
