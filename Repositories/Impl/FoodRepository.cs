using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Alere.Models;
using Alere.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Alere.Repositories.Impl
{
    public class FoodRepository : IFoodRepository
    {
        private FactoryContext _context;

        public FoodRepository(FactoryContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IList<Food> FindAll()
        {
            return _context
                        .Foods
                        .Include(f => f.User)
                            .ThenInclude(f => f.Address)
                    .ToList()
                    ;
        }

        public IList<Food> FindAllByCondition(Expression<Func<Food, bool>> condition)
        {
            return _context
                        .Foods
                        .Include(e => e.User)
                            .ThenInclude(e => e.Address)
                        .Where(condition)
                    .ToList()
                    ;
        }

        public Food FindByCondition(Expression<Func<Food, bool>> condition)
        {
            return _context
                        .Foods
                        .Include(e => e.User)
                            .ThenInclude(e => e.Address)
                        .Where(condition)
                    .FirstOrDefault()
                    ;
        }

        public Food FindById(long id)
        {
            return _context
                        .Foods
                        .Where(f => f.FoodId == id)
                    .FirstOrDefault()
                    ;
        }

        public void Store(Food entity)
        {
            _context.Foods.Add(entity);
        }

        public void Update(Food entity)
        {
            _context.Foods.Update(entity);

            _context.Entry(entity).Property(p => p.UserId).IsModified = false;
        }
    }
}