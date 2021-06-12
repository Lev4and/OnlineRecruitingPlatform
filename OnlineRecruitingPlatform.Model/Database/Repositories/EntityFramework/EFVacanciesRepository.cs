using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacanciesRepository : IVacanciesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacanciesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyByIdentifierFromZarplataRu(int id)
        {
            return _context.Vacancies.SingleOrDefault(v => v.IdentifierFromZarplataRu == id) != null;
        }

        public bool ContainsVacancyByIdentifierFromHeadHunter(int id)
        {
            return _context.Vacancies.SingleOrDefault(v => v.IdentifierFromHeadHunter == id) != null;
        }

        public int GetCountVacancies()
        {
            return _context.Vacancies.Count();
        }

        public int GetCountVacancies(string searchStringByJobTitleSkillsOrCompany = "")
        {
            return _context.Vacancies
                    .Include(v => v.Company)
                    .Include(v => v.Address)
                    .Include(v => v.Schedule)
                    .Include(v => v.Company.Logo)
                    .Include(v => v.VacancySalary)
                    .Include(v => v.VacancySalary.Currency)
                    .Include(v => v.VacancyKeySkills).ThenInclude(vk => vk.Skill)
                    .Where(v =>
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower()) : true) ||
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.Company.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower()) : true) ||
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.VacancyKeySkills.Any(vk => vk.Skill.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower())) : true))
                    .Count();
        }

        public int GetCountAvtiveVacancies()
        {
            return _context.Vacancies.Where(v => v.Archived == false).Count();
        }

        public Vacancy GetVacancy(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Vacancies.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.Vacancies.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public Vacancy GetVacancyByIdentifierFromZarplataRu(int id, bool track = false)
        {
            if (track)
            {
                return _context.Vacancies.SingleOrDefault(v => v.IdentifierFromZarplataRu == id);
            }
            else
            {
                return _context.Vacancies.AsNoTracking().SingleOrDefault(v => v.IdentifierFromZarplataRu == id);
            }
        }

        public IQueryable<Vacancy> GetVacancies(bool track = false)
        {
            if (track)
            {
                return _context.Vacancies;
            }
            else
            {
                return _context.Vacancies.AsNoTracking();
            }
        }

        public IQueryable<Vacancy> GetBrowseVacancies(int itemsPerPage = 5, int numberPage = 1, string searchStringByJobTitleSkillsOrCompany = "", bool track = false)
        {
            if (track)
            {
                return _context.Vacancies
                    .Include(v => v.Company)
                    .Include(v => v.Address)
                    .Include(v => v.Schedule)
                    .Include(v => v.Company.Logo)
                    .Include(v => v.VacancySalary)
                    .Include(v => v.VacancySalary.Currency)
                    .Include(v => v.VacancyKeySkills).ThenInclude(vk => vk.Skill)
                    .Where(v =>
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower()) : true) ||
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.Company.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower()) : true) ||
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.VacancyKeySkills.Any(vk => vk.Skill.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower())) : true))
                    .OrderBy(v => v.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.Vacancies
                    .Include(v => v.Company)
                    .Include(v => v.Address)
                    .Include(v => v.Schedule)
                    .Include(v => v.Company.Logo)
                    .Include(v => v.VacancySalary)
                    .Include(v => v.VacancySalary.Currency)
                    .Include(v => v.VacancyKeySkills).ThenInclude(vk => vk.Skill)
                    .Where(v =>
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower()) : true) ||
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.Company.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower()) : true) ||
                    (searchStringByJobTitleSkillsOrCompany.Length > 0 ? v.VacancyKeySkills.Any(vk => vk.Skill.Name.ToLower().Contains(searchStringByJobTitleSkillsOrCompany.ToLower())) : true))
                    .OrderBy(v => v.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public IQueryable<Vacancy> GetRecentVacancies(int itemsInResult, bool track = false)
        {
            if (track)
            {
                return _context.Vacancies
                    .Include(v => v.Company)
                    .Include(v => v.Company.Logo)
                    .Include(v => v.Address)
                    .Include(v => v.Schedule)
                    .OrderBy(v => v.CreatedAt)
                    .Skip(0)
                    .Take(itemsInResult);
            }
            else
            {
                return _context.Vacancies
                    .Include(v => v.Company)
                    .Include(v => v.Company.Logo)
                    .Include(v => v.Address)
                    .Include(v => v.Schedule)
                    .OrderBy(v => v.CreatedAt)
                    .Skip(0)
                    .Take(itemsInResult)
                    .AsNoTracking();
            }
        }

        public void SaveVacancy(Vacancy entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public void DeleteVacancy(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancy(id);

            _context.Vacancies.Remove(entity);
            _context.SaveChanges();
        }
    }
}