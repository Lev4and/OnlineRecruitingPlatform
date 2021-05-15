using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFAddressesRepository : IAddressesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFAddressesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsAddress(Guid? cityId, Guid? streetId, Guid? buildingId)
        {
            return _context.Addresses.SingleOrDefault(a =>
                a.CityId == cityId && a.StreetId == streetId && a.BuildingId == buildingId) != null;
        }

        public bool ContainsAddress(string cityName, string streetName, string buildingName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException("cityName", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (streetName == null)
            {
                throw new ArgumentNullException("streetName", "Параметр не может быть пустым.");
            }

            if (buildingName == null)
            {
                throw new ArgumentNullException("buildingName", "Параметр не может быть пустым.");
            }

            return _context.Addresses.SingleOrDefault(a =>
                a.CityName == cityName && a.StreetName == streetName && a.BuildingName == buildingName) != null;
        }

        public bool SaveAddress(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsAddress(entity.CityName, entity.StreetName, entity.BuildingName))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetAddress(entity.Id);

                if (oldVersionEntity.CityName != entity.CityName || oldVersionEntity.StreetName != entity.StreetName ||
                    oldVersionEntity.BuildingName != entity.BuildingName)
                {
                    if (!ContainsAddress(entity.CityName, entity.StreetName, entity.BuildingName))
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

        public Address GetAddress(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Addresses.SingleOrDefault(a => a.Id == id);
            }
            else
            {
                return _context.Addresses.AsNoTracking().SingleOrDefault(a => a.Id == id);
            }
        }

        public Address GetAddress(Guid? cityId, Guid? streetId, Guid? buildingId, bool track = false)
        {
            if (track)
            {
                return _context.Addresses.SingleOrDefault(a => a.CityId == cityId && a.StreetId == streetId && a.BuildingId == buildingId);
            }
            else
            {
                return _context.Addresses.AsNoTracking().SingleOrDefault(a => a.CityId == cityId && a.StreetId == streetId && a.BuildingId == buildingId);
            }
        }

        public Address GetAddress(string cityName, string streetName, string buildingName, bool track = false)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException("cityName", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (streetName == null)
            {
                throw new ArgumentNullException("streetName", "Параметр не может быть пустым.");
            }

            if (buildingName == null)
            {
                throw new ArgumentNullException("buildingName", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Addresses.SingleOrDefault(a =>
                    a.CityName == cityName && a.StreetName == streetName && a.BuildingName == buildingName);
            }
            else
            {
                return _context.Addresses.AsNoTracking().SingleOrDefault(a =>
                    a.CityName == cityName && a.StreetName == streetName && a.BuildingName == buildingName);
            }
        }

        public IQueryable<Address> GetAddress(bool track = false)
        {
            if (track)
            {
                return _context.Addresses;
            }
            else
            {
                return _context.Addresses.AsNoTracking();
            }
        }

        public void DeleteAddress(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentException("id", "Параметр не может быть пустым.");
            }

            var entity = GetAddress(id);

            _context.Addresses.Remove(entity);
            _context.SaveChanges();
        }
    }
}