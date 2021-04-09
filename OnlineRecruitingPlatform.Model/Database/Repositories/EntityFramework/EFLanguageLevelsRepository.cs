﻿using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFLanguageLevelsRepository : ILanguageLevelsRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFLanguageLevelsRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsLanguageLevel(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.LanguageLevels.SingleOrDefault(l => l.Name == name) != null;
        }

        public bool SaveLanguageLevel(LanguageLevel entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if(entity.Id == default)
            {
                if (!ContainsLanguageLevel(entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetLanguageLevel(entity.Id);

                if(oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsLanguageLevel(entity.Name))
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

        public LanguageLevel GetLanguageLevel(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.LanguageLevels.SingleOrDefault(l => l.Id == id);
            }
            else
            {
                return _context.LanguageLevels.AsNoTracking().SingleOrDefault(l => l.Id == id);
            }
        }

        public LanguageLevel GetLanguageLevel(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.LanguageLevels.SingleOrDefault(l => l.Name == name);
            }
            else
            {
                return _context.LanguageLevels.AsNoTracking().SingleOrDefault(l => l.Name == name);
            }
        }

        public IQueryable<LanguageLevel> GetLanguageLevels()
        {
            return _context.LanguageLevels;
        }

        public void DeleteLanguageLevel(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetLanguageLevel(id);

            _context.LanguageLevels.Remove(entity);
            _context.SaveChanges();
        }
    }
}
