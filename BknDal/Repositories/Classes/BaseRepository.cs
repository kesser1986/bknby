using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BknDal.Repositories.Interfaces;

namespace BknDal.Repositories.Classes
{
    public class BaseRepository<T, I> : IRepository<T, I> where T : class
    {
        public async Task Create(T entity)
        {
            using (var db = DbContextFactory.OpenContext())
            {
                db.Set<T>().Add(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(I id)
        {
            using (var db = DbContextFactory.OpenContext())
            {
                var item = await db.Set<T>().FindAsync(id);
                if (item != null)
                {
                    db.Set<T>().Remove(item);
                    await db.SaveChangesAsync();
                }
            }
        }

        public async Task<T> Get(I id)
        {
            using (var db = DbContextFactory.OpenContext())
            {
                return await db.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> GetAll()
        {
            using (var db = DbContextFactory.OpenContext())
            {
                return await db.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T entity)
        {
            using (var db = DbContextFactory.OpenContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            using (var db = DbContextFactory.OpenContext())
            {
                return await db.Set<T>().Where(expression).ToListAsync();
            }
        }
    }
}
