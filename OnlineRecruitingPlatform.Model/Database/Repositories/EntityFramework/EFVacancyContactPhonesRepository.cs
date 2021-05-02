using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyContactPhonesRepository : IVacancyContactPhonesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyContactPhonesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyContactPhone(Guid vacancyContactId, string countryCode, string cityCode, string number)
        {
            if (vacancyContactId == null)
            {
                throw new ArgumentNullException("vacancyContactId", "Параметр не может быть пустым.");
            }
            
            if (string.IsNullOrEmpty(countryCode))
            {
                throw new ArgumentNullException("countryCode", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (string.IsNullOrEmpty(cityCode))
            {
                throw new ArgumentNullException("cityCode", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("number", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.VacancyContactPhones.SingleOrDefault(v =>
                v.VacancyContactId == vacancyContactId && v.CountryCode == countryCode &&
                v.CityCode == cityCode && v.Number == number) != null;
        }

        public bool SaveVacancyContactPhone(VacancyContactPhone entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsVacancyContactPhone(entity.VacancyContactId, entity.CountryCode, entity.CityCode,
                    entity.Number))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetVacancyContactPhone(entity.Id);

                if (oldVersionEntity.VacancyContactId != entity.VacancyContactId ||
                    oldVersionEntity.CountryCode != entity.CountryCode ||
                    oldVersionEntity.CityCode != entity.CityCode || oldVersionEntity.Number != entity.Number)
                {
                    if (!ContainsVacancyContactPhone(entity.VacancyContactId, entity.CountryCode, entity.CityCode,
                        entity.Number))
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

        public VacancyContactPhone GetVacancyContactPhone(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyContactPhones.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancyContactPhones.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public VacancyContactPhone GetVacancyContactPhone(Guid vacancyContactId, string countryCode, string cityCode, string number,
            bool track = false)
        {
            if (vacancyContactId == null)
            {
                throw new ArgumentNullException("vacancyContactId", "Параметр не может быть пустым.");
            }
            
            if (string.IsNullOrEmpty(countryCode))
            {
                throw new ArgumentNullException("countryCode", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (string.IsNullOrEmpty(cityCode))
            {
                throw new ArgumentNullException("cityCode", "Параметр не может быть пустым или длиной 0 символов.");
            }
            
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException("number", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.VacancyContactPhones.SingleOrDefault(v =>
                    v.VacancyContactId == vacancyContactId && v.CountryCode == countryCode &&
                    v.CityCode == cityCode && v.Number == number);
            }
            else
            {
                return _context.VacancyContactPhones.AsNoTracking().SingleOrDefault(v =>
                    v.VacancyContactId == vacancyContactId && v.CountryCode == countryCode &&
                    v.CityCode == cityCode && v.Number == number);
            }
        }

        public IQueryable<VacancyContactPhone> GetVacancyContactPhones(bool track = false)
        {
            if (track)
            {
                return _context.VacancyContactPhones;
            }
            else
            {
                return _context.VacancyContactPhones.AsNoTracking();
            }
        }

        public void DeleteVacancyContactPhone(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyContactPhone(id);

            _context.VacancyContactPhones.Remove(entity);
            _context.SaveChanges();
        }
    }
}