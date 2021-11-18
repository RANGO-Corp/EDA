using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Alere.Models;

namespace Alere.Repositories
{
    public interface IFoodRepository : ICrudRepository<Food, long>
    {

        IList<Food> FindAllByCondition(Expression<Func<Food, bool>> condition);
        Food FindByCondition(Expression<Func<Food, bool>> condition);
    }
}