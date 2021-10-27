using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Api.Models;
using System.Data.SqlClient;
using Dapper;

namespace Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;

        public UserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<User>("SELECT * FROM Users");
            }
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @id", new { id });
            }
        }

        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO Users (FirstName, LastName, Email, Password) VALUES (@firstName, @lastName, @email, @password)", user);
            }
        }

        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("UPDATE Users SET FirstName = @firstName, LastName = @lastName, Email = @email, Password = @password WHERE Id = @id", user);
            }
        }

        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("DELETE FROM Users WHERE Id = @id", new { id });
            }
        }
    }
}