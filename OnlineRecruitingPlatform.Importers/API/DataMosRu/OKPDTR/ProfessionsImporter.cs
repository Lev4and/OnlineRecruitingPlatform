using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DataMosRu.OKPDTR.Clients;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Profession = OnlineRecruitingPlatform.Model.API.DataMosRu.OKPDTR.Profession;

namespace OnlineRecruitingPlatform.Importers.API.DataMosRu.OKPDTR
{
    public class ProfessionsImporter : Importer
    {
        private readonly PositionsClient _positionsClient;
        private readonly ProfessionsClient _professionsClient;

        public ProfessionsImporter()
        {
            _positionsClient = new PositionsClient();
            _professionsClient = new ProfessionsClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var responsePositions = await _positionsClient.GetPositions();
            var responseProfessions = await _professionsClient.GetProfessions();

            if (responsePositions.IsSuccessStatusCode && responseProfessions.IsSuccessStatusCode)
            {
                var resultPositionsJson = await responsePositions.Content.ReadAsStringAsync();
                var resultPositions = JsonConvert.DeserializeObject<Profession[]>(resultPositionsJson);

                var resultProfessionsJson = await responseProfessions.Content.ReadAsStringAsync();
                var resultProfessions = JsonConvert.DeserializeObject<Profession[]>(resultProfessionsJson);

                foreach (var profession in resultProfessions.Concat(resultPositions).ToArray())
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        Status = ImportStatus.SavingToDb;

                        _dataManager.Professions.SaveProfession(new Model.Database.Entities.Profession()
                        {
                            Code = profession.Content.Code,
                            Name = profession.Content.Name
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
            var responsePositions = await _positionsClient.GetPositions();
            var resultPositionsJson = await responsePositions.Content.ReadAsStringAsync();
            var resultPositions = JsonConvert.DeserializeObject<Profession[]>(resultPositionsJson);

            var responseProfessions = await _professionsClient.GetProfessions();
            var resultProfessionsJson = await responseProfessions.Content.ReadAsStringAsync();
            var resultProfessions = JsonConvert.DeserializeObject<Profession[]>(resultProfessionsJson);

            return resultPositions.Length + resultProfessions.Length;
        }
    }
}
