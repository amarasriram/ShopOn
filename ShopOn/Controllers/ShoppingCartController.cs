using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOn.Models;

namespace ShopOn.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IConfiguration _configuration;
        string BaseAddress1;
        public ShoppingCartController(IConfiguration configuration)
        {
            _configuration = configuration;
            this.BaseAddress1 = _configuration.GetValue<string>("BaseAddress1");
        }

        public IActionResult BuyNow(int ElectronicItemId)
        {
            var URL = this.BaseAddress1 + "GetAllPies";
            var electronicItems = APIShopOnURL.GetApiElectronicItemsData(URL);
            return View(electronicItems.Result.FirstOrDefault(x => x.ElectronicItemId == ElectronicItemId));
        }



        public async Task<IActionResult> AddToCart(int ElectronicItemId)
        {

            var URL = this.BaseAddress1 + "AddToCartItem?itemId=" + ElectronicItemId;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(URL, ElectronicItemId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetAllItems", "ElectronicItem");

        }

        public async Task<IActionResult> AddToCart11(int ElectronicItemId)
        {

            var URL = this.BaseAddress1 + "AddToCartItem?itemId=" + ElectronicItemId;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(URL, ElectronicItemId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetCartItems");

        }



        public async Task<IActionResult> GetCartItems()
        {
            var URL = this.BaseAddress1 + "GetCartItems";
            var CartDetails = APIShopOnURL.GetApiCartData(URL);
            ViewBag.OrderTotal = CartDetails.Result.Sum(x => (x.ItemPrice * x.Quantity));
            return View(CartDetails.Result);
        }




        public async Task<IActionResult> RemoveCartItem(int CartId)
        {
            var URL = this.BaseAddress1 + "RemoveCartItem?id=" + CartId;
            var status = APIShopOnURL.RemoveData(URL);
            return RedirectToAction("GetCartItems");
        }



        public async Task<IActionResult> DecreamentCartItem(int ElectronicItemId)
        {
            var URL = this.BaseAddress1 + "DecreamentCartItem?itemId=" + ElectronicItemId;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetCartItems");
        }

    }
}
