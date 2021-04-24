using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DataDovRu.OKVED2.Clients;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.DataDovRu.OKVED2
{
    public class IndustriesImporter : Importer
    {
        private readonly OKVED2Client _client;

        public IndustriesImporter() : base()
        {
            _client = new OKVED2Client();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            Status = ImportStatus.DownloadFromAPI;

            var industries =
                JsonConvert.DeserializeObject<List<IndustryIVDataDovRu>>(await (await _client.GetOKVED2()).Content
                    .ReadAsStringAsync()).Where(i => i.Code != null ? i.Code.Length == 2 : false).ToList();

            Status = ImportStatus.SavingToDb;

            foreach (var industry in industries)
            {
                _dataManager.Industries.SaveIndustry(new Industry()
                {
                    Code = industry.Code,
                    Name = industry.Name
                });

                Progress.CountImportedRecords++;
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            return JsonConvert.DeserializeObject<List<IndustryIVDataDovRu>>(await (await _client.GetOKVED2()).Content
                .ReadAsStringAsync()).Where(i => i.Code != null ? i.Code.Length == 2 : false).ToList().Count;
        }
    }
}
