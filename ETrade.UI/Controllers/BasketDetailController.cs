using ETrade.Dto;
using ETrade.Entity.Concrete;
using ETrade.UI.Models.ViewModel;
using ETrade.Uow;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    public class BasketDetailController : Controller
    {
        BasketDetailModel _detailModel;
        BasketDetail _basketDetail;
        IUow _uow;
        public BasketDetailController(BasketDetailModel detailModel, IUow uow, BasketDetail basketDetail)
        {
            _detailModel = detailModel;
            _basketDetail = basketDetail;
            _uow = uow;
        }

        public IActionResult Add(int id)
        {
            _detailModel.ProductDTOs = _uow._ProductRep.GetProductsSelect();
            _detailModel.BasketDetailDTOs = _uow._BasketDetailRep.BasketDetailDTOs(id);
            return View(_detailModel);
        }
        [HttpPost]
        public IActionResult Add(BasketDetailModel m, int id)
        {
            Product product = _uow._ProductRep.FindWithVat(m.ProductId);
            _basketDetail.Amount = m.Amount;
            _basketDetail.ProductId = m.ProductId;
            _basketDetail.Id = id;
            _basketDetail.OrderId = id;
            _basketDetail.UnitId = product.UnitId;
            //Araştır - Eager Loading lle metot girmek lazım.
            _basketDetail.Ratio = product.Vats.Ratio;
            _basketDetail.UnitPrice = product.UnitPrice;
            _uow._BasketDetailRep.Add(_basketDetail);
            _uow.Commit();

            return RedirectToAction("Add", new { id });
        }

        public IActionResult Delete(int id, int productId)
        {
            _uow._BasketDetailRep.Delete(id, productId);
            _uow.Commit();
            //IActionResult Add(int id) Add actionında int parametre göndermemiz gerekir.
            return RedirectToAction("Add", new { id });
        }

        public IActionResult Update(int id, int productId)
        {
            return View(_uow._BasketDetailRep.Find(id, productId));
        }

        [HttpPost]
        public IActionResult Update(int Amount, int id, int productId)
        {
            var selectedBasDetail = _uow._BasketDetailRep.Find(id, productId);
            selectedBasDetail.Amount = Amount;
            _uow._BasketDetailRep.Update(selectedBasDetail);
            _uow.Commit();
            return RedirectToAction("Add", new { id });
        }
    }
}
