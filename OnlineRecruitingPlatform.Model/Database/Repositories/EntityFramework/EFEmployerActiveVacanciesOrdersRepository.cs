using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework
{
    public class EFEmployerActiveVacanciesOrdersRepository : IEmployerActiveVacanciesOrdersRepository
    {
        private readonly OnlineRecruitingPlatformDbContext _context;

        public EFEmployerActiveVacanciesOrdersRepository(OnlineRecruitingPlatformDbContext context)
        {
            _context = context;
        }

        public bool ContainsEmployerActiveVacanciesOrder(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            return _context.EmployerActiveVacanciesOrders.SingleOrDefault(e => e.Name == name) != null;
        }

        public bool SaveEmployerActiveVacanciesOrder(EmployerActiveVacanciesOrder entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity", "Параметр не может быть пустым.");
            }

            if (!ContainsEmployerActiveVacanciesOrder(entity.Name))
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

        public EmployerActiveVacanciesOrder GetEmployerActiveVacanciesOrder(Guid id, bool track = false)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            if (track)
            {
                return _context.EmployerActiveVacanciesOrders.SingleOrDefault(e => e.Id == id);
            }
            else
            {
                return _context.EmployerActiveVacanciesOrders.AsNoTracking().SingleOrDefault(e => e.Id == id);
            }
        }

        public EmployerActiveVacanciesOrder GetEmployerActiveVacanciesOrder(string name, bool track = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Параметр не может быть пустым или длиной 0 символов.");
            }

            if (track)
            {
                return _context.EmployerActiveVacanciesOrders.SingleOrDefault(e => e.Name == name);
            }
            else
            {
                return _context.EmployerActiveVacanciesOrders.AsNoTracking().SingleOrDefault(e => e.Name == name);
            }
        }

        public IQueryable<EmployerActiveVacanciesOrder> GetEmployerActiveVacanciesOrders()
        {
            return _context.EmployerActiveVacanciesOrders;
        }

        public void DeleteEmployerActiveVacanciesOrder(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException("id", "Параметр не может быть пустым.");
            }

            var entity = GetEmployerActiveVacanciesOrder(id);

            _context.EmployerActiveVacanciesOrders.Remove(entity);
            _context.SaveChanges();
        }
    }
}
