using System.Collections.Generic;
using TodoList.API.Models;

namespace TodoList.API.Services
{
    public interface IStorageService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity t);
        TEntity Update(TEntity t);
        List<TEntity> GetAll();
        TEntity Get(int id);
        void Delete(TEntity t);
    }
}
