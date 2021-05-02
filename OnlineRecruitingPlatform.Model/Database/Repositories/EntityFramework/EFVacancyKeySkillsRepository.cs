using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFVacancyKeySkillsRepository : IVacancyKeySkillsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFVacancyKeySkillsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsVacancyKeySkill(Guid vacancyId, Guid skillId)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }
            
            if (skillId == null)
            {
                throw new ArgumentNullException("skillId", "Параметр не может быть пустым.");
            }

            return _context.VacancyKeySkills.SingleOrDefault(v => v.VacancyId == vacancyId && v.SkillId == skillId) !=
                   null;
        }

        public bool SaveVacancyKeySkill(VacancyKeySkill entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsVacancyKeySkill(entity.VacancyId, entity.SkillId))
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

        public VacancyKeySkill GetVacancyKeySkill(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.VacancyKeySkills.SingleOrDefault(v => v.Id == id);
            }
            else
            {
                return _context.VacancyKeySkills.AsNoTracking().SingleOrDefault(v => v.Id == id);
            }
        }

        public VacancyKeySkill GetVacancyKeySkill(Guid vacancyId, Guid skillId, bool track = false)
        {
            if (vacancyId == null)
            {
                throw new ArgumentNullException("vacancyId", "Параметр не может быть пустым.");
            }
            
            if (skillId == null)
            {
                throw new ArgumentNullException("skillId", "Параметр не может быть пустым.");
            }
            
            if (track)
            {
                return _context.VacancyKeySkills.SingleOrDefault(v => v.VacancyId == vacancyId && v.SkillId == skillId);
            }
            else
            {
                return _context.VacancyKeySkills.AsNoTracking().SingleOrDefault(v => v.VacancyId == vacancyId && v.SkillId == skillId);
            }
        }

        public IQueryable<VacancyKeySkill> GetVacancyKeySkills(bool track = false)
        {
            if (track)
            {
                return _context.VacancyKeySkills;
            }
            else
            {
                return _context.VacancyKeySkills.AsNoTracking();
            }
        }

        public void DeleteVacancyKeySkill(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetVacancyKeySkill(id);

            _context.VacancyKeySkills.Remove(entity);
            _context.SaveChanges();
        }
    }
}