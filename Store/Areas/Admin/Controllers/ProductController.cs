using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.interfaces.FacadPattern;
using Store.Application.Services.Product.FacadPattern;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductFacad _productFacad;
        public ProductController(ProductFacad productfacad)
        {
            _productFacad = productfacad;
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategory.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request, List<AddNewProduct_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_productFacad.AddNewProductService.Execute(request));
        }
        public IActionResult Index(int Page = 1, int PageSize = 20)
        {
            return View(_productFacad.GetProductForAdminService.Execute(Page, PageSize).Data);
        }
        public IActionResult Detail(long Id)
        {
            return View(_productFacad.GetProductDetailsForAdmin.Execute(Id).Data);
        }
        public IActionResult Delete(long Id)
        {
  
            return Json(_productFacad.deleteProduct.Execute(Id));
        }
    }
}
