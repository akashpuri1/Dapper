using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Services
{
    public interface IUserServices
    {
        List<User> GetUsers();
        User GetUserById(int id);
        User CreateUser(User userModel, string password);
        User EditUser(User userModel);
        void DeleteUser(int id);
    }
}
