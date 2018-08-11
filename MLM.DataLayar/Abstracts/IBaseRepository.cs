using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MLM.DataLayer.Abstracts
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Add(T t);
        /// <summary>
        /// Add new record using threading
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<T> AddAsync(T t);
        /// <summary>
        /// count total records in a entity
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// Count total records with help of threading
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
        void Delete(T entity);
        Task<int> DeleteAsync(T entity);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        T Get(Guid ID);
        Task<T> GetAsync(Guid ID);
        IEnumerable<T> All { get; }
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        /// <summary>
        /// Commit records
        /// </summary>
        void Save();
        Task<int> SaveAsync();
        T Update(T t, object key);
        Task<T> UpdateAsync(T t, object key);
    }
}