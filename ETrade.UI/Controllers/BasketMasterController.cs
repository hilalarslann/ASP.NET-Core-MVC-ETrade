using ETrade.Dto;
using ETrade.Entity.Concrete;
using ETrade.Uow;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    public class BasketMasterController : Controller
    {
        IUow _uow;
        BasketMaster _basketMaster;
        public BasketMasterController(IUow uow, BasketMaster basketMaster)
        {
            _uow = uow;
            _basketMaster = basketMaster;
        }
        //Müşteri sepete ilk ürününü eklediğinde basket master oluşturulur ve oluşan master id yi basketmastera göndeririz.
        //İkinci bir ürün eklediğinde yeni sepet oluşturmamak için sipariş tamamlanmış mı tamamlanmamış mı diye completed ile kontrolünü sağlarız.
        //Yeni sipariş-ilk master kayıt- o id yi detayda kullanacak- sonra ürün girecek.
        //Ürün yoksa yeni bir basket master oluşturup id yi detay mastera göndeririz.
        public IActionResult Create()
        {
            var usr = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            var selectedBasket = _uow._BasketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == usr.Id);
            if (selectedBasket != null)
            {
                return RedirectToAction("Add", "BasketDetail", new { id = selectedBasket.Id });
            }
            else
            {
                _basketMaster.OrderDate = DateTime.Now;
                _basketMaster.EntityId = usr.Id;
                _uow._BasketMasterRep.Add(_basketMaster);
                _uow.Commit();
                return RedirectToAction("Add", "BasketDetail", new { id = _basketMaster.Id });
            }
            return View();
        }
    }
}
