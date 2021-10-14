using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Unikrowd.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Add(T entity);
        Task AddAsync(T entity);

        // Marks an entity as modified
        void Update(T entity);      
        void UpdateRange(IEnumerable<T> entities);      

        // Marks an entity to be removed
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        void Delete(int id);

        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        // Get an entity by int id
        T GetSingleById(int id);
        Task<T> GetSingleByIdAsync(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        Task<IEnumerable<T>> GetMultiAsync(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);       

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where, string includes);

    }
}