using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto
{
    public class BasketDetailDTO
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public string UnitName { get; set; }
        public decimal Ratio { get; set; }
        public int ProductId { get; set; }
        public int Id { get; set; }
        public decimal Total { get; set; }
    }
}
