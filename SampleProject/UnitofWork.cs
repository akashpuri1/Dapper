using SampleProject.Repository;
using System;

namespace SampleProject
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        public UnitOfWork(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        void IUnitOfWork.Complete()
        {
            throw new NotImplementedException();
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository;
            }
        }
    }
}