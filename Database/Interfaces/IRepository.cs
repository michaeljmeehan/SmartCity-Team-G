using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTA.Database.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(string id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task<T> Delete(string id);
    }
}
