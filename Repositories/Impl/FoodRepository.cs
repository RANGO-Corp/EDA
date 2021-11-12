using System.Collections.Generic;
using System.Linq;
using Alere.Models;
using Alere.Persistence;

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
            return _context.Foods.ToList();
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