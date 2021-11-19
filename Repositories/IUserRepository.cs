using System;
using System.Linq.Expressions;
using Alere.Models;

namespace Alere.Repositories
{
    public interface IUserRepository : ICrudRepository<User, long>
    {
        User FindByCondition(Expression<Func<User, bool>> condition);
        void RemoveById(long id);
    }
}