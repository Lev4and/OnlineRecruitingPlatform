using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.ZarplataRu.Clients.Vacancies;
using OnlineRecruitingPlatform.Model.API.ZarplataRu;
using OnlineRecruitingPlatform.Model.Gzip;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineRecruitingPlatform.HttpClients.CLADR.Clients;
using OnlineRecruitingPlatform.Model.API.CLADR;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System.IO;

namespace OnlineRecruitingPlatform.Importers.API.ZarplataRu.Vacancies
{
    public class VacanciesImporter : Importer
    {
        private readonly FIASClient _fiasClient;
        private readonly VacanciesClient _client;

        public VacanciesImporter() : base()
        {
            _client = new VacanciesClient();
            _fiasClient = new FIASClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            for (int i = 0; i <= Progress.CountFoundRecords / 100; i++)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    Status = ImportStatus.DownloadFromAPI;

                    var response = await _client.GetNewVacancies(100, i * 100);

                    if (response.IsSuccessStatusCode)
                    {
                        var resultByteArrayGzip = await response.Content.ReadAsByteArrayAsync();
                        var resultByteArray = Decompresser.Decompress(resultByteArrayGzip);
                        var resultString = Encoding.UTF8.GetString(resultByteArray, 0, resultByteArray.Length);
                        var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultString);

                        Status = ImportStatus.SavingToDb;

                        foreach (var vacancy in result.Vacancies)
                        {
                            if (!_dataManager.Vacancies.ContainsVacancyByIdentifierFromZarplataRu(vacancy.Id))
                            {
                                var responseVacancy = await _client.GetVacancy(vacancy.Id);

                                if (responseVacancy.IsSuccessStatusCode)
                                {
                                    var resultVacancyByteArrayGzip = await responseVacancy.Content.ReadAsByteArrayAsync();
                                    var resultVacancyByteArray = Decompresser.Decompress(resultVacancyByteArrayGzip);
                                    var resultVacancyString = Encoding.UTF8.GetString(resultVacancyByteArray, 0, resultVacancyByteArray.Length);
                                    var resultVacancy = JsonConvert.DeserializeObject<VacanciesDirectory>(resultVacancyString).Vacancies[0];

                                    var vacancyGuid = Guid.Empty;
                                    Guid? companyGuid = null;

                                    if (resultVacancy.Company != null)
                                    {
                                        if (resultVacancy.Company.Id != null ? !_dataManager.Companies.ContainsCompanyByIdentifierFromZarplataRu((int)
                                            resultVacancy.Company.Id) : false)
                                        {
                                            if (!_dataManager.Companies.ContainsCompany(resultVacancy.Company.Name))
                                            {
                                                var company = new Company()
                                                {
                                                    IsHr = resultVacancy.Company.IsHr,
                                                    Name = resultVacancy.Company.Name,
                                                    IsBlocked = resultVacancy.Company.IsBlocked,
                                                    CreatedAt = resultVacancy.Company.CreatedAt,
                                                    IsHolding = resultVacancy.Company.IsHolding,
                                                    ModifiedAt = resultVacancy.Company.ModifiedAt,
                                                    IsCommerce = resultVacancy.Company.IsCommerce,
                                                    IdentifierFromZarplataRu = resultVacancy.Company.Id,
                                                    IsBlacklisted = resultVacancy.Company.IsBlacklisted
                                                };

                                                _dataManager.Companies.SaveCompany(company);
                                                _dataManager.Companies.DetachCompany(company);
                                                _dataManager.CompanyInformation.SaveCompanyInformation(new CompanyInformation()
                                                {
                                                    CompanyId = company.Id,
                                                    Email = resultVacancy.Company.Email,
                                                    SiteUrl = resultVacancy.Company.SiteUrl,
                                                    Description = resultVacancy.Company.Description,
                                                    CardCompanyUrl = resultVacancy.Company.CardCompanyUrl
                                                });

                                                if (resultVacancy.Company.Logo != null)
                                                {
                                                    string logoOriginalPath = null;

                                                    if (!Directory.Exists(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\"))
                                                    {
                                                        Directory.CreateDirectory(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\");
                                                        Directory.CreateDirectory(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\logos\");
                                                        Directory.CreateDirectory(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\photos\");
                                                    }

                                                    if (!string.IsNullOrEmpty(resultVacancy.Company.Logo.Original))
                                                    {
                                                        logoOriginalPath = @$"images\upload\companies\{company.Id}\logos\Original.jpeg";

                                                        File.WriteAllBytes(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\{logoOriginalPath}", Convert.FromBase64String(resultVacancy.Company.Logo.Original));
                                                    }

                                                    _dataManager.CompanyLogos.SaveCompanyLogo(new CompanyLogo()
                                                    {
                                                        Original = logoOriginalPath,
                                                        CompanyId = company.Id
                                                    });
                                                }

                                                if (resultVacancy.Company.CompanyPhotos != null)
                                                {
                                                    if (!Directory.Exists(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\"))
                                                    {
                                                        Directory.CreateDirectory(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\");
                                                        Directory.CreateDirectory(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\logos\");
                                                        Directory.CreateDirectory(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\photos\");
                                                    }

                                                    foreach (var photo in resultVacancy.Company.CompanyPhotos)
                                                    {
                                                        string photoPath = null;
                                                        int countFiles = Directory.GetFiles(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\images\upload\companies\{company.Id}\photos\").Length;

                                                        if (!string.IsNullOrEmpty(photo.Photo))
                                                        {
                                                            photoPath = @$"images\upload\companies\{company.Id}\photos\{countFiles + 1}.jpeg";

                                                            File.WriteAllBytes(@$"C:\Users\andre\Desktop\Проекты\OnlineRecruitingPlatform\OnlineRecruitingPlatform.DevExtremeAspNetCore\wwwroot\{photoPath}", Convert.FromBase64String(photo.Photo));
                                                        }

                                                        _dataManager.CompanyPhotos.SaveCompanyPhoto(new CompanyPhoto()
                                                        {
                                                            IdentifierFromZarplataRu = photo.IdentifierFromZarplataRu,
                                                            CompanyId = company.Id,
                                                            Photo = photoPath
                                                        });
                                                    }
                                                }

                                                if (resultVacancy.Company.CompanyContacts != null)
                                                {
                                                    foreach (var contact in resultVacancy.Company.CompanyContacts)
                                                    {
                                                        if (!string.IsNullOrEmpty(resultVacancy.VacancyContact.City.Name) &&
                                                            !string.IsNullOrEmpty(resultVacancy.VacancyContact.StreetName) &&
                                                            !string.IsNullOrEmpty(resultVacancy.VacancyContact.BuildingName))
                                                        {
                                                            var address = new Address();
                                                            var companyContact = new CompanyContact();

                                                            if (!_dataManager.Addresses.ContainsAddress(contact.City.Name,
                                                                contact.StreetName, contact.BuildingName))
                                                            {
                                                                Guid? aoGuid = null;

                                                                var responseFIAS = await _fiasClient.GetBuilding($"{contact.City.Name}, {contact.StreetName}, {contact.BuildingName}");

                                                                if (responseFIAS.IsSuccessStatusCode)
                                                                {
                                                                    var responseFIASJson =
                                                                        await responseFIAS.Content.ReadAsStringAsync();
                                                                    var resultFIAS =
                                                                        JsonConvert.DeserializeObject<ResultContent>(
                                                                            responseFIASJson);

                                                                    if (resultFIAS.Contents != null)
                                                                    {
                                                                        if (resultFIAS.Contents.Length > 0)
                                                                        {
                                                                            aoGuid = resultFIAS.Contents[0].AoGuid;
                                                                        }
                                                                    }
                                                                }

                                                                address = new Address()
                                                                {
                                                                    Aoguid = aoGuid,
                                                                    CityName = contact.City.Name,
                                                                    StreetName = contact.StreetName,
                                                                    BuildingName = contact.BuildingName,
                                                                };

                                                                _dataManager.Addresses.SaveAddress(address);
                                                            }
                                                            else
                                                            {
                                                                address = _dataManager.Addresses.GetAddress(
                                                                    contact.City.Name, contact.StreetName,
                                                                    contact.BuildingName);
                                                            }

                                                            companyContact = new CompanyContact()
                                                            {
                                                                AddressId = address.Id,
                                                                CompanyId = (Guid)companyGuid
                                                            };

                                                            _dataManager.CompanyContacts.SaveCompanyContact(companyContact);

                                                            foreach (var phone in contact.Phones)
                                                            {
                                                                _dataManager.CompanyContactPhones.SaveCompanyContactPhone(
                                                                    new CompanyContactPhone()
                                                                    {
                                                                        Phone = phone.Phone,
                                                                        Comment = phone.Comment,
                                                                        CityCode = phone.CityCode,
                                                                        Formatted = phone.Formatted,
                                                                        CountryCode = phone.CountryCode,
                                                                        CompanyContactId = companyContact.Id,
                                                                        Number = phone.Number.Length > 7 ? "" : phone.Number
                                                                    });
                                                            }
                                                        }
                                                    }
                                                }

                                                if (resultVacancy.Company.CompanyInsiderInterviews != null ? resultVacancy.Company.CompanyInsiderInterviews.Length > 0 : false)
                                                {
                                                    foreach (var insiderInterview in resultVacancy.Company.CompanyInsiderInterviews)
                                                    {
                                                        _dataManager.CompanyInsiderInterviews.SaveCompanyInsiderInterview(
                                                            new CompanyInsiderInterview()
                                                            {
                                                                CompanyId = company.Id,
                                                                Url = insiderInterview.Url,
                                                                Title = insiderInterview.Title,
                                                                IdentifierFromZarplataRu = insiderInterview.IdentifierFromZarplataRu
                                                            });
                                                    }
                                                }

                                                companyGuid = company.Id;
                                            }
                                            else
                                            {
                                                var compnay = _dataManager.Companies.GetCompany(resultVacancy.Company.Name, false);

                                                companyGuid = compnay.Id;
                                                compnay.IdentifierFromZarplataRu = resultVacancy.Company.Id;

                                                _dataManager.Companies.SaveCompany(compnay);
                                                _dataManager.Companies.DetachCompany(compnay);
                                            }
                                        }
                                    }

                                    var vacancyEntity = new Vacancy()
                                    {
                                        Name = resultVacancy.Name,
                                        CompanyId = companyGuid,
                                        UpdatedAt = resultVacancy.UpdatedAt,
                                        ModifiedAt = resultVacancy.ModifiedAt,
                                        IdentifierFromZarplataRu = resultVacancy.Id,
                                        AcceptStudent = resultVacancy.AcceptStudent,
                                        AcceptPensioner = resultVacancy.AcceptPensioner,
                                        RemoteInterview = resultVacancy.RemoteInterview,
                                        AcceptHandicapped = resultVacancy.AcceptHandicapped,
                                        ScheduleId = resultVacancy.Schedule != null
                                            ? (Guid?)_dataManager.Schedules
                                                .GetScheduleByIdentifierFromZarplataRu(
                                                    (int)resultVacancy.Schedule.IdentifierFromZarplataRu).Id
                                            : null,
                                        EmploymentId = resultVacancy.Employment != null
                                            ? (Guid?)_dataManager.Employments
                                                .GetEmploymentByIdentifierFromZarplataRu(
                                                    (int)resultVacancy.Employment.IdentifierFromZarplataRu).Id
                                            : null,
                                        ExperienceId = resultVacancy.Experience != null
                                            ? (Guid?)_dataManager.Experiences
                                                .GetExperienceByIdentifierFromZarplataRu(
                                                    (int)resultVacancy.Experience.IdentifierFromZarplataRu).Id
                                            : null,
                                        EducationLevelId = resultVacancy.EducationLevel != null
                                            ? (Guid?)_dataManager.EducationLevels
                                                .GetEducationLevelByIdentifierFromZarplataRu(
                                                    (int)resultVacancy.EducationLevel.IdentifierFromZarplataRu).Id
                                            : null,
                                    };

                                    _dataManager.Vacancies.SaveVacancy(vacancyEntity);
                                    _dataManager.VacancySalaries.SaveVacancySalary(new VacancySalary()
                                    {
                                        Gross = resultVacancy.Gross,
                                        VacancyId = vacancyEntity.Id,
                                        Bonus = (double)resultVacancy.Bonus,
                                        UpperWageLimit = (int)resultVacancy.UpperWageLimit,
                                        LowerWageLimit = (int)resultVacancy.LowerWageLimit,
                                        UpperWageLimitRubles = (int)resultVacancy.UpperWageLimitRubles,
                                        LowerWageLimitRubles = (int)resultVacancy.LowerWageLimitRubles,
                                        CurrencyId = _dataManager.Currencies.GetCurrencyByIdentifierFromZarplataRu((int)resultVacancy.Currency.IdentifierFromZarplataRu).Id,
                                    });

                                    if (resultVacancy.VacancyContact != null)
                                    {
                                        var address = new Address();
                                        var vacancyContact = new VacancyContact();

                                        if (!string.IsNullOrEmpty(resultVacancy.VacancyContact.City.Name) &&
                                            !string.IsNullOrEmpty(resultVacancy.VacancyContact.StreetName) &&
                                            !string.IsNullOrEmpty(resultVacancy.VacancyContact.BuildingName))
                                        {
                                            if (!_dataManager.Addresses.ContainsAddress(resultVacancy.VacancyContact.City.Name,
                                                resultVacancy.VacancyContact.StreetName, resultVacancy.VacancyContact.BuildingName))
                                            {
                                                Guid? aoGuid = null;
                                                var responseFIAS = await _fiasClient.GetBuilding($"{resultVacancy.VacancyContact.City.Name}, {resultVacancy.VacancyContact.StreetName}, {resultVacancy.VacancyContact.BuildingName}", true);

                                                if (responseFIAS.IsSuccessStatusCode)
                                                {
                                                    var responseFIASJson =
                                                        await responseFIAS.Content.ReadAsStringAsync();
                                                    var resultFIAS =
                                                        JsonConvert.DeserializeObject<ResultContent>(
                                                            responseFIASJson);

                                                    if (resultFIAS.Contents != null)
                                                    {
                                                        if (resultFIAS.Contents.Length > 0)
                                                        {
                                                            aoGuid = resultFIAS.Contents[0].AoGuid;
                                                        }
                                                    }
                                                }

                                                address = new Address()
                                                {
                                                    Aoguid = aoGuid,
                                                    CityName = resultVacancy.VacancyContact.City.Name,
                                                    StreetName = resultVacancy.VacancyContact.StreetName,
                                                    BuildingName = resultVacancy.VacancyContact.BuildingName,
                                                };

                                                _dataManager.Addresses.SaveAddress(address);
                                            }
                                            else
                                            {
                                                address = _dataManager.Addresses.GetAddress(resultVacancy.VacancyContact.City.Name, resultVacancy.VacancyContact.StreetName,
                                                    resultVacancy.VacancyContact.BuildingName);
                                            }

                                            vacancyContact = new VacancyContact()
                                            {
                                                AddressId = (address != null ? (address.Id != default ? (Guid?)address.Id : null) : null),
                                                VacancyId = vacancyEntity.Id,
                                                Url = resultVacancy.VacancyContact.Url,
                                                Name = resultVacancy.VacancyContact.Name,
                                                Skype = resultVacancy.VacancyContact.Skype,
                                                Email = resultVacancy.VacancyContact.Email,
                                            };

                                            _dataManager.VacancyContacts.SaveVacancyContact(vacancyContact);

                                            foreach (var phone in resultVacancy.VacancyContact.Phones)
                                            {
                                                _dataManager.VacancyContactPhones.SaveVacancyContactPhone(new VacancyContactPhone()
                                                {
                                                    Phone = phone.Phone,
                                                    Comment = phone.Comment,
                                                    CityCode = phone.CityCode,
                                                    Formatted = phone.Formatted,
                                                    CountryCode = phone.CountryCode,
                                                    VacancyContactId = vacancyContact.Id,
                                                    Number = phone.Number.Length > 7 ? "" : phone.Number
                                                });
                                            }
                                        }
                                    }

                                    Progress.CountImportedRecords++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            var response = await _client.GetNewVacancies(1, 0);
            var resultByteArrayGzip = await response.Content.ReadAsByteArrayAsync();
            var resultByteArray = Decompresser.Decompress(resultByteArrayGzip);
            var resultString = Encoding.UTF8.GetString(resultByteArray, 0, resultByteArray.Length);
            var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultString);

            return result.Metadata.Resultset.Count;
        }
    }
}
