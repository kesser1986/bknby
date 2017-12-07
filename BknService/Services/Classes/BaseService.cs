using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BknDal.Repositories.Interfaces;
using BknService.Services.Interfaces;

namespace BknService.Services.Classes
{
    public class BaseService<T, I> : IService<T, I> where T : class
    {
        private readonly IRepository<T, I> _repository;

        public BaseService(IRepository<T, I> repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<T> Get(I id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task Create(T entity)
        {
            await _repository.Create(entity);
        }

        public virtual async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        public virtual async Task Delete(I id)
        {
            await _repository.Delete(id);
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _repository.GetAll(expression);
        }
    }
}
