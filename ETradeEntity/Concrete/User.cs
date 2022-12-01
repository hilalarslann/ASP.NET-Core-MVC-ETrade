using ETrade.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class User : BaseEntity
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [ForeignKey("CountyId")]
        public County County { get; set; }
        public bool Error { get; set; }
        public ICollection<BasketMaster> BasketMaster { get; set; }
    }
}
