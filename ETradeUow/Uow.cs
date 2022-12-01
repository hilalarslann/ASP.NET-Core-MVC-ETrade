using ETrade.Dal;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Uow
{
    public class Uow : IUow
    {

        TradeContext _db;
        public Uow(TradeContext db, IBasketDetailRep basketDetailRep, IBasketMasterRep basketMasterRep, ICategoryRep categoryRep, ICityRep cityRep, ICountyRep countyRep, IProductRep productRep, ISupplierRep supplierRep, IUnitRep unitRep, IUserRep userRep, IVatRep vatRep)
        {
            _db = db;
            _BasketDetailRep = basketDetailRep;
            _BasketMasterRep = basketMasterRep;
            _CategoryRep = categoryRep;
            _CityRep = cityRep;
            _CountyRep = countyRep;
            _ProductRep = productRep;
            _SupplierRep = supplierRep;
            _UnitRep = unitRep;
            _UserRep = userRep;
            _VatRep = vatRep;
        }
    
        public IBasketDetailRep _BasketDetailRep { get; private set; }

        public IBasketMasterRep _BasketMasterRep { get; private set; }

        public ICategoryRep _CategoryRep { get; private set; }

        public ICityRep _CityRep { get; private set; }

        public ICountyRep _CountyRep { get; private set; }

        public IProductRep _ProductRep { get; private set; }

        public ISupplierRep _SupplierRep { get; private set; }

        public IUnitRep _UnitRep { get; private set; }

        public IUserRep _UserRep { get; private set; }

        public IVatRep _VatRep { get; private set; }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
