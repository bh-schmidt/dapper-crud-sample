
using System.Collections.Generic;
using Api.Models;
using Api.Repositories;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }
    }
}