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