using System.Collections.Generic;
using TodoList.API.Models;

namespace TodoList.API.Services
{
    public class StorageService<TEntity> : IStorageService<TEntity> where TEntity : BaseEntity
    {
        public TEntity Add(TEntity t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity t)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TEntity Update(TEntity t)
        {
            throw new System.NotImplementedException();
        }
    }
}
