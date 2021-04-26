using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Companies;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Companies;
using System;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Companies
{
    public class CompaniesImporter : Importer
    {
        private readonly string _connectString;

        private readonly CompaniesClient _client;

        private readonly OleDbCommand _myCommand;
        private readonly OleDbConnection _myConnection;

        public CompaniesImporter() : base()
        {
            _client = new CompaniesClient();

            _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Companies.accdb;";

            _myConnection = new OleDbConnection(_connectString);

            _myCommand = new OleDbCommand();
            _myCommand.Connection = _myConnection;
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            _myConnection.Open();

            Status = ImportStatus.DownloadFromAPI;

            for (int i = 0; i <= int.MaxValue && Progress.ProgressImport < 100; i++)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var response = await _client.GetCompany(i);

                    if (response.IsSuccessStatusCode)
                    {
                        var company =
                            JsonConvert.DeserializeObject<CompanyDetailInformation>(await response.Content.ReadAsStringAsync());
                        var companyId = Guid.NewGuid();

                        Status = ImportStatus.SavingToDb;

                        _myCommand.CommandText = $"INSERT INTO [Companies] (Id, Name, IdentifierFromHeadHunter) VALUES (?, ?, ?);";

                        _myCommand.Parameters.Clear();
                        _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.VarChar)).Value = $"{companyId}";
                        _myCommand.Parameters.Add(new OleDbParameter("@Name", OleDbType.LongVarChar)).Value = company.Name;
                        _myCommand.Parameters.Add(new OleDbParameter("@IdentifierFromHeadHunter", OleDbType.Integer)).Value = company.Id;
                        _myCommand.ExecuteNonQuery();

                        if (company.Logo != null)
                        {
                            _myCommand.CommandText = $"INSERT INTO [CompanyLogos] (Id, CompanyId, Resolution90px, Resolution240px, Original) VALUES (?, ?, ?, ?, ?);";

                            _myCommand.Parameters.Clear();
                            _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.VarChar)).Value = $"{Guid.NewGuid()}";
                            _myCommand.Parameters.Add(new OleDbParameter("@CompanyId", OleDbType.VarChar)).Value = $"{companyId}";
                            _myCommand.Parameters.Add(new OleDbParameter("@Resolution90px", OleDbType.LongVarChar)).Value = new Func<object?>(
                                () =>
                                {
                                    if (string.IsNullOrEmpty(company.Logo.Resolution90px))
                                    {
                                        return DBNull.Value;
                                    }

                                    return company.Logo.Resolution90px;
                                }).Invoke();
                            _myCommand.Parameters.Add(new OleDbParameter("@Resolution240px", OleDbType.LongVarChar)).Value = new Func<object?>(
                                () =>
                                {
                                    if (string.IsNullOrEmpty(company.Logo.Resolution240px))
                                    {
                                        return DBNull.Value;
                                    }

                                    return company.Logo.Resolution240px;
                                }).Invoke();
                            _myCommand.Parameters.Add(new OleDbParameter("@Original", OleDbType.LongVarChar)).Value = new Func<object?>(
                                () =>
                                {
                                    if (string.IsNullOrEmpty(company.Logo.Original))
                                    {
                                        return DBNull.Value;
                                    }

                                    return company.Logo.Original;
                                }).Invoke();
                            _myCommand.ExecuteNonQuery();
                        }

                        _myCommand.CommandText = $"INSERT INTO [CompanyInformation] (Id, CompanyId, SiteUrl, Description, BrandedDescription) VALUES (?, ?, ?, ?, ?);";

                        _myCommand.Parameters.Clear();
                        _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.VarChar)).Value = $"{Guid.NewGuid()}";
                        _myCommand.Parameters.Add(new OleDbParameter("@CompanyId", OleDbType.VarChar)).Value = $"{companyId}";
                        _myCommand.Parameters.Add(new OleDbParameter("@SiteUrl", OleDbType.LongVarChar)).Value = new Func<object?>(
                            () =>
                            {
                                if (string.IsNullOrEmpty(company.SiteUrl))
                                {
                                    return DBNull.Value;
                                }

                                return company.SiteUrl;
                            }).Invoke();
                        _myCommand.Parameters.Add(new OleDbParameter("@Description", OleDbType.LongVarChar)).Value = new Func<object?>(
                            () =>
                            {
                                if (string.IsNullOrEmpty(company.Description))
                                {
                                    return DBNull.Value;
                                }

                                return company.Description;
                            }).Invoke();
                        _myCommand.Parameters.Add(new OleDbParameter("@BrandedDescription", OleDbType.LongVarChar)).Value = new Func<object?>(
                            () =>
                            {
                                if (string.IsNullOrEmpty(company.BrandedDescription))
                                {
                                    return DBNull.Value;
                                }

                                return company.BrandedDescription;
                            }).Invoke(); ;
                        _myCommand.ExecuteNonQuery();

                        foreach (var insiderInterview in company.InsiderInterviews)
                        {
                            _myCommand.CommandText = $"INSERT INTO [CompanyInsiderInterviews] (Id, CompanyId, Title, Url, IdentifierFromHeadHunter) VALUES (?, ?, ?, ?, ?);";

                            _myCommand.Parameters.Clear();
                            _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.VarChar)).Value = $"{Guid.NewGuid()}";
                            _myCommand.Parameters.Add(new OleDbParameter("@CompanyId", OleDbType.VarChar)).Value = $"{companyId}";
                            _myCommand.Parameters.Add(new OleDbParameter("@Title", OleDbType.LongVarChar)).Value = insiderInterview.Title;
                            _myCommand.Parameters.Add(new OleDbParameter("@Url", OleDbType.LongVarChar)).Value = insiderInterview.Url;
                            _myCommand.Parameters.Add(new OleDbParameter("@IdentifierFromHeadHunter", OleDbType.Integer)).Value = insiderInterview.IdentifierFromHeadHunter;
                            _myCommand.ExecuteNonQuery();
                        }

                        if (company.Location != null)
                        {
                            _myCommand.CommandText = $"INSERT INTO [CompanyLocation] (Id, CompanyId, AreaId) VALUES (?, ?, ?);";

                            _myCommand.Parameters.Clear();
                            _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.VarChar)).Value = $"{Guid.NewGuid()}";
                            _myCommand.Parameters.Add(new OleDbParameter("@CompanyId", OleDbType.VarChar)).Value = $"{companyId}";
                            _myCommand.Parameters.Add(new OleDbParameter("@AreaId", OleDbType.VarChar)).Value = $"{company.Location.Area}";
                            _myCommand.ExecuteNonQuery();
                        }

                        foreach (var subIndustry in company.SubIndustries)
                        {
                            _myCommand.CommandText = $"INSERT INTO [CompanySubIndustries] (Id, CompanyId, SubIndustryId) VALUES (?, ?, ?);";

                            _myCommand.Parameters.Clear();
                            _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.VarChar)).Value = $"{Guid.NewGuid()}";
                            _myCommand.Parameters.Add(new OleDbParameter("@CompanyId", OleDbType.VarChar)).Value = $"{companyId}";
                            _myCommand.Parameters.Add(new OleDbParameter("@SubIndustryId", OleDbType.VarChar)).Value = $"{subIndustry.Code}";
                            _myCommand.ExecuteNonQuery();
                        }

                        foreach (var relation in company.Relations)
                        {
                            _myCommand.CommandText = $"INSERT INTO [CompanyRelations] (Id, CompanyId, RelationId) VALUES (?, ?, ?);";

                            _myCommand.Parameters.Clear();
                            _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.VarChar)).Value = $"{Guid.NewGuid()}";
                            _myCommand.Parameters.Add(new OleDbParameter("@CompanyId", OleDbType.VarChar)).Value = $"{companyId}";
                            _myCommand.Parameters.Add(new OleDbParameter("@RelationId", OleDbType.VarChar)).Value = $"8c6a7194-7a09-46d2-88fd-897a61974570";
                            _myCommand.ExecuteNonQuery();
                        }

                        Progress.CountImportedRecords += 1;
                    }
                }
                else
                {
                    break;
                }
            }

            _myConnection.Close();

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            return JsonConvert.DeserializeObject<SearchResultCompanies>(await (await _client.GetCompanies(perPage: 1))
                .Content.ReadAsStringAsync()).Found;
        }
    }
}
