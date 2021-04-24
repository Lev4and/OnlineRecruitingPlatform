using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DataMosRu.OKVED2.Clients;
using OnlineRecruitingPlatform.Model.API.DataMosRu.OKVED2;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Importers.API.DataMosRu.OKVED2
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
                JsonConvert.DeserializeObject<List<ResultIndustryDirectory>>(await (await _client.GetOKVED2()).Content
                    .ReadAsStringAsync()).Where(i => i.Industry.Code != null ? i.Industry.Code.Length == 2 : false).ToList();

            Status = ImportStatus.SavingToDb;

            foreach (var item in industries)
            {
                _dataManager.Industries.SaveIndustry(new Industry()
                {
                    Code = item.Industry.Code,
                    Name = item.Industry.Name
                });

                Progress.CountImportedRecords++;
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            return JsonConvert.DeserializeObject<List<ResultIndustryDirectory>>(await (await _client.GetOKVED2()).Content
                .ReadAsStringAsync()).Where(i => i.Industry.Code != null ? i.Industry.Code.Length == 2 : false).ToList().Count;
        }
    }
}