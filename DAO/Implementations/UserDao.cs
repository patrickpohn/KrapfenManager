using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAO.Implementations
{
    public class UserDao : IUserDao
    {
        private readonly DbContextOptionsBuilder _optionsBuilder;
        
        public UserDao(string db)
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextManager>();
            _optionsBuilder.UseMySql(db);
        }
        
        public List<User> GetAllUser()
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.User.ToList();
        }

        public User GetUserById(Guid? id)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.User.FirstOrDefault(k => k.Id.Equals(id));
        }

        public User GetUserByName(string name)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            return ctx.User.FirstOrDefault(u => u.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public User AddUser(User user)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.User.Add(user);
            ctx.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.User.Update(user);
            ctx.SaveChanges();
            return user;
        }

        public void DeleteUser(User user)
        {
            using var ctx = new ContextManager(_optionsBuilder.Options);
            ctx.User.Remove(user);
            ctx.SaveChanges();
        }
    }
}