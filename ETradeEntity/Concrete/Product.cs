using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class Product : BaseDescription
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public int VatId { get; set; }
        [ForeignKey("VatId")]
        public Vat Vats { get; set; }

        [ForeignKey("CategoryId")]
        public Category Categories { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        public ICollection<BasketDetail> BasketDetail { get; set; }
    }
}
