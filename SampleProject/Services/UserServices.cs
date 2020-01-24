using System.Collections.Generic;
using SampleProject.Models;
using SampleProject.Repository;

namespace SampleProject.Services
{
    public class UserServices : IUserServices
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;
        public UserServices(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public Data CreateUser(Data userModel, string password)
        {
            return _userRepository.CreateUser(userModel,password);
        }

        public void DeleteUser(int id)
        {
             _userRepository.DeleteUser(id);
        }

        public Data EditUser(Data userModel)
        {
            return _userRepository.EditUser(userModel);
        }

        public Data GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<Data> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
