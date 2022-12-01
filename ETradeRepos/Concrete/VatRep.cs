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
    public class VatRep<T> : BaseRepository<Vat>, IVatRep where T : class
    {
        public VatRep(TradeContext db) : base(db)
        {
        }
    }
}
