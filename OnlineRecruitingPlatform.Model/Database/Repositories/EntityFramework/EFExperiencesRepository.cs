using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFExperiencesRepository : IExperiencesRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFExperiencesRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsExperience(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.Experiences.SingleOrDefault(e => e.Name == name) != null;
        }

        public bool SaveExperience(Experience entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsExperience(entity.Name))
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

        public Experience GetExperience(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.Experiences.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return _context.Experiences.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public Experience GetExperience(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Experiences.SingleOrDefault(e => e.Name == name);
            }
            else
            {
                return _context.Experiences.AsNoTracking().SingleOrDefault(e => e.Name == name);
            }
        }

        public Experience GetExperienceByIdentifierFromHeadHunter(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Experiences.SingleOrDefault(s => s.IdentifierFromHeadHunter == id);
            }
            else
            {
                return _context.Experiences.AsNoTracking().SingleOrDefault(s => s.IdentifierFromHeadHunter == id);
            }
        }

        public Experience GetExperienceByIdentifierFromAvitoRu(string id, bool track = false)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.Experiences.SingleOrDefault(s => s.IdentifierFromAvitoRu == id);
            }
            else
            {
                return _context.Experiences.AsNoTracking().SingleOrDefault(s => s.IdentifierFromAvitoRu == id);
            }
        }

        public Experience GetExperienceByIdentifierFromZarplataRu(int id, bool track = false)
        {
            if (track)
            {
                return _context.Experiences.SingleOrDefault(s => s.IdentifierFromZarplataRu == id);
            }
            else
            {
                return _context.Experiences.AsNoTracking().SingleOrDefault(s => s.IdentifierFromZarplataRu == id);
            }
        }

        public IQueryable<Experience> GetExperiences()
        {
            return _context.Experiences;
        }

        public void DeleteExperience(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetExperience(id);

            _context.Experiences.Remove(entity);
            _context.SaveChanges();
        }
    }
}
