using Microsoft.AspNetCore.Mvc;
using ShopOn.Models;

namespace ShopOn.Controllers
{
    public class ElectronicItemController : Controller
    {
        private readonly IConfiguration _configuration;
        string BaseAddress1;
        public ElectronicItemController(IConfiguration configuration)
        {
            _configuration = configuration;
            this.BaseAddress1 = _configuration.GetValue<string>("BaseAddress1");
        }
        public IActionResult SearchList(string searchValue)
        {
            var URL = this.BaseAddress1 + "GetAllItems";
            var electronicItems = APIShopOnURL.GetApiElectronicItemsData(URL);
            var ResultOfsearch = electronicItems.Result.Where(x => x.Name.ToLower().Contains(searchValue.ToLower()) || x.BrandName.ToLower().Contains(searchValue.ToLower()));
            return View(ResultOfsearch);
        }
        public IActionResult SortList(int Id)
        {
            var URL = this.BaseAddress1 + "GetAllItems";
            var AllItems = APIShopOnURL.GetApiElectronicItemsData(URL);

            if (Id == 1)
            {
                return View(AllItems.Result.OrderBy(x =>x.Price));
            }
            else
            {
                return View(AllItems.Result.OrderByDescending(x=>x.Price));
            }
        }

        public IActionResult GetAllItems(int CategoryId)
        {
            var URL = this.BaseAddress1 + "GetAllItems";
            var AllItems = APIShopOnURL.GetApiElectronicItemsData(URL);

            if (CategoryId > 0)
            {
                return View(AllItems.Result.Where(x => x.CategoryId == CategoryId));
            }
            else
            {
                return View(AllItems.Result);
            }
        }

        public async Task<IActionResult> AddToWishList(int id)
        {
            var URL = this.BaseAddress1 + "AddToWishList?ItemIdNumber=" + id;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(URL, id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetAllItems");

        }

        public IActionResult GetWishListItems()
        {
            List<ElectronicItem> electronicItems = new List<ElectronicItem>();
            var URL = this.BaseAddress1 + "GetWishListDetails";
            var Ids = APIShopOnURL.GetApiWishListData(URL);
            var AllDistinctIds = Ids.Result.DistinctBy(x => x.ItemIdentityNumber);
            var AllElectronicItems = APIShopOnURL.GetApiElectronicItemsData(this.BaseAddress1 + "GetAllItems");
            foreach (var item in AllDistinctIds)
            {
                var AllItems = AllElectronicItems.Result.FirstOrDefault(x => x.ElectronicItemId == item.ItemIdentityNumber);
                if (AllItems != null)
                {
                    electronicItems.Add(AllItems);
                }
            }
            return View(electronicItems);
        }


        public async Task<IActionResult> DeleteWishListItem(int ElectronicItemId)
        {
            var URL = BaseAddress1 + "RemoveWishListItem?id=" + ElectronicItemId;
            // var student = studentRepository.GetAllStudents().FirstOrDefault(student => student.StudentID == studentId);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetWishListItems");
        }

        public IActionResult Details(int id)
        {
            var URL = this.BaseAddress1 + "GetAllItems";
            var electronicItems = APIShopOnURL.GetApiElectronicItemsData(URL);
            var AllItems = electronicItems.Result.FirstOrDefault(x => x.ElectronicItemId == id);
            return View(AllItems);
        }

        public IActionResult Edit(int id)
        {
            var URL = this.BaseAddress1 + "GetAllItems";
            var electronicItems = APIShopOnURL.GetApiElectronicItemsData(URL);
            var AllItems = electronicItems.Result.FirstOrDefault(x => x.ElectronicItemId == id);
            return View(AllItems);
        }

        public async Task<IActionResult> UpdateElectronicItem(ElectronicItem electronicItem)
        {
            var URL = this.BaseAddress1 + "UpdateElectronicItem";
           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync(URL, electronicItem))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetAllItems");
        }


        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateElectronicItem(ElectronicItem item)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(BaseAddress1 + "AddElectronicItem", item))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetAllItems");
        }


        public async Task<IActionResult> DeleteElectronicItem(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(BaseAddress1 + "DeleteElectroicItem?Id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("GetAllItems");
        }


    }
}
