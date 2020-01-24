using SampleProject.Models;
using System.Collections.Generic;

namespace SampleProject.Repository
{
    public interface IUserRepository
    {
        List<Data> GetUsers();
        Data GetUserById(int id);
        Data CreateUser(Data userModel, string password);
        Data EditUser(Data userModel);
        void DeleteUser(int id);
    }
}
