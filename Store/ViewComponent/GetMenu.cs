using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Application.Services.Common.Queries.GetMenuItem;

namespace Store.ViewComponent
{
    public class GetMenu : ViewComponent
    {
        private readonly IGetMenusItem _getMenuItemService;
        public GetMenu(IGetMenusItem getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }


        public IViewComponentResult Invoke()
        {
            var menuItem = _getMenuItemService.Execute();
            return View(viewName: "GetMenu", menuItem.Data);
        }

    }
}
