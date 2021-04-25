using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanySubIndustriesRepository : ICompanySubIndustriesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanySubIndustriesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanySubIndustry(Guid companyId, Guid subIndustryId)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            if (subIndustryId == null)
            {
                throw new ArgumentNullException("subIndustryId", "Параметр не может быть пустым.");
            }

            return _context.CompanySubIndustries.SingleOrDefault(
                c => c.CompanyId == companyId && c.SubIndustryId == subIndustryId) != null;
        }

        public bool SaveCompanySubIndustry(CompanySubIndustry entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsCompanySubIndustry(entity.CompanyId, entity.SubIndustryId))
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

        public CompanySubIndustry GetCompanySubIndustry(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanySubIndustries.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanySubIndustries.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public IQueryable<CompanySubIndustry> GetCompanySubIndustries(bool track = false)
        {
            if (track)
            {
                return _context.CompanySubIndustries;
            }
            else
            {
                return _context.CompanySubIndustries.AsNoTracking();
            }
        }

        public void DeleteCompanySubIndustry(Guid id)
        {
            var entity = GetCompanySubIndustry(id);

            _context.CompanySubIndustries.Remove(entity);
            _context.SaveChanges();
        }
    }
}
