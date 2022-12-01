using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        TradeContext _db;
        public BaseRepository(TradeContext db)
        {
            _db = db;
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(int id)
        {
            return Set().Find(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return Set().SingleOrDefault(filter);
        }

        public List<T> List(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? Set().ToList() : Set().Where(filter).ToList();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id, int Id2)
        {
            try
            {
                Set().Remove(Find(Id, Id2));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(int Id, int Id2)
        {
            return Set().Find(Id, Id2);
            //Find metodu keyValues istiyor yani parametre olarak primary key, composite key istiyor tabloda o alanlarda arama yapıyor.
            //Find metoduna gönderilen parametrelerin sırası önemli tabloda ilk keyden eşleştirme yapmaya başlar.
            //BasketDetail Id = BD.Id Id2 = PD.Id2
        }
    }
}
