using ETrade.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var usr = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            ViewBag.User = usr.Mail;
            return View();
        }
    }
}
