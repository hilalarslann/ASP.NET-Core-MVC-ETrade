using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Uow
{
    public interface IUow
    {
        IBasketDetailRep _BasketDetailRep { get; }
        IBasketMasterRep _BasketMasterRep { get; }
        ICategoryRep _CategoryRep { get; }
        ICityRep _CityRep { get; }
        ICountyRep _CountyRep { get; }
        IProductRep _ProductRep { get; }
        ISupplierRep _SupplierRep { get; }
        IUnitRep _UnitRep { get; }
        IUserRep _UserRep { get; }
        IVatRep _VatRep { get; }

        void Commit();
    }
}
