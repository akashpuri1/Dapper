using System.Collections.Generic;

namespace SampleProject.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public TEntity Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}