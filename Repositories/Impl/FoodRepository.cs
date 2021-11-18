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

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Food> FindAll()
        {
            return _context
                        .Foods
                        .Include(f => f.User)
                        .Include(f => f.User.Address)
                        .ToList()
                    ;
        }

        public IList<Food> FindAllByCondition(Expression<Func<Food, bool>> condition)
        {
            return _context
                        .Foods
                        .Include(e => e.User)
                        .Include(e => e.User.Address)
                        .Where(condition)
                    .ToList()
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
        }
    }
}