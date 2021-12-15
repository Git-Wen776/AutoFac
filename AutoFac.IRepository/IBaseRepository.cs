using AutoFac.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.IRepository
{
    public interface IBaseRepository<T> where T:class,new()
    {
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(int id);
        ValueTask<T> FindAsync(T entity);
        ValueTask<T> FindAsync(int id);
        IQueryable Query();
        IQueryable Query(Expression<Func<T, bool>> expression);
        IQueryable Query(Expression<Func<T, bool>> expression,PageModel pageModel);
        IQueryable Query(string sql, List<SqlParameter> parameters);
        Task<int> ExecutQuery(string sql, List<SqlParameter> parameters);
    }
}
