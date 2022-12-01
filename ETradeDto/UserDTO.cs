using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto
{
    //Sessiona kaydedeceğimiz için bu Dto yu oluşturduk.
    public class UserDTO
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Role { get; set; }
        public bool Error { get; set; }
    }
}
