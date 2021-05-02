using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class SpecializationsDirectoryImporter : Importer
    {
        private readonly SpecializationsClient _client;
        private readonly ProfessionalArea[] _professionalAreas;

        public SpecializationsDirectoryImporter()
        {
            _client = new SpecializationsClient();
            _professionalAreas = _dataManager.ProfessionalAreas.GetProfessionalAreas().ToArray();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var response = await _client.GetSpecializations();

            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProfessionalAreaIVWithSpecializations[]>(resultJson);

                foreach (var professionalAreaIvWithSpecializations in result)
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        Status = ImportStatus.SavingToDb;

                        if (professionalAreaIvWithSpecializations.Specializations != null)
                        {
                            var professionalArea = _professionalAreas.SingleOrDefault(p =>
                                p.Code == professionalAreaIvWithSpecializations.IdentifierFromHeadHunter);

                            foreach (var specialization in professionalAreaIvWithSpecializations.Specializations)
                            {
                                _dataManager.Specializations.SaveSpecialization(new Specialization()
                                {
                                    Name = specialization.Name,
                                    ProfessionalAreaId = professionalArea.Id,
                                    Code = specialization.IdentifierFromHeadHunter,
                                    IdentifierFromHeadHunter = specialization.IdentifierFromHeadHunter
                                });

                                Progress.CountImportedRecords++;
                            }
                        }
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
            var countRecords = 0;

            var response = await _client.GetSpecializations();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProfessionalAreaIVWithSpecializations[]>(resultJson);

            foreach (var professionalAreaIvWithSpecializations in result)
            {
                if (professionalAreaIvWithSpecializations.Specializations != null)
                {
                    countRecords += professionalAreaIvWithSpecializations.Specializations.Length;
                }
            }

            return countRecords;
        }
    }
}
