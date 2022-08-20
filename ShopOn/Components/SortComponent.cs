using Microsoft.AspNetCore.Mvc;
using ShopOn.Models;

namespace ShopOn.Components
{
    public class SortComponent : ViewComponent
    {    
        public SortComponent()
        {
           

        }

        public IViewComponentResult Invoke()
        {
            

            return View();
        }
    }
    
}
