using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class Vat : BaseDescription
    {
        //Ratio : oran
        public decimal Ratio { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
