using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CORE.NG.DATA.Context
{
    public class Repository: DbContext, IRepository
    {
        public Repository(DbContextOptions options) : base(options) { }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public void Delete<T>(T entity) where T: class, ISupportIdentity
        {
            base.Remove<T>(entity);
        }

        public async Task DeleteAsync<T>(T entity) where T: class, ISupportIdentity
        {
            await Task.Run(() => base.Remove<T>(entity));
        }

        public T Find<T>(int id) where T: class, ISupportIdentity
        {
            return base.Find<T>(id);
        }

        public async Task<T> FindAsync<T>(int id) where T: class, ISupportIdentity
        {
            return await base.FindAsync<T>(id);
        }

        public IEnumerable<T> GetAll<T>() where T: class, ISupportIdentity
        {
            return base.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T: class, ISupportIdentity
        {
            return await base.Set<T>().ToListAsync();
        }

        public T Insert<T>(T entity) where T: class, ISupportIdentity
        {
            var model = base.Add<T>(entity);
            return model.Entity;
        }

        public async Task<T> InsertAsync<T>(T entity) where T: class, ISupportIdentity
        {
            var model = await base.AddAsync<T>(entity);
            return model.Entity;
        }

        public T Update<T>(T entity, int id) where T: class, ISupportIdentity
        {
            var model = base.Update<T>(entity);
            return model.Entity;
        }

        public async Task<T> UpdateAsync<T>(T entity, int id) where T: class, ISupportIdentity
        {
            var model = await Task.Run(() => base.Update<T>(entity));
            return model.Entity;
        }
        public IQueryable<T> GetQuery<T>() where T : class
        {
            return base.Set<T>();
        }

    }
}