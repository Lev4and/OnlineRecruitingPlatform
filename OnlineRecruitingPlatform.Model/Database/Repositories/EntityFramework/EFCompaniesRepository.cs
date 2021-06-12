using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompaniesRepository : ICompaniesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompaniesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompany(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Companies.SingleOrDefault(c => c.Name == name) != null;
        }

        public bool ContainsCompanyByIdentifierFromZarplataRu(int id)
        {
            return _context.Companies.SingleOrDefault(c => c.IdentifierFromZarplataRu == id) != null;
        }

        public bool ContainsCompanyByIdentifierFromHeadHunter(int id)
        {
            return _context.Companies.SingleOrDefault(c => c.IdentifierFromHeadHunter == id) != null;
        }

        public bool SaveCompany(Company entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsCompany(entity.Name))
            {
                if (entity.Id == default)
                {
                    _context.Entry(entity).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public int GetCountCompanies()
        {
            return _context.Companies.Count();
        }

        public Company GetCompany(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Companies
                    .Include(c => c.Logo)
                    .Include(c => c.Information)
                    .SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.Companies
                    .Include(c => c.Logo)
                    .Include(c => c.Information)
                    .AsNoTracking()
                    .SingleOrDefault(c => c.Id == id);
            }
        }

        public Company GetCompany(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Companies.SingleOrDefault(c => c.Name == name);
            }
            else
            {
                return _context.Companies.AsNoTracking().SingleOrDefault(c => c.Name == name);
            }
        }

        public Company GetCompanyByIdentifierFromZarplataRu(int id, bool track = false)
        {
            if (track)
            {
                return _context.Companies.SingleOrDefault(c => c.IdentifierFromZarplataRu == id);
            }
            else
            {
                return _context.Companies.AsNoTracking().SingleOrDefault(c => c.IdentifierFromZarplataRu == id);
            }
        }

        public Company GetCompanyByIdentifierFromHeadHunter(int id, bool track = false)
        {
            if (track)
            {
                return _context.Companies.SingleOrDefault(c => c.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.Companies.AsNoTracking().SingleOrDefault(c => c.IdentifierFromHeadHunter == id);
            }
        }

        public IQueryable<Company> GetCompanies(bool track = false)
        {
            if (track)
            {
                return _context.Companies;
            }
            else
            {
                return _context.Companies.AsNoTracking();
            }
        }

        public IQueryable<Company> GetBrowseCompanies(int itemsPerPage = 5, int numberPage = 1, bool track = false)
        {
            if (track)
            {
                return _context.Companies
                    .OrderBy(c => c.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .Include(c => c.Logo)
                    .Include(c => c.Vacancies.Where(v => v.Archived == false));
            }
            else
            {
                return _context.Companies
                    .OrderBy(c => c.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .Include(c => c.Logo)
                    .Include(c => c.Vacancies.Where(v => v.Archived == false))
                    .AsNoTracking();
            }
        }

        public void DeleteCompany(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompany(id);

            _context.Companies.Remove(entity);
            _context.SaveChanges();
        }

        public void DetachCompany(Company entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
