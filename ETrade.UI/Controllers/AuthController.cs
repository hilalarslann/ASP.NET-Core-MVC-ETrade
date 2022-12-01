using ETrade.Dto;
using ETrade.Entity.Concrete;
using ETrade.Repos.Concretes;
using ETrade.UI.Models.ViewModel;
using ETrade.Uow;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    public class AuthController : Controller
    {
        public const string SessionUser = "";

        IUow _uow;
        UserModel _model;
        public AuthController(IUow uow, UserModel model)
        {
            _uow = uow;
            _model = model;
        }

        public IActionResult Register()
        {
            _model.User = new User();
            _model.Counties = _uow._CountyRep.List();
            return View(_model);
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            model.User = _uow._UserRep.CreateUser(model.User);
            if (!model.User.Error)
            {
                //Burada şifreleme işlemi yaptık.
                _uow._UserRep.Add(model.User);
                _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.Msg = $"{model.User.Mail} zaten mevcut";
                model.Counties = _uow._CountyRep.List();
                return View(model);
            }
        }
        //Login olur olmaz hangi bilgilerle login olduğumuzu saklayacağız.
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Mail, string Password)
        {
            //Session
            UserDTO user = _uow._UserRep.Login(Mail, Password);

            if (user.Error == false)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
