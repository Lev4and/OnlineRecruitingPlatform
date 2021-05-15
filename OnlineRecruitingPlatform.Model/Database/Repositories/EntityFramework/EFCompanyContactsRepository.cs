using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyContactsRepository : ICompanyContactsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyContactsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanyContact(Guid companyId, Guid addressId)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            if (addressId == null)
            {
                throw new ArgumentNullException("addressId", "Параметр не может быть пустым.");
            }

            return _context.CompanyContacts.SingleOrDefault(c => c.CompanyId == companyId && c.AddressId == addressId) !=
                   null;
        }

        public bool SaveCompanyContact(CompanyContact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsCompanyContact(entity.CompanyId, entity.AddressId))
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

        public CompanyContact GetCompanyContact(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyContacts.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyContacts.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public CompanyContact GetCompanyContact(Guid companyId, Guid addressId, bool track = false)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            if (addressId == null)
            {
                throw new ArgumentNullException("addressId", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyContacts.SingleOrDefault(c => c.CompanyId == companyId && c.AddressId == addressId);
            }
            else
            {
                return _context.CompanyContacts.AsNoTracking().SingleOrDefault(c => c.CompanyId == companyId && c.AddressId == addressId);
            }
        }

        public IQueryable<CompanyContact> GetCompanyContacts(bool track = false)
        {
            if (track)
            {
                return _context.CompanyContacts;
            }
            else
            {
                return _context.CompanyContacts.AsNoTracking();
            }
        }

        public void DeleteCompanyContact(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyContact(id);

            _context.CompanyContacts.Remove(entity);
            _context.SaveChanges();
        }
    }
}
