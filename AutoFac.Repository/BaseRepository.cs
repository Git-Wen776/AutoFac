using AutoFac.IRepository;
using AutoFac.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly BlogContext _context;
        public BaseRepository(BlogContext context)
        {
            _context = context;
        }
        public  Task<int> DeleteAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException(nameof(id));
            T t=await this.FindAsync(id);
            return await this.DeleteAsync(t);
        }

        public  Task<int> ExecutQuery(string sql, List<SqlParameter> parameters)
        {
            if(string.IsNullOrEmpty(sql)||parameters is null)
                throw new ArgumentNullException(nameof(sql));
            return _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public ValueTask<T> FindAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            return _context.Set<T>().FindAsync(entity);
        }

        public ValueTask<T> FindAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException(nameof(id));
            return  _context.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public IQueryable Query()
        {
            return _context.Set<T>();
        }

        public IQueryable Query(Expression<Func<T, bool>> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));
            return _context.Set<T>().Where(expression);
        }

        public IQueryable Query(Expression<Func<T, bool>> expression, PageModel pageModel)
        {
            if(expression is null || pageModel is null)
                throw new ArgumentNullException ($"{nameof(expression)} or {nameof(pageModel)} is null");   
            return _context.Set<T>().Where(expression).EntityCorePage(pageModel);
        }

        public IQueryable Query(string sql, List<SqlParameter> parameters)
        {

                if (string.IsNullOrEmpty(sql) || parameters is null)
                    throw new ArgumentNullException(nameof(sql));
            return _context.Set<T>().FromSqlRaw(sql, parameters);
        }

        public  Task<int> UpdateAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync(); 
        }

        /// <summary>
        /// 简单的导航查询
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="where"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IQueryable Query<TProperty>(Expression<Func<T,bool>> where,Expression<Func<T, TProperty>> include)
        {
            if (where is null || include is null)
                throw new ArgumentNullException($"{nameof(where)} or {nameof(include)} is null");
            return _context.Set<T>().Where(where).Include(include);
        }
    }
}
