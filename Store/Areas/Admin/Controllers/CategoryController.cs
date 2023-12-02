using Microsoft.AspNetCore.Mvc;
using Store.Application.interfaces.FacadPattern;
using Store.Application.Services.Product.FacadPattern;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IProductFacad _ProductFacad;
        public CategoryController(IProductFacad productFacad)
        {
            _ProductFacad = productFacad;
        }
        public IActionResult Index(long? parentId)
        {
            return View(_ProductFacad.GetCategoryService.Execute(parentId).Data);
            
        }
        public IActionResult AddnewCategory(long? ParentId)
        {
            ViewBag.ParentId = ParentId;
            return View();
        }
        [HttpPost]
        public IActionResult AddnewCategory(string name,long? ParentId)
        {
            var result = _ProductFacad.AddNewCategoryService.Execute(ParentId, name);
            return Json(result);
        }
    }
}
