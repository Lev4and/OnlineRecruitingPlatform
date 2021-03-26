using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFApplicantCommentAccessTypesRepository : IApplicantCommentAccessTypesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFApplicantCommentAccessTypesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsApplicantCommentAccessType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.ApplicantCommentAccessTypes.SingleOrDefault(a => a.Name == name) != null;
        }

        public bool SaveApplicantCommentAccessType(ApplicantCommentAccessType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if((!ContainsApplicantCommentAccessType(entity.Name)))
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

        public ApplicantCommentAccessType GetApplicantCommentAccessType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            return _context.ApplicantCommentAccessTypes.SingleOrDefault(a => a.Id == id);
        }

        public ApplicantCommentAccessType GetApplicantCommentAccessType(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.ApplicantCommentAccessTypes.SingleOrDefault(a => a.Name == name);
        }

        public IQueryable<ApplicantCommentAccessType> GetApplicantCommentAccessTypes()
        {
            return _context.ApplicantCommentAccessTypes;
        }

        public void DeleteApplicantCommentAccessType(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetApplicantCommentAccessType(id);

            _context.ApplicantCommentAccessTypes.Remove(entity);
            _context.SaveChanges();
        }
    }
}
