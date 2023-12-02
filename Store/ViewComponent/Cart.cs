using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Store.Application.Services.Cart;
using Store.Utilities;
using System.Numerics;

namespace Store.ViewComponent
{
    public class Cart:ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManager;
        public Cart(ICartService cart, CookiesManager cookiemanager)
        {
            _cartService = cart;
            _cookiesManager = cookiemanager;
        }

        public IViewComponentResult Invoke()
        {
            return view(viewName: "cart", _cartService.GetMyCart(_cookiesManager.GetBroswerId(HttpContext)).Data);
        }
    }
}
