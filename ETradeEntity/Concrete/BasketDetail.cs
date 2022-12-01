using ETrade.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class BasketDetail : IBaseTable
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        //Ratio-Oran
        public decimal Ratio { get; set; }
        public int UnitId { get; set; }

        [ForeignKey("OrderId")]
        public BasketMaster BasketMaster { get; set; }
        [ForeignKey("ProductId")]
        public Product Products { get; set; }
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
    }
}
