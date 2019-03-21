using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.API.Models;

namespace TodoList.API.Services
{
    public interface IStorageService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity t);
        TEntity Update(TEntity t);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(string id);
        void Delete(TEntity t);
    }
}
