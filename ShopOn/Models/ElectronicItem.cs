using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ShopOn.Models
{
    public class ElectronicItem
    {
        public int ElectronicItemId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Specifications { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public bool DealOfTheDay { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
         [BindNever]
         [ValidateNever]
         public Category Category { get; set; }
    }
}
