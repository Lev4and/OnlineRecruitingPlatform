using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Vacancies;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Vacancies;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OnlineRecruitingPlatform.HttpClients.CLADR.Clients;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Companies;
using OnlineRecruitingPlatform.Model.API.CLADR;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Companies;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Vacancies
{
    public class VacanciesImporter : Importer
    {
        private readonly FIASClient _fiasClient;
        private readonly CompaniesClient _companiesClient;
        private readonly VacanciesClient _vacanciesClient;

        public VacanciesImporter()
        {
            _fiasClient = new FIASClient();
            _companiesClient = new CompaniesClient();
            _vacanciesClient = new VacanciesClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            Progress.CountFoundRecords = await CalculateCountRecords();

            var dateTo = new DateTime(2021, 5, 14, 22, 1, 0);
            var dateFrom = new DateTime(2021, 5, 14, 22, 0, 0);

            while (dateTo <= DateTime.Now)
            {
                var response = await _vacanciesClient.GetVacancies(dateFrom, dateTo, 100, 0);

                if (response.IsSuccessStatusCode)
                {
                    Status = ImportStatus.DownloadFromAPI;

                    var resultJson = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultJson);

                    for (int i = 0; i <= result.Pages; i++)
                    {
                        var responseVacancies = await _vacanciesClient.GetVacancies(dateFrom, dateTo, 100, i);

                        if (responseVacancies.IsSuccessStatusCode)
                        {
                            var resultVacanciesJson = await responseVacancies.Content.ReadAsStringAsync();
                            var resultVacancies = JsonConvert.DeserializeObject<VacanciesDirectory>(resultVacanciesJson);

                            Status = ImportStatus.SavingToDb;

                            if (resultVacancies.Vacancies != null)
                            {
                                foreach (var vacancy in resultVacancies.Vacancies)
                                {
                                    if (!_dataManager.Vacancies.ContainsVacancyByIdentifierFromHeadHunter((int)vacancy.Id))
                                    {
                                        var responseVacancy = await _vacanciesClient.GetVacancy((int)vacancy.Id);

                                        if (responseVacancy.IsSuccessStatusCode)
                                        {
                                            var resultVacancyJson = await responseVacancy.Content.ReadAsStringAsync();
                                            var resultVacancy =
                                                JsonConvert.DeserializeObject<VacancyIV>(resultVacancyJson);

                                            Guid? companyGuid = null;

                                            if (resultVacancy.Company != null ? resultVacancy.Company.IdentifierFromHeadHunter != null : false)
                                            {
                                                var responseCompany =
                                                    await _companiesClient.GetCompany((int)resultVacancy.Company.IdentifierFromHeadHunter);

                                                if (responseCompany.IsSuccessStatusCode)
                                                {
                                                    var resultCompanyJson = await responseCompany.Content.ReadAsStringAsync();
                                                    var resultCompany =
                                                        JsonConvert.DeserializeObject<CompanyDetailInformation>(resultCompanyJson);

                                                    if (!_dataManager.Companies.ContainsCompanyByIdentifierFromHeadHunter(resultCompany.Id))
                                                    {
                                                        if (!_dataManager.Companies.ContainsCompany(resultCompany.Name))
                                                        {
                                                            var company = new Company()
                                                            {
                                                                Name = resultCompany.Name,
                                                                IdentifierFromHeadHunter = resultCompany.Id
                                                            };

                                                            _dataManager.Companies.SaveCompany(company);
                                                            _dataManager.Companies.DetachCompany(company);
                                                            _dataManager.CompanyInformation.SaveCompanyInformation(new CompanyInformation()
                                                            {
                                                                CompanyId = company.Id,
                                                                SiteUrl = resultCompany.SiteUrl,
                                                                Description = resultCompany.Description,
                                                                BrandedDescription = resultCompany.BrandedDescription
                                                            });

                                                            if (resultCompany.Logo != null)
                                                            {
                                                                _dataManager.CompanyLogos.SaveCompanyLogo(new CompanyLogo()
                                                                {
                                                                    CompanyId = company.Id,
                                                                    Original = resultCompany.Logo.Original,
                                                                    Resolution90px = resultCompany.Logo.Resolution90px,
                                                                    Resolution240px = resultCompany.Logo.Resolution240px
                                                                });
                                                            }

                                                            if (resultCompany.InsiderInterviews != null)
                                                            {
                                                                foreach (var insiderInterview in resultCompany.InsiderInterviews)
                                                                {
                                                                    _dataManager.CompanyInsiderInterviews.SaveCompanyInsiderInterview(
                                                                        new CompanyInsiderInterview()
                                                                        {
                                                                            CompanyId = company.Id,
                                                                            Url = insiderInterview.Url,
                                                                            Title = insiderInterview.Title,
                                                                            IdentifierFromHeadHunter =
                                                                                insiderInterview.IdentifierFromHeadHunter
                                                                        });
                                                                }
                                                            }

                                                            companyGuid = company.Id;
                                                        }
                                                        else
                                                        {
                                                            var company = _dataManager.Companies.GetCompany(resultCompany.Name, false);

                                                            companyGuid = company.Id;
                                                            company.IdentifierFromHeadHunter = resultCompany.Id;

                                                            _dataManager.Companies.SaveCompany(company);
                                                            _dataManager.Companies.DetachCompany(company);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        var company = _dataManager.Companies
                                                            .GetCompanyByIdentifierFromHeadHunter(resultCompany.Id, false);

                                                        companyGuid = company.Id;

                                                        _dataManager.Companies.DetachCompany(company);
                                                    }
                                                }
                                            }

                                            var vacancyEntity = new Vacancy()
                                            {
                                                Name = resultVacancy.Name,
                                                CompanyId = companyGuid,
                                                Archived = resultVacancy.Archived,
                                                CreatedAt = resultVacancy.CreatedAt,
                                                AcceptKids = resultVacancy.AcceptKids,
                                                PublishedAt = resultVacancy.PublishedAt,
                                                IdentifierFromHeadHunter = resultVacancy.Id,
                                                AcceptTemporary = resultVacancy.AcceptTemporary,
                                                AcceptHandicapped = resultVacancy.AcceptHandicapped,
                                                ScheduleId = resultVacancy.Schedule != null ? (Guid?)_dataManager.Schedules.GetScheduleByIdentifierFromHeadHunter(resultVacancy.Schedule.IdentifierFromHeadHunter).Id : null,
                                                ExperienceId = resultVacancy.Experience != null ? (Guid?)_dataManager.Experiences.GetExperienceByIdentifierFromHeadHunter(resultVacancy.Experience.IdentifierFromHeadHunter).Id : null,
                                                EmploymentId = resultVacancy.Employment != null ? (Guid?)_dataManager.Employments.GetEmploymentByIdentifierFromHeadHunter(resultVacancy.Employment.IdentifierFromHeadHunter).Id : null,
                                                VacancyTypeId = resultVacancy.VacancyType != null ? (Guid?)_dataManager.VacancyTypes.GetVacancyTypeByIdentifierFromHeadHunter(resultVacancy.VacancyType.IdentifierFromHeadHunter).Id : null,
                                                WorkingDaysId = resultVacancy.WorkingDays != null ? (resultVacancy.WorkingDays.Length == 1 ? (Guid?)_dataManager.WorkingDays.GetWorkingDaysByIdentifierFromHeadHunter(resultVacancy.WorkingDays[0].IdentifierFromHeadHunter).Id : null) : null,
                                                WorkingTimeModesId = resultVacancy.WorkingTimeModes != null ? (resultVacancy.WorkingTimeModes.Length == 1 ? (Guid?)_dataManager.WorkingTimeModes.GetWorkingTimeModesByIdentifierFromHeadHunter(resultVacancy.WorkingTimeModes[0].IdentifierFromHeadHunter).Id : null) : null,
                                                WorkingTimeIntervalsId = resultVacancy.WorkingTimeIntervals != null ? (resultVacancy.WorkingTimeIntervals.Length == 1 ? (Guid?)_dataManager.WorkingTimeIntervals.GetWorkingTimeIntervalsByIdentifierFromHeadHunter(resultVacancy.WorkingTimeIntervals[0].IdentifierFromHeadHunter).Id : null) : null

                                            };
                                            _dataManager.Vacancies.SaveVacancy(vacancyEntity);

                                            _dataManager.VacancyInformation.SaveVacancyInformation(new VacancyInformation()
                                            {
                                                Url = resultVacancy.Url,
                                                HasTest = resultVacancy.HasTest,
                                                VacancyId = vacancyEntity.Id,
                                                Description = resultVacancy.Description,
                                                BrandedDescription = resultVacancy.BrandedDescription,
                                                VacancyBillingTypeId = resultVacancy.VacancyBillingType != null ? (Guid?)_dataManager.VacancyBillingTypes.GetVacancyBillingTypeByIdentifierFromHeadHunter(resultVacancy.VacancyBillingType.IdentifierFromHeadHunter).Id : null
                                            });

                                            if (resultVacancy.VacancySalary != null)
                                            {
                                                _dataManager.VacancySalaries.SaveVacancySalary(new VacancySalary()
                                                {
                                                    VacancyId = vacancyEntity.Id,
                                                    Bonus = resultVacancy.VacancySalary.Bonus,
                                                    Gross = resultVacancy.VacancySalary.Gross,
                                                    UpperWageLimit = resultVacancy.VacancySalary.UpperWageLimit,
                                                    LowerWageLimit = resultVacancy.VacancySalary.LowerWageLimit,
                                                    CurrencyId = _dataManager.Currencies.GetCurrencyByIdentifierFromHeadHunter(resultVacancy.VacancySalary.CurrencyCode).Id
                                                });
                                            }

                                            if (resultVacancy.VacancyContact != null)
                                            {
                                                var vacancyContact = new VacancyContact()
                                                {
                                                    VacancyId = vacancyEntity.Id,
                                                    Name = resultVacancy.VacancyContact.Name,
                                                    Email = resultVacancy.VacancyContact.Email,
                                                    Skype = vacancyEntity.VacancyContact.Skype
                                                };

                                                _dataManager.VacancyContacts.SaveVacancyContact(vacancyContact);

                                                foreach (var vacancyContactPhone in resultVacancy.VacancyContact.VacancyContactPhones)
                                                {
                                                    _dataManager.VacancyContactPhones.SaveVacancyContactPhone(
                                                        new VacancyContactPhone()
                                                        {
                                                            Phone = vacancyContactPhone.Phone,
                                                            Number = vacancyContactPhone.Number,
                                                            VacancyContactId = vacancyContact.Id,
                                                            Comment = vacancyContactPhone.Comment,
                                                            CityCode = vacancyContactPhone.CityCode,
                                                            Formatted = vacancyContactPhone.Formatted,
                                                            CountryCode = vacancyContactPhone.CountryCode
                                                        });
                                                }
                                            }

                                            if (resultVacancy.VacancyKeySkills != null)
                                            {
                                                foreach (var vacancyKeySkill in resultVacancy.VacancyKeySkills)
                                                {
                                                    var skill = new Skill()
                                                    {
                                                        Name = vacancyKeySkill.Name,
                                                        IdentifierFromHeadHunter = vacancyKeySkill.IdentifierFromHeadHunter
                                                    };

                                                    if (!_dataManager.Skills.ContainsSkill(vacancyKeySkill.Name))
                                                    {
                                                        _dataManager.Skills.SaveSkill(skill);
                                                    }
                                                    else
                                                    {
                                                        skill = _dataManager.Skills.GetSkill(vacancyKeySkill.Name);
                                                    }

                                                    _dataManager.VacancyKeySkills.SaveVacancyKeySkill(new VacancyKeySkill()
                                                    {
                                                        SkillId = skill.Id,
                                                        VacancyId = vacancyEntity.Id
                                                    });
                                                }
                                            }

                                            if (resultVacancy.VacancyDriverLicenseTypes != null)
                                            {
                                                foreach (var vacancyDriverLicenseType in resultVacancy.VacancyDriverLicenseTypes)
                                                {
                                                    _dataManager.VacancyDriverLicenseTypes.SaveVacancyDriverLicenseType(
                                                        new VacancyDriverLicenseType()
                                                        {
                                                            VacancyId = vacancyEntity.Id,
                                                            DriverLicenseTypeId = _dataManager.DriverLicenseTypes.GetDriverLicenseTypeByIdentifierFromHeadHunter(vacancyDriverLicenseType.IdentifierFromHeadHunter).Id
                                                        });
                                                }
                                            }

                                            Progress.CountImportedRecords++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                dateTo = dateTo.AddMinutes(1);
                dateFrom = dateFrom.AddMinutes(1);
            }


            Status = ImportStatus.Completed;
        }

        private async Task<int> CalculateCountRecords()
        {
            var response = await _vacanciesClient.GetVacancies(new DateTime(2021, 5, 14, 22, 0, 0), DateTime.Now, 1, 0);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VacanciesDirectory>(resultJson);

            return result.Found;
        }
    }
}
