using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class SkillsDirectoryImpoter : Impoter
    {
        private readonly SkillsClient _client;

        public SkillsDirectoryImpoter() : base ()
        {
            _client = new SkillsClient();
        }

        private protected override async Task Import(CancellationToken cancellationToken, int minValueSkillId = 0, int maxValueSkillId = int.MaxValue)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            var maxThresholdValueSkillId = await GetMaxValueSkillId(minValueSkillId, maxValueSkillId);
            var countIterations = maxThresholdValueSkillId % 50 == 0 ? maxThresholdValueSkillId / 50 : maxThresholdValueSkillId / 50 + 1;

            Progress.CountFoundRecords = maxThresholdValueSkillId - minValueSkillId;

            for (int i = minValueSkillId / 50; i < countIterations; i++)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var skillsIds = new int[i < countIterations - 1 ? 50 : maxThresholdValueSkillId - i * 50];

                    for (int j = 0; j < skillsIds.Length; j++)
                    {
                        skillsIds[j] = minValueSkillId + i * 50 + j;
                    }

                    Status = ImportStatus.DownloadFromAPI;

                    var skills = JsonConvert.DeserializeObject<SkillsDirectory>(_client.GetSkills(skillsIds).Result.Content.ReadAsStringAsync().Result);

                    Status = ImportStatus.SavingToDb;

                    foreach (var skill in skills.Skills)
                    {
                        _dataManager.Skills.MarkToAdd(new Skill { Name = skill.Name });
                        _dataManager.Skills.SaveChanges();

                        Progress.CountImportedRecords += 1;
                    }
                }
                else
                {
                    break;
                }
            }

            Status = ImportStatus.Completed;
        }

        private async Task<int> GetMaxValueSkillId(int minValueSkillId = 0, int maxValueSkillId = int.MaxValue)
        {
            var countRecords = maxValueSkillId;
            var oldCountRecords = minValueSkillId;

            while (countRecords != oldCountRecords)
            {
                var currentValueCountRecords = countRecords;

                var skills = JsonConvert.DeserializeObject<SkillsDirectory>(await(await _client.GetSkill(currentValueCountRecords)).Content.ReadAsStringAsync());

                if (skills.Skills.Length > 0)
                {
                    if (countRecords == maxValueSkillId)
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
