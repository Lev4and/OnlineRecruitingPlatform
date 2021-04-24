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
                JsonConvert.DeserializeObject<List<ResultSubIndustryDirectory>>(await (await _client.GetOKVED2()).Content
                    .ReadAsStringAsync()).Where(i => i.SubIndustry.Code != null ? i.SubIndustry.Code.Length >= 4 : false).ToList();

            Status = ImportStatus.SavingToDb;

            foreach (var item in subIndustries)
            {
                var industry = _dataManager.Industries.GetIndustryByCode(item.SubIndustry.Code.Substring(0, 2));

                _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry()
                {
                    IndustryId = industry.Id,
                    Code = item.SubIndustry.Code,
                    Name = item.SubIndustry.Name
                });

                Progress.CountImportedRecords++;
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            return JsonConvert.DeserializeObject<List<ResultSubIndustryDirectory>>(await (await _client.GetOKVED2()).Content
                .ReadAsStringAsync()).Where(i => i.SubIndustry.Code != null ? i.SubIndustry.Code.Length >= 4 : false).ToList().Count;
            
            
        }
    }
}