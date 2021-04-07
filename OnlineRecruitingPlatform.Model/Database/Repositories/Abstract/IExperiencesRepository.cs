﻿using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IExperiencesRepository
    {
        bool ContainsExperience(string name);

        bool SaveExperience(Experience entity);

        Experience GetExperience(Guid id, bool track = false);

        Experience GetExperience(string name, bool track = false);

        IQueryable<Experience> GetExperiences();

        void DeleteExperience(Guid id);
    }
}