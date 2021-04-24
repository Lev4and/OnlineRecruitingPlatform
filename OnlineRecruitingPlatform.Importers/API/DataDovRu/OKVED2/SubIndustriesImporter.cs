using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DataDovRu.OKVED2.Clients;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.DataDovRu.OKVED2
{
    public class SubIndustriesImporter : Importer
    {
        private readonly OKVED2Client _client;

        public SubIndustriesImporter() : base()
        {
            _client = new OKVED2Client();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var subIndustries =
                JsonConvert.DeserializeObject<List<SubIndustryIVDataDovRu>>(await (await _client.GetOKVED2()).Content
                    .ReadAsStringAsync()).Where(s => s.Code != null ? s.Code.Length >= 4 : false).ToList();

            Status = ImportStatus.SavingToDb;

            foreach (var subIndustry in subIndustries)
            {
                var industry = _dataManager.Industries.GetIndustryByCode(subIndustry.Code.Substring(0, 2));

                _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry()
                {
                    IndustryId = industry.Id,
                    Code = subIndustry.Code,
                    Name = subIndustry.Name
                });

                Progress.CountImportedRecords++;
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            return JsonConvert.DeserializeObject<List<SubIndustryIVDataDovRu>>(await (await _client.GetOKVED2()).Content
                    .ReadAsStringAsync()).Where(s => s.Code != null ? s.Code.Length >= 4 : false).ToList().Count;
        }
    }
}
