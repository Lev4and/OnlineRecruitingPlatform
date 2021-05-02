using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class SkillsDirectoryImporter : Importer
    {
        private readonly SkillsClient _client;

        public SkillsDirectoryImporter() : base ()
        {
            _client = new SkillsClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken, int minValueId = 0, int maxValueId = int.MaxValue)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            var maxThresholdValueSkillId = await GetMaxValueSkillId(minValueId, maxValueId);
            var countIterations = maxThresholdValueSkillId % 50 == 0 ? maxThresholdValueSkillId / 50 : maxThresholdValueSkillId / 50 + 1;

            Progress.CountFoundRecords = maxThresholdValueSkillId - minValueId;

            for (int i = minValueId / 50; i < countIterations; i++)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var skillsIds = new int[i < countIterations - 1 ? 50 : maxThresholdValueSkillId - i * 50];

                    for (int j = 0; j < skillsIds.Length; j++)
                    {
                        skillsIds[j] = i * 50 + j;
                    }

                    Status = ImportStatus.DownloadFromAPI;

                    var skills = JsonConvert.DeserializeObject<SkillsDirectory<SkillIV>>(_client.GetSkills(skillsIds).Result.Content.ReadAsStringAsync().Result);

                    Status = ImportStatus.SavingToDb;

                    foreach (var skill in skills.Skills)
                    {
                        try
                        {
                            _dataManager.Skills.SaveSkill(new Skill { Name = skill.Name, IdentifierFromHeadHunter = skill.IdentifierFromHeadHunter });

                            Progress.CountImportedRecords += 1;
                        }
                        catch
                        {
                            Status = ImportStatus.Completed;

                            return;
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

        private async Task<int> GetMaxValueSkillId(int minValueId = 0, int maxValueId = int.MaxValue)
        {
            var countRecords = maxValueId;
            var oldCountRecords = minValueId;

            while (countRecords != oldCountRecords)
            {
                var currentValueCountRecords = countRecords;

                var skills = JsonConvert.DeserializeObject<SkillsDirectory<SkillIV>>(await(await _client.GetSkill(currentValueCountRecords)).Content.ReadAsStringAsync());

                if (skills.Skills.Length > 0)
                {
                    if (countRecords == maxValueId)
                    {
                        break;
                    }

                    countRecords += Math.Abs(currentValueCountRecords - oldCountRecords) / 2;
                    oldCountRecords = currentValueCountRecords;
                }
                else
                {
                    countRecords -= Math.Abs(currentValueCountRecords - oldCountRecords) / 2;
                    oldCountRecords = currentValueCountRecords;
                }
            }

            return countRecords;
        }
    }
}
