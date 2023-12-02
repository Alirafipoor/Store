using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Product.Queries.GetCategoryService;

namespace Store.ViewComponent
{
    public class Search : ViewComponent
    {
        private readonly IGetCategoryService _getCategoryService;
        public Search(IGetCategoryService getCategoryService)
        {
            _getCategoryService = getCategoryService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _getCategoryService.Execute().Data);
        }
    }
}
