using System.Collections.Generic;

namespace SampleProject.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        List<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
