using Microsoft.AspNetCore.Mvc;
using ShopOn.Models;

namespace ShopOn.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        string BaseAddress2;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            this.BaseAddress2 = _configuration.GetValue<string>("BaseAddress2");
        }

        public IActionResult GetAllCategoriesItems()
        {
            var URL = this.BaseAddress2 + "GetAllCategories";
            var AllCategoryItems = APIShopOnURL.GetApiCategoryData(URL);
            return View(AllCategoryItems.Result);
        }

    }
}
