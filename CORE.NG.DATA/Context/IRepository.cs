using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.NG.DATA.Context
{
    public interface IRepository: IDisposable
    {
        IEnumerable<T> GetAll<T>() where T : class, ISupportIdentity;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class, ISupportIdentity;
        T Find<T>(int id) where T : class, ISupportIdentity;
        Task<T> FindAsync<T>(int id) where T : class, ISupportIdentity;
        T Insert<T>(T entity) where T : class, ISupportIdentity;
        Task<T> InsertAsync<T>(T entity) where T : class, ISupportIdentity;
        T Update<T>(T entity, int id) where T : class, ISupportIdentity;
        Task<T> UpdateAsync<T>(T entity, int id) where T : class, ISupportIdentity;
        void Delete<T>(T entity) where T : class, ISupportIdentity;
        Task DeleteAsync<T>(T entity) where T : class, ISupportIdentity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IQueryable<T> GetQuery<T>() where T : class;
    }
}
