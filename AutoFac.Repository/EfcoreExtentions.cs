using AutoFac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Repository
{
    public static class EfcoreExtentions
    {
        public static IQueryable<TSource> EntityCorePage<TSource>(this IQueryable<TSource> sources, PageModel page)
        {
            if (sources is null)
                throw new ArgumentNullException(nameof(sources));
            return sources.Take(page.Size).Skip(page.Size * (page.Page - 1));
        }

        public static IQueryable<TSourse> WhereIf<TSourse>(this IQueryable<TSourse> sourse,bool istrue,Expression<Func<TSourse,bool>> func)
        {
            if (!istrue)
                return sourse;
            return sourse.Where(func);
        }
    }
}
