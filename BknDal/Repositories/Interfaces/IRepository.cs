using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BknDal.Repositories.Interfaces
{
    public interface IRepository<T, I> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
        Task<T> Get(I id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(I id);
    }
}
