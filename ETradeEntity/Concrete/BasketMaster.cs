using ETrade.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class BasketMaster : IBaseTable
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Completed { get; set; }
        public int EntityId { get; set; }
        [ForeignKey("EntityId")]
        public User Users { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
