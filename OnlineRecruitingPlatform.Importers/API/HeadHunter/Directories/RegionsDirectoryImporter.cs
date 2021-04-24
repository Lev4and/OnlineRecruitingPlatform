using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class RegionsDirectoryImporter : Importer
    {
        private readonly RegionsClient _client;

        public RegionsDirectoryImporter()
        {
            _client = new RegionsClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var countries = _dataManager.Counties.GetCountries().ToList();

            foreach (var country in countries)
            {
                if (country.IdentifierFromHeadHunter != null)
                {
                    var regions = JsonConvert.DeserializeObject<RegionsDirectory>(
                        await (await _client.GetRegions((int)country.IdentifierFromHeadHunter)).Content
                            .ReadAsStringAsync()).Regions.ToList();

                    Status = ImportStatus.SavingToDb;

                    foreach (var region in regions)
                    {
                        _dataManager.Regions.SaveRegion(new Region()
                        {
                            Aoguid = null,
                            Name = region.Name,
                            CountryId = country.Id,
                            IdentifierFromHeadHunter = region.IdentifierFromHeadHunter,
                            IdentifierParentFromHeadHunter = region.IdentifierParentFromHeadHunter
                        });

                        Progress.CountImportedRecords++;
                    }
                }
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            var countRecords = 0;
            var countries = _dataManager.Counties.GetCountries().ToList();

            foreach (var country in countries)
            {
                if (country.IdentifierFromHeadHunter != null)
                {
                    countRecords += JsonConvert.DeserializeObject<RegionsDirectory>(await (await _client.GetRegions((int)country.IdentifierFromHeadHunter)).Content
                        .ReadAsStringAsync()).Regions.Length;
                }
            }

            return countRecords;
        }
    }
}
