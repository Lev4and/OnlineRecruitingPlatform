using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFSkillsRepository : ISkillsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFSkillsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsSkill(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Skills.SingleOrDefault(s => s.Name == name) != null;
        }

        public bool SaveSkill(Skill entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsSkill(entity.Name))
            {
                if(entity.Id == default)
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

        public Skill GetSkill(Guid id, bool track = false)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Skills.SingleOrDefault(s => s.Id == id);
            }
            else
            {
                return _context.Skills.AsNoTracking().SingleOrDefault(s => s.Id == id);
            }
        }

        public Skill GetSkill(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Skills.SingleOrDefault(s => s.Name == name);
            }
            else
            {
                return _context.Skills.AsNoTracking().SingleOrDefault(s => s.Name == name);
            }
        }

        public IQueryable<Skill> GetSkills()
        {
            return _context.Skills;
        }

        public void DeleteSkill(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetSkill(id);

            _context.Skills.Remove(entity);
            _context.SaveChanges();
        }
    }
}
