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
            CountFoundRecords = await GetMaximumCountRecords(minValueSkillId, maxValueSkillId);

            var countIterations = CountFoundRecords % 50 == 0 ? CountFoundRecords / 50 : CountFoundRecords / 50 + 1;

            for (int i = 0; i < countIterations; i++)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var skillsIds = new int[i < countIterations - 1 ? 50 : CountFoundRecords - i * 50];

                    for (int j = 0; j < skillsIds.Length; j++)
                    {
                        skillsIds[j] = minValueSkillId + i * 50 + j;
                    }

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        var skills = JsonConvert.DeserializeObject<SkillsDirectory>(_client.GetSkills(skillsIds).Result.Content.ReadAsStringAsync().Result);

                        foreach (var skill in skills.Skills)
                        {
                            if (!cancellationToken.IsCancellationRequested)
                            {
                                _dataManager.Skills.MarkToAdd(new Skill { Name = skill.Name });
                                _dataManager.Skills.SaveChanges();

                                //_dataManager.Skills.SaveSkill(new Skill { Name = skill.Name });

                                CountImportedRecords += 1;
                            }
                            else
                            {
                                break;
                            }
                        }

                        //_dataManager.Skills.SaveChanges();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            IsRunning = false;
        }

        private async Task<int> GetMaximumCountRecords(int minValueSkillId = 0, int maxValueSkillId = int.MaxValue)
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
