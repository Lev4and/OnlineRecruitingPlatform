using Newtonsoft.Json;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.API.HeadHunter.Directories;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories
{
    public class SkillsDirectoryImpoter : Impoter
    {
        private readonly string _connectString;
        private readonly SkillsClient _client;
        private readonly OleDbCommand _myCommand;
        private readonly OleDbConnection _myConnection;

        public SkillsDirectoryImpoter() : base ()
        {
            _connectString = _connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Skills.accdb;";

            _client = new SkillsClient();

            _myConnection = new OleDbConnection(_connectString);

            _myCommand = new OleDbCommand();
            _myCommand.Connection = _myConnection;
        }

        private protected override async Task Import(CancellationToken cancellationToken, int minValueSkillId = 0, int maxValueSkillId = int.MaxValue)
        {
            Status = ImportStatus.SearchForARangeOfValidValues;

            var maxThresholdValueSkillId = await GetMaxValueSkillId(minValueSkillId, maxValueSkillId);
            var countIterations = maxThresholdValueSkillId % 50 == 0 ? maxThresholdValueSkillId / 50 : maxThresholdValueSkillId / 50 + 1;

            Progress.CountFoundRecords = maxThresholdValueSkillId - minValueSkillId;

            _myConnection.Open();

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
                        try
                        {
                            _myCommand.CommandText = $"INSERT INTO [Skills] (Id, Name, IdentifierFromHeadHunter, IdentifierFromZarplataRu) VALUES (?, ?, ?, ?)";

                            _myCommand.Parameters.Clear();
                            _myCommand.Parameters.Add(new OleDbParameter("@Id", OleDbType.LongVarChar)).Value = $"{Guid.NewGuid()}";
                            _myCommand.Parameters.Add(new OleDbParameter("@Name", OleDbType.VarChar)).Value = skill.Name;
                            _myCommand.Parameters.Add(new OleDbParameter("@IdentifierFromHeadHunter", OleDbType.Integer)).Value = skill.IdentifierFromHeadHunter;
                            _myCommand.Parameters.Add(new OleDbParameter("@IdentifierFromZarplataRu", OleDbType.Integer)).Value = DBNull.Value;

                            _myCommand.ExecuteNonQuery();

                            //_dataManager.Skills.MarkToAdd(new Skill { Name = skill.Name });
                            //_dataManager.Skills.SaveChanges();

                            Progress.CountImportedRecords += 1;
                        }
                        catch
                        {
                            _myConnection.Close();

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

            _myConnection.Close();

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
