using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class ProfessionalAreasDirectoryImporter : Importer
    {
        private readonly ProfessionalAreasClient _client;

        public ProfessionalAreasDirectoryImporter()
        {
            _client = new ProfessionalAreasClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var response = await _client.GetProfessionalAreas();

            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProfessionalAreaIV[]>(resultJson);

                foreach (var professionalArea in result)
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        Status = ImportStatus.SavingToDb;

                        _dataManager.ProfessionalAreas.SaveProfessionalArea(new ProfessionalArea()
                        {
                            Name = professionalArea.Name,
                            Code = professionalArea.IdentifierFromHeadHunter,
                            IdentifierFromHeadHunter = professionalArea.IdentifierFromHeadHunter
                        });

                        Progress.CountImportedRecords++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            var response = await _client.GetProfessionalAreas();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProfessionalAreaIV[]>(resultJson);

            return result.Length;
        }
    }
}
