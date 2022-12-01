using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class Category : BaseDescription
    {
        public ICollection<Product> Products { get; set; }
    }
}
