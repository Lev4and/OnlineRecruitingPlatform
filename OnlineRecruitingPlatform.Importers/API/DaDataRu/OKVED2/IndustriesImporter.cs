using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Clients;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Formatters;
using OnlineRecruitingPlatform.Model.API.DaDataRu.OKVED2;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.DaDataRu.OKVED2
{
    public class IndustriesImporter : Importer
    {
        public readonly IndustriesClient _client;

        public IndustriesImporter() : base()
        {
            _client = new IndustriesClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            for(int i = 1; i < 100; i++)
            {
                Status = ImportStatus.DownloadFromAPI;

                var industry = JsonConvert.DeserializeObject<SuggestionsIndustriesDirectory>(await (await _client.GetIndustry(new OKVED(i))).Content.ReadAsStringAsync());

                Status = ImportStatus.SavingToDb;

                if(industry != null)
                {
                    if(industry.Suggestions.Length == 1)
                    {
                        var data = industry.Suggestions[0].Data;

                        _dataManager.Industries.SaveIndustry(new Industry { Code = data.Code, Name = data.Name });

                        Progress.CountImportedRecords++;
                    }
                }
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            var countRecords = 0;

            for(int i = 1; i < 100; i++)
            {
                var industry = JsonConvert.DeserializeObject<SuggestionsIndustriesDirectory>(await (await _client.GetIndustry(new OKVED(i))).Content.ReadAsStringAsync());

                if(industry != null)
                {
                    if(industry.Suggestions.Length == 1)
                    {
                        countRecords++;
                    }
                }
            }

            return countRecords;
        }
    }
}
