using ETrade.Entity.Concrete;

namespace ETrade.UI.Models.ViewModel
{
    public class UserModel
    {
        public User User { get; set; }
        public List<County> Counties { get; set; }
        public string Msg { get; set; }
    }
}
