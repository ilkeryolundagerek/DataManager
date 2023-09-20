using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task InsertOneAsync(T entity);
        Task InsertManyAsync(IEnumerable<T> entities);

        Task UpdateOneAsync(T entity);
        Task UpdateManyAsync(IEnumerable<T> entities);

        Task DeleteOneAsync(T entity);
        Task DeleteManyAsync(IEnumerable<T> entities);
        Task DeleteAllAsync();

        Task<IEnumerable<T>> GetAllAsync(string[]? includes = null);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> expression, string[]? includes = null);
        Task<T?> GetOneAsync(string entityKey);
        Task<T?> GetFirstAsync(Expression<Func<T, bool>>? expression = null);

        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    }
}
