using System;
using System.Collections.Generic;
using Entities;

namespace DAO.Interfaces
{
    public interface IUserDao
    {
        List<User> GetAllUser();
        User GetUserById(Guid? id);
        User GetUserByName(string name);
        User AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
    }
}