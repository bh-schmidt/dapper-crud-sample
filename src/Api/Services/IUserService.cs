using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUser(User user);
    }
}