using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyLogosRepository : ICompanyLogosRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyLogosRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanyLogo(Guid companyId)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            return _context.CompanyLogos.SingleOrDefault(c => c.CompanyId == companyId) != null;
        }

        public bool SaveCompanyLogo(CompanyLogo entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsCompanyLogo(entity.CompanyId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetCompanyLogo(entity.Id);

                if (oldVersionEntity.CompanyId != entity.CompanyId)
                {
                    if (!ContainsCompanyLogo(entity.CompanyId))
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

        public int GetCountCompanyLogos()
        {
            return _context.CompanyLogos.Count();
        }

        public CompanyLogo GetCompanyLogo(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyLogos.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyLogos.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public IQueryable<CompanyLogo> GetCompanyLogos(bool track = false)
        {
            if (track)
            {
                return _context.CompanyLogos;
            }
            else
            {
                return _context.CompanyLogos.AsNoTracking();
            }
        }

        public IQueryable<CompanyLogo> GetCompanyLogos(int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.CompanyLogos
                    .OrderBy(c => c.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.CompanyLogos
                    .AsNoTracking()
                    .OrderBy(c => c.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
        }

        public void DeleteCompanyLogo(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyLogo(id);

            _context.CompanyLogos.Remove(entity);
            _context.SaveChanges();
        }
    }
}
