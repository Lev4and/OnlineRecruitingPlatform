using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyContactPhonesRepository : ICompanyContactPhonesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyContactPhonesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }
        public bool ContainsCompanyContactPhone(Guid companyContactId, string phone)
        {
            if (companyContactId == null)
            {
                throw new ArgumentNullException("companyContactId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentNullException("phone", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.CompanyContactPhones.SingleOrDefault(c =>
                c.CompanyContactId == companyContactId && c.Phone == phone) != null;
        }

        public bool SaveCompanyContactPhone(CompanyContactPhone entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsCompanyContactPhone(entity.CompanyContactId, entity.Phone))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetCompanyContactPhone(entity.Id);

                if (oldVersionEntity.CompanyContactId != entity.CompanyContactId || oldVersionEntity.Phone != entity.Phone)
                {
                    if (!ContainsCompanyContactPhone(entity.CompanyContactId, entity.Phone))
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

        public CompanyContactPhone GetCompanyContactPhone(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyContactPhones.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyContactPhones.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public CompanyContactPhone GetCompanyContactPhone(Guid companyContactId, string phone, bool track = false)
        {
            if (companyContactId == null)
            {
                throw new ArgumentNullException("companyContactId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentNullException("phone", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.CompanyContactPhones.SingleOrDefault(c =>
                    c.CompanyContactId == companyContactId && c.Phone == phone);
            }
            else
            {
                return _context.CompanyContactPhones.AsNoTracking().SingleOrDefault(c =>
                    c.CompanyContactId == companyContactId && c.Phone == phone);
            }
        }

        public IQueryable<CompanyContactPhone> GetCompanyContactPhones(bool track = false)
        {
            if (track)
            {
                return _context.CompanyContactPhones;
            }
            else
            {
                return _context.CompanyContactPhones.AsNoTracking();
            }
        }

        public void DeleteCompanyContactPhone(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyContactPhone(id);

            _context.CompanyContactPhones.Remove(entity);
            _context.SaveChanges();
        }
    }
}
