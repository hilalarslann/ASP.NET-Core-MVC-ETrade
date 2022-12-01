using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto
{
    //Ürünü seçerken sadece id-product-name lazım o yüzden bu dto yu oluşturduk
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
