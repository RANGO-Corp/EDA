using System.Collections.Generic;
using System.Linq;
using Alere.Models;
using Alere.Persistence;

namespace Alere.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private FactoryContext _context;

        public UserRepository(FactoryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<User> FindAll()
        {
            return _context.Users.ToList();
        }

        public User FindById(long id)
        {
            return _context
                        .Users
                        .Where(u => u.UserId == id)
                        .FirstOrDefault()
                    ;
        }

        public void Store(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }
    }
}