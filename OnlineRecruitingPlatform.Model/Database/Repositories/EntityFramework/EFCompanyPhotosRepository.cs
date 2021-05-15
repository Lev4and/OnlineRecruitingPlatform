using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyPhotosRepository : ICompanyPhotosRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyPhotosRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanyPhoto(Guid companyId, string photo)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(photo))
            {
                throw new ArgumentNullException("photo", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.CompanyPhotos.SingleOrDefault(c =>
                c.CompanyId == companyId && c.Photo == photo) != null;
        }

        public bool SaveCompanyPhoto(CompanyPhoto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsCompanyPhoto(entity.CompanyId, entity.Photo))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetCompanyPhoto(entity.Id);

                if (oldVersionEntity.CompanyId != entity.CompanyId || oldVersionEntity.Photo != entity.Photo)
                {
                    if (!ContainsCompanyPhoto(entity.CompanyId, entity.Photo))
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

        public CompanyPhoto GetCompanyPhoto(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyPhotos.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyPhotos.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public CompanyPhoto GetCompanyPhoto(Guid companyId, string photo, bool track = false)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            if (string.IsNullOrEmpty(photo))
            {
                throw new ArgumentNullException("photo", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.CompanyPhotos.SingleOrDefault(c =>
                    c.CompanyId == companyId && c.Photo == photo);
            }
            else
            {
                return _context.CompanyPhotos.AsNoTracking().SingleOrDefault(c =>
                    c.CompanyId == companyId && c.Photo == photo);
            }
        }

        public IQueryable<CompanyPhoto> GetCompanyPhotos(bool track = false)
        {
            if (track)
            {
                return _context.CompanyPhotos;
            }
            else
            {
                return _context.CompanyPhotos.AsNoTracking();
            }
        }

        public void DeleteCompanyPhoto(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyPhoto(id);

            _context.CompanyPhotos.Remove(entity);
            _context.SaveChanges();
        }
    }
}
