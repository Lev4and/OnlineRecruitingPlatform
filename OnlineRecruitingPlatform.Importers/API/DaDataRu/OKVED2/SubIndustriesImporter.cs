using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Clients;
using OnlineRecruitingPlatform.HttpClients.DaDataRu.OKVED2.Formatters;
using OnlineRecruitingPlatform.Model.API.DaDataRu.OKVED2;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.DaDataRu.OKVED2
{
    public class SubIndustriesImporter : Importer
    {
        private readonly SubIndustriesClient _client;

        public SubIndustriesImporter() : base()
        {
            _client = new SubIndustriesClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            var data = new SubIndustryIV();
            var subIndustry = new SuggestionsSubIndustriesDirectory();

            for (int c = 1; c < 100; c++)
            {
                for (int sc = 0; sc < 10; sc++)
                {
                    Status = ImportStatus.DownloadFromAPI;

                    subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc))).Content.ReadAsStringAsync());

                    Status = ImportStatus.SavingToDb;

                    if (subIndustry != null)
                    {
                        if (subIndustry.Suggestions.Length == 1)
                        {
                            data = subIndustry.Suggestions[0].Data;

                            _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry { IndustryId = _dataManager.Industries.GetIndustryByCode(new OKVED(c).GetFormat()).Id, Code = data.Code, Name = data.Name });

                            Progress.CountImportedRecords++;
                        }
                    }

                    for (int g = 0; g < 10; g++)
                    {
                        Status = ImportStatus.DownloadFromAPI;

                        subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc, g))).Content.ReadAsStringAsync());

                        Status = ImportStatus.SavingToDb;

                        if (subIndustry != null)
                        {
                            if (subIndustry.Suggestions.Length == 1)
                            {
                                data = subIndustry.Suggestions[0].Data;

                                _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry { IndustryId = _dataManager.Industries.GetIndustryByCode(new OKVED(c).GetFormat()).Id, Code = data.Code, Name = data.Name });

                                Progress.CountImportedRecords++;
                            }
                        }

                        for (int sg = 0; sg < 10; sg++)
                        {
                            Status = ImportStatus.DownloadFromAPI;

                            subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc, g, sg))).Content.ReadAsStringAsync());

                            Status = ImportStatus.SavingToDb;

                            if (subIndustry != null)
                            {
                                if (subIndustry.Suggestions.Length == 1)
                                {
                                    data = subIndustry.Suggestions[0].Data;

                                    _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry { IndustryId = _dataManager.Industries.GetIndustryByCode(new OKVED(c).GetFormat()).Id, Code = data.Code, Name = data.Name });

                                    Progress.CountImportedRecords++;
                                }
                            }

                            for (int k = 0; k < 10; k++)
                            {
                                Status = ImportStatus.DownloadFromAPI;

                                subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc, g, sg, k))).Content.ReadAsStringAsync());

                                Status = ImportStatus.SavingToDb;

                                if (subIndustry != null)
                                {
                                    if (subIndustry.Suggestions.Length == 1)
                                    {
                                        data = subIndustry.Suggestions[0].Data;

                                        _dataManager.SubIndustries.SaveSubIndustry(new SubIndustry { IndustryId = _dataManager.Industries.GetIndustryByCode(new OKVED(c).GetFormat()).Id, Code = data.Code, Name = data.Name });

                                        Progress.CountImportedRecords++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            var countRecords = 0;
            var subIndustry = new SuggestionsSubIndustriesDirectory();

            for (int c = 1; c < 100; c++)
            {
                for(int sc = 0; sc < 10; sc++)
                {
                    subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc))).Content.ReadAsStringAsync());

                    if (subIndustry != null)
                    {
                        if (subIndustry.Suggestions.Length == 1)
                        {
                            countRecords++;

                            Progress.CountFoundRecords = countRecords;
                        }
                    }

                    for (int g = 0; g < 10; g++)
                    {
                        subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc, g))).Content.ReadAsStringAsync());

                        if (subIndustry != null)
                        {
                            if (subIndustry.Suggestions.Length == 1)
                            {
                                countRecords++;

                                Progress.CountFoundRecords = countRecords;
                            }
                        }

                        for (int sg = 0; sg < 10; sg++)
                        {
                            subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc, g, sg))).Content.ReadAsStringAsync());

                            if (subIndustry != null)
                            {
                                if (subIndustry.Suggestions.Length == 1)
                                {
                                    countRecords++;

                                    Progress.CountFoundRecords = countRecords;
                                }
                            }

                            for (int k = 0; k < 10; k++)
                            {
                                subIndustry = JsonConvert.DeserializeObject<SuggestionsSubIndustriesDirectory>(await (await _client.GetSubIndustry(new OKVED(c, sc, g, sg, k))).Content.ReadAsStringAsync());

                                if(subIndustry != null)
                                {
                                    if(subIndustry.Suggestions.Length == 1)
                                    {
                                        countRecords++;

                                        Progress.CountFoundRecords = countRecords;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return countRecords;
        }
    }
}
