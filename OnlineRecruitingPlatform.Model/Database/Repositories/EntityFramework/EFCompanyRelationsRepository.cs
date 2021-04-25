using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFCompanyRelationsRepository : ICompanyRelationsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFCompanyRelationsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsCompanyRelation(Guid companyId, Guid relationId)
        {
            if (companyId == null)
            {
                throw new ArgumentNullException("companyId", "Параметр не может быть пустым.");
            }

            if (relationId == null)
            {
                throw new ArgumentNullException("relationId", "Параметр не может быть пустым.");
            }

            return _context.CompanyRelations.SingleOrDefault(
                c => c.CompanyId == companyId && c.RelationId == relationId) != null;
            
        }

        public bool SaveCompanyRelation(CompanyRelation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsCompanyRelation(entity.CompanyId, entity.RelationId))
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

        public CompanyRelation GetCompanyRelation(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.CompanyRelations.SingleOrDefault(c => c.Id == id);
            }
            else
            {
                return _context.CompanyRelations.AsNoTracking().SingleOrDefault(c => c.Id == id);
            }
        }

        public IQueryable<CompanyRelation> GerCompanyRelations(bool track = false)
        {
            if (track)
            {
                return _context.CompanyRelations;
            }
            else
            {
                return _context.CompanyRelations.AsNoTracking();
            }
        }

        public void DeleteCompanyRelation(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetCompanyRelation(id);

            _context.CompanyRelations.Remove(entity);
            _context.SaveChanges();
        }
    }
}
