using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concrete;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concrete
{
    public class CategoryRep<T> : BaseRepository<Category>, ICategoryRep where T : class
    {
        public CategoryRep(TradeContext db) : base(db)
        {
        }
    }
}
