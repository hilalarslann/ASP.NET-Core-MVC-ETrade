using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> List(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int Id);
        bool Delete(int Id, int Id2);
        T Find(int Id);
        T Find(int Id, int Id2);
        DbSet<T> Set();
    }
}
