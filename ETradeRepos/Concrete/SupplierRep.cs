using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concrete;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concretes
{
    public class SupplierRep<T> : BaseRepository<Supplier>, ISupplierRep where T : class
    {
        public SupplierRep(TradeContext db) : base(db)
        {
        }
    }
}
