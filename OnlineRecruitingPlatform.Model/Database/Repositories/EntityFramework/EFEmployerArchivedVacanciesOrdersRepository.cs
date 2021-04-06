using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFEmployerArchivedVacanciesOrdersRepository : IEmployerArchivedVacanciesOrdersRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFEmployerArchivedVacanciesOrdersRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsEmployerArchivedVacanciesOrder(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.EmployerArchivedVacanciesOrders.SingleOrDefault(e => e.Name == name) != null;
        }

        public bool SaveEmployerArchivedVacanciesOrder(EmployerArchivedVacanciesOrder entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsEmployerArchivedVacanciesOrder(entity.Name))
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

        public EmployerArchivedVacanciesOrder GetEmployerArchivedVacanciesOrder(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.EmployerArchivedVacanciesOrders.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return _context.EmployerArchivedVacanciesOrders.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public EmployerArchivedVacanciesOrder GetEmployerArchivedVacanciesOrder(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.EmployerArchivedVacanciesOrders.SingleOrDefault(e => e.Name == name);
            }
            else
            {
                return _context.EmployerArchivedVacanciesOrders.AsNoTracking().SingleOrDefault(e => e.Name == name);
            }
        }

        public IQueryable<EmployerArchivedVacanciesOrder> GetEmployerArchivedVacanciesOrders()
        {
            return _context.EmployerArchivedVacanciesOrders;
        }

        public void DeleteEmployerArchivedVacanciesOrder(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetEmployerArchivedVacanciesOrder(id);

            _context.EmployerArchivedVacanciesOrders.Remove(entity);
            _context.SaveChanges();
        }
    }
}
