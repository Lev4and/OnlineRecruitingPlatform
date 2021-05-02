using System;
using OnlineRecruitingPlatform.HttpClients.CbrXmlDaily.Clients;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.API.CbrXmlDaily;
using CurrencyQuote = OnlineRecruitingPlatform.Model.API.CbrXmlDaily.CurrencyQuote;

namespace OnlineRecruitingPlatform.Importers.API.CbrXmlDaily
{
    public class CurrencyQuotesImporter : Importer
    {
        private readonly CurrencyQuotesClient _client;
        private readonly Currency[] _currencies;

        public CurrencyQuotesImporter() : base()
        {
            _client = new CurrencyQuotesClient();
            _currencies = _dataManager.Currencies.GetCurrencies().AsNoTracking().ToList().ToArray();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            DateTime dateTime = new DateTime(2021, 1, 1);

            while (dateTime < DateTime.Now)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    Status = ImportStatus.DownloadFromAPI;

                    var response = await _client.GetCurrencyQuotes(dateTime);

                    if (response.IsSuccessStatusCode)
                    {
                        var resultJson = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<DailyCurrencyQuotes>(resultJson);
                        var properties = result.CurrencyQuoteDirectory.GetType().GetProperties();

                        Status = ImportStatus.SavingToDb;

                        foreach (var property in properties)
                        {
                            var currencyQuote = (CurrencyQuote)(property.GetValue(result.CurrencyQuoteDirectory));

                            if (currencyQuote != null)
                            {
                                var currency = _currencies.SingleOrDefault(c => c.Code == currencyQuote.CharCode);

                                _dataManager.CurrencyQuotes.SaveCurrencyQuote(new Model.Database.Entities.CurrencyQuote()
                                {
                                    CurrencyId = currency.Id,
                                    Nominal = currencyQuote.Nominal,
                                    Timestamp = result.Timestamp,
                                    Value = currencyQuote.Value
                                });
                            }
                        }

                        Progress.CountImportedRecords++;

                    }

                    dateTime = dateTime.AddDays(1);
                }
                else
                {
                    break;
                }
            }

            Status = ImportStatus.DownloadFromAPI;



            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            return (DateTime.Now.AddDays(-1) - new DateTime(2021, 1, 1)).Days;
        }
    }
}
