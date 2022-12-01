using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class County : BaseDescription
    {
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
