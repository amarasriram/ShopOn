using Microsoft.AspNetCore.Mvc;
using ShopOn.Models;

namespace ShopOn.Components
{
    public class CategoryMenu : ViewComponent
    {
        
        private readonly IConfiguration configuration;
       
        string BaseAddress2;
        public CategoryMenu(IConfiguration configuration)
        {
           
            this.BaseAddress2 = configuration.GetValue<string>("BaseAddress2");

        }

        public IViewComponentResult Invoke()
        {
            var URL = this.BaseAddress2 + "GetAllCategories";
            var category = APIShopOnURL.GetApiCategoryData(URL);
            return View(category.Result);
        }
    }
}
