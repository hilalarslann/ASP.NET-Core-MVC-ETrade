using ETrade.Core;
using ETrade.Dal;
using ETrade.Dto;
using ETrade.Entity.Concrete;
using ETrade.Repos.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concretes
{
    public class ProductRep<T> : BaseRepository<Product>, IProductRep where T : class
    {
        public ProductRep(TradeContext db) : base(db)
        {
        }

        public Product FindWithVat(int Id)
        {
            //Lazy Loading 
            return Set().Where(x => x.Id == Id).Include(x => x.Vats).FirstOrDefault();
        }

        public List<ProductDTO> GetProductsSelect()
        {
            return Set().Select(x => new ProductDTO { Id = x.Id, ProductName = x.ProductName }).ToList();
        }
    }
}
