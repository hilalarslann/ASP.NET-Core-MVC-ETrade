using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Abstract
{
    public interface IAddress
    {
        public string Street { get; set; }
        public string Avenue { get; set; }
        public int No { get; set; }
        public int CountyId { get; set; }
    }
}
