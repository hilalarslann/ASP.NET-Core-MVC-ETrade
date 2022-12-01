using ETrade.Core;
using ETrade.Dto;
using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Abstract
{
    public interface IUserRep : IBaseRepository<User>
    {
        User CreateUser(User user);
        UserDTO Login(string Mail, string Password); 
    }
}
