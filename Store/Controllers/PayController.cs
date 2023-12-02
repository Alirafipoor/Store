using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Cart;
using Store.Application.Services.Finance.Commands.AddRequestPay;
using Store.Domain.Entites.Finance;
using Store.Utilities;

namespace Store.Controllers
{
    public class PayController : Controller
    {
        private readonly IAddRequestPay _requestpay;
        private readonly ICartService _cartService; 
        private readonly CookiesManager _cookiesManager;
        public PayController(IAddRequestPay addRequestPay, ICartService cartService, CookiesManager cookiesManager)
        {
            _requestpay = addRequestPay;
            _cartService = cartService;
            _cookiesManager = cookiesManager;
        }
        public IActionResult Index()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var cart=_cartService.GetMyCart(_cookiesManager.GetBroswerId(HttpContext),UserId);
            var requestpay=_requestpay.Execute(cart.Data.SumAmount, UserId.Value);
            return View();
        }
    }
}
