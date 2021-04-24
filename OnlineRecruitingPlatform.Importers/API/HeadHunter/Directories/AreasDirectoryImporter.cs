using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class AreasDirectoryImporter : Importer
    {
        private readonly AreasClient _client;

        public AreasDirectoryImporter() : base()
        {
            _client = new AreasClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var regions = _dataManager.Regions.GetRegions().ToList();

            foreach (var region in regions)
            {
                if (region.IdentifierFromHeadHunter != null)
                {
                    var areas = JsonConvert.DeserializeObject<AreasDirectory>(
                        await (await _client.GetAreas((int)region.IdentifierFromHeadHunter)).Content
                            .ReadAsStringAsync()).Areas.ToList();

                    Status = ImportStatus.SavingToDb;

                    foreach (var area in areas)
                    {
                        _dataManager.Areas.SaveArea(new Area()
                        {
                            Aoguid = null,
                            Name = area.Name,
                            RegionId = region.Id,
                            IdentifierFromHeadHunter = area.IdentifierFromHeadHunter,
                            IdentifierParentFromHeadHunter = area.IdentifierParentFromHeadHunter
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
            var regions = _dataManager.Regions.GetRegions().ToList();

            foreach (var region in regions)
            {
                if (region.IdentifierFromHeadHunter != null)
                {
                    countRecords += JsonConvert.DeserializeObject<AreasDirectory>(await (await _client.GetAreas((int)region.IdentifierFromHeadHunter)).Content
                        .ReadAsStringAsync()).Areas.Length;
                }
            }

            return countRecords;
        }
    }
}
