using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUser(User user);
    }
}