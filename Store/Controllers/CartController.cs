using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Cart;
using Store.Utilities;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManager;
        public CartController(ICartService cartservice)
        {
            _cartService = cartservice;
            _cookiesManager = new CookiesManager();
        }
        public IActionResult Index()
        {
            var userId = ClaimUtility.GetUserId(User);

            var resultGetLst = _cartService.GetMyCart(_cookiesManager.GetBroswerId(HttpContext), userId);

            return View(resultGetLst.Data);
        }
        public IActionResult AddToCart(long ProductId)
        {
            CookiesManager cookiesManager = new CookiesManager();

            _cartService.AddToCart(ProductId, cookiesManager.GetBroswerId(HttpContext));


            return RedirectToAction("Index");
        }
        public IActionResult Add(long CartItemId)
        {
            _cartService.Add(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(long CartItemId)
        {
            _cartService.LowOff(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(long ProductId)
        {
            _cartService.RemoveFromCart(ProductId, _cookiesManager.GetBroswerId(HttpContext));
            return RedirectToAction("Index");

        }
    }
}
