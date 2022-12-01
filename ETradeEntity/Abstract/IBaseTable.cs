using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entity.Abstract
{
    public interface IBaseTable
    {
        [Key]
        public int Id { get; set; }
    }
}
