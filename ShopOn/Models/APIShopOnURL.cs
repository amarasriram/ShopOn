using Newtonsoft.Json;
namespace ShopOn.Models
{
    public static class APIShopOnURL
    {
        public static async Task<IEnumerable<ElectronicItem>> GetApiElectronicItemsData(string APIAddress)
        {
            IEnumerable<ElectronicItem> ElectronicItemss = new List<ElectronicItem>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(APIAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ElectronicItemss = JsonConvert.DeserializeObject<IEnumerable<ElectronicItem>>(apiResponse);
                }
            }
            return ElectronicItemss;
        }


        public static async Task<IEnumerable<Category>> GetApiCategoryData(string APIAddress)
        {
            IEnumerable<Category> categories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(APIAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(apiResponse);
                }
            }
            return categories;
        }


        public static async Task<IEnumerable<CartItems>> GetApiCartData(string APIAddress)
        {
            IEnumerable<CartItems> cartItems = new List<CartItems>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(APIAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cartItems = JsonConvert.DeserializeObject<IEnumerable<CartItems>>(apiResponse);
                }
            }
            return cartItems;
        }


        public static async Task<IEnumerable<WishListItems>> GetApiWishListData(string APIAddress)
        {
            IEnumerable<WishListItems> wishListItems = new List<WishListItems>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(APIAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    wishListItems = JsonConvert.DeserializeObject<IEnumerable<WishListItems>>(apiResponse);
                }
            }
            return wishListItems;
        }

        public static async Task<string> RemoveData(string URL)
        {
            string apiResponse;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(URL))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return apiResponse;

        }
    }
}
