using Core.Abstracts.Bases;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext context;
        protected DbSet<T> set;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            set = this.context.Set<T>();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression != null ? await set.CountAsync(expression) : await set.CountAsync();
        }

        public async Task DeleteAllAsync()
        {
            var entities = await GetAllAsync();
            //Fiziksel silme:
            await DeleteManyAsync(entities);

            //Silindi gösterme:
            //var deleted_entities = new List<T>();
            //foreach (var item in entities)
            //{
            //    item.Deleted = true;
            //    item.Active = false;
            //    deleted_entities.Add(item);
            //}
            //await UpdateManyAsync(deleted_entities);
        }

        public async Task DeleteManyAsync(IEnumerable<T> entities)
        {
            //Fiziksel silme:
            await Task.Run(() => set.RemoveRange(entities));

            //Silindi gösterme:
            //var deleted_entities = new List<T>();
            //foreach (var item in entities)
            //{
            //    item.Deleted = true;
            //    item.Active = false;
            //    deleted_entities.Add(item);
            //}
            //await UpdateManyAsync(deleted_entities);
        }

        public async Task DeleteOneAsync(T entity)
        {
            //Fiziksel silme:
            await Task.Run(() => set.Remove(entity));

            //Silindi gösterme:
            //entity.Deleted = true;
            //entity.Active = false;
            //await UpdateOneAsync(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await set.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string[]? includes = null)
        {
            IQueryable<T> data = set;
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    data = data.Include(item);
                }
            }
            return await Task.Run(() => data);
        }

        public async Task<T?> GetFirstAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression != null ? await set.FirstOrDefaultAsync(expression) : await set.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> expression, string[]? includes = null)
        {
            IQueryable<T> data = set.Where(expression);
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    data = data.Include(item);
                }
            }
            return await Task.Run(() => data);
        }

        public async Task<T?> GetOneAsync(object entityKey)
        {
            return await set.FindAsync(entityKey);
        }

        public async Task InsertManyAsync(IEnumerable<T> entities)
        {
            await set.AddRangeAsync(entities);
        }

        public async Task InsertOneAsync(T entity)
        {
            await set.AddAsync(entity);
        }

        public async Task UpdateManyAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => set.UpdateRange(entities));
        }

        public async Task UpdateOneAsync(T entity)
        {
            await Task.Run(() => set.Update(entity));
        }
    }
}
