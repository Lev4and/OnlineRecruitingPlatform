using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class CountriesDirectoryImporter : Importer
    {
        private readonly CountiesClient _client;

        public CountriesDirectoryImporter() : base()
        {
            _client = new CountiesClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var countries =
                JsonConvert.DeserializeObject<CountryIV[]>(await (await _client.GetCounties()).Content
                    .ReadAsStringAsync()).ToList();

            Status = ImportStatus.SavingToDb;

            foreach (var item in countries)
            {
                _dataManager.Counties.SaveCountry(new Country()
                {
                    Name = item.Name,
                    IdentifierFromHeadHunter = item.IdentifierFromHeadHunter
                });

                Progress.CountImportedRecords++;
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            return JsonConvert.DeserializeObject<CountryIV[]>(await (await _client.GetCounties()).Content
                .ReadAsStringAsync()).ToList().Count;
        }
    }
}
