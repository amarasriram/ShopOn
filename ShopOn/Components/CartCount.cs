using Microsoft.AspNetCore.Mvc;
using ShopOn.Models;

namespace ShopOn.Components
{
    public class CartCount : ViewComponent
    {
        private readonly IConfiguration _configuration;
        public string BaseAddress1;
        public CartCount(IConfiguration configuration)
        {
            _configuration = configuration;
            this.BaseAddress1 = configuration.GetValue<string>("BaseAddress1");
        }

        public IViewComponentResult Invoke()
        {
            
            var URL = this.BaseAddress1 + "GetCartItems";
            var CartDetails = APIShopOnURL.GetApiCartData(URL);
            ViewBag.CartCount = CartDetails.Result.Count();

            return View(CartDetails.Result);
        }
    }
}
