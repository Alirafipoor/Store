using Microsoft.AspNetCore.Mvc;
using Store.Application.interfaces.FacadPattern;
using Store.Application.Services.Product.FacadPattern;
using Store.Application.Services.Product.Queries.GetProductForSite;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productfacad;
        public ProductsController(IProductFacad productfacad)
        {
            _productfacad = productfacad;
        }
        public IActionResult Index(Ordering ordering, string Searchkey, long? CatId = null, int page = 1, int pageSize = 20)
        {
            return View(_productfacad.GetProductForSite.Execute(ordering, Searchkey, page, pageSize, CatId).Data);
        }
        public IActionResult Detail(long Id)
        {
            return View(_productfacad.GetProductDetailsForSite.Execute(Id).Data);
        }
    }
}
