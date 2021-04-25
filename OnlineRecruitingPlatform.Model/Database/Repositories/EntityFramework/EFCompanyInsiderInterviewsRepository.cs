using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyInsiderInterviewsRepository : ICompanyInsiderInterviewsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyInsiderInterviewsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanyInsiderInterview(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.CompanyInsiderInterviews.SingleOrDefault(c => c.Title == title) != null;
        }

        public bool SaveCompanyInsiderInterview(CompanyInsiderInterview entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (entity.Id == default)
            {
                if (!ContainsCompanyInsiderInterview(entity.Title))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetCompanyInsiderInterview(entity.Id);

                if (oldVersionEntity.Title != entity.Title)
                {
                    if (!ContainsCompanyInsiderInterview(entity.Title))
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

        public CompanyInsiderInterview GetCompanyInsiderInterview(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyInsiderInterviews.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyInsiderInterviews.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public IQueryable<CompanyInsiderInterview> GetCompanyInsiderInterviews(bool track = false)
        {
            if (track)
            {
                return _context.CompanyInsiderInterviews;
            }
            else
            {
                return _context.CompanyInsiderInterviews.AsNoTracking();
            }
        }

        public void DeleteCompanyInsiderInterview(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyInsiderInterview(id);

            _context.CompanyInsiderInterviews.Remove(entity);
            _context.SaveChanges();
        }
    }
}
