using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyInformationRepository : ICompanyInformationRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyInformationRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanyInformation(Guid companyId)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            return _context.CompanyInformation.SingleOrDefault(c => c.CompanyId == companyId) != null;
        }

        public bool SaveCompanyInformation(CompanyInformation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsCompanyInformation(entity.CompanyId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetCompanyInformation(entity.Id);

                if (oldVersionEntity.CompanyId != entity.CompanyId)
                {
                    if (!ContainsCompanyInformation(entity.CompanyId))
                    {
                        _context.Entry(entity).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public CompanyInformation GetCompanyInformation(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyInformation.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyInformation.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public IQueryable<CompanyInformation> GetCompanyInformation(bool track = false)
        {
            if (track)
            {
                return _context.CompanyInformation;
            }
            else
            {
                return _context.CompanyInformation.AsNoTracking();
            }
        }

        public void DeleteCompanyInformation(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyInformation(id);

            _context.CompanyInformation.Remove(entity);
            _context.SaveChanges();
        }
    }
}
