using Microsoft.AspNetCore.Mvc;

namespace ShopOn.Components
{
    public class SearchComponent : ViewComponent
    {
        public SearchComponent()
        {


        }

        public IViewComponentResult Invoke()
        {


            return View();
        }
    }
}
