using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Alere.Models;
using Alere.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Alere.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private FactoryContext _context;

        public UserRepository(FactoryContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IList<User> FindAll()
        {
            return _context
                        .Users
                        .Include(u => u.Address)
                        .Include(e => e.Foods)
                        .ToList()
                    ;
        }

        public User FindByCondition(Expression<Func<User, bool>> condition)
        {
            return _context
                        .Users
                        .Include(u => u.Address)
                        .Where(condition)
                        .FirstOrDefault()
                    ;
        }

        public User FindById(long id)
        {
            return _context
                        .Users
                        .Include(u => u.Address)
                        .Include(p => p.Foods)
                        .Where(u => u.UserId == id)
                        .FirstOrDefault()
                    ;
        }

        public void RemoveById(long id)
        {
            User user = _context.Users.Find(id);

            _context.Users.Remove(user);
        }

        public void Store(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);

            // Prevents property state from being modified
            _context.Entry(entity).Property(p => p.CreatedAt).IsModified = false;
        }
    }
}