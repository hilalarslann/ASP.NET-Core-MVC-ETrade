using ETrade.Core;
using ETrade.Dal;
using ETrade.Entity.Concrete;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using ETrade.Dto;

namespace ETrade.Repos.Concretes
{
    public class UserRep<T> : BaseRepository<User>, IUserRep where T : class
    {
        TradeContext _db;
        UserDTO UserDto;
        public UserRep(TradeContext db) : base(db)
        {
            _db = db;
        }

        public User CreateUser(User user)
        {
            //Where ile yapsakta FirstOrDefault ile bitirmem şart olduğu için direk FirstOrDefaultun içinde şartımı yazdım.
            User selectedUser = _db.Set<User>().FirstOrDefault(x => x.Mail == user.Mail);

            if (selectedUser != null)
                user.Error = true;
            else
                user.Error = false;

            //BCrypt.Net.BCrypt.HashPassword(user.Password); arayüzden girilen parolayı şifreler.Yazılım sahibi kişide şifrenizi göremez.
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "User";


            return user;
        }

        public UserDTO Login(string Mail, string Password)
        {
            User selectedUser = _db.Set<User>().FirstOrDefault(x => x.Mail == Mail);
            UserDTO user = new UserDTO();
            user.Mail = Mail;
  
            if (selectedUser != null)
            {
                user.Error = false;
                //Ekrandan gelen 
                bool verified = BCrypt.Net.BCrypt.Verify(Password, selectedUser.Password);
                if (verified == true)
                {
                    user.Role = selectedUser.Role;
                    user.Id = selectedUser.Id;
                    user.Error = false;
                }
                else
                {
                    user.Error = true;
                }
            }
            else
            {
                user.Error = true;
            }
            return user;
        }
    }
}
