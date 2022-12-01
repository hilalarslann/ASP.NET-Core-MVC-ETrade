using ETrade.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Concrete
{
    public class BaseEntity : IBaseTable, IAddress
    {
        [Key]
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string Street { get; set; }
        public string Avenue { get; set; }
        public int No { get; set; }
        public int CountyId { get; set; }
    }
}
